namespace RepetBase_App.Forms
{
    partial class StudentEvaluationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPublic = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectScooler_CB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PridmetSelect_CB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.valuesSucsses_TB = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.plusDesc_TB = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valuesSucsses_TB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(205, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = " Оценка знаний ученика ";
            // 
            // buttonPublic
            // 
            this.buttonPublic.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPublic.Location = new System.Drawing.Point(12, 639);
            this.buttonPublic.Name = "buttonPublic";
            this.buttonPublic.Size = new System.Drawing.Size(776, 65);
            this.buttonPublic.TabIndex = 1;
            this.buttonPublic.Text = "Опубликовать оценку учащегося";
            this.buttonPublic.UseVisualStyleBackColor = true;
            this.buttonPublic.Click += new System.EventHandler(this.buttonPublic_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 126);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ученик:";
            // 
            // SelectScooler_CB
            // 
            this.SelectScooler_CB.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectScooler_CB.FormattingEnabled = true;
            this.SelectScooler_CB.Location = new System.Drawing.Point(108, 161);
            this.SelectScooler_CB.Name = "SelectScooler_CB";
            this.SelectScooler_CB.Size = new System.Drawing.Size(680, 33);
            this.SelectScooler_CB.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Предмет:";
            // 
            // PridmetSelect_CB
            // 
            this.PridmetSelect_CB.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PridmetSelect_CB.FormattingEnabled = true;
            this.PridmetSelect_CB.Location = new System.Drawing.Point(108, 217);
            this.PridmetSelect_CB.Name = "PridmetSelect_CB";
            this.PridmetSelect_CB.Size = new System.Drawing.Size(680, 33);
            this.PridmetSelect_CB.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(5, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Оценка успеваемости:";
            // 
            // valuesSucsses_TB
            // 
            this.valuesSucsses_TB.Location = new System.Drawing.Point(224, 271);
            this.valuesSucsses_TB.Maximum = 50;
            this.valuesSucsses_TB.Name = "valuesSucsses_TB";
            this.valuesSucsses_TB.Size = new System.Drawing.Size(480, 45);
            this.valuesSucsses_TB.TabIndex = 8;
            this.valuesSucsses_TB.Scroll += new System.EventHandler(this.valuesSucsses_TB_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(704, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(732, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "балов";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(5, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(283, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Дополнительные коментарии:";
            // 
            // plusDesc_TB
            // 
            this.plusDesc_TB.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.plusDesc_TB.Location = new System.Drawing.Point(12, 363);
            this.plusDesc_TB.MaxLength = 5000;
            this.plusDesc_TB.Multiline = true;
            this.plusDesc_TB.Name = "plusDesc_TB";
            this.plusDesc_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.plusDesc_TB.Size = new System.Drawing.Size(776, 260);
            this.plusDesc_TB.TabIndex = 12;
            // 
            // StudentEvaluationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 716);
            this.Controls.Add(this.plusDesc_TB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.valuesSucsses_TB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PridmetSelect_CB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SelectScooler_CB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonPublic);
            this.Controls.Add(this.panel1);
            this.Name = "StudentEvaluationForm";
            this.Text = "Форма оценивания";
            this.Load += new System.EventHandler(this.StudentEvaluationForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valuesSucsses_TB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPublic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SelectScooler_CB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox PridmetSelect_CB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar valuesSucsses_TB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox plusDesc_TB;
    }
}