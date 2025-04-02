using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phase_2
{
    public partial class frmMakeupRoomUsage : Form
    {
        DataSet ds = new DataSet();
        private string _OpMode;
        private int _BookingPlanID;
        private int _isUpdated;
        private DateTime _ScheduleDate;
        private Boolean _isCalled;
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


        private void setMasters()
        {
            try
            {
                grdSchedule.IgnoreReadOnly = true;
                grdSchedule[0, 1].Text = "ID";
                grdSchedule[0, 2].Text = "MakeupRoom Location";
                grdSchedule[0, 3].Text = "Room No";
                grdSchedule[0, 4].Text = "Occupied?";
                grdSchedule[0, 5].Text = "Narration";

                grdSchedule[0, 9].Text = "ACTION";
                grdSchedule[0, 6].Text = "Used By";
                grdSchedule[0, 7].Text = "BookingPlanID";
                grdSchedule[0, 8].Text = "NormalShift";
                grdSchedule.SetColHidden(1, 1, true);
              grdSchedule.SetColHidden(7, 20, true); // TO-DO : Col hidden change 
                grdSchedule.SetColWidth(5, 6, 120);
                grdSchedule.IgnoreReadOnly = false;
                // Show Booking Plan Details0
                DataSet dsBook = new DataSet();
                String strSQL = "SELECT * FROM vu_bookingPlan WHERE BookingPlanId = " + Convert.ToString(_BookingPlanID);
                dsBook = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                if (dsBook.Tables.Count > 0 && dsBook.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsBook.Tables[0].Rows[0];
                    lblSetName.Text = Convert.ToString(dr["SetName"]);
                    lblShootType.Text = Convert.ToString(dr["CategoryName"]);
                    lblCustomer.Text = Convert.ToString(dr["CustomerName"]);
                    lblBookingRef.Text = Convert.ToString(dr["RefNo"]);
                    lblBookingDate.Text = Convert.ToDateTime(dr["BookingDate"]).ToString("dd-MM-yyyy");
                    lblFromDate.Text = Convert.ToDateTime(dr["BookingFromDate"]).ToString("ddd dd-MMM-yyyy");
                    lblToDate.Text = Convert.ToDateTime(dr["BookingToDate"]).ToString("ddd dd-MMM-yyyy");
                    lblShiftTime.Text = Convert.ToString(dr["ShiftTime"]);
                    lblDays.Text = Convert.ToString(dr["TotalShifts"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public frmMakeupRoomUsage()
        {
            InitializeComponent();
            _ScheduleDate = DateTime.Today;
            _isCalled = false;
        }
        private void fillGrid()
        {
            try
            {
                dtpScheduleDate.Value = _ScheduleDate;
                dtpShiftDate.Value = _ScheduleDate;
                if (_isCalled)
                {
                    dtpShiftDate.Enabled = false;
                    dtpScheduleDate.Enabled = false;
                }
                else
                {
                    dtpShiftDate.Enabled = true;
                    dtpScheduleDate.Enabled = true;
                }
                grdSchedule.IgnoreReadOnly = true;
                if (grdSchedule.Model.RowCount >= 1)
                    grdSchedule.Rows.RemoveRange(1, grdSchedule.Model.RowCount);
                ds = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_MakeupRoomMaster '" + _ScheduleDate.ToString("yyyyMMdd") + "'");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int tot = 0;
                    int totBooking = 0;
                    int totCharged = 0;
                    int totFree = 0;
                    int rw = 1;
                    StringCollection mkType = new StringCollection();
                    mkType.Add("Free");
                    mkType.Add("Paid");
                    grdSchedule.Rows.InsertRange(1, ds.Tables[0].Rows.Count);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        grdSchedule.Model[rw, 1].Text = Convert.ToString(dr["MakeupRoomId"]);
                        grdSchedule[rw, 1].Enabled = false;
                        grdSchedule[rw, 2].Text = Convert.ToString(dr["MakeupRoomArea"]);
                        grdSchedule[rw, 2].Enabled = false;
                        grdSchedule[rw, 3].Text = Convert.ToString(dr["MakeupRoomNo"]);
                        grdSchedule[rw, 3].Enabled = false;
                        grdSchedule[rw, 4].CellType = Syncfusion.Windows.Forms.Grid.GridCellTypeName.ComboBox;
                        grdSchedule[rw, 4].DropDownStyle = Syncfusion.Windows.Forms.Grid.GridDropDownStyle.Exclusive;
                        grdSchedule[rw, 4].ChoiceList = mkType;

                        if (Convert.ToString(_BookingPlanID) == Convert.ToString(dr["BookingPlanId"]) || Convert.ToString(dr["BookingPlanID"]) == "")
                        {
                            
                            grdSchedule[rw, 4].Enabled = true;
                            grdSchedule[rw, 10].Text = "1";
                            grdSchedule[rw, 4].BackColor = Color.GreenYellow;
                            // Calc Booking Rooms
                            if ( ! (dr["isNormalShift"] is DBNull))
                            {
                                if (Convert.ToInt16(dr["isNormalShift"]) == 1) totCharged += 1;
                                else if (Convert.ToInt16(dr["isNormalShift"]) == 0) totFree += 1;
                                totBooking++;
                            }
                        }
                        else
                        {
                            
                            grdSchedule[rw, 4].Enabled = false;
                        }
                        grdSchedule[rw, 4].Text = Convert.ToString(dr["UsageType"]);
                        grdSchedule[rw, 5].Text = Convert.ToString(dr["Narration"]);
                        if (grdSchedule[rw, 4].Enabled) grdSchedule[rw, 5].Enabled = true;
                        else grdSchedule[rw, 5].Enabled = false;

                        grdSchedule[rw, 6].Text = Convert.ToString(dr["CustomerName"]);
                        grdSchedule[rw, 6].Enabled = false;
                        grdSchedule[rw, 7].Text = Convert.ToString(dr["BookingPlanId"]);
                        grdSchedule[rw, 7].Enabled = false;
                        grdSchedule[rw, 8].Text = Convert.ToString(dr["isNormalShift"]);
                        grdSchedule[rw, 8].Enabled = false;
                        grdSchedule[rw, 9].Text = Convert.ToString(dr["MakeupRoomUsageId"]);
                        if (Convert.ToInt32(dr["MakeupRoomUsageID"]) != 0) tot++;
                        rw++;
                    }
                    this.grdSchedule.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(2, 3));
                    grdSchedule.IgnoreReadOnly = false;
                    txtDailyTotal.Text = Convert.ToString(tot);
                    txtBookingTotal.Text = Convert.ToString(totBooking);
                    txtCharged.Text = Convert.ToString(totCharged);
                    txtFree.Text = Convert.ToString(totFree);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw;
            }
        }
        private void frmMakeupRoomUsage_Load(object sender, EventArgs e)
        {
            setMasters();
            fillGrid();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            String strSQL = "";
            try
            {
                for (int rw = 1; rw <= grdSchedule.RowCount; rw++)
                {
                    if (Convert.ToString( _BookingPlanID) == Convert.ToString(grdSchedule[rw, 7].Text))
                    {
                        strSQL = "exec save_MakeupRoomUsage ";
                        strSQL += "@MakeupRoomUsageID = " + grdSchedule.Model[rw, 9].Text;
                        strSQL += ", @ScheduleDate = '" + _ScheduleDate.ToString("yyyyMMdd") + "'";
                        strSQL += ", @MakeupRoomID = " + grdSchedule.Model[rw, 1].Text;
                        strSQL += ", @BookingPlanID = " + grdSchedule.Model[rw, 7].Text;
                        strSQL += ", @isNormalShift = " + grdSchedule.Model[rw, 8].Text;
                        strSQL += ", @Narration = '" + grdSchedule.Model[rw, 5].Text + "'";
                        strSQL += ", @isActive = " + grdSchedule.Model[rw, 10].Text;
                        strSQL += ", @CreatedBy = 1";
                        SqlHelper.ExecuteNonQuery(clsConnection.connStr, CommandType.Text, strSQL) ;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void grdSchedule_CurrentCellAcceptedChanges(object sender, CancelEventArgs e)
        {
            int tot = 0;
            int totBooking = 0;
            int totCharged = 0;
            int totFree = 0;
            if (grdSchedule[grdSchedule.CurrentCell.RowIndex, 4].Text != "")
            {
                if (Convert.ToString(grdSchedule[grdSchedule.CurrentCell.RowIndex, 7].Text) == "")
                {
                    grdSchedule[grdSchedule.CurrentCell.RowIndex, 7].Text = Convert.ToString(_BookingPlanID);
                    grdSchedule[grdSchedule.CurrentCell.RowIndex, 6].Text = lblCustomer.Text;
                    grdSchedule[grdSchedule.CurrentCell.RowIndex, 10].Text = "1";
                }
                if (grdSchedule[grdSchedule.CurrentCell.RowIndex, 4].Text.ToUpper() == "PAID") grdSchedule[grdSchedule.CurrentCell.RowIndex, 8].Text = "1";
                else grdSchedule[grdSchedule.CurrentCell.RowIndex, 8].Text = "0";
            }
            else if (Convert.ToString(grdSchedule[grdSchedule.CurrentCell.RowIndex, 7].Text) != "")
            {// if editing existing data
                if (Convert.ToString(grdSchedule[grdSchedule.CurrentCell.RowIndex, 9].Text) == "0")
                {
                    grdSchedule[grdSchedule.CurrentCell.RowIndex, 7].Text = "";
                    grdSchedule[grdSchedule.CurrentCell.RowIndex, 6].Text = "";
                    grdSchedule[grdSchedule.CurrentCell.RowIndex, 8].Text = "0";
                } else { grdSchedule[grdSchedule.CurrentCell.RowIndex, 10].Text = "0"; }
            }

            for (int i = 1; i <= grdSchedule.RowCount; i++)
            {
                if (grdSchedule[i, 4].Text != "")
                {
                    tot++;
                    if (Convert.ToString(_BookingPlanID) == Convert.ToString(grdSchedule[i, 7].Text))
                    {
                        if (grdSchedule[i, 4].Text.ToUpper() == "PAID") totCharged += 1;
                        else if (grdSchedule[i, 4].Text.ToUpper() == "FREE") totFree += 1;
                        totBooking++;
                    }
                }
            }
            txtDailyTotal.Text = Convert.ToString(tot);
            txtBookingTotal.Text = Convert.ToString(totBooking);
            txtCharged.Text = Convert.ToString(totCharged);
            txtFree.Text = Convert.ToString(totFree);
        }

        private void grdSchedule_CellMouseHover(object sender, Syncfusion.Windows.Forms.Grid.GridCellMouseEventArgs e)
        {
            // Booking details to show
            if (grdSchedule.CurrentCell.ColIndex == 6) grpBookingDetails.Visible = true;
            else grpBookingDetails.Visible = false;
        }
    }
}