namespace RepCenter_SupabaseEdition.Forms
{
    partial class FormTeacher
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
            components = new System.ComponentModel.Container();
            TabMenu = new TabControl();
            StudentPage = new TabPage();
            StudentDGV = new DataGridView();
            panel2 = new Panel();
            label10 = new Label();
            panel11 = new Panel();
            TimeOfWorkPage = new TabPage();
            buttonChange = new Button();
            buttonNew = new Button();
            buttonDel = new Button();
            StatusZanytia_CB = new ComboBox();
            label4 = new Label();
            DateLearn_DTP = new DateTimePicker();
            label3 = new Label();
            SelectStudent_CB = new ComboBox();
            label2 = new Label();
            DataLearnDGV = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            PaymentPage = new TabPage();
            PaymentDGV = new DataGridView();
            panel4 = new Panel();
            label5 = new Label();
            panel5 = new Panel();
            menuStrip1 = new MenuStrip();
            файлДействиеToolStripMenuItem = new ToolStripMenuItem();
            сохранитьТаблицуКакToolStripMenuItem = new ToolStripMenuItem();
            оценкаУспеваемостиУченикаToolStripMenuItem = new ToolStripMenuItem();
            выйтиСПриложенияToolStripMenuItem = new ToolStripMenuItem();
            сведеньяToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog1 = new SaveFileDialog();
            notifyIcon1 = new NotifyIcon(components);
            TabMenu.SuspendLayout();
            StudentPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)StudentDGV).BeginInit();
            panel2.SuspendLayout();
            TimeOfWorkPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataLearnDGV).BeginInit();
            panel1.SuspendLayout();
            PaymentPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PaymentDGV).BeginInit();
            panel4.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TabMenu
            // 
            TabMenu.Controls.Add(StudentPage);
            TabMenu.Controls.Add(TimeOfWorkPage);
            TabMenu.Controls.Add(PaymentPage);
            TabMenu.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold);
            TabMenu.Location = new Point(12, 27);
            TabMenu.Name = "TabMenu";
            TabMenu.SelectedIndex = 0;
            TabMenu.Size = new Size(1112, 708);
            TabMenu.TabIndex = 0;
            // 
            // StudentPage
            // 
            StudentPage.Controls.Add(StudentDGV);
            StudentPage.Controls.Add(panel2);
            StudentPage.Location = new Point(4, 26);
            StudentPage.Name = "StudentPage";
            StudentPage.Padding = new Padding(3);
            StudentPage.Size = new Size(1104, 678);
            StudentPage.TabIndex = 0;
            StudentPage.Text = "Студенты";
            StudentPage.UseVisualStyleBackColor = true;
            // 
            // StudentDGV
            // 
            StudentDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            StudentDGV.Location = new Point(6, 106);
            StudentDGV.Name = "StudentDGV";
            StudentDGV.Size = new Size(1092, 567);
            StudentDGV.TabIndex = 18;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label10);
            panel2.Controls.Add(panel11);
            panel2.Location = new Point(6, 7);
            panel2.Name = "panel2";
            panel2.Size = new Size(1092, 93);
            panel2.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.GradientActiveCaption;
            label10.Font = new Font("Segoe UI Variable Display", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label10.Location = new Point(19, 26);
            label10.Name = "label10";
            label10.Size = new Size(154, 38);
            label10.TabIndex = 0;
            label10.Text = "Студенты";
            // 
            // panel11
            // 
            panel11.BackColor = SystemColors.GradientActiveCaption;
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.ForeColor = SystemColors.ButtonShadow;
            panel11.Location = new Point(11, 9);
            panel11.Name = "panel11";
            panel11.Size = new Size(1068, 71);
            panel11.TabIndex = 5;
            // 
            // TimeOfWorkPage
            // 
            TimeOfWorkPage.Controls.Add(buttonChange);
            TimeOfWorkPage.Controls.Add(buttonNew);
            TimeOfWorkPage.Controls.Add(buttonDel);
            TimeOfWorkPage.Controls.Add(StatusZanytia_CB);
            TimeOfWorkPage.Controls.Add(label4);
            TimeOfWorkPage.Controls.Add(DateLearn_DTP);
            TimeOfWorkPage.Controls.Add(label3);
            TimeOfWorkPage.Controls.Add(SelectStudent_CB);
            TimeOfWorkPage.Controls.Add(label2);
            TimeOfWorkPage.Controls.Add(DataLearnDGV);
            TimeOfWorkPage.Controls.Add(panel1);
            TimeOfWorkPage.Location = new Point(4, 26);
            TimeOfWorkPage.Name = "TimeOfWorkPage";
            TimeOfWorkPage.Padding = new Padding(3);
            TimeOfWorkPage.Size = new Size(1104, 678);
            TimeOfWorkPage.TabIndex = 1;
            TimeOfWorkPage.Text = "Расписание занятия";
            TimeOfWorkPage.UseVisualStyleBackColor = true;
            // 
            // buttonChange
            // 
            buttonChange.Font = new Font("Segoe UI Variable Display Semib", 14.25F, FontStyle.Bold);
            buttonChange.Location = new Point(706, 567);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(392, 68);
            buttonChange.TabIndex = 29;
            buttonChange.Text = "Изменить запись";
            buttonChange.UseVisualStyleBackColor = true;
            // 
            // buttonNew
            // 
            buttonNew.Font = new Font("Segoe UI Variable Display Semib", 14.25F, FontStyle.Bold);
            buttonNew.Location = new Point(706, 493);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(392, 68);
            buttonNew.TabIndex = 28;
            buttonNew.Text = "Новая запись";
            buttonNew.UseVisualStyleBackColor = true;
            // 
            // buttonDel
            // 
            buttonDel.Font = new Font("Segoe UI Variable Display Semib", 14.25F, FontStyle.Bold);
            buttonDel.Location = new Point(706, 419);
            buttonDel.Name = "buttonDel";
            buttonDel.Size = new Size(392, 68);
            buttonDel.TabIndex = 27;
            buttonDel.Text = "Удалить запись";
            buttonDel.UseVisualStyleBackColor = true;
            // 
            // StatusZanytia_CB
            // 
            StatusZanytia_CB.Font = new Font("Segoe UI Variable Text", 18F);
            StatusZanytia_CB.FormattingEnabled = true;
            StatusZanytia_CB.Items.AddRange(new object[] { "Занятие началось ", "Занятие закончилось", "Занятие не состоялось", "Занятие не началось" });
            StatusZanytia_CB.Location = new Point(706, 347);
            StatusZanytia_CB.Name = "StatusZanytia_CB";
            StatusZanytia_CB.Size = new Size(392, 40);
            StatusZanytia_CB.TabIndex = 26;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold);
            label4.Location = new Point(706, 328);
            label4.Name = "label4";
            label4.Size = new Size(102, 17);
            label4.TabIndex = 25;
            label4.Text = "Статус занятия:";
            // 
            // DateLearn_DTP
            // 
            DateLearn_DTP.CalendarFont = new Font("Segoe UI Variable Text", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            DateLearn_DTP.Font = new Font("Segoe UI Variable Text Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DateLearn_DTP.Location = new Point(706, 261);
            DateLearn_DTP.Name = "DateLearn_DTP";
            DateLearn_DTP.Size = new Size(392, 39);
            DateLearn_DTP.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold);
            label3.Location = new Point(706, 242);
            label3.Name = "label3";
            label3.Size = new Size(136, 17);
            label3.TabIndex = 23;
            label3.Text = "Дата начала занятия:";
            // 
            // SelectStudent_CB
            // 
            SelectStudent_CB.Font = new Font("Segoe UI Variable Text", 18F);
            SelectStudent_CB.FormattingEnabled = true;
            SelectStudent_CB.Location = new Point(706, 177);
            SelectStudent_CB.Name = "SelectStudent_CB";
            SelectStudent_CB.Size = new Size(392, 40);
            SelectStudent_CB.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(706, 153);
            label2.Name = "label2";
            label2.Size = new Size(69, 17);
            label2.TabIndex = 21;
            label2.Text = "Студенты:";
            // 
            // DataLearnDGV
            // 
            DataLearnDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataLearnDGV.Location = new Point(6, 105);
            DataLearnDGV.Name = "DataLearnDGV";
            DataLearnDGV.Size = new Size(694, 567);
            DataLearnDGV.TabIndex = 20;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(1092, 93);
            panel1.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.GradientActiveCaption;
            label1.Font = new Font("Segoe UI Variable Display", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(19, 26);
            label1.Name = "label1";
            label1.Size = new Size(300, 38);
            label1.TabIndex = 0;
            label1.Text = "Расписание занятия";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.GradientActiveCaption;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.ForeColor = SystemColors.ButtonShadow;
            panel3.Location = new Point(11, 9);
            panel3.Name = "panel3";
            panel3.Size = new Size(1068, 71);
            panel3.TabIndex = 5;
            // 
            // PaymentPage
            // 
            PaymentPage.Controls.Add(PaymentDGV);
            PaymentPage.Controls.Add(panel4);
            PaymentPage.Location = new Point(4, 26);
            PaymentPage.Name = "PaymentPage";
            PaymentPage.Size = new Size(1104, 678);
            PaymentPage.TabIndex = 2;
            PaymentPage.Text = "Оплата занятия";
            PaymentPage.UseVisualStyleBackColor = true;
            // 
            // PaymentDGV
            // 
            PaymentDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PaymentDGV.Location = new Point(6, 105);
            PaymentDGV.Name = "PaymentDGV";
            PaymentDGV.Size = new Size(1092, 567);
            PaymentDGV.TabIndex = 20;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label5);
            panel4.Controls.Add(panel5);
            panel4.Location = new Point(6, 6);
            panel4.Name = "panel4";
            panel4.Size = new Size(1092, 93);
            panel4.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.GradientActiveCaption;
            label5.Font = new Font("Segoe UI Variable Display", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(19, 26);
            label5.Name = "label5";
            label5.Size = new Size(234, 38);
            label5.TabIndex = 0;
            label5.Text = "Оплата занятия";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.GradientActiveCaption;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.ForeColor = SystemColors.ButtonShadow;
            panel5.Location = new Point(11, 9);
            panel5.Name = "panel5";
            panel5.Size = new Size(1068, 71);
            panel5.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлДействиеToolStripMenuItem, сведеньяToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1136, 25);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлДействиеToolStripMenuItem
            // 
            файлДействиеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сохранитьТаблицуКакToolStripMenuItem, оценкаУспеваемостиУченикаToolStripMenuItem, выйтиСПриложенияToolStripMenuItem });
            файлДействиеToolStripMenuItem.Name = "файлДействиеToolStripMenuItem";
            файлДействиеToolStripMenuItem.Size = new Size(117, 21);
            файлДействиеToolStripMenuItem.Text = "Файл\\Действие";
            // 
            // сохранитьТаблицуКакToolStripMenuItem
            // 
            сохранитьТаблицуКакToolStripMenuItem.Name = "сохранитьТаблицуКакToolStripMenuItem";
            сохранитьТаблицуКакToolStripMenuItem.Size = new Size(267, 22);
            сохранитьТаблицуКакToolStripMenuItem.Text = "Сохранить таблицу как...";
            сохранитьТаблицуКакToolStripMenuItem.Click += сохранитьКакToolStripMenuItem_Click;
            // 
            // оценкаУспеваемостиУченикаToolStripMenuItem
            // 
            оценкаУспеваемостиУченикаToolStripMenuItem.Name = "оценкаУспеваемостиУченикаToolStripMenuItem";
            оценкаУспеваемостиУченикаToolStripMenuItem.Size = new Size(267, 22);
            оценкаУспеваемостиУченикаToolStripMenuItem.Text = "Оценка успеваемости ученика";
            оценкаУспеваемостиУченикаToolStripMenuItem.Click += оценкаУспеваемостиУченикаToolStripMenuItem_Click;
            // 
            // выйтиСПриложенияToolStripMenuItem
            // 
            выйтиСПриложенияToolStripMenuItem.Name = "выйтиСПриложенияToolStripMenuItem";
            выйтиСПриложенияToolStripMenuItem.Size = new Size(267, 22);
            выйтиСПриложенияToolStripMenuItem.Text = "Выйти с приложения";
            выйтиСПриложенияToolStripMenuItem.Click += выйтиИзПрофиляToolStripMenuItem_Click;
            // 
            // сведеньяToolStripMenuItem
            // 
            сведеньяToolStripMenuItem.Name = "сведеньяToolStripMenuItem";
            сведеньяToolStripMenuItem.Size = new Size(79, 21);
            сведеньяToolStripMenuItem.Text = "Сведенья";
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // FormTeacher
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1136, 747);
            ControlBox = false;
            Controls.Add(TabMenu);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FormTeacher";
            ShowIcon = false;
            Text = "Окно Учителя";
            TabMenu.ResumeLayout(false);
            StudentPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)StudentDGV).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            TimeOfWorkPage.ResumeLayout(false);
            TimeOfWorkPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataLearnDGV).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            PaymentPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PaymentDGV).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl TabMenu;
        private TabPage StudentPage;
        private TabPage TimeOfWorkPage;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлДействиеToolStripMenuItem;
        private ToolStripMenuItem сохранитьТаблицуКакToolStripMenuItem;
        private ToolStripMenuItem выйтиСПриложенияToolStripMenuItem;
        private ToolStripMenuItem сведеньяToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private NotifyIcon notifyIcon1;
        private TabPage PaymentPage;
        private DataGridView StudentDGV;
        private Panel panel2;
        private Label label10;
        private Panel panel11;
        private DateTimePicker DateLearn_DTP;
        private Label label3;
        private ComboBox SelectStudent_CB;
        private Label label2;
        private DataGridView DataLearnDGV;
        private Panel panel1;
        private Label label1;
        private Panel panel3;
        private Button buttonChange;
        private Button buttonNew;
        private Button buttonDel;
        private ComboBox StatusZanytia_CB;
        private Label label4;
        private DataGridView PaymentDGV;
        private Panel panel4;
        private Label label5;
        private Panel panel5;
        private ToolStripMenuItem оценкаУспеваемостиУченикаToolStripMenuItem;
    }
}