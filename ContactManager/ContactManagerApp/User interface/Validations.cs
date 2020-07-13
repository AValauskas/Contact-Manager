using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ContactManagerApp.User_interface
{
    public class Validations
    {
        public static string ProcessNameInCreation()
        {
            Console.WriteLine("Enter the name");
            var name = Console.ReadLine();
            return name;
        }
        public static string ProcessLastNameInCreation()
        {
            Console.WriteLine("Enter the last name");
            var lastName = Console.ReadLine();
            return lastName;
        }
        public static string ProcessPhoneInCreation()
        {
            Console.WriteLine("Enter the phone");
            
            bool error = true;
            while (error)
            {
                string phone = Console.ReadLine();
                error = !Regex.IsMatch(phone, "^[0-9]+$");
                if (error)
                { Console.WriteLine("Phone should contain only numbers, plese write again"); }
                else
                { return phone; }
            }
            return null;         
        }

        public static string ProcessAddressInCreation()
        {
            Console.WriteLine("Enter the address");
            var adress = Console.ReadLine();
            return adress;
        }
    }
}
