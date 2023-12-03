using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Image_Processor
{
    public partial class Form1 : Form
    {

        int[] histogram;
        string imagePath;
        Bitmap image;
        Bitmap processedImage;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox1.Enabled = false;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.png;*.gif;*.tif|All files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image
                    imagePath = openFileDialog.FileName;
                    string file = Path.GetFileName(imagePath);
                    textBox1.Text = file;
                    Bitmap image = new Bitmap(imagePath);
                    ComputeHistogram(image);
                    drawHistogram();
                    pictureBox1.Image = image;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.png;*.gif;*.tif|All files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image
                    imagePath = openFileDialog.FileName;
                    string file = Path.GetFileName(imagePath);
                    textBox1.Text = file;
                    Bitmap image = new Bitmap(imagePath);
                    ComputeHistogram(image);
                    drawHistogram();
                    pictureBox1.Image = image;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //COMPUT AND STORE THE HISTOGRAM DATA ON AN INT ARRAY
        private void ComputeHistogram(Bitmap image)
        {
            histogram = new int[256];

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    histogram[grayValue]++;
                }
            }
        }
        //INPUT THE HISTOGRAM ON THE PANEL
        private void drawHistogram()
        {
            if (histogramPanel != null)
            {
                using (Graphics g = histogramPanel.CreateGraphics())
                {
                    int barWidth = histogramPanel.Width / histogram.Length;

                    for (int i = 0; i < histogram.Length; i++)
                    {
                        int barHeight = histogram[i];
                        Rectangle barRect = new Rectangle(i * barWidth, histogramPanel.Height - barHeight, barWidth, barHeight);
                        g.FillRectangle(Brushes.Gray, barRect);
                    }
                }
            }
        }
        //BASIC COPY
        private void basicCopy()
        {
            try
            {
                Bitmap sourceImage = new Bitmap(imagePath);
                Bitmap copiedImage = new Bitmap(sourceImage.Width,
                                                sourceImage.Height,
                                                sourceImage.PixelFormat);

                for (int x = 0; x < sourceImage.Width; x++)
                {
                    for (int y = 0; y < sourceImage.Height; y++)
                    {
                        Color pixelColor = sourceImage.GetPixel(x, y);
                        copiedImage.SetPixel(x, y, pixelColor);
                    }
                }

                pictureBox2.Image = copiedImage;
                processedImage = copiedImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //GRAYSCALE EFFECT
        private void grayScale()
        {
            try
            {
                Bitmap sourceImage = new Bitmap(imagePath);
                Bitmap grayscaleImage = new Bitmap(sourceImage.Width,
                                                sourceImage.Height,
                                                sourceImage.PixelFormat);

                for (int x = 0; x < sourceImage.Width; x++)
                {
                    for (int y = 0; y < sourceImage.Height; y++)
                    {
                        Color pixelColor = sourceImage.GetPixel(x, y);
                        int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                        grayscaleImage.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
                    }
                }
                pictureBox2.Image = grayscaleImage;
                processedImage = grayscaleImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //COLOR INVERSION
        private void colorInversion()
        {
            try
            {
                Bitmap sourceImage = new Bitmap(imagePath);
                Bitmap colorInverted = new Bitmap(sourceImage.Width,
                                                sourceImage.Height,
                                                sourceImage.PixelFormat);

                for (int x = 0; x < sourceImage.Width; x++)
                {
                    for (int y = 0; y < sourceImage.Height; y++)
                    {
                        Color pixelColor = sourceImage.GetPixel(x, y);

                        int invertedR = 255 - pixelColor.R;
                        int invertedG = 255 - pixelColor.G;
                        int invertedB = 255 - pixelColor.B;

                        invertedR = Math.Max(0, Math.Min(255, invertedR));
                        invertedG = Math.Max(0, Math.Min(255, invertedG));
                        invertedB = Math.Max(0, Math.Min(255, invertedB));

                        colorInverted.SetPixel(x, y, Color.FromArgb(invertedR, invertedG, invertedB));
                    }
                }

                pictureBox2.Image = colorInverted;
                processedImage = colorInverted;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //SEPIA AN IMAGE
        private void sepiaImage()
        {
            try
            {
                Bitmap sourceImage = new Bitmap(imagePath);
                Bitmap sepiaImage = new Bitmap(sourceImage.Width,
                                                sourceImage.Height,
                                                sourceImage.PixelFormat);

                for (int x = 0; x < sourceImage.Width; x++)
                {
                    for (int y = 0; y < sourceImage.Height; y++)
                    {
                        Color pixelColor = sourceImage.GetPixel(x, y);

                        int sepiaR = (int)(0.393 * pixelColor.R + 0.769 * pixelColor.G + 0.189 * pixelColor.B);
                        int sepiaG = (int)(0.349 * pixelColor.R + 0.686 * pixelColor.G + 0.168 * pixelColor.B);
                        int sepiaB = (int)(0.272 * pixelColor.R + 0.534 * pixelColor.G + 0.131 * pixelColor.B);

                        sepiaR = Math.Max(0, Math.Min(255, sepiaR));
                        sepiaG = Math.Max(0, Math.Min(255, sepiaG));
                        sepiaB = Math.Max(0, Math.Min(255, sepiaB));

                        sepiaImage.SetPixel(x, y, Color.FromArgb(sepiaR, sepiaG, sepiaB));
                    }
                }

                pictureBox2.Image = sepiaImage;
                processedImage = sepiaImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ComputeHistogram(image);
            drawHistogram();
        }

        //PROCESS BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    basicCopy();
                    break;
                case 1:
                    grayScale();
                    break;
                case 2:
                    colorInversion();
                    break;
                case 3:
                    sepiaImage();
                    break;

            }
        }
        //SAVE BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp|GIF Image|*.gif|TIFF Image|*.tif";
            saveFileDialog.Title = "Save Image";
            saveFileDialog.FileName = "image";  // Default file name

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file name and extension
                string fileName = saveFileDialog.FileName;

                // Determine the format based on the selected filter
                ImageFormat imageFormat = ImageFormat.Jpeg;  // Default to JPEG
                string ext = System.IO.Path.GetExtension(fileName);
                if (ext.Equals(".png", StringComparison.OrdinalIgnoreCase))
                    imageFormat = ImageFormat.Png;
                else if (ext.Equals(".bmp", StringComparison.OrdinalIgnoreCase))
                    imageFormat = ImageFormat.Bmp;
                else if (ext.Equals(".gif", StringComparison.OrdinalIgnoreCase))
                    imageFormat = ImageFormat.Gif;
                else if (ext.Equals(".tif", StringComparison.OrdinalIgnoreCase) || ext.Equals(".tiff", StringComparison.OrdinalIgnoreCase))
                    imageFormat = ImageFormat.Tiff;

                try
                {
                    // Save the Bitmap to the selected file
                    processedImage.Save(fileName, imageFormat);

                    MessageBox.Show("Image saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void greenScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();

            form.Show();
        }
    }
}