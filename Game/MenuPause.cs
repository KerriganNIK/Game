using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class MenuPause : Form
    {
        public MenuPause()
        {
            InitializeComponent();
            DoubleBuffered = true;
            BackgroundImage = Properties.Resources.Фон_меню;

            var button1 = new Button();
            var button2 = new Button();
            SizeChanged += (sender, args) =>
            {
                button1.Text = "Продолжить";
                button1.Font = new Font("Microsoft Sans Serif", 16.25F);
                button1.Size = new Size(340, 70);
                button1.Left = (ClientSize.Width - button1.Width) / 2;
                button1.Top = (ClientSize.Height - button1.Height) / 2 - 100;
                button1.Click += new System.EventHandler(button1_Click);
                this.Controls.Add(button1);

                button2.Text = "Выйти из игры";
                button2.Font = new Font("Microsoft Sans Serif", 16.25F);
                button2.Size = new Size(340, 70);
                button2.Left = (ClientSize.Width - button2.Width) / 2;
                button2.Top = (ClientSize.Height - button2.Height) / 2;
                button2.Click += new System.EventHandler(button2_Click);
                Controls.Add(button2);
            };
        }

        private void MenuPause_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (char)Keys.Escape)
            {
                Close();
            }
        }
         
        public void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MenuPause_Load(object sender, EventArgs e)
        {

        }
    }
}
