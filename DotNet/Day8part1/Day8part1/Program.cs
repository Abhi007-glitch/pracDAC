using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Day8part1
{
    internal class Program
    {
        /// <summary>
        /// FILE IO:
        /// 1)
        /// 2)
        /// 3)FileStream
        /// 4) Unformatted IO  
        /// 5) Formatted IO
        /// 
        /// File stream
        /// </summary>
        /// <param name="args"></param>
        static void Main1(string[] args)
        {
            DriveInfo drive = new DriveInfo("C");
            //drive.

            //Directory.CreateDirectory("C:\\new"); // first \ is escape char
            Directory.CreateDirectory(@"C:\new");
            // Directory. -> has static method to get details of directory

            DirectoryInfo dir =new DirectoryInfo("C:\\new");
            // DirectoryInfo - have non static methods for getting details of directory 


            // File and FileInfo are same as Directory and DirectoryInfo (static and nonStaic features)
            File.Create(@"C:\new\a.txt");


            FileInfo file = new FileInfo(@"C:\new\a.txt");

            // open or created file should be closed after work so that other can access it .
        }


        // Text File I/O - formated and unformatted
        public static void Main2()
        {
            String s = " hello , World";
            byte[] arr = Encoding.Default.GetBytes(s); // have UTF and other encoding too

            // writiing a file 
            FileStream writeStream = File.Open("C\\new\a.txt", FileMode.Create);// File mode define the access that fs has on this file 
                                                                                // FileMode - mode of modification create a new one or append to previous or overwrite a file 
                                                                                // FileMode - open -> open a file 
                                                                                // FileMode - create -> create a new file if not exists else overwrite
                                                                                // FileMode - createNew -> will throw eoor 
            writeStream.Write(arr, 0, arr.Length);

            writeStream.Close(); // closing the file 

            FileStream readStream = File.Open("C\\new\a.txt", FileMode.Create);
            byte[] readBytes = new byte[readStream.Length];
            readStream.Read(readBytes,0,readBytes.Length);
            readStream.Close();



            // FORMATED STREAM 

            StreamWriter write = File.CreateText(@"C:\new\a.txt");
            write.Write("ABhinav");
            write.WriteLine(" sharma ");

            write.Close();
            String str;
            StreamReader reader = File.OpenText("");
            while( (str=reader.ReadLine()) != null )
            {
                Console.WriteLine(str);
            }
            reader.Close();
            
        }


        public static void Main3()
        {
            string s ="Hello";
            int i = 100;
            bool b =true;


            FileInfo binary_writer =new FileInfo(@"C:\new\a.dat");

            BinaryWriter writter = new BinaryWriter(binary_writer.OpenWrite());

            writter.Write(s);
            writter.Write((byte)i);
            writter.Write(b);


            writter.Close();
            // the order in which write data should be the same as the order in which read 

            FileInfo binary_reader = new FileInfo(@"C:\new\a.dat");
            BinaryReader reader = new BinaryReader(binary_reader.OpenRead());

            s = reader.ReadString();
            i = reader.ReadInt32();
            b = reader.ReadBoolean();

            reader.Close();


        }

        /// ****************************** SERIALIZATION ********************************

        // what can we serialized ? _> any class marked with an attribute serializable
        // attribute - is meta Data for either the assembly or for the class or for the member of the class 
        // for serializing into different formate - we have formtter ( BinaryFormatter, JsonSerializer, XMLFormatter)


        // marking class as serializable 
        [Serializable]
        // attribute that we create will have suffix of attribute
        public class Class1
        {
            private int privat_data;
            public int i;
            [XmlElement] // atribute for member of the class
            public String p1
            {
                get;
                set;
            }

            private int mP2;
            
        }


        public static void Main()
        {
            Class1 o = new Class1();

            o.i = 10;
            o.p1 = "abhnav";
            
            BinaryFormatter bf = new BinaryFormatter();

            Stream s = new FileStream(@"C:\new\o.dat",FileMode.Create);
#pragma warning disable SYSLIB0011 // supressing error caused by calling serilize
            bf.Serialize(s, o);  // this works in dotnet Framework

            s.Close();


            binaryDeserialization();


            // Deserialzation same as serialization '
            // just use bf.Desrialzae
            // type cast

        }

        public static void  binaryDeserialization()
        {
            BinaryFormatter bf = new BinaryFormatter();
            Stream s = new FileStream(@"C:\new\o.dat", FileMode.Open);
            Class1 o = (Class1)bf.Deserialize(s);
            Console.WriteLine("P1 : ",o.p1);
            Console.WriteLine(o.i);
            Console.WriteLine(o.p1);


        }





    }
}
