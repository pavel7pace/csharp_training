﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("test name");
            contact.MiddleName = "test middlename";
            contact.LastName = "test lastname";

            ContactData newData = new ContactData("Ivan");
            newData.MiddleName = "Petrovich";
            newData.LastName = "Vetrov";


            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            app.Contacts.Modify(newData, 0);
            List<ContactData> newContacts = app.Contacts.GetContactsList();

            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
