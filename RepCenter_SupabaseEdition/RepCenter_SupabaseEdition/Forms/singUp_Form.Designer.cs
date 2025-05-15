namespace RepCenter_SupabaseEdition.Forms
{
    partial class singUp_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            comboBoxSubject = new ComboBox();
            nuberPhone_TB = new MaskedTextBox();
            dateStudent_DTP = new DateTimePicker();
            email_TB = new TextBox();
            FIO_Student_TB = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            checkBox1 = new CheckBox();
            buttonReg = new Button();
            linkLabel1 = new LinkLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Ivory;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(766, 99);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.LightCyan;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.reg;
            pictureBox1.Location = new Point(16, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(88, 81);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI Variable Text", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.Location = new Point(112, 14);
            label1.Name = "label1";
            label1.Size = new Size(635, 70);
            label1.TabIndex = 1;
            label1.Text = "Заявка на регистрацию в учебный центр";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Ivory;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(comboBoxSubject);
            panel2.Controls.Add(nuberPhone_TB);
            panel2.Controls.Add(dateStudent_DTP);
            panel2.Controls.Add(email_TB);
            panel2.Controls.Add(FIO_Student_TB);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(12, 117);
            panel2.Name = "panel2";
            panel2.Size = new Size(766, 218);
            panel2.TabIndex = 1;
            // 
            // comboBoxSubject
            // 
            comboBoxSubject.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            comboBoxSubject.FormattingEnabled = true;
            comboBoxSubject.Location = new Point(187, 157);
            comboBoxSubject.Name = "comboBoxSubject";
            comboBoxSubject.Size = new Size(511, 30);
            comboBoxSubject.TabIndex = 10;
            // 
            // nuberPhone_TB
            // 
            nuberPhone_TB.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            nuberPhone_TB.Location = new Point(187, 123);
            nuberPhone_TB.Mask = "8 (999) 000-0000";
            nuberPhone_TB.Name = "nuberPhone_TB";
            nuberPhone_TB.Size = new Size(511, 28);
            nuberPhone_TB.TabIndex = 9;
            // 
            // dateStudent_DTP
            // 
            dateStudent_DTP.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            dateStudent_DTP.Location = new Point(187, 89);
            dateStudent_DTP.Name = "dateStudent_DTP";
            dateStudent_DTP.Size = new Size(511, 28);
            dateStudent_DTP.TabIndex = 7;
            dateStudent_DTP.ValueChanged += dateStudent_DTP_ValueChanged;
            // 
            // email_TB
            // 
            email_TB.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            email_TB.Location = new Point(187, 56);
            email_TB.Name = "email_TB";
            email_TB.Size = new Size(511, 28);
            email_TB.TabIndex = 6;
            email_TB.Leave += email_TB_Leave;
            // 
            // FIO_Student_TB
            // 
            FIO_Student_TB.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            FIO_Student_TB.Location = new Point(187, 22);
            FIO_Student_TB.Name = "FIO_Student_TB";
            FIO_Student_TB.Size = new Size(511, 28);
            FIO_Student_TB.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            label6.Location = new Point(60, 160);
            label6.Name = "label6";
            label6.Size = new Size(121, 22);
            label6.TabIndex = 4;
            label6.Text = "Дисциплина:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            label5.Location = new Point(77, 124);
            label5.Name = "label5";
            label5.Size = new Size(104, 22);
            label5.TabIndex = 3;
            label5.Text = "Номер тел:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            label4.Location = new Point(34, 91);
            label4.Name = "label4";
            label4.Size = new Size(147, 22);
            label4.TabIndex = 2;
            label4.Text = "Дата рождения:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            label3.Location = new Point(116, 58);
            label3.Name = "label3";
            label3.Size = new Size(66, 22);
            label3.TabIndex = 1;
            label3.Text = "Почта:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            label2.Location = new Point(77, 25);
            label2.Name = "label2";
            label2.Size = new Size(105, 22);
            label2.TabIndex = 0;
            label2.Text = "Ваше ФИО:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI Variable Text", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBox1.Location = new Point(115, 340);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(596, 21);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Я принимаю условия соглашения и несу отвественность за предоставленную информацию";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonReg
            // 
            buttonReg.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonReg.Location = new Point(12, 362);
            buttonReg.Name = "buttonReg";
            buttonReg.Size = new Size(766, 69);
            buttonReg.TabIndex = 3;
            buttonReg.Text = "Подать заявку!";
            buttonReg.UseVisualStyleBackColor = true;
            buttonReg.Click += buttonReg_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI Variable Text", 9.75F);
            linkLabel1.Location = new Point(215, 341);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(143, 17);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Условния соглашения";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // singUp_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(790, 435);
            Controls.Add(linkLabel1);
            Controls.Add(buttonReg);
            Controls.Add(checkBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "singUp_Form";
            ShowIcon = false;
            Text = "Подача заявки";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private CheckBox checkBox1;
        private Button buttonReg;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox comboBoxSubject;
        private MaskedTextBox nuberPhone_TB;
        private DateTimePicker dateStudent_DTP;
        private TextBox email_TB;
        private TextBox FIO_Student_TB;
        private Label label6;
        private LinkLabel linkLabel1;
    }
}