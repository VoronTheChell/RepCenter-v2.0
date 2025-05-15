using RepCenter_SupabaseEdition.Forms;


namespace RepCenter_SupabaseEdition
{
    public partial class loginUp_Form : Form
    {
        public loginUp_Form()
        {
            InitializeComponent();

            login_textBox.MaxLength = 20;
            pass_textBox.MaxLength = 20;

            MaximizeBox = false;
            pass_textBox.UseSystemPasswordChar = true;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            login_textBox.KeyDown += TextBox_KeyDown;
            pass_textBox.KeyDown += TextBox_KeyDown;
        }

        private void PictureBoxTogglePassword_Click(object sender, EventArgs e)
        {
            if (pass_textBox.UseSystemPasswordChar)
            {
                pass_textBox.UseSystemPasswordChar = false;
                PictureBoxTogglePassword.Image = Properties.Resources.open;
            }
            else
            {
                pass_textBox.UseSystemPasswordChar = true;
                PictureBoxTogglePassword.Image = Properties.Resources.close;
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }

        }

        private async void enter_button_Click(object sender, EventArgs e)
        {
            var loginUser = login_textBox.Text;
            var passUser = pass_textBox.Text;

            if (string.IsNullOrWhiteSpace(loginUser) || string.IsNullOrWhiteSpace(passUser))
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var service = new SupabaseService();
            await service.InitAsync();

            var query = await service.LoginAsync(loginUser, service.Getsupabase());

            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "Пожалуйста подождите!";
            notifyIcon1.BalloonTipText = "Выполняеться инициализация пользователя...";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ShowBalloonTip(350);

            if (query != null)
            {
                string hashedPassword = query.PasswordUser;
                string status = query.StatusUser.Trim();

                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(passUser, hashedPassword);

                if (isPasswordValid)
                {
                    MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    login_textBox.Text = "";
                    pass_textBox.Text = "";

                    switch (status)
                    {
                        case "admin":
                            var adminForm = new Admin_Form();
                            adminForm.FormClosed += (s, args) => this.Close();
                            adminForm.Show();
                            this.Hide();
                            break;

                        case "учащийся":
                            var scollerForm = new FormScoller();
                            scollerForm.FormClosed += (s, args) => this.Close();
                            scollerForm.Show();
                            this.Hide();
                            break;

                        case "учитель":
                            var teacherForm = new FormTeacher();
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
                    notifyIcon1.Icon = SystemIcons.Error;
                    notifyIcon1.Visible = true;
                    notifyIcon1.BalloonTipTitle = "Ошибка входа!";
                    notifyIcon1.BalloonTipText = "Был указан неверный пароль!";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                    notifyIcon1.ShowBalloonTip(3000);
                }
            }
            else
            {
                notifyIcon1.Icon = SystemIcons.Error;
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "Ошибка входа!";
                notifyIcon1.BalloonTipText = "Такой пользователь не найден!";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                notifyIcon1.ShowBalloonTip(3000);
            }
        }

        private void Reg_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            singUp_Form singUp = new singUp_Form();

            this.Hide();
            singUp.ShowDialog();
            this.Show();
        }
    }
}
