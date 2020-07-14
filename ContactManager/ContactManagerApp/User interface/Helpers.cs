using ContactManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ContactManagerApp.User_interface
{
    public class Helpers
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
            Console.WriteLine("Enter the phone or few phones separated by comma(,) ");
            
            bool error = true;
            while (error)
            {
                string phone = Console.ReadLine();
                error = !Regex.IsMatch(phone, "^[0-9,+]+$");
                if (error)
                { Console.WriteLine("Phone should contain only numbers or few phones should be separated by comma, please write again"); }
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

        public static string ProcessNameInUpdate(string name)
        {
            Console.WriteLine($"Enter the name or press enter for {name} ");
            var writtenName = Console.ReadLine();

            return writtenName!=""? writtenName:name;
        }
        public static string ProcessLastNameInUpdate(string lastName)
        {

            Console.WriteLine($"Enter the last name or press enter for {lastName} ");
            var writtenLastName = Console.ReadLine();
            return writtenLastName != "" ? writtenLastName : lastName;

        }
        public static string ProcessPhoneInUpdate(string phone)
        {
            Console.WriteLine($"Enter the phone or press enter for {phone} ");

            bool error = true;
            while (error)
            {
                string writtenPhone = Console.ReadLine();
                error = !Regex.IsMatch(writtenPhone, "^[0-9]+$");
                if (error && writtenPhone!="")
                { Console.WriteLine("Phone should contain only numbers, plese write again"); }
                else
                { return writtenPhone != "" ? writtenPhone : phone; }
            }
            return null;
        }

        public static string ProcessAddressInUpdate(string address)
        {
            Console.WriteLine($"Enter the address or press enter for {address} ");
            var writtenAddress = Console.ReadLine();
            return writtenAddress != "" ? writtenAddress : address;
        }

        

    }
}
