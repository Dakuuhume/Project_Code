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
    public partial class frmMeterReadingEntry : Form
    {
        string strSQL;
        private string _ReadingDate;
        private Int16 _locationId;
        private int _BookingPlanId;
        private string _CustomerId;
        int btn_No;
        public frmMeterReadingEntry()
        {
            InitializeComponent();
        }
        #region Properties
        public Int16 ReadingLocationId { get { return _locationId; } set { _locationId = value; } }
        public string ReadingDate { get { return _ReadingDate; } set { _ReadingDate = value; } }
        public int BookingPlanId
        {
            get { return _BookingPlanId; }
            set
            {
                _BookingPlanId = value;
                string tSQL;
                tSQL = "select CustomerID from vu_bookingPla where BookingPlanid = " + _BookingPlanId.ToString();
                _CustomerId = SqlHelper.ExecuteScalar(clsConnection.conn, CommandType.Text, tSQL).ToString();
            }
        }
        public int SelectedButton { get { return btn_No; } set { btn_No = value; btn_Clicked(); } }
        #endregion
        #region MasterSet
        private void setMasters()
        {
            try
            {
                DataSet ds;
                dtpReadingDate.Value = Convert.ToDateTime(_ReadingDate);
                // set Usage
                DataSet dsUsage = new DataSet();
                dsUsage = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "getElecMeterUsage");
                if (dsUsage.Tables.Count > 0 && dsUsage.Tables[0].Rows.Count > 0)
                {
                    dbcUsage.DisplayMember = "purpose_desc";
                    dbcUsage.ValueMember = "ElecMeterUsageId";
                    dbcUsage.DataSource = dsUsage.Tables[0];
                    dbcUsage.Refresh();
                    dbcUsage.SelectedIndex = -1;
                }
                // get_SubMeterReading GRID HIDDEN TO manage DATA
                DataSet dsSubMeters = new DataSet();
                strSQL = "get_SubMeterReading @LocationID = " + _locationId + ", @ReadingDate = '" + _ReadingDate + "'";
                dsSubMeters = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);

                if (grdSubMeters.Model.RowCount >= 1)
                    grdSubMeters.Rows.RemoveRange(1, grdSubMeters.Model.RowCount);

                if (dsSubMeters.Tables.Count > 0 && dsSubMeters.Tables[0].Rows.Count > 0)
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
                    grdSchedule[0, 10].Text = "BookingPlanId";
                    grdSchedule[0, 11].Text = "Production Name";
                    grdSchedule[0, 12].Text = "Narration";

                    grdSchedule[0, 13].Text = "ACTION";
                    grdSchedule[0, 14].Text = "";
                    grdSchedule[0, 15].Text = "isMakeupRoom";
                    grdSchedule[0, 16].Text = "isRevenueHead";
                    grdSchedule[0, 17].Text = "freeUnits";
                    grdSchedule.IgnoreReadOnly = false;
                    grdSchedule.SetColHidden(1, 4, true);
                    grdSchedule.SetColHidden(9, 10, true);
                    grdSchedule.SetColHidden(13, 20, true);
                    grdSchedule[0, 6].HorizontalAlignment = GridHorizontalAlignment.Right;
                    grdSchedule[0, 7].HorizontalAlignment = GridHorizontalAlignment.Right;
                    grdSchedule[0, 8].HorizontalAlignment = GridHorizontalAlignment.Right;
                    grdSchedule.SetColWidth(6, 8, 55);
                    // UPDATE Submeters Grid and Prepare Controls of the METER Board
                    grdSubMeters.IgnoreReadOnly = true;
                    grdSubMeters.Model[0, 1].Text = "SetMeterID";
                    grdSubMeters.Model[0, 2].Text = "MeterName";
                    grdSubMeters.Model[0, 3].Text = "StartReading";
                    grdSubMeters.Model[0, 4].Text = "EndReading";
                    int rw = 1;
                    grdSubMeters.SuspendLayout();

                    grdSubMeters.Rows.InsertRange(1, dsSubMeters.Tables[0].Rows.Count);
                    Label lMeter = lblMeterName;
                    Label lStrt = lblStart;
                    Label lEnd = lblEnd;
                    Button btnEP = btn_1;
                    foreach (DataRow dr in dsSubMeters.Tables[0].Rows)
                    {
                        if (rw == 1)
                        {
                            if (dr["MeterNo"] == DBNull.Value)
                                lMeter.Text = Convert.ToString(dr["MeterName"]);
                            else
                                lMeter.Text = Convert.ToString(dr["MeterName"]) + "/" + Convert.ToString(dr["MeterNo"]);
                            lStrt.Text = Convert.ToString(dr["StartReading"]);
                            lEnd.Text = Convert.ToString(dr["EndReading"]);
                            lMeter.Tag = Convert.ToString(dr["SetMeterId"]);
                            btn_1.Tag = "1";
                        }
                        else
                        {
                            // Electric Meter Display UI
                            Panel pnlM = new Panel();
                            lMeter = new Label();
                            lStrt = new Label();
                            lEnd = new Label();
                            btnEP = new Button();

                            flwPanel.Controls.Add(pnlM);
                            pnlM.Name = "panel" + rw;
                            pnlM.Size = new System.Drawing.Size(128, 91);
                            pnlM.Controls.Add(lEnd);
                            pnlM.Controls.Add(lStrt);
                            pnlM.Controls.Add(lMeter);
                            pnlM.Controls.Add(btnEP);

                            lMeter.AutoSize = false;
                            lMeter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            lMeter.Dock = System.Windows.Forms.DockStyle.Top;
                            lMeter.Location = new System.Drawing.Point(0, 26);
                            lMeter.Name = "lblMeterName" + rw.ToString();
                            lMeter.Size = new System.Drawing.Size(128, 45);
                            lMeter.TabIndex = 1;
                            lMeter.Text = Convert.ToString(dr["MeterName"]) + "/" + Convert.ToString(dr["MeterNo"]);
                            lMeter.BackColor = System.Drawing.Color.WhiteSmoke;
                            lMeter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                            btnEP.BackColor = System.Drawing.Color.PowderBlue;
                            btnEP.Dock = System.Windows.Forms.DockStyle.Top;
                            btnEP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                            btnEP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            btnEP.Location = new System.Drawing.Point(0, 0);
                            btnEP.Name = "btn_" + rw.ToString();
                            btnEP.Size = new System.Drawing.Size(128, 26);
                            btnEP.TabIndex = 0;
                            btnEP.Text = "&" + rw.ToString();
                            btnEP.Tag = rw.ToString();
                            btnEP.UseVisualStyleBackColor = true;
                            btnEP.Click += new System.EventHandler(this.btn_1_Click);

                            // 
                            // lblStart
                            // 
                            lStrt.AutoSize = false;
                            lStrt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            lStrt.Dock = System.Windows.Forms.DockStyle.Left;
                            lStrt.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            lStrt.Location = new System.Drawing.Point(0, 71);                   // 
                            lStrt.Name = "lblStart" + rw.ToString();
                            lStrt.Size = new System.Drawing.Size(66, 20);
                            lStrt.TabIndex = 2;
                            lStrt.Text = Convert.ToString(dr["StartReading"]);
                            // lblEnd
                            // 
                            lEnd.AutoSize = false;
                            lEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            lEnd.Dock = System.Windows.Forms.DockStyle.Right;
                            lEnd.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            lEnd.Location = new System.Drawing.Point(66, 71);
                            lEnd.Name = "lblEnd" + rw.ToString();
                            lEnd.Size = new System.Drawing.Size(64, 20);
                            lEnd.TabIndex = 3;
                            lEnd.Text = Convert.ToString(dr["EndReading"]);


                        }
                        // set values
                        lStrt.Text = Convert.ToString(dr["StartReading"]);
                        lEnd.Text = Convert.ToString(dr["EndReading"]);
                        // for ref and selection in Entry etc. Hidden Control
                        this.grdSubMeters.Model[rw, 1].Text = Convert.ToString(dr["SetMeterId"]);
                        this.grdSubMeters.Model[rw, 2].Text = Convert.ToString(dr["MeterName"]);
                        this.grdSubMeters.Model[rw, 3].Text = Convert.ToString(dr["StartReading"]);
                        this.grdSubMeters.Model[rw, 4].Text = Convert.ToString(dr["EndReading"]);

                        rw++;
                    }
                    this.grdSubMeters.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(2, 4));
                    this.grdSubMeters.SetColHidden(1, 1, true);
                    this.grdSubMeters.ResumeLayout();
                    this.grdSubMeters.IgnoreReadOnly = false;
                }

                // Set Booking of the day to Dropdown list
                ds = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "DASH_BookingView '" + _ReadingDate + "'");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr;
                    dr = ds.Tables[0].NewRow();
                    dr["CustomerName"] = "---Other---";
                    dr["BookingPlanId"] = -1;
                    ds.Tables[0].Rows.Add(dr);
                    this.dbcBooking.DisplayMember = "CustomerName";
                    this.dbcBooking.ValueMember = "BookingPlanId";
                    this.dbcBooking.DataSource = ds.Tables[0];
                    this.dbcBooking.Enabled = true;
                    this.lblProd.Visible = true;
                    this.dbcBooking.Visible = true;
                    this.dbcOther.Visible = false;
                }
                else
                {
                    DataRow dr;
                    dr = ds.Tables[0].NewRow();
                    dr["CustomerName"] = "---Other---";
                    dr["BookingPlanId"] = -1;
                    ds.Tables[0].Rows.Add(dr);
                    this.dbcBooking.DisplayMember = "CustomerName";
                    this.dbcBooking.ValueMember = "BookingPlanId";
                    this.dbcBooking.DataSource = ds.Tables[0];
                    this.dbcBooking.Enabled = true;
                    this.lblProd.Visible = true;
                    this.dbcBooking.Visible = true;
                    this.dbcOther.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void fillSubMeters()
        {
            DataSet dsDailyRading;
            try
            {
                strSQL = "get_Daily_ElecMeterReading @ReadingDate ='" + dtpReadingDate.Value.Date.ToString("yyyy-MM-dd") + "', @SetMEterID = " + txtSetMeterID.Text;
                dsDailyRading = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);

                if (grdSchedule.Model.RowCount >= 1)
                    grdSchedule.Rows.RemoveRange(1, grdSchedule.Model.RowCount);

                if (dsDailyRading.Tables.Count > 0 && dsDailyRading.Tables[0].Rows.Count > 0)
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
                    grdSchedule[0, 10].Text = "BookingPlanId";
                    grdSchedule[0, 11].Text = "Production Name";
                    grdSchedule[0, 12].Text = "Narration";

                    grdSchedule[0, 13].Text = "ACTION";
                    grdSchedule[0, 14].Text = "";
                    grdSchedule[0, 15].Text = "isMakeupRoom";
                    grdSchedule[0, 16].Text = "isRevenueHead";
                    grdSchedule[0, 17].Text = "freeUnits";
                    grdSchedule.IgnoreReadOnly = false;
                    grdSchedule.SetColHidden(1, 4, true);
                    grdSchedule.SetColHidden(9, 10, true);
                    grdSchedule.SetColHidden(12, 17, true);


                    int i = 0;

                    grdSchedule.Rows.InsertRange(1, dsDailyRading.Tables[0].Rows.Count);
                    foreach (DataRow dr in dsDailyRading.Tables[0].Rows)
                    {
                        grdSchedule.Model[i + 1, 1].Text = i.ToString();

                        grdSchedule.Model[i + 1, 2].Text = Convert.ToString(dr["SetMeterId"]);
                        grdSchedule.Model[i + 1, 3].Text = Convert.ToString(dr["MeterName"]);
                        grdSchedule.Model[i + 1, 4].Text = Convert.ToString(dr["ElecMeterUsageId"]);
                        grdSchedule.Model[i + 1, 5].Text = Convert.ToString(dr["Usage_Purpose"]);
                        grdSchedule.Model[i + 1, 6].Text = Convert.ToString(dr["FromReading"]);
                        grdSchedule.Model[i + 1, 7].Text = Convert.ToString(dr["TOReading"]);
                        grdSchedule.Model[i + 1, 8].Text = Convert.ToString(dr["ReadingUnits"]);
                        // grdSchedule.Model[i + 1, 9].Text = "UNITS";
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
                        //grdSchedule.Model[i + 1, 10].VerticalAlignment = GridVerticalAlignment.Middle;
                        //grdSchedule[i + 1, 14].Description = "ADD";
                        //grdSchedule[i + 1, 14].TextColor = Color.DarkSlateGray;
                        grdSchedule.Model[i + 1, 15].Text = Convert.ToString(dr["isMakeupRoom"]);
                        grdSchedule.Model[i + 1, 17].Text = Convert.ToString(dr["AdjustUnits"]);
                        grdSchedule.Model[i + 1, 18].Text = Convert.ToString(dr["ElecMeterReadingId"]);
                        grdSchedule.Model[i + 1, 19].Text = Convert.ToString(dr["CustomerId"]);

                        grdSchedule.SetColHidden(10, 10, true);
                        // set all col Disabled
                        for (int j = 2; j <= 12; j++) grdSchedule.Model[i + 1, j].Enabled = false;
                        i++;
                    }
                }
                //this.grdSchedule.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(5, 5));
                //this.grdSchedule.ColWidths.SetSize(11, 150);
                grdSchedule.SetColHidden(15, 20, true);
                grdSchedule.IgnoreReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            btn_No = Convert.ToInt16(((Button)sender).Tag);
            btn_Clicked();
        }
        private void btn_Clicked()
        {
            txtRwNo.Text = "0";
            txtSetMeterID.Text = grdSubMeters.Model[btn_No, 1].Text;
            lblMeterSeleted.Text = grdSubMeters.Model[btn_No, 2].Text;
            //txtUnitFrom.Text = grdSubMeters.Model[btn_No, 3].Text;
            //txtUnitTo.Text = grdSubMeters.Model[btn_No, 4].Text;
            showUsage(grdSubMeters.Model[btn_No, 1].Text, dtpReadingDate.Value.Date);
            if (grdSchedule.RowCount < 1)
            {
                txtUnitFrom.Text = grdSubMeters.Model[btn_No, 3].Text;
                txtUnitTo.Text = grdSubMeters.Model[btn_No, 4].Text;
            }
            grpEntry.Enabled = true;
            dbcUsage.Focus();
        }
        private void showUsage(string meterId, DateTime readingDate)
        {
            DataSet dtUsages;
            Int16 i;
            try
            {
                strSQL = "get_Daily_ElecMeterReading @SetMeterId = " + meterId + ", @ReadingDate ='" + readingDate.ToString("yyyyMMdd") + "'";
                dtUsages = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                if (grdSchedule.RowCount >= 1)
                    grdSchedule.Rows.RemoveRange(1, grdSchedule.RowCount);
                if (dtUsages.Tables.Count > 0 && dtUsages.Tables[0].Rows.Count > 0)
                {
                    grdSchedule.Rows.InsertRange(1, dtUsages.Tables[0].Rows.Count);
                    i = 0;
                    grdSchedule.IgnoreReadOnly = true;
                    foreach (DataRow dr in dtUsages.Tables[0].Rows)
                    {
                        //grdSchedule.Model[i + 1, 1].Text = i.ToString();
                        grdSchedule[i + 1, 1].Text = i.ToString();
                        grdSchedule[i + 1, 2].Text = Convert.ToString(dr["SetMeterId"]);
                        grdSchedule[i + 1, 3].Text = Convert.ToString(dr["MeterName"]);
                        grdSchedule[i + 1, 4].Text = Convert.ToString(dr["ElecMeterUsageId"]);
                        grdSchedule[i + 1, 5].Text = Convert.ToString(dr["Usage_Purpose"]);
                        grdSchedule[i + 1, 6].Text = Convert.ToString(dr["FromReading"]);
                        grdSchedule[i + 1, 7].Text = Convert.ToString(dr["TOReading"]);
                        grdSchedule[i + 1, 8].Text = Convert.ToString(dr["ReadingUnits"]);
                        if (grdSchedule[i + 1, 8].Text != "")
                        {
                            txtUnitFrom.Text = grdSchedule[i + 1, 7].Text;
                            txtUnitTo.Text = String.Empty;
                            txtQty.Text = string.Empty;
                        }
                        grdSchedule[i + 1, 10].Text = Convert.ToString(dr["BookingPlanId"]);
                        grdSchedule[i + 1, 11].Text = Convert.ToString(dr["CustomerName"]);
                        grdSchedule[i + 1, 12].Text = Convert.ToString(dr["Remarks"]);
                        //grdSchedule.Model[i + 1, 8].BackColor = System.Drawing.Color.YellowGreen;
                        grdSchedule[i + 1, 15].Text = Convert.ToString(dr["isMakeupRoom"]);
                        grdSchedule[i + 1, 17].Text = Convert.ToString(dr["AdjustUnits"]);
                        grdSchedule[i + 1, 18].Text = Convert.ToString(dr["ElecMeterReadingId"]);
                        grdSchedule[i + 1, 19].Text = Convert.ToString(dr["CustomerId"]);
                        grdSchedule.Model[i + 1, 8].BackColor = System.Drawing.Color.YellowGreen;


                        this.grdSchedule.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(5, 5), GridResizeToFitOptions.IncludeHeaders);
                        this.grdSchedule.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(11, 12));
                        grdSchedule.SetColHidden(10, 10, true);
                        grdSchedule.SetColWidth(5, 5, 100);
                        grdSchedule.SetColWidth(11, 12, 150);
                        grdSchedule[i + 1, 6].HorizontalAlignment = GridHorizontalAlignment.Right;
                        grdSchedule[i + 1, 7].HorizontalAlignment = GridHorizontalAlignment.Right;
                        grdSchedule[i + 1, 8].HorizontalAlignment = GridHorizontalAlignment.Right;

                        // set all col Disabled
                        for (int j = 2; j <= 20; j++) grdSchedule.Model[i + 1, j].Enabled = false;
                        i++;
                    }
                    grdSchedule.IgnoreReadOnly = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnChange.Enabled = true;
                }
                else
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnChange.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
        #endregion
        private void grpEntry_Enter(object sender, EventArgs e)
        {

        }
        private void frmMeterReadingEntry_Load(object sender, EventArgs e)
        {
            try
            {
                setMasters();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #region " ENTRY SECTION "

        private void dbcUsage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds;
            try
            {
                if (!(dbcUsage.SelectedValue is null))
                {
                    ds = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "select isRevenueHead from ElecMeterUsage where ElecMeterUsageId = " + dbcUsage.SelectedValue.ToString());
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        txtIsRevenue.Text = ds.Tables[0].Rows[0]["isRevenueHead"].ToString();
                    }
                    else txtIsRevenue.Text = "0";
                    if (txtIsRevenue.Text == "1")
                    {
                        dbcBooking.Visible = true;
                        dbcBooking.Enabled = true;
                        lblProd.Visible = true;
                    }
                    else
                    {
                        dbcOther.Enabled = false;
                        dbcOther.Visible = false;
                        dbcBooking.Visible = false;
                        dbcBooking.Enabled = false;
                        lblProd.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }

        }

        #region EntryUnits
        private void clearForNextEntry()
        {
            this.SuspendLayout();
            txtRwNo.Text = "0";
            txtIsRevenue.Text = "0";
            dbcUsage.SelectedIndex = -1;
            if (grdSchedule.RowCount >= 1)
            {
                txtUnitFrom.Text = grdSchedule[grdSchedule.RowCount, 7].Text;
                txtQty.Text = string.Empty;
            }
            txtUnitTo.Text = string.Empty;
            txtUnitTo.Enabled = true;
            txtNarration.Text = String.Empty;
            dbcBooking.SelectedIndex = -1;
            dbcBooking.Visible = true;
            dbcOther.Visible = false;
            lblProd.Visible = true;
            this.ResumeLayout();
            dbcUsage.Focus();
        }
        private void txtUnitFrom_TextChanged(object sender, EventArgs e)
        {
            MakCalc_Units();

        }
        private void txtUnitTo_Validating(object sender, CancelEventArgs e)
        {
            if (txtUnitTo.Text != "")
            {
                if (Convert.ToDouble(txtUnitFrom.Text) > Convert.ToDouble(txtUnitTo.Text))
                { MessageBox.Show("TO Units are less than FROM units"); e.Cancel = true; }
                else { e.Cancel = false; }
            }
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
        private void MakCalc_Units()
        {
            try
            {
                if (txtUnitFrom.Text == string.Empty || txtUnitTo.Text == string.Empty || txtUnitTo.Text == "" || txtUnitFrom.Text == "")
                {
                    return;
                }
                //if (Convert.ToInt32(txtUnitTo.Text) < Convert.ToInt32(txtUnitFrom.Text) )
                //{
                //    MessageBox.Show("TO Unit is less than FROM reading");
                //    return;
                //}
                else
                {
                    double f = Convert.ToDouble(txtUnitFrom.Text);
                    double t = Convert.ToDouble(txtUnitTo.Text);
                    double fr;
                    fr = 0;
                    double q = Math.Round((t - f) - fr, 2);
                    if (q < 0)
                        q = 0;

                    txtQty.Text = (q + fr).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }
        private void setdbcOther()
        {
            try
            {
                strSQL = "get_CustomerName";
                DataSet dsc = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                if (dsc.Tables.Count > 0 && dsc.Tables[0].Rows.Count > 0)
                {
                    dbcOther.SuspendLayout();
                    dbcOther.DisplayMember = "CustomerName";
                    dbcOther.ValueMember = "CustomerID";
                    dbcOther.DataSource = dsc.Tables[0];
                    dbcOther.Top = dbcBooking.Top;
                    dbcOther.Left = dbcBooking.Left;
                    dbcOther.Visible = true;
                    dbcOther.Enabled = true;
                    dbcBooking.Visible = false;
                    lblProd.Visible = true;
                    dbcOther.ResumeLayout();
                }
                else
                {
                    dbcOther.Visible = false;
                    dbcBooking.Visible = true;
                    lblProd.Visible = true;
                }
            }
            catch (Exception ex) { }
        }
        private void dbcBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQL;
            try
            {
                if (dbcBooking.Text == "---Other---")
                {
                    setdbcOther();
                }
                else
                {
                    if (!(dbcBooking.SelectedValue is null))
                    {
                        _BookingPlanId = Convert.ToInt32(dbcBooking.SelectedValue);
                        _CustomerId = SqlHelper.ExecuteScalar(clsConnection.conn, CommandType.Text, "select CustomerId from vu_BookingPlan where BookingPlanId = " + _BookingPlanId.ToString()).ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private bool isValidApply()
        {
            try
            {
                if (txtQty.Text.Trim() == "")
                {
                    MessageBox.Show("Entry is not complete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (dbcUsage.Text.Trim() == "")
                {
                    MessageBox.Show("Entry is not complete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (dbcBooking.Visible && dbcBooking.Text == "")
                {
                    MessageBox.Show("No Production selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (dbcOther.Visible && dbcOther.Text == "")
                {
                    MessageBox.Show("No Production selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void UpdateEndReading(string endR)
        {
            grdSubMeters.IgnoreReadOnly = true;
            grdSubMeters.Model[btn_No, 4].Text = endR;
            grdSubMeters.IgnoreReadOnly = false;
            // SEARCH > label of END READING 
            if (btn_No == 1) { lblEnd.Text = endR; }
            else
            {
                Control[] c = flwPanel.Controls.Find("lblEnd" + btn_No, true);
                if (c.Length > 0)
                {
                    ((Label)c[0]).Text = endR;
                }
            }
        }
        private void cmdApply_Click(object sender, EventArgs e)
        {
            String strSQL;
            string strCustCode;
            int rw;
            try
            {
                if (dbcUsage.Text.ToString() == "")
                {
                    MessageBox.Show("Please select Usage Type", "Validation");
                    return;
                }
                if (!isValidApply())
                    return;

                rw = Convert.ToUInt16(txtRwNo.Text);
                UpdateEndReading(txtUnitTo.Text);

                strSQL = "exec save_ElecMeterReading ";
                if (grdSchedule.Model[rw, 18].Text == "") strSQL += "  @ElecMeterReadingId = 0";
                else strSQL += "  @ElecMeterReadingId = " + grdSchedule.Model[rw, 18].Text;
                strSQL += ", @ReadingDate = '" + dtpReadingDate.Value.Date.ToString("yyyyMMdd") + "'";
                strSQL += " , @SetMeterID =" + txtSetMeterID.Text;
                strSQL += " , @ElecMeterUsageId =" + dbcUsage.SelectedValue.ToString();
                if (dbcBooking.Visible)
                    strSQL += " , @BookingPlanId =" + dbcBooking.SelectedValue.ToString();
                else strSQL += " , @BookingPlanId = null";
                //strSQL += " , @ShiftTime =" + grdSchedule.Model[rw, 1].Text;
                strSQL += " , @FromReading =" + txtUnitFrom.Text;
                strSQL += " , @ToReading =" + txtUnitTo.Text;
                strSQL += " , @ReadingUnits =" + txtQty.Text;
                strSQL += " , @AdjustUnits = null";
                //strSQL += " , @TotalUnits =" + grdSchedule.Model[rw, 1].Text;
                strSQL += " , @Remarks = '" + txtNarration.Text + "'";
                strSQL += " , @CreatedBy = " + DataContainer.EMP_Code;
                if (dbcBooking.Visible)
                {
                    if (_CustomerId != "")
                    {
                        strSQL += " , @CustomerId = " + _CustomerId;
                        strCustCode = grdSchedule.Model[rw, 19].Text;
                    }
                    else
                    {
                        string tSQL;
                        tSQL = "select CustomerID from vu_bookingPlan where BookingPlanid = " + dbcBooking.SelectedValue.ToString();
                        strCustCode = SqlHelper.ExecuteScalar(clsConnection.conn, CommandType.Text, tSQL).ToString();
                        strSQL += " , @CustomerId = " + strCustCode;
                    }
                }
                if (dbcOther.Visible)
                {
                    strSQL += " , @CustomerId = " + dbcOther.SelectedValue.ToString();
                    strCustCode = dbcOther.SelectedValue.ToString();
                }
                SqlHelper.ExecuteNonQuery(clsConnection.connStr, CommandType.Text, strSQL);
                showUsage(grdSubMeters.Model[btn_No, 1].Text, dtpReadingDate.Value.Date);
                // grdSchedule.Rows.InsertRange(grdSchedule.RowCount, 1);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }


            clearForNextEntry();
        }

        #endregion

        private void ShowCurrentData(int i)
        {
            this.SuspendLayout();
            txtRwNo.Text = i.ToString();
            txtSetMeterID.Text = grdSchedule[i, 2].Text;
            dbcUsage.SelectedValue = grdSchedule[i, 4].Text;
            txtUnitFrom.Text = grdSchedule[i, 6].Text;
            txtUnitTo.Text = grdSchedule[i, 7].Text;
            txtQty.Text = grdSchedule[i, 8].Text;
            txtNarration.Text = grdSchedule[i, 12].Text;
            if (grdSchedule[i, 19].Text != "")
            {
                lblProd.Visible = true;
                if (grdSchedule[i, 10].Text != "") // Booking Plan ID
                {
                    dbcBooking.SelectedValue = Convert.ToInt32(grdSchedule[i, 10].Text);
                    dbcBooking.Visible = true;
                    dbcOther.Visible = false;
                }
                else
                {
                    setdbcOther();
                    dbcOther.SelectedValue = grdSchedule[i, 19].Text;
                    dbcBooking.Visible = false;
                    dbcOther.Visible = true;
                }
            }
            else lblProd.Visible = false;
            this.ResumeLayout();
            //if (txtIsRevenue.Text == "1")
            //{
            //    dbcBooking.Visible = true;
            //    dbcOther.Visible = false;
            //}
            //else
            //{
            //    dbcBooking.Visible = false;
            //    dbcOther.Visible = false;
            //}
        }
        private void grdSchedule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (grdSchedule.CurrentCell.RowIndex == grdSchedule.RowCount)
                    ShowCurrentData(grdSchedule.CurrentCell.RowIndex);
                else MessageBox.Show("Only the last Entry can be edited");
            }

        }

        private void grdSchedule_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show(grdSchedule.CurrentCell.RowIndex.ToString());

        }

        #endregion
        private void btnEntryCancel_Click(object sender, EventArgs e)
        {
            clearForNextEntry();
        }
        private void lblStart_Click(object sender, EventArgs e)
        {

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ShowCurrentData(grdSchedule.RowCount);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ShowCurrentData(grdSchedule.RowCount);
                DialogResult mAns = MessageBox.Show("Do you want the last entry? (Y/N)", "Confirmation", MessageBoxButtons.YesNo);
                if (mAns == DialogResult.Yes)
                {
                    int rw = grdSchedule.RowCount;
                    strSQL = "exec delete_ElecMeterReading ";
                    if (grdSchedule.Model[rw, 18].Text == "") strSQL += "  @ElecMeterReadingId = 0";
                    else strSQL += "  @ElecMeterReadingId = " + grdSchedule.Model[rw, 18].Text;
                    SqlHelper.ExecuteNonQuery(clsConnection.connStr, CommandType.Text, strSQL);
                    showUsage(grdSubMeters.Model[btn_No, 1].Text, dtpReadingDate.Value.Date);
                    // update END READING in Meter label
                    if (grdSchedule.RowCount < 1) UpdateEndReading("");
                    else UpdateEndReading(grdSchedule[grdSchedule.RowCount, 7].Text);
                }
            }
            catch (Exception ex)
            { }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            frmMeterReadings fr = new frmMeterReadings();
            //if (clickFunction(fr) == false)
            //{
            //    return;
            //}
            fr.StartPosition = FormStartPosition.Manual;
            fr.Location = new Point(0, 0);
            fr.MdiParent = this.MdiParent;
            fr.Icon = this.Icon;
            fr.TopMost = true;
            fr.ScheduleDate = dtpReadingDate.Value.Date;
            fr.Show();
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            ShowCurrentData(grdSchedule.CurrentCell.RowIndex);
            txtUnitTo.Enabled = false;
        }
    }
}
