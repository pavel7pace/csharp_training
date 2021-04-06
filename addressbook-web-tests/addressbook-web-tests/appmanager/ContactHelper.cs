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
    }
}