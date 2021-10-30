using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    class Task
    {
        private string name;
        private string description;
        public static Task NewTask()
        {
            Console.WriteLine("Введите название задачи");
            string name = Console.ReadLine();
            Console.WriteLine("Введите описание");
            string description = Console.ReadLine();
            return new Task(name,description);
        }
        public Task(string name,string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
