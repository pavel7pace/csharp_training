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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret")); ;
            app.ContactHelper.InitContactCreation();
            app.ContactHelper.FillContactInfo(new ContactData ("Ivan", "Ivanovich", "Ivanov"));
            app.ContactHelper.SubmitContactCreation();
            app.ContactHelper.ReturnToContactsPage();
            app.Auth.Logout();
        }       
    }
}

