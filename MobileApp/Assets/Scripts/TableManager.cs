using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

public class TableManager : MonoBehaviour
{
    public GameObject rowPrefab; // Префаб строки
    public Transform content;    // Контейнер (Content) таблицы

    // Строка подключения к базе данных
    private string connectionString = "Data Source=192.168.0.105,1433; Initial Catalog=RepCenter; User ID = sa; Password=antares;;";

    // Метод для добавления строки
    public void AddRow(string[] rowData)
    {
        GameObject newRow = Instantiate(rowPrefab, content);
        Text[] cells = newRow.GetComponentsInChildren<Text>();

        for (int i = 0; i < rowData.Length; i++)
        {
            cells[i].text = rowData[i];
        }
    }

    // Метод для загрузки данных из базы данных
    private void LoadDataFromDatabase()
    {
        // Очистка существующих строк в таблице
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT 
                        r.schedule_id AS 'ID', 
                        s.FIO AS 'Ученик', 
                        t.FIO AS 'Учитель', 
                        r.Time_Learn AS 'Время начала занятия', 
                        r.Learn_Status AS 'Статус занятия'
                    FROM 
                        Raspisanie_Zaniyatiy r
                    JOIN 
                        Student s ON r.student_id = s.student_id
                    JOIN 
                        Repetitors t ON r.tutor_id = t.tutor_id;
                ";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] rowData = new string[]
                        {
                            reader["ID"].ToString(),
                            reader["Ученик"].ToString(),
                            reader["Учитель"].ToString(),
                            reader["Время начала занятия"].ToString(),
                            reader["Статус занятия"].ToString()
                        };

                        AddRow(rowData);
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            Debug.LogError("Ошибка подключения к базе данных: " + ex.Message);
        }
        catch (IndexOutOfRangeException ex)
        {
            Debug.LogError("Ошибка доступа к полю: " + ex.Message);
        }
    }

    // Метод вызывается при старте приложения
    private void Start()
    {
        LoadDataFromDatabase();
    }
}
