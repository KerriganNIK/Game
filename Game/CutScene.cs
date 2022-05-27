using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class CutScene
    {
        public Form1 Form { get; private set; }
        public CutScene(Form1 form)
        {
            Form = form;
            Form.button16.Visible = true;
            Form.button16.Enabled = true;
        }

        public async void Cutscene1()
        {
            List<Bitmap> images = new List<Bitmap>();
            images.Add(Properties.Resources.Фон);
            images.Add(Properties.Resources.Сидит);
            images.Add(Properties.Resources.Сидит2);
            images.Add(Properties.Resources.Телефон1);
            images.Add(Properties.Resources.Телефон2);
            images.Add(Properties.Resources.Телефон3);
            images.Add(Properties.Resources.Телефон4);
            images.Add(Properties.Resources.Телефон5);
            images.Add(Properties.Resources.Телефон6);
            images.Add(Properties.Resources.Телефон7);
            images.Add(Properties.Resources.Фон);
            images.Add(Properties.Resources.Дом);


            foreach (var el in images)
            {
                Form.BackgroundImage = el;
                await Task.Delay(2000);
                if (Form.Need == true) //Никита2
                {
                    Form.Need = false;
                    break;
                }
            }

            Form.button16.Visible = false;
            Form.button16.Enabled = false;

            Form.GameOne();
        }
    }
}