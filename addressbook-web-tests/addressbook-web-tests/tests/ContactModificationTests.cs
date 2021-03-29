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
        public void GroupModificationTest()
        {
            ContactData newData = new ContactData("Pavel");
            newData.MiddleName = "Nikolaevich";
            newData.LastName = null;

            app.Contacts.Modify(newData);
        }
    }
}
