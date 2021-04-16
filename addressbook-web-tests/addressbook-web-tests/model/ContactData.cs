using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        private string allEmails;

        private string allInfoFromEditForm;

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddress2 { get; set; }
        public string EmailAddress3 { get; set; }
        public string Homepage { get; set; }


        public ContactData(string firstName)
        {
            FirstName = firstName;
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ContactData(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString()
        {
            return ("firstname=" + FirstName) + ("lastname=" + LastName);
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (FirstName.CompareTo(other.FirstName) == 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            return FirstName.CompareTo(other.FirstName);
        }    

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(EmailAddress) + CleanUp(EmailAddress2) + CleanUp(EmailAddress3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        
        public string AllInfoFromEditForm
        {
            get
            {
                if (allInfoFromEditForm != null)
                {
                    return allInfoFromEditForm;
                }
                else
                {
                    return CleanUpAllInfo(FirstName) + CleanUpAllInfo(MiddleName) + CleanUpAllInfo(LastName) + CleanUpAllInfo(Nickname) + CleanUpAllInfo(Title) + CleanUpAllInfo(Company)
                        + CleanUpAllInfo(Address) + CleanUpAllInfo(HomePhone) + CleanUpAllInfo(MobilePhone)
                        + CleanUpAllInfo(WorkPhone) + CleanUpAllInfo(Fax) + CleanUpAllInfo(EmailAddress) + CleanUpAllInfo(EmailAddress2) + CleanUpAllInfo(EmailAddress3) + CleanUpAllInfo(Homepage);
                }
            }
            set
            {
                allInfoFromEditForm = value;
            }
        }

        public string CleanUp(string contactData)
        {
                if (contactData == null || contactData == "")
                {
                    return "";
                }
            //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            return Regex.Replace(contactData, "[ -()]", "") + "\r\n";

        }

        public string CleanUpAllInfo(string AllContactData)
        {
            if (AllContactData == null || AllContactData == "")
            {
                return "";
            }
            //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            return AllContactData.Replace(" ", "").Replace("H: ", "").Replace("M: ", "").Replace("W: ", "").Replace("F: ", "").Replace("Homepage: ", "").Replace("\r\n", "");

        }

    }
}
