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

namespace phase_2
{
    public partial class frmMeterReadings : Form
    {
        DataSet ds = new DataSet();
        private string _OpMode;
        private int _BookingPlanID;
        private int _isUpdated;
        private DateTime _ScheduleDate;
        private Boolean _isCalled;
        private Int32 rwB = -1;

        public int BookingPlanID
        {
            get { return _BookingPlanID; }
            set
            {
                _BookingPlanID = value;
                _isCalled = true;
            }
        }
        public DateTime ScheduleDate
        {
            get { return _ScheduleDate; }
            set { _ScheduleDate = value; }
        }
        public frmMeterReadings()
        {
            InitializeComponent();
            _ScheduleDate = DateTime.Today;
            _isCalled = false;
        }
        private void setMasters()
        {
            try
            {
                grdSchedule.IgnoreReadOnly = true;
                grdSchedule[0, 1].Text = "ID";
                grdSchedule[0, 2].Text = "MeterID";
                grdSchedule[0, 3].Text = "Meter Name";
                grdSchedule[0, 4].Text = "ElecMeterUsageId";
                grdSchedule[0, 5].Text = "Usage";
                grdSchedule[0, 6].Text = "FROM";
                grdSchedule[0, 7].Text = "TO";
                grdSchedule[0, 8].Text = "Units";
                grdSchedule[0, 9].Text = "UoM";
                grdSchedule[0, 10].Text = "BookingPlanIn";
                grdSchedule[0, 11].Text = "Production Name";
                grdSchedule[0, 12].Text = "Narration";

                grdSchedule[0, 13].Text = "ACTION";
                grdSchedule[0, 14].Text = "";
                grdSchedule[0, 15].Text = "isMakeupRoom";
                grdSchedule[0, 16].Text = "isRevenueHead";
                grdSchedule[0, 17].Text = "freeUnits";
                grdSchedule.IgnoreReadOnly = false;
                grdSchedule.SetColHidden(1, 2, true);
                grdSchedule.SetColHidden(4, 5, true);
                grdSchedule.SetColHidden(10, 12, true);
                grdSchedule.Model.CoveredRanges.Add(GridRangeInfo.Cells(0, 13, 0, 14));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void populateData(bool changeDate)
        {
            try
            {
                if (changeDate) dtpReadingDate.Value = _ScheduleDate;

                if (_isCalled)
                {
                    dtpReadingDate.Enabled = false;
                }
                else
                {
                    dtpReadingDate.Enabled = true;
                }
                // Set Booking of the day to Dropdown list
                //ds = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "DASH_BookingView '" + _ScheduleDate.ToString("yyyyMMdd") + "'");
                //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                //{
                //    DataRow dr;
                //    dr = ds.Tables[0].NewRow();
                //    dr["CustomerName"] = "---Other---";
                //    dr["BookingPlanId"] = -1;
                //    ds.Tables[0].Rows.Add(dr);
                //    dbcBooking.DisplayMember = "CustomerName";
                //    dbcBooking.ValueMember = "BookingPlanId";
                //    dbcBooking.DataSource = ds.Tables[0];
                //    dbcBooking.Enabled = true;
                //    lblProd.Visible = true;
                //}
                //else
                //{
                //    dbcBooking.Enabled = false;
                //    lblProd.Visible = false;
                //}// Show Meter Readings
                ds = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "getElecMeterReading '" + _ScheduleDate.ToString("yyyyMMdd") + "'");
                int i = 0;
                grdSchedule.IgnoreReadOnly = true;
                if (grdSchedule.Model.RowCount >= 1)
                    grdSchedule.Rows.RemoveRange(1, grdSchedule.Model.RowCount);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdSchedule.Rows.InsertRange(1, ds.Tables[0].Rows.Count);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        grdSchedule.Model[i + 1, 1].Text = i.ToString();

                        grdSchedule.Model[i + 1, 2].Text = Convert.ToString(dr["SetMeterId"]);
                        grdSchedule.Model[i + 1, 3].Text = Convert.ToString(dr["MeterName"]);
                        grdSchedule.Model[i + 1, 4].Text = Convert.ToString(dr["ElecMeterUsageId"]);
                        grdSchedule.Model[i + 1, 5].Text = Convert.ToString(dr["Usage_Purpose"]);
                        grdSchedule.Model[i + 1, 6].Text = Convert.ToString(dr["FromReading"]);
                        grdSchedule.Model[i + 1, 7].Text = Convert.ToString(dr["TOReading"]);
                        grdSchedule.Model[i + 1, 8].Text = Convert.ToString(dr["ReadingUnits"]);
                        grdSchedule.Model[i + 1, 9].Text = "UNITS";
                        grdSchedule.Model[i + 1, 10].Text = Convert.ToString(dr["BookingPlanId"]);
                        grdSchedule.Model[i + 1, 11].Text = Convert.ToString(dr["CustomerName"]);
                        grdSchedule.Model[i + 1, 12].Text = Convert.ToString(dr["Remarks"]);
                        grdSchedule.Model[i + 1, 8].BackColor = System.Drawing.Color.YellowGreen;
                        //grdSchedule.Model[i + 1, 13].CellType = Syncfusion.Windows.Forms.Grid.GridCellTypeName.PushButton;
                        //grdSchedule.Model[i + 1, 13].HorizontalAlignment = GridHorizontalAlignment.Center;
                        //grdSchedule.Model[i + 1, 13].VerticalAlignment = GridVerticalAlignment.Middle;
                        //grdSchedule[i + 1, 13].Description = "EDIT";
                        //grdSchedule[i + 1, 13].TextColor = Color.BlueViolet;
                        //grdSchedule.Model[i + 1, 14].CellType = Syncfusion.Windows.Forms.Grid.GridCellTypeName.PushButton;
                        //grdSchedule.Model[i + 1, 14].HorizontalAlignment = GridHorizontalAlignment.Center;
                        grdSchedule.Model[i + 1, 10].VerticalAlignment = GridVerticalAlignment.Middle;
                        //grdSchedule[i + 1, 14].Description = "ADD";
                        //grdSchedule[i + 1, 14].TextColor = Color.DarkSlateGray;
                        grdSchedule.Model[i + 1, 15].Text = Convert.ToString(dr["isMakeupRoom"]);
                        grdSchedule.Model[i + 1, 17].Text = Convert.ToString(dr["AdjustUnits"]);
                        grdSchedule.Model[i + 1, 18].Text = Convert.ToString(dr["ElecMeterReadingId"]);
                        grdSchedule.Model[i + 1, 19].Text = Convert.ToString(dr["CustomerId"]);

                        grdSchedule.SetColHidden(10, 10, true);
                        // Booking Plan ID called then set rw
                        if (_isCalled) if (dr["BookingPlanId"].ToString() != "")
                                if (Convert.ToInt32(dr["BookingPlanID"]) == _BookingPlanID && rwB == -1) rwB = i + 1;
                        // set all col Disabled
                        for (int j = 2; j <= 12; j++) grdSchedule.Model[i + 1, j].Enabled = false;
                        i++;
                    }
                }
                this.grdSchedule.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(3, 4));
                this.grdSchedule.ColWidths.SetSize(11, 80);
                grdSchedule.SetColHidden(13, 20, true);
                grdSchedule.IgnoreReadOnly = false;
                if (rwB < 0) grdSchedule.CurrentCell.MoveTo(1, 13);
                else showUsage(rwB, 13);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void populateData()
        {
            try
            {
                dtpReadingDate.Value = _ScheduleDate;

                if (_isCalled)
                {
                    dtpReadingDate.Enabled = false;
                }
                else
                {
                    dtpReadingDate.Enabled = true;
                }
                //// Set Booking of the day to Dropdown list
                //ds = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "DASH_BookingView '" + _ScheduleDate.ToString("yyyyMMdd") + "'");
                //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                //{
                //    DataRow dr;
                //    dr = ds.Tables[0].NewRow();
                //    dr["CustomerName"] = "---Other---";
                //    dr["BookingPlanId"] = -1;
                //    ds.Tables[0].Rows.Add(dr);
                //    dbcBooking.DisplayMember = "CustomerName";
                //    dbcBooking.ValueMember = "BookingPlanId";
                //    dbcBooking.DataSource = ds.Tables[0];
                //    dbcBooking.Enabled = true;
                //    lblProd.Visible = true;
                //}
                //else
                //{
                //    dbcBooking.Enabled = false;
                //    lblProd.Visible = false;
                //}// Show Meter Readings
                ds = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "getMeterReading_Morn '" + _ScheduleDate.ToString("yyyyMMdd") + "'");
                int i = 0;
                grdSchedule.IgnoreReadOnly = true;
                if (grdSchedule.Model.RowCount >= 1)
                    grdSchedule.Rows.RemoveRange(1, grdSchedule.Model.RowCount);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdSchedule.Rows.InsertRange(1, ds.Tables[0].Rows.Count);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        grdSchedule.Model[i + 1, 1].Text = i.ToString();

                        grdSchedule.Model[i + 1, 2].Text = Convert.ToString(dr["SetMeterId"]);
                        grdSchedule.Model[i + 1, 3].Text = Convert.ToString(dr["MeterName"]);
                        // grdSchedule.Model[i + 1, 4].Text = Convert.ToString(dr["ElecMeterUsageId"]);
                        // grdSchedule.Model[i + 1, 5].Text = Convert.ToString(dr["Usage_Purpose"]);
                        grdSchedule.Model[i + 1, 6].Text = Convert.ToString(dr["FromReading"]);
                        grdSchedule.Model[i + 1, 7].Text = Convert.ToString(dr["TOReading"]);
                        grdSchedule.Model[i + 1, 8].Text = Convert.ToString(dr["ReadingUnits"]);
                        grdSchedule.Model[i + 1, 9].Text = "UNITS";
                        grdSchedule.Model[i + 1, 12].Text = Convert.ToString(dr["Remarks"]);
                        grdSchedule.Model[i + 1, 10].VerticalAlignment = GridVerticalAlignment.Middle;
                        grdSchedule.Model[i + 1, 17].Text = Convert.ToString(dr["AdjustUnits"]);
                        grdSchedule.Model[i + 1, 18].Text = Convert.ToString(dr["ElecMeterReadingId"]);

                        grdSchedule.SetColHidden(10, 10, true);
                        // set all col Disabled
                        for (int j = 2; j <= 12; j++) grdSchedule.Model[i + 1, j].Enabled = false;

                        // setup TO units as Readable
                        grdSchedule.Model[i + 1, 7].Enabled = true;
                        grdSchedule.Model[i + 1, 7].ReadOnly = false;
                        grdSchedule.Model[i + 1, 7].BackColor = System.Drawing.Color.YellowGreen;
                        i++;
                    }
                }
                this.grdSchedule.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(3, 4));
                this.grdSchedule.ColWidths.SetSize(11, 80);
                grdSchedule.SetColHidden(13, 20, true);
                // grdSchedule.IgnoreReadOnly = false;
                //if (rwB < 0) grdSchedule.CurrentCell.MoveTo(1, 13);
                //else showUsage(rwB, 13);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #region Calculations
        private void clearEntry()
        {
            try
            {
                dtpReadingDate.Value = dtpReadingDate.Value.AddDays(1);
                populateData();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());

            }
        }
        private void MakCalc_Units()
        {
            //try
            //{
            //    if (txtUnitFrom.Text == string.Empty || txtUnitTo.Text == string.Empty || txtUnitTo.Text == "" || txtUnitFrom.Text == "")
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        int f = Convert.ToInt32(txtUnitFrom.Text);
            //        int t = Convert.ToInt32(txtUnitTo.Text);
            //        int fr;
            //        fr = 0;
            //        int q = (t - f) - fr;
            //        if (q < 0)
            //            q = 0;

            //        txtQty.Text = (q + fr).ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            //}
        }

        private void MakCalc_Daily()
        {
            try
            {
                txtDailyTotal.Text = "0";
                int tot = 0;
                for (int i = 1; i <= grdSchedule.RowCount; i++)
                {
                    if (grdSchedule.Model[i, 8].Text != "")
                        tot += Convert.ToInt32(grdSchedule.Model[i, 8].Text);
                }
                txtDailyTotal.Text = Convert.ToString(tot);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        #endregion
        private void frmMeterReadings_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " " + _ScheduleDate.ToString("ddd dd-MMM-yyyy");
            this._isCalled = false;
            setMasters();
            populateData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void showUsage(int rw, int cl)
        {

            //txtRwNo.Text = rw.ToString();
            //txtIsMakeup.Text = grdSchedule.Model[rw, 15].Text;
            //if (grdSchedule.Model[rw, 4].Text != "")
            //{
            //    dbcUsage.Text = (grdSchedule.Model[rw, 5].Text);
            //}
            //txtCharges.Text = grdSchedule.Model[rw, 3].Text;
            //lblUoM.Text = grdSchedule.Model[rw, 9].Text;
            //lblQty.Text = "UNIT";

            //txtUnitFrom.Text = grdSchedule.Model[rw, 6].Text;
            //txtUnitTo.Text = grdSchedule.Model[rw, 7].Text;

            //txtQty.Text = grdSchedule.Model[rw, 8].Text;
            //txtAdj.Text = grdSchedule.Model[rw, 17].Text;
            //if (grdSchedule.Model[rw, 11].Text != "")
            //{
            //    dbcBooking.SelectedValue = grdSchedule.Model[rw, 10].Text;
            //}
            //else
            //{
            //    dbcBooking.Text = "";
            //}
            //txtNarration.Text = grdSchedule.Model[rw, 12].Text;
            //grpEntry.Visible = true;
            //grpEntry.BringToFront();
            //dbcUsage.Focus();
        }
        private void grdSchedule_PushButtonClick(object sender, GridCellPushButtonClickEventArgs e)
        {
            try
            {
                clearEntry();
                int rw = e.RowIndex;
                int cl = e.ColIndex;
                grdSchedule.IgnoreReadOnly = true;
                grdSchedule[rw, cl].BackColor = Color.Yellow;
                grdSchedule.IgnoreReadOnly = false;
                grdSchedule.Selections.Clear();
                grdSchedule.Selections.SelectRange(GridRangeInfo.Rows(rw, rw), true);

                showUsage(rw, cl);

                if (grdSchedule[rw, cl].Description == "DELETE")
                {
                    if (grdSchedule.Model[rw, 6].Text != "")
                    {
                        DialogResult mAns = MessageBox.Show("Are you sure wou want to delete this entry?", "Confirm", MessageBoxButtons.YesNo);
                        if (mAns == DialogResult.Yes)
                        {
                            clearEntry();
                            grdSchedule.IgnoreReadOnly = true;
                            grdSchedule.Model[rw, 4].Text = string.Empty;
                            grdSchedule.Model[rw, 5].Text = string.Empty;
                            grdSchedule.Model[rw, 6].Text = string.Empty;
                            grdSchedule.Model[rw, 8].Text = string.Empty;
                            grdSchedule.Model[rw, 2].Text = "-1";
                            grdSchedule.IgnoreReadOnly = false;
                            MakCalc_Daily();
                            _isUpdated = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }

        }
        #region ApplyEntry
        private bool isValidApply()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void cmdApply_Click(object sender, EventArgs e)
        {
            String strSQL;
            string strCustCode;
            //try
            //{
            //    if (dbcUsage.Text.ToString() == "")
            //        return;
            //    if (!isValidApply())
            //        return;

            //    int rw = Convert.ToUInt16(txtRwNo.Text);

            //    strSQL = "exec save_ElecMeterReading ";
            //    if (grdSchedule.Model[rw, 18].Text == "") strSQL += "  @ElecMeterReadingId = 0";
            //    else strSQL += "  @ElecMeterReadingId = " + grdSchedule.Model[rw, 18].Text;
            //    strSQL += ", @ReadingDate = '" + dtpReadingDate.Value.Date.ToString("yyyyMMdd") + "'";
            //    strSQL += " , @SetMeterID =" + grdSchedule.Model[rw, 2].Text;
            //    strSQL += " , @ElecMeterUsageId =" + dbcUsage.SelectedValue.ToString();
            //    if (dbcBooking.Visible)
            //        strSQL += " , @BookingPlanId =" + dbcBooking.SelectedValue.ToString();
            //    else strSQL += " , @BookingPlanId = null";
            //    //strSQL += " , @ShiftTime =" + grdSchedule.Model[rw, 1].Text;
            //    strSQL += " , @FromReading =" + txtUnitFrom.Text;
            //    strSQL += " , @ToReading =" + txtUnitTo.Text;
            //    strSQL += " , @ReadingUnits =" + txtQty.Text;
            //    strSQL += " , @AdjustUnits = null";
            //    //strSQL += " , @TotalUnits =" + grdSchedule.Model[rw, 1].Text;
            //    strSQL += " , @Remarks = '" + txtNarration.Text + "'";
            //    strSQL += " , @CreatedBy = " + DataContainer.EMP_Code;
            //    if (dbcBooking.Visible)
            //    {
            //        if (grdSchedule.Model[rw, 19].ToString() != "")
            //        {
            //            strSQL += " , @CustomerId = " + grdSchedule.Model[rw, 19].Text;
            //            strCustCode = grdSchedule.Model[rw, 19].Text;
            //        }
            //        else
            //        {
            //            string tSQL;
            //            tSQL = "select CustomerID from vu_bookingPla where BookingPlanid = " + dbcBooking.SelectedValue.ToString();
            //            strCustCode = SqlHelper.ExecuteScalar(clsConnection.conn, CommandType.Text, tSQL).ToString();
            //            strSQL += " , @CustomerId = " + strCustCode;
            //        }
            //    }
            //    if (dbcOther.Visible)
            //    {
            //        strSQL += " , @CustomerId = " + dbcOther.SelectedValue.ToString();
            //        strCustCode = dbcOther.SelectedValue.ToString();
            //    }
            //    SqlHelper.ExecuteNonQuery(clsConnection.connStr, CommandType.Text, strSQL);

            //    grdSchedule.IgnoreReadOnly = true;
            //    grdSchedule.Model[rw, 4].Text = dbcUsage.SelectedValue.ToString();
            //    grdSchedule.Model[rw, 5].Text = dbcUsage.Text;
            //    //grdSchedule.Model[rw, 6].Text = txtUnitFrom.Text.Trim();
            //    grdSchedule.Model[rw, 7].Text = txtUnitTo.Text.Trim();
            //    grdSchedule.Model[rw, 8].Text = txtQty.Text;
            //    if (dbcBooking.Visible)
            //    {
            //        grdSchedule.Model[rw, 10].Text = dbcBooking.SelectedValue.ToString();
            //        grdSchedule.Model[rw, 11].Text = dbcBooking.Text;
            //    }
            //    else
            //    {
            //        grdSchedule.Model[rw, 10].Text = "";
            //        grdSchedule.Model[rw, 11].Text = "";
            //    }

            //    grdSchedule.Model[rw, 12].Text = txtNarration.Text;

            //    grdSchedule.Model[rw, 1].Text = "1";
            //    grdSchedule.Model[rw, 15].Text = txtIsMakeup.Text;
            //    grdSchedule.Model[rw, 16].Text = txtIsMakeup.Text;
            //    grdSchedule.IgnoreReadOnly = false;
            //    // n case of TV free Units are considered in txtAdj

            //    if (txtAdj.Text != "")
            //        if (Convert.ToInt32(txtAdj.Text) > Convert.ToInt32(txtQty.Text))
            //            txtAdj.Text = txtQty.Text;

            //    MakCalc_Daily();
            //    clearEntry();
            //    _isUpdated = -1;
            //    if (rw < grdSchedule.RowCount) grdSchedule.CurrentCell.MoveTo(rw + 1, 13);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //    clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            //}
        }
        #endregion
        #region EntryUnits
        private void txtUnitFrom_TextChanged(object sender, EventArgs e)
        {
            MakCalc_Units();

        }

        private void txtUnitFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            int num = e.KeyChar;
            if (char.IsDigit(e.KeyChar) || num == 8 || num == 46)
            {
                e.Handled = false;
            }
            else //if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        #endregion

        private void btnEntryCancel_Click(object sender, EventArgs e)
        {
            //grpEntry.Visible = false;
        }

        private void btnSelBooking_Click(object sender, EventArgs e)
        { }

        private void btnSelectBooking_Click(object sender, EventArgs e)
        {
        }

        private void grpBookingDetails_VisibleChanged(object sender, EventArgs e)
        {
            //if (grpBookingDetails.Visible)
            //{
            //    // Show Booking Plan Details0
            //    DataSet dsBook = new DataSet();
            //    String strSQL = "SELECT * FROM vu_bookingPlan WHERE BookingPlanId = " + Convert.ToString(_BookingPlanID);
            //    dsBook = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
            //    if (dsBook.Tables.Count > 0 && dsBook.Tables[0].Rows.Count > 0)
            //    {
            //        DataRow dr = dsBook.Tables[0].Rows[0];
            //        lblSetName.Text = Convert.ToString(dr["SetName"]);
            //        lblShootType.Text = Convert.ToString(dr["CategoryName"]);
            //        lblCustomer.Text = Convert.ToString(dr["CustomerName"]);
            //        lblBookingRef.Text = Convert.ToString(dr["RefNo"]);
            //        lblBookingDate.Text = Convert.ToDateTime(dr["BookingDate"]).ToString("dd-MM-yyyy");
            //        lblFromDate.Text = Convert.ToDateTime(dr["BookingFromDate"]).ToString("dd-MM-yyyy");
            //        lblToDate.Text = Convert.ToDateTime(dr["BookingToDate"]).ToString("dd-MM-yyyy");
            //        lblShiftTime.Text = Convert.ToString(dr["ShiftTime"]);
            //        lblDays.Text = Convert.ToString(dr["TotalShifts"]);
            //    }

            //}

        }

        private void dtpReadingDate_Validated(object sender, EventArgs e)
        {
            _ScheduleDate = dtpReadingDate.Value.Date;
            _isCalled = false;
            populateData();
        }

        private void dtpReadingDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpReadingDate.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Reading date cannot be future date");
                e.Cancel = true;
            }
        }

        private void grdSchedule_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtAdj_Validated(object sender, EventArgs e)
        {
            // if (txtIsRevenue.Text == "") txtIsRevenue.Text = "0";
        }

        private void dbcUsage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            //    ds = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "select isRevenueHead from ElecMeterUsage where ElecMeterUsageId = " + dbcUsage.SelectedValue.ToString());
            //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //    {
            //        txtIsRevenue.Text = ds.Tables[0].Rows[0]["isRevenueHead"].ToString();
            //    }
            //    else txtIsRevenue.Text = "0";
            //    if (txtIsRevenue.Text == "1")
            //    {
            //        dbcBooking.Visible = true;
            //        dbcBooking.Enabled = true;
            //        lblProd.Visible = true;
            //    }
            //    else
            //    {
            //        dbcOther.Enabled = false;
            //        dbcOther.Visible = false;
            //        dbcBooking.Visible = false;
            //        dbcBooking.Enabled = false;
            //        lblProd.Visible = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //    throw ex;
            //}
        }

        private void dbcBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string strSQL;
            //try
            //{
            //    if (dbcBooking.Text == "---Other---")
            //    {
            //        strSQL = "get_CustomerName";
            //        DataSet dsc = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
            //        if (dsc.Tables.Count > 0 && dsc.Tables[0].Rows.Count > 0)
            //        {
            //            dbcOther.SuspendLayout();
            //            dbcOther.DisplayMember = "CustomerName";
            //            dbcOther.ValueMember = "CustomerID";
            //            dbcOther.DataSource = dsc.Tables[0];
            //            dbcOther.Top = dbcBooking.Top;
            //            dbcOther.Left = dbcBooking.Left;
            //            dbcOther.Visible = true;
            //            dbcOther.Enabled = true;
            //            dbcBooking.Visible = false;
            //            lblProd.Visible = false;
            //            dbcOther.ResumeLayout();
            //        }
            //        else
            //        {
            //            dbcOther.Visible = false;
            //            dbcBooking.Visible = true;
            //            lblProd.Visible = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string strSQL;
            try
            {
                for (int rw = 1; rw <= grdSchedule.RowCount; rw++)
                {
                    if (grdSchedule.Model[rw, 7].Text != "")
                    {
                        strSQL = "exec save_ElecMeterReadingMorn ";
                        if (grdSchedule.Model[rw, 18].Text == "") strSQL += "  @ElecMeterReadingId = 0";
                        else strSQL += "  @ElecMeterReadingId = " + grdSchedule.Model[rw, 18].Text;
                        strSQL += ", @ReadingDate = '" + dtpReadingDate.Value.Date.ToString("yyyyMMdd") + "'";
                        strSQL += " , @SetMeterID =" + grdSchedule.Model[rw, 2].Text;
                        //strSQL += " , @ElecMeterUsageId =" + grdSchedule.Model[rw, 4].Text;
                        //strSQL += " , @BookingPlanId =" + grdSchedule.Model[rw, 10].Text;
                        //strSQL += " , @ShiftTime =" + grdSchedule.Model[rw, 1].Text;
                        strSQL += " , @FromReading =" + grdSchedule.Model[rw, 6].Text;
                        strSQL += " , @ToReading =" + grdSchedule.Model[rw, 7].Text;
                        strSQL += " , @ReadingUnits =" + grdSchedule.Model[rw, 8].Text;
                        strSQL += " , @AdjustUnits =" + grdSchedule.Model[rw, 17].Text;
                        //strSQL += " , @TotalUnits =" + grdSchedule.Model[rw, 1].Text;
                        strSQL += " , @Remarks = '" + grdSchedule.Model[rw, 12].Text + "'";
                        strSQL += " , @CreatedBy = 1"; // TO-DO user IF

                        SqlHelper.ExecuteNonQuery(clsConnection.connStr, CommandType.Text, strSQL);
                    }
                }
                MessageBox.Show("Data saved successfully", Application.ProductName, MessageBoxButtons.OK);
                clearEntry();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void grpEntry_Enter(object sender, EventArgs e)
        {

        }

        private void txtAdj_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // creating Excel Application
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                workbook.SaveAs("Reading" + dtpReadingDate.Value.Date.ToString("yyyyMMdd"));
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Schedule" + dtpReadingDate.Value.Date.ToString("yyyyMMdd");
                // storing header part in Excel  
                int xlCol = 1;
                int cl;
                int rw;
                for (cl = 0; cl <= grdSchedule.Model.ColCount; cl++)
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
                    for (cl = 0; cl <= grdSchedule.Model.ColCount; cl++)
                    {
                        if (!grdSchedule.GetColHidden(cl))
                        {
                            worksheet.Cells[rw + 1, xlCol + 1] = grdSchedule.Model[rw, cl].Text;// cl.ToString() + '-' + xlCol.ToString(); 
                            if (cl >= 6 && cl <= 8)
                            {
                                worksheet.Cells[rw, xlCol + 1].Numberformat = "@";
                            }
                            xlCol++;
                        }
                    }
                }
                for (cl = 1; cl <= xlCol; cl++)
                {
                    ///if (!grdSchedule.GetColHidden(cl))
                    {
                        worksheet.Columns[cl].EntireColumn.Autofit();// cl.ToString() + '-' + xlCol.ToString(); 

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dtpReadingDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void grdSchedule_CurrentCellAcceptedChanges(object sender, CancelEventArgs e)
        {
            try
            {
                int cl = grdSchedule.CurrentCell.ColIndex;
                int rw = grdSchedule.CurrentCell.RowIndex;
                grdSchedule[rw, cl + 1].CellValue = Convert.ToDouble(grdSchedule[rw, cl].CellValue.ToString()) - Convert.ToDouble(grdSchedule[rw, cl - 1].CellValue.ToString());
                if (Convert.ToDouble(grdSchedule[rw, cl + 1].CellValue) < 0)
                {
                    MessageBox.Show("TO Units are less than FROM units\nPlease correct", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data is not in proper format");
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete entry of " + dtpReadingDate.Value.Date.ToString("ddd dd/MMM/yyyy") + "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string strSQL = "delete from ElecMeterReadingMorn where ReadingDate = '" + dtpReadingDate.Value.Date.ToString("yyyyMMdd") + "'";
                SqlHelper.ExecuteNonQuery(clsConnection.connStr, CommandType.Text, strSQL);
                populateData();
            }

        }
    }
}