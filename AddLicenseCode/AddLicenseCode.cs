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

namespace AddLicenseCode
{
    [TestClass]
    public class AddLicenseCodes
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        [TestMethod]
        [TestCategory("Chrome")]
        public void AddLicenseCode()
        {
            DataTable AddNewLicenseCodeData = new DataTable();
            AddNewLicenseCodeData = GetDataFromURL("AddNewLicenseCode");

            driver.Navigate().GoToUrl(appURL);

            //driver.FindElement(By.Id("txtUserId")).SendKeys("Admin");
            driver.FindElement(By.Id("txtUserId")).SendKeys(AddNewLicenseCodeData.Select("ID='txtUserId'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("txtUserPassword")).SendKeys("Arm714strong");
            driver.FindElement(By.Id("txtUserPassword")).SendKeys(AddNewLicenseCodeData.Select("ID='txtUserPassword'")[0]["Value"].ToString());

            driver.FindElement(By.Id("btnLogin")).Click();

            WaitForOverLay(10000);

            string GoToURL = RedirectToPage("AddNewLicenseCode.aspx");
            driver.Navigate().GoToUrl(GoToURL);

            WaitForOverLay(20000);
            ////////////////////////////////////////////////////////////////

            driver.FindElement(By.Id("txtLicenseCode")).Click();

            driver.FindElement(By.Id("txtLicenseCode")).SendKeys(AddNewLicenseCodeData.Select("ID='txtLicenseCode'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtDescription")).Click();

            driver.FindElement(By.Id("txtDescription")).SendKeys(AddNewLicenseCodeData.Select("ID='txtDescription'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtShortDescription")).Click();

            driver.FindElement(By.Id("txtShortDescription")).SendKeys(AddNewLicenseCodeData.Select("ID='txtShortDescription'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtMediumDescription")).Click();

            driver.FindElement(By.Id("txtMediumDescription")).SendKeys(AddNewLicenseCodeData.Select("ID='txtMediumDescription'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtLongDescription")).Click();

            driver.FindElement(By.Id("txtLongDescription")).SendKeys(AddNewLicenseCodeData.Select("ID='txtLongDescription'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ContentPlaceHolder1_ddlGroup")).Click();

            //driver.FindElement(By.Id("ContentPlaceHolder1_ddlGroup")).Click();

            //driver.FindElement(By.Id("ContentPlaceHolder1_ddlGroup")).Click();
            //{
            //    var element = driver.FindElement(By.Id("ContentPlaceHolder1_ddlGroup"));
            //    Actions builder = new Actions(driver);
            //    builder.DoubleClick(element).Perform();
            //}
            //driver.FindElement(By.Id("ContentPlaceHolder1_ddlGroup")).Click();

            //driver.FindElement(By.Id("ContentPlaceHolder1_ddlGroup")).Click();

            //driver.FindElement(By.Id("ContentPlaceHolder1_ddlGroup")).Click();

            //driver.FindElement(By.Id("ContentPlaceHolder1_ddlGroup")).Click();
            //{
            //    var element = driver.FindElement(By.Id("ContentPlaceHolder1_ddlGroup"));
            //    Actions builder = new Actions(driver);
            //    builder.DoubleClick(element).Perform();
            //}

            driver.FindElement(By.Id("ddlRenewalFrequency")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlRenewalFrequency"));
                dropdown.FindElement(By.XPath("//option[. = '"+ AddNewLicenseCodeData.Select("ID='ddlRenewalFrequency'")[0]["Value"].ToString()+"']")).Click();
            }
            driver.FindElement(By.Id("ddlRenewalFrequency")).Click();

            driver.FindElement(By.Id("ddlDueMonth")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlDueMonth"));
                dropdown.FindElement(By.XPath("//option[. = '"+ AddNewLicenseCodeData.Select("ID='ddlDueMonth'")[0]["Value"].ToString()+"']")).Click();
            }
            driver.FindElement(By.Id("ddlDueMonth")).Click();

            driver.FindElement(By.Id("ddlRemittanceType")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlRemittanceType"));
                dropdown.FindElement(By.XPath("//option[. = '"+ AddNewLicenseCodeData.Select("ID='ddlRemittanceType'")[0]["Value"].ToString()+"']")).Click();
            }
            driver.FindElement(By.Id("ddlRemittanceType")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtDueDay")).SendKeys(AddNewLicenseCodeData.Select("ID='ContentPlaceHolder1_txtDueDay'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_ddlRemittanceAddress")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ContentPlaceHolder1_ddlRemittanceAddress"));
                dropdown.FindElement(By.XPath("//option[. = '"+ AddNewLicenseCodeData.Select("ID='ContentPlaceHolder1_ddlRemittanceAddress'")[0]["Value"].ToString()+"']")).Click();
            }
            driver.FindElement(By.Id("ContentPlaceHolder1_ddlRemittanceAddress")).Click();

            SelectDropDwonIndex("ddlPeriodEndMonth", Convert.ToInt32(AddNewLicenseCodeData.Select("ID='ddlPeriodEndMonth'")[0]["Value"].ToString()));
            
            //driver.FindElement(By.Id("ddlPeriodEndMonth")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlPeriodEndMonth"));
            //    dropdown.FindElement(By.XPath("//option[@value = '11']")).Click();
            //}
            //driver.FindElement(By.Id("ddlPeriodEndMonth")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtStatute")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtStatute")).SendKeys(AddNewLicenseCodeData.Select("ID='ContentPlaceHolder1_txtStatute'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_chkFollowUp")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtFollowUpDays")).SendKeys(AddNewLicenseCodeData.Select("ID='ContentPlaceHolder1_txtFollowUpDays'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_txtFollowUpLetter")).SendKeys(AddNewLicenseCodeData.Select("ID='ContentPlaceHolder1_txtFollowUpLetter'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_btnNewPeriod")).Click();

            WaitForOverLay(15000);

            FindMeLooped("txtPeriodEffectiveSession");

            driver.FindElement(By.Id("txtPeriodEffectiveSession")).Click();

            driver.FindElement(By.Id("txtPeriodEffectiveSession")).SendKeys(AddNewLicenseCodeData.Select("ID='txtPeriodEffectiveSession'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtNotesSession")).SendKeys(AddNewLicenseCodeData.Select("ID='txtNotesSession'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtFlatFee")).SendKeys(AddNewLicenseCodeData.Select("ID='txtFlatFee'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ddlFlatFeePrintCode")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlFlatFeePrintCode"));
                dropdown.FindElement(By.XPath("//option[. = '"+ AddNewLicenseCodeData.Select("ID='ddlFlatFeePrintCode'")[0]["Value"].ToString()+"']")).Click();
            }
            driver.FindElement(By.Id("ddlFlatFeePrintCode")).Click();

            driver.FindElement(By.Id("txtMinimumAmount")).SendKeys(AddNewLicenseCodeData.Select("ID='txtMinimumAmount'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtMaximumAmount")).SendKeys(AddNewLicenseCodeData.Select("ID='txtMaximumAmount'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtPoliceJurisdiction")).SendKeys(AddNewLicenseCodeData.Select("ID='txtPoliceJurisdiction'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ddlProrationMethod")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlProrationMethod"));
                dropdown.FindElement(By.XPath("//option[. = '"+ AddNewLicenseCodeData.Select("ID='ddlProrationMethod'")[0]["Value"].ToString()+"']")).Click();
            }
            driver.FindElement(By.Id("ddlProrationMethod")).Click();

            driver.FindElement(By.Id("txtIssueFee")).SendKeys(AddNewLicenseCodeData.Select("ID='txtIssueFee'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_chkFee1")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtDescriptionFee1")).SendKeys(AddNewLicenseCodeData.Select("ID='ContentPlaceHolder1_txtDescriptionFee1'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtDefaultAmountFee1")).SendKeys(AddNewLicenseCodeData.Select("ID='txtDefaultAmountFee1'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_chkFee2")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtDescriptionFee2")).SendKeys(AddNewLicenseCodeData.Select("ID='ContentPlaceHolder1_txtDescriptionFee2'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtDefaultAmountFee2")).SendKeys(AddNewLicenseCodeData.Select("ID='txtDefaultAmountFee2'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_chkFee3")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtDescriptionFee3")).SendKeys(AddNewLicenseCodeData.Select("ID='ContentPlaceHolder1_txtDescriptionFee3'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtDefaultAmountFee3")).SendKeys(AddNewLicenseCodeData.Select("ID='txtDefaultAmountFee3'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_chkFee4")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtDescriptionFee4")).SendKeys(AddNewLicenseCodeData.Select("ID='ContentPlaceHolder1_txtDescriptionFee4'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtDefaultAmountFee4")).SendKeys(AddNewLicenseCodeData.Select("ID='txtDefaultAmountFee4'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ContentPlaceHolder1_chkFee5")).Click();

            driver.FindElement(By.Id("ContentPlaceHolder1_txtDescriptionFee5")).SendKeys(AddNewLicenseCodeData.Select("ID='ContentPlaceHolder1_txtDescriptionFee5'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtDefaultAmountFee5")).SendKeys(AddNewLicenseCodeData.Select("ID='txtDefaultAmountFee5'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridRows_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("txtRowNumberI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtRowNumberI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtDescriptionI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtDescriptionI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlPrintCodeI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlPrintCodeI"));
            //    dropdown.FindElement(By.XPath("//option[@value='ABC']")).Click();
            //}
            //driver.FindElement(By.Id("ddlPrintCodeI")).Click();

            var ddlPrintCodeI = new SelectElement(driver.FindElement(By.Id("ddlPrintCodeI")));
            ddlPrintCodeI.SelectByText(AddNewLicenseCodeData.Select("ID='ddlPrintCodeI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtToFromByAmountI")).Click();

            driver.FindElement(By.Id("txtToFromByAmountI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtToFromByAmountI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlRateCodeI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlRateCodeI"));
            //    dropdown.FindElement(By.XPath("//option[@value='BBD']")).Click();
            //}
            //driver.FindElement(By.Id("ddlRateCodeI")).Click();

            var ddlRateCodeI = new SelectElement(driver.FindElement(By.Id("ddlRateCodeI")));
            ddlRateCodeI.SelectByText(AddNewLicenseCodeData.Select("ID='ddlRateCodeI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlSecondaryOperatorI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlSecondaryOperatorI"));
            //    dropdown.FindElement(By.XPath("//option[. = '/']")).Click();
            //}

            var ddlSecondaryOperatorI = new SelectElement(driver.FindElement(By.Id("ddlSecondaryOperatorI")));
            ddlSecondaryOperatorI.SelectByText(AddNewLicenseCodeData.Select("ID='ddlSecondaryOperatorI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ddlSecondaryOperatorI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridRows_ctl00_ctl02_ctl03_chkRenewableI")).Click();

            driver.FindElement(By.Id("txtWorkFieldNumberI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtWorkFieldNumberI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridRows_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridRows_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("txtRowNumberI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtRowNumberI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtDescriptionI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtDescriptionI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlPrintCodeI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlPrintCodeI"));
            //    dropdown.FindElement(By.XPath("//option[. = 'GC - test 2']")).Click();
            //}
            //driver.FindElement(By.Id("ddlPrintCodeI")).Click();

            var ddlPrintCodeI1 = new SelectElement(driver.FindElement(By.Id("ddlPrintCodeI")));
            ddlPrintCodeI1.SelectByText(AddNewLicenseCodeData.Select("ID='ddlPrintCodeI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlPrimaryOperatorI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlPrimaryOperatorI"));
            //    dropdown.FindElement(By.XPath("//option[. = '/']")).Click();
            //}
            //driver.FindElement(By.Id("ddlPrimaryOperatorI")).Click();

            var ddlPrimaryOperatorI1 = new SelectElement(driver.FindElement(By.Id("ddlPrimaryOperatorI")));
            ddlPrimaryOperatorI1.SelectByText(AddNewLicenseCodeData.Select("ID='ddlPrimaryOperatorI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtToFromByAmountI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtToFromByAmountI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlRateCodeI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlRateCodeI"));
            //    dropdown.FindElement(By.XPath("//option[. = 'FP2 - FIRE SAFETY 10/05 - G']")).Click();
            //}
            //driver.FindElement(By.Id("ddlRateCodeI")).Click();

            var ddlRateCodeI2 = new SelectElement(driver.FindElement(By.Id("ddlRateCodeI")));
            ddlRateCodeI2.SelectByText(AddNewLicenseCodeData.Select("ID='ddlRateCodeI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlSecondaryOperatorI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlSecondaryOperatorI"));
            //    dropdown.FindElement(By.XPath("//option[. = 'label']")).Click();
            //}
            //driver.FindElement(By.Id("ddlSecondaryOperatorI")).Click();

            var ddlSecondaryOperatorI1 = new SelectElement(driver.FindElement(By.Id("ddlSecondaryOperatorI")));
            ddlSecondaryOperatorI1.SelectByText(AddNewLicenseCodeData.Select("ID='ddlSecondaryOperatorI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtWorkFieldNumberI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtWorkFieldNumberI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridRows_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridWorkFields_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("txtWorkFieldNumberI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtWorkFieldNumberI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlComparisonI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlComparisonI"));
            //    dropdown.FindElement(By.XPath("//option[. = 'label']")).Click();
            //}
            //driver.FindElement(By.Id("ddlComparisonI")).Click();

            var ddlComparisonI = new SelectElement(driver.FindElement(By.Id("ddlComparisonI")));
            ddlComparisonI.SelectByText(AddNewLicenseCodeData.Select("ID='ddlComparisonI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtToFromByAmountI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtToFromByAmountI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlRateCodeI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlRateCodeI"));
            //    dropdown.FindElement(By.XPath("//option[. = 'FS1 - Fire Safety - M']")).Click();
            //}
            //driver.FindElement(By.Id("ddlRateCodeI")).Click();

            var ddlRateCodeI3 = new SelectElement(driver.FindElement(By.Id("ddlRateCodeI")));
            ddlRateCodeI3.SelectByText(AddNewLicenseCodeData.Select("ID='ddlRateCodeI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlSecondaryOperatorI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlSecondaryOperatorI"));
            //    dropdown.FindElement(By.XPath("//option[. = '/']")).Click();
            //}
            //driver.FindElement(By.Id("ddlSecondaryOperatorI")).Click();

            var ddlSecondaryOperatorI2 = new SelectElement(driver.FindElement(By.Id("ddlSecondaryOperatorI")));
            ddlSecondaryOperatorI2.SelectByText(AddNewLicenseCodeData.Select("ID='ddlSecondaryOperatorI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridWorkFields_ctl00_ctl02_ctl03_chkTotalLicenseI")).Click();

            driver.FindElement(By.Id("txtCalculateFieldNumberI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtCalculateFieldNumberI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridWorkFields_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridWorkFields_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("txtWorkFieldNumberI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtWorkFieldNumberI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlComparisonI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlComparisonI"));
            //    dropdown.FindElement(By.XPath("//option[. = '<']")).Click();
            //}
            //driver.FindElement(By.Id("ddlComparisonI")).Click();

            var ddlComparisonI2 = new SelectElement(driver.FindElement(By.Id("ddlComparisonI")));
            ddlComparisonI2.SelectByText(AddNewLicenseCodeData.Select("ID='ddlComparisonI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlPrimaryOperatorI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlPrimaryOperatorI"));
            //    dropdown.FindElement(By.XPath("//option[. = '*']")).Click();
            //}
            //driver.FindElement(By.Id("ddlPrimaryOperatorI")).Click();

            var ddlPrimaryOperatorI2 = new SelectElement(driver.FindElement(By.Id("ddlPrimaryOperatorI")));
            ddlPrimaryOperatorI2.SelectByText(AddNewLicenseCodeData.Select("ID='ddlPrimaryOperatorI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtToFromByAmountI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtToFromByAmountI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlRateCodeI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlRateCodeI"));
            //    dropdown.FindElement(By.XPath("//option[. = 'PR2 - Plan Review Table 2 - G']")).Click();
            //}
            //driver.FindElement(By.Id("ddlRateCodeI")).Click();

            var ddlRateCodeI4 = new SelectElement(driver.FindElement(By.Id("ddlRateCodeI")));
            ddlRateCodeI4.SelectByText(AddNewLicenseCodeData.Select("ID='ddlRateCodeI'")[0]["Value"].ToString());

            //driver.FindElement(By.Id("ddlSecondaryOperatorI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlSecondaryOperatorI"));
            //    dropdown.FindElement(By.XPath("//option[. = '/']")).Click();
            //}
            //driver.FindElement(By.Id("ddlSecondaryOperatorI")).Click();

            //var ddlSecondaryOperatorI3 = new SelectElement(driver.FindElement(By.Id("ddlSecondaryOperatorI")));
            //ddlSecondaryOperatorI3.SelectByText("/");

            //driver.FindElement(By.Id("ddlSecondaryOperatorI")).Click();
            //{
            //    var dropdown = driver.FindElement(By.Id("ddlSecondaryOperatorI"));
            //    dropdown.FindElement(By.XPath("//option[. = 'label']")).Click();
            //}
            //driver.FindElement(By.Id("ddlSecondaryOperatorI")).Click();

            var ddlSecondaryOperatorI4 = new SelectElement(driver.FindElement(By.Id("ddlSecondaryOperatorI")));
            ddlSecondaryOperatorI4.SelectByText(AddNewLicenseCodeData.Select("ID='ddlSecondaryOperatorI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtCalculateFieldNumberI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtCalculateFieldNumberI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridWorkFields_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPenaltyInterest_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("txtDaysLateI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtDaysLateI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ddlPenaltyTypeI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlPenaltyTypeI"));
                dropdown.FindElement(By.XPath("//option[. = '"+ AddNewLicenseCodeData.Select("ID='ddlPenaltyTypeI'")[0]["Value"].ToString()+"']")).Click();
            }
            driver.FindElement(By.Id("ddlPenaltyTypeI")).Click();

            driver.FindElement(By.Id("txtPenaltyPercentI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtPenaltyPercentI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtPenaltyAmountI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtPenaltyAmountI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtInterestPercentI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtInterestPercentI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtInterestAmountI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtInterestAmountI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridPenaltyInterest_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridGeneralLedger_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(20000); 

            driver.FindElement(By.Id("ddlGLAccountDebitI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlGLAccountDebitI"));
                dropdown.FindElement(By.XPath("//option[. = '"+ AddNewLicenseCodeData.Select("ID='ddlGLAccountDebitI'")[0]["Value"].ToString()+"']")).Click();
            }
            driver.FindElement(By.Id("ddlGLAccountDebitI")).Click();

            driver.FindElement(By.Id("ddlGLAccountCreditI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlGLAccountCreditI"));
                dropdown.FindElement(By.XPath("//option[. = '"+ AddNewLicenseCodeData.Select("ID='ddlGLAccountCreditI'")[0]["Value"].ToString()+"']")).Click();
            }
            driver.FindElement(By.Id("ddlGLAccountCreditI")).Click();

            driver.FindElement(By.Id("txtPercentI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtPercentI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtAmountI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtAmountI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridGeneralLedger_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridGeneralLedger_ctl00_ctl02_ctl00_AddNewRecordButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridGeneralLedger_ctl00_ctl02_ctl03_chkAppliesToDiscountI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridGeneralLedger_ctl00_ctl02_ctl03_chkAppliesToPenaltyI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridGeneralLedger_ctl00_ctl02_ctl03_chkAppliesToInterestI")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridGeneralLedger_ctl00_ctl02_ctl03_chkAppliesToFee3I")).Click();

            driver.FindElement(By.Id("ddlGLAccountDebitI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlGLAccountDebitI"));
                dropdown.FindElement(By.XPath("//option[. = '"+ AddNewLicenseCodeData.Select("ID='ddlGLAccountDebitI'")[0]["Value"].ToString()+"']")).Click();
            }
            driver.FindElement(By.Id("ddlGLAccountDebitI")).Click();

            driver.FindElement(By.Id("ddlGLAccountDebitI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlGLAccountDebitI"));
                dropdown.FindElement(By.XPath("//option[. = '"+ AddNewLicenseCodeData.Select("ID='ddlGLAccountDebitI'")[0]["Value"].ToString()+"']")).Click();
            }
            driver.FindElement(By.Id("ddlGLAccountDebitI")).Click();

            driver.FindElement(By.Id("ddlGLAccountCreditI")).Click();
            {
                var dropdown = driver.FindElement(By.Id("ddlGLAccountCreditI"));
                dropdown.FindElement(By.XPath("//option[. = '"+ AddNewLicenseCodeData.Select("ID='ddlGLAccountCreditI'")[0]["Value"].ToString()+"']")).Click();
            }
            driver.FindElement(By.Id("ddlGLAccountCreditI")).Click();

            driver.FindElement(By.Id("txtPercentI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtPercentI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("txtAmountI")).SendKeys(AddNewLicenseCodeData.Select("ID='txtAmountI'")[0]["Value"].ToString());

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_RadGridGeneralLedger_ctl00_ctl02_ctl03_PerformInsertButton")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("ContentPlaceHolder1_btnSavePeriod")).Click();

            WaitForOverLay(20000);

            driver.FindElement(By.Id("ContentPlaceHolder1_btnOK")).Click();

            ///////////////////////////////////////////////////////////////

            WaitForOverLay(10000);

            string expectedval = "License Code saved successfully";
            string actualval = string.Empty;
            if (driver.FindElement(By.ClassName("swal-text")).GetAttribute("innerHTML").ToLower() == "values saved successfully!")
            {
                driver.FindElement(By.XPath("//div[@class='swal-button-container']/button[.='OK']")).Click();
                actualval = "License Code saved successfully";
            }

            Assert.AreEqual(expectedval, actualval);
        }

        public void SelectDropDwonIndex(string DropDownControlID, int drpSelectIndex)
        {
            for (int i = 0; i <= drpSelectIndex - 1; i++)
            {
                driver.FindElement(By.Id(DropDownControlID)).SendKeys(Keys.ArrowDown);
            }
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
