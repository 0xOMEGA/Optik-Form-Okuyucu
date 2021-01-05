using Efundies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yuzem_Optik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] files;
        FolderBrowserDialog fbd;

        private void button1_Click(object sender, EventArgs e)
        {
            using (fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    files = Directory.GetFiles(fbd.SelectedPath, "*.jpg");
                    folderStatus.Text = fbd.SelectedPath + "\n\n" + files.Length.ToString() + " resim bulundu.";
                    starterButton.Enabled = true;
                }
            }
        }

        private void starterButton_Click(object sender, EventArgs e)
        {
            starterButton.Visible = false;
            progressBar1.Visible = true;
            renamer();
        }

        private void renamer()
        {
            try
            {
                int imgIndex = 0;
                progressBar1.Maximum = files.Length;
                foreach (string file in files)
                {
                    imgIndex++;
                    folderStatus.Text = imgIndex + ". resim işleniyor.";
                    folderStatus.Refresh();
                    progressBar1.Value += 1;
                    progressBar1.Refresh();
                    Image tmp = Image.FromFile(file);
                    Image numberSection = cropImage(tmp, new Rectangle(165, 1255, 450, 500));
                    tmp.Dispose();
                    string number = "";
                    for (int x = 0; x < 9; x++)
                    {
                        List<int> numbers = new List<int>();
                        for (int y = 0; y < 10; y++)
                        {
                            Bitmap bmp = new Bitmap(cropImage(numberSection, new Rectangle(x * 50, y * 50, 50, 50)));
                            blueFilter(bmp);
                            numbers.Add(getDominantColor(makeGrayscale(bmp)));
                        }
                        //MessageBox.Show(String.Join(",", numbers.ToArray()));
                        number = number + numbers.IndexOf(numbers.Min()).ToString();
                    }
                    string newImageName = "";
                    string[] parts = file.Split('\\');
                    for (int i = 0; i < parts.Length - 1; i++)
                    {
                        newImageName = newImageName + parts[i] + "\\";
                    }
                    newImageName = newImageName + number + ".jpg";
                    while (File.Exists(newImageName))
                        newImageName = newImageName.Replace(".jpg", "") + "(1)" + ".jpg";
                    numberSection.Dispose();
                    File.Move(file, newImageName);
                }
                MessageBox.Show("Tamamlandı!");
            }
            catch(Exception e)
            {
                MessageBox.Show("Hata gerçekleşti! Detaylar: \n\n" + e.Message);
            }
            
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap returnBmp = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            bmpImage.Dispose();
            return returnBmp;
        }

        public static Bitmap makeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap))
            {

                //create the grayscale ColorMatrix
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                   {
                         new float[] {.3f, .3f, .3f, 0, 0},
                         new float[] {.59f, .59f, .59f, 0, 0},
                         new float[] {.11f, .11f, .11f, 0, 0},
                         new float[] {0, 0, 0, 1, 0},
                         new float[] {0, 0, 0, 0, 1}
                   });

                //create some image attributes
                using (ImageAttributes attributes = new ImageAttributes())
                {

                    //set the color matrix attribute
                    attributes.SetColorMatrix(colorMatrix);
                    attributes.SetThreshold(.7f);

                    //draw the original image on the new image
                    //using the grayscale color matrix
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                    g.Dispose();
                    attributes.Dispose();
                }
            }
            return newBitmap;
        }

        public int getDominantColor(Bitmap bmp)
        {
            BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            int stride = srcData.Stride;

            IntPtr Scan0 = srcData.Scan0;

            int[] totals = new int[] { 0, 0, 0 };

            int width = bmp.Width;
            int height = bmp.Height;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        for (int color = 0; color < 3; color++)
                        {
                            int idx = (y * stride) + x * 4 + color;
                            totals[color] += p[idx];
                        }
                    }
                }
            }

            int avgB = totals[0] / (width * height);
            int avgG = totals[1] / (width * height);
            int avgR = totals[2] / (width * height);

            bmp.UnlockBits(srcData);
            bmp.Dispose();

            return avgR + avgG + avgB;
        }

        private static void blueFilter(Bitmap bmp)
        {
            var lockedBitmap = new LockBitmap(bmp);
            lockedBitmap.LockBits();

            for (int y = 0; y < lockedBitmap.Height; y++)
            {
                for (int x = 0; x < lockedBitmap.Width; x++)
                {
                    if ((lockedBitmap.GetPixel(x, y).B > lockedBitmap.GetPixel(x,y).G + 5) &&(lockedBitmap.GetPixel(x, y).B > 150))
                    {
                        lockedBitmap.SetPixel(x, y, Color.White);
                    }
                }
            }
            lockedBitmap.UnlockBits();
        }
    }
}
