using ContactManagerApp.Contracts;
using ContactManagerApp.Models;
using ContactManagerApp.Services;
using NUnit.Framework;
using System.Collections.Generic;


namespace ContactManagerTest
{
    public class Tests
    {
        List<Contact> contacts;
        IContactService contactService;
        IFileService fileService;

        [SetUp]
        public void Setup()
        {
            contacts = new List<Contact>() {
            new Contact(){Name = "James", LastName = "Bond", Phone ="12345", Address="pasile"},
            new Contact(){Name = "James", LastName = "Bond", Phone ="22222", Address="pasile"},
            new Contact(){Name = "Mike", LastName = "Tyson", Phone ="123456", Address="savanoriai"},
            };
            fileService = new FileService();
            contactService = new ContactService() { fileService = fileService };
        }

        [Test]
        public void Add_Contact_Test()
        {


            Assert.Pass();
        }
    }
}