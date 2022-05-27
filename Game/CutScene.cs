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
                if (Form.Need == true)
                {
                    Form.Need = false;
                    break;
                }
            }

            Form.button16.Visible = false;
            Form.button16.Enabled = false;

            Form.GameOne();
        }

        public async void Cutscene2()
        {
            List<Bitmap> images = new List<Bitmap>();
            images.Add(Properties.Resources.Фон);
            images.Add(Properties.Resources.Сейфнет);
            images.Add(Properties.Resources.Сейфда);
            images.Add(Properties.Resources.Сейфоткрыт);
            images.Add(Properties.Resources.Похоже_на_шифр);
            images.Add(Properties.Resources.Попробую_расшифровать);
            images.Add(Properties.Resources.Уровень2);

            foreach (var el in images)
            {
                if (Form.Need == true)
                {
                    Form.Need = false;
                    break;
                }
                Form.BackgroundImage = el;
                await Task.Delay(2000);
                if (Form.Need == true)
                {
                    Form.Need = false;
                    break;
                }
            }

            Form.button16.Visible = false;
            Form.button16.Enabled = false;

            Form.GameTwo();
        }

        public async void Cutscene3()
        {
            List<Bitmap> images = new List<Bitmap>();
            images.Add(Properties.Resources.Фон);
            images.Add(Properties.Resources.Где);
            images.Add(Properties.Resources.Едет);
            images.Add(Properties.Resources.Frame1);
            images.Add(Properties.Resources.Frame2);
            images.Add(Properties.Resources.Frame3);
            images.Add(Properties.Resources.Frame4);
            images.Add(Properties.Resources.Frame5);
            images.Add(Properties.Resources.Уровень_3);

            foreach (var el in images)
            {
                Form.BackgroundImage = el;
                await Task.Delay(2500);
                if (Form.Need == true)
                {
                    Form.Need = false;
                    break;
                }
            }

            Form.button16.Visible = false;
            Form.button16.Enabled = false;

            Form.GameThree();
        }

        public async void CutsceneFinal()
        {
            List<Bitmap> images = new List<Bitmap>();
            images.Add(Properties.Resources.Фон);
            images.Add(Properties.Resources.Жемчужина);
            images.Add(Properties.Resources._2месяца);
            images.Add(Properties.Resources.Лежит);
            images.Add(Properties.Resources.Титры1);
            images.Add(Properties.Resources.Титры2);
            images.Add(Properties.Resources.Титры3);
            images.Add(Properties.Resources.Титры4);
            images.Add(Properties.Resources.Титры5);

            foreach (var el in images)
            {
                Form.BackgroundImage = el;
                await Task.Delay(2500);
                if (Form.Need == true)
                {
                    Form.Need = false;
                    break;
                }
            }

            Form.button16.Visible = false;
            Form.button16.Enabled = false;

            Application.Restart();
        }
    }
}