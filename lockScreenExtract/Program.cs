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
                // if (Environment.OSVersion.Version.Major < 10) {
                //     Console.WriteLine("You need at least Windows 10");
                //     Console.ReadKey();
                //     return;
                // }
                Console.WriteLine("Windows version -> " + Environment.OSVersion.Version.ToString());
                Console.WriteLine("Logged user is -> " + Environment.UserName);

                string imgPath = string.Format(@"C:\Users\{0}\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets", Environment.UserName);
                string currentPath = Directory.GetCurrentDirectory();
                string targetPath = Path.Join(currentPath, "LockScreens");
                string[] files = Directory.GetFiles(imgPath);

                Console.WriteLine("Extracting files in folder 'LockScreens' under path {0}...", currentPath);
                if (!Directory.Exists(targetPath))
                {
                    Console.WriteLine("Creating folder...");
                    Directory.CreateDirectory(targetPath);
                }
                foreach (string filePath in files)
                {
                    long fileLength = new FileInfo(filePath).Length;
                    if (fileLength/1024 < 200) continue;
                    string fileName = Path.GetFileName(filePath);
                    string targetFileName = Path.Combine(targetPath, fileName + ".jpg");
                    File.Copy(filePath, targetFileName, true);
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
