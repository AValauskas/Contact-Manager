using ContactManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagerApp.Contracts
{
    public interface IFileService
    {
        public List<Contact> LoadContacts();
        public void WriteContacts(List<Contact> contacts);
      
    }
}
