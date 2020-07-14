using ContactManagerApp.Contracts;
using ContactManagerApp.Models;
using ContactManagerApp.Services;
using ContactManagerApp.User_interface;
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
            Console.Clear();
            Console.WriteLine("Creation of new contact \n");

            var contact = FillCreationData();
            var contacts = SeparatePhones(contact);

            string duplicatedPhones = ContactService.AddContact(contacts);
            if (duplicatedPhones == "")
            {
                Console.WriteLine("\nNew Contact was sucesfully added");
            }
            else
            {
                Console.WriteLine($"\n{duplicatedPhones} out of {contact.Phone} already exist in contacts and was not added");
            }
            EndAnOperation();
        }

        public void Update()
        {
            List();    
            Console.WriteLine("\nWrite index, which contact should be updated or write any letter to get back");         
            
            bool error = true;
            while (error)
            {
                error = ProcessUpdateOperation();
            }
            EndAnOperation();
        }

        public void Delete()
        {
            List();
            Console.WriteLine("\nWrite contact index which should be deleted, or write any letter to stop deleting");                     
            bool error = true;

            while (error)
            {
                error = ProcessDeleteOperation();
            }
            EndAnOperation();
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
        }

        private Contact FillCreationData()
        {
            Contact contact = new Contact();

            contact.Name = Helpers.ProcessNameInCreation();
            contact.LastName = Helpers.ProcessLastNameInCreation();
            contact.Phone = Helpers.ProcessPhoneInCreation();
            contact.Address = Helpers.ProcessAddressInCreation();

            return contact;
        }

        private Contact FillUpdateData(int index)
        {
            var contacts = ContactService.ContactList();

            Contact contact = contacts[index - 1];

            contact.Name = Helpers.ProcessNameInUpdate(contact.Name);
            contact.LastName = Helpers.ProcessLastNameInUpdate(contact.LastName);
            contact.Phone = Helpers.ProcessPhoneInUpdate(contact.Phone);
            contact.Address = Helpers.ProcessAddressInUpdate(contact.Address);

            return contact;
        }

        private List<Contact> SeparatePhones(Contact contact)
        {
            List<Contact> newContacts = new List<Contact>();
            string[] phones = contact.Phone.Split(',');

            foreach (var phone in phones)
            {
                var separatePhone = (Contact)contact.Clone();
                separatePhone.Phone = phone;
                newContacts.Add(separatePhone);
            }

            return newContacts;
        }

        public void EndAnOperation()
        {
            Console.WriteLine("\nPress enter to get back to operations");
            Console.ReadLine();
            Console.Clear();
        }       

        private bool CheckIfIndexCorrect(int index)
        {
            var contacts = ContactService.ContactList();
            if (index > contacts.Count)
                return false;
            return true;
        }

        private bool ProcessDeleteOperation()
        {
            int index;
            int.TryParse(Console.ReadLine(), out index);
            if (index == 0)
            {
                Console.WriteLine("\nYou clicked to get back \n");
                return false;
            }

            if (CheckIfIndexCorrect(index))
            {
                ContactService.DeleteContact(index);
                Console.WriteLine("\nContact was sucesfully deleted");
                return false;
            }
            else
            {
                Console.WriteLine("\nIndex out of range, write index once again");
                return true;
            }        
        }

        private bool ProcessUpdateOperation()
        {
            int index;         
            int.TryParse(Console.ReadLine(), out index);
            if (index == 0)
            {
                Console.WriteLine("\nYou clicked to get back \n");
                return false;
            }

            if (!CheckIfIndexCorrect(index))
            {
                Console.WriteLine("\nIndex out of range, write index once again");
                return true;
            }
                
            var contact = FillUpdateData(index);

            if (ContactService.UpdateContact(index, contact))
            {
                Console.WriteLine("\nContact was sucesfully updated");
                return false;
            }
            else
            {
                Console.WriteLine("\nPhone number already exist");
                return false;
            } 
        }


    }
}
