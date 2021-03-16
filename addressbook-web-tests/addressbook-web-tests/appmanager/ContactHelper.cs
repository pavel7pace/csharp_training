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

        public ContactHelper Create(ContactData contact)
        {
         InitContactCreation();
         FillContactInfo(contact);
         SubmitContactCreation();
         ReturnToContactsPage();
         return this;
        }

        public ContactHelper Modify(ContactData newData)
        {
                InitContactModification();
                FillContactInfo(newData);
                SubmitContactModification();
                ReturnToContactsPage();
                return this;
        }

        public ContactHelper Remove()
        {
            SelectContact(1);
            InitContactRemoval();
            ConfirmGroupRemoval();
            return this;
        }

        private void ConfirmGroupRemoval()
        {
            driver.SwitchTo().Alert().Accept();
        }

        private void InitContactRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
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

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }
    }
}
