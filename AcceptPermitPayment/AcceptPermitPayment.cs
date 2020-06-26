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

namespace AcceptPermitPayment
{
    [TestClass]
    public class AcceptPermitPayments
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        [TestMethod]
        [TestCategory("Chrome")]
        public void AcceptPermitPayment()
        {
            DataTable AcceptPermitPaymentData = new DataTable();
            AcceptPermitPaymentData = GetDataFromURL("AcceptPermitPayment");

            driver.Navigate().GoToUrl(appURL);

            driver.FindElement(By.Id("txtUserId")).SendKeys(AcceptPermitPaymentData.Select("ID='txtUserId'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtUserPassword")).SendKeys(AcceptPermitPaymentData.Select("ID='txtUserPassword'")[0]["Value"].ToString());

            driver.FindElement(By.Id("btnLogin")).Click();

            WaitForOverLay(10000);

            string GoToURL = RedirectToPage("AcceptPermitPayment.aspx");
            driver.Navigate().GoToUrl(GoToURL);


            WaitForOverLay(20000);

            ////////////////////////////////////////////////////////////////

            driver.FindElement(By.Id("RadComboBoxSessionID_Input")).Click();

            WaitForOverLay(10000);

            String searchText = AcceptPermitPaymentData.Select("ID='RadComboBoxSessionID_Input'")[0]["Value"].ToString();
            IWebElement SessionIDdropdown = driver.FindElement(By.Id("RadComboBoxSessionID_DropDown"));

            WaitForOverLay(5000);

            foreach (IWebElement option in SessionIDdropdown.FindElements(By.ClassName("rcbItem")))
            {
                if (option.TagName == "li")
                {
                    if (option.Text.Equals(searchText))
                    {
                        option.Click(); // click the desired option
                        break;
                    }
                }
            }

            WaitForOverLay(5000);

            //driver.FindElement(By.Id("PermitNumberPopup")).Click();

            foreach (IWebElement PermitNumberPopupAnchor in driver.FindElements(By.Id("PermitNumberPopup")))
            {
                if (PermitNumberPopupAnchor.TagName == "a")
                {
                    PermitNumberPopupAnchor.Click();
                }
            }

            WaitForOverLay(20000);

            driver.FindElement(By.XPath("//tr[contains(@id,'PaymentPermitNumberPopup_RadGridPermitNumberLookup_ctl00__7')]")).Click();
            driver.FindElement(By.XPath("//input[contains(@id,'btnPermitNumberLookupOk')]")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("txtRemittedAmount")).SendKeys(AcceptPermitPaymentData.Select("ID='txtRemittedAmount'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_ddlPaymentTypeI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_ddlPaymentTypeI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AcceptPermitPaymentData.Select("ID='ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_ddlPaymentTypeI'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_ddlPaymentTypeI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_txtReferenceI")).SendKeys(AcceptPermitPaymentData.Select("ID='ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_txtReferenceI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_txtAmountI")).SendKeys(AcceptPermitPaymentData.Select("ID='ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_txtAmountI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_PerformInsertButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_ddlPaymentTypeI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_ddlPaymentTypeI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AcceptPermitPaymentData.Select("ID='ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_ddlPaymentTypeI'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_ddlPaymentTypeI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_txtReferenceI")).SendKeys(AcceptPermitPaymentData.Select("ID='ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_txtReferenceI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_txtAmountI")).SendKeys(AcceptPermitPaymentData.Select("ID='ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_txtAmountI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPayment_ctl00_ctl02_ctl02_PerformInsertButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("btnAccept")).Click();

            WaitForOverLay(15000);

            string actualval = string.Empty;

            if (driver.FindElement(By.CssSelector(".swal-button--confirm")) != null && driver.FindElement(By.Id("ContentPlaceHolder1_btnPrint")).Displayed == false)
            {
                driver.FindElement(By.CssSelector(".swal-button--confirm")).Click();
                WaitForOverLay(10000);
            }

            if (driver.FindElement(By.CssSelector(".swal-button--confirm")) != null && driver.FindElement(By.Id("ContentPlaceHolder1_btnPrint")).Displayed == false)
            {
                driver.FindElement(By.CssSelector(".swal-button--confirm")).Click();
                WaitForOverLay(10000);
            }

            if (driver.FindElement(By.CssSelector(".swal-button--confirm")) != null && driver.FindElement(By.Id("ContentPlaceHolder1_btnPrint")).Displayed == false)
            {
                driver.FindElement(By.CssSelector(".swal-button--confirm")).Click();
                WaitForOverLay(10000);
            }

            if (driver.FindElement(By.CssSelector(".swal-button--confirm")) != null && driver.FindElement(By.Id("ContentPlaceHolder1_btnPrint")).Displayed == false)
            {
                driver.FindElement(By.CssSelector(".swal-button--confirm")).Click();
                WaitForOverLay(10000);
            }

            if (driver.FindElement(By.Id("ContentPlaceHolder1_btnPrint")) != null && driver.FindElement(By.Id("ContentPlaceHolder1_btnPrint")).Displayed == true)
            {
                driver.FindElement(By.Id("ContentPlaceHolder1_btnPrint")).Click();
                actualval = "Saved successfully";
                WaitForOverLay(10000);
            }

            ///////////////////////////////////////////////////////////////

            string expectedval = "Saved successfully";

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

        public int FindMeLoopedByCSS(string elementCSS)
        {
            int retval = 0;
            Thread.Sleep(5000);

            var foundElement = driver.FindElements(By.CssSelector(elementCSS));

            if (foundElement.Count > 0)
            {
                retval = foundElement.Count;
            }
            else
            {
                FindMeLoopedByCSS(elementCSS);
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
