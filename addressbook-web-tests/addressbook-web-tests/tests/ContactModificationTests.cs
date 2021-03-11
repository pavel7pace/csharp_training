using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class ContactModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            ContactData newData = new ContactData("Nikita");
            newData.MiddleName = "Nikolaevich";
            newData.LastName = "Nikiforov";

            app.Contacts.Modify(1, newData);
        }
    }
}
