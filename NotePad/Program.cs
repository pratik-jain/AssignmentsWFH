using System;
using System.IO;
using System.Text;
namespace NotePad
{
    class Program
    {
        StreamWriter sw;
        StreamReader sr;
        static void Main(string[] args)
        {
            Program p = new Program();
            if (args.Length!=0)
            {
                p.concate(args[3],args[1],args[2]);
            }

           else
            {
                p.Menu();
            }
            
            //p.Menu();
        }

        public void Menu()
        {
            Console.WriteLine("1. for Create new File,2. for rename  a file,3. for show content file,4. for copy file,5. for concate two files");
            int m = Int32.Parse(Console.ReadLine());

            switch (m)
            {
                case 1:
                    create();
                    Menu();
                    break;

                case 2:
                    Rename();
                    Menu();
                    break;

                case 3:
                    display();
                    Menu();
                    break;

                case 4:
                    Copy();
                    Menu();
                    break;

                case 5:
                    Console.WriteLine("Enter the first source filename ");
                    string sourceFile = Console.ReadLine();

                    Console.WriteLine("Enter the second source filename ");
                    string destFile = Console.ReadLine();

                    Console.WriteLine("Enter target filename");
                    string targetFile = Console.ReadLine();
                    concate(targetFile,sourceFile,destFile);
                    Menu();
                    break;

                case 6:
                    break;
            }
        }

        public void create()
        {
            Console.WriteLine("Enter the name of file");
            string fileName = Console.ReadLine();

            Console.WriteLine("Enter the Connten of file");
            string content = Console.ReadLine();

            sw = new StreamWriter("F://"+fileName+".txt");
            sw.WriteLine(content);
            sw.Flush();
            sw.Close();
        }

        public void display()
        {
            Console.WriteLine("Enter the filename want to display");
            string fileName = Console.ReadLine();

            sr = new StreamReader("F://"+fileName+".txt");
            sr.BaseStream.Seek(0,SeekOrigin.Begin);

            string str = sr.ReadLine();

            while(str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }            
            sr.Close();
        }

        public void Rename()
        {
            Console.WriteLine("Enter the file to rename");
            string fileName = Console.ReadLine();
            Console.WriteLine("Enter new file name");
            string rename = Console.ReadLine();
            FileInfo fi = new FileInfo("F://"+fileName+".txt");

            if (fi.Exists)
            {
                fi.MoveTo("f://"+rename+".txt");
                Console.WriteLine("success renameing");
            }
        }

        public void Copy()
        {
            Console.WriteLine("Enter the source filename to copy");
            string sourceFile = Console.ReadLine();
            Console.WriteLine("Enter the destination filename ");
            string destFile = Console.ReadLine();

            File.Delete("F://"+destFile+".txt");

            File.Copy("F://"+sourceFile+".txt","F://"+destFile+".txt");
            Console.WriteLine("done copied..");

            
        }

        public void concate(string targetFile,string sourceFile,string destFile)
        {
            string final = "";
           /* Console.WriteLine("Enter the first source filename ");
            string sourceFile = Console.ReadLine();

            Console.WriteLine("Enter the second source filename ");
            string destFile = Console.ReadLine();

            Console.WriteLine("Enter target filename");
            string targetFile = Console.ReadLine();
*/
            sr = new StreamReader("F://"+sourceFile+".txt");
            sr.BaseStream.Seek(0,SeekOrigin.Begin);
            string data1 = sr.ReadLine();
            if (sr != null)
            {
                data1 += sr.ReadLine();
            }
            final += data1;
            sr.Close();

            sr = new StreamReader("F://" + destFile + ".txt");
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string data2 = sr.ReadLine();
            if (sr != null)
            {
                data2 += sr.ReadLine();
            }
            final += data2;
            sr.Close();

            sw = new StreamWriter("F://"+targetFile+".txt");

            sw.WriteLine("" + final);
            sw.Flush();
            sw.Close();            
            Console.WriteLine("done..");


        }
    }
}
