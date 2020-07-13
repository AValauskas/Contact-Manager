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
    class ContactService : IContactService
    {
        public IFileService fileService { get; set; }

        public bool AddContact( Contact contact)
        {        
            var contacts = fileService.LoadContacts();
            if (contacts == null)
            {
                contacts = new List<Contact>();
            }

            int index = contacts.FindIndex(f => f.Phone == contact.Phone);

            if (index < 0)
            {
                contacts.Add(contact);
                fileService.WriteContacts(contacts);
                return true;
            }
            return false;
        }

        public List<Contact> ContactList()
        {
            return fileService.LoadContacts();
        }

        public bool DeleteContact(int index)
        {
            var contacts = fileService.LoadContacts();

            if (index > contacts.Count)
               return false;
                    
            contacts.RemoveAt(index-1);
            fileService.WriteContacts(contacts);
            return true;           
        }

        public bool UpdateContact(int index, Contact contact)
        {
            var contacts = fileService.LoadContacts();

            contacts[index-1] = contact;
            fileService.WriteContacts(contacts);
            return false;
        }
    }
}
