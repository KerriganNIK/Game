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
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            Menu mainMenu = new Menu(this);
            mainMenu.StartGame();

            game1 = new Game1(this);
        }
        public void button0_Click(object sender, EventArgs e) => game1.button0_Click(sender, e);

    }
}
