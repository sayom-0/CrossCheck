using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CrossCheck
{
    public partial class Form1 : Form
    {

        private static Excel.Workbook ExcelBook;
        private static Excel.Application ExcelApp;
        private static Excel.Worksheet InventorySheet;
        private static Excel.Worksheet SurplusSheet;

        public Form1()
        {
            InitializeComponent();

            //Define File Dialog Properties
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Title = "Browse Excel Files";
            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            openFileDialog.DefaultExt = "xlsx";
            openFileDialog.FilterIndex = 1;
            openFileDialog.FileName = "";

            //Define Excel Application Properties
            ExcelApp = new Excel.Application();
            ExcelApp.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BrowseFilesButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePathText.Text = openFileDialog.FileName;
            }

        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            //Open Workbook for compare
            ExcelBook = ExcelApp.Workbooks.Open(FilePathText.Text);

            //Open Inventory and Surplus sheets
            InventorySheet = ExcelBook.Worksheets["Inventory"];
            SurplusSheet = ExcelBook.Worksheets["Surplus"];

            //Find Serial Columns & Row Ranges for each sheet
            String InventorySerialColumn = GetSerialRow(InventorySheet);
            String SurplusSerialColumn = GetSerialRow(SurplusSheet);

            int InventorySerialLastRow = InventorySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;// Find last row with data
            int SurplusSerialLastRow = SurplusSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

            //Put serials for each sheet into a Set
            HashSet<String> InventorySerials = new HashSet<String>(((System.Array)
                InventorySheet.get_Range(InventorySerialColumn + "2", InventorySerialColumn + InventorySerialLastRow).Cells.Value).OfType<object>().Select(o => o.ToString()).ToArray());
            HashSet<String> SurplusSerials = new HashSet<String>(((System.Array) 
                SurplusSheet.get_Range(SurplusSerialColumn + "2", SurplusSerialColumn + SurplusSerialLastRow).Cells.Value).OfType<object>().Select(o => o.ToString()).ToArray());
            //getting the range out of excel returns a System.Array which isn't able to be converted to a HashSet,
            //so LINQ must be used to convert to a normal array

            //Find the intersection of sets
            HashSet<String> SerialResults = new HashSet<String>(InventorySerials);
            SerialResults.IntersectWith(SurplusSerials);

            //Display results
            foreach (String serial in SerialResults)
                ResultsBox.Text += serial + " ";
        }

        private String GetSerialRow(Excel.Worksheet worksheet)
        {
            //Find last colum and put first row into list to find the "Serial" Column
            String lastCol = ((char)(worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column + 64)).ToString();
            Array Columns = (System.Array)worksheet.get_Range("A1", lastCol + "1").Cells.Value;

            //Return Serial Column Character
            for (int i = 1; i < Columns.Length; i++)
                if (Columns.GetValue(1, i).ToString().ToLower().Contains("serial"))
                    return ((char)(i + 64)).ToString();// add 65 and convert to char to change column numerical value to character

            return null;
        }
    }
}
