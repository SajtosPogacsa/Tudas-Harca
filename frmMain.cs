using System.Drawing.Text;
using System.Security.Cryptography;
using Tudás_Harca.Properties;

namespace Tudás_Harca
{
    public partial class frmMain : Form
    {
        Color btnColor = Color.FromArgb(200, 60, 60, 60);

        List<Question> questionList = [];
        List<Enemy> enemyList = [];
        Random rnd = new Random();
        Player plr = new(10, 1, "Játékos");
        Question q;
        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMainLoad;
            monsterPbx.BackColor = Color.Transparent;
            answ1Btn.Click += AnswBtnClick;
            answ2Btn.Click += AnswBtnClick;
            answ3Btn.Click += AnswBtnClick;
            answ4Btn.Click += AnswBtnClick;
        }

        private void AnswBtnClick(object? sender, EventArgs e)
        {
            buttonEnabler();
            Button btn = (Button)sender;
            if (btn.Text == q.correct.Trim())
            {
                btn.BackColor = Color.Green;
                enemyList[0].takeDamage(plr.dmg);
                if (enemyList[0].hp <= 0)
                {
                    enemyList.RemoveAt(0);
                    MessageBox.Show("Sikeresen legyőzted a szörnyet, de még közel sincs vége!");
                }
            }
            else
            {
                btn.BackColor = Color.Red;
                plr.takeDamage(enemyList[0].dmg);
                if (plr.hp <= 0)
                {
                    MessageBox.Show("GATYAXDDD");
                }
            }
            updateScreen();
            waitQuestion(2000);
        }

        private void FrmMainLoad(object? sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"Properties\\Resources\\questions.txt");
            while (!sr.EndOfStream) 
            {
                String[] data = sr.ReadLine().Split(";");
                Question q = new Question(data[0], data[1], data[2], data[3], data[4], data[5]);
                questionList.Add(q);
            }
            enemyList.Add(new Enemy("kis haver1", 1, 1, @"Properties\\Resources\\enemy1.png"));
            enemyList.Add(new Enemy("kis haver2", 3, 2, @"Properties\\Resources\\enemy2.png"));
            enemyList.Add(new Enemy("nagy haver", 10, 3, @"Properties\\Resources\\pixel boss.png"));
            setupScreen();
            initQuestion();
        }

        private void setupScreen()
        {
            charPbx.ImageLocation = @"Properties\\Resources\\pixel jo.png";
            questionLbl.BackColor = Color.FromArgb(168, 60, 60, 60);
            enemyHpLbl.BackColor = Color.FromArgb(168, 60, 60, 60);
            plrHpLbl.BackColor = Color.FromArgb(168,60,60,60);
            perk1Btn.BackColor = btnColor;
            perk2Btn.BackColor = btnColor;
            perk3Btn.BackColor = btnColor;
            updateScreen();
        }


        private void updateScreen()
        {
            plrHpLbl.Text = $"Az életed: {plr.hp}";
            monsterPbx.ImageLocation = enemyList[0].img;
            enemyHpLbl.Text = $"A szörny élete: {enemyList[0].hp}";
 
        }

        private void initQuestion()
        {
            q = questionList[rnd.Next(questionList.Count)];
            questionLbl.Text = q.prompt;
            answ1Btn.Text = q.answer1;
            answ1Btn.BackColor = btnColor;
            answ2Btn.Text = q.answer2;
            answ2Btn.BackColor = btnColor;
            answ3Btn.Text = q.answer3;
            answ3Btn.BackColor = btnColor;
            answ4Btn.Text = q.answer4;
            answ4Btn.BackColor = btnColor;
        }
        async private void waitQuestion(int time)
        {
            await Task.Delay(time);

            initQuestion();
            buttonEnabler();
        }

        private void buttonEnabler()
        {
            if (answ1Btn.Enabled) answ1Btn.Enabled = false; else answ1Btn.Enabled = true;
            if (answ2Btn.Enabled) answ2Btn.Enabled = false; else answ2Btn.Enabled = true;
            if (answ3Btn.Enabled) answ3Btn.Enabled = false; else answ3Btn.Enabled = true;
            if (answ4Btn.Enabled) answ4Btn.Enabled = false; else answ4Btn.Enabled = true;
        }
    }
}
