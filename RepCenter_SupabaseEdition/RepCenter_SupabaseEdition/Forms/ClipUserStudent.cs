using System.Data;
using System.Net;
using System.Net.Mail;

namespace RepCenter_SupabaseEdition.Forms
{
    public partial class ClipUserStudent : Form
    {
        private int selectedRow;
        private readonly SupabaseService _service = new SupabaseService();

        public ClipUserStudent()
        {
            InitializeComponent();
            AppConfig();
        }

        private async void AppConfig()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;

            selectStudent_CB.DropDownStyle = ComboBoxStyle.DropDownList;

            SelectUserStudent_DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            await _service.InitAsync();
            await LoadStudentsToComboBoxAsync();
            await LoadStudentUsersToGridAsync();
        }

        private async Task LoadStudentsToComboBoxAsync()
        {
            selectStudent_CB.Items.Clear();

            var response = await _service.supabase
                .From<Student>()
                .Filter("id_user", Supabase.Postgrest.Constants.Operator.Is, "null")
                .Get();

            foreach (var student in response.Models)
            {
                if (!string.IsNullOrWhiteSpace(student.FIO))
                    selectStudent_CB.Items.Add(student.FIO);
            }
        }

        private async Task LoadStudentUsersToGridAsync()
        {
            var response = await _service.supabase
                .From<Register>()
                .Filter("status_user", Supabase.Postgrest.Constants.Operator.Equals, "учащийся")
                .Get();

            SelectUserStudent_DGV.DataSource = response.Models.Select(r => new
            {
                Логин = r.LoginUser,
                Пароль = r.PasswordUser,
                Предмет = r.SubjectUser
            }).ToList();
        }

        private void SelectUserStudent_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (selectedRow >= 0)
            {
                var row = SelectUserStudent_DGV.Rows[selectedRow];
                nameUser_TB.Text = row.Cells["Логин"].Value.ToString();
            }
        }

        private async void buttonPublication_Click(object sender, EventArgs e)
        {
            if (selectStudent_CB.Text == null && nameUser_TB.Text == null)
            {
                MessageBox.Show("Выберите и студента, и пользователя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (passUser_TB.Text == null)
            {
                MessageBox.Show("Пожалуйста впишите пароль для отправки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string studentFIO = selectStudent_CB.Text;
            string selectedLogin = nameUser_TB.Text;
            string selectedPassword = passUser_TB.Text;

            var userResp = await _service.supabase
                .From<Register>()
                .Filter("login_user", Supabase.Postgrest.Constants.Operator.Equals, selectedLogin)
                .Get();

            int userID = userResp.Models.FirstOrDefault()?.IdUser ?? -1;

            var studentResp = await _service.supabase
                .From<Student>()
                .Filter("fio", Supabase.Postgrest.Constants.Operator.Equals, studentFIO)
                .Get();

            var student = studentResp.Models.FirstOrDefault();

            if (userID == -1 || student == null)
            {
                MessageBox.Show("Ошибка при получении данных пользователя или студента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            student.IdUser = userID;
            var update = await student.Update<Student>();

            if (update != null)
            {
                MessageBox.Show("Связывание выполнено успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!string.IsNullOrEmpty(student.EmailAdress))
                {
                    SendEmailToStudent(student.EmailAdress, selectedLogin, selectedPassword);
                }
                else
                {
                    MessageBox.Show("Email студента не найден. Письмо не отправлено.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                await LoadStudentsToComboBoxAsync();
                await LoadStudentUsersToGridAsync();
            }
            else
            {
                MessageBox.Show("Не удалось обновить студента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendEmailToStudent(string email, string login, string password)
        {
            try
            {
                using (var smtpClient = new SmtpClient("smtp.yandex.ru", 587))
                {
                    smtpClient.Credentials = new NetworkCredential("Kontychan@yandex.ru", "vrkzpkkvbqlblkvx");
                    smtpClient.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("Kontychan@yandex.ru"),
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
    }

}
