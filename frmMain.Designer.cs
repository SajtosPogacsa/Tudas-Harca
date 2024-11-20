namespace Tudás_Harca
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            charPbx = new PictureBox();
            monsterPbx = new PictureBox();
            perk1Btn = new Button();
            perk2Btn = new Button();
            perk3Btn = new Button();
            questionLbl = new Label();
            answ1Btn = new Button();
            answ2Btn = new Button();
            answ3Btn = new Button();
            answ4Btn = new Button();
            plrHpLbl = new Label();
            enemyHpBtn = new Label();
            ((System.ComponentModel.ISupportInitialize)charPbx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)monsterPbx).BeginInit();
            SuspendLayout();
            // 
            // charPbx
            // 
            charPbx.Image = (Image)resources.GetObject("charPbx.Image");
            charPbx.ImageLocation = "H:\\repos\\Tudás Harca\\Resources\\pixel jo.png";
            charPbx.Location = new Point(41, 12);
            charPbx.Name = "charPbx";
            charPbx.Size = new Size(200, 200);
            charPbx.TabIndex = 0;
            charPbx.TabStop = false;
            // 
            // monsterPbx
            // 
            monsterPbx.Image = (Image)resources.GetObject("monsterPbx.Image");
            monsterPbx.ImageLocation = "H:\\repos\\Tudás Harca\\Resources\\enemy1.png";
            monsterPbx.Location = new Point(359, 11);
            monsterPbx.Name = "monsterPbx";
            monsterPbx.Size = new Size(200, 200);
            monsterPbx.TabIndex = 0;
            monsterPbx.TabStop = false;
            // 
            // perk1Btn
            // 
            perk1Btn.Location = new Point(41, 234);
            perk1Btn.Name = "perk1Btn";
            perk1Btn.Size = new Size(120, 75);
            perk1Btn.TabIndex = 1;
            perk1Btn.Text = "Felezés";
            perk1Btn.UseVisualStyleBackColor = true;
            // 
            // perk2Btn
            // 
            perk2Btn.Location = new Point(241, 234);
            perk2Btn.Name = "perk2Btn";
            perk2Btn.Size = new Size(120, 75);
            perk2Btn.TabIndex = 1;
            perk2Btn.Text = "Dupla sebzés";
            perk2Btn.UseVisualStyleBackColor = true;
            // 
            // perk3Btn
            // 
            perk3Btn.Location = new Point(439, 234);
            perk3Btn.Name = "perk3Btn";
            perk3Btn.Size = new Size(120, 75);
            perk3Btn.TabIndex = 1;
            perk3Btn.Text = "Pajzs";
            perk3Btn.UseVisualStyleBackColor = true;
            // 
            // questionLbl
            // 
            questionLbl.BackColor = SystemColors.ButtonFace;
            questionLbl.Font = new Font("Segoe UI", 12F);
            questionLbl.Location = new Point(31, 312);
            questionLbl.Name = "questionLbl";
            questionLbl.Size = new Size(547, 62);
            questionLbl.TabIndex = 2;
            questionLbl.Text = "Placeholder text lorem lorem lorem lorem lorem lorem lorem lorem lorem lorem lorem lorem lorem";
            questionLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // answ1Btn
            // 
            answ1Btn.Location = new Point(41, 387);
            answ1Btn.Name = "answ1Btn";
            answ1Btn.Size = new Size(256, 85);
            answ1Btn.TabIndex = 3;
            answ1Btn.Text = "button1";
            answ1Btn.UseVisualStyleBackColor = true;
            // 
            // answ2Btn
            // 
            answ2Btn.Location = new Point(303, 387);
            answ2Btn.Name = "answ2Btn";
            answ2Btn.Size = new Size(256, 85);
            answ2Btn.TabIndex = 3;
            answ2Btn.Text = "button1";
            answ2Btn.UseVisualStyleBackColor = true;
            // 
            // answ3Btn
            // 
            answ3Btn.Location = new Point(41, 478);
            answ3Btn.Name = "answ3Btn";
            answ3Btn.Size = new Size(256, 85);
            answ3Btn.TabIndex = 3;
            answ3Btn.Text = "button1";
            answ3Btn.UseVisualStyleBackColor = true;
            // 
            // answ4Btn
            // 
            answ4Btn.Location = new Point(303, 478);
            answ4Btn.Name = "answ4Btn";
            answ4Btn.Size = new Size(256, 85);
            answ4Btn.TabIndex = 3;
            answ4Btn.Text = "button1";
            answ4Btn.UseVisualStyleBackColor = true;
            // 
            // plrHpLbl
            // 
            plrHpLbl.AutoSize = true;
            plrHpLbl.BackColor = SystemColors.ButtonFace;
            plrHpLbl.Location = new Point(88, 216);
            plrHpLbl.Name = "plrHpLbl";
            plrHpLbl.Size = new Size(73, 15);
            plrHpLbl.TabIndex = 4;
            plrHpLbl.Text = "Az életed: 10";
            // 
            // enemyHpBtn
            // 
            enemyHpBtn.AutoSize = true;
            enemyHpBtn.BackColor = SystemColors.ButtonFace;
            enemyHpBtn.Location = new Point(411, 214);
            enemyHpBtn.Name = "enemyHpBtn";
            enemyHpBtn.Size = new Size(98, 15);
            enemyHpBtn.TabIndex = 4;
            enemyHpBtn.Text = "A szörny élete: 10";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(604, 611);
            Controls.Add(enemyHpBtn);
            Controls.Add(plrHpLbl);
            Controls.Add(answ4Btn);
            Controls.Add(answ3Btn);
            Controls.Add(answ2Btn);
            Controls.Add(answ1Btn);
            Controls.Add(questionLbl);
            Controls.Add(perk3Btn);
            Controls.Add(perk2Btn);
            Controls.Add(perk1Btn);
            Controls.Add(monsterPbx);
            Controls.Add(charPbx);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmMain";
            Text = "A tudás harca";
            ((System.ComponentModel.ISupportInitialize)charPbx).EndInit();
            ((System.ComponentModel.ISupportInitialize)monsterPbx).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox charPbx;
        private PictureBox monsterPbx;
        private Button perk1Btn;
        private Button perk2Btn;
        private Button perk3Btn;
        private Label questionLbl;
        private Button answ1Btn;
        private Button answ2Btn;
        private Button answ3Btn;
        private Button answ4Btn;
        private Label plrHpLbl;
        private Label enemyHpBtn;
    }
}
