using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQdemo
{
    class Program
    {
        static Employee employee;
        static Incentive incentive;
        static void Main(string[] args)
        {
            employee = new Employee();
            incentive = new Incentive();
            List<Employee> str = new List<Employee>()
           {
                new Employee(){EmpId = 1,Firstname="Pratik",LastName="Jain",salary=1000,JoiningDate="15 Jan 2020",Department=".net"},
                new Employee(){EmpId = 2,Firstname="Anuj",LastName="Jain",salary=10000,JoiningDate="15 Jan 2020",Department="php"}, 
                new Employee(){EmpId = 3,Firstname="John",LastName="yadav",salary=4000,JoiningDate="15 Jan 2020",Department=".net"}
           };

            var emp = from s in str select s;
            foreach (var i in emp)
                Console.WriteLine(i.LastName.ToUpper()+" "+i.Firstname);

            var unique = str.Select(o => new { o.Department}).Distinct();
            foreach (var i in unique)
                Console.WriteLine(i);

            var oInJohn = from s in str where s.Firstname == "John" select s;
            foreach (var i in oInJohn)
            {
                Console.WriteLine(i.Firstname.IndexOf("o"));
                Console.WriteLine(i.Firstname.Replace("o","$"));
            }

            var fist3Char = from s in str select s.Firstname;
            foreach (var i in fist3Char) {
                Console.WriteLine(i.Substring(0, 3));
                Console.WriteLine(i.Length);
            }

            var fistCharP = from s in str where s.Firstname.StartsWith("P") select s.Firstname;
            foreach (var i in fistCharP)
                Console.WriteLine(i);

            var x = str.Where(f => f.Firstname == "Pratik");
            foreach(var i in x)
            {
                Console.WriteLine(i.EmpId); 
            }

            var dist = str.Select(o=>o.Department).Distinct();
            foreach(var i in dist)
            {
                Console.WriteLine(i);
            }

            int max1 = str.Max(f => f.salary);
            Console.WriteLine(max1);
            var max2 = from s in str where s.salary < (str.Select(f => f.salary).Max()) select s.salary;
            Console.WriteLine(max2);

            var top10 = (from s in str orderby s.salary descending select s).Take(2).ToList();
            foreach(var i in top10) 
                Console.WriteLine(i.salary);

            var depTotalSalary = str.Where(x=>x.Department==".net").Select(o => o.salary).Sum();
            Console.WriteLine(depTotalSalary);
                
        }
    }
}
