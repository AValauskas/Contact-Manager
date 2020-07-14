using ContactManagerApp.Contracts;
using ContactManagerApp.Services;
using System;

namespace ContactManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {        
            ProcessContactManager();
        }

        public static void ProcessContactManager()
        {
            UI ui = new UI() 
            { 
                ContactService = new ContactService() 
                { 
                    fileService = new FileService() 
                }
            };
                       
            Console.WriteLine("Hello, this is Contact Manager App!! \n ");
            bool exit = false;
            while (!exit)
            {
                switch (Operation())
                {
                    case 'C':
                        ui.Create();
                        break;
                    case 'U':
                        ui.Update();
                        break;
                    case 'D':
                        ui.Delete();
                        break;
                    case 'L':
                        ui.List();
                        ui.EndAnOperation();
                        break;
                    case 'X':
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You typed the wrong letter.\n\n");
                        break;
                }
                
            }
        }

        public static char Operation()
        {
            Console.WriteLine("Select the operation you want to perform " +
                "\n C-Create contact \n U-Update contact \n D-Delete contact \n L-Contacts List \n X-Exit");

            var selection = Console.ReadKey().KeyChar;          
            return Char.ToUpper(selection);
        }

    }
}
