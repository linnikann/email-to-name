using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GetNameFromEMail
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UserService userService = new UserService();
            

            //Console.Write("Enter e-mail address: ");
            //string address = Console.ReadLine();
            //Console.WriteLine("Name: {0} {1}", userService.GetFirstName(address), userService.GetLastName(address));
            Console.WriteLine("Preparing CSV...");
            userService.ConvertCSV();
            Console.WriteLine("CSV Finished.");

            Console.ReadKey();
        }
    }
}
