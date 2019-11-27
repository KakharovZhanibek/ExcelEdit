using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_
{
    public static class ExcelPackageExtension
    {

        public static DataTable ToDataTable(this ExcelPackage package)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
            DataTable Dt = new DataTable();

            foreach (var firstRowCell in worksheet
                .Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                Dt.Columns.Add(firstRowCell.Text);
            }

            for (int rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
            {
                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                var newRow = Dt.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column-1] = cell.Text;
                }

                Dt.Rows.Add(newRow);
            }
            return Dt;
        }

    }
}
