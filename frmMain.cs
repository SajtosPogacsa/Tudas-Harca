using System.Drawing.Text;
using Tudás_Harca.Properties;

namespace Tudás_Harca
{
    public partial class frmMain : Form
    {
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
            setupScreen();
            waitQuestion(2000);
        }

        private void FrmMainLoad(object? sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"H:\\repos\\Tudás Harca\\Resources\\questions.txt");
            while (!sr.EndOfStream) 
            {
                String[] data = sr.ReadLine().Split(";");
                Question q = new Question(data[0], data[1], data[2], data[3], data[4], data[5]);
                questionList.Add(q);
            }
            enemyList.Add(new Enemy("kis haver1", 1, 1, @"H:\\repos\\Tudás Harca\\Resources\\enemy1.png"));
            enemyList.Add(new Enemy("kis haver2", 3, 2, @"H:\\repos\\Tudás Harca\\Resources\\enemy2.png"));
            enemyList.Add(new Enemy("nagy haver", 10, 3, @"H:\\repos\\Tudás Harca\\Resources\\pixel boss.png"));
            setupScreen();
            initQuestion();
        }

        private void setupScreen()
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
            answ1Btn.BackColor = Control.DefaultBackColor;
            answ2Btn.Text = q.answer2;
            answ2Btn.BackColor = Control.DefaultBackColor;
            answ3Btn.Text = q.answer3;
            answ3Btn.BackColor = Control.DefaultBackColor;
            answ4Btn.Text = q.answer4;
            answ4Btn.BackColor = Control.DefaultBackColor;
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
