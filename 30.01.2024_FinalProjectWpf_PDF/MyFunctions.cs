using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace _30._01._2024_FinalProjectWpf_PDF
{
    public class MyFunctions
    {
        public static BitmapImage LoadImage(string imagePath)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage();

                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
                bitmap.EndInit();

                return bitmap;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error loading image {ex.Message}");
            }
        }



    }
}
