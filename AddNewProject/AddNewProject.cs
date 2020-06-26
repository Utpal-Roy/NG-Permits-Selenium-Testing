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

namespace AddNewProject
{
    [TestClass]
    public class AddNewProjects
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        [TestMethod]
        [TestCategory("Chrome")]
        public void AddNewProject()
        {
            DataTable AddNewProjectData = new DataTable();
            AddNewProjectData = GetDataFromURL("AddNewProject");

            if (AddNewProjectData.Select("ID='skip-it'")[0]["Value"].ToString().ToLower() == "true")
            {
                Assert.Inconclusive("Skipped");
            }

            driver.Navigate().GoToUrl(appURL);

            //driver.FindElement(By.Id("txtUserId")).SendKeys("Admin");
            driver.FindElement(By.Id("txtUserId")).SendKeys(AddNewProjectData.Select("ID='txtUserId'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("txtUserPassword")).SendKeys("Arm714strong");
            driver.FindElement(By.Id("txtUserPassword")).SendKeys(AddNewProjectData.Select("ID='txtUserPassword'")[0]["Value"].ToString());

            driver.FindElement(By.Id("btnLogin")).Click();

            WaitForOverLay(10000);

            //driver.FindElement(By.LinkText("Add New Permit")).Click();
            //or
            string GoToURL = RedirectToPage("AddNewProject.aspx");
            driver.Navigate().GoToUrl(GoToURL);

            WaitForOverLay(20000);

            driver.FindElement(By.Id("ContentPlaceHolder1_ckhAutoNumber")).Click();

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtDescription")).SendKeys("This is a new project for running regression test.");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtDescription")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtDescription'")[0]["Value"].ToString());

            driver.FindElement(By.CssSelector(".col-lg-6:nth-child(1) .input-group-addon")).Click();

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtOpenDate")).SendKeys("05/18/2020");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtOpenDate")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtOpenDate'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtCloseDate")).SendKeys("07/22/2020");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtCloseDate")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtCloseDate'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtAddress1")).Click();
            //driver.FindElement(By.Id("ContentPlaceHolder1_txtAddress1")).SendKeys("test1");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtAddress1")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtAddress1'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtAddress2")).Click();
            //driver.FindElement(By.Id("ContentPlaceHolder1_txtAddress2")).SendKeys("test2");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtAddress2")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtAddress2'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_ddlCity")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ContentPlaceHolder1_ddlCity"));
                //dropdown.FindElement(By.XPath("//option[. = 'MIAMI']")).Click();
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewProjectData.Select("ID='ContentPlaceHolder1_ddlCity'")[0]["Value"].ToString() + "']")).Click();
            }

            driver.FindElement(By.Id("ContentPlaceHolder1_ddlCity")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_ddlState")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ContentPlaceHolder1_ddlState"));
                //dropdown.FindElement(By.XPath("//option[. = 'LA']")).Click();
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewProjectData.Select("ID='ContentPlaceHolder1_ddlState'")[0]["Value"].ToString() + "']")).Click();
            }

            driver.FindElement(By.Id("ContentPlaceHolder1_ddlState")).Click();

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtZip")).SendKeys("22222");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtZip")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtZip'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtPhone")).SendKeys("(444) 444-4444");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtPhone")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtPhone'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtSurvey")).SendKeys("added survey");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtSurvey")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtSurvey'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtLot")).SendKeys("added lot");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtLot")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtLot'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtBlock")).SendKeys("34555");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtBlock")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtBlock'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtGroup")).SendKeys("added group");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtGroup")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtGroup'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtControlMap")).SendKeys("added control map");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtControlMap")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtControlMap'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtGeoCode")).SendKeys("11345");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtGeoCode")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtGeoCode'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtSpecialInterest")).SendKeys("123455");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtSpecialInterest")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtSpecialInterest'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtOwnerName")).SendKeys("test owner");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtOwnerName")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtOwnerName'")[0]["Value"].ToString());

            //driver.FindElement(By.CssSelector("fieldset:nth-child(3) > .col-lg-12:nth-child(2)")).Click();

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtOwnerAddress1")).SendKeys("address 1st line");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtOwnerAddress1")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtOwnerAddress1'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtOwnerAddress2")).SendKeys("address 2nd line");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtOwnerAddress2")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtOwnerAddress2'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_ddlOwnerCity")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ContentPlaceHolder1_ddlOwnerCity"));
                //dropdown.FindElement(By.XPath("//option[. = 'NEW ORLEANS']")).Click();
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewProjectData.Select("ID='ContentPlaceHolder1_ddlOwnerCity'")[0]["Value"].ToString() + "']")).Click();
            }

            driver.FindElement(By.Id("ContentPlaceHolder1_ddlOwnerCity")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_ddlOwnerState")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ContentPlaceHolder1_ddlOwnerState"));
                //dropdown.FindElement(By.XPath("//option[. = 'LA']")).Click();
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewProjectData.Select("ID='ContentPlaceHolder1_ddlOwnerState'")[0]["Value"].ToString() + "']")).Click();
            }

            driver.FindElement(By.Id("ContentPlaceHolder1_ddlOwnerState")).Click();

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtOwnerZip")).SendKeys("11111");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtOwnerZip")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtOwnerZip'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtOwnerPhone")).SendKeys("(999) 999-9999");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtOwnerPhone")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtOwnerPhone'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_txtNotes")).SendKeys("add this project and see how it works");
            driver.FindElement(By.Id("ContentPlaceHolder1_txtNotes")).SendKeys(AddNewProjectData.Select("ID='ContentPlaceHolder1_txtNotes'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_Attachment_Tab")).Click();

            //WaitForOverLay(5000);

            //driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl00_AddNewRecordButton']")).Click();

            //WaitForOverLay(10000);

            //driver.FindElement(By.Id("txtDescriptionI")).SendKeys(AddNewProjectData.Select("ID='txtDescriptionI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_RadProjectAttachmentIfile0")).SendKeys(AddNewProjectData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_RadProjectAttachmentIfile0'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            //WaitForOverLay(10000);

            //driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl00_AddNewRecordButton']")).Click();

            //WaitForOverLay(10000);

            //driver.FindElement(By.Id("txtDescriptionI")).SendKeys(AddNewProjectData.Select("ID='txtDescriptionI'")[1]["Value"].ToString());

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_RadProjectAttachmentIfile0")).SendKeys(AddNewProjectData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_RadProjectAttachmentIfile0'")[1]["Value"].ToString());

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ContentPlaceHolder1_btnSave")).Click();

            WaitForOverLay(10000);

            // 43 | click | css=.swal-button | 
            //driver.FindElement(By.CssSelector(".swal-button")).Click();

            string expectedval = "Project saved successfully";
            string actualval = string.Empty;
            if (driver.FindElement(By.ClassName("swal-text")).GetAttribute("innerHTML").ToLower() == "values saved successfully!")
            {
                driver.FindElement(By.XPath("//div[@class='swal-button-container']/button[.='OK']")).Click();
                actualval = "Project saved successfully";
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
