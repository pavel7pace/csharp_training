using System;
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
            ContactData contact = new ContactData("Ivan");
            contact.MiddleName = "Petrovich";
            contact.LastName = "Vetrov";

            ContactData newData = new ContactData("Pavel");
            newData.MiddleName = "Nikolaevich";
            newData.LastName = null;


            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.Create(contact);
            }
            app.Contacts.Modify(newData);
        }
    }
}
