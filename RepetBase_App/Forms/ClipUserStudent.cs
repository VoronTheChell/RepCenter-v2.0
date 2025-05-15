using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RepetBase_App.Forms
{
    public partial class ClipUserStudent : Form
    {
        int selectdRow;
        DataBase dataBase = new DataBase();

        public ClipUserStudent()
        {
            InitializeComponent();
            AppConfig();
        }

        private void AppConfig()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;

            selectStudent_CB.DropDownStyle = ComboBoxStyle.DropDownList;

            FillDataGridView("SELECT login_user AS 'Логин пользователей', password_user AS 'Пароли', " +
                             "subject_user AS 'Предметы' FROM register WHERE status_user = 'учащийся'", SelectUserStudent_DGV);

            LoadScoolersToComboBox();
        }

        public void LoadScoolersToComboBox()
        {
            // Очищаем ComboBox перед заполнением
            selectStudent_CB.Items.Clear();

            // SQL-запрос для получения названий предметов из таблицы Student
            string query = "SELECT FIO FROM Student WHERE id_User IS NULL";

            // Открываем соединение и выполняем запрос
            dataBase.openConnection();
            using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Добавляем каждый предмет в ComboBox
                    selectStudent_CB.Items.Add(reader["FIO"].ToString());
                }
            }
            dataBase.closeConnection();
        }

        private int GetIDByNameStudent(string selectedName)
        {
            // Устанавливаем значение по умолчанию, если ID не найден
            int idStudent = -1;

            // Проверяем, что selectedName не равен null или пустой строке
            if (string.IsNullOrEmpty(selectedName))
            {
                MessageBox.Show("Имя студента не указано.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return idStudent;
            }

            // Открываем соединение и выполняем запрос в блоке using
            string query = "SELECT student_id FROM Student WHERE FIO = @Name";
            try
            {
                dataBase.openConnection();
                using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
                {
                    // Устанавливаем значение параметра @Name
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = selectedName;

                    // Выполняем запрос и получаем результат
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        idStudent = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обращении к базе данных: {ex.Message}", "Ошибка");
            }
            finally
            {
                // Закрываем соединение
                dataBase.closeConnection();
            }

            return idStudent;
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

        private string GetStudentEmailById(int studentID)
        {
            string email = null;
            string query = "SELECT Email_adress FROM Student WHERE student_id = @StudentID";

            try
            {
                dataBase.openConnection();
                using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        email = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении email: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }

            return email;
        }

        private void SendEmailToStudent(string email, string login, string password)
        {
            try
            {
                using (var smtpClient = new System.Net.Mail.SmtpClient("smtp.yandex.ru", 587))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential("Kontychan@yandex.ru", "vrkzpkkvbqlblkvx");
                    smtpClient.EnableSsl = true;

                    var mailMessage = new System.Net.Mail.MailMessage
                    {
                        From = new System.Net.Mail.MailAddress("max20131102@gmail.com"),
                        Subject = "Регистрация в учебном центре",
                        Body = $"Здравствуйте!\n\nВаша заявка была одобрена. Данные для входа:\n" +
                               $"Логин: {login}\nПароль: {password}\n\nС уважением, Администрация учебного центра.",
                        IsBodyHtml = false
                    };

                    mailMessage.To.Add(email);

                    smtpClient.Send(mailMessage);

                    MessageBox.Show("Письмо успешно отправлено студенту!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке письма: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            string studentName = selectStudent_CB.Text;

            // Получаем ID студента по имени
            int studentID = GetIDByNameStudent(studentName);

            // Проверяем, найден ли студент
            if (studentID == -1)
            {
                MessageBox.Show("Не удалось найти студента. Проверьте правильность выбора.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем, выбран ли пользователь в DataGridView
            if (SelectUserStudent_DGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пользователя из таблицы для связывания.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем логин и пароль выбранного пользователя
            string selectedLogin = SelectUserStudent_DGV.SelectedRows[0].Cells["Логин пользователей"].Value.ToString();
            string selectedPassword = SelectUserStudent_DGV.SelectedRows[0].Cells["Пароли"].Value.ToString();

            // Запрашиваем id_User выбранного пользователя
            int userID = GetUserIDByLogin(selectedLogin);

            // Проверяем, найден ли пользователь
            if (userID == -1)
            {
                MessageBox.Show("Не удалось найти пользователя. Проверьте данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Связываем студента с пользователем
            string query = "UPDATE Student SET id_User = @UserID WHERE student_id = @StudentID";

            try
            {
                dataBase.openConnection();
                using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Связывание выполнено успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Получаем email студента для отправки письма
                        string studentEmail = GetStudentEmailById(studentID);

                        // Отправляем письмо
                        if (!string.IsNullOrEmpty(studentEmail))
                        {
                            SendEmailToStudent(studentEmail, selectedLogin, selectedPassword);
                        }
                        else
                        {
                            MessageBox.Show("Email студента не найден. Письмо не отправлено.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // Обновляем ComboBox и DataGridView
                        LoadScoolersToComboBox();
                        FillDataGridView("SELECT login_user AS 'Логин пользователей', password_user AS 'Пароли', subject_user AS 'Предметы' FROM register WHERE status_user = 'учащийся'", SelectUserStudent_DGV);
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

        private void SelectUserStudent_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = SelectUserStudent_DGV.Rows[selectdRow];

                    nameUser_TB.Text = row.Cells[0].Value.ToString();
                    passUser_TB.Text = row.Cells[1].Value.ToString();
                }

                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
