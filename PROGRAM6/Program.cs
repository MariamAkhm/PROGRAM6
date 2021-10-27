using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;


namespace PROGRAM6
{
    class Song
    {
        public Song(string name,string author)
        {
            this.name = name;
            this.author = author;
        }
        public static void Search(List<Song> songs)
        {
            bool isFounded = false;
            for (int i = 0; i < songs.Count; i++)
            {
                for (int j = 1; j < songs.Count - 1; j++)
                {
                    if (songs[i] != null && songs[j] != null)
                    {
                        if (songs[i].Equals(songs[j]) && i!=j)
                        {
                            isFounded = true;
                            Console.WriteLine($"Совпали песни под номерами {i + 1} и {j + 1}, Название {songs[i].name} , автор {songs[i].author} ");
                            songs[i] = null;
                        }
                    }
                }
                if (isFounded)
                {
                    Search(songs);
                }   
            }
            
        }
        public static string Title(Song song)
        {
            return $"{song.name} {song.author}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Song)
            {             
                if ($"{this.name} {this.author}" == Song.Title(obj as Song))
                {
                    return true;
                }              
            }
            return false;
        }

        string name;
        string author;

    }
    
    class Program
    {
        class Person
        {
            string name;
        }
        class Student:Person
        {
            string exam;
            int age;
        }
        
        static void GetMail(ref string strInput)
        {
            List<string> emails = new List<string>();
            bool flag = true;
            while (!strInput.Equals("") && flag)
            {
                int i = 0;
                string str = "";
                while (strInput[i] != '\n')
                {
                    str += strInput[i];
                    i++;
                }

                emails.Add(str.Replace(" ", "").Split('#')[1]);
                strInput = strInput.Remove(0, strInput.IndexOf('\n') + 1);
            }            
            File.WriteAllLines("result.txt", emails);
        }
        static bool isFormattable(object a)
        {
            if (a is IFormattable)
            {
                Console.WriteLine(a);
                return true;
            }
            else
            {
                return false;
            }
        }
            static string Reverse(string str)
            {
                string tmp = "";
                for (int i = str.Length-1; i >= 0; i--)
                {
                    tmp += str[i];
                }
                return tmp;

            }
            static void Main(string[] args)
            {


            /*   Console.WriteLine("Задание 2");
               string input = Console.ReadLine();
               Console.WriteLine(Reverse(input));
               /*Student student = new Student();
               if (student is Person)
               {
                  object c = student as Person;
               }
               object a =student as Person;*/

           /* Console.WriteLine("Задание 3");
            Console.WriteLine("Введите имя файла");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {
                string tmp = File.ReadAllText(path).ToUpper();               
                File.WriteAllText("1"+path, tmp);               
            }
            else
            {
                Console.WriteLine("Файл не найден");
            }
           */
                int count = 0;
                using (StreamReader reader = new StreamReader("emails.txt"))
                {
                    while (reader.ReadLine() != null)
                    {
                        count++;
                    }
                    reader.Close();
                }
                string str = "";
                using (StreamReader reader = new StreamReader("emails.txt"))
                {

                    for (int i = 0; i < count; i++)
                    {
                        str += reader.ReadLine() + "\n";
                    }
                }
                GetMail(ref str);

                
             /*   Console.WriteLine("Песни");
                List<Song> songs = new List<Song>();
                songs.Add(new Song("Кадиллак", "Моргенштерн"));
                songs.Add(new Song("Кадиллак", "Моргенштерн"));
                songs.Add(new Song("Old Town Road", "Lil Nas X"));
                songs.Add(new Song("Кадиллак", "Моргенштерн"));

                foreach (var song in songs)
                {
                    Console.WriteLine(Song.Title(song));
                }
             */
                
               
                




            }
        }
}
