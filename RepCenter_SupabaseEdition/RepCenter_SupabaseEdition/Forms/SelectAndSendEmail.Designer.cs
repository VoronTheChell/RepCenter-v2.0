namespace RepCenter_SupabaseEdition.Forms
{
    partial class SelectAndSendEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectAndSendEmail));
            buttonSendCheck = new Button();
            dragdropPanel = new Panel();
            label1 = new Label();
            Email_comboBox = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dragdropPanel.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSendCheck
            // 
            buttonSendCheck.Font = new Font("Segoe UI Variable Small Semibol", 12F, FontStyle.Bold);
            buttonSendCheck.Location = new Point(12, 188);
            buttonSendCheck.Name = "buttonSendCheck";
            buttonSendCheck.Size = new Size(689, 58);
            buttonSendCheck.TabIndex = 0;
            buttonSendCheck.Text = "Отправить чек";
            buttonSendCheck.UseVisualStyleBackColor = true;
            buttonSendCheck.Click += buttonSendCheck_Click;
            // 
            // dragdropPanel
            // 
            dragdropPanel.BackColor = Color.Gainsboro;
            dragdropPanel.BorderStyle = BorderStyle.FixedSingle;
            dragdropPanel.Controls.Add(label1);
            dragdropPanel.Location = new Point(248, 108);
            dragdropPanel.Name = "dragdropPanel";
            dragdropPanel.Size = new Size(453, 74);
            dragdropPanel.TabIndex = 1;
            dragdropPanel.DragDrop += dragdropPanel_DragDrop;
            dragdropPanel.DragEnter += dragdropPanel_DragEnter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Small Semibol", 12F, FontStyle.Bold);
            label1.Location = new Point(129, 25);
            label1.Name = "label1";
            label1.Size = new Size(199, 21);
            label1.TabIndex = 0;
            label1.Text = "Вставте cюда файл чека";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Email_comboBox
            // 
            Email_comboBox.Font = new Font("Segoe UI Variable Text", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Email_comboBox.FormattingEnabled = true;
            Email_comboBox.Location = new Point(248, 62);
            Email_comboBox.Name = "Email_comboBox";
            Email_comboBox.Size = new Size(453, 40);
            Email_comboBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Variable Display Semib", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 70);
            label2.Name = "label2";
            label2.Size = new Size(230, 26);
            label2.TabIndex = 3;
            label2.Text = "Выбирете email ученика:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Variable Display Semib", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 130);
            label3.Name = "label3";
            label3.Size = new Size(178, 26);
            label3.TabIndex = 4;
            label3.Text = "Вставте файл чека:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Variable Display Semib", 18.25F, FontStyle.Bold);
            label4.Location = new Point(169, 13);
            label4.Name = "label4";
            label4.Size = new Size(389, 33);
            label4.TabIndex = 5;
            label4.Text = "Настройка отправки документа";
            // 
            // SelectAndSendEmail
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(713, 250);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Email_comboBox);
            Controls.Add(dragdropPanel);
            Controls.Add(buttonSendCheck);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "SelectAndSendEmail";
            Text = "Настройка отправки документа";
            dragdropPanel.ResumeLayout(false);
            dragdropPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSendCheck;
        private Panel dragdropPanel;
        private ComboBox Email_comboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}