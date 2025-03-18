using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RepetBase_App
{
    public partial class sign_up : Form
    {
        WMPLib.WindowsMediaPlayer _player = new WMPLib.WindowsMediaPlayer();
        
        private readonly DataBase _dataBase = new DataBase();

        public sign_up()
        {
            InitializeComponent(); AppConfig();
            LoadSubjectsToComboBox();
        }

        private void AppConfig()
        {
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;

            comboBoxSubject.DropDownStyle = ComboBoxStyle.DropDownList;

            // Подключаем события для динамической проверки
            FIO_Student_TB.TextChanged += ValidateForm;
            email_TB.TextChanged += ValidateForm;
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
            buttonReg.Enabled = !string.IsNullOrWhiteSpace(FIO_Student_TB.Text) &&
                              !string.IsNullOrWhiteSpace(email_TB.Text) &&
                              !string.IsNullOrWhiteSpace(nuberPhone_TB.Text) &&
                              !string.IsNullOrWhiteSpace(email_TB.Text) &&
                              comboBoxSubject.SelectedItem != null &&
                              checkBox1.Checked;
        }

        private void email_TB_Leave(object sender, EventArgs e)
        {
            // Регулярное выражение для проверки email
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Проверка введенного значения
            if (!Regex.IsMatch(email_TB.Text, emailPattern))
            {
                // Вывод сообщения об ошибке
                MessageBox.Show("Ошибка: Введенные данные не являются корректным email-адресом.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Очистка поля
                email_TB.Clear();
            }
        }

        private void dateStudent_DTP_ValueChanged(object sender, EventArgs e)
        {
            // Получаем выбранную дату рождения
            DateTime selectedDate = dateStudent_DTP.Value;

            // Вычисляем возраст
            int age = DateTime.Now.Year - selectedDate.Year;
            if (DateTime.Now.Date < selectedDate.AddYears(age)) // Проверяем, был ли день рождения в этом году
            {
                age--;
            }

            // Проверка возраста
            if (age < 14)
            {
                MessageBox.Show("Вы слишком малы для регистрации на данный учебный центр (возраст менее 14 лет).",
                                "Ошибка возраста",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                // Сбрасываем дату на сегодняшнюю
                dateStudent_DTP.Value = DateTime.Now.Date;
            }
            else
            {
                // Генерация чисел для умножения
                Random random = new Random();
                int number1 = random.Next(1, 10); // Число от 1 до 9
                int number2 = random.Next(1, 10);

                // Задаем вопрос пользователю
                string question = $"Для подтверждения возраста решите пример: {number1} x {number2} = ?";
                string input = Microsoft.VisualBasic.Interaction.InputBox(question,
                                    "Подтверждение возраста",
                                    "");

                // Проверка ответа
                if (int.TryParse(input, out int result) && result == number1 * number2)
                {
                    MessageBox.Show("Возраст успешно подтвержден!",
                                    "Подтверждение",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Неправильный ответ. Регистрация невозможна.",
                                    "Ошибка подтверждения",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    // Сбрасываем дату на сегодняшнюю
                    dateStudent_DTP.Value = DateTime.Now.Date;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var FIO = FIO_Student_TB.Text;

            DateTime selectedDate = dateStudent_DTP.Value;
            string date = selectedDate.ToString("dd.MM.yyyy");
            
            var numberPhone = nuberPhone_TB.Text;
            var email = email_TB.Text;
            var subject = comboBoxSubject.SelectedItem?.ToString();

            const string query = "INSERT INTO Student (id_User, FIO, Date_Birth, Number_Phone, Email_adress, Predmet) " +
                                 "VALUES (null, @FIO, @DateStudent, @PhoneNumber, @Email, @Predmet)";
            
            using (var command = new SqlCommand(query, _dataBase.GetConnection()))
            {
                command.Parameters.AddWithValue("@FIO", FIO);
                command.Parameters.AddWithValue("@DateStudent", date);
                command.Parameters.AddWithValue("@PhoneNumber", numberPhone);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Predmet", subject);

                _dataBase.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Пожалуйста ожидайте дальнейшей информации на почту которую вы указали при регистрации!", 
                                    $"Ваша заявка успешно отправлена!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Возникла ошибка при регистрации!", "Ошибка регистрации!");
                }

                _player.controls.stop();
                _dataBase.closeConnection();
            }
        }

        private void signUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            _dataBase.closeConnection();
            _player.controls.stop();
        }
    }
}
