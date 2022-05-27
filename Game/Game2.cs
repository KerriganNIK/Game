using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class Game2
    {
        public Button buttonСoup { get; set; } 
        public Button buttonFinal { get; set; }
        public TextBox textboxFinal { get; set; }
        public Form1 Form { get; private set; }

        private bool flag;
        const string result = "ЖЕМЧУЖИНАВПОРТУ";

        public Game2(Form1 form) 
        {
            Form = form;

            buttonСoup = new Button();
            buttonFinal = new Button();
            textboxFinal = new TextBox();

            Form.SizeChanged += (sender, args) =>
            {
                buttonСoup.Text = "Посмотреть список";
                buttonСoup.Font = new Font("Microsoft Sans Serif", 16.25F);
                buttonСoup.Size = new Size(340, 70);
                buttonСoup.ForeColor = Color.White;
                buttonСoup.Left = 1500;
                buttonСoup.Top = 850;
                buttonСoup.Click += new System.EventHandler(buttonСoup_Click);
                buttonСoup.BackColor = Color.Black;
                buttonСoup.FlatStyle = FlatStyle.Flat;
                buttonСoup.FlatAppearance.BorderColor = Color.Black;
                buttonСoup.FlatAppearance.BorderSize = 6;
                buttonСoup.FlatAppearance.MouseOverBackColor = Color.Silver;
                Form.Controls.Add(buttonСoup);

                buttonFinal.Text = "Проверить";
                buttonFinal.Font = new Font("Microsoft Sans Serif", 16.25F);
                buttonFinal.Size = new Size(150, 40);
                buttonFinal.ForeColor = Color.White;
                buttonFinal.Left = 650;
                buttonFinal.Top = 850;
                buttonFinal.Click += new System.EventHandler(buttonFinal_Click);
                buttonFinal.BackColor = Color.Black;
                buttonFinal.FlatStyle = FlatStyle.Flat;
                buttonFinal.FlatAppearance.BorderColor = Color.Black;
                buttonFinal.FlatAppearance.BorderSize = 6;
                buttonFinal.FlatAppearance.MouseOverBackColor = Color.Silver;
                Form.Controls.Add(buttonFinal);

                textboxFinal.Left = 300;
                textboxFinal.Top = 850;
                textboxFinal.Name = "textBox1";
                textboxFinal.Multiline = true;
                textboxFinal.Font = new Font("Microsoft Sans Serif", 20.25F);
                textboxFinal.Size = new System.Drawing.Size(300, 42);
                textboxFinal.TabIndex = 3;
                Form.Controls.Add(textboxFinal);
            };

            buttonСoup.Visible = false;
            buttonСoup.Enabled = false;
            buttonFinal.Visible = false;
            buttonFinal.Enabled = false;
            textboxFinal.Visible = false;
            textboxFinal.Enabled = false;
        }

        public void StartGame()
        {
            Form.BackgroundImage = Properties.Resources.Папка;

            buttonСoup.Visible = true;
            buttonСoup.Enabled = true;
            buttonFinal.Visible = true;
            buttonFinal.Enabled = true;
            textboxFinal.Visible = true;
            textboxFinal.Enabled = true;

        }

        public void buttonСoup_Click(object sender, EventArgs args)
        {
            if (flag == false)
            {
                Form.BackgroundImage = Properties.Resources.Список;
                buttonСoup.Text = "Посмотреть шифр";
                flag = true;
            }
            else
            {
                Form.BackgroundImage = Properties.Resources.Папка;
                buttonСoup.Text = "Посмотреть листок";
                flag = false;
            }
        }

        public void buttonFinal_Click(object sender, EventArgs args)
        {
            string word = textboxFinal.Text;

            if (result == word.Replace(" ", "").ToUpper())
            {
                buttonСoup.Visible = false;
                buttonСoup.Enabled = false;
                buttonFinal.Visible = false;
                buttonFinal.Enabled = false;
                textboxFinal.Visible = false;
                textboxFinal.Enabled = false;

                CutScene cutScene = new CutScene(Form);
                cutScene.Cutscene3();
            }
            else
            {
                MessageBox.Show("Шифр не верный");
            }
        }
    }
}
