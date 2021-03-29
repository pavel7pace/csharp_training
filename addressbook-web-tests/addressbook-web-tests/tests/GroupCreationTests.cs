using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
       
        [Test]
        public void GroupCreationTest()
        {
            //GroupData group = new GroupData("New test Group", "New Header", "New Footer");
            GroupData group = new GroupData("New test Group");
            group.Header = "New Header";
            group.Footer = "New Footer";

            app.Groups.Create(group);
            //app.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            //GroupData group = new GroupData("", "", "");

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
            //app.Auth.Logout();
        }
    }
}
