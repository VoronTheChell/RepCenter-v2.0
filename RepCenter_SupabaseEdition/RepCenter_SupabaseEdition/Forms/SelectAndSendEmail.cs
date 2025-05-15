using System.Net.Mail;
using System.Net;

namespace RepCenter_SupabaseEdition.Forms
{
    public partial class SelectAndSendEmail : Form
    {
        string filePath;

        public SelectAndSendEmail()
        {
            InitializeComponent();
            LoadEmailsIntoComboBoxAsync();
            AppOptions();
        }

        private void AppOptions()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;

            Email_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            dragdropPanel.AllowDrop = true;

            dragdropPanel.DragEnter += dragdropPanel_DragEnter;

            this.Controls.Add(dragdropPanel);
        }

        private async Task LoadEmailsIntoComboBoxAsync()
        {
            try
            {
                Email_comboBox.Items.Clear();

                var service = new SupabaseService();
                await service.InitAsync();

                var response = await service.supabase
                    .From<Student>().Select("email_adress").Get();

                foreach (var student in response.Models)
                {
                    if (!string.IsNullOrWhiteSpace(student.EmailAdress))
                        Email_comboBox.Items.Add(student.EmailAdress);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки email: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    label1.Text = "Файл готов к отправке!";
                    label1.ForeColor = Color.ForestGreen;
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
                    From = new MailAddress("info@edcenter.ru"),
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
