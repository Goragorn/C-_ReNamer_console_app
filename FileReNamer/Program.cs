using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FileReNamer
{
    class Program
    {
        static void Main(string[] args)
        {

            //Tryb masowej zmiany nazw
            //Tryb w czasie rzeczysitym
            //Logowanie zmian nazw
            //Możliwość cofnięcia ostatnich zmian nazw


            //Tworzenie operacyjnych folderów
            string InputDirectory = "Input";
            string OutputDirectory = "Output";
            CreateDirectory(InputDirectory, OutputDirectory);

            //Funkcja do zmiany nazw plików na daną nazwe z numeracją od _1

            //MassRemane("test_#1","jpg",InputDirectory,OutputDirectory);

            AutoRename("test_#2","jpg",InputDirectory,OutputDirectory);


            Console.ReadKey();


        }

        
        static void CreateDirectory(string InputDir, string OutputDir) //Create input/output directory for operations
        {
            //Check if directory already exist or create one
            if (!Directory.Exists(InputDir))
            {
                DirectoryInfo id = Directory.CreateDirectory(InputDir);
                Console.WriteLine("Directory Input is created");
            }
            else Console.WriteLine("Directory Input exist");

            if (!Directory.Exists(OutputDir))
            {
                DirectoryInfo od = Directory.CreateDirectory(OutputDir);
                Console.WriteLine("Directory Input is created");
            }
            else Console.WriteLine("Directory Output exist");
        }
        
        
        static void MassRemane(string NewFileName, string extension, string InputDir, string OutputDir) //Mass rename files
        {
            
            DirectoryInfo d = new DirectoryInfo(InputDir); //get files from directory
            FileInfo[] Files = d.GetFiles("*."+extension); //can choose file type ex. "*.txt" lub "*.jpg"  

            List<string> OldNameList = new List<string>(); //create list of file names

            foreach (FileInfo file in Files)
            {
                OldNameList.Add(file.Name);
            }

            
            string[] tabela = OldNameList.ToArray(); // transformation list to array

            //Rename files
            string NewName;
            for (int i=0; i < tabela.Length;i++)
            {
                NewName = NewFileName + "_" + i+"."+extension;
                Console.WriteLine(NewName);
                System.IO.File.Move(@InputDir + "\\" + tabela[i], @OutputDir+ "\\" + NewName);
            }


            //[Test]Clean list and trim
            //OldNameList.Clear();
            //OldNameList.TrimExcess();

            //Place for CreateLog function
        }


        static void AutoRename(string NewFileName, string extension, string InputDir, string OutputDir) //Rename file puting on at a time to input folder
        {     

            Console.WriteLine("Put single file into Input to start renaming");
            Console.WriteLine("Press ESC button to stop renaming");

            List<string> OldNameList = new List<string>(); //create list of file names

            int i = 1; //loop variable, keep order of renaming files

            while (true)
            {
                
                DirectoryInfo d = new DirectoryInfo(InputDir); //get files from directory
                FileInfo[] Files = d.GetFiles("*." + extension); //can choose file type ex. "*.txt" lub "*.jpg"

                foreach (FileInfo file in Files)
                {
                    OldNameList.Add(file.Name);
                }

                string NewName;
                
                Console.WriteLine("Count number: " + OldNameList.Count);
                if (OldNameList.Count == i )
                {
                    Console.WriteLine("Count number now: " + OldNameList.Count);
                    i++;
                    NewName = NewFileName + "_" + OldNameList.Count + "." + extension;
                    Console.WriteLine(NewName);
                    System.IO.File.Move(@InputDir + "\\" + OldNameList.Last(), @OutputDir + "\\" + NewName);
                }

                System.Threading.Thread.Sleep(1000); //To slowdown a little

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape) break; // Jeżeli wykryje ESC przerwij pętle
            } 

            //Place for CreateLog function
        }

        static void CreateLog(string[] OldNames,string[] NewNames) //Create log from rename operations
        {
            //1.Create txt file log
            //2.[loop]Make string out of old name and new name
            //3.[loop]Put it into txt log
        }
    }   
}
