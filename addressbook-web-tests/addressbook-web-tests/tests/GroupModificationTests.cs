using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Modified test Group");
            newData.Header = "Modified Header";
            newData.Footer = "Modified Footer";

            app.Groups.Modify(1, newData);
        }

    }
}
