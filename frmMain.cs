using Microsoft.VisualBasic;
using System.Diagnostics;
using System.IO;

namespace Tudás_Harca
{
    public partial class frmMain : Form
    {
        Color btnColor = Color.FromArgb(200, 60, 60, 60);
        frmMenu menu = new();
        public string plrName;
        List<Question> questionList = [];
        List<Enemy> enemyList = [];
        List<Question> prevQ = [];
        Random rnd = new Random();
        Player plr = new(10, 1, "Játékos");
        Question q;
        const String resources = @"Properties\\Resources\\";
        System.Windows.Forms.Timer timer = new();
        System.Windows.Forms.Timer timerHud = new();
        Stopwatch gameTime = new Stopwatch();

        public frmMain()
        {
            timer.Interval = 15000;
            timerHud.Interval = 1000;
            InitializeComponent();
            this.Load += FrmMainLoad;
            this.FormClosing += FrmMainFormClosing;
            monsterPbx.BackColor = Color.Transparent;
            answ1Btn.Click += AnswBtnClick;
            answ2Btn.Click += AnswBtnClick;
            answ3Btn.Click += AnswBtnClick;
            answ4Btn.Click += AnswBtnClick;
            timer.Tick += TimerTick;
            timerHud.Tick += TimerHudTick;
            gameTime.Start();
        }

        private void FrmMainFormClosing(object? sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMainFormClosed(object? sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TimerTick(object? sender, EventArgs e)
        {
            buttonEnabler();
            MessageBox.Show("Kifutottál az időből, a szörny megtámadott");
            plr.takeDamage(enemyList[0].dmg);
            updateScreen();
            waitQuestion(2000);
        }

        private void TimerHudTick(object? sender, EventArgs e)
        {
            timerPnl.Width -= 35;
        }

        private void TimerUpdate()
        {
            timer.Start();
            timerHud.Start();
            timerPnl.Width = 520;
        }

        private void AnswBtnClick(object? sender, EventArgs e)
        {
            buttonEnabler();
            timer.Stop();
            timerHud.Stop();
            Button btn = (Button)sender;
            if (btn.Text == q.correct.Trim())
            {
                btn.BackColor = Color.Green;
                enemyList[0].takeDamage(plr.dmg);
                if (enemyList[0].hp <= 0)
                {
                    enemyList.RemoveAt(0);
                    if (enemyList.Count != 0)
                    {
                        MessageBox.Show($"Sikeresen legyőzted a szörnyet, de még közel sincs vége!");
                    }

                }
            }
            else
            {
                btn.BackColor = Color.Red;
                plr.takeDamage(enemyList[0].dmg);
                if (plr.hp <= 0)
                {
                    MessageBox.Show("Vesztettél. A szörnyek átvették az uralmat a világ felett!");
                }
            }
            updateScreen();
            waitQuestion(2000);

        }

        private void FrmMainLoad(object? sender, EventArgs e)
        {
            StreamReader sr = new StreamReader($@"{resources}\\questions.txt");
            while (!sr.EndOfStream) 
            {
                String[] data = sr.ReadLine().Split(";");
                Question q = new Question(data[0], data[1], data[2], data[3], data[4], data[5]);
                questionList.Add(q);
            }
            enemyList.Add(new Enemy("kis haver1", 1, 1, $@"{resources}\\enemy1.png"));
            enemyList.Add(new Enemy("kis haver2", 1, 2, $@"{resources}\\enemy2.png"));
            enemyList.Add(new Enemy("nagy haver", 1, 3, $@"{resources}\\pixel boss.png"));
            setupScreen();
            initQuestion();
        }




        private void setupScreen()
        {
            charPbx.ImageLocation = $@"{resources}\\pixel jo.png";
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
            plrHpLbl.Text = $"{plrName} élete: {plr.hp}";
            if (enemyList.Count > 0)
            {
                monsterPbx.ImageLocation = enemyList[0].img;
                enemyHpLbl.Text = $"A szörny élete: {enemyList[0].hp}";
            }
            else
            {
                win();
            }
 
        }

        private void win()
        {
            gameTime.Stop();
            MessageBox.Show(
                text: $"Gratulálok sikeresen megölted a gonosz csontvázat, ezzel megmentve a világot! {gameTime.ElapsedMilliseconds / 1000}s", 
                caption: "Nyertél!",
                icon: MessageBoxIcon.Asterisk,
                buttons:MessageBoxButtons.OK);
            plrName = Interaction.InputBox("Mi  a neved?");
            leaderBoard();
            Application.Exit();
        } 

        private void leaderBoard()
        {
            FileStream fs = new FileStream("data.bin", FileMode.Open);
            
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                fs.Position = fs.Length;
                bw.Write(plrName.ToString());
                bw.Write(((int)gameTime.ElapsedMilliseconds));
            }
        }
        private void initQuestion()
        {
            do
            {
                q = questionList[rnd.Next(questionList.Count)];
            }
            while (prevQ.Contains(q));
            
            questionLbl.Text = q.prompt;
            answ1Btn.Text = q.answer1;
            answ1Btn.BackColor = btnColor;
            answ2Btn.Text = q.answer2;
            answ2Btn.BackColor = btnColor;
            answ3Btn.Text = q.answer3;
            answ3Btn.BackColor = btnColor;
            answ4Btn.Text = q.answer4;
            answ4Btn.BackColor = btnColor;
            prevQ.Add(q);
            TimerUpdate();
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
