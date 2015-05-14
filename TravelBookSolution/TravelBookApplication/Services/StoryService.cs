using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace TravelBookApplication.Services
{
    public class StoryService
    {
        private static StoryService service = null;

        public static StoryService Service
        {
            get
            {
                if (service == null)
                {
                    service = new StoryService();
                }

                return service;
            }
        }

        public FileInfo CreateStory(List<string> texts, List<FileInfo> images, string storyfileName, string storyDirectory)
        {
            int imageWidth = int.Parse(ConfigurationManager.AppSettings.Get("StoryImageWidth"));

            List<FileInfo> deletionList = new List<FileInfo>();
            List<FileInfo> textImages = new List<FileInfo>();
            Font storyFont = new Font("Calibri", 22f);

            foreach(var text in texts)
            {
                if(!String.IsNullOrEmpty(text))
                {
                    string path = Path.Combine(storyDirectory, text.Substring(0, Math.Min(text.Length, 4)) + ".jpg");

                    if (File.Exists(path))
                    {
                        path = GetNewPathForFile(path);
                    }

                    FileInfo textImgFileInfo = DrawImageFromText(text, imageWidth, storyFont, Color.White, Color.Black, path);
                    textImages.Add(textImgFileInfo);
                    deletionList.Add(textImgFileInfo);
                }
                else
                {
                    textImages.Add(null);
                }
            }

            for ( int i = 0; i < images.Count; i++ )
            {
                using (Image img = Image.FromFile(images[i].FullName))
                {
                    deletionList.Add(images[i]);

                    if (img.Width > imageWidth)
                    {
                        images[i] = ResizeImageWidth(images[i], imageWidth);
                        deletionList.Add(images[i]);
                    }
                    else if (img.Width < imageWidth)
                    {
                        images[i] = SetBackgroundToImage(images[i], imageWidth, img.Height);
                        deletionList.Add(images[i]);
                    }
                }
            }

            List<FileInfo> combinedList = new List<FileInfo>();

            for ( int i = 0; i < images.Count; i++ )
            {
                combinedList.Add(images[i]);

                if(textImages[i] != null)
                {
                    combinedList.Add(textImages[i]);
                }
            }

            FileInfo story =  CombineImages(combinedList, Path.Combine(storyDirectory, storyfileName.Replace(" ", "")));
            DeleteFiles(deletionList);
            return story;
        }

        private FileInfo CombineImages(List<FileInfo> files, string finalImagePath)
        {;
            if(File.Exists(finalImagePath))
            {
                finalImagePath = GetNewPathForFile(finalImagePath);
            }

            List<int> imageWidths = new List<int>();
            int nIndex = 0;
            int height = 0;
            foreach (FileInfo file in files)
            {
                Image img = Image.FromFile(file.FullName);
                imageWidths.Add(img.Width);
                height += img.Height;
                img.Dispose();
            }
            imageWidths.Sort();
            int width = imageWidths[imageWidths.Count - 1];
            Bitmap img3 = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(img3);
            g.Clear(SystemColors.AppWorkspace);
            foreach (FileInfo file in files)
            {
                Image img = Image.FromFile(file.FullName);
                if (nIndex == 0)
                {
                    g.DrawImage(img, new Point(0, 0));
                    nIndex++;
                    height = img.Height;
                }
                else
                {
                    g.DrawImage(img, new Point(0, height));
                    height += img.Height;
                }
                img.Dispose();
            }
            g.Dispose();
            img3.Save(finalImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            img3.Dispose();

            return new FileInfo(finalImagePath);
        }

        private FileInfo DrawImageFromText(string text, int imageWidth, Font font, Color textColor, Color backColor, string imagepath)
        {
            SizeF recMeasurements;
            using (Graphics graph = Graphics.FromImage(new Bitmap(1, 1)))
            {
                //SizeF layout = new SizeF((float)imageWidth, 700);
                //recMeasurements = graph.MeasureString(text, font, layout);
                recMeasurements = graph.MeasureString(text, font, imageWidth);
            }

            using (Bitmap textDrawing = new Bitmap(imageWidth, (int)(Math.Ceiling(recMeasurements.Height))))
            {
                using (Graphics graph = Graphics.FromImage(textDrawing))
                {
                    graph.Clear(backColor);
                    Brush textBrush = new SolidBrush(textColor);
                    graph.DrawString(text, font, textBrush, new Rectangle(0, 0, imageWidth, textDrawing.Height));
                    graph.Save();
                }

                if(File.Exists(imagepath))
                {
                    imagepath = GetNewPathForFile(imagepath);
                }

                textDrawing.Save(imagepath, ImageFormat.Jpeg);
            }
            return new FileInfo(imagepath);
        }
        
        private FileInfo ResizeImageWidth(FileInfo fileInfo, int newWidth)
        {
            Image image = Image.FromFile(fileInfo.FullName);

            if (image.Width == newWidth)
            {
                image.Dispose();
                return fileInfo;
            }

            // getting the ratio of head and width
            double ratio = (double)image.Width / newWidth;
            int newHeight = (int)Math.Floor(image.Height / ratio);
            using (image)
            {
                Bitmap resizedImage = new Bitmap(newWidth, newHeight, PixelFormat.Format64bppArgb);
                using (Graphics graphic = Graphics.FromImage(resizedImage))
                {
                    graphic.Clear(Color.Transparent);
                    graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graphic.DrawImage(image, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
                }

                string newPath = GetNewPathForFile(fileInfo.FullName);
                resizedImage.Save(newPath, ImageFormat.Jpeg);
                resizedImage.Dispose();
                return new FileInfo(newPath);
            }
        }

        private FileInfo SetBackgroundToImage(FileInfo imageInfo, int bgWidth, int bgHeight)
        {
            string newPath = GetNewPathForFile(imageInfo.FullName);
            using (Bitmap backgroundRectangle = new Bitmap(bgWidth, bgHeight))
            {
                using (Graphics graphics = Graphics.FromImage(backgroundRectangle))
                {
                    using (Image image = Image.FromFile(imageInfo.FullName))
                    {
                        // Find the point where to draw the image
                        int imageWidth = image.Width, imageHeight = image.Height;
                        int xCord = (bgWidth - image.Width) / 2;
                        int yCord = (bgHeight - image.Height) / 2;
                        graphics.Clear(Color.Black); // Setting background as black
                        graphics.DrawImage(image, new Point(xCord, yCord));
                    }
                }

                backgroundRectangle.Save(newPath, ImageFormat.Jpeg);
            }

            return new FileInfo(newPath);
        }

        private void DeleteFiles(List<FileInfo> Info)
        {
            foreach(var file in Info)
            {
                File.Delete(file.FullName);
            }
        }

        public string GetNewPathForFile(string path)
        {
            int index = 0;
            string directory = System.IO.Path.GetDirectoryName(path) + "\\",
                filename = System.IO.Path.GetFileNameWithoutExtension(path),
                extension = System.IO.Path.GetExtension(path);

            StringBuilder builder = new StringBuilder();

            do
            {
                index++;
                builder.Clear();
                builder.Append(directory);
                builder.Append(filename);
                builder.Append("(" + index + ")");
                builder.Append(extension);
                path = builder.ToString();
            } while (System.IO.File.Exists(String.Format(path)));

            return path;
        }
    }
}