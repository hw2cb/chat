namespace Messenger
{
    partial class ucLogin
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lollipopLabel1 = new LollipopLabel();
            this.TextBoxName = new LollipopTextBox();
            this.logButton = new LollipopButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lollipopLabel1
            // 
            this.lollipopLabel1.AutoSize = true;
            this.lollipopLabel1.BackColor = System.Drawing.Color.Transparent;
            this.lollipopLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lollipopLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lollipopLabel1.Location = new System.Drawing.Point(18, 227);
            this.lollipopLabel1.Name = "lollipopLabel1";
            this.lollipopLabel1.Size = new System.Drawing.Size(96, 17);
            this.lollipopLabel1.TabIndex = 0;
            this.lollipopLabel1.Text = "Введите имя:";
            // 
            // TextBoxName
            // 
            this.TextBoxName.FocusedColor = "#508ef5";
            this.TextBoxName.FontColor = "#999999";
            this.TextBoxName.IsEnabled = true;
            this.TextBoxName.Location = new System.Drawing.Point(21, 257);
            this.TextBoxName.MaxLength = 32767;
            this.TextBoxName.Multiline = false;
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.ReadOnly = false;
            this.TextBoxName.Size = new System.Drawing.Size(251, 24);
            this.TextBoxName.TabIndex = 1;
            this.TextBoxName.Text = "Имя";
            this.TextBoxName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBoxName.UseSystemPasswordChar = false;
            // 
            // logButton
            // 
            this.logButton.BackColor = System.Drawing.Color.Transparent;
            this.logButton.BGColor = "#508ef5";
            this.logButton.FontColor = "#ffffff";
            this.logButton.Location = new System.Drawing.Point(72, 313);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(143, 41);
            this.logButton.TabIndex = 2;
            this.logButton.Text = "Войти";
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // ucLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.lollipopLabel1);
            this.Name = "ucLogin";
            this.Size = new System.Drawing.Size(290, 506);
            this.Load += new System.EventHandler(this.ucLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LollipopLabel lollipopLabel1;
        private LollipopTextBox TextBoxName;
        private LollipopButton logButton;
        private System.Windows.Forms.Label label1;
    }
}
