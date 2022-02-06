using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class ThenTableSteps : StepsBase
    {
        public ThenTableSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Then(@"Table ""([^""]*)"" Is Displayed")]
        public void GivenTableIsDisplayed(string tableName)
        {
            string proc = $"Then Table {tableName} Is Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Table.IsDisplayed(tableName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Table ""([^""]*)"" Has (.*) Rows Displayed")]
        public void ThenTableHasRowsDisplayed(string tableName, int numberOfRows)
        {
            string proc = $"Then Table {tableName} Is Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Table.GetNumberOfRowsDisplayed(tableName) == numberOfRows)
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Table ""([^""]*)"" has (.*) Populated Rows Displayed")]
        public void ThenTableHasPopulatedRowsDisplayed(string tableName, int populatedRows)
        {
            string proc = $"Then Table {tableName} Is Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Table.GetNumberOfPopulatedRowsDisplayed(tableName) == populatedRows)
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Table ""([^""]*)"" Column Title ""([^""]*)"" Row (.*) Is Equal To ""([^""]*)""")]
        public void ThenTableColumnTitleRowIsEqualTo(string tableName, string columnTitle, int rowNumber, string value)
        {
            string proc = $"Then Table {tableName} Column Title {columnTitle} Row {rowNumber} Is Equal To {value}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Table.GetValueOfGridBoxUsingColumnTitle(tableName, columnTitle, rowNumber) == value)
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }


        [Then(@"Table ""([^""]*)"" Row (.*) Column (.*) Is Equal To ""([^""]*)""")]
        public void ThenTableRowColumnIsEqualTo(string tableName, int rowNumber, int columnNumber, string value)
        {
            string proc = $"Then Table {tableName} Row {rowNumber} Column {columnNumber} Is Equal To {value}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Table.GetValueOfGridBox(tableName, rowNumber, columnNumber) == value)
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Table ""([^""]*)"" Column Title ""([^""]*)"" Contains Value ""([^""]*)""")]
        public void ThenTableColumnTitleContainsValue(string tableName, string columnName, string value)
        {
            string proc = $"Then Table {tableName} Column Title {columnName} Contains Value {value}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Table.IsColumnContainValue(tableName, columnName, value))   
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }



    }
}
