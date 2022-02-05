using Core;
using Core.Logging;
using Core.Transformations;
using Generic.Steps.Helpers.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class TableStepHelper : StepHelper, ITableStepHelper
    {
        private readonly ITargetForms targetForms;
        public TableStepHelper(FeatureContext featureContext, ITargetForms targetForms) : base(featureContext)
        {
            this.targetForms = targetForms;
        }

        int versionNumber = 0;

        int primaryColumnForTable = 1;

        private readonly By[] headLocator = { By.ClassName($"rt-thead") };
        private readonly By[] headRowLocator = { By.ClassName($"rt-th") };
        private readonly By[] headRowText = { By.ClassName($"rt-resizable-header-content") };

        private readonly By[] bodyLocator = { By.ClassName($"rt-tbody") };
        private readonly By[] bodyRowGroupLocator = { By.ClassName($"rt-tr-group") };
        private readonly By[] bodyRowLocator = { By.ClassName($"rt-tr-group") };

        private readonly By[] bodyGridCell = { By.ClassName($"rt-td") };

        public bool IsDisplayed(string tableName)
        {
            DebugOutput.Log($"IsDisplayed {tableName}");
            var tableElement = GetTableElement(tableName);
            if (tableElement == null) return false;
            return tableElement.Displayed;
        }

        public int GetNumberOfRowsDisplayed(string tableName)
        {
            DebugOutput.Log($"NumberOfRowsDisplayed {tableName}");
            var tableElement = GetTableElement(tableName);
            if (tableElement == null) return -1;
            return GetAllRows(tableElement).Count();
        }

        public int GetNumberOfPopulatedRowsDisplayed(string tableName)
        {
            DebugOutput.Log($"GetNumberOfPopulatedRowsDisplayed {tableName}");
            var tableElement = GetTableElement(tableName);
            if (tableElement == null) return -1;
            var rowElements = GetAllRows(tableElement);
            DebugOutput.Log($"There are {rowElements.Count} rows displayed");
            int numberOfPopulatedRows = 0;
            foreach (var rowElement in rowElements)
            {
                var rowGridElements = SeleniumUtil.GetElementsUnder(rowElement, bodyGridCell[versionNumber]);
                DebugOutput.Log($"We have {rowGridElements.Count} columns");
                var text = StringValues.RemoveHtmlFromEnd(SeleniumUtil.GetElementText(rowGridElements[primaryColumnForTable - 1]));
                DebugOutput.Log($">>> {text}");
                if (text != "") numberOfPopulatedRows++;
            }
            DebugOutput.Log($"That means {numberOfPopulatedRows} rows are populated");
            return numberOfPopulatedRows;
        }

        public string GetValueOfGridBox(string tableName, int rowNumber, int columnNumber)
        {
            DebugOutput.Log($"GetValueOfGridBox {tableName} {rowNumber} {columnNumber}");
            //row includes header. column incudes something?
            rowNumber--;
            columnNumber--;
            var tableElement = GetTableElement(tableName);
            if (tableElement == null) return "";
            var rowElements = GetAllRows(tableElement);
            DebugOutput.Log($"There are {rowElements.Count} rows displayed");
            var rowElement = rowElements[rowNumber];
            DebugOutput.Log($"We have our row element!");
            var rowGridElements = SeleniumUtil.GetElementsUnder(rowElement, bodyGridCell[versionNumber]);
            DebugOutput.Log($"We have {rowGridElements?.Count} Columns in this row");
            var rowGridElement = rowGridElements[columnNumber];
            return StringValues.RemoveHtmlFromEnd(SeleniumUtil.GetElementText(rowGridElement));
        }


        //PRIVATE

        private List<IWebElement> GetAllRows(IWebElement tableElement)
        {
            DebugOutput.Log($"GetAllRows {tableElement}");
            var rows = new List<IWebElement>();
            rows = SeleniumUtil.GetElementsUnder(tableElement, bodyRowLocator[versionNumber]);
            DebugOutput.Log($"{rows.Count} return in table!");
            return rows;
        }

        private IWebElement GetTableElement(string tableName)
        {
            DebugOutput.Log($"GetTableElement {tableName}");
            tableName = GetTableName(tableName);
            var tableLocator = CurrentPage.Elements[tableName];
            var tableElement = SeleniumUtil.GetElement(tableLocator);
            if (tableElement == null) return null;
            DebugOutput.Log($"Table Element {tableName} = {tableElement}");
            return tableElement;
        }

        private string GetTableName(string tableName)
        {
            DebugOutput.Log($"GetTableName {tableName}");
            tableName = tableName.ToLower();
            if (tableName.Contains("table")) return tableName;
            return tableName + " table";
        }

    }
}
