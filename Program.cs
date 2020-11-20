using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            int member;

            Console.WriteLine("Ввыберите пользователя\n1: Андрей\n2: Кристина\n");
            member = Convert.ToInt32(Console.ReadLine());

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://lk.sut.ru/cabinet/?login=yes";

            switch (member) {
                case 1: 
                    driver.FindElement(By.Name("users")).SendKeys("gnataly2106@mail.ru");
                    driver.FindElement(By.Name("parole")).SendKeys("Andrey2002");
                    break;
                case 2:
                    driver.FindElement(By.Name("users")).SendKeys("lyagiceva@mail.ru");
                    driver.FindElement(By.Name("parole")).SendKeys("Kirik5218");
                    break;
                default:
                    Console.WriteLine("Пользователь не найден");
                    driver.Quit();
                    break;
            }

            driver.FindElement(By.Name("logButton")).Click();

            Thread.Sleep(1000);

            driver.FindElement(By.ClassName("lm_item")).Click();

            Thread.Sleep(1000);

            driver.FindElement(By.Id("menu_li_6118")).Click();
            Thread.Sleep(1000);
            try
            {
                driver.FindElement(By.LinkText("Начать занятие")).Click();
            }
            catch(Exception)
            {
                Console.WriteLine("\n\nПару не начали или кнопка не обнаружена\n\n");
                driver.Close();
                Console.ReadKey();
            }
            driver.Quit();
        }
    }
}
