using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RepetBase_App.Forms
{
    public partial class TeacherEvaluationForm : Form
    {
        int selectdRow;
        DataBase dataBase = new DataBase();

        public TeacherEvaluationForm()
        {
            InitializeComponent();
            AppConfig();
        }

        private void AppConfig()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;

            selectTeacher_CB.DropDownStyle = ComboBoxStyle.DropDownList;

            FillDataGridView("SELECT login_user AS 'Логин пользователей', password_user AS 'Пароли', " +
                             "subject_user AS 'Предметы' FROM register WHERE status_user = 'учитель'", SelectUserTeacher_DGV);
            LoadTeachersToComboBox();
        }
        private int GetUserIDByLogin(string login)
        {
            int userID = -1;

            string query = "SELECT id_User FROM register WHERE login_user = @Login";

            try
            {
                dataBase.openConnection();
                using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Login", login);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        userID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении ID пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }

            return userID;
        }

        private void SelectUserTeacher_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = SelectUserTeacher_DGV.Rows[selectdRow];

                    nameUser_TB.Text = row.Cells[0].Value.ToString();
                    passUser_TB.Text = row.Cells[1].Value.ToString();
                }

                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        public void LoadTeachersToComboBox()
        {
            // Очищаем ComboBox перед заполнением
            selectTeacher_CB.Items.Clear();

            // SQL-запрос для получения названий предметов из таблицы Repetitors
            string query = "SELECT FIO FROM Repetitors WHERE id_User IS NULL";

            // Открываем соединение и выполняем запрос
            dataBase.openConnection();
            using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Добавляем каждый предмет в ComboBox
                    selectTeacher_CB.Items.Add(reader["FIO"].ToString());
                }
            }
            dataBase.closeConnection();
        }

        private int GetIDByNameTeacher(string selectedName)
        {
            int id_teacher = -1; // Значение по умолчанию, если ID не найден

            try
            {
                dataBase.openConnection(); // Открываем подключение
                string query = "SELECT tutor_id FROM Repetitors WHERE FIO = @Name";
                using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Name", selectedName);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        id_teacher = Convert.ToInt32(result);
                    }
                }
            }

            finally
            {
                dataBase.closeConnection(); // Закрываем подключение
            }

            return id_teacher;
        }

        private void FillDataGridView(string query, DataGridView dataGridView)
        {
            dataBase.openConnection();
            using (SqlCommand com = new SqlCommand(query, dataBase.GetConnection()))
            using (SqlDataAdapter adapter = new SqlDataAdapter(com))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView.DataSource = ds.Tables[0];
                dataGridView.AutoResizeColumns();
            }
            dataBase.closeConnection();
        }
 
        private void buttonPublication_Click(object sender, EventArgs e)
        {
            // Получаем ID учителя по имени
            int teacherID = GetIDByNameTeacher(selectTeacher_CB.Text);

            // Проверяем, найден ли учитель
            if (teacherID == -1)
            {
                MessageBox.Show("Не удалось найти учителя. Проверьте правильность выбора.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем, выбран ли студент в ComboBox
            if (selectTeacher_CB.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите студента из списка для связывания.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем логин выбранного пользователя
            string selectedLogin = SelectUserTeacher_DGV.SelectedRows[0].Cells["Логин пользователей"].Value.ToString();

            // Запрашиваем id_User выбранного пользователя
            int userID = GetUserIDByLogin(selectedLogin);

            // Проверяем, найден ли пользователь
            if (userID == -1)
            {
                MessageBox.Show("Не удалось найти пользователя. Проверьте данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Связываем студента с пользователем
            string query = "UPDATE Repetitors SET id_User = @UserID WHERE tutor_id = @StudentID";

            try
            {
                dataBase.openConnection();
                using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@StudentID", teacherID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Связывание выполнено успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Обновляем ComboBox и DataGridView
                        LoadTeachersToComboBox();
                        FillDataGridView("SELECT login_user AS 'Логин пользователей', password_user AS 'Пароли', subject_user AS 'Предметы' FROM register WHERE status_user = 'учитель'", SelectUserTeacher_DGV);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить запись. Проверьте данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении обновления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }

        }
    }
}
