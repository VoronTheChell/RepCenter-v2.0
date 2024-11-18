using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RepetBase_App
{
    public partial class sign_up : Form
    {
        private readonly WMPLib.WindowsMediaPlayer _player = new WMPLib.WindowsMediaPlayer();
        private readonly DataBase _dataBase = new DataBase();

        public sign_up()
        {
            InitializeComponent();
            LoadSubjectsToComboBox();

            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;

            // Подключаем события для динамической проверки
            textBox_login.TextChanged += ValidateForm;
            textBox_password2.TextChanged += ValidateForm;
            comboBoxSubject.SelectedIndexChanged += ValidateForm;
            checkBox1.CheckedChanged += ValidateForm;

            _player.URL = "https://kappa.vgmsite.com/soundtracks/wii-photo-channel/veyhgasoif/04%20Post%20to%20the%20Wii%20Message%20Board.mp3";
            _player.controls.play();
        }

        private void LoadSubjectsToComboBox()
        {
            comboBoxSubject.Items.Clear();
            const string query = "SELECT Name_Pridment FROM Pridments";

            _dataBase.openConnection();
            using (var command = new SqlCommand(query, _dataBase.GetConnection()))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxSubject.Items.Add(reader["Name_Pridment"].ToString());
                }
            }
            _dataBase.closeConnection();
        }

        // Метод для динамической проверки формы
        private void ValidateForm(object sender, EventArgs e)
        {
            // Проверяем, что все необходимые поля заполнены
            button1.Enabled = !string.IsNullOrWhiteSpace(textBox_login.Text) &&
                              !string.IsNullOrWhiteSpace(textBox_password2.Text) &&
                              comboBoxSubject.SelectedItem != null &&
                              checkBox1.Checked;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckUser())
            {
                return;
            }

            var login = textBox_login.Text;
            var password = textBox_password2.Text;
            var subject = comboBoxSubject.SelectedItem?.ToString();

            const string query = "INSERT INTO register (login_user, password_user, subject_user, status_user) VALUES (@login, @password, @subject, 'учащийся')";
            using (var command = new SqlCommand(query, _dataBase.GetConnection()))
            {
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@subject", subject);

                _dataBase.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт был успешно создан!", $"Добро пожаловать, пользователь {login}!");
                    var frmLogin = new LoginUp_Form();
                    Hide();
                    frmLogin.Show();
                }
                else
                {
                    MessageBox.Show("Аккаунт не был успешно создан!", "Ошибка регистрации!");
                }

                _player.controls.stop();
                _dataBase.closeConnection();
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBox_login.Clear();
            textBox_password2.Clear();
        }

        private bool CheckUser()
        {
            var loginUser = textBox_login.Text;
            var passUser = textBox_password2.Text;

            const string query = "SELECT id_user FROM register WHERE login_user = @login AND password_user = @password";
            using (var command = new SqlCommand(query, _dataBase.GetConnection()))
            {
                command.Parameters.AddWithValue("@login", loginUser);
                command.Parameters.AddWithValue("@password", passUser);

                var adapter = new SqlDataAdapter(command);
                var table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Пользователь уже зарегистрирован!", "Ошибка!");
                    return true;
                }
                return false;
            }
        }

        private void LogInLoad(object sender, EventArgs e)
        {
            textBox_password2.UseSystemPasswordChar = true;
            textBox_password2.MaxLength = 50;

            comboBoxSubject.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void PictureBoxTogglePassword_Click(object sender, EventArgs e)
        {
            // Переключаем режим отображения текста в TextBox
            if (textBox_password2.UseSystemPasswordChar)
            {
                // Показать пароль
                textBox_password2.UseSystemPasswordChar = false;
                ButtonShow.Image = Properties.Resources.open; // Установите иконку открытого глаза
            }
            else
            {
                // Скрыть пароль
                textBox_password2.UseSystemPasswordChar = true;
                ButtonShow.Image = Properties.Resources.close; // Установите иконку закрытого глаза
            }
        }

        private void signUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            _dataBase.closeConnection();
            _player.controls.stop();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(textBox_login.Text) &&
                              !string.IsNullOrWhiteSpace(textBox_password2.Text) &&
                              comboBoxSubject.SelectedItem != null &&
                              checkBox1.Checked;
        }

        private void signUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            var frmLogin = new LoginUp_Form();
            _player.controls.stop();
            Hide();
            frmLogin.Show();
        }
    }
}
