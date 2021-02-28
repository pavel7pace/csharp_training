using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string firstName;
        private string middleName;
        private string lastName;

        public ContactData(string firstName, string middleName, string lastName)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }

        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }

        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }

        }
    }
}
