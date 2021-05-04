using System;
using System.IO;

namespace CreateFile
{
    class Program
    {
        string path;
        string fileName;
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
                Restart("Please input a valid path");
            }

            Console.Write("Input File Name: ");
            program.fileName = Console.ReadLine();
            if (program.fileName == "")
            {
                Restart("Please input a valid file name");
            }

            Console.Write("Input File Size (Bytes): ");
            long.TryParse(Console.ReadLine(), out program.fileSize);
            if (program.fileSize == 0)
            {
                Restart("Please input a valid file size");
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
                    fileStream.SetLength(fileSize);

                    Restart("File created at " + path + fileName);
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