using Spire.Doc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtfTools
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length < 2)
            {
                Console.WriteLine("args error");
            }

            Rtf2Image(args);
        }

        static void Rtf2Image(string[] args)
        {
            if (!Directory.Exists(args[0]))
            {
                Directory.CreateDirectory(args[0]);
            }

            Document document = new Document();
            document.LoadRtf(args[1],Encoding.UTF8);
            Image[] imgs = document.SaveToImages(Spire.Doc.Documents.ImageType.Bitmap);
            foreach (var item in imgs)
            {
                imgs[0].Save(Path.Combine(args[0], Guid.NewGuid().ToString("N") + ".png"), ImageFormat.Png);
            }
        }
    }
}
