using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;

namespace Image_Processor
{

    public partial class Form2 : Form
    {
        string imagePath1;
        string imagePath2;
        Bitmap image1;
        Bitmap image2;
        Bitmap resultImage;
        bool isWebCamOn = false;

        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg*.png;*.gif;*.tif|All files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image
                    imagePath1 = openFileDialog.FileName;
                    image1 = new Bitmap(imagePath1);
                    pictureBox1.Image = image1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg*.png;*.gif;*.tif|All files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image
                    imagePath2 = openFileDialog.FileName;
                    image2 = new Bitmap(imagePath2);
                    pictureBox3.Image = image2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap image1 = new Bitmap(imagePath1);
                Bitmap image2 = new Bitmap(imagePath2);
                resultImage = new Bitmap(image2.Width, image2.Height);
                Color mygreen = Color.FromArgb(0, 255, 0);
                int greygreen = (mygreen.R + mygreen.G + mygreen.B) / 3;
                int threshold = 5;

                for (int x = 0; x < image2.Width; x++)
                {
                    for (int y = 0; y < image2.Height; y++)
                    {
                        Color pixel = image2.GetPixel(x, y);
                        Color backpixel = image1.GetPixel(x, y);
                        int grey = (pixel.R + pixel.G + pixel.B) / 3;
                        int subtractvalue = Math.Abs(grey - greygreen);
                        if (subtractvalue > threshold)
                            resultImage.SetPixel(x, y, pixel);
                        else
                            resultImage.SetPixel(x, y, backpixel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pictureBox2.Image = resultImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(isWebCamOn == false)
            {
                isWebCamOn = true;
            }
            else
            {
                isWebCamOn = false;
            }

            button4Status();
        }

        private void button4Status()
        {
            if(isWebCamOn == true)
            {
                button4.Text = "On";
            }
            else
            {
                button4.Text = "Off";
            }

        }
    }
}
