using System;
using System.IO;

namespace CreateFile
{
    class Program
    {
        string path;
        string fileName;
        string unit;
        long fileSize;

        static void Main()
        {
            Program program = new Program();

            Console.Clear();

            Console.WriteLine("Please use backslashes in the file path.");
            Console.WriteLine();

            Console.Write("Input File Path: ");
            program.path = Console.ReadLine();
            if (program.path == "")
            {
                Restart("Please input a valid path.");
            }

            Console.Write("Input File Name: ");
            program.fileName = Console.ReadLine();
            if (program.fileName == "")
            {
                Restart("Please input a valid file name.");
            }

            Console.Write("Input Unit (B, KB, MB, GB, TB, PB, or EB): ");
            program.unit = Console.ReadLine();
            if (program.unit == "")
            {
                Restart("Please input a unit.");
            }

            Console.Write("Input File Size: ");
            long.TryParse(Console.ReadLine(), out program.fileSize);
            if (program.fileSize <= 0)
            {
                Restart("Please input a valid file size.");
            }

            string bs = @"\";
            if (program.path.EndsWith(bs) == false)
            {
                program.path = program.path + @"\";
            }

            program.CreateDummyFile();
        }

        private void CreateDummyFile()
        {
            try
            {
                using (var fileStream = new FileStream(path + fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    if (unit == "KB" || unit == "Kb" || unit == "kB" || unit == "kb")
                    {
                        fileSize = fileSize * 1024;
                    } else if (unit == "MB" || unit == "Mb" || unit == "mB" || unit == "mb")
                    {
                        fileSize = fileSize * 1048576;
                    }
                    else if (unit == "GB" || unit == "Gb" || unit == "gB" || unit == "gb")
                    {
                        fileSize = fileSize * 1073741824;
                    }
                    else if (unit == "TB" || unit == "Tb" || unit == "tB" || unit == "tb")
                    {
                        fileSize = fileSize * 1099511627776;
                    }
                    else if (unit == "PB" || unit == "Pb" || unit == "pB" || unit == "pb")
                    {
                        fileSize = fileSize * 1125899906842620;
                    }
                    else if (unit == "EB" || unit == "Eb" || unit == "eB" || unit == "eb")
                    {
                        fileSize = fileSize * 1152921504606850048;
                    }

                    fileStream.SetLength(fileSize);

                    Restart("File created at " + path + fileName + " with a size of " + fileSize + " Bytes.");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Restart("Access Denied");
            }
            catch (DirectoryNotFoundException)
            {
                Restart("Directory Not Found");
            }
            catch (ArgumentOutOfRangeException)
            {
                Restart("Please Input Valid Number");
            }
            catch (IOException)
            {
                Restart("Insufficient Disk Space");
            }
        }

        static void Restart(string restartMessage)
        {
            if (restartMessage != null)
            {
                Console.WriteLine();
                Console.WriteLine(restartMessage);
                Console.ReadLine();
            }

            Main();
        }
    }
}