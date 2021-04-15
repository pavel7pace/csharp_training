using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("Ivan");
            contact.MiddleName = "Petrovich";
            contact.LastName = "Vetrov";


            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.Create(contact);
            }
            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            app.Contacts.Remove(0);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactsList();            

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
