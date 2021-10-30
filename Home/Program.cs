using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new Boss("Борис"));

            employees.Add(new HelperOfBoss("О Ильхам", employees[0]));

            employees.Add(new MainDeveloper("Сергей", employees[1]));

            employees.Add(new MainSystemEmployee("Ильшат", employees[1]));

            employees.Add(new HelperOfDevelopers("Ляйсан", employees[2]));

            employees.Add(new HelperOfSystemEmployee("Иваныч",employees[3]));

            employees.Add(new SystemEmployee("Илья", employees[5]));
            employees.Add(new SystemEmployee("Женя", employees[5]));
            employees.Add(new SystemEmployee("Витя", employees[5]));

            employees.Add(new Developer("Дина", employees[4]));
            employees.Add(new Developer("Марат", employees[4]));
            employees.Add(new Developer("Ильдар", employees[4]));
            employees.Add(new Developer("Антон", employees[4]));

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите команду Добавить,чтобы добавить задачу Выйти,чтобы закрыть программу");
                string command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "добавить":
                        Employee.GiveTask(employees);
                        break;
                    case "выйти":
                        flag = false;
                        break;
                }
            }


        }
    }
}
