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
            button1 = new Button();
            pb_bmp = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            nd_rotate = new NumericUpDown();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)pb_bmp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nd_rotate).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(589, 42);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 0;
            button1.Text = "show";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pb_bmp
            // 
            pb_bmp.Location = new Point(23, 17);
            pb_bmp.Margin = new Padding(3, 2, 3, 2);
            pb_bmp.Name = "pb_bmp";
            pb_bmp.Size = new Size(531, 311);
            pb_bmp.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_bmp.TabIndex = 1;
            pb_bmp.TabStop = false;
            pb_bmp.Click += pictureBox1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(589, 68);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(82, 22);
            button2.TabIndex = 2;
            button2.Text = "Greyscale";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(589, 303);
            button3.Name = "button3";
            button3.Size = new Size(82, 23);
            button3.TabIndex = 3;
            button3.Text = "Rotate";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // nd_rotate
            // 
            nd_rotate.Location = new Point(589, 274);
            nd_rotate.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            nd_rotate.Name = "nd_rotate";
            nd_rotate.Size = new Size(82, 23);
            nd_rotate.TabIndex = 5;
            // 
            // button4
            // 
            button4.Location = new Point(589, 95);
            button4.Name = "button4";
            button4.Size = new Size(82, 23);
            button4.TabIndex = 6;
            button4.Text = "B/W";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(589, 124);
            button5.Name = "button5";
            button5.Size = new Size(82, 23);
            button5.TabIndex = 7;
            button5.Text = "Negative";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(589, 153);
            button6.Name = "button6";
            button6.Size = new Size(82, 23);
            button6.TabIndex = 8;
            button6.Text = "Invert";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(589, 182);
            button7.Name = "button7";
            button7.Size = new Size(82, 23);
            button7.TabIndex = 9;
            button7.Text = "Hide image";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(589, 211);
            button8.Name = "button8";
            button8.Size = new Size(82, 23);
            button8.TabIndex = 10;
            button8.Text = "Histogram";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(nd_rotate);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(pb_bmp);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pb_bmp).EndInit();
            ((System.ComponentModel.ISupportInitialize)nd_rotate).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private PictureBox pb_bmp;
        private Button button2;
        private Button button3;
        private NumericUpDown nd_rotate;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
    }
}
