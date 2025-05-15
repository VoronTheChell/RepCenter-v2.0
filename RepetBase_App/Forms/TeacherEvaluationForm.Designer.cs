namespace RepetBase_App.Forms
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.passUser_TB = new System.Windows.Forms.TextBox();
            this.nameUser_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectUserTeacher_DGV = new System.Windows.Forms.DataGridView();
            this.selectTeacher_CB = new System.Windows.Forms.ComboBox();
            this.buttonPublication = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SelectUserTeacher_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(522, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Пароль пользователя:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(522, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Имя пользователя:";
            // 
            // passUser_TB
            // 
            this.passUser_TB.BackColor = System.Drawing.SystemColors.Control;
            this.passUser_TB.Enabled = false;
            this.passUser_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.passUser_TB.Location = new System.Drawing.Point(525, 253);
            this.passUser_TB.Name = "passUser_TB";
            this.passUser_TB.ReadOnly = true;
            this.passUser_TB.Size = new System.Drawing.Size(444, 35);
            this.passUser_TB.TabIndex = 17;
            // 
            // nameUser_TB
            // 
            this.nameUser_TB.Enabled = false;
            this.nameUser_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.nameUser_TB.Location = new System.Drawing.Point(525, 193);
            this.nameUser_TB.Name = "nameUser_TB";
            this.nameUser_TB.ReadOnly = true;
            this.nameUser_TB.Size = new System.Drawing.Size(444, 35);
            this.nameUser_TB.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(313, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Настройка привязки аккаунта учителя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Выбирете аккаунт для привязки учителя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Выбирите учителя к которуму хотите привязать аккаунт:";
            // 
            // SelectUserTeacher_DGV
            // 
            this.SelectUserTeacher_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelectUserTeacher_DGV.Location = new System.Drawing.Point(10, 133);
            this.SelectUserTeacher_DGV.Name = "SelectUserTeacher_DGV";
            this.SelectUserTeacher_DGV.RowTemplate.Height = 24;
            this.SelectUserTeacher_DGV.Size = new System.Drawing.Size(506, 257);
            this.SelectUserTeacher_DGV.TabIndex = 12;
            this.SelectUserTeacher_DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectUserTeacher_DGV_CellClick);
            // 
            // selectTeacher_CB
            // 
            this.selectTeacher_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.selectTeacher_CB.FormattingEnabled = true;
            this.selectTeacher_CB.Location = new System.Drawing.Point(10, 62);
            this.selectTeacher_CB.Name = "selectTeacher_CB";
            this.selectTeacher_CB.Size = new System.Drawing.Size(956, 37);
            this.selectTeacher_CB.TabIndex = 11;
            // 
            // buttonPublication
            // 
            this.buttonPublication.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPublication.Location = new System.Drawing.Point(10, 396);
            this.buttonPublication.Name = "buttonPublication";
            this.buttonPublication.Size = new System.Drawing.Size(956, 68);
            this.buttonPublication.TabIndex = 10;
            this.buttonPublication.Text = "Привязать учителя";
            this.buttonPublication.UseVisualStyleBackColor = true;
            this.buttonPublication.Click += new System.EventHandler(this.buttonPublication_Click);
            // 
            // TeacherEvaluationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 467);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.passUser_TB);
            this.Controls.Add(this.nameUser_TB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectUserTeacher_DGV);
            this.Controls.Add(this.selectTeacher_CB);
            this.Controls.Add(this.buttonPublication);
            this.Name = "TeacherEvaluationForm";
            this.Text = "TeacherEvaluationForm";
            ((System.ComponentModel.ISupportInitialize)(this.SelectUserTeacher_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passUser_TB;
        private System.Windows.Forms.TextBox nameUser_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView SelectUserTeacher_DGV;
        private System.Windows.Forms.ComboBox selectTeacher_CB;
        private System.Windows.Forms.Button buttonPublication;
    }
}