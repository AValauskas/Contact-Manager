using ContactManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagerApp.Contracts
{
    public interface IContactService
    {
        public string AddContact(List<Contact> contacts);
        public bool UpdateContact(int index, Contact contact);
        public void DeleteContact(int index);
        public List<Contact> ContactList();
    }
}
