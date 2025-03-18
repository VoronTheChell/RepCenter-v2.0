namespace RepetBase_App.Forms
{
    partial class ClipUserStudent
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
            this.buttonPublication = new System.Windows.Forms.Button();
            this.selectStudent_CB = new System.Windows.Forms.ComboBox();
            this.SelectUserStudent_DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameUser_TB = new System.Windows.Forms.TextBox();
            this.passUser_TB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SelectUserStudent_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPublication
            // 
            this.buttonPublication.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPublication.Location = new System.Drawing.Point(12, 396);
            this.buttonPublication.Name = "buttonPublication";
            this.buttonPublication.Size = new System.Drawing.Size(956, 68);
            this.buttonPublication.TabIndex = 0;
            this.buttonPublication.Text = "Привязать студента";
            this.buttonPublication.UseVisualStyleBackColor = true;
            this.buttonPublication.Click += new System.EventHandler(this.buttonPublication_Click);
            // 
            // selectStudent_CB
            // 
            this.selectStudent_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.selectStudent_CB.FormattingEnabled = true;
            this.selectStudent_CB.Location = new System.Drawing.Point(12, 62);
            this.selectStudent_CB.Name = "selectStudent_CB";
            this.selectStudent_CB.Size = new System.Drawing.Size(956, 37);
            this.selectStudent_CB.TabIndex = 1;
            // 
            // SelectUserStudent_DGV
            // 
            this.SelectUserStudent_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelectUserStudent_DGV.Location = new System.Drawing.Point(12, 133);
            this.SelectUserStudent_DGV.Name = "SelectUserStudent_DGV";
            this.SelectUserStudent_DGV.RowTemplate.Height = 24;
            this.SelectUserStudent_DGV.Size = new System.Drawing.Size(506, 257);
            this.SelectUserStudent_DGV.TabIndex = 2;
            this.SelectUserStudent_DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectUserStudent_DGV_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выбирите студента к которуму хотите привязать аккаунт:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выбирете аккаунт для привязки студента";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(315, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(360, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Настройка привязки аккаунта студента";
            // 
            // nameUser_TB
            // 
            this.nameUser_TB.Enabled = false;
            this.nameUser_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.nameUser_TB.Location = new System.Drawing.Point(524, 193);
            this.nameUser_TB.Name = "nameUser_TB";
            this.nameUser_TB.ReadOnly = true;
            this.nameUser_TB.Size = new System.Drawing.Size(444, 35);
            this.nameUser_TB.TabIndex = 6;
            // 
            // passUser_TB
            // 
            this.passUser_TB.Enabled = false;
            this.passUser_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.passUser_TB.Location = new System.Drawing.Point(524, 253);
            this.passUser_TB.Name = "passUser_TB";
            this.passUser_TB.ReadOnly = true;
            this.passUser_TB.Size = new System.Drawing.Size(444, 35);
            this.passUser_TB.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(524, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Имя пользователя:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(524, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Пароль пользователя:";
            // 
            // ClipUserStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 466);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.passUser_TB);
            this.Controls.Add(this.nameUser_TB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectUserStudent_DGV);
            this.Controls.Add(this.selectStudent_CB);
            this.Controls.Add(this.buttonPublication);
            this.Name = "ClipUserStudent";
            this.Text = "Настройка привязки аккаунта студента";
            ((System.ComponentModel.ISupportInitialize)(this.SelectUserStudent_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPublication;
        private System.Windows.Forms.ComboBox selectStudent_CB;
        private System.Windows.Forms.DataGridView SelectUserStudent_DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameUser_TB;
        private System.Windows.Forms.TextBox passUser_TB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}