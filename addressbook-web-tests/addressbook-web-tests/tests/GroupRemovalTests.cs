using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("New test Group");
            group.Header = "New Header";
            group.Footer = "New Footer";

            if (!app.Groups.IsGroupPresent())
            {
                app.Groups.Create(group);
            }                
            app.Groups.Remove(1);
        }
    }
}
