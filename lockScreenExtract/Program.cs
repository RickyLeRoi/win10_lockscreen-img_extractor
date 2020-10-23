using System;
using System.IO;

namespace lockScreenExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tLockScreen Extractor\n\t\tby RickyLeRoi");

            try
            {
                if (Environment.OSVersion.Version.Major < 10) {
                    Console.WriteLine("You need at least Windows 10");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Windows version -> " + Environment.OSVersion.Version.ToString());
                Console.WriteLine("Logged user is -> " + Environment.UserName);

                string imgPath = string.Format(@"C:\Users\{0}\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets", Environment.UserName);
                string currentPath = Directory.GetCurrentDirectory();
                string[] files = Directory.GetFiles(imgPath);

                foreach (string filePath in files)
                {
                    Console.WriteLine(filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
