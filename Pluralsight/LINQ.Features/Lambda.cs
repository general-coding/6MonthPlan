using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Features
{
    public class Lambda
    {
        static int num = 10;

        public void NamedMethod()
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee{ Id = 1, Name = "Alpha"},
                new Employee{ Id = 2, Name ="Bravo"},
                new Employee{ Id = 3, Name = "Charlie"},
                new Employee{ Id = 4, Name ="Delta"}
            };

            IEnumerable<Employee> filteredList = developers.Where(ContainsA);

            foreach (Employee employee in filteredList)
            {
                Console.WriteLine(employee.Name);
            }
        }

        public bool ContainsA(Employee arg)
        {
            return arg.Name.Contains("a") ? true : false;
        }

        public void AnonymousMethod()
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee{ Id = 1, Name = "Alpha"},
                new Employee{ Id = 2, Name ="Bravo"},
                new Employee{ Id = 3, Name = "Charlie"},
                new Employee{ Id = 4, Name ="Delta"}
            };

            IEnumerable<Employee> filteredList = developers.Where(delegate (Employee arg)
                                                {
                                                    return arg.Name.Contains("a") ? true : false;
                                                });

            foreach (Employee employee in filteredList)
            {
                Console.WriteLine(employee.Name);
            }
        }

        public void Expression()
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee{ Id = 1, Name = "Alpha"},
                new Employee{ Id = 2, Name ="Bravo"},
                new Employee{ Id = 3, Name = "Charlie"},
                new Employee{ Id = 4, Name ="Delta"}
            };

            IEnumerable<Employee> filteredList = developers.Where(d => d.Name.Contains("a"));

            foreach (Employee employee in filteredList)
            {
                Console.WriteLine(employee.Name);
            }
        }

        public void FuncsForMethods()
        {
            Func<int, int, int> add = (x, y) =>
            {
                int temp = x + y;
                return temp;
            };

            Console.WriteLine(add(5, 3));
        }

        private int MaxEmployeeIdMethod(List<Employee> arg)
        {
            return arg.Max(e => e.Id);
        }

        public void FuncsForExpression()
        {
            Func<int, int> square = x => x * x;

            Console.WriteLine(square(3));
        }

        public void Actions()
        {
            Action<int> write = x => Console.WriteLine(x);

            write(10);

            List<String> names = new List<String>();
            names.Add("Bruce");
            names.Add("Alfred");
            names.Add("Tim");
            names.Add("Richard");

            // Display the contents of the list using the Print method.
            names.ForEach(Print);

            // The following demonstrates the anonymous method feature of C#
            // to display the contents of the list to the console.
            names.ForEach(delegate (String name)
            {
                Console.WriteLine(name);
            });
        }

        private static void Print(string s)
        {
            Console.WriteLine(s);
        }

        delegate int NumberChanger(int n);

        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }

        public static int getNum()
        {
            return num;
        }

        static void Main(string[] args)
        {
            //create delegate instances
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);

            //calling the methods using the delegate objects
            nc1(25);
            Console.WriteLine("Value of Num: {0}", getNum());
            nc2(5);
            Console.WriteLine("Value of Num: {0}", getNum());
            Console.ReadKey();
        }
    }
}
