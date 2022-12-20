using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace whatsapp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://web.whatsapp.com/");
            
            // scan the QR code
            Console.WriteLine("Please scan the QR code to log in to WhatsApp");
            Console.WriteLine("Press enter when you have logged in");
            Console.ReadLine();
            
            // enter name of contact
            Console.WriteLine("Enter the name of the contact you want to send a message to:");
            var contactName = Console.ReadLine();
            
            // find the search bar and search for the contact
            var searchBar = driver.FindElement(By.XPath("//*[@id='side']/div[1]/div/div/div[2]/div/div[2])"));
            searchBar.SendKeys(contactName);
                
            // wait for the contact to appear
            System.Threading.Thread.Sleep(2000);
            
            // find contact in the search results and click on it
            var contact = driver.FindElement(By.XPath("//*[@id='pane-side']/div[1]/div/div/div[10]/div/div/div/div[2]"));
            // not sure if XPath is correct
                contact.Click();
                
            // wait for chat screen to load
            System.Threading.Thread.Sleep(2000);
            
            // enter message
            Console.WriteLine("Enter the message you want to send:");
            var message = Console.ReadLine();
            
            // find message bar and enter message
            var messageBar = driver.FindElement(By.XPath("//*[@id='main]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]/p "));
                messageBar.Click();
            messageBar.SendKeys(message);
            
            // find send button and send
            var sendButton = driver.FindElement(By.XPath("//*[@id='main]/footer/div[1]/div/span[2]/div/div[2]/div[2]/button/span"));
                sendButton.Click();

            // close program
            Environment.Exit(0);
        }
    }
}

