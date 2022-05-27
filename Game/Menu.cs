using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class Menu
    {
        public Button buttonStart { get; set; }
        public Button buttonExit { get; set; }
        public Form1 Form { get; private set; }

        public Menu (Form1 form)
        {
            Form = form;
            Form.tableLayoutPanel1.Visible = false;
            Form.tableLayoutPanel1.Enabled = false;

            buttonStart = new Button();
            buttonExit = new Button();

            Form.SizeChanged += (sender, args) =>
            {
                buttonStart.Text = "Начать игру";
                buttonStart.Font = new Font("Microsoft Sans Serif", 16.25F);
                buttonStart.ForeColor = Color.White;
                buttonStart.Size = new Size(400, 80);
                buttonStart.Left = 200;
                buttonStart.Top = 350;
                buttonStart.Click += new System.EventHandler(buttonStart_Click);
                buttonStart.BackColor = Color.Black;
                buttonStart.FlatStyle = FlatStyle.Flat;
                buttonStart.FlatAppearance.BorderColor = Color.Black;
                buttonStart.FlatAppearance.BorderSize = 6;
                buttonStart.FlatAppearance.MouseOverBackColor = Color.Silver;
                Form.Controls.Add(buttonStart);

                buttonExit.Text = "Выход";
                buttonExit.Font = new Font("Microsoft Sans Serif", 16.25F);
                buttonExit.ForeColor = Color.White;
                buttonExit.Size = new Size(400, 80);
                buttonExit.Left = 200;
                buttonExit.Top = 475;
                buttonExit.Click += new System.EventHandler(buttonExit_Click);
                buttonExit.BackColor = Color.Black;
                buttonExit.FlatStyle = FlatStyle.Flat;
                buttonExit.FlatAppearance.BorderColor = Color.Black;
                buttonExit.FlatAppearance.BorderSize = 6;
                buttonExit.FlatAppearance.MouseOverBackColor = Color.Silver;
                Form.Controls.Add(buttonExit);
            };

            buttonStart.Visible = false;
            buttonStart.Enabled = false;
            buttonExit.Visible = false;
            buttonExit.Enabled = false;
        }

        public void StartGame()
        {
            Form.BackgroundImage = Properties.Resources.Start;
            Form.BackgroundImageLayout = ImageLayout.Stretch;

            buttonStart.Visible = true;
            buttonStart.Enabled = true;
            buttonExit.Visible = true;
            buttonExit.Enabled = true;
        }

        public void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            buttonExit.Enabled = false;
            buttonStart.Visible = false;
            buttonExit.Visible = false;

            CutScene cut = new CutScene(Form);
            cut.Cutscene1();
        }
        public void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
