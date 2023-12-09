using SkiaSharp;
using System;
using System.Drawing;

namespace FSC
{
    public static partial class Terminal
    {
        /// <summary>
        /// Writes the text representation of the specified generic type value to the standard output stream
        /// </summary>
        /// <param name="value">The value to write</param>
        public static void Write<T>(T value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the current line terminator to the standard output stream
        /// </summary>
        public static void WriteLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Writes the text representation of the specified generic type value, followed by the current line terminator, to the standard output stream
        /// </summary>
        /// <param name="value">The value to write</param>
        public static void WriteLine<T>(T value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Writes a picture as ASCII art to the standard output stream
        /// </summary>
        /// <param name="bitmap">The picture to paint on console</param>
        public static void WritePicture(SKBitmap bitmap)
        {
            WritePicture(bitmap, bitmap.Width, bitmap.Height);
        }

        /// <summary>
        /// Writes a picture as ASCII art to the standard output stream
        /// </summary>
        /// <param name="bitmap">The picture to paint on console</param>
        /// <param name="size">The new size of the picture</param>
        public static void WritePicture(SKBitmap bitmap, Size size)
        {
            WritePicture(bitmap, size.Width, size.Height);
        }

        /// <summary>
        /// Writes a picture as ASCII art to the standard output stream
        /// </summary>
        /// <param name="bitmap">The picture to paint on console</param>
        /// <param name="width">The new width of the picture</param>
        /// <param name="height">The new height of the picture</param>
        public static void WritePicture(SKBitmap bitmap, int width, int height)
        {
            string asciiChars = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/|()1{}[]?-_+~<>i!lI;:,\"^`'. ";
            bitmap = ResizeImage(bitmap, width, height);

            string asciiArt = "";
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    SKColor pixelColor = bitmap.GetPixel(x, y);
                    int grayValue = (int)((pixelColor.Red * 0.3) + (pixelColor.Green * 0.59) + (pixelColor.Blue * 0.11));
                    int index = (grayValue * (asciiChars.Length - 1)) / 255;
                    asciiArt += asciiChars[index];
                }
                asciiArt += "\n";
            }

            WriteLine(asciiArt);
        }

        private static SKBitmap ResizeImage(SKBitmap image, int width, int height)
        {
            var resizedImage = new SKBitmap(width, height);
            using (var canvas = new SKCanvas(resizedImage))
            {
                canvas.DrawBitmap(image, new SKRect(0, 0, width, height));
            }
            return resizedImage;
        }
    }
}