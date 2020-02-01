using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using DevExpress.XtraEditors;
using DevExpress.Spreadsheet;
using System.Diagnostics;
using System.IO;
using DevExpress.Spreadsheet.Functions;
using System.Text;
using DevExpress.XtraEditors.Repository;

namespace DXApplication15
{
    public partial class Form1 : XtraForm
    {
        public Form1() {
            InitializeComponent();
            spreadsheetControl.LoadDocument();
            var worksheet = spreadsheetControl.ActiveWorksheet;
            spreadsheetControl.CustomCellEdit += spreadsheetControl_CustomCellEdit;
            spreadsheetControl.CellEndEdit += SpreadsheetControl_CellEndEdit;
        }

        private void SpreadsheetControl_CellEndEdit(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (string.IsNullOrEmpty(e.EditorText)) return;

                float value = float.Parse(e.EditorText);
                if (value < 100 || value > 2000)
                {
                    e.Cancel = true;
                    XtraMessageBox.Show("The entered value must be >=100 and <=2000");
                }
            }
        }

        private void spreadsheetControl_CustomCellEdit(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCustomCellEditEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                RepositoryItemTextEdit repository = new RepositoryItemTextEdit();
                repository.AutoHeight = false;
                repository.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

                Style thisCellsStyle = e.Cell.Style;
                string thisCellsFormat = thisCellsStyle.NumberFormat;
                string thisCellsStyleName = thisCellsStyle.Name;
                thisCellsFormat = e.Cell.NumberFormat;
                bool thisCellIsLocked = e.Cell.Protection.Locked;
                IList<DevExpress.Spreadsheet.Comment> comments = spreadsheetControl.ActiveWorksheet.Comments.GetComments(spreadsheetControl.ActiveCell);
                string thisCellsNote = comments[0].Text; // hardcoding '0' only works because there is only one ActiveCell

                if (thisCellsFormat == "")
                {
                    repository.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                }
                else
                { 
                    repository.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    repository.Mask.EditMask = thisCellsFormat;
                } 
                e.RepositoryItem = repository;
            }
        }
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }


  
}