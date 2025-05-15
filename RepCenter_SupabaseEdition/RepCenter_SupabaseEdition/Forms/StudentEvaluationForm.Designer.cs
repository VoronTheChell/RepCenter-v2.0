namespace RepCenter_SupabaseEdition.Forms
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentEvaluationForm));
            panel1 = new Panel();
            imageList1 = new ImageList(components);
            label1 = new Label();
            label2 = new Label();
            SelectScooler_CB = new ComboBox();
            PridmetSelect_CB = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            valuesSucsses_TB = new TrackBar();
            label5 = new Label();
            plusDesc_TB = new TextBox();
            buttonPublic = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)valuesSucsses_TB).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 136);
            panel1.TabIndex = 0;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display Semib", 25.25F, FontStyle.Bold);
            label1.Location = new Point(183, 46);
            label1.Name = "label1";
            label1.Size = new Size(416, 46);
            label1.TabIndex = 1;
            label1.Text = " Оценка знаний ученика ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Variable Small Semibol", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 172);
            label2.Name = "label2";
            label2.Size = new Size(83, 26);
            label2.TabIndex = 1;
            label2.Text = "Ученик:";
            // 
            // SelectScooler_CB
            // 
            SelectScooler_CB.Font = new Font("Segoe UI Variable Text", 14F);
            SelectScooler_CB.FormattingEnabled = true;
            SelectScooler_CB.Location = new Point(132, 169);
            SelectScooler_CB.Name = "SelectScooler_CB";
            SelectScooler_CB.Size = new Size(656, 34);
            SelectScooler_CB.TabIndex = 2;
            // 
            // PridmetSelect_CB
            // 
            PridmetSelect_CB.Font = new Font("Segoe UI Variable Text", 14F);
            PridmetSelect_CB.FormattingEnabled = true;
            PridmetSelect_CB.Location = new Point(132, 221);
            PridmetSelect_CB.Name = "PridmetSelect_CB";
            PridmetSelect_CB.Size = new Size(656, 34);
            PridmetSelect_CB.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Variable Small Semibol", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 224);
            label3.Name = "label3";
            label3.Size = new Size(97, 26);
            label3.TabIndex = 4;
            label3.Text = "Предмет:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Variable Small Semibol", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 281);
            label4.Name = "label4";
            label4.Size = new Size(219, 26);
            label4.TabIndex = 5;
            label4.Text = "Оценка успеваемости:";
            // 
            // valuesSucsses_TB
            // 
            valuesSucsses_TB.BackColor = SystemColors.Control;
            valuesSucsses_TB.Location = new Point(237, 275);
            valuesSucsses_TB.Name = "valuesSucsses_TB";
            valuesSucsses_TB.Size = new Size(551, 45);
            valuesSucsses_TB.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Variable Small Semibol", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(12, 332);
            label5.Name = "label5";
            label5.Size = new Size(297, 26);
            label5.TabIndex = 7;
            label5.Text = "Дополнительные коментарии:";
            // 
            // plusDesc_TB
            // 
            plusDesc_TB.Location = new Point(12, 361);
            plusDesc_TB.MaxLength = 5000;
            plusDesc_TB.Multiline = true;
            plusDesc_TB.Name = "plusDesc_TB";
            plusDesc_TB.Size = new Size(776, 252);
            plusDesc_TB.TabIndex = 8;
            // 
            // buttonPublic
            // 
            buttonPublic.Font = new Font("Segoe UI Variable Display Semib", 14F, FontStyle.Bold);
            buttonPublic.Location = new Point(13, 619);
            buttonPublic.Name = "buttonPublic";
            buttonPublic.Size = new Size(776, 91);
            buttonPublic.TabIndex = 9;
            buttonPublic.Text = "Опубликовать оценку учащегося";
            buttonPublic.UseVisualStyleBackColor = true;
            buttonPublic.Click += buttonPublic_Click;
            // 
            // StudentEvaluationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 712);
            Controls.Add(buttonPublic);
            Controls.Add(plusDesc_TB);
            Controls.Add(label5);
            Controls.Add(valuesSucsses_TB);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(PridmetSelect_CB);
            Controls.Add(SelectScooler_CB);
            Controls.Add(label2);
            Controls.Add(panel1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "StudentEvaluationForm";
            ShowIcon = false;
            Text = "Форма оценивания";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)valuesSucsses_TB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ImageList imageList1;
        private Label label2;
        private ComboBox SelectScooler_CB;
        private ComboBox PridmetSelect_CB;
        private Label label3;
        private Label label4;
        private TrackBar valuesSucsses_TB;
        private Label label5;
        private TextBox plusDesc_TB;
        private Button buttonPublic;
    }
}