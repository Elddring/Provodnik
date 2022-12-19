using System.Diagnostics;
using System.IO;

namespace проводник
{
    internal class Program
    {
        public static List<DriveInfo> Drives = DriveInfo.GetDrives().ToList();
        public static ConsoleKeyInfo key;
        public static int positionUP_Dawn = 1;
        static string open_File;
        public static int interconection;
        public static string path = null;
        public static bool HarDDrive = true;
        static void Main(string[] args)
        {
            info();
            /*string das = Console.ReadLine();
            string[] AllFiles = Directory.GetFiles(das, "*.*", SearchOption.AllDirectories);
            foreach (string filename in AllFiles)
            {
                Console.WriteLine(filename);
            }*/

            /*string[] allfolders = Directory.GetDirectories(das);
            foreach (string folder in allfolders)
            {
                Console.WriteLine(folder);
            }*/
            /*List<string> ls = GetRecursFiles(das);
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

            

        }
        public static void info()
        {
            int Size = 1024 * 1024 * 1024;

            foreach (DriveInfo disks in Drives)
            {
                interconection++;
                Console.SetCursorPosition(0, interconection);
                Console.Write("  " + disks.Name);
                if (disks.IsReady)
                {
                    Console.Write("\tВсего " + disks.TotalSize / Size + "Gb");
                    Console.Write("\tСвободно " + disks.TotalFreeSpace / Size + "Gb" + "\n");
                }
            }
            Console.Clear();
            interconection = 0;
            foreach (DriveInfo disks in Drives)
            {
                interconection++;
                Console.SetCursorPosition(0, interconection);
                Console.Write("  " + disks.Name);
                if (disks.IsReady)
                {
                    Console.Write("\tВсего " + disks.TotalSize / Size + "Gb");
                    Console.Write("\tСвободно " + disks.TotalFreeSpace / Size + "Gb" + "\n");
                }
            }
            IO();
            Producing(path);
        }
        public static void IO()
        {
            for (int a = 0; a < 45; a++)
            {
                Console.SetCursorPosition(a, 0);
                Console.Write("----------------------------------------------");

                if (a < interconection)
                {
                    Console.SetCursorPosition(92, 0);
                    Console.Write("F1 - создать файл ");
                    Console.SetCursorPosition(92, 1);
                    Console.Write("F2 - удалить файл ");
                    Console.SetCursorPosition(92, 2);
                    Console.Write("F3 - создать директорию ");
                    Console.SetCursorPosition(92, 3);
                    Console.Write("F4 - удалить директорию");
                }
            }
            Console.SetCursorPosition(91, 4);
            Console.WriteLine("--------------------------");
        }
        public static void Producing(string path)
        {
            do
            {
                Console.SetCursorPosition(0, positionUP_Dawn);
                Console.WriteLine("->");
                PerekluchArrows.key = Console.ReadKey().Key;
                PerekluchArrows.CursorPosition(PerekluchArrows.key);
                if (Program.positionUP_Dawn == 0)
                {
                    Program.positionUP_Dawn = Program.positionUP_Dawn + 1;
                }
                if (PerekluchArrows.key == ConsoleKey.Enter)
                {
                    do
                    {
                        path = Convert.ToString(Drives[positionUP_Dawn - 1]);
                        string ParhDisk = ($"{path}\\");

                        var directory = new DirectoryInfo(ParhDisk);
                        if (directory.Exists)
                        {
                            FileSystemInfo[] InfoFiles = directory.GetFileSystemInfos();
                            for (int i = 0; i < InfoFiles.Length; i++)
                            {
                                Console.SetCursorPosition(0, i + 1);
                                Console.Write($"  {InfoFiles[i].Name}");
                                Console.SetCursorPosition(45, i + 1);
                                Console.Write($"  {InfoFiles[i].CreationTime}");
                                Console.SetCursorPosition(75, i + 1);
                                Console.Write($"  {InfoFiles[i].Extension}");
                            }
                            int count = InfoFiles.Length;
                            PerekluchArrows.max = count;
                            bool check = true;
                            Console.WriteLine();
                            do
                            {
                                Console.SetCursorPosition(0, positionUP_Dawn);
                                Console.WriteLine("->");
                                PerekluchArrows.key = Console.ReadKey().Key;
                                PerekluchArrows.CursorPosition(PerekluchArrows.key);
                                if (Program.positionUP_Dawn == 0)
                                {
                                    Program.positionUP_Dawn = Program.positionUP_Dawn + 1;
                                }
                                if (PerekluchArrows.key == ConsoleKey.Enter)
                                {
                                    path = Convert.ToString(InfoFiles[positionUP_Dawn - 1]);
                                    open_File = path;
                                    open_File.TrimEnd('\\');
                                    path = ($"{path}\\");
                                    positionUP_Dawn = 1;
                                    Clean_string();
                                    DIrectory(PerekluchArrows.max, PerekluchArrows.min, path);
                                }
                                if (PerekluchArrows.key == ConsoleKey.F1 || PerekluchArrows.key == ConsoleKey.F2 || PerekluchArrows.key == ConsoleKey.F3 || PerekluchArrows.key == ConsoleKey.F4)
                                {
                                    Work_with_directory(PerekluchArrows.key, InfoFiles);
                                }
                                if (PerekluchArrows.key == ConsoleKey.Escape)
                                {
                                    Console.Clear();
                                    info();
                                    check = false;
                                }
                            } while (check);
                        }
                        else
                        {
                            OpenFile(open_File, path);
                        }
                    } while (true);
                }
            } while (true);
        }
        public static void Clean_string()
        {
            Console.Clear();
            IO();
        }
        public static ConsoleKeyInfo GetKey()
        {
            return key;
        }
        public static void DIrectory( int max, int min, string path)
        {
            positionUP_Dawn = 1;
            var directory = new DirectoryInfo(path);
            var file = new FileInfo(path);
            if (directory.Exists)
            {
                FileSystemInfo[] InfoFiles = directory.GetFileSystemInfos();
                for (int i = 0; i < InfoFiles.Length; i++)
                {
                    Console.SetCursorPosition(0, i +1);
                    Console.WriteLine($"  {InfoFiles[i].Name}");
                    Console.SetCursorPosition(45, i + 1);
                    Console.WriteLine($"  {InfoFiles[i].CreationTime}");
                    Console.SetCursorPosition(75, i + 1);
                    Console.WriteLine($"  {InfoFiles[i].Extension}");
                }
                int count = InfoFiles.Length;
                max = count;
                min = count - count + 1;
                bool check = true;
                Console.WriteLine();
                do
                {
                    Console.SetCursorPosition(0, positionUP_Dawn);
                    Console.WriteLine("->");
                    PerekluchArrows.key = Console.ReadKey().Key;
                    PerekluchArrows.CursorPosition(PerekluchArrows.key);
                    if (Program.positionUP_Dawn == 0)
                    {
                        Program.positionUP_Dawn = Program.positionUP_Dawn + 1;
                    }
                    if (PerekluchArrows.key == ConsoleKey.Enter)
                    {
                        path = Convert.ToString(InfoFiles[positionUP_Dawn-1]);
                        open_File = path;
                        open_File.TrimEnd('\\');
                        path = ($"{path}\\");
                        positionUP_Dawn = 1;
                        DIrectory( max, min, path);
                    }
                    if (PerekluchArrows.key == ConsoleKey.F1 || PerekluchArrows.key == ConsoleKey.F2 || PerekluchArrows.key == ConsoleKey.F3 || PerekluchArrows.key == ConsoleKey.F4)
                    {
                        Work_with_directory(PerekluchArrows.key, InfoFiles);
                    }
                    if (PerekluchArrows.key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        info();
                        check = false;
                    }
                } while (check);
            }
            else if (file.Exists)
            {
                OpenFile(open_File, path);
            }
        }
        static private void OpenFile(string openFile, string path)
        {
            Process.Start(new ProcessStartInfo($"{openFile}") { UseShellExecute = true });
            Console.Clear();
            positionUP_Dawn = 1;
            PerekluchArrows.min = 1;
            PerekluchArrows.max = 2;
            IO();
            info();
        }













        private static void Work_with_directory(ConsoleKey key, FileSystemInfo[] dirs) 
        {
            positionUP_Dawn = 1;
            PerekluchArrows.min = 1;
            PerekluchArrows.max = 2;
            if (key == ConsoleKey.F1)
            {
                CreateFile(path);
            }
            if (key == ConsoleKey.F2)
            {
                DeleteFile(open_File, dirs);

            }
            if (key == ConsoleKey.F3)
            {
                CreateDirectory(path);
            }
            if (key == ConsoleKey.F4)
            {
                DeleteDirectory(path, dirs);
            }
            Clean_string();
            IO();
            info();
        }
        static private void CreateFile(string path)
        {
            Console.Clear();
            Console.WriteLine("Введите название файла");
            string name = Console.ReadLine();
            path = path + name;
            path = path.Trim('.');
            Console.WriteLine(path);
            File.Create(path);
            
        }
        static private void DeleteFile(string openFile, FileSystemInfo[] dirs)
        {
            openFile = Convert.ToString(dirs[positionUP_Dawn]);
            File.Delete(openFile);
            
        }
        static private void CreateDirectory(string path)
        {

            Console.Clear();
            Console.WriteLine("Введите название директории");
            string name = Console.ReadLine();
            path = path + name;
            Console.WriteLine(path);
            Directory.CreateDirectory(path);
            
        }
        static private void DeleteDirectory(string path, FileSystemInfo[] dirs)
        {
            path = Convert.ToString(dirs[positionUP_Dawn]);
            Directory.Delete(path, true);
            
        }
    }
}