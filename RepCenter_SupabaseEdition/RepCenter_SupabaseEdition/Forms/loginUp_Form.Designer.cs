namespace RepCenter_SupabaseEdition
{
    partial class loginUp_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginUp_Form));
            enter_button = new Button();
            Reg_link = new LinkLabel();
            login_textBox = new TextBox();
            pass_textBox = new TextBox();
            PictureBoxTogglePassword = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            notifyIcon1 = new NotifyIcon(components);
            ((System.ComponentModel.ISupportInitialize)PictureBoxTogglePassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // enter_button
            // 
            enter_button.BackColor = Color.Azure;
            enter_button.Font = new Font("Segoe UI Variable Text", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            enter_button.Location = new Point(12, 468);
            enter_button.Name = "enter_button";
            enter_button.Size = new Size(479, 92);
            enter_button.TabIndex = 0;
            enter_button.Text = "Войти";
            enter_button.UseVisualStyleBackColor = false;
            enter_button.Click += enter_button_Click;
            // 
            // Reg_link
            // 
            Reg_link.AutoSize = true;
            Reg_link.Location = new Point(133, 574);
            Reg_link.Name = "Reg_link";
            Reg_link.Size = new Size(245, 16);
            Reg_link.TabIndex = 1;
            Reg_link.TabStop = true;
            Reg_link.Text = "Нет профиля, заргистрируйся уже сегодня!";
            Reg_link.LinkClicked += Reg_link_LinkClicked;
            // 
            // login_textBox
            // 
            login_textBox.Font = new Font("Segoe UI Variable Display", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            login_textBox.Location = new Point(12, 316);
            login_textBox.Name = "login_textBox";
            login_textBox.Size = new Size(479, 46);
            login_textBox.TabIndex = 2;
            // 
            // pass_textBox
            // 
            pass_textBox.Font = new Font("Segoe UI Variable Display", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            pass_textBox.Location = new Point(12, 399);
            pass_textBox.Name = "pass_textBox";
            pass_textBox.Size = new Size(425, 46);
            pass_textBox.TabIndex = 3;
            // 
            // PictureBoxTogglePassword
            // 
            PictureBoxTogglePassword.Image = Properties.Resources.close;
            PictureBoxTogglePassword.Location = new Point(443, 399);
            PictureBoxTogglePassword.Name = "PictureBoxTogglePassword";
            PictureBoxTogglePassword.Size = new Size(48, 46);
            PictureBoxTogglePassword.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxTogglePassword.TabIndex = 4;
            PictureBoxTogglePassword.TabStop = false;
            PictureBoxTogglePassword.Click += PictureBoxTogglePassword_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Text", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(212, 287);
            label1.Name = "label1";
            label1.Size = new Size(70, 26);
            label1.TabIndex = 5;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Variable Text", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(206, 369);
            label2.Name = "label2";
            label2.Size = new Size(83, 26);
            label2.TabIndex = 6;
            label2.Text = "Пароль";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.logo_image;
            pictureBox2.Location = new Point(12, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(479, 272);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // loginUp_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(503, 614);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PictureBoxTogglePassword);
            Controls.Add(pass_textBox);
            Controls.Add(login_textBox);
            Controls.Add(Reg_link);
            Controls.Add(enter_button);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "loginUp_Form";
            ShowIcon = false;
            Text = "Вход в аккаунт";
            ((System.ComponentModel.ISupportInitialize)PictureBoxTogglePassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button enter_button;
        private LinkLabel Reg_link;
        private TextBox login_textBox;
        private TextBox pass_textBox;
        private PictureBox PictureBoxTogglePassword;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox2;
        private NotifyIcon notifyIcon1;
    }
}
