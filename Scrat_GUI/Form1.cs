using System.Windows.Forms;
using System;
using Scrat;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.WindowsAPICodePack.Dialogs;
namespace Oscour_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string path = ""; // chemin de l'image � traiter
        private void button1_Click(object sender, EventArgs e) // ouvrir une image
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    path = dlg.FileName;
                    pb_bmp.Image = new Bitmap(path);
                    this.Controls.Add(pb_bmp);
                }
            }
            histo();
            histo();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // filtre gris
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.Greyscale();
            res.Save("output.bmp");
            path = "output.bmp";
            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
            histo();
            histo();
        }

        private void button3_Click(object sender, EventArgs e) // rotation selon un angle donné
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.Rotate(Convert.ToInt32(Math.Round(nd_rotate.Value, 0)));
            res.Save("output.bmp");
            path = "output.bmp";
            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
            histo();
            histo();
        }

        private void button4_Click(object sender, EventArgs e) // noir et blanc
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.BlackAndWhite();
            res.Save("output.bmp");
            path = "output.bmp";
            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
            histo();
            histo();
        }

        private void button5_Click(object sender, EventArgs e) // filtre négatif
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.Negative();
            res.Save("output.bmp");
            path = "output.bmp";
            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
            histo();
            histo();
        }

        private void button6_Click(object sender, EventArgs e) // inversion des couleurs
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.Invert();
            res.Save("output.bmp");
            path = "output.bmp";
            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
            histo();
            histo();
        }

        private void button7_Click(object sender, EventArgs e) // cacher une image dans une autre
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
                    this.Controls.Add(pb_bmp);
                }
            }
            MyImage tmp2 = new MyImage(path2);
            MyImage res = tmp.HideImageInside(tmp2);
            res.Save("output.bmp");
            path = "output.bmp";
            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
            histo();
            histo();
        }

        private void histo() //generer l'histogramme de l'image
        {
            pb_histo.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.Histogram();
            res.Save("histo.bmp");
            pb_histo.Image = new Bitmap("histo.bmp");
            this.Controls.Add(pb_histo);
        }

        private void button9_Click(object sender, EventArgs e) //Permet de zoomer dans l'image
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.Scale(Convert.ToInt32(Math.Round(nd_scale.Value, 0)));
            res.Save("output.bmp");
            path = "output.bmp";
            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
            histo();
            histo();
        }

        private void button1_Click_1(object sender, EventArgs e) //Permet de sauvegarder l'image dans un dossier spécifique
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path2 = dialog.FileName + "/sortie.bmp";
                MyImage tmp = new MyImage(path);
                tmp.Save(path2);
            }

        }

        private void bttn_montrer_Click(object sender, EventArgs e) //Permet de montrer l'image cachée dans une autre image
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.GetHiddenImage();
            res.Save("output.bmp");
            path = "output.bmp";
            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
            histo();
            histo();
        }

        private void bttn_flou_Click(object sender, EventArgs e) //Filtre flou BoxBlur
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.ApplyKernel(Convolution.Kernel.BoxBlur);
            res.Save("output.bmp");
            path = "output.bmp";

            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
            histo();
            histo();
        }

        private void button1_Click_2(object sender, EventArgs e) //Filtre flou GaussianBlur5x5
        {

            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.ApplyKernel(Convolution.Kernel.GaussianBlur5x5);
            res.Save("output.bmp");
            path = "output.bmp";

            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
            histo();
            histo();
        }

        private void button8_Click(object sender, EventArgs e) //Filtre flou GaussianBlur3x3
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.ApplyKernel(Convolution.Kernel.GaussianBlur3x3);
            res.Save("output.bmp");
            path = "output.bmp";

            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
            histo();
            histo();
        }

        private void button10_Click(object sender, EventArgs e)  //Filtre de detection de contours
        {
            pb_bmp.Image = null;
            MyImage tmp = new MyImage(path);
            MyImage res = tmp.ApplyKernel(Convolution.Kernel.EdgeDetection);
            res.Save("output.bmp");
            path = "output.bmp";

            pb_bmp.Image = new Bitmap(path);
            this.Controls.Add(pb_bmp);
            histo();
            histo();
        }
    }
}
