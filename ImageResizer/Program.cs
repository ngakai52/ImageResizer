using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            var imageProcess = new ImageProcess();
            var imageProcessAsync1 = new ImageProcessAsync1();
            var imageProcessAsync2 = new ImageProcessAsync2();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();

            Console.WriteLine($"同步版花費時間: {sw.ElapsedMilliseconds} ms");

            sw.Reset();
            sw.Start();
            imageProcessAsync1.ResizeImagesAsync(sourcePath, destinationPath, 2.0).Wait();
            sw.Stop();

            Console.WriteLine($"非同步版花費時間: {sw.ElapsedMilliseconds} ms");


            sw.Reset();
            sw.Start();
            imageProcessAsync2.ResizeImagesAsync(sourcePath, destinationPath, 2.0).Wait();
            sw.Stop();

            Console.WriteLine($"非同步版2花費時間: {sw.ElapsedMilliseconds} ms");


            Console.ReadKey();
        }
    }
}
