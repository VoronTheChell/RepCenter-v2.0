using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RepetBase_App
{
    public partial class LoginUp_Form : Form
    {
        DataBase dataBase = new DataBase();

        public string USER;

        public LoginUp_Form()
        {
            InitializeComponent();

            MaximizeBox = false;
            textBox_password.UseSystemPasswordChar = true;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            textBox_login.MaxLength = 10;
            textBox_password.MaxLength = 10;

            // Привязываем событие KeyDown к каждому TextBox
            textBox_login.KeyDown += TextBox_KeyDown;
            textBox_password.KeyDown += TextBox_KeyDown;
        }

        private void LoginUp_Form_Load(object sender, EventArgs e)
        {
            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;

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

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_login.Text;
            USER = textBox_login.Text;
            var passUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            
            
           


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
                            FormScoller scollerForm = new FormScoller();

                            this.Hide();
                            scollerForm.ShowDialog();
                            this.Show();
                            break;
                        }

                    case "учитель":
                        {
                            FormTeacher teacherForm = new FormTeacher();

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
            frm_sign.Show();
            
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
