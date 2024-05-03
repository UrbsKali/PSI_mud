namespace Oscour_GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bttn_show = new Button();
            pb_bmp = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            nd_rotate = new NumericUpDown();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button9 = new Button();
            nd_scale = new NumericUpDown();
            pb_histo = new PictureBox();
            bttn_save = new Button();
            bttn_montrer = new Button();
            bttn_flou = new Button();
            button1 = new Button();
            button8 = new Button();
            button10 = new Button();
            bttn_fractale = new Button();
            ((System.ComponentModel.ISupportInitialize)pb_bmp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nd_rotate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nd_scale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_histo).BeginInit();
            SuspendLayout();
            // 
            // bttn_show
            // 
            bttn_show.Location = new Point(831, 159);
            bttn_show.Name = "bttn_show";
            bttn_show.Size = new Size(117, 29);
            bttn_show.TabIndex = 0;
            bttn_show.Text = "Choisir image";
            bttn_show.UseVisualStyleBackColor = true;
            bttn_show.Click += button1_Click;
            // 
            // pb_bmp
            // 
            pb_bmp.Location = new Point(14, 55);
            pb_bmp.Name = "pb_bmp";
            pb_bmp.Size = new Size(766, 501);
            pb_bmp.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_bmp.TabIndex = 1;
            pb_bmp.TabStop = false;
            pb_bmp.Click += pictureBox1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(897, 267);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "Gris";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(897, 229);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(94, 31);
            button3.TabIndex = 3;
            button3.Text = "Rotation";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // nd_rotate
            // 
            nd_rotate.Location = new Point(897, 195);
            nd_rotate.Margin = new Padding(3, 4, 3, 4);
            nd_rotate.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            nd_rotate.Name = "nd_rotate";
            nd_rotate.Size = new Size(94, 27);
            nd_rotate.TabIndex = 5;
            // 
            // button4
            // 
            button4.Location = new Point(797, 265);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(94, 31);
            button4.TabIndex = 6;
            button4.Text = "N/B";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(797, 304);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(94, 31);
            button5.TabIndex = 7;
            button5.Text = "Negatif";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(897, 307);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(94, 31);
            button6.TabIndex = 8;
            button6.Text = "Inverser";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(797, 461);
            button7.Margin = new Padding(3, 4, 3, 4);
            button7.Name = "button7";
            button7.Size = new Size(94, 31);
            button7.TabIndex = 9;
            button7.Text = "Cacher";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button9
            // 
            button9.Location = new Point(797, 229);
            button9.Margin = new Padding(3, 4, 3, 4);
            button9.Name = "button9";
            button9.Size = new Size(94, 31);
            button9.TabIndex = 11;
            button9.Text = "Zoom";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // nd_scale
            // 
            nd_scale.Location = new Point(797, 195);
            nd_scale.Margin = new Padding(3, 4, 3, 4);
            nd_scale.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            nd_scale.Name = "nd_scale";
            nd_scale.Size = new Size(94, 27);
            nd_scale.TabIndex = 12;
            // 
            // pb_histo
            // 
            pb_histo.Location = new Point(800, 31);
            pb_histo.Margin = new Padding(3, 4, 3, 4);
            pb_histo.Name = "pb_histo";
            pb_histo.Size = new Size(194, 121);
            pb_histo.TabIndex = 13;
            pb_histo.TabStop = false;
            // 
            // bttn_save
            // 
            bttn_save.Location = new Point(831, 556);
            bttn_save.Margin = new Padding(3, 4, 3, 4);
            bttn_save.Name = "bttn_save";
            bttn_save.Size = new Size(117, 31);
            bttn_save.TabIndex = 14;
            bttn_save.Text = "Sauvegarder";
            bttn_save.UseVisualStyleBackColor = true;
            bttn_save.Click += button1_Click_1;
            // 
            // bttn_montrer
            // 
            bttn_montrer.Location = new Point(897, 461);
            bttn_montrer.Margin = new Padding(3, 4, 3, 4);
            bttn_montrer.Name = "bttn_montrer";
            bttn_montrer.Size = new Size(94, 31);
            bttn_montrer.TabIndex = 15;
            bttn_montrer.Text = "Montrer";
            bttn_montrer.UseVisualStyleBackColor = true;
            bttn_montrer.Click += bttn_montrer_Click;
            // 
            // bttn_flou
            // 
            bttn_flou.Location = new Point(797, 353);
            bttn_flou.Margin = new Padding(3, 4, 3, 4);
            bttn_flou.Name = "bttn_flou";
            bttn_flou.Size = new Size(94, 31);
            bttn_flou.TabIndex = 16;
            bttn_flou.Text = "BoxBlur";
            bttn_flou.UseVisualStyleBackColor = true;
            bttn_flou.Click += bttn_flou_Click;
            // 
            // button1
            // 
            button1.Location = new Point(897, 353);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(94, 31);
            button1.TabIndex = 17;
            button1.Text = "Gauss5x5";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_2;
            // 
            // button8
            // 
            button8.Location = new Point(797, 392);
            button8.Margin = new Padding(3, 4, 3, 4);
            button8.Name = "button8";
            button8.Size = new Size(94, 31);
            button8.TabIndex = 18;
            button8.Text = "Gauss3x3";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button10
            // 
            button10.Location = new Point(897, 392);
            button10.Margin = new Padding(3, 4, 3, 4);
            button10.Name = "button10";
            button10.Size = new Size(94, 31);
            button10.TabIndex = 19;
            button10.Text = "Detection";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // bttn_fractale
            // 
            bttn_fractale.Location = new Point(831, 511);
            bttn_fractale.Name = "bttn_fractale";
            bttn_fractale.Size = new Size(117, 29);
            bttn_fractale.TabIndex = 20;
            bttn_fractale.Text = "Fractale";
            bttn_fractale.UseVisualStyleBackColor = true;
            bttn_fractale.Click += bttn_fractale_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 629);
            Controls.Add(bttn_fractale);
            Controls.Add(button10);
            Controls.Add(button8);
            Controls.Add(button1);
            Controls.Add(bttn_flou);
            Controls.Add(bttn_montrer);
            Controls.Add(bttn_save);
            Controls.Add(pb_histo);
            Controls.Add(nd_scale);
            Controls.Add(button9);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(nd_rotate);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(pb_bmp);
            Controls.Add(bttn_show);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pb_bmp).EndInit();
            ((System.ComponentModel.ISupportInitialize)nd_rotate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nd_scale).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_histo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button bttn_show;
        private PictureBox pb_bmp;
        private Button button2;
        private Button button3;
        private NumericUpDown nd_rotate;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button9;
        private NumericUpDown nd_scale;
        private PictureBox pb_histo;
        private Button bttn_save;
        private Button bttn_montrer;
        private Button bttn_flou;
        private Button button1;
        private Button button8;
        private Button button10;
        private Button bttn_fractale;
    }
}
