namespace RepCenter_SupabaseEdition.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClipUserStudent));
            selectStudent_CB = new ComboBox();
            SelectUserStudent_DGV = new DataGridView();
            buttonPublication = new Button();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label3 = new Label();
            passUser_TB = new TextBox();
            nameUser_TB = new TextBox();
            ((System.ComponentModel.ISupportInitialize)SelectUserStudent_DGV).BeginInit();
            SuspendLayout();
            // 
            // selectStudent_CB
            // 
            selectStudent_CB.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            selectStudent_CB.FormattingEnabled = true;
            selectStudent_CB.Location = new Point(12, 34);
            selectStudent_CB.Name = "selectStudent_CB";
            selectStudent_CB.Size = new Size(956, 40);
            selectStudent_CB.TabIndex = 0;
            // 
            // SelectUserStudent_DGV
            // 
            SelectUserStudent_DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SelectUserStudent_DGV.Location = new Point(12, 96);
            SelectUserStudent_DGV.Name = "SelectUserStudent_DGV";
            SelectUserStudent_DGV.Size = new Size(546, 284);
            SelectUserStudent_DGV.TabIndex = 1;
            SelectUserStudent_DGV.CellClick += SelectUserStudent_DGV_CellClick;
            // 
            // buttonPublication
            // 
            buttonPublication.Font = new Font("Segoe UI Variable Display Semib", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonPublication.Location = new Point(12, 386);
            buttonPublication.Name = "buttonPublication";
            buttonPublication.Size = new Size(956, 77);
            buttonPublication.TabIndex = 2;
            buttonPublication.Text = "Привязать студента";
            buttonPublication.UseVisualStyleBackColor = true;
            buttonPublication.Click += buttonPublication_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 77);
            label1.Name = "label1";
            label1.Size = new Size(236, 16);
            label1.TabIndex = 3;
            label1.Text = "Выбирете аккаунт для привязки студента:\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 15);
            label2.Name = "label2";
            label2.Size = new Size(322, 16);
            label2.TabIndex = 4;
            label2.Text = "Выбирите студента к которуму хотите привязать аккаунт:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(564, 245);
            label4.Name = "label4";
            label4.Size = new Size(177, 16);
            label4.TabIndex = 12;
            label4.Text = "Впишите пароль пользователя:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(564, 168);
            label3.Name = "label3";
            label3.Size = new Size(109, 16);
            label3.TabIndex = 11;
            label3.Text = "Имя пользователя:";
            // 
            // passUser_TB
            // 
            passUser_TB.Font = new Font("Segoe UI Variable Text", 18F);
            passUser_TB.Location = new Point(564, 264);
            passUser_TB.Name = "passUser_TB";
            passUser_TB.Size = new Size(404, 39);
            passUser_TB.TabIndex = 10;
            // 
            // nameUser_TB
            // 
            nameUser_TB.Enabled = false;
            nameUser_TB.Font = new Font("Segoe UI Variable Text", 18F);
            nameUser_TB.Location = new Point(564, 187);
            nameUser_TB.Name = "nameUser_TB";
            nameUser_TB.ReadOnly = true;
            nameUser_TB.Size = new Size(404, 39);
            nameUser_TB.TabIndex = 9;
            // 
            // ClipUserStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(980, 466);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(passUser_TB);
            Controls.Add(nameUser_TB);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonPublication);
            Controls.Add(SelectUserStudent_DGV);
            Controls.Add(selectStudent_CB);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClipUserStudent";
            Text = "Настройка привязки аккаунта студента";
            ((System.ComponentModel.ISupportInitialize)SelectUserStudent_DGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox selectStudent_CB;
        private DataGridView SelectUserStudent_DGV;
        private Button buttonPublication;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label3;
        private TextBox passUser_TB;
        private TextBox nameUser_TB;
    }
}