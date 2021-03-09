using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.GroupHelper.InitGroupCreation();
            app.GroupHelper.FillGroupForm(new GroupData("New test Group777", "Dummy group header", "Dummy group footer"));
            app.GroupHelper.SubmitGroupCreation();
            app.GroupHelper.ReturnToGroupsPage();
            app.Auth.Logout();
        }          
    }
}
