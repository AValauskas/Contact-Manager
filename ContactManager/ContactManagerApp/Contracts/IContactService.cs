using ContactManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagerApp.Contracts
{
    public interface IContactService
    {
        public bool AddContact(Contact contact);
        public bool UpdateContact(int index, Contact contact);
        public bool DeleteContact(string phone);
        public List<Contact> ContactList();
    }
}
