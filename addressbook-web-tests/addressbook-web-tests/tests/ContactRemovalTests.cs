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
            app.Contacts.Remove();                      
        }
    }
}
