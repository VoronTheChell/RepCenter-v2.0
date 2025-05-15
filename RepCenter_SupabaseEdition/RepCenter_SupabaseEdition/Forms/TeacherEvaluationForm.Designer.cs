namespace RepCenter_SupabaseEdition.Forms
{
    partial class TeacherEvaluationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherEvaluationForm));
            selectTeacher_CB = new ComboBox();
            SelectUserTeacher_DGV = new DataGridView();
            buttonPublication = new Button();
            label1 = new Label();
            label2 = new Label();
            nameUser_TB = new TextBox();
            passUser_TB = new TextBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)SelectUserTeacher_DGV).BeginInit();
            SuspendLayout();
            // 
            // selectTeacher_CB
            // 
            selectTeacher_CB.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            selectTeacher_CB.FormattingEnabled = true;
            selectTeacher_CB.Location = new Point(12, 38);
            selectTeacher_CB.Name = "selectTeacher_CB";
            selectTeacher_CB.Size = new Size(949, 40);
            selectTeacher_CB.TabIndex = 0;
            // 
            // SelectUserTeacher_DGV
            // 
            SelectUserTeacher_DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SelectUserTeacher_DGV.Location = new Point(12, 103);
            SelectUserTeacher_DGV.Name = "SelectUserTeacher_DGV";
            SelectUserTeacher_DGV.Size = new Size(543, 286);
            SelectUserTeacher_DGV.TabIndex = 1;
            SelectUserTeacher_DGV.CellClick += SelectUserTeacher_DGV_CellClick;
            // 
            // buttonPublication
            // 
            buttonPublication.Font = new Font("Segoe UI Variable Small Semibol", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonPublication.Location = new Point(12, 395);
            buttonPublication.Name = "buttonPublication";
            buttonPublication.Size = new Size(949, 68);
            buttonPublication.TabIndex = 2;
            buttonPublication.Text = "Привязать учителя";
            buttonPublication.UseVisualStyleBackColor = true;
            buttonPublication.Click += buttonPublication_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 84);
            label1.Name = "label1";
            label1.Size = new Size(231, 16);
            label1.TabIndex = 3;
            label1.Text = "Выбирете аккаунт для привязки учителя:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 19);
            label2.Name = "label2";
            label2.Size = new Size(317, 16);
            label2.TabIndex = 4;
            label2.Text = "Выбирите учителя к которуму хотите привязать аккаунт:";
            // 
            // nameUser_TB
            // 
            nameUser_TB.Enabled = false;
            nameUser_TB.Font = new Font("Segoe UI Variable Text", 18F);
            nameUser_TB.Location = new Point(561, 190);
            nameUser_TB.Name = "nameUser_TB";
            nameUser_TB.ReadOnly = true;
            nameUser_TB.Size = new Size(400, 39);
            nameUser_TB.TabIndex = 5;
            // 
            // passUser_TB
            // 
            passUser_TB.Enabled = false;
            passUser_TB.Font = new Font("Segoe UI Variable Text", 18F);
            passUser_TB.Location = new Point(561, 267);
            passUser_TB.Name = "passUser_TB";
            passUser_TB.ReadOnly = true;
            passUser_TB.Size = new Size(400, 39);
            passUser_TB.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(561, 171);
            label3.Name = "label3";
            label3.Size = new Size(109, 16);
            label3.TabIndex = 7;
            label3.Text = "Имя пользователя:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(561, 248);
            label4.Name = "label4";
            label4.Size = new Size(127, 16);
            label4.TabIndex = 8;
            label4.Text = "Пароль пользователя:";
            // 
            // TeacherEvaluationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(973, 467);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(passUser_TB);
            Controls.Add(nameUser_TB);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonPublication);
            Controls.Add(SelectUserTeacher_DGV);
            Controls.Add(selectTeacher_CB);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "TeacherEvaluationForm";
            ShowInTaskbar = false;
            Text = "Настройка привязки аккаунта учителя";
            ((System.ComponentModel.ISupportInitialize)SelectUserTeacher_DGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox selectTeacher_CB;
        private DataGridView SelectUserTeacher_DGV;
        private Button buttonPublication;
        private Label label1;
        private Label label2;
        private TextBox nameUser_TB;
        private TextBox passUser_TB;
        private Label label3;
        private Label label4;
    }
}