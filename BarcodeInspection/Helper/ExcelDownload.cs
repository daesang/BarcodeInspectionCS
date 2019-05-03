using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeInspection.Helper
{
    public class ExcelDownload
    {

        public ExcelDownload()
        {

        }

        public static void GenerateExcel(DataTable dataToExcel, string fileName, string excelSheetName)
        {

            //string fileName = "ByteOfCode";
            //string currentDirectorypath = Environment.;
            //string finalFileNameWithPath = string.Empty;

            //fileName = string.Format("{0}_{1}", fileName, DateTime.Now.ToString("dd-MM-yyyy"));
            //finalFileNameWithPath = string.Format("{0}\\{1}.xlsx", currentDirectorypath, fileName);

            //같은 이름 저장 하게 할 것인가?
            //Delete existing file with same file name.
            //if (File.Exists(fileName))
            //    File.Delete(fileName);

            FileInfo newFile = new FileInfo(fileName);

            //Step 1 : Create object of ExcelPackage class and pass file path to constructor.
            using (var package = new ExcelPackage(newFile))
            {
                //Step 2 : Add a new worksheet to ExcelPackage object and give a suitable name
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(excelSheetName);

                //Step 3 : Start loading datatable form A1 cell of worksheet.

                worksheet.Cells["A1"].LoadFromDataTable(dataToExcel, true);
                worksheet.Cells["A1"].AutoFitColumns();

                //worksheet.Cells[2, 4, dataToExcel.Rows.Count + 1, 5].Style.Numberformat.Format = "@";
                //worksheet.Cells[2, 10, dataToExcel.Rows.Count + 1, 11].Style.Numberformat.Format = "@";
                //worksheet.Cells[2, 14, dataToExcel.Rows.Count + 1, 14].Style.Numberformat.Format = "@";

                //Step 4 : (Optional) Set the file properties like title, author and subject
                //package.Workbook.Properties.Title = @"This code is part of tutorials available at http://bytesofcode.hubpages.com";
                //package.Workbook.Properties.Author = "Bytes Of Code";
                //package.Workbook.Properties.Subject = @"Register here for more http://hubpages.com/_bytes/user/new/";

                //Step 5 : Save all changes to ExcelPackage object which will create Excel 2007 file.
                package.Save();
            }
        }

    }
}
