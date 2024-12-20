using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

public class TableManager : MonoBehaviour
{
    public GameObject rowPrefab; // ������ ������
    public Transform content;    // ��������� (Content) �������

    // ������ ����������� � ���� ������
    private string connectionString = "Data Source=192.168.0.105,1433; Initial Catalog=RepCenter; User ID = sa; Password=antares;;";

    // ����� ��� ���������� ������
    public void AddRow(string[] rowData)
    {
        GameObject newRow = Instantiate(rowPrefab, content);
        Text[] cells = newRow.GetComponentsInChildren<Text>();

        for (int i = 0; i < rowData.Length; i++)
        {
            cells[i].text = rowData[i];
        }
    }

    // ����� ��� �������� ������ �� ���� ������
    private void LoadDataFromDatabase()
    {
        // ������� ������������ ����� � �������
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
                        s.FIO AS '������', 
                        t.FIO AS '�������', 
                        r.Time_Learn AS '����� ������ �������', 
                        r.Learn_Status AS '������ �������'
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
                            reader["������"].ToString(),
                            reader["�������"].ToString(),
                            reader["����� ������ �������"].ToString(),
                            reader["������ �������"].ToString()
                        };

                        AddRow(rowData);
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            Debug.LogError("������ ����������� � ���� ������: " + ex.Message);
        }
        catch (IndexOutOfRangeException ex)
        {
            Debug.LogError("������ ������� � ����: " + ex.Message);
        }
    }

    // ����� ���������� ��� ������ ����������
    private void Start()
    {
        LoadDataFromDatabase();
    }
}
