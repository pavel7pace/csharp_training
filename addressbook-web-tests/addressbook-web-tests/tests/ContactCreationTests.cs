using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : AuthTestBase
    {
       
        [Test]
        public void ContactCreationTests()
        {

            ContactData contact = new ContactData("Ivan");
            contact.MiddleName = "Petrovich";
            contact.LastName = "Vetrov";

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Create(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }       
    }
}

