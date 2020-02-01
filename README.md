# T856537
Spreadsheet Cell editor example

From DevExpress - added functionality
To provide a custom editor for a spreadsheet cell, handle the SpreadsheetControl.CustomCellEdit event, create a RepositoryItem descendant corresponding to the editor you want to use, and assign it to the event's SpreadsheetCustomCellEditEventArgs.RepositoryItem parameter.

This approach is described in the Use the CustomCellEdit event to Assign Your Own Editor to a Cell topic Mariya suggested in the Input mask on spreadsheet cell ticket. Please refer to that topic for clarification.

I created a sample that demonstrates how to limit entered values with numbers from 100 to 2000. To provide an input mask for cells, I used the RepositoryItemTextEdit repository item. To limit a cell value by 100-2000, I handled the SpreadsheetControl.CellEndEdit event.
