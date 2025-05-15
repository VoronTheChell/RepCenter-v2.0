using System;
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

            if (string.IsNullOrWhiteSpace(loginUser) || string.IsNullOrWhiteSpace(passUser))
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT id_user, password_user, status_user FROM register WHERE login_user = @Login";
            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
            command.Parameters.AddWithValue("@Login", loginUser);

            SqlDataReader reader = null;

            try
            {
                dataBase.openConnection();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int userId = reader.GetInt32(0);
                    string hashedPassword = reader.GetString(1);
                    string status = reader.GetString(2).Trim(); // <-- добавил Trim()

                    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(passUser, hashedPassword);

                    if (isPasswordValid)
                    {
                        reader.Close();
                        dataBase.closeConnection();

                        MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_login.Text = "";
                        textBox_password.Text = "";

                        // Временно добавь сюда для проверки:
                        // MessageBox.Show($"Статус пользователя: '{status}'");

                        switch (status)
                        {
                            case "admin":
                                var adminForm = new Admin_Form();
                                adminForm.FormClosed += (s, args) => this.Close();
                                adminForm.Show();
                                this.Hide();
                                break;

                            case "учащийся":
                                var scollerForm = new FormScoller(userId);
                                scollerForm.FormClosed += (s, args) => this.Close();
                                scollerForm.Show();
                                this.Hide();
                                break;

                            case "учитель":
                                var teacherForm = new FormTeacher(userId);
                                teacherForm.FormClosed += (s, args) => this.Close();
                                teacherForm.Show();
                                this.Hide();
                                break;

                            default:
                                MessageBox.Show($"Неизвестный статус пользователя: '{status}'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка входа!\nНеверный пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка входа!\nТакой пользователь не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при попытке входа: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                reader?.Close();
                dataBase.closeConnection();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
