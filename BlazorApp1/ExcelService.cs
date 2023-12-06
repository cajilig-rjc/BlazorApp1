using BlazorApp1;
using OfficeOpenXml;
using System;
using System.Collections.Generic;

public class ExcelService
{
    public List<DynamicItem> ReadExcel(byte[] fileData)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage(new System.IO.MemoryStream(fileData)))
        {
            var worksheet = package.Workbook.Worksheets[0];
            var items = new List<DynamicItem>();

            for (int row = 2; row <= worksheet.Dimension.Rows; row++)
            {
                var item = new DynamicItem();

                for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                {
                    var header = worksheet.Cells[1, col]?.Value?.ToString() ?? "Null";
                    var value = worksheet.Cells[row, col]?.Value;

                    // Check if the key already exists in the dictionary
                    if (item.Properties.ContainsKey(header))
                    {
                        // Handle the duplicate key, for example, by appending a unique identifier
                        header = $"{header}_{Guid.NewGuid().ToString("N")}";
                    }

                    item.Properties.Add(header, value);
                }

                items.Add(item);
            }

            return items;
        }
    }
}
