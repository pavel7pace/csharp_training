using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : TestBase
    {
       
        [Test]
        public void ContactCreationTests()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret")); ;
            InitContactCreation();
            FillContactInfo(new ContactData ("Ivan", "Ivanovich", "Ivanov"));
            SubmitContactCreation();
            ReturnToContactsPage();
        }       
    }
}

