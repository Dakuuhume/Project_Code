using Syncfusion.Windows.Forms.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Licensing;
//using Syncfusion.Grid.Windows;
//using Syncfusion.Shared.Base;
//using Syncfusion.DocIO.WinForms;
//using System.Windows.Forms.PropertyGridInternal;



namespace phase_2
{
    public partial class frmBookingSchedule : Form
    {
        DataTable dtMaster = new DataTable();
        DataSet ds;
        System.DateTime selBookingDate;
        public frmBookingSchedule()
        {
            InitializeComponent();
        }
        private void getMaster()
        {
            try
            {
                dtMaster = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_SetMaster").Tables[0];
                int i = 1;
                foreach (DataRow dr in dtMaster.Rows)
                {
                    CheckBox chk = new CheckBox();
                    chk.Appearance = System.Windows.Forms.Appearance.Button;
                    chk.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    //chk.Checked = false;
                    chk.CheckState = CheckState.Unchecked;
                    chk.BackColor = System.Drawing.SystemColors.Control;
                    chk.ForeColor = SystemColors.ControlText;
                    chk.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                    chk.Location = new System.Drawing.Point(9, 136 + (28 * (i) + 20));
                    chk.Name = "set" + Convert.ToString(dr["Setid"]).PadLeft(2, '0');
                    chk.Size = new System.Drawing.Size(170, 28);
                    chk.TabIndex = 20;
                    chk.Text = Convert.ToString(dr["SetName"]);
                    chk.Tag = Convert.ToString(dr["Setid"]);
                    chk.UseVisualStyleBackColor = true;
                    this.chkSet01.CheckedChanged += new System.EventHandler(this.chkSet01_CheckedChanged);
                    this.groupBox1.Controls.Add(chk);
                    i++;
                }
                grdSchedule.IgnoreReadOnly = true;
                grdSchedule.Model[0, 1+2].Text = "SetName";
                grdSchedule.Model[0, 2+2].Text = "Shift Time";  //';
                grdSchedule.Model[0, 3+2].Text = "Hirer and Contact"; // ;
                grdSchedule.Model[0, 4-3].Text = "";
                grdSchedule.Model[0, 5-3].Text = "";
                grdSchedule.Model[0, 6].Text = "Schedule Dates\nRemaining Days"; // 
                grdSchedule.RowHeights[0] += 5;
                
                grdSchedule[0, 4-3].Text = "METER READING";
                grdSchedule[0, 5-3].Text = "MAKE-UP ROOMS";
                grdSchedule[0, 10].Text = "BookingPlanId";
                grdSchedule.Model[0, 7].Text = "Activity";
                grdSchedule.Model[0, 8].Text = "Instructions"; 
                grdSchedule.Model[0, 9].Text = "BookingStatus";
                grdSchedule.IgnoreReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        private void fillSchedule()
        {
            try
            {
                DataSet dsTemp ;
                string strsql, dlyActivity;
                GridStyleInfo subheaderstyle = new GridStyleInfo();
                subheaderstyle.Font.Bold = true;
                subheaderstyle.VerticalAlignment = GridVerticalAlignment.Middle;
                subheaderstyle.CellType = GridCellTypeName.Static;
               
//                subheaderstyle.BackColor = Color.LightGray;

                foreach (Control chk in groupBox1.Controls)
               { if (chk.GetType().ToString().Contains("CheckBox"))
                    {
                        ((CheckBox)chk).CheckState = CheckState.Unchecked;
                        chk.BackColor = System.Drawing.SystemColors.Control;
                        chk.ForeColor = SystemColors.ControlText;
                    }
                }

                //ds = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "DASH_BookingView '" + dtpBookingDate.Value.Date.ToString("yyyyMMdd") + "'");
                ds = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "DASH_BookingView '" + dtpMonth.SelectionRange.Start.ToString("yyyyMMdd") + "'");

                int rw = 0;
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (grdSchedule.Model.RowCount >= 1)
                        grdSchedule.Rows.RemoveRange(1, grdSchedule.Model.RowCount);

                    grdSchedule.Rows.InsertRange(1, ds.Tables[0].Rows.Count);

                    grdSchedule.IgnoreReadOnly = true;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        strsql = "select bs.BookingPlanId ";
                        strsql += ", c.ChargesId ";
                        strsql += ", bs.ChargesId ";
                        strsql += ", c.ChargesName";
                        strsql += " from BookingSchedule bs";
                        strsql += " inner join Charges c on bs.ChargesId = c.ChargesId ";
                        strsql += " where bs.BookingPlanId = " + dr["BookingPlanId"].ToString();
                        strsql += " and bs.scheduleDate = '" + dtpMonth.SelectionRange.Start.ToString("yyyyMMdd") + "'";
                           
                        dsTemp = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strsql);
                        if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                        {
                            dlyActivity = Convert.ToString(dsTemp.Tables[0].Rows[0]["ChargesName"]);
                        }
                        else dlyActivity = string.Empty;

                        grdSchedule.Model[rw + 1, 4-3].CellType = Syncfusion.Windows.Forms.Grid.GridCellTypeName.PushButton;
                        grdSchedule.Model[rw + 1, 4-3].HorizontalAlignment = GridHorizontalAlignment.Center;
                        grdSchedule.Model[rw + 1, 4-3].VerticalAlignment = GridVerticalAlignment.Middle;
                        grdSchedule[rw + 1, 4-3].Description = "METER READING";
                        grdSchedule[rw + 1, 4-3].TextColor = Color.OrangeRed;
                        grdSchedule.Model[rw + 1, 5-3].CellType = Syncfusion.Windows.Forms.Grid.GridCellTypeName.PushButton;
                        grdSchedule.Model[rw + 1, 5-3].HorizontalAlignment = GridHorizontalAlignment.Center;
                        grdSchedule.Model[rw + 1, 5-3].VerticalAlignment = GridVerticalAlignment.Middle;
                        grdSchedule[rw + 1, 5-3].Description = "MAKE-UP ROOMS";
                        grdSchedule[rw + 1, 5-3].TextColor = Color.DarkViolet;

                        grdSchedule[rw + 1, 1+2] = subheaderstyle;
                        //grdSchedule[rw + 1, 5-3] = subheaderstyle;
                        grdSchedule[rw + 1, 7] = subheaderstyle;
                        grdSchedule.Model[rw + 1, 1+2].Text = Convert.ToString(dr["SetName"]);
                        grdSchedule.Model[rw + 1, 2+2].Text = Convert.ToString(dr["ShiftTime"]);
                        grdSchedule.Model[rw + 1, 3+2].Text = Convert.ToString(dr["CustomerName"]) + "\n" + Convert.ToString(dr["EnquiryContactPerson"]) + "\n" + Convert.ToString(dr["EnquiryContactPhone"]);
                        grdSchedule[rw + 1, 10].Text = Convert.ToString(dr["BookingPlanId"]);

                        grdSchedule.Model[rw + 1, 7].Text = dlyActivity;// + "\n" + Convert.ToString(dr["RefNo"]);

                        grdSchedule.Model[rw + 1, 6].Text = Convert.ToString(dr["BookingFromDate"]) + "\n" + Convert.ToString(dr["BookingtoDate"]) + "\n" + Convert.ToString(dr["TotalShifts"]);
                        grdSchedule.Model[rw + 1, 8].Text = Convert.ToString(dr["Instructions"]);
                        grdSchedule.Model[rw + 1, 9].Text = Convert.ToString(dr["BookingStatus"]);
                        grdSchedule.Model[rw + 1, 2+2].WrapText = true;
                        grdSchedule.Model[rw + 1, 6].WrapText = true;
                        grdSchedule.Model[rw + 1, 2+2].AutoFit = Syncfusion.Windows.Forms.Grid.AutoFitOptions.Both;
                        grdSchedule.RowHeights[(rw + 1)] = 65;
               
                        grdSchedule.SetColWidth(7, 7, 100);
                        grdSchedule.SetColWidth(6, 6, 100);
                        grdSchedule.SetColWidth(1+2, 1+2, 120);
                        grdSchedule.SetColWidth(3+2, 3+2, 200);
                        grdSchedule.SetColWidth(8, 8, 200);
                        foreach (Control chk in groupBox1.Controls)
                        {
                            if (chk.Text.StartsWith(Convert.ToString(dr["SetName"])))
                            {
                                ((CheckBox)chk).CheckState = CheckState.Checked;
                                chk.BackColor =System.Drawing.Color.DarkRed;
                                chk.ForeColor =System.Drawing.Color.White ;
                            }

                        }
                        rw++;
                    }
                    //grdSchedule.Cols.FreezeRange(1 + 3, 2 + 3);
                    grdSchedule.SetColHidden(9, 10, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {


        }

        private void frmBookingSchedule_Load(object sender, EventArgs e)
        {
            getMaster();
            fillSchedule();
        }

        private void chkSet01_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtpBookingDate_Validated(object sender, EventArgs e)
        {
            fillSchedule();
        }

        private void dtpBookingDate_ValueChanged(object sender, EventArgs e)
        {
            fillSchedule();
        }

        private void dtpMonth_DateSelected(object sender, DateRangeEventArgs e)
        {
            selBookingDate = e.Start.Date;
            fillSchedule();
        }
        private void dtpMonth_DateChanged(object sender, DateRangeEventArgs e)
        {
            selBookingDate = e.Start.Date;
            fillSchedule();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
#region " OPEN Form from GRID "
        private bool clickFunction(object stryChild)
        {
            foreach (Form fc in this.MdiParent.MdiChildren)
            {
                if (fc != null)
                {
                    if (fc.Name == stryChild.GetType().Name)
                    {
                        fc.TopMost = true;
                        fc.Activate();
                        return false;
                    }
                }
            }
            return true;
        }

        private void grdSchedule_PushButtonClick(object sender, GridCellPushButtonClickEventArgs e)
        {
            clsGeneric genCode = new clsGeneric();
            try
            {
                int rw = e.RowIndex;
                int cl = e.ColIndex;
                
                if (cl == 4-3) 
                {
                    if (genCode.hasRights("ALL-METERS", DataContainer.EMP_ROLE) == true)
                    {
                        frmMeterReadings fr = new frmMeterReadings();
                        if (clickFunction(fr) == false)
                        {
                            return;
                        }
                        fr.StartPosition = FormStartPosition.Manual;
                        fr.Location = new Point(0, 0);
                        fr.MdiParent = this.MdiParent;
                        fr.Icon = this.Icon;
                        fr.TopMost = true;
                        fr.ScheduleDate = selBookingDate;
                        fr.BookingPlanID = Convert.ToInt32( grdSchedule.Model[rw, 10].Text);
                        fr.Show();
                    }
                    else
                        MessageBox.Show("Access denied");
                }
                if (cl == 5-3)
                {
                    if (genCode.hasRights("ROOM-USAGE", DataContainer.EMP_ROLE) == true)
                    {
                        frmMakeupRoomUsage fr = new frmMakeupRoomUsage();
                        if (clickFunction(fr) == false)
                        {
                            return;
                        }
                        fr.StartPosition = FormStartPosition.Manual;
                        fr.Location = new Point(0, 0);
                        fr.MdiParent = this.MdiParent;
                        fr.Icon = this.Icon;
                        fr.TopMost = true;
                        fr.ScheduleDate = selBookingDate;
                        fr.BookingPlanID = Convert.ToInt32(grdSchedule.Model[rw, 10].Text);
                        fr.Show();
                    }
                    else
                        MessageBox.Show("Access denied");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void grdSchedule_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                grdSchedule.RaisePushButtonClick(grdSchedule.CurrentCell.RowIndex, 4-3);
                e.Handled = false;
            }
        }

        private void btnMeterPlain_Click(object sender, EventArgs e)
        {
            clsGeneric genCode = new clsGeneric();

            if (genCode.hasRights("ALL-METERS", DataContainer.EMP_ROLE) == true)
            {
                frmMeterReadings fr = new frmMeterReadings();
                if (clickFunction(fr) == false)
                {
                    return;
                }
                fr.StartPosition = FormStartPosition.Manual;
                fr.Location = new Point(0, 0);
                fr.MdiParent = this.MdiParent;
                fr.Icon = this.Icon;
                fr.TopMost = true;
                fr.ScheduleDate = dtpMonth.SelectionRange.Start.Date;
                //fr.BookingPlanID = Convert.ToInt32(grdSchedule.Model[rw, 10].Text);
                fr.Show();
            }
            else
                MessageBox.Show("Access denied");
        }
        #region " Export To Excel"
        private void btnExport_Click(object sender, EventArgs e)
        {
            // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            workbook.SaveAs("Report " + dtpMonth.SelectionRange.Start.ToString("yyyyMMdd"));
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Schedule" + dtpMonth.SelectionRange.Start.ToString("yyyyMMdd");
            // storing header part in Excel  
            int xlCol = 1;
            int cl;
            int rw;
            for (cl = 3; cl <= grdSchedule.Model.ColCount; cl++)
            {
                if (!grdSchedule.GetColHidden(cl))
                {
                    worksheet.Cells[1, xlCol] = grdSchedule.Model[0, cl].Text;
                    worksheet.Cells[1, xlCol].Font.Bold = true;
                    worksheet.Cells[1, xlCol].Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                    xlCol++;
                }
            }
            // storing Each row and column value to excel sheet  

            for (rw = 1; rw <= grdSchedule.Model.RowCount; rw++)
            {
                xlCol = 0;
                for (cl = 3; cl <= grdSchedule.Model.ColCount; cl++)
                {
                    if (!grdSchedule.GetColHidden(cl))
                    {
                        worksheet.Cells[rw + 1, xlCol + 1] = grdSchedule.Model[rw, cl].Text;// cl.ToString() + '-' + xlCol.ToString(); 
                        if (cl == 22)
                        {
                            worksheet.Cells[rw, xlCol + 1].Numberformat = "@";
                        }
                        xlCol++;
                    }
                }
            }
            worksheet.Range["A1:G" + grdSchedule.Model.RowCount.ToString()].EntireColumn.AutoFit();
            worksheet.Range["A1:G" + grdSchedule.Model.RowCount.ToString()].EntireRow.AutoFit();
        }
        #endregion

        private void grdSchedule_CurrentCellChanged(object sender, EventArgs e)
        {

        }
    }
    #endregion
}
