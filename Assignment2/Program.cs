using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListsAndMoreLists
{
    class Program
    {
        static void Main(string[] args)
        {         
            var users = new List<User>();

            users.Add(new User { Name = "Dave", Password = "hello" });
            users.Add(new User { Name = "Steve", Password = "steve" });
            users.Add(new User { Name = "Lisa", Password = "hello" });

            Console.WriteLine($"The list starts out with ({users.Count}) users:");
            foreach (var item in users)
            {
                Console.WriteLine($" -->{item.Name}");
            }

            // 1.Display to the console, all the passwords that are "hello".Hint: Where
            
            //var passwordHello = from candidate in users
            //           where candidate.Password == "hello"
            //           select candidate;
            var passwordHello = users.Where(candidate => candidate.Password == "hello");

            Console.WriteLine("\n----------------------------------------\n");
            Console.WriteLine($"({passwordHello.ToArray().Length}) user(s) found with \"hello\" as a password:");
            foreach (var item in passwordHello)
            {
                Console.WriteLine($" -->{item.Name.ToString()}");
            }


            // 2.Delete any passwords that are the lower-cased version of their Name. Do not just look for "steve".It has to be data - driven.Hint: Remove or RemoveAll

            //var lowerCaseNamesRemoved = from candidate in users
            //                            where candidate.Password == candidate.Name.ToLower()
            //                            select candidate;
            var lowerCaseNamesRemoved = users.Where(candidate => candidate.Password == candidate.Name.ToLower());

            Console.WriteLine("\n----------------------------------------\n");
            Console.WriteLine($"({lowerCaseNamesRemoved.ToArray().Length}) user(s) removed from the list because password was set to lowercase name:");
            foreach (var item in lowerCaseNamesRemoved)
            {
                Console.WriteLine($" -->{item.Name}");
            }
            users.RemoveAll(r => lowerCaseNamesRemoved.Any(a => a == r));



            Console.WriteLine($"\nThe list now contains ({users.Count}) user(s)");
            foreach (var item in users)
            {
                Console.WriteLine($" -->{item.Name}");
            }
            Console.WriteLine("\n----------------------------------------");


            //3.Delete the first User that has the password "hello".Hint: First or FirstOrDefault
            var result = users.First(x => x.Password == "hello");
            users.Remove(result);
            Console.WriteLine($"\nThe first occurance of the password \"hello\" in the list belongs to:");
            Console.WriteLine($" -->{result.Name}");
            Console.WriteLine("\n----------------------------------------");


            //4.Display to the console the remaining users with their Name and Password.
            Console.WriteLine($"\nList now contains {users.Count.ToString()} user(s)");
            Console.WriteLine($"    NAME:         PASSWORD:");
            foreach (var item in users)
            {
                Console.WriteLine($" -->{item.Name.ToString()}          {item.Password}");
            }
            Console.WriteLine("\n----------------------------------------");
        }
    }
}
