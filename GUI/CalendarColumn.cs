using System;
using System.Drawing;
using System.Windows.Forms;

[ToolboxBitmap(typeof(DataGridViewColumn))]
public class CalendarColumn : DataGridViewColumn
{
    public CalendarColumn()
        : base(new CalendarCell())
    {

    }
    public DateTime MinDate
    {
        get { return CalendarCell.CellMinDate; }
        set { CalendarCell.CellMinDate = value; }
    }
    public DateTime MaxDate
    {
        get { return CalendarCell.CellMaxDate; }
        set { CalendarCell.CellMaxDate = value; }
    }
    public override DataGridViewCell CellTemplate
    {
        get { return base.CellTemplate; }
        set
        {
            if (value != null && !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
            {
                throw new InvalidCastException("Must be a CalendarCell");
            }
            base.CellTemplate = value;
        } // Ensure that the cell used for the template is a CalendarCell.
    }
}

public class CalendarCell : DataGridViewTextBoxCell
{
    public CalendarCell()
        : base()
    {
        this.Style.Format = "d";// Use the short date format. 
    }
    public static DateTime CellMaxDate { get; set; }
    public static DateTime CellMinDate { get; set; }
    public DateTime MinDate { get; set; }
    public DateTime MaxDate { get; set; }
    public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)   // Set the value of the editing control to the current cell value.
    {
        base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

        var ctl = DataGridView.EditingControl as CalendarEditingControl;
        ctl.MinDate = DateTimePicker.MinimumDateTime;
        ctl.MaxDate = DateTimePicker.MaximumDateTime;
        ctl.MinDate = CellMinDate;
        ctl.MaxDate = CellMaxDate;
        if (this.Value == null)// Use the default row value when Value property is null.
        {
            ctl.EditingControlFormattedValue = ctl.Value = (DateTime)this.DefaultNewRowValue;
        }
        else
        {
            var value = DateTime.Parse(this.Value.ToString());
            if (value.Date <= CellMinDate.Date)
            {
                value = CellMinDate;
            }
            else if (value.Date >= CellMaxDate.Date)
            {
                value = CellMaxDate;
            }
            ctl.EditingControlFormattedValue = ctl.Value = value;
        }
    }
    public override Type EditType // Return the type of the editing control that CalendarCell uses.       
    {
        get { return typeof(CalendarEditingControl); }
    }
    public override Type ValueType// Return the type of the value that CalendarCell contains.
    {
        get { return typeof(DateTime); }
    }
    public override object DefaultNewRowValue// Use the current date and time as the default value.
    {
        get
        {
            if (DateTime.Now.Date < CellMinDate.Date)
                return CellMinDate.Date;
            if (DateTime.Now.Date > CellMaxDate.Date)
                return CellMaxDate.Date;
            return DateTime.Now;

        }
    }
}

[ToolboxBitmap(typeof(DataGridViewColumn))]
internal class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl, IDisposable
{
    DataGridView dataGridView;
    private bool valueChanged = false;
    int rowIndex;

    public CalendarEditingControl()
    {
        this.Format = DateTimePickerFormat.Short;
    }

    // Implements the IDataGridViewEditingControl.EditingControlFormattedValue property.
    public object EditingControlFormattedValue
    {
        get
        {
            return this.Value.ToShortDateString();
        }
        set
        {
            try
            {
                var date = DateTime.Parse(value.ToString());
                if (date.Date < MinDate.Date)
                    this.Value = MinDate;
                else if (date.Date > MaxDate.Date)
                    this.Value = MaxDate;
                else this.Value = date;
            }
            catch
            {
                if (DateTime.Now < MinDate.Date)
                    this.Value = MinDate;
                else if (DateTime.Now > MaxDate.Date)
                    this.Value = MaxDate;
                else this.Value = DateTime.Now;
            }
        }
    }
    // Implements the IDataGridViewEditingControl.GetEditingControlFormattedValue method.
    public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
    {
        return EditingControlFormattedValue;
    }
    // Implements the IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
    public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
    {
        this.Font = dataGridViewCellStyle.Font;
        this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
        this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
    }
    // Implements the IDataGridViewEditingControl.EditingControlRowIndex property.
    public int EditingControlRowIndex
    {
        get { return rowIndex; }
        set { rowIndex = value; }
    }
    // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey method.
    public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
    {
        // Let the DateTimePicker handle the keys listed.
        switch (key & Keys.KeyCode)
        {
            case Keys.Left:
            case Keys.Up:
            case Keys.Down:
            case Keys.Right:
            case Keys.Home:
            case Keys.End:
            case Keys.PageDown:
            case Keys.PageUp:
                return true;
            default:
                return !dataGridViewWantsInputKey;
        }
    }
    // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit method.
    public void PrepareEditingControlForEdit(bool selectAll)
    {
        // No preparation needs to be done.
    }

    // Implements the IDataGridViewEditingControl. RepositionEditingControlOnValueChange property.
    public bool RepositionEditingControlOnValueChange
    {
        get { return false; }
    }

    // Implements the IDataGridViewEditingControl. EditingControlDataGridView property.
    public DataGridView EditingControlDataGridView
    {
        get { return dataGridView; }
        set { dataGridView = value; }
    }

    // Implements the IDataGridViewEditingControl. EditingControlValueChanged property.
    public bool EditingControlValueChanged
    {
        get { return valueChanged; }
        set { valueChanged = value; }
    }

    // Implements the IDataGridViewEditingControl. EditingPanelCursor property.
    public Cursor EditingPanelCursor
    {
        get { return base.Cursor; }
    }

    protected override void OnValueChanged(EventArgs eventargs)
    {
        // Notify the DataGridView that the contents of the cell have changed.
        valueChanged = true;
        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        base.OnValueChanged(eventargs);
    }
}