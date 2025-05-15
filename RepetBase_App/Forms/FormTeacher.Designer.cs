
namespace RepetBase_App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTeacher));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оценкаУспеваемостиУченикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИзПрофиляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.StudentPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TimeOfWorkPage = new System.Windows.Forms.TabPage();
            this.SelectStudent_CB = new System.Windows.Forms.ComboBox();
            this.StatusZanytia_CB = new System.Windows.Forms.ComboBox();
            this.DateLearn_DTP = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.PaymentPage = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.StudentPage.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.TimeOfWorkPage.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.PaymentPage.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьКакToolStripMenuItem,
            this.оценкаУспеваемостиУченикаToolStripMenuItem,
            this.выйтиИзПрофиляToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // оценкаУспеваемостиУченикаToolStripMenuItem
            // 
            this.оценкаУспеваемостиУченикаToolStripMenuItem.Name = "оценкаУспеваемостиУченикаToolStripMenuItem";
            this.оценкаУспеваемостиУченикаToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.оценкаУспеваемостиУченикаToolStripMenuItem.Text = "Оценка успеваемости ученика";
            this.оценкаУспеваемостиУченикаToolStripMenuItem.Click += new System.EventHandler(this.оценкаУспеваемостиУченикаToolStripMenuItem_Click);
            // 
            // выйтиИзПрофиляToolStripMenuItem
            // 
            this.выйтиИзПрофиляToolStripMenuItem.Name = "выйтиИзПрофиляToolStripMenuItem";
            this.выйтиИзПрофиляToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.выйтиИзПрофиляToolStripMenuItem.Text = "Выйти из профиля";
            this.выйтиИзПрофиляToolStripMenuItem.Click += new System.EventHandler(this.выйтиИзПрофиляToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.StudentPage);
            this.tabControl1.Controls.Add(this.TimeOfWorkPage);
            this.tabControl1.Controls.Add(this.PaymentPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1112, 712);
            this.tabControl1.TabIndex = 3;
            // 
            // StudentPage
            // 
            this.StudentPage.Controls.Add(this.panel1);
            this.StudentPage.Controls.Add(this.dataGridView1);
            this.StudentPage.Location = new System.Drawing.Point(4, 22);
            this.StudentPage.Name = "StudentPage";
            this.StudentPage.Padding = new System.Windows.Forms.Padding(3);
            this.StudentPage.Size = new System.Drawing.Size(1104, 686);
            this.StudentPage.TabIndex = 0;
            this.StudentPage.Text = "Студенты";
            this.StudentPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_Search);
            this.panel1.Location = new System.Drawing.Point(6, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 52);
            this.panel1.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(752, 11);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(260, 30);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextChanged += new System.EventHandler(this.SearchAppStudents_ChangeText);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(14, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 38);
            this.label3.TabIndex = 0;
            this.label3.Text = "Страница: Студенты";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.White;
            this.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Search.Image = ((System.Drawing.Image)(resources.GetObject("btn_Search.Image")));
            this.btn_Search.Location = new System.Drawing.Point(1024, 6);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(44, 42);
            this.btn_Search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Search.TabIndex = 12;
            this.btn_Search.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1092, 611);
            this.dataGridView1.TabIndex = 0;
            // 
            // TimeOfWorkPage
            // 
            this.TimeOfWorkPage.Controls.Add(this.SelectStudent_CB);
            this.TimeOfWorkPage.Controls.Add(this.StatusZanytia_CB);
            this.TimeOfWorkPage.Controls.Add(this.DateLearn_DTP);
            this.TimeOfWorkPage.Controls.Add(this.label23);
            this.TimeOfWorkPage.Controls.Add(this.label22);
            this.TimeOfWorkPage.Controls.Add(this.label20);
            this.TimeOfWorkPage.Controls.Add(this.buttonChange);
            this.TimeOfWorkPage.Controls.Add(this.buttonNew);
            this.TimeOfWorkPage.Controls.Add(this.buttonDel);
            this.TimeOfWorkPage.Controls.Add(this.panel2);
            this.TimeOfWorkPage.Controls.Add(this.dataGridView2);
            this.TimeOfWorkPage.Location = new System.Drawing.Point(4, 22);
            this.TimeOfWorkPage.Name = "TimeOfWorkPage";
            this.TimeOfWorkPage.Padding = new System.Windows.Forms.Padding(3);
            this.TimeOfWorkPage.Size = new System.Drawing.Size(1104, 686);
            this.TimeOfWorkPage.TabIndex = 1;
            this.TimeOfWorkPage.Text = "Расписание занятия";
            this.TimeOfWorkPage.UseVisualStyleBackColor = true;
            // 
            // SelectStudent_CB
            // 
            this.SelectStudent_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.SelectStudent_CB.FormattingEnabled = true;
            this.SelectStudent_CB.Location = new System.Drawing.Point(780, 139);
            this.SelectStudent_CB.Name = "SelectStudent_CB";
            this.SelectStudent_CB.Size = new System.Drawing.Size(315, 32);
            this.SelectStudent_CB.TabIndex = 31;
            // 
            // StatusZanytia_CB
            // 
            this.StatusZanytia_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.StatusZanytia_CB.FormattingEnabled = true;
            this.StatusZanytia_CB.Items.AddRange(new object[] {
            "Занятие началось ",
            "Занятие закончилось",
            "Занятие не состоялось",
            "Занятие не началось"});
            this.StatusZanytia_CB.Location = new System.Drawing.Point(780, 247);
            this.StatusZanytia_CB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StatusZanytia_CB.Name = "StatusZanytia_CB";
            this.StatusZanytia_CB.Size = new System.Drawing.Size(315, 32);
            this.StatusZanytia_CB.TabIndex = 30;
            // 
            // DateLearn_DTP
            // 
            this.DateLearn_DTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.DateLearn_DTP.Location = new System.Drawing.Point(780, 190);
            this.DateLearn_DTP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DateLearn_DTP.Name = "DateLearn_DTP";
            this.DateLearn_DTP.Size = new System.Drawing.Size(315, 29);
            this.DateLearn_DTP.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(779, 232);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 13);
            this.label23.TabIndex = 28;
            this.label23.Text = "Статус занятия:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(780, 175);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(118, 13);
            this.label22.TabIndex = 27;
            this.label22.Text = "Дата начала занятия:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(781, 123);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 13);
            this.label20.TabIndex = 25;
            this.label20.Text = "Студенты:";
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(780, 503);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(315, 78);
            this.buttonChange.TabIndex = 18;
            this.buttonChange.Text = "Изменить запись";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(780, 417);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(315, 80);
            this.buttonNew.TabIndex = 16;
            this.buttonNew.Text = "Новая запись";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(780, 315);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(315, 96);
            this.buttonDel.TabIndex = 17;
            this.buttonDel.Text = "Удалить запись";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1092, 54);
            this.panel2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(14, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(386, 38);
            this.label4.TabIndex = 0;
            this.label4.Text = "Страница: Расписание занятия";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 66);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(768, 611);
            this.dataGridView2.TabIndex = 14;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // PaymentPage
            // 
            this.PaymentPage.Controls.Add(this.panel3);
            this.PaymentPage.Controls.Add(this.dataGridView3);
            this.PaymentPage.Location = new System.Drawing.Point(4, 22);
            this.PaymentPage.Name = "PaymentPage";
            this.PaymentPage.Size = new System.Drawing.Size(1104, 686);
            this.PaymentPage.TabIndex = 2;
            this.PaymentPage.Text = "Оплата занятия";
            this.PaymentPage.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(14, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1078, 52);
            this.panel3.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(14, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(280, 38);
            this.label5.TabIndex = 0;
            this.label5.Text = "Страница: Оплата занятия";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView3
            // 
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(14, 66);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.Size = new System.Drawing.Size(1078, 602);
            this.dataGridView3.TabIndex = 14;
            // 
            // FormTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1136, 747);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTeacher";
            this.Text = "Окно Учителя";
            this.Load += new System.EventHandler(this.FormTeacher_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.StudentPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.TimeOfWorkPage.ResumeLayout(false);
            this.TimeOfWorkPage.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.PaymentPage.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзПрофиляToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage StudentPage;
        private System.Windows.Forms.TabPage TimeOfWorkPage;
        private System.Windows.Forms.TabPage PaymentPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox btn_Search;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox StatusZanytia_CB;
        private System.Windows.Forms.DateTimePicker DateLearn_DTP;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox SelectStudent_CB;
        private System.Windows.Forms.ToolStripMenuItem оценкаУспеваемостиУченикаToolStripMenuItem;
    }
}