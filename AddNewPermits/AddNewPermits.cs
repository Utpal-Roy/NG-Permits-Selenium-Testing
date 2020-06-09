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

namespace AddNewPermits
{
    [TestClass]
    public class AddNewPermit
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        [TestMethod]
        [TestCategory("Chrome")]
        public void AddNewPermits()
        {
            DataTable AddNewPermitsData = new DataTable();
            AddNewPermitsData = GetDataFromURL("AddNewPermits");

            driver.Navigate().GoToUrl(appURL);

            //driver.FindElement(By.Id("txtUserId")).SendKeys("Admin");
            driver.FindElement(By.Id("txtUserId")).SendKeys(AddNewPermitsData.Select("ID='txtUserId'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("txtUserPassword")).SendKeys("Arm714strong");
            driver.FindElement(By.Id("txtUserPassword")).SendKeys(AddNewPermitsData.Select("ID='txtUserPassword'")[0]["Value"].ToString());

            driver.FindElement(By.Id("btnLogin")).Click();

            WaitForOverLay(10000);

            string curURL = driver.Url;
            string GoToURL = curURL.Replace(curURL.Split('/')[5].ToString(), "AddNewPermits.aspx");
            driver.Navigate().GoToUrl(GoToURL);

            WaitForOverLay(20000);
            ////////////////////////////////////////////////////////////////

            // 10 | click | id=ProductLookup | 
            IWebElement ProductLookupwebElement = driver.FindElement(By.Id("ProductLookup"));
            IJavaScriptExecutor ProductLookupexecutor = (IJavaScriptExecutor)driver;
            ProductLookupexecutor.ExecuteScript("arguments[0].click();", ProductLookupwebElement);

            Thread.Sleep(10000);

            driver.FindElement(By.XPath("//tr[contains(@id,'ProjectLookupPopup_RadGridProjectLookup_ctl00__2')]")).Click();
            driver.FindElement(By.XPath("//input[contains(@id,'btnProjectLookupOk')]")).Click();

            Thread.Sleep(20000);

            FindMeLoopedByCSS(".swal-button--confirm");

            driver.FindElement(By.CssSelector(".swal-button--confirm")).Click();

            WaitForOverLay(10000);

            IWebElement PermitCodeLookupwebElement = driver.FindElement(By.Id("PermitCodeLookup"));
            IJavaScriptExecutor PermitCodeLookupexecutor = (IJavaScriptExecutor)driver;
            PermitCodeLookupexecutor.ExecuteScript("arguments[0].click();", PermitCodeLookupwebElement);

            Thread.Sleep(10000);

            driver.FindElement(By.XPath("//tr[contains(@id,'PermitCodeLookupPopup_RadGridPermitCodeLookup_ctl00__6')]")).Click();
            driver.FindElement(By.XPath("//input[contains(@id,'btnPermitCodeLookupOk')]")).Click();

            WaitForOverLay(50000);

            FindMeLooped("txtJobCost");

            driver.FindElement(By.Id("txtJobCost")).SendKeys(AddNewPermitsData.Select("ID='txtJobCost'")[0]["Value"].ToString());

            IWebElement OccupencyLookupwebElement = driver.FindElement(By.Id("OccupencyLookup"));
            IJavaScriptExecutor OccupencyLookupexecutor = (IJavaScriptExecutor)driver;
            OccupencyLookupexecutor.ExecuteScript("arguments[0].click();", OccupencyLookupwebElement);

            Thread.Sleep(5000);

            driver.FindElement(By.XPath("//tr[contains(@id,'OccupencyLookupPopup_RadGridOccupencyLookup_ctl00__14')]")).Click();
            driver.FindElement(By.XPath("//input[contains(@id,'btnOccupencyLookupOk')]")).Click();

            WaitForOverLay(10000);

            FindMeLooped("txtOfUnits");

            driver.FindElement(By.Id("txtOfUnits")).SendKeys(AddNewPermitsData.Select("ID='txtOfUnits'")[0]["Value"].ToString());

            IWebElement MasterPermitLookupwebElement = driver.FindElement(By.Id("MasterPermitLookup"));
            IJavaScriptExecutor MasterPermitLookupexecutor = (IJavaScriptExecutor)driver;
            MasterPermitLookupexecutor.ExecuteScript("arguments[0].click();", MasterPermitLookupwebElement);

            Thread.Sleep(5000);

            driver.FindElement(By.XPath("//tr[contains(@id,'MasterPermitLookupPopup_RadGridMasterPermitLookup_ctl00__0')]")).Click();
            driver.FindElement(By.XPath("//input[contains(@id,'btnMasterPermitLookupOk')]")).Click();

            WaitForOverLay(10000);

            FindMeLooped("ddlApprovedBy");

            driver.FindElement(By.Id("ddlApprovedBy")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlApprovedBy"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ddlApprovedBy'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlApprovedBy")).Click();

            driver.FindElement(By.Id("btnCalculate")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ddlImprovement")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlImprovement"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ddlImprovement'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlImprovement")).Click();

            driver.FindElement(By.Id("txtIssueDate")).SendKeys(AddNewPermitsData.Select("ID = 'txtIssueDate'")[0]["Value"].ToString());
            driver.FindElement(By.Id("txtExpirationDate")).SendKeys(AddNewPermitsData.Select("ID = 'txtExpirationDate'")[0]["Value"].ToString());

            if (AddNewPermitsData.Select("ID='chkDrawingDiagram'")[0]["Value"].ToString().ToLower() == "true")
            {
                driver.FindElement(By.Id("chkDrawingDiagram")).Click();
            }
            driver.FindElement(By.Id("txtCOIssued")).SendKeys(AddNewPermitsData.Select("ID = 'txtCOIssued'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtCOIssued")).Click();

            driver.FindElement(By.Id("txtProposedUse")).SendKeys(AddNewPermitsData.Select("ID='txtProposedUse'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtPurchasedBy")).SendKeys(AddNewPermitsData.Select("ID='txtPurchasedBy'")[0]["Value"].ToString());

            //check  ---------------------------
            driver.FindElement(By.LinkText("View / Add Characteristics...")).Click();
            {
                var element = driver.FindElement(By.LinkText("View / Add Characteristics..."));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            //{
            //    var element = driver.FindElement(By.TagName("body"));
            //    Actions builder = new Actions(driver);
            //    builder.MoveToElement(element, 0, 0).Perform();
            //}
            //check  -----------------------------

            driver.FindElement(By.Id("ddlDrawnBy")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlDrawnBy"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ddlDrawnBy'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlDrawnBy")).Click();

            // 76 | click | id=ddlConstructionType | 
            driver.FindElement(By.Id("ddlConstructionType")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlConstructionType"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ddlConstructionType'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlConstructionType")).Click();

            driver.FindElement(By.Id("ddlSewageDisposal")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlSewageDisposal"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ddlSewageDisposal'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlSewageDisposal")).Click();

            driver.FindElement(By.Id("ddlWaterSupply")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlWaterSupply"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ddlWaterSupply'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlWaterSupply")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtNumberOfStories")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtNumberOfStories'")[0]["Value"].ToString());

            if (AddNewPermitsData.Select("ID='ContentPlaceHolder1_chkElevator'")[0]["Value"].ToString().ToLower() == "true")
            {
                driver.FindElement(By.Id("ContentPlaceHolder1_chkElevator")).Click();
            }

            if (AddNewPermitsData.Select("ID='ContentPlaceHolder1_chkCentralAir'")[0]["Value"].ToString().ToLower() == "true")
            {
                driver.FindElement(By.Id("ContentPlaceHolder1_chkCentralAir")).Click();
            }

            driver.FindElement(By.Id("ContentPlaceHolder1_txtTotalNonLiving")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtTotalNonLiving'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtFrontWidth")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtFrontWidth'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtSide1Length")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtSide1Length'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtBedRooms")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtBedRooms'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_BuildingPermit")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtBedRooms")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtBedRooms'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtBathRooms")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtBathRooms'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtMinFloorElevator")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtMinFloorElevator'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtMiscInformationOne")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtMiscInformationOne'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtMiscInformationTwo")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtMiscInformationTwo'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtMinPadElevation")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtMinPadElevation'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ddlZoningClass")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlZoningClass"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ddlZoningClass'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlZoningClass")).Click();

            driver.FindElement(By.Id("ddltypeOfHeat")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddltypeOfHeat"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ddltypeOfHeat'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddltypeOfHeat")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtSewarImpactNumber")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtSewarImpactNumber'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtNumberOfPerking")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtNumberOfPerking'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtTotalLiving")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtTotalLiving'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtPlotArea")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtPlotArea'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtRearWidth")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtRearWidth'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtSide2Length")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtSide2Length'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtTotalRooms")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtTotalRooms'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_btnMasterCharacteristicsApply")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00_ctl04_EditButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00__0 > td:nth-child(3)")).Click();
            {
                var element = driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00__0 > td:nth-child(3)"));
                Actions builder = new Actions(driver);
                builder.DoubleClick(element).Perform();
            }

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00_ctl04_rcValueE_Input")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00_ctl04_rcValueE_Input'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00_ctl04_UpdateButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00_ctl05_EditButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00_ctl05_rcValueE_Input")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00_ctl05_rcValueE_Input'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00_ctl05_UpdateButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00_ctl06_EditButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00_ctl06_rcValueE_Input")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00_ctl06_rcValueE_Input'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalPermitCharacteristics_ctl00_ctl06_UpdateButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl00_AddNewRecordButton > .rgButtonText")).Click();

            WaitForOverLay(30000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtInputAmountI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtInputAmountI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtUnitsI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtUnitsI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtFeeAmountI")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(30000);

            driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl00_AddNewRecordButton > .rgButtonText")).Click();

            WaitForOverLay(30000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI'")[1]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtInputAmountI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtInputAmountI'")[1]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtUnitsI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtUnitsI'")[1]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtFeeAmountI")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl00_AddNewRecordButton > .rgButtonText")).Click();

            WaitForOverLay(30000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI'")[2]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtInputAmountI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtInputAmountI'")[2]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtUnitsI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtUnitsI'")[2]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtFeeAmountI")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(15000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(30000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI'")[3]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_ddlFeeTypeI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtInputAmountI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtInputAmountI'")[3]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtUnitsI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtUnitsI'")[3]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_txtFeeAmountI")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubFee_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.LinkText("Copy Sub-Fees")).Click();
            {
                var element = driver.FindElement(By.LinkText("Copy Sub-Fees"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            //{
            //    var element = driver.FindElement(By.TagName("body"));
            //    Actions builder = new Actions(driver);
            //    builder.MoveToElement(element, 0, 0).Perform();
            //}

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ContentPlaceHolder1_btnCopyPermit")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ContentPlaceHolder1_btnAppyPermit")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(30000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_ddlFeeTypeI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_ddlFeeTypeI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_ddlFeeTypeI'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_ddlFeeTypeI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtInputAmountI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtInputAmountI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtInputAmountI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtUnitsI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtUnitsI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtUnitsI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtFeeAmountI")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_chkAdditionalPaidI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(30000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_ddlFeeTypeI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_ddlFeeTypeI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_ddlFeeTypeI'")[1]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_ddlFeeTypeI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtInputAmountI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtInputAmountI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtInputAmountI'")[1]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtUnitsI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtUnitsI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtUnitsI'")[1]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_txtFeeAmountI")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_chkAdditionalPaidI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAdditionalFee_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPermits_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(30000);

            driver.FindElement(By.Id("GridPermitLookup")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_GridPermitLookupPopup_RadGridPermitLookup_ctl00__3")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_GridPermitLookupPopup_btnGridPermitLookupOk")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPermits_ctl00_ctl02_ctl02_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ContentPlaceHolder1_Contractors_Tab")).Click();

            WaitForOverLay(5000);

            driver.FindElement(By.Id("TaxpayersLookup")).Click();
            {
                var element = driver.FindElement(By.Id("TaxpayersLookup"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_TaxpayersLookupPopup_RadTaxpayersLookup_ctl00__6")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_TaxpayersLookupPopup_btnTaxpayersLookupOk")).Click();

            WaitForOverLay(20000);

            //driver.FindElement(By.CssSelector(".swal-button")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ContentPlaceHolder1_lblLicense")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtNotes")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtNotes")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtNotes'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtWorkDescription")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtWorkDescription'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_Location_Tab")).Click();

            WaitForOverLay(5000);

            //add street name
            driver.FindElement(By.LinkText("...")).Click();
            {
                var element = driver.FindElement(By.LinkText("..."));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }

            driver.FindElement(By.Id("ContentPlaceHolder1_txtStreetName")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtStreetName'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_btnStreetName")).Click();

            WaitForOverLay(15000);

            driver.FindElement(By.CssSelector(".swal-button")).Click();

            WaitForOverLay(15000);
            //add street name

            driver.FindElement(By.Id("ContentPlaceHolder1_ddlE911Address")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ContentPlaceHolder1_ddlE911Address"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ContentPlaceHolder1_ddlE911Address'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ContentPlaceHolder1_ddlE911Address")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtE911Address")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtE911Address")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtE911Address'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtAddress1")).Click();

            driver.FindElement(By.Id("txtAddress1")).SendKeys(AddNewPermitsData.Select("ID='txtAddress1'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtAddress2")).SendKeys(AddNewPermitsData.Select("ID='txtAddress2'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ddlCity")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlCity"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ddlCity'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlCity")).Click();

            driver.FindElement(By.Id("ddlState")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlState"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ddlState'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlState")).Click();

            driver.FindElement(By.Id("txtZip")).SendKeys(AddNewPermitsData.Select("ID='txtZip'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtPhone")).SendKeys(AddNewPermitsData.Select("ID='txtPhone'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtSurvey")).SendKeys(AddNewPermitsData.Select("ID='txtSurvey'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtLot")).SendKeys(AddNewPermitsData.Select("ID='txtLot'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtBlock")).SendKeys(AddNewPermitsData.Select("ID='txtBlock'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtMap")).SendKeys(AddNewPermitsData.Select("ID='txtMap'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtGroup")).SendKeys(AddNewPermitsData.Select("ID='txtGroup'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtControlMap")).SendKeys(AddNewPermitsData.Select("ID='txtControlMap'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtPercel")).SendKeys(AddNewPermitsData.Select("ID='txtPercel'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtGeoCode")).Click();

            driver.FindElement(By.Id("txtGeoCode")).SendKeys(AddNewPermitsData.Select("ID='txtGeoCode'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtSpecialInterest")).Click();

            driver.FindElement(By.Id("txtSpecialInterest")).SendKeys(AddNewPermitsData.Select("ID='txtSpecialInterest'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtLongitude")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtLongitude'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtFootPrint")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtFootPrint'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtLatitude")).SendKeys(AddNewPermitsData.Select("ID='ContentPlaceHolder1_txtLatitude'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_ddlJuridiction")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ContentPlaceHolder1_ddlJuridiction"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ContentPlaceHolder1_ddlJuridiction'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ContentPlaceHolder1_ddlJuridiction")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_ddlSubDivision")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ContentPlaceHolder1_ddlSubDivision"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ContentPlaceHolder1_ddlSubDivision'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ContentPlaceHolder1_ddlSubDivision")).Click();

            driver.FindElement(By.Id("txtJobLocationNotes")).SendKeys(AddNewPermitsData.Select("ID='txtJobLocationNotes'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtName")).SendKeys(AddNewPermitsData.Select("ID='txtName'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtOwnerAddress1")).SendKeys(AddNewPermitsData.Select("ID='txtOwnerAddress1'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_lnkbtnJobLocationAddress2")).Click();

            WaitForOverLay(15000);

            driver.FindElement(By.Id("ddlOwnerCity")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlOwnerCity"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ddlOwnerCity'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlOwnerCity")).Click();

            driver.FindElement(By.Id("ddlOwnerState")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlOwnerState"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ddlOwnerState'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ddlOwnerState")).Click();

            driver.FindElement(By.Id("txtOwnerZip")).SendKeys(AddNewPermitsData.Select("ID='txtOwnerZip'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtOwnerPhone")).SendKeys(AddNewPermitsData.Select("ID='txtOwnerPhone'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_SubContactors_Tab")).Click();

            WaitForOverLay(5000);

            driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl00_AddNewRecordButton > .rgButtonText")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl03_ddlSubContractorTypeI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl03_ddlSubContractorTypeI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl03_ddlSubContractorTypeI'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl03_ddlSubContractorTypeI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl03_ddlTaxPayerI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl03_ddlTaxPayerI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl03_ddlTaxPayerI'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl03_ddlTaxPayerI")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl03_txtNotesI")).SendKeys(AddNewPermitsData.Select("ID = 'ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl03_txtNotesI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl03_txtAmountI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl03_txtAmountI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridSubContractor_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_RadGridQuestions_ctl00_ctl02_ctl00_AddNewRecordButton > .rgButtonText")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridQuestions_ctl00_ctl02_ctl03_txtQuestionsDescriptionI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridQuestions_ctl00_ctl02_ctl03_txtQuestionsDescriptionI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridQuestions_ctl00_ctl02_ctl03_ddlAnswerI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridQuestions_ctl00_ctl02_ctl03_ddlAnswerI"));
            //    dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridQuestions_ctl00_ctl02_ctl03_ddlAnswerI'")[0]["Value"].ToString() + "']")).Click();
            //}
            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridQuestions_ctl00_ctl02_ctl03_ddlAnswerI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridQuestions_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl00_AddNewRecordButton > .rgButtonText")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_ddlUserDefinedFieldsI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_ddlUserDefinedFieldsI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_ddlUserDefinedFieldsI'")[0]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_ddlUserDefinedFieldsI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_txtValueI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_txtValueI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl00_AddNewRecordButton > .rgButtonText")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_ddlUserDefinedFieldsI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_ddlUserDefinedFieldsI"));
                dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_ddlUserDefinedFieldsI'")[1]["Value"].ToString() + "']")).Click();
            }
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_ddlUserDefinedFieldsI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_txtValueI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_txtValueI'")[1]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridUserDefinedFields_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("ContentPlaceHolder1_Inspections_Tab")).Click();

            WaitForOverLay(5000);

            driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl00_AddNewRecordButton > .rgButtonText")).Click();

            WaitForOverLay(10000);

            driver.FindElement(By.Id("RequestedByLookup")).Click();
            {
                var element = driver.FindElement(By.Id("RequestedByLookup"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            WaitForOverLay(10000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RequestedByLookupPopup_RadRequestedByLookup_ctl00__14")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_RequestedByLookupPopup_RequestedByLookupOk")).Click();

            WaitForOverLay(20000);

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_ddlInspectorI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_ddlInspectorI"));
            //    dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_ddlInspectorI'")[0]["Value"].ToString() + "']")).Click();
            //}
            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_ddlInspectorI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_txtInspectionTimeI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_txtInspectionTimeI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_txtInspectionTimeI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_txtActualInspectionTimeI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_txtActualInspectionTimeI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_txtActualInspectionTimeI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_ddlApprovedI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_ddlApprovedI"));
            //    dropdown.FindElement(By.XPath("//option[. = '" + AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_ddlApprovedI'")[0]["Value"].ToString() + "']")).Click();
            //}
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_ddlApprovedI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_txtInspectionFeeI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_txtInspectionFeeI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_txtInspectionNotesI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_txtInspectionNotesI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_chkScheduledI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridInspections_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            //WaitForOverLay(10000);

            //driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl00_AddNewRecordButton > .rgButtonText")).Click();

            //WaitForOverLay(10000);

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_txtDescriptionI")).Click();

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_txtDescriptionI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_txtDescriptionI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_txtAttachmentDateI")).Click();

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_txtAttachmentDateI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_txtAttachmentDateI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_RadAttachmentIfile0")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_RadAttachmentIfile0'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            //WaitForOverLay(10000);

            //driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl00_AddNewRecordButton > .rgButtonText")).Click();

            //WaitForOverLay(10000);

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_txtDescriptionI")).Click();

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_txtDescriptionI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_txtDescriptionI'")[1]["Value"].ToString());

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_txtAttachmentDateI")).Click();

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_txtAttachmentDateI")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_txtAttachmentDateI'")[1]["Value"].ToString());

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_RadAttachmentIfile0")).SendKeys(AddNewPermitsData.Select("ID='ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_RadAttachmentIfile0'")[1]["Value"].ToString());

            //driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridAttachments_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            ///////////////////////////////////////////////////////////////


            WaitForOverLay(10000);

            driver.FindElement(By.Id("btnSave")).Click();

            WaitForOverLay(10000);

            string expectedval = "Project saved successfully";
            string actualval = string.Empty;
            if (driver.FindElement(By.ClassName("swal-text")).GetAttribute("innerHTML").ToLower() == "values saved successfully!")
            {
                driver.FindElement(By.XPath("//div[@class='swal-button-container']/button[.='OK']")).Click();
                actualval = "Project saved successfully";
            }

            Assert.AreEqual(expectedval, actualval);
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
