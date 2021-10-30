using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    abstract class Employee
    {
        private const int constPenalty = 50;
        private string name;
        private Employee head;
        private List<Task> tasks = new List<Task>();
        private Guid id;
        private double penalty=0;
        private bool isWarning = false;
        public Employee(string name,Employee head)
        {
            this.name = name;
            this.head = head;
            id = Guid.NewGuid();
        }
        public Employee(string name)
        {
            this.name=name;
            id = Guid.NewGuid();
        }
        
        public static void GiveTask(List <Employee> employees)
        {
            Console.WriteLine("Кто дает задачу?");
            string nameHead = Console.ReadLine(); // кто дает задачу?
            Type typeHead=null;
            bool isFounded = false;
            foreach (var employee in employees)
            {
                if (employee.name.Equals(nameHead) && !(employee is Developer) && !(employee is SystemEmployee))
                {
                    typeHead = employee.GetType();
                    isFounded = true;
                    Console.WriteLine("Мы нашли этого работника!");
                    employee.PrintInfo();
                }
            }
            if (!isFounded)
            {
                Console.WriteLine("Работник не найден!");
            }
            Console.WriteLine("Кому он ее дает?");//кому дать задачу?
            string name = Console.ReadLine();
            isFounded = false;
            foreach (var employee in employees)
            {
                if (name.Equals(employee.name) && !(employee is Boss) && employee.head.GetType() == typeHead && employee.tasks.Count<2)
                {
                    employee.PrintInfo();
                    Console.WriteLine("Введите согласен ли работник выполнять задачу?да/нет");
                    string access = Console.ReadLine().ToLower();
                    if (access.Equals("нет") && !employee.isWarning)
                    {
                        Console.WriteLine();///штраф,предупреждение
                        employee.isWarning = true;
                        employee.penalty += constPenalty;
                    }
                    else
                    {
                        employee.tasks.Add(Task.NewTask());
                        Console.WriteLine();//он взял задачу
                    }
                   
                    isFounded = true;
                }
            }
            if (!isFounded)
            {
                Console.WriteLine("Работник не найден!/Он не может взяться за эту задачу");
            }

        }
        public void PrintInfo()
        {
            Console.WriteLine($"Имя работника {this.name} ID работника {this.id}, его штрафы {this.penalty} Рублей");
        }
    }
}
