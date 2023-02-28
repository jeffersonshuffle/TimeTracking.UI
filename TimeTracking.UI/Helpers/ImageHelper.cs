using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.UI.Helpers
{
    internal static class ImageHelper
    {
        public static Image ByteArrayToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            try
            {
                using var ms = new MemoryStream(bytes);
                return Image.FromStream(ms);
            }
            catch { return null; }
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static Image LoadFromFile(string path)
        {
            try
            {
                var fullPath = Path.GetFullPath(path);
                return Image.FromFile(fullPath);
            }
            catch { return null; }
        }

        public static Image LoadDefault() 
        {
            var path = Directory.GetCurrentDirectory() + @"\pic_default_employee.png";
            return LoadFromFile(path); 
        }
    }
}
