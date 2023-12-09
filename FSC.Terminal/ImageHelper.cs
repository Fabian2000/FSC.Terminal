using SkiaSharp;

namespace FSC
{
    /// <summary>
    /// Provides image helping methods
    /// </summary>
    public class ImageHelper
    {
        /// <summary>
        /// Loads an image from the specified path
        /// </summary>
        /// <param name="imagePath">The path where the image is located</param>
        /// <returns></returns>
        public static SKBitmap LoadImage(string imagePath)
        {
            return SKBitmap.Decode(imagePath);
        }
    }
}
