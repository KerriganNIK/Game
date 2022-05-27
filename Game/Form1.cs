using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        Game1 game1;
        Game2 game2;
        Game3 game3;
        public bool Need { get; set; }
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            Menu mainMenu = new Menu(this);
            mainMenu.StartGame();

            game1 = new Game1(this);
        }
        public void button0_Click(object sender, EventArgs e) => game1.button0_Click(sender, e);
        public void button16_Click(object sender, EventArgs e) => Need = true; 

        public void GameOne() => game1.StartGame();

        public void GameTwo() => game2.StartGame();
        public void GameThree() => game3.StartGame();

        public void Form1_KeyDown_1(object sender, KeyEventArgs e) //Макс1
        {
            if (e.KeyValue == (char)Keys.Escape)
            {
                MenuPause menuPause = new MenuPause();
                menuPause.ShowDialog();
            }

            if (e.KeyValue == (char)Keys.F2)
            {
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel1.Enabled = false;

                CutScene cutScene = new CutScene(this);
                cutScene.Cutscene2();
            }
        }
    }
}
