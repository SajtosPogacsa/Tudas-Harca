namespace Tudás_Harca
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            titleLbl = new Label();
            startBtn = new Button();
            ldbBtn = new Button();
            exitBtn = new Button();
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.BackColor = Color.FromArgb(244, 244, 244);
            titleLbl.Font = new Font("Segoe UI", 32F);
            titleLbl.ForeColor = SystemColors.HighlightText;
            titleLbl.Location = new Point(186, 70);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(259, 59);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Tudás Harca";
            titleLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // startBtn
            // 
            startBtn.BackColor = Color.DarkGray;
            startBtn.FlatAppearance.BorderSize = 0;
            startBtn.FlatStyle = FlatStyle.Flat;
            startBtn.Font = new Font("Segoe UI", 12F);
            startBtn.ForeColor = Color.Azure;
            startBtn.Location = new Point(215, 354);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(200, 50);
            startBtn.TabIndex = 4;
            startBtn.Text = "Start Game";
            startBtn.UseVisualStyleBackColor = false;
            // 
            // ldbBtn
            // 
            ldbBtn.BackColor = Color.DarkGray;
            ldbBtn.FlatAppearance.BorderSize = 0;
            ldbBtn.FlatStyle = FlatStyle.Flat;
            ldbBtn.Font = new Font("Segoe UI", 12F);
            ldbBtn.ForeColor = Color.Azure;
            ldbBtn.Location = new Point(215, 410);
            ldbBtn.Name = "ldbBtn";
            ldbBtn.Size = new Size(200, 50);
            ldbBtn.TabIndex = 4;
            ldbBtn.Text = "LeaderBoard";
            ldbBtn.UseVisualStyleBackColor = false;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = Color.DarkGray;
            exitBtn.FlatAppearance.BorderSize = 0;
            exitBtn.FlatStyle = FlatStyle.Flat;
            exitBtn.Font = new Font("Segoe UI", 12F);
            exitBtn.ForeColor = Color.Azure;
            exitBtn.Location = new Point(215, 466);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(200, 50);
            exitBtn.TabIndex = 4;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = false;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(604, 611);
            Controls.Add(exitBtn);
            Controls.Add(ldbBtn);
            Controls.Add(startBtn);
            Controls.Add(titleLbl);
            Name = "frmMenu";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLbl;
        private Button startBtn;
        private Button ldbBtn;
        private Button exitBtn;
    }
}