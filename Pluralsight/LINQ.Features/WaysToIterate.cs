using System;
using System.Collections.Generic;

namespace LINQ.Features
{
    public class WaysToIterate
    {
        public void OldWay()
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee{ Id = 1, Name = "Alpha"},
                new Employee{ Id = 2, Name ="Bravo"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee{ Id = 3, Name = "Charlie"},
                new Employee{ Id = 4, Name ="Delta"}
            };

            IEnumerator<Employee> developersEnumerator = developers.GetEnumerator();
            while (developersEnumerator.MoveNext())
            {
                Console.WriteLine(developersEnumerator.Current.Name);
            }

            IEnumerator<Employee> salesEnumerator = sales.GetEnumerator();
            while (salesEnumerator.MoveNext())
            {
                Console.WriteLine(salesEnumerator.Current.Name);
            }

            //Use extension method to get count
            Console.WriteLine($"Number of developers: {developers.Count()}");
            Console.WriteLine($"Number of sales reps: {sales.Count()}");
        }
        public void NewWay()
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee{ Id = 1, Name = "Alpha"},
                new Employee{ Id = 2, Name ="Bravo"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee{ Id = 3, Name = "Charlie"},
                new Employee{ Id = 4, Name ="Delta"}
            };

            foreach (Employee employee in developers)
            {
                Console.WriteLine(employee.Name);
            }

            foreach (Employee employee in sales)
            {
                Console.WriteLine(employee.Name);
            }

            //Use extension method to get count
            Console.WriteLine($"Number of developers: {developers.Count()}");
            Console.WriteLine($"Number of sales reps: {sales.Count()}");
        }
    }
}
