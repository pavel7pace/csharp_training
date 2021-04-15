using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactsList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();

                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry")); ;
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> fields = element.FindElements(By.TagName("td"));
                    string lastname = fields[1].Text;
                    string firstname = fields[2].Text;
                    contactCache.Add(new ContactData(firstname, lastname));
                }
            }
            return contactCache;
        }

        public int GetContactsCount()
        {
            manager.Navigator.GoToHomePage();
            return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitContactCreation();
            FillContactInfo(contact);
            SubmitContactCreation();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper Modify(ContactData newData, int v)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(v);
            FillContactInfo(newData);
            SubmitContactModification();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            InitContactRemoval();
            ConfirmContactRemoval();
            return this;
        }

        private void ConfirmContactRemoval()
        {
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
        }

        private void InitContactRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillContactInfo(ContactData contact)
        {

            driver.FindElement(By.Name("firstname")).Click();
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public bool IsContactPresent()
        {
            manager.Navigator.GoToHomePage();
            return IsElementPresent(By.Name("entry"));
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            {
                manager.Navigator.GoToHomePage();
                IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                                                .FindElements(By.TagName("td"));
                string lastName = cells[1].Text;
                string firstName = cells[2].Text;
                string address = cells[3].Text;
                string allEmails = cells[4].Text;
                string allPhones = cells[5].Text;

                return new ContactData(firstName, lastName)
                {
                    Address = address,
                    AllEmails = allEmails,
                    AllPhones = allPhones
                };
            }
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string emailAdress = driver.FindElement(By.Name("email")).GetAttribute("value");
            string emailAdress2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string emailAdress3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                MiddleName = middleName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                EmailAddress = emailAdress,
                EmailAddress2 = emailAdress2,
                EmailAddress3 = emailAdress3

            };
        }
    }
}