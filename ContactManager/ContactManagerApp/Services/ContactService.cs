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
                fileService.WriteContacts(contacts);
                return true;
            }
            return false;
        }

        public List<Contact> ContactList()
        {
            return fileService.LoadContacts();
        }

        public bool DeleteContact(string phone)
        {
            var contacts = fileService.LoadContacts();

            int index = contacts.FindIndex(f => f.Phone == phone);

            if (index >= 0)
            {
                contacts.RemoveAt(index);
                fileService.WriteContacts(contacts);
                return true;
            }
            return false;
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
