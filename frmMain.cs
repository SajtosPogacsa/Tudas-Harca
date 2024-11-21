namespace Tudás_Harca
{
    public partial class frmMain : Form
    {
        List<Question> questionList = [];
        List<Enemy> enemyList = [];
        Random rnd = new Random();
        Question q;
        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMainLoad;
        }

        private void FrmMainLoad(object? sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"H:\\repos\\Tudás Harca\\Resources\\questions.txt");
            while (!sr.EndOfStream) 
            {
                String[] data = sr.ReadLine().Split(";");
                Question q = new Question(data[0], data[1], data[2], data[3], data[4], int.Parse(data[5]) - 1);
                questionList.Add(q);
            }
            enemyList.Add(new Enemy("kis haver1", 3, 1, @"H:\\repos\\Tudás Harca\\Resources\\enemy1.png"));
            enemyList.Add(new Enemy("kis haver2", 5, 2, @"H:\\repos\\Tudás Harca\\Resources\\enemy2.png"));
            enemyList.Add(new Enemy("nagy haver", 10, 3, @"H:\\repos\\Tudás Harca\\Resources\\pixel boss.png"));
            initQuestion();
        }

        private void initQuestion()
        {
            q = questionList[rnd.Next(questionList.Count)];
            questionLbl.Text = q.prompt;
            answ1Btn.Text = q.answer1;
            answ2Btn.Text = q.answer2;
            answ3Btn.Text = q.answer3;
            answ4Btn.Text = q.answer4;
        }
    }
}
