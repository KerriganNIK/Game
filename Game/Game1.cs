using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Game1
    {
        private int Size;
        private int[,] array;
        private int SpaceX, SpaceY;
        public int[] NumbArray = new int[16];
        public int[] RightNumber = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
        public Form1 Form { get; set; }

        static Random rand = new Random();

        public Game1(Form1 frm)
        {
            Size = 4;
            array = new int[Size, Size];

            Form = frm;

            Form.button16.Visible = false;
            Form.button16.Enabled = false;
        }

        public void Start()
        {
            int z = 0;

            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    array[x, y] = CoordsPosition(x, y) + 1;
                    RightNumber[z] = array[x, y];
                    z++;
                }
            }

            SpaceX = Size - 1;
            SpaceY = Size - 1;
            array[SpaceX, SpaceY] = 0;
            RightNumber[15] = 0;
        }

        public int GetNumber(int pos)
        {
            int x, y;
            PositionCoords(pos, out x, out y);
            if (x < 0 || x >= Size)
                return 0;

            if (y < 0 || y >= Size)
                return 0;

            return array[x, y];
        }

        public void InsertTail(int index)
        {
            int x, y;
            PositionCoords(index, out x, out y);
            array[x, y] = 0;
        }

        public void MixTails()
        {
            for (int i = 0; i < 1000000; i++)
                SwapTails(rand.Next(0, 16));
        }

        public void SwapTails(int index)
        {
            int x, y, xNew, yNew, tempCurrent;

            PositionCoords(index, out x, out y);

            tempCurrent = array[x, y];
            xNew = SpaceX;
            yNew = SpaceY;


            if (SpaceX == x & (SpaceY + 1 == y || SpaceY - 1 == y))
            {
                SpaceX = x;
                SpaceY = y;
                array[SpaceX, SpaceY] = 0;
                array[xNew, yNew] = tempCurrent;
            }
            else if (SpaceY == y & (SpaceX + 1 == x || SpaceX - 1 == x))
            {
                SpaceX = x;
                SpaceY = y;
                array[SpaceX, SpaceY] = 0;
                array[xNew, yNew] = tempCurrent;
            }

        }

        public bool CheckEndGame()
        {
            int z = 0;

            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    NumbArray[z] = array[x, y];
                    z++;
                }
            }

            return RightNumber.SequenceEqual(NumbArray);
        }



        private int CoordsPosition(int x, int y)
        {
            return y * Size + x;
        }

        private void PositionCoords(int pos, out int x, out int y)
        {
            x = pos % Size;
            y = pos / Size;
        }


        public void RefreshTiles()
        {
            for (int p = 0; p < 16; p++)
            {
                int nmb = GetNumber(p);

                myButton(p).Text = nmb.ToString();

                myButton(p).Visible = (nmb > 0);
            }
        }

        public Button myButton(int pos)
        {
            switch (pos)
            {
                case 0: return Form.button0;
                case 1: return Form.button1;
                case 2: return Form.button2;
                case 3: return Form.button3;
                case 4: return Form.button4;
                case 5: return Form.button5;
                case 6: return Form.button6;
                case 7: return Form.button7;
                case 8: return Form.button8;
                case 9: return Form.button9;
                case 10: return Form.button10;
                case 11: return Form.button11;
                case 12: return Form.button12;
                case 13: return Form.button13;
                case 14: return Form.button14;
                case 15: return Form.button15;
                default: return null;
            }
        }

        public void StartGame()
        {
            Form.tableLayoutPanel1.Visible = true;
            Form.tableLayoutPanel1.Enabled = true;
            Form.BackgroundImage = Properties.Resources.Сейф;
            Start();
            MixTails();
            RefreshTiles();
        }

        public void button0_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt16(((Button)sender).Tag);

            SwapTails(temp);
            myButton(temp).Focus();
            RefreshTiles();
            myButton(temp).Focus();

            if (CheckEndGame())
            {
                Form.tableLayoutPanel1.Visible = false;
                Form.tableLayoutPanel1.Enabled = false;

                CutScene cutScene = new CutScene(Form);
                cutScene.Cutscene2();
            }
        }
    }
}
