using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("New test Group");
            group.Header = "New Header";
            group.Footer = "New Footer";

            GroupData newData = new GroupData("Modified test Group");
            newData.Header = "Modified Header";
            newData.Footer = "Modified Footer";


            if (app.Groups.IsGroupPresent())
            {
                app.Groups.Modify(1, newData);
            }
            else
            {
                app.Groups.Create(group);
                app.Groups.Modify(1, newData);
            }

        }
    }
}
