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
            Console.WriteLine("Задание 1");
            BankAccount bankAccount1 = new BankAccount();
            Console.WriteLine("Введите номер аккаунта");
            long number;
            while (!long.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            Console.WriteLine("Введите тип аккаунта");
            string type = Console.ReadLine();
            Console.WriteLine("Введите баланс банковского счета");
            decimal balance;
            while (!decimal.TryParse(Console.ReadLine(), out balance))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            bankAccount1.Number = number;
            bankAccount1.Type = type;
            bankAccount1.Balance = balance;
            bankAccount1.PrintValues();
            BankAccount bankAccount2 = new BankAccount();
            Console.WriteLine("Введите номер аккаунта");
            while (!long.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            Console.WriteLine("Введите тип аккаунта");
            type = Console.ReadLine();
            Console.WriteLine("Введите баланс банковского счета");
            while (!decimal.TryParse(Console.ReadLine(), out balance))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            bankAccount2.Number = number;
            bankAccount2.Type = type;
            bankAccount2.Balance = balance;
            bankAccount2.PrintValues();
            Console.WriteLine("Введите сумму, которую нужно перевести с первого счета на второй");
            int sum1;
            while (!int.TryParse(Console.ReadLine(), out sum1))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
             if (sum1 < bankAccount1.Balance)
            {
                bankAccount1.MoneyTransfer(bankAccount2, sum1);
                Console.WriteLine($"Баланс на первом аккаунте: {bankAccount1.Balance}");
                Console.WriteLine($"Баланс на втором аккаунте: {bankAccount2.Balance}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств на балансе");
            }
            Console.WriteLine("Введите сумму, которую нужно перевести со второго счета на первый");
            int sum2;
            while (!int.TryParse(Console.ReadLine(), out sum2))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
             if (sum2 < bankAccount2.Balance)
            {
                bankAccount2.MoneyTransfer(bankAccount1, sum2);
                Console.WriteLine($"Баланс на втором аккаунте: {bankAccount2.Balance}");
                Console.WriteLine($"Баланс на первом аккаунте: {bankAccount1.Balance}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств на балансе ");
            }

            Console.WriteLine("Задание 2");
               string input = Console.ReadLine();
               Console.WriteLine(Reverse(input));
               Student student = new Student();
               if (student is Person)
               {
                  object c = student as Person;
               }
               object a =student as Person;

            Console.WriteLine("Задание 3");
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

                
                Console.WriteLine("Песни");
                List<Song> songs = new List<Song>();
                songs.Add(new Song("Antarstica", "$uicideboy$"));
                songs.Add(new Song("lately", "guccihighwater"));
                songs.Add(new Song("Old Town Road", "Lil Nas X"));
                songs.Add(new Song("The Real Slim Shady", "Eminem"));

                foreach (var song in songs)
                {
                    Console.WriteLine(Song.Title(song));
                }
            }
        }
}
