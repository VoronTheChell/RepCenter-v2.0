using System;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace RepetBase_App.Forms
{
    public partial class SelectAndSendEmail : Form
    {
        DataBase dataBase = new DataBase();
        string filePath;
        public SelectAndSendEmail()
        {
            InitializeComponent();
            LoadEmailsIntoComboBox();
            AppOptions();
        }

        private void AppOptions()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;

            Email_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            // Включение поддержки Drag-and - Drop
            dragdropPanel.AllowDrop = true;

            // Обработчики событий DragEnter
            dragdropPanel.DragEnter += dragdropPanel_DragEnter;

            this.Controls.Add(dragdropPanel);
        }

        private void LoadEmailsIntoComboBox()
        {
            try
            {
                Email_comboBox.Items.Clear();

                // SQL-запрос для получения названий предметов из таблицы Pridments
                string query = "SELECT Email_adress FROM Student";

                // Открываем соединение и выполняем запрос
                dataBase.openConnection();
                using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Добавляем каждый предмет в ComboBox
                        Email_comboBox.Items.Add(reader["Email_adress"].ToString());
                    }
                }
                dataBase.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки email: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteQuery(string query, params (string, object)[] parameters)
        {
            dataBase.openConnection();
            using (SqlCommand com = new SqlCommand(query, dataBase.GetConnection()))
            {
                foreach (var param in parameters)
                    com.Parameters.AddWithValue(param.Item1, param.Item2);

                com.ExecuteNonQuery();
            }
            dataBase.closeConnection();
        }


        // Событие DragEnter: проверяем, является ли объект файлом
        private void dragdropPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dragdropPanel_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null && files.Length > 0)
            {
                filePath = files[0]; // Сохраняем путь к первому файлу
                string extension = Path.GetExtension(filePath).ToLower(); // Получаем расширение файла

                if (IsSupportedFormat(extension))
                {
                    label4.Text = filePath;
                    MessageBox.Show($"Файл успешно добавлен: {filePath}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("Поддерживаются только файлы форматов PDF, Excel или Word.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Проверка поддерживаемых форматов
        private bool IsSupportedFormat(string extension)
        {
            // Список поддерживаемых расширений
            string[] supportedFormats = { ".pdf", ".xls", ".xlsx", ".doc", ".docx" };
            return Array.Exists(supportedFormats, format => format == extension);
        }

        private void SendEmailWithAttachment(string fP)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.yandex.ru")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("Kontychan@yandex.ru", "vrkzpkkvbqlblkvx"),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("Kontychan@yandex.ru"),
                    Subject = "Оплата занятия",
                    Body = $"Здравствуйте!\n\n" +
                           $"Ниже будет прикреплен файл с вашим чеком.\n\nС уважением, администрация учебный центр: 'Умники и умницы'.",
                    IsBodyHtml = false
                };

                // Адрес получателя
                mailMessage.To.Add(Email_comboBox.Text);

                // Добавление вложения
                mailMessage.Attachments.Add(new Attachment(fP));

                // Отправка сообщения
                smtpClient.Send(mailMessage);

                MessageBox.Show($"Файл успешно отправлен на email: {Email_comboBox.Text}!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке email: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSendCheck_Click(object sender, EventArgs e)
        {
            SendEmailWithAttachment(filePath);
            this.Close();
        }
    }
}
