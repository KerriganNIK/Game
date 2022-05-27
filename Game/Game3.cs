using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
    }
}
