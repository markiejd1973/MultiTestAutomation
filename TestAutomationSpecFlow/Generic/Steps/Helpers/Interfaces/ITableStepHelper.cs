using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Steps.Helpers.Interfaces
{
    public interface ITableStepHelper : IStepHelper
    {
        int GetNumberOfRowsDisplayed(string tableName);
        int GetNumberOfPopulatedRowsDisplayed(string tableName);
        string GetValueOfGridBox(string tableName, int rowNumber, int columnNumber);
        string GetValueOfGridBoxUsingColumnTitle(string tableName, string columnTitle, int rowNumber);
        bool Filter(string tableName, string value);
        bool IsColumnContainValue(string tableName, string columnName, string value);
        bool IsDisplayed(string tableName);
    }
}
