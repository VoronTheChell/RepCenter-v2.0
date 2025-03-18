using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RepetBase_App
{
    public partial class LoginUp_Form : Form
    {
        DataBase dataBase = new DataBase();

        public LoginUp_Form()
        {
            InitializeComponent();
            AppConfig();
        }

        private void AppConfig()
        {
            MaximizeBox = false;
            textBox_password.UseSystemPasswordChar = true;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            textBox_login.MaxLength = 20;
            textBox_password.MaxLength = 20;

            // Привязываем событие KeyDown к каждому TextBox
            textBox_login.KeyDown += TextBox_KeyDown;
            textBox_password.KeyDown += TextBox_KeyDown;
        }

        private void LoginUp_Form_Load(object sender, EventArgs e)
        {
            // Подключаем обработчик клика на PictureBox
            pictureBox2.Click += new EventHandler(PictureBoxTogglePassword_Click);

        }
       
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Отключает звук клавиши Enter

                // Перемещаем фокус на следующий элемент управления
                this.SelectNextControl((Control)sender, true, true, true, true);
            }

        }

        private void PictureBoxTogglePassword_Click(object sender, EventArgs e)
        {
            // Переключаем режим отображения текста в TextBox
            if (textBox_password.UseSystemPasswordChar)
            {
                // Показать пароль
                textBox_password.UseSystemPasswordChar = false;
                pictureBox2.Image = Properties.Resources.open; // Установите иконку открытого глаза
            }
            else
            {
                // Скрыть пароль
                textBox_password.UseSystemPasswordChar = true;
                pictureBox2.Image = Properties.Resources.close; // Установите иконку закрытого глаза
            }
        }

        public int GetUserIdByCredentials(string login, string password)
        {
            int userId = -1; // Значение по умолчанию, если пользователь не найден
            string query = "SELECT id_User FROM register WHERE login_user = @Login AND password_user = @Password";

            try
            {
                // Открываем соединение
                dataBase.openConnection();
                using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
                {
                    // Добавляем параметры для защиты от SQL-инъекций
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);

                    // Выполняем запрос и проверяем результат
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        userId = Convert.ToInt32(result); // Преобразуем результат в int
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении ID пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Закрываем соединение
                dataBase.closeConnection();
            }

            return userId;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_login.Text;
            var passUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            int userId = GetUserIdByCredentials(loginUser, passUser);

            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());

            // Сommand Code
            adapter.SelectCommand = command;
            adapter.Fill(table);


            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox_login.Text = "";
                textBox_password.Text = "";

                dataBase.openConnection();
                string checkStatus = $"SELECT status_user from register where login_user like '{loginUser}'";
                SqlCommand commandCheck = new SqlCommand(checkStatus, dataBase.GetConnection());
                string status = ((string)commandCheck.ExecuteScalar());

                switch (status)
                {
                    case "admin":
                        {
                            Admin_Form adminForm = new Admin_Form();

                            this.Hide();
                            adminForm.ShowDialog();
                            this.Show();
                            break;
                        }

                    case "учащийся":
                        {
                            FormScoller scollerForm = new FormScoller(userId);

                            this.Hide();
                            scollerForm.ShowDialog();
                            this.Show();
                            break;
                        }

                    case "учитель":
                        {
                            FormTeacher teacherForm = new FormTeacher(userId);

                            this.Hide();
                            teacherForm.ShowDialog();
                            this.Show();
                            break;
                        }
                }
                    

                
            }

            else
            {
                MessageBox.Show("Ошибка входа!\nТого пользователя не существует или вы вели не верный пароль!", "Ошибка...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }

        private void Reg_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sign_up frm_sign = new sign_up();
            this.Hide();
            frm_sign.ShowDialog();
            this.Show();
            
        }

        private void login_up_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataBase.closeConnection();
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = "Знания сила, cпорт могила!";
        }
    }
}
