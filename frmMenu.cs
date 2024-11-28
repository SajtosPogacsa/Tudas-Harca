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
        public static frmMenu instance;
        public frmMenu()
        { 
            InitializeComponent();
            instance = this;
            titleLbl.BackColor = Color.FromArgb(200, 60, 60, 60);
            startBtn.Click += StartBtnClick;
            exitBtn.Click += ExitBtnClick;
        }

        private void ExitBtnClick(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartBtnClick(object? sender, EventArgs e)
        {
            frmMain game = new();
            game.Show();
            instance.Hide();
        }
    }
}
