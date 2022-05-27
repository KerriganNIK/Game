using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class Game3
    {
        Boolean[] opened = new Boolean[12];
        Boolean[] opened1Time = new Boolean[12];
        int openCount = 0;
        int completed = 0;
        int index = 0;
        public Form1 Form { get; set; }

        List<Tuple<int, Image>> list = new List<Tuple<int, Image>>();

        PictureBox[] pictureBox = new PictureBox[12];
        Image[] completedPictureBox = new Image[12];
        int[] completedIndex = new int[12];
        public Game3(Form1 form)
        {
            Form = form;
            Form.button16.Visible = false;
            Form.button16.Enabled = false;
        }

        public void StartGame()
        {
            Random random = new Random();
            Form.BackgroundImage = Properties.Resources.Микросхема;
            Form.tableLayoutPanel1.Visible = false;

            list.Add(Tuple.Create<int, Image>(1, Properties.Resources.Берюзовый));
            list.Add(Tuple.Create<int, Image>(2, Properties.Resources.Жёлтый));
            list.Add(Tuple.Create<int, Image>(3, Properties.Resources.Зелёный));
            list.Add(Tuple.Create<int, Image>(4, Properties.Resources.Красный));
            list.Add(Tuple.Create<int, Image>(5, Properties.Resources.Синий));
            list.Add(Tuple.Create<int, Image>(6, Properties.Resources.Фиолетовый));
            list.Add(Tuple.Create<int, Image>(1, Properties.Resources.Берюзовый));
            list.Add(Tuple.Create<int, Image>(2, Properties.Resources.Жёлтый));
            list.Add(Tuple.Create<int, Image>(3, Properties.Resources.Зелёный));
            list.Add(Tuple.Create<int, Image>(4, Properties.Resources.Красный));
            list.Add(Tuple.Create<int, Image>(5, Properties.Resources.Синий));
            list.Add(Tuple.Create<int, Image>(6, Properties.Resources.Фиолетовый));


            int x = 700, y = 550;
            for (int i = 0; i < pictureBox.Length; i++)
            {
                pictureBox[i] = new System.Windows.Forms.PictureBox();
                pictureBox[i].BackgroundImage = Properties.Resources.Чёрный;
                pictureBox[i].BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox[i].Left = x;
                pictureBox[i].Top = y;
                pictureBox[i].Size = new System.Drawing.Size(100, 100);
                pictureBox[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox[i].BackColor = Color.Transparent;


                Form.Controls.Add(pictureBox[i]);

                if (i == 5)
                {
                    x = 700;
                    y = 700;
                }
                else if (i == 6)
                {
                    x = 850;
                    y = 700;
                }
                else
                {
                    x += 150;
                }

                pictureBox[i].MouseHover += new EventHandler(chosen);
                pictureBox[i].MouseLeave += new EventHandler(notChosen);
                pictureBox[i].Click += new EventHandler(clicked);
                opened[i] = false;
            }
        }

        private void chosen(object sender, EventArgs e)
        {
            int index = Array.IndexOf(pictureBox, sender);
            if (!opened[index])                                                             
            {
                (sender as PictureBox).BackgroundImage = Properties.Resources.Белый;
                GC.Collect();
            }
        }
        private void notChosen(object sender, EventArgs e)
        {
            int index = Array.IndexOf(pictureBox, sender);
            if (!opened[index])
            {
                (sender as PictureBox).BackgroundImage = Properties.Resources.Чёрный;
                GC.Collect();
            }
        }
        private void clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int index = Array.IndexOf(pictureBox, sender);

            if (opened[index] || openCount == 2)
                return;

            if (!opened1Time[index])
            {
                int randomNumber = random.Next(list.Count);
                (sender as PictureBox).BackgroundImage = list[randomNumber].Item2;

                completedPictureBox[index] = list[randomNumber].Item2;


                completedIndex[index] = list[randomNumber].Item1;

                list.RemoveAt(randomNumber);
                opened[index] = true;
                openCount++;
                opened1Time[index] = true;
            }
            else
            {
                (sender as PictureBox).BackgroundImage = completedPictureBox[index];
                opened[index] = true;
                openCount++;
            }

            if (openCount == 1)
            {
                this.index = index;

            }
            else if (openCount == 2)
            {
                if (completedIndex[index] != completedIndex[this.index])
                {
                    Thread ClosingFirst = new Thread(new ParameterizedThreadStart(CardClosed));
                    ClosingFirst.Start(index);
                    Thread ClosingSecond = new Thread(new ParameterizedThreadStart(CardClosed));
                    ClosingSecond.Start(this.index);
                }
                else
                {
                    openCount = 0;
                    completed += 2;
                }

            }

            if (completed == 12)
            {
                for (int i = 0; i < pictureBox.Length; i++)
                {
                    pictureBox[i].Visible = false;
                    pictureBox[i].Enabled = false;
                }
                CutScene cutScene = new CutScene(Form);
                cutScene.CutsceneFinal();
            }

            GC.Collect();
        }

        private void CardClosed(object x)
        {
            Thread.Sleep(1500);
            int index = (int)x;
            pictureBox[index].BackgroundImage = Properties.Resources.Чёрный;
            opened[index] = false;
            openCount--;

            GC.Collect();
        }
    }
}
