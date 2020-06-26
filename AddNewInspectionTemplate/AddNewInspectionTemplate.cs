using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.IO;
using ExcelDataReader;
using System.Reflection;
using OpenQA.Selenium.Interactions;

namespace AddNewInspectionTemplate
{
    [TestClass]
    public class AddNewInspectionTemplates
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        [TestMethod]
        [TestCategory("Chrome")]
        public void AddNewInspectionTemplate()
        {
            DataTable AddNewInspectionTemplateData = new DataTable();
            AddNewInspectionTemplateData = GetDataFromURL("AddNewInspectionTemplate");

            if (AddNewInspectionTemplateData.Select("ID='skip-it'")[0]["Value"].ToString().ToLower() == "true")
            {
                Assert.Inconclusive("Skipped");
            }

            driver.Navigate().GoToUrl(appURL);

            WaitForOverLay(10000);

            //driver.FindElement(By.Id("txtUserId")).SendKeys("Admin");
            driver.FindElement(By.Id("txtUserId")).SendKeys(AddNewInspectionTemplateData.Select("ID='txtUserId'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("txtUserPassword")).SendKeys("Arm714strong");
            driver.FindElement(By.Id("txtUserPassword")).SendKeys(AddNewInspectionTemplateData.Select("ID='txtUserPassword'")[0]["Value"].ToString());

            driver.FindElement(By.Id("btnLogin")).Click();

            WaitForOverLay(10000);

            string GoToURL = RedirectToPage("InspectorInspectionsDetails.aspx");
            driver.Navigate().GoToUrl(GoToURL);

            WaitForOverLay(20000);

            driver.FindElement(By.CssSelector("#ContentPlaceHolder1_divmyModalInspectionType > .btn")).Click();

            WaitForOverLay(10000);

            ClickLinkByHref("javascript:SelectInspectionName('" + AddNewInspectionTemplateData.Select("ID='SelectInspectionName'")[0]["Value"].ToString() + "')");

            if (driver.FindElement(By.Id("myModalInspectionType")).GetAttribute("style") != "display: none;")
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                IWebElement element = driver.FindElement(By.Id("myModalInspectionType"));
                js.ExecuteScript("arguments[0].setAttribute('style', 'display: none;')", element);
            }

            if (driver.FindElement(By.CssSelector("body > div.modal-backdrop.fade.in")) != null)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                IWebElement element = driver.FindElement(By.CssSelector("body > div.modal-backdrop.fade.in"));
                js.ExecuteScript("arguments[0].setAttribute('class', 'modal - backdrop fade')", element);
            }

            driver.FindElement(By.CssSelector("#ContentPlaceHolder1_divmyModalPermitCode > .btn")).Click();

            WaitForOverLay(10000);

            ClickLinkByHref("javascript:SelectPermitCode('" + AddNewInspectionTemplateData.Select("ID='SelectPermitCode'")[0]["Value"].ToString() + "')");

            if (driver.FindElement(By.Id("myModalPermitCode")).GetAttribute("style") != "display: none;")
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                IWebElement element = driver.FindElement(By.Id("myModalPermitCode"));
                js.ExecuteScript("arguments[0].setAttribute('style', 'display: none;')", element);
            }
            if (driver.FindElement(By.CssSelector("body > div.modal-backdrop.fade.in")) != null)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                IWebElement element = driver.FindElement(By.CssSelector("body > div.modal-backdrop.fade.in"));
                js.ExecuteScript("arguments[0].setAttribute('class', 'modal - backdrop fade')", element);
            }

            WaitForOverLay(10000);

            if (AddNewInspectionTemplateData.Select("ID='Inspection Item check'")[0]["Value"].ToString() == "true")
            {
                driver.FindElement(By.Id("check1")).Click();
            }

            driver.FindElement(By.Id("field1")).SendKeys(AddNewInspectionTemplateData.Select("ID='Inspection Item text'")[0]["Value"].ToString());

            driver.FindElement(By.LinkText("Add New Inspection Item Line")).Click();

            if (AddNewInspectionTemplateData.Select("ID='Inspection Item check'")[0]["Value"].ToString() == "true")
            {
                driver.FindElement(By.Id("check3")).Click();
            }
            driver.FindElement(By.Id("field3")).Click();

            driver.FindElement(By.Id("field3")).SendKeys(AddNewInspectionTemplateData.Select("ID='Inspection Item text'")[0]["Value"].ToString());

            driver.FindElement(By.Id("btn2")).Click();

            ClickLinkByHref("javascript:SelectCommentCode('" + AddNewInspectionTemplateData.Select("ID='SelectCommentCode'")[0]["Value"].ToString() + "', '" + AddNewInspectionTemplateData.Select("ID='SelectCommentCode text'")[0]["Value"].ToString() + "')");

            if (driver.FindElement(By.Id("myModal")).GetAttribute("style") != "display: none;")
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                IWebElement element = driver.FindElement(By.Id("myModal"));
                js.ExecuteScript("arguments[0].setAttribute('style', 'display: none;')", element);
            }
            if (driver.FindElement(By.CssSelector("body > div.modal-backdrop.fade.in")) != null)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                IWebElement element = driver.FindElement(By.CssSelector("body > div.modal-backdrop.fade.in"));
                js.ExecuteScript("arguments[0].setAttribute('class', 'modal - backdrop fade')", element);
            }

            driver.FindElement(By.LinkText("Add New Comment Code Setup")).Click();

            driver.FindElement(By.Id("btn4")).Click();

            ClickLinkByHref("javascript:SelectCommentCode('" + AddNewInspectionTemplateData.Select("ID='SelectCommentCode'")[0]["Value"].ToString() + "', '" + AddNewInspectionTemplateData.Select("ID='SelectCommentCode text'")[0]["Value"].ToString() + "')");

            if (driver.FindElement(By.Id("myModal")).GetAttribute("style") != "display: none;")
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                IWebElement element = driver.FindElement(By.Id("myModal"));
                js.ExecuteScript("arguments[0].setAttribute('style', 'display: none;')", element);
            }
            //if (driver.FindElement(By.CssSelector("body > div.modal-backdrop.fade.in")) != null)
            //{
            //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //    IWebElement element = driver.FindElement(By.CssSelector("body > div.modal-backdrop.fade.in"));
            //    js.ExecuteScript("arguments[0].setAttribute('class', 'modal - backdrop fade')", element);
            //}

            driver.FindElement(By.Id("ContentPlaceHolder1_btnSAVE")).Click();

            WaitForOverLay(10000);

            string expectedval = "Inspection Template saved successfully";
            string actualval = string.Empty;
            //Can not Insert Duplicate Template!
            if (driver.FindElement(By.ClassName("swal-text")).GetAttribute("innerHTML").ToLower() == "values saved successfully!")
            {
                driver.FindElement(By.XPath("//div[@class='swal-button-container']/button[.='OK']")).Click();
                actualval = "Inspection Template saved successfully";
            }

            Assert.AreEqual(expectedval, actualval);

        }
        public string RedirectToPage(string PageName)
        {
            string retval = string.Empty;
            string curURL = driver.Url.ToLower();
            int a = curURL.IndexOf("home.aspx");
            string b = curURL.Substring(a).ToLower();

            string GoToURL = curURL.Replace(b, PageName.ToString());
            retval = GoToURL;
            return retval;

        }
        public void ClickLinkByHref(String href)
        {
            //List<IWebElement> anchors = driver.FindElements(By.TagName("a"));

            foreach (IWebElement IElement in driver.FindElements(By.TagName("a")))
            {
                if (IElement.GetAttribute("href") != null)
                {
                    if (IElement.GetAttribute("href").Contains(href))
                    {
                        IElement.Click();
                        break;
                    }
                }
            }
        }

        public int WaitForOverLay(int DelayInMiliSeconds)
        {
            int retval = 0;
            Thread.Sleep(DelayInMiliSeconds);
            if (driver.FindElements(By.Id("ContentPlaceHolder1_prgLoadingStatus")).Count > 0)
            {
                if (driver.FindElement(By.Id("ContentPlaceHolder1_prgLoadingStatus")).GetAttribute("style") == "display: block;")
                {
                    WaitForOverLay(DelayInMiliSeconds);
                }
            }
            return retval;
        }

        public int WaitForPopUpToBeRemoved(string ModalPopUpID)
        {
            int retval = 0;
            Thread.Sleep(5000);
            if (driver.FindElement(By.Id(ModalPopUpID)).GetAttribute("style") == "display: block;")
            {
                WaitForPopUpToBeRemoved(ModalPopUpID);
            }

            return retval;
        }

        public int FindMeLooped(string elementid)
        {
            int retval = 0;
            Thread.Sleep(5000);

            var foundElement = driver.FindElements(By.Id(elementid));

            if (foundElement.Count > 0)
            {
                retval = foundElement.Count;
            }
            else
            {
                FindMeLooped(elementid);
            }

            return retval;
        }

        public DataTable GetDataFromURL(string PageName)
        {
            DataTable retData = new DataTable();
            string curPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            String strURL = String.Empty;
            strURL = "https://lgcclouddev.localgovcorp.com/SeleniumScriptData/SeleniumPageData.xlsx";
            WebClient wc = new WebClient();
            wc.DownloadFile(strURL, curPath + "\\SeleniumPageData.xlsx");

            //Open file and returns as Stream
            using (FileStream stream = File.Open(curPath + "\\SeleniumPageData.xlsx", FileMode.Open, FileAccess.Read))
            {
                //Createopenxmlreader via ExcelReaderFactory
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                //DataSet result = excelReader.AsDataSet
                //Return as DataSet and Set the First Row as Column Name
                DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                //Get all the Tables
                DataTableCollection table = result.Tables;

                //Store it in DataTable
                retData = table[PageName];

            }

            if (File.Exists(curPath + "\\SeleniumPageData.xlsx"))
            {
                File.Delete(curPath + "\\SeleniumPageData.xlsx");
            }

            return retData;
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            //appURL = "http://www.bing.com/";
            appURL = "https://lgcclouddev.localgovcorp.com/ngpermits/Login.aspx";
            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AcceptInsecureCertificates = true;
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

    }
}
