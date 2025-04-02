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
    public partial class frmCalendarDash : Form
    {
        Boolean flg_form = false;
        DataSet ds = new DataSet();
        DataSet dsEnq = new DataSet();
        DataSet dsBook = new DataSet();
        DataSet dsCalendar = new DataSet();
        Int32 _SetMeterID;
        string strSQL;
        string strSQL_ENQ;
        string strSQL_BOOK;

        public frmCalendarDash()
        {
            InitializeComponent();
        }
        DateTime _fromDate;
        DateTime _ToDate;
        public DateTime FromDate { get { return _fromDate; } set { _fromDate = value; } }
        public DateTime ToDate { get { return _ToDate; } set { _ToDate = value; } }

        private void frmCalendarDash_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime d = dtpMonth.Value.Date;
                DateTime d2;

                dtpMonth.Value = new DateTime(d.Year, d.Month, 1);
                getMaster();

                //strSQL = "repo2_dailyReadings @SetMeterID = " + dbcSet.SelectedValue.ToString();
                //strSQL += ", @MonthDate = '" + dtpMonth.Value.Date.ToString("yyyyMMdd") + "'";// '2020-02-01','2020-02-29', 1";
                //dsBook = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!flg_form)
                return;

            fillcalnedar();
        }
        private void fillcalnedar()
        {
            try
            {
                if (!flg_form)
                    return;
                //this.flowLayoutPanel1.Visible = false;
                tblLayoutDash.SuspendLayout();

                while (tblLayoutDash.Controls.Count > 7)
                {
                    foreach (Control pn in tblLayoutDash.Controls)
                    {
                        if (pn.GetType().ToString() == "System.Windows.Forms.FlowLayoutPanel")
                            pn.Dispose();
                    }
                }
                int p = 1;
                int rw = 0;
                DateTime d = dtpMonth.Value.Date;
                DateTime d1 = new DateTime(d.Year, d.Month, 1);

                // getdata
                //strSQL_BOOK = "repo2_DASH_dailyReadings @SetMeterID = " + dbcSet.SelectedValue.ToString();
                //strSQL_BOOK += ", @MonthDate = '" + d1.ToString("yyyyMMdd") + "'";// '2020-02-01','2020-02-29', 1";

                strSQL_BOOK = "repo2_DASH_get_SubMeterReading @LocationId = " + dbcSet.SelectedValue.ToString();
                strSQL_BOOK += ", @ReadingDate = '" + d1.ToString("yyyyMMdd") + "'";// '2020-02-01','2020-02-29', 1";

                ds = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL_BOOK);
                dsBook = ds;
                rw = 1;
                while (d.Month == d1.Month)
                {
                    FlowLayoutPanel dyPnl = new System.Windows.Forms.FlowLayoutPanel();// Panel();
                    Label dyLbl = new Label();

                    dyLbl.Size = new System.Drawing.Size(26, 16);
                    //''dyLbl.Dock = System.Windows.Forms.DockStyle.Top;
                    dyLbl.Text = d.Date.Day.ToString();
                    dyLbl.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    dyLbl.ForeColor = Color.Black;

                    dyPnl.Controls.Add(dyLbl);
                    dyPnl.BackColor = System.Drawing.Color.WhiteSmoke;
                    dyPnl.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
                    dyPnl.BorderStyle = BorderStyle.FixedSingle;
                    dyPnl.Tag = "E_";
                    // Check if
                    int lblCount = 1;
                    foreach (DataRow dr in dsBook.Tables[0].Rows)
                    {
                        if (d == Convert.ToDateTime(dr["ReadingDate"].ToString()) && Convert.ToInt32(dr["SetMeterID"]) == _SetMeterID)
                        {
                            Label cLbl = new Label();
                            Label eLbl = new Label();
                            Label lblEntries = new Label();

                            cLbl.Text = "Start: " + dr["startReading"].ToString();
                            lblEntries.Text = "Units: " + dr["Units"].ToString();
                            eLbl.Text = "End  : " + dr["EndReading"].ToString();
                            cLbl.ForeColor = Color.DarkSlateGray;
                            eLbl.ForeColor = Color.Brown;
                            eLbl.ForeColor = Color.DarkGreen;

                            // cLbl.BackColor = pnlBook.BackColor;
                            cLbl.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            eLbl.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            lblEntries.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            // cLbl.Size = new Size(dyPnl.Width - 4, 18);
                            cLbl.AutoSize = true;
                            eLbl.AutoSize = true;
                            lblEntries.AutoSize = true;

                            // cLbl.Size = new Size(dyPnl.Width - 4, 18);
                            cLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                            eLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                            lblEntries.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

                            eLbl.BackColor = Color.White;

                            //this.toolTipCustomer.SetToolTip(cLbl, dr["MeterName"].ToString());
                            //cLbl.Tag = "E_" + dr["ElecMeterReadingId"].ToString();

                            //if (Convert.ToInt32(dr["isRevenueHead"].ToString()) == 1)
                            //{
                            //    cLbl.BackColor = Color.Gold;
                            //    cLbl.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
                            //}
                            // cLbl.DoubleClick += new System.EventHandler(this.tblLayoutDash_DoubleClick);
                            //cLbl.Location = new System.Drawing.Point(4, 2 + (20 * (lblCount)));

                            dyPnl.Controls.Add(cLbl);
                            dyPnl.Controls.Add(lblEntries);
                            dyPnl.Controls.Add(eLbl);
                            dyPnl.BorderStyle = BorderStyle.FixedSingle;
                            lblCount++;
                            dyPnl.BackColor = Color.White;
                        }
                    }
                    dyPnl.Tag += d.ToString("yyyy-MM-dd");
                    dyPnl.DoubleClick += new System.EventHandler(this.tblLayoutDash_DoubleClick);

                    this.tblLayoutDash.Controls.Add(dyPnl, (int)d.DayOfWeek, rw);
                    d = d.AddDays(1);
                    if ((int)d.DayOfWeek == 0)
                        rw++;
                    //this.flowLayoutPanel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
            finally
            {
                tblLayoutDash.ResumeLayout();
            }
        }

        private void frmCalendarDash_Activated(object sender, EventArgs e)
        {
            flg_form = true;
            fillcalnedar();
        }

        private void tblLayoutDash_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Panel cP = (Panel)sender;
                string tagStr = cP.Tag.ToString().Substring(2, cP.Tag.ToString().Length - 2);

                // int planId = Convert.ToInt32(tagStr);
                frmMeterReadingEntry fr = new frmMeterReadingEntry();
                fr.MdiParent = this.MdiParent;
                fr.StartPosition = FormStartPosition.Manual;
                fr.Location = new Point(0, 0);
                fr.ReadingDate = tagStr;
                fr.ReadingLocationId = Convert.ToInt16(dbcSet.SelectedValue);
                //fr.setBookingPlanId = planId;
                //fr.setOperation = "DAILY";
                fr.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        private void getMaster()
        {
            try
            {
                DataTable dtMaster = new DataTable();
                dtMaster = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_ElecLocation").Tables[0];
                dbcSet.DisplayMember = "LocationDesc";
                dbcSet.ValueMember = "LocationId";
                dbcSet.DataSource = dtMaster;
                dbcSet.Refresh();

            }
            catch (Exception ex)
            {
            }
        }

        private void dbcSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flg_form)
            {
                //    ds = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "get_EnquiryPlan '2020-02-01','2020-02-29', " + dbcSet.SelectedValue.ToString());
                fillcalnedar();
            }
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FillDashboard(object sender, EventArgs e)
        {
            if (sender.GetType().ToString().Contains("Label"))
                _SetMeterID = Convert.ToInt32(((Label)sender).Tag);
            else
                _SetMeterID = Convert.ToInt32(((Button)sender).Tag);

            foreach (Control c in flwPanel.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    foreach (Control l in c.Controls)
                    {
                        l.BackColor = Color.White;
                    }
                    //foreach (Button b in c.Controls)
                    //{
                    //    b.BackColor = Color.White;
                    //}
                }
            }
            if (sender.GetType().ToString().Contains("Label"))
                ((Label)sender).BackColor = Color.PaleGreen;
            else
                ((Button)sender).BackColor = Color.PaleGreen;

            fillcalnedar();
        }
        private void dbcSet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                while (flwPanel.Controls.Count > 1)
                {
                    flwPanel.Controls.RemoveAt(1);
                }
                strSQL = "get_ElecMeterMaster null, " + dbcSet.SelectedValue.ToString();
                DataSet dsTemp = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);

                //if (grdSets.Model.RowCount >= 1)
                //    grdSets.Rows.RemoveRange(1, grdSets.Model.RowCount);
                
                if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                {
                    int rw = 1;
                    //Label lMeter = lblMeterName;
                    Button bMeter = btnMeterName;
                    foreach (DataRow dr in dsTemp.Tables[0].Rows)
                    {
                        if (rw == 1)
                        {
                            //lMeter.Text = Convert.ToString(dr["MeterName"]) + "/" + Convert.ToString(dr["MeterNo"]);
                            //lMeter.Tag = Convert.ToString(dr["SetMeterId"]);
                            //lMeter.Click += new System.EventHandler(this.FillDashboard);
                            //lMeter.Name = "lblMeterName" + rw.ToString();

                            bMeter.Text = Convert.ToString(dr["MeterName"]) + "/" + Convert.ToString(dr["MeterNo"]);
                            bMeter.Tag = Convert.ToString(dr["SetMeterId"]);bMeter.Dock = DockStyle.Top;

                            bMeter.Click += new System.EventHandler(this.FillDashboard);
                            bMeter.Name = "btnMeterName" + rw.ToString();
                        }
                        else
                        {
                            // Electric Meter Display UI
                            Panel pnlM = new Panel();
                            //lMeter = new Label();
                            bMeter = new Button();
                           
                            flwPanel.Controls.Add(pnlM);
                            pnlM.Name = "panel" + rw;
                            pnlM.Size = new System.Drawing.Size(128, 55);
                            //pnlM.Controls.Add(lMeter);
                            pnlM.Controls.Add(bMeter);

                            //lMeter.AutoSize = false;
                            //lMeter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            //lMeter.Dock = System.Windows.Forms.DockStyle.Top;
                            //lMeter.Location = new System.Drawing.Point(0, 26);
                            //lMeter.Name = "lblMeterName" + rw.ToString();
                            //lMeter.Size = new System.Drawing.Size(128, 45);
                            //lMeter.TabIndex = 1;
                            //lMeter.Text = Convert.ToString(dr["MeterName"]) + "/" + Convert.ToString(dr["MeterNo"]);
                            //lMeter.BackColor = System.Drawing.Color.WhiteSmoke;
                            //lMeter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                            //lMeter.Click += new System.EventHandler(this.FillDashboard);

                            bMeter.AutoSize = false;
                            bMeter.FlatStyle = FlatStyle.Flat;
                            bMeter.Dock = System.Windows.Forms.DockStyle.Top;
                            bMeter.Location = new System.Drawing.Point(0, 26);
                            bMeter.Name = "btnMeterName" + rw.ToString();
                            bMeter.Size = new System.Drawing.Size(132,41);
                            bMeter.TabIndex = 1;
                            bMeter.Text = Convert.ToString(dr["MeterName"]) + "/" + Convert.ToString(dr["MeterNo"]);
                            bMeter.BackColor = System.Drawing.Color.WhiteSmoke;
                            bMeter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                            bMeter.Tag = Convert.ToString(dr["SetMeterId"]);
                            bMeter.Click += new System.EventHandler(this.FillDashboard);
                        }
                        rw++;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void flwPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chkOption.Checked)
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
                fr.ScheduleDate = System.DateTime.Today.AddDays(-1);
                //fr.BookingPlanID = Convert.ToInt32(grdSchedule.Model[rw, 10].Text);
                fr.Show();
            }
            else
            {
                frmMeterReadingEntry fr = new frmMeterReadingEntry();
                fr.MdiParent = this.MdiParent;
                fr.StartPosition = FormStartPosition.Manual;
                fr.Location = new Point(0, 0);
                fr.ReadingDate = System.DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
                fr.ReadingLocationId = Convert.ToInt16(dbcSet.SelectedValue);
                //fr.setBookingPlanId = planId;
                //fr.setOperation = "DAILY";
                fr.Show();
            }
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            if (chkOption.Checked)
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
                fr.ScheduleDate = System.DateTime.Today;
                //fr.BookingPlanID = Convert.ToInt32(grdSchedule.Model[rw, 10].Text);
                fr.Show();
            }
            else
            {
                frmMeterReadingEntry fr = new frmMeterReadingEntry();
                fr.MdiParent = this.MdiParent;
                fr.StartPosition = FormStartPosition.Manual;
                fr.Location = new Point(0, 0);
                fr.ReadingDate = System.DateTime.Today.ToString("yyyy-MM-dd");
                fr.ReadingLocationId = Convert.ToInt16(dbcSet.SelectedValue);
                //fr.setBookingPlanId = planId;
                //fr.setOperation = "DAILY";
                fr.Show();
            }
        }

        private void btnMeterName_Click(object sender, EventArgs e)
        {

        }
    }
    #region UNUserd Code

    /***/
    /* To Update Events if it is not properyl Marked in Calendar */
    //            if (dsBook.Tables.Count > 0 && dsBook.Tables[0].Rows.Count > 0)
    //            {
    //                int bookEventId;
    //    DateTime tdt;
    //    String strSQL;
    //    clsCalendarEvents eCalendar = new clsCalendarEvents();
    //                foreach (DataRow drBooking in dsBook.Tables[0].Rows)
    //                {
    //                    try
    //                    {
    //                        if (eCalendar.isInternetConnection())
    //                        {
    //                            bookEventId = Convert.ToInt32(drBooking["BookingPlanId"]);
    //                            tdt = Convert.ToDateTime(drBooking["FromDate"]);
    //                            eCalendar.SetId = Convert.ToInt32(drBooking["SetId"]);

    //                            while (tdt <= Convert.ToDateTime(drBooking["ToDate"]))
    //                            {
    //                                eCalendar.EventStartTime = tdt.AddHours(Convert.ToInt32(Convert.ToString(drBooking["ShiftTime"]).Substring(0, 2))).ToString("HH:mm");
    //    eCalendar.EventEndTime = Convert.ToDateTime(eCalendar.EventStartTime).AddHours(12).ToString("dd-MM-yyyy HH:mm");
    //    eCalendar.EventUntil = tdt.ToString("yyyy-MM-dd");
    //                                eCalendar.EventSummary = "BOOK: " + drBooking["Customer"].ToString().Replace("'", "^") + " " + drBooking["Contact"].ToString().Trim().Replace("'", "^");
    //    eCalendar.EventLocation = drBooking["SetName"].ToString();

    //    eCalendar.EventID = "book" + (bookEventId > 0 ? 'p' + bookEventId.ToString() : 'm' + (-1 * bookEventId).ToString()) + 'd' + tdt.ToString("yyyyMMdd");
    //                                strSQL = "save_GoogleEventsList ";
    //                                strSQL += " @ActivityType = 'BOOK'";
    //                                strSQL += ", @ActivityStatus = 1";
    //                                strSQL += ", @SystemPlanID = " + bookEventId.ToString();
    //                                strSQL += ", @ScheduleDate = '" + tdt.ToString("yyyy-MM-dd") + "'";
    //                                strSQL += ", @SystemEventID = '" + eCalendar.EventID + "'";
    //                                strSQL += ", @ActivityStartDate = '" + eCalendar.EventStartTime.ToString().Substring(0, 10) + "'";
    //                                strSQL += ", @ActivityEndDate = '" + eCalendar.EventEndTime.ToString().Substring(0, 10) + "'";
    //                                strSQL += ", @ActivityUntil = '" + eCalendar.EventEndTime.ToString().Substring(0, 16).Replace('T', ' ') + "'";
    //                                strSQL += ", @ActivitySummary = '" + eCalendar.EventSummary + "'";
    //                                strSQL += ", @ActivityLocation = '" + eCalendar.EventLocation + "'";
    //                                strSQL += ", @ActivityCalendar = '" + eCalendar.EventCalendar + "'";
    //                                strSQL += ", @ActivityCredential = '" + eCalendar.EventCredentialPath + "'";
    //                                strSQL += ", @CreatedBy  = " + DataContainer.EMP_Code.ToString();
    //                                DataSet dsGB = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
    //                                if (dsGB.Tables.Count > 0 && dsGB.Tables[0].Rows.Count > 0)
    //                                {
    //                                    if (dsGB.Tables[0].Rows[0]["MSG"].ToString() == "UPDATE") eCalendar.EventUpdate();
    //                                    else eCalendar.EventCreate();
    //                                }
    //dsGB.Dispose();
    //                                tdt = tdt.AddDays(1);
    //                            }
    //                        }
    //                        else
    //                        {
    //                            MessageBox.Show("Internet connection Not available cannot continue", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //                        }
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                        MessageBox.Show("Error while Updating Event - " + eCalendar.EventSummary, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
    //                        clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
    //}
    //                }
    /***/
    //rw = d.Day;
    //p = (int)d.DayOfWeek;

    //rw = (int)rw / 5;

    //if ((d.DayOfWeek < d1.DayOfWeek))
    //{// weekday is LESS than 1st Day
    //    rw++;
    //}
    //p++; // forweekday
    //switch (rw)
    //{
    //    case 0:
    //        {
    //            switch (p)
    //            {
    //                case 1:
    //                    {
    //                        panel1.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 2:
    //                    {
    //                        panel2.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 3:
    //                    {
    //                        panel3.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 4:
    //                    {
    //                        panel4.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 5:
    //                    {
    //                        panel5.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 6:
    //                    {
    //                        panel6.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 7:
    //                    {
    //                        panel7.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //            }
    //            break;
    //        }
    //    case 1:
    //        {
    //            switch (p)
    //            {
    //                case 1:
    //                    {
    //                        panel8.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 2:
    //                    {
    //                        panel9.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 3:
    //                    {
    //                        panel10.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 4:
    //                    {
    //                        panel11.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 5:
    //                    {
    //                        panel12.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 6:
    //                    {
    //                        panel13.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 7:
    //                    {
    //                        panel14.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //            }
    //            break;
    //        }
    //    case 2:
    //        {
    //            switch (p)
    //            {
    //                case 15:
    //                    {
    //                        panel8.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 16:
    //                    {
    //                        panel9.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 17:
    //                    {
    //                        panel10.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 18:
    //                    {
    //                        panel11.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 19:
    //                    {
    //                        panel12.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 20:
    //                    {
    //                        panel13.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //                case 21:
    //                    {
    //                        panel14.BackColor = Color.Wheat;
    //                        break;
    //                    }
    //            }
    //            break;
    //        }
    //    default:
    //        break;
    //}

    #endregion
}
