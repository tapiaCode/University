using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "toyota Supra",
                "toyota Onix",
                "toyota Rav4",
                "suzuky",
                "nissan",
                "mitsubishi",
                "ford",
                "changan",
                "fiat",
            };

            //1. SELECT * for cars (SELECT ALL CARS)
            var carList = from car in cars select car;

            foreach (var car in carList )
            {
                Console.WriteLine(car);  
            }

            //2. SELECT WHERE car is toyota (SELECT TOYOs)
            var toyoList = from car in cars where car.Contains("toyota") select car;

            foreach (var toyo in toyoList)
            {
                Console.WriteLine(toyo);
            }
        }

        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1,2,3,4,5,6,7,8,9};

            //Each number multiplied by 3
            //take all numbers, but 9
            //order numbers by ascending value

            var processedNumberList = numbers
                .Select(num => num * 3) // { 3, 6, 9, etc.}
                .Where(num => num != 9) // {all but the 9}
                .OrderBy(num => num); // {order ascending}
        }

        static public void searchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bc",
                "as",
                "d",
                "c",
                "ce",
                "f",
                "cr"
            };

            //1. first of all element
            var first = textList.First();

            //2. first element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            //3. first element that contains "a"
            var aText   = textList.First(text => text.Contains("a"));

            //4. first element that contains "z" or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Equals("z"));
            
            //5. last element that contains "z" or default
            var lastOrDefaultText = textList.LastOrDefault(text => text.Equals("z"));

            //6. Single Values
            var uniqueText = textList.Single();
            var uniqueorDefaultText = textList.SingleOrDefault();

            int[] ovenNumber = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumber = { 0, 4 };

            var myEvenNumber = ovenNumber.Except(otherEvenNumber); // { 2, 6 , 8 }

        }

        static public void multipleSelect()
        {
            //SELECT MANY
            string[] myOpinion =
            {
                "opinion1, text1",
                "opinion2, text2",
                "opinion3, text3"
            };

            var opinionSelection = myOpinion.SelectMany(opinion => opinion.Split(","));

            
            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 1,
                            Name = "jose",
                            Email = "jose@mail.net",
                            Salary = 3000
                        },
                        new Employee()
                        {
                            Id = 2,
                            Name = "khali",
                            Email = "khali@mail.net",
                            Salary = 2000
                        },
                        new Employee()
                        {
                            Id = 3,
                            Name = "angel",
                            Email = "angel@mail.net",
                            Salary = 3000
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 4,
                            Name = "pedro",
                            Email = "pedro@mail.net",
                            Salary = 3000
                        },
                        new Employee()
                        {
                            Id = 5,
                            Name = "maria",
                            Email = "maria@mail.net",
                            Salary = 2000
                        },
                        new Employee()
                        {
                            Id = 6,
                            Name = "flor",
                            Email = "flor@mail.net",
                            Salary = 3000
                        }
                    }
                }
            };

            //obtain all employees of all enterprises with linQ
            var listEmployees = enterprises.SelectMany(enterprise => enterprise.Employees);

            //Know is an a list is Empty
            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            //All enterprises at least has an employee with more than > 1000 of salary
            bool hasEmployeeWithSalary = 
                enterprises.Any(enterprise => 
                    enterprise.Employees.Any(employee => employee.Salary >= 1000));
        }


        static public void linQCollections()
        {
            var firstList = new List<string>() { "a", "b", "c"};
            var secondList = new List<string>() { "a", "c", "d" };

            //INNER JOIN
            var commonResult = from a in firstList 
                               join b in secondList 
                               on a equals b select new { a, b };

            var commonResult2 = firstList.Join(
                    secondList,
                    a => a,
                    b => b,
                    ( a, b ) => new { a, b }
                );

            //OUTER JOIN - LEFT
            var leftOuterJoin = from a in firstList
                                join b in secondList
                                on a equals b into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where a != temporalElement
                                select new { Element = a };

            var leftOuterJoin2 = from a in firstList
                                 from b in secondList.Where(s => s == a).DefaultIfEmpty()
                                 select new { ElementA = a, ElementB = b};



            //OUTER JOIN - RIGTH
            var rigthOuterJoin = from b in secondList
                                 join a in firstList
                                 on b equals a into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where b != temporalElement
                                 select new { Element = b };

            //UNION
            var unionList = leftOuterJoin.Union(rigthOuterJoin);
        }

        static public void skipTakeLinQ()
        {
            var myList = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //SKIP
            var skipTwoFirst = myList.Skip(2);

            var skipTwoLast = myList.SkipLast(2);

            var skipWhile= myList.SkipWhile(num => num < 4);

            //TAKE
            var takeTwoFirst = myList.Take(2);

            var takeTwoLast = myList.TakeLast(2);

            var takeWhile = myList.TakeWhile(num => num < 4);

        }
    }
}