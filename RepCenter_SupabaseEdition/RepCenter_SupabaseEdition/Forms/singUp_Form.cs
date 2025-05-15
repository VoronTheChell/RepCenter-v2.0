using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace RepCenter_SupabaseEdition.Forms
{
    public partial class singUp_Form : Form
    {
        public singUp_Form()
        {
            InitializeComponent(); AppConfig();
            LoadSubjectsToComboBox();
        }

        private void AppConfig()
        {
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            buttonReg.Enabled = false;

            comboBoxSubject.DropDownStyle = ComboBoxStyle.DropDownList;

            // Подключаем события для динамической проверки
            FIO_Student_TB.TextChanged += ValidateForm;
            email_TB.TextChanged += ValidateForm;
            comboBoxSubject.SelectedIndexChanged += ValidateForm;
            checkBox1.CheckedChanged += ValidateForm;
        }

        private async void LoadSubjectsToComboBox()
        {
            comboBoxSubject.Items.Clear();

            try
            {
                var service = new SupabaseService();
                await service.InitAsync();

                // Получаем список предметов из Supabase
                var response = await service.GetSubjects();

                // Проверяем, есть ли данные
                if (response != null && response.Count > 0)
                {
                    foreach (var subject in response)
                    {
                        comboBoxSubject.Items.Add(subject.NamePridment);
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось загрузить предметы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке предметов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string relativePath = "licenses\\license_ru.docx";
            string filePath = Path.Combine(Application.StartupPath, relativePath);

            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Файл не найден: " + filePath, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonReg_Click(object sender, EventArgs e)
        {
            var FIO = FIO_Student_TB.Text;
            var dateOfBirth = dateStudent_DTP.Text;
            var phone = nuberPhone_TB.Text;
            var email = email_TB.Text;
            var subject = comboBoxSubject.SelectedItem?.ToString();

            try
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var result = await service.RegisterStudent(FIO, dateOfBirth, phone, email, subject);

                if (result)
                {
                    MessageBox.Show("Пожалуйста ожидайте дальнейшей информации на почту, которую вы указали при регистрации!",
                                    "Ваша заявка успешно отправлена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при регистрации!", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Исключение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
