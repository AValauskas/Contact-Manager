using ContactManagerApp.Contracts;
using ContactManagerApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContactManagerApp.Services
{
    public class FileService : IFileService
    {
        public List<Contact> LoadContacts()
        {
            List<Contact> items;
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"../../Files/Contacts.json");
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
               items = JsonConvert.DeserializeObject<List<Contact>>(json);
            }
            return items;
        }

        public void WriteContacts(List<Contact> contacts)
        {
            string json = JsonConvert.SerializeObject(contacts);
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"../../Files/Contacts.json");
            File.WriteAllText(path, json);
        }
    }
}
