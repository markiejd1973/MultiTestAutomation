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
        bool IsDisplayed(string tableName);
    }
}
