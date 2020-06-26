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

namespace AddNewContractor
{
    [TestClass]
    public class AddNewContractors
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        [TestMethod]
        [TestCategory("Chrome")]
        public void AddNewContractor()
        {
            DataTable AddContractorData = new DataTable();
            AddContractorData = GetDataFromURL("AddNewContractor");

            if (AddContractorData.Select("ID='skip-it'")[0]["Value"].ToString().ToLower() == "true")
            {
                Assert.Inconclusive("Skipped");
            }

            driver.Navigate().GoToUrl(appURL);

            //driver.FindElement(By.Id("txtUserId")).SendKeys("Admin");
            driver.FindElement(By.Id("txtUserId")).SendKeys(AddContractorData.Select("ID='txtUserId'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("txtUserPassword")).SendKeys("Arm714strong");
            driver.FindElement(By.Id("txtUserPassword")).SendKeys(AddContractorData.Select("ID='txtUserPassword'")[0]["Value"].ToString());

            driver.FindElement(By.Id("btnLogin")).Click();

            WaitForOverLay(10000);

            string GoToURL = RedirectToPage("AddNewContractor.aspx"); 
            driver.Navigate().GoToUrl(GoToURL);

            WaitForOverLay(20000);

            if (AddContractorData.Select("ID='ContentPlaceHolder1_chkAutotxtContractorID'")[0]["Value"].ToString().ToLower() == "true")
            {
                driver.FindElement(By.Id("ContentPlaceHolder1_chkAutotxtContractorID")).Click();
            }

            driver.FindElement(By.Id("ContentPlaceHolder1_txtName")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtName'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtDBA")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtDBA'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtAttention")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtAttention'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtAddress1")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtAddress1'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtAddress2")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtAddress2'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadComboBoxCity_Input")).SendKeys(AddContractorData.Select("ID='ctl00_ContentPlaceHolder1_RadComboBoxCity_Input'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtAddress2")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_ddlState")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ContentPlaceHolder1_ddlState"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddContractorData.Select("ID='ContentPlaceHolder1_ddlState'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ContentPlaceHolder1_ddlState")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtZip")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtZip'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtPhone")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtPhone'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtExt")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtExt'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtFax")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtFax'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtMobile")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtMobile'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtMessages")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtMessages'")[0]["Value"].ToString());

            //Add officer
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridOfficer_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("txtNameI")).SendKeys(AddContractorData.Select("ID='txtNameI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtBusinessNameI")).SendKeys(AddContractorData.Select("ID='txtBusinessNameI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtTitleI")).SendKeys(AddContractorData.Select("ID='txtTitleI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridOfficer_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridOfficer_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("txtNameI")).SendKeys(AddContractorData.Select("ID='txtNameI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtBusinessNameI")).SendKeys(AddContractorData.Select("ID='txtBusinessNameI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtTitleI")).SendKeys(AddContractorData.Select("ID='txtTitleI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridOfficer_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ContentPlaceHolder1_References_Tab")).Click();

            WaitForOverLay(5000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridLicenses_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridLicenses_ctl00_ctl02_ctl03_ddlCodeI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridLicenses_ctl00_ctl02_ctl03_ddlCodeI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddContractorData.Select("ID='ctl00_ContentPlaceHolder1_RadGridLicenses_ctl00_ctl02_ctl03_ddlCodeI'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridLicenses_ctl00_ctl02_ctl03_ddlCodeI")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("txtStartDateI")).SendKeys(AddContractorData.Select("ID='txtStartDateI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtStopDateI")).SendKeys(AddContractorData.Select("ID='txtStopDateI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtInsuredUntilDateI")).SendKeys(AddContractorData.Select("ID='txtInsuredUntilDateI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridLicenses_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ContentPlaceHolder1_txtClassification")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtClassification'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtLimit")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtLimit")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtLimit'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtLocalReference")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtLocalReference")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtLocalReference'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtExpirationDate_LocalReference")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtExpirationDate_LocalReference'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtStateReference")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtStateReference")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtStateReference'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtExpirationDate_StateReference")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtExpirationDate_StateReference'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtBondReference")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtBondReference")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtBondReference'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtExpirationDate_BondReference")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtExpirationDate_BondReference'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtWorkmansComp")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtWorkmansComp'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtExpirationDate_WorkmansComp")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtExpirationDate_WorkmansComp'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_Transactions_Tab")).Click();

            WaitForOverLay(5000);

            driver.FindElement(By.Id("ContentPlaceHolder1_Actions_Tab")).Click();

            WaitForOverLay(5000);

            driver.FindElement(By.Id("ContentPlaceHolder1_txtNotes")).SendKeys(AddContractorData.Select("ID='ContentPlaceHolder1_txtNotes'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ddlDescriptionI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlDescriptionI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddContractorData.Select("ID='ddlDescriptionI'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlDescriptionI")).Click();

            driver.FindElement(By.Id("txtValueI")).SendKeys(AddContractorData.Select("ID='txtValueI'")[0]["Value"].ToString());


            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ddlDescriptionI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlDescriptionI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddContractorData.Select("ID='ddlDescriptionI'")[1]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlDescriptionI")).Click();

            driver.FindElement(By.Id("txtValueI")).SendKeys(AddContractorData.Select("ID='txtValueI'")[1]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridCategories_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ddlDescriptionI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlDescriptionI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddContractorData.Select("ID='RadGridCategories_ddlDescriptionI'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlDescriptionI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridCategories_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridCategories_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ddlDescriptionI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlDescriptionI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddContractorData.Select("ID='RadGridCategories_ddlDescriptionI'")[1]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlDescriptionI")).Click();


            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridCategories_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            //driver.FindElement(By.Id("ContentPlaceHolder1_btnSave_Top")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ContentPlaceHolder1_btnSave")).Click();

            WaitForOverLay(10000);

            string expectedval = "Contractor saved successfully";
            string actualval = string.Empty;
            if (driver.FindElement(By.ClassName("swal-text")).GetAttribute("innerHTML").ToLower() == "values saved successfully!")
            {
                driver.FindElement(By.XPath("//div[@class='swal-button-container']/button[.='OK']")).Click();
                actualval = "Contractor saved successfully";
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
