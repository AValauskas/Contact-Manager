using ContactManagerApp.Contracts;
using ContactManagerApp.Models;
using ContactManagerApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagerApp
{
    public class UI
    {
        public IContactService ContactService { get; set; }
        public void Create()
        {
            Contact contact = new Contact();
            Console.Clear();
            Console.WriteLine("Creation of new contact \n");

            Console.WriteLine("Enter the name");
            contact.Name = Console.ReadLine();

            Console.WriteLine("Enter the last name");
            contact.LastName = Console.ReadLine();

            Console.WriteLine("Enter the phone");
            contact.Phone = Console.ReadLine();

            Console.WriteLine("Enter the address");
            contact.Address = Console.ReadLine();

            if (ContactService.AddContact(contact))
            {
                Console.WriteLine("\nNew Contact was sucesfully added");
            }
            else
            {
                Console.WriteLine("\nThis phone number is already in list");
            }
            Console.WriteLine("\nPress enter to continue operations");
            Console.ReadLine();

        }

        public void Update()
        {
            List();
           

            Console.WriteLine("Write index, which contact should be updated");
            var index = int.Parse(Console.ReadLine());

            var contacts = ContactService.ContactList();
            if (index>contacts.Count)
            {
                Console.WriteLine("Index out of range");
            }
            else
            {
                Contact contact = contacts[index - 1];

                Console.WriteLine($"Enter the name, press enter for {contact.Name} ");
                contact.Name = Console.ReadLine();

                Console.WriteLine($"Enter the last name, press enter for {contact.LastName} ");
                contact.LastName = Console.ReadLine();

                Console.WriteLine($"Enter the phone, press enter for {contact.Phone} ");
                contact.Phone = Console.ReadLine();

                Console.WriteLine($"Enter the address, press enter for {contact.Address} ");
                contact.Address = Console.ReadLine();

                ContactService.UpdateContact(index, contact);
            }
            Console.WriteLine("\nPress enter to continue operations");
            Console.ReadLine();

        }

        public void Delete()
        {
            Console.Clear();
            
            Console.WriteLine("Write phone number which should be deleted");
            var phone = Console.ReadLine();
           
            if (ContactService.DeleteContact(phone))
            {
                Console.WriteLine("\nContact was sucesfully deleted");
            }
            else
            {
                Console.WriteLine("\nThere is no such contact");
            }
            Console.WriteLine("\nPress enter to continue operations");
            Console.ReadLine();
        }
        public void List()
        {
            Console.Clear();
            var contacts = ContactService.ContactList();
           
            Console.WriteLine("All Contacts List: \n");
            Console.WriteLine("Name, Last Name, Phone Number, Address");
            int count = 0;
            foreach (var item in contacts)
            {
                Console.Write(++count+") ");
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();
        }

        
    }
}
