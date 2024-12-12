using Microsoft.VisualBasic;
using System.Diagnostics;
using System.IO;
using Timer = System.Windows.Forms.Timer;

namespace Tudás_Harca
{
    public partial class FrmMain : Form
    {
        Color btnColor = Color.FromArgb(200, 60, 60, 60);
        const int timeBetweenRounds = 1000;
        Player plr;

        const int timerInt = 15000;
        const int hudInt = 1000;

        public string plrName;
        Question q;
        const string resources = @"Properties\\Resources\\";

        List<Question> questionList = [];
        List<Enemy> enemyList = [];
        List<Question> prevQ = [];
        Random rnd = new Random();

        Timer timer = new();
        Timer timerHud = new();
        Stopwatch gameTime = new Stopwatch();

        public FrmMain()
        {
            InitializeComponent();
            plr  = new(10, 1, "Játékos");

            this.Load += FrmMainLoad;
            this.FormClosed += FrmMainFormClosed;
            monsterPbx.BackColor = Color.Transparent;
            answ1Btn.Click += AnswBtnClick;
            answ2Btn.Click += AnswBtnClick;
            answ3Btn.Click += AnswBtnClick;
            answ4Btn.Click += AnswBtnClick;
            timer.Interval = timerInt;
            timerHud.Interval = hudInt;

            gameTime.Reset();
            gameTime.Start();

            timer.Tick += TimerTick;
            timerHud.Tick += TimerHudTick;

            perk2Btn.Click += Perk2BtnClick;
            perk3Btn.Click += Perk3BtnClick;

        }

        private void FrmMainFormClosed(object? sender, FormClosedEventArgs e)
        {
            timer.Stop();
            timerHud.Stop();
            gameTime.Stop();
        }

        private void perk1Btn_Click(object sender, EventArgs e)
        {
            initQuestion();
            perk1Btn.Enabled = false;
            MessageBox.Show("Elhasználtad az új kérdés perket!");
        }

        private void Perk2BtnClick(object? sender, EventArgs e)
        {
            enemyList[0].doubleDmg = true;
            perk2Btn.Enabled = false;
            MessageBox.Show("Elhasználtad a dupla sebzés perkedet!");
        }

        private void Perk3BtnClick(object? sender, EventArgs e)
        {
            plr.shield = true;
            perk3Btn.Enabled = false;
            MessageBox.Show("Elhasználtad a pajzs perkedet");
        }

        private void TimerTick(object? sender, EventArgs e)
        {
            buttonEnabler();
            MessageBox.Show("Kifutottál az időből, a szörny megtámadott");
            plr.takeDamage(enemyList[0].dmg);
            updateScreen();
            waitQuestion(timeBetweenRounds);
        }

        private void TimerHudTick(object? sender, EventArgs e)
        {
            timerPnl.Width -= 35;
        }

        private void TimerUpdate()
        {
            timer.Interval = timerInt;
            timerHud.Interval = hudInt;
            timer.Stop();
            timerHud.Stop();
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
                        MessageBox.Show($"Sikeresen legyőzted a szörnyet, de még közel sincs vége a harcodnak!");
                    }

                }
            }
            else
            {
                btn.BackColor = Color.Red;
                plr.takeDamage(enemyList[0].dmg);
                if (plr.hp <= 0)
                {
                    MessageBox.Show("Vesztettél. A szörnyek átvették az uralmat a világ felett!👹");                    
                    this.Close();
                }
            }
            updateScreen();
            waitQuestion(timeBetweenRounds);

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
            plrHpLbl.BackColor = Color.FromArgb(168, 60, 60, 60);
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
                text: $"Gratulálok sikeresen megölted a gonosz csontvázat, ezzel megmentve a világot! \nEnnyi idő alatt mentetted meg a világot: {gameTime.ElapsedMilliseconds / 1000}s",
                caption: "Ügyes vagy, nyertél!",
                icon: MessageBoxIcon.Asterisk,
                buttons: MessageBoxButtons.OK);

            this.BackgroundImage = Image.FromFile($@"{resources}\win.png"); 
            this.BackgroundImageLayout = ImageLayout.Stretch;

        

        plrName = Interaction.InputBox("Mi a neved dicső harcos?");
            leaderBoard();
            timerHud.Enabled = false;
            timer.Enabled = false;
            timer.Tick -= TimerTick;
            timer.Tick -= TimerHudTick;
            this.Close();
        }


        private void leaderBoard()
        {
            FileStream fs = new FileStream("data.bin", FileMode.OpenOrCreate);

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
