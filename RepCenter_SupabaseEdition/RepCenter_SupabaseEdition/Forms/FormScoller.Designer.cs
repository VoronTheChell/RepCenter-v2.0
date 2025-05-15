namespace RepCenter_SupabaseEdition.Forms
{
    partial class FormScoller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScoller));
            menuStrip1 = new MenuStrip();
            файлДействиеToolStripMenuItem = new ToolStripMenuItem();
            сохранитьТаблицуКакToolStripMenuItem = new ToolStripMenuItem();
            выйтиСПриложенияToolStripMenuItem = new ToolStripMenuItem();
            сведеньяToolStripMenuItem = new ToolStripMenuItem();
            TabMenu = new TabControl();
            TimeOfWorkPage = new TabPage();
            DataLearnDGV = new DataGridView();
            panel2 = new Panel();
            label10 = new Label();
            panel11 = new Panel();
            PaymentPage = new TabPage();
            PaymentDGV = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            notifyIcon1 = new NotifyIcon(components);
            saveFileDialog1 = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            TabMenu.SuspendLayout();
            TimeOfWorkPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataLearnDGV).BeginInit();
            panel2.SuspendLayout();
            PaymentPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PaymentDGV).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлДействиеToolStripMenuItem, сведеньяToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1136, 25);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлДействиеToolStripMenuItem
            // 
            файлДействиеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сохранитьТаблицуКакToolStripMenuItem, выйтиСПриложенияToolStripMenuItem });
            файлДействиеToolStripMenuItem.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold);
            файлДействиеToolStripMenuItem.Name = "файлДействиеToolStripMenuItem";
            файлДействиеToolStripMenuItem.Size = new Size(117, 21);
            файлДействиеToolStripMenuItem.Text = "Файл\\Действие";
            // 
            // сохранитьТаблицуКакToolStripMenuItem
            // 
            сохранитьТаблицуКакToolStripMenuItem.Name = "сохранитьТаблицуКакToolStripMenuItem";
            сохранитьТаблицуКакToolStripMenuItem.Size = new Size(228, 22);
            сохранитьТаблицуКакToolStripMenuItem.Text = "Сохранить таблицу как...";
            сохранитьТаблицуКакToolStripMenuItem.Click += сохранитьКакToolStripMenuItem_Click;
            // 
            // выйтиСПриложенияToolStripMenuItem
            // 
            выйтиСПриложенияToolStripMenuItem.Name = "выйтиСПриложенияToolStripMenuItem";
            выйтиСПриложенияToolStripMenuItem.Size = new Size(228, 22);
            выйтиСПриложенияToolStripMenuItem.Text = "Выйти с приложения";
            выйтиСПриложенияToolStripMenuItem.Click += выйтиСАккаунтаToolStripMenuItem_Click;
            // 
            // сведеньяToolStripMenuItem
            // 
            сведеньяToolStripMenuItem.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold);
            сведеньяToolStripMenuItem.Name = "сведеньяToolStripMenuItem";
            сведеньяToolStripMenuItem.Size = new Size(79, 21);
            сведеньяToolStripMenuItem.Text = "Сведенья";
            // 
            // TabMenu
            // 
            TabMenu.Controls.Add(TimeOfWorkPage);
            TabMenu.Controls.Add(PaymentPage);
            TabMenu.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold);
            TabMenu.Location = new Point(12, 27);
            TabMenu.Name = "TabMenu";
            TabMenu.SelectedIndex = 0;
            TabMenu.Size = new Size(1112, 708);
            TabMenu.TabIndex = 1;
            // 
            // TimeOfWorkPage
            // 
            TimeOfWorkPage.Controls.Add(DataLearnDGV);
            TimeOfWorkPage.Controls.Add(panel2);
            TimeOfWorkPage.Location = new Point(4, 26);
            TimeOfWorkPage.Name = "TimeOfWorkPage";
            TimeOfWorkPage.Padding = new Padding(3);
            TimeOfWorkPage.Size = new Size(1104, 678);
            TimeOfWorkPage.TabIndex = 0;
            TimeOfWorkPage.Text = "Расписание занятия";
            TimeOfWorkPage.UseVisualStyleBackColor = true;
            // 
            // DataLearnDGV
            // 
            DataLearnDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataLearnDGV.Location = new Point(6, 105);
            DataLearnDGV.Name = "DataLearnDGV";
            DataLearnDGV.Size = new Size(1092, 567);
            DataLearnDGV.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label10);
            panel2.Controls.Add(panel11);
            panel2.Location = new Point(6, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(1092, 93);
            panel2.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.GradientActiveCaption;
            label10.Font = new Font("Segoe UI Variable Display", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label10.Location = new Point(19, 26);
            label10.Name = "label10";
            label10.Size = new Size(300, 38);
            label10.TabIndex = 0;
            label10.Text = "Расписание занятия";
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
            // PaymentPage
            // 
            PaymentPage.Controls.Add(PaymentDGV);
            PaymentPage.Controls.Add(panel1);
            PaymentPage.Location = new Point(4, 26);
            PaymentPage.Name = "PaymentPage";
            PaymentPage.Padding = new Padding(3);
            PaymentPage.Size = new Size(1104, 678);
            PaymentPage.TabIndex = 1;
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
            label1.Size = new Size(234, 38);
            label1.TabIndex = 0;
            label1.Text = "Оплата занятия";
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
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // FormScoller
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1136, 747);
            ControlBox = false;
            Controls.Add(TabMenu);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FormScoller";
            ShowIcon = false;
            Text = "Добро пожаловать ученик!";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            TabMenu.ResumeLayout(false);
            TimeOfWorkPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataLearnDGV).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            PaymentPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PaymentDGV).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлДействиеToolStripMenuItem;
        private ToolStripMenuItem сведеньяToolStripMenuItem;
        private ToolStripMenuItem сохранитьТаблицуКакToolStripMenuItem;
        private ToolStripMenuItem выйтиСПриложенияToolStripMenuItem;
        private TabControl TabMenu;
        private TabPage TimeOfWorkPage;
        private TabPage PaymentPage;
        private DataGridView DataLearnDGV;
        private Panel panel2;
        private Label label10;
        private Panel panel11;
        private DataGridView PaymentDGV;
        private Panel panel1;
        private Label label1;
        private Panel panel3;
        private NotifyIcon notifyIcon1;
        private SaveFileDialog saveFileDialog1;
    }
}