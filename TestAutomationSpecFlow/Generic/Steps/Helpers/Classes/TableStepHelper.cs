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

        private readonly By[] nextPageButton = { By.XPath("//button[contains(text(),'Next')]") };
        private readonly By[] previousPageButton = { By.XPath("//button[contains(text(),'Previous')]") };

        private readonly By[] filterLocator = { By.Id("searchBox") };


        public bool Filter(string tableName, string value)
        {
            DebugOutput.Log($"Filter {tableName} {value}");
            var filterTextBox = SeleniumUtil.GetElement(filterLocator[versionNumber]);
            if (filterTextBox == null) return false;
            return SeleniumUtil.EnterText(filterTextBox, value);
        }

        public bool IsDisplayed(string tableName)
        {
            DebugOutput.Log($"IsDisplayed {tableName}");
            var tableElement = GetTableElement(tableName);
            if (tableElement == null) return false;
            return tableElement.Displayed;
        }

        public bool IsColumnContainValue(string tableName, string columnName, string value)
        {
            DebugOutput.Log($"IsColumnContainValue {tableName}");
            var tableElement = GetTableElement(tableName);
            if (tableElement == null) return false;
            int columnNumber = GetColumnNumberFromTitle(tableElement, columnName);  
            if (columnNumber == -1) return false;
            DebugOutput.Log($"Checking in Column {columnNumber}");
            var numberofDisplayedRows = GetNumberOfRowsDisplayed(tableName);
            var numberofPopulatedRows = GetNumberOfPopulatedRowsDisplayed(tableName);
            DebugOutput.Log($"We have {numberofDisplayedRows} displayed and {numberofPopulatedRows} populated");
            var counter = 1;
            while(counter <= numberofPopulatedRows)
            {
                var text = GetValueOfGridBox(tableName, counter, columnNumber);
                if (text == value) return true;
                counter++;
            }
            DebugOutput.Log($"Cycled - not found!");
            return false;
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

        public string GetValueOfGridBoxUsingColumnTitle(string tableName, string columnTitle, int rowNumber)
        {
            DebugOutput.Log($"GetValueOfGridBoxUsingColumnTitle {tableName} {columnTitle} {rowNumber}");
            //row includes headerincudes something?
            var tableElement = GetTableElement(tableName);
            if (tableElement == null) return "";
            var columnNumber = GetColumnNumberFromTitle(tableElement, columnTitle);
            if (columnNumber == -1) return "";
            return GetValueOfGridBox(tableName, rowNumber, columnNumber);
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

        private int GetColumnNumberFromTitle(IWebElement tableElement, string columnTitle)
        {
            DebugOutput.Log($"GetColumnNumberFromTitle {tableElement} {columnTitle}");
            var columnTitleElements = SeleniumUtil.GetElementsUnder(tableElement, headRowText[versionNumber]);
            int columnNumber = 1;
            foreach (var columnElement in columnTitleElements)
            {
                var text = SeleniumUtil.GetElementText(columnElement);
                if (text == columnTitle) return columnNumber;
                columnNumber++;
            }
            DebugOutput.Log($"Failed to find {columnTitle}");
            return -1;
        }

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
