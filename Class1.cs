using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace проводник
{
    public class DisksModel
    {
        public string Name { get; set; }
        public int TotalFreeSpace { get; set; }
        public int TotalSize { get; set; }
        public List<DriveInfo> Disks { get; set; }
        public DisksModel()
        {
            Disks = DriveInfo.GetDrives().Where(r => r.IsReady).Where(r => r.DriveType == DriveType.Fixed).ToList();
        }
    }
    public class PerekluchArrows
    {
        public static int max = 0;
        public static int min = 0;
        public static ConsoleKey key;
        public static void CursorPosition(ConsoleKey key)
        {
            Console.SetCursorPosition(0, Program.positionUP_Dawn);
            Console.Write("  ");
            if (key == ConsoleKey.UpArrow)
            {
                Program.positionUP_Dawn = Program.positionUP_Dawn -1;
            }
            if (key == ConsoleKey.DownArrow)
            {
                Program.positionUP_Dawn = Program.positionUP_Dawn + 1;
            }
        }
        
    }


}
/*List<string> ls = new List<string>();
try
{
    string[] folders = Directory.GetDirectories(start_path);
    foreach (string folder in folders)
    {
        ls.Add("Папка: " + folder);
        ls.AddRange(GetRecursFiles(folder));
    }
    string[] files = Directory.GetFiles(start_path);
    foreach (string filename in files)
    {
        ls.Add("Файл: " + filename);
    }
}
catch (System.Exception e)
{
    MessageBox.Show(e.Message);
}*/


/*string das = "C:\\Games\\Noita";
string[] allfolders = Directory.GetDirectories(das);
foreach (string folder in allfolders)
{
    Console.WriteLine(folder);
}*/



















/*string das = Console.ReadLine();
            List<string> ls = GetRecursFiles(das);
            foreach (string fname in ls)
            {
                Console.WriteLine(fname);
            }

            List<string> GetRecursFiles(string start_path)
            {
                List<string> ls = new List<string>();
                try
                {
                    string[] folders = Directory.GetDirectories(start_path);
                    foreach (string folder in folders)
                    {
                        ls.Add("  Папка: " + folder);
                        ls.AddRange(GetRecursFiles(folder));
                    }
                    string[] files = Directory.GetFiles(start_path);
                    foreach (string filename in files)
                    {
                        ls.Add("  Файл: " + filename);
                    }
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return ls;
            }*/