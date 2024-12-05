using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tudás_Harca
{
    public partial class frmMenu : Form
    {
        static frmMain game = new();
        public frmMenu()
        { 
            InitializeComponent();
            titleLbl.BackColor = Color.FromArgb(200, 60, 60, 60);
            startBtn.Click += StartBtnClick;
            exitBtn.Click += ExitBtnClick;
            ldbBtn.Click += LdbBtnClick;

        }

        private void GameFormClosing(object? sender, FormClosingEventArgs e)
        {
            this.Show();
            game = new();
        }

        private void LdbBtnClick(object? sender, EventArgs e)
        {
            ldbLbx.Items.Clear();
            FileStream fs;
            try
            {
                fs = new("data.bin", FileMode.Open);
            }
            catch (Exception)
            {
                fs = new("data.bin", FileMode.CreateNew);
            }


            if (fs.Length == 0)
            {
                fs.Close();
                return;
            };
            ldbLbx.Visible = true;
            using(BinaryReader br = new BinaryReader(fs))
            {
                while (br.PeekChar() != -1)
                {
                    ldbLbx.Items.Add($"{br.ReadString()} {br.ReadInt32() / 1000}s");
                }
 
            }
        }

        private void ExitBtnClick(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Biztosan ki akarsz lépni?", "Kilépés megerősítése", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void StartBtnClick(object? sender, EventArgs e)
        {
            game.Show();
            game.FormClosing += GameFormClosing;
            this.Hide();
        }

        
    }
}
