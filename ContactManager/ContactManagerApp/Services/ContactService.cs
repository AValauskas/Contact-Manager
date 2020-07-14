using ContactManagerApp.Contracts;
using ContactManagerApp.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ContactManagerApp.Services
{
    public class ContactService : IContactService
    {
        public IFileService fileService { get; set; }

        public string AddContact( List<Contact> contacts)
        {         
            var allContacts = fileService.LoadContacts();
            if (allContacts == null)
            {
                allContacts = new List<Contact>();
            }
            string duplicatedPhones = "";
            foreach (var contact in contacts)
            {
                int index = allContacts.FindIndex(f => f.Phone == contact.Phone);
                if (index < 0)
                {
                    allContacts.Add(contact);                    
                }
                else
                {
                    duplicatedPhones = duplicatedPhones + contact.Phone + ";";
                }

            }
            fileService.WriteContacts(allContacts);
            return duplicatedPhones;
        }

        public List<Contact> ContactList()
        {
            return fileService.LoadContacts();
        }

        public void DeleteContact(int index)
        {
            var contacts = fileService.LoadContacts();
                    
            contacts.RemoveAt(index-1);
            fileService.WriteContacts(contacts);
                
        }

        public bool UpdateContact(int index, Contact contact)
        {        
            var contacts = fileService.LoadContacts();

            int indexOfDuplicate = contacts.FindIndex(f => f.Phone == contact.Phone);
            if (indexOfDuplicate < 0 || indexOfDuplicate == index-1)
            {
                contacts[index - 1] = contact;
                fileService.WriteContacts(contacts);
                return true;
            }
            else
            {
                return false;
            }

            
        }
    }
}
