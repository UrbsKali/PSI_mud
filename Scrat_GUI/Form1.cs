using System.Windows.Forms;
using System;
using Scrat;
using Microsoft.VisualBasic.ApplicationServices;
namespace Oscour_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string path = ""; // Path to the image 
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    path = dlg.FileName;
                    pb_bmp.Image = new Bitmap(path);

                    // Add the new control to its parent's controls collection
                    this.Controls.Add(pb_bmp);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.Greyscale();
            res.Save("C:/Users/Mattheo/Desktop/Valeurs/output.bmp");
            path = "C:/Users/Mattheo/Desktop/Valeurs/output.bmp";
            // Add the new control to its parent's controls collection

            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.Rotate(Convert.ToInt32(Math.Round(nd_rotate.Value, 0)));
            res.Save("C:/Users/Mattheo/Desktop/Valeurs/output.bmp");
            path = "C:/Users/Mattheo/Desktop/Valeurs/output.bmp";
            // Add the new control to its parent's controls collection

            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.BlackAndWhite();
            res.Save("C:/Users/Mattheo/Desktop/Valeurs/output.bmp");
            path = "C:/Users/Mattheo/Desktop/Valeurs/output.bmp";
            // Add the new control to its parent's controls collection

            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.Negative();
            res.Save("C:/Users/Mattheo/Desktop/Valeurs/output.bmp");
            path = "C:/Users/Mattheo/Desktop/Valeurs/output.bmp";
            // Add the new control to its parent's controls collection

            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.Invert();
            res.Save("C:/Users/Mattheo/Desktop/Valeurs/output.bmp");
            path = "C:/Users/Mattheo/Desktop/Valeurs/output.bmp";
            // Add the new control to its parent's controls collection

            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            string path2 = "";
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    path2 = dlg.FileName;
                    pb_bmp.Image = new Bitmap(path);

                    // Add the new control to its parent's controls collection
                    this.Controls.Add(pb_bmp);
                }
            }
            MyImage tmp2 = new MyImage(path2);
            MyImage res = tmp.HideImageInside(tmp2);
            res.Save("C:/Users/Mattheo/Desktop/Valeurs/output.bmp");
            path = "C:/Users/Mattheo/Desktop/Valeurs/output.bmp";
            // Add the new control to its parent's controls collection

            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
