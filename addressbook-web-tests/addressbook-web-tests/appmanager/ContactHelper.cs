﻿using System;
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

        public ContactHelper(IWebDriver driver)
            : base(driver)
        {
        }

        public void SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        public void FillContactInfo(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
        }

        public void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}
