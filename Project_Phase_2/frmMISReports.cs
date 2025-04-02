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
    public partial class frmMISReports : Form
    {
        public frmMISReports()
        {
            InitializeComponent();
        }
        DataSet dsSchedule = new DataSet();
        bool flg_frmLoad = false;
        string xlsFormulaColumns;
        string[] xlsAryColumns;
        bool add2String = true;
        #region " properties for called "
        private string _repoName = string.Empty;
        private string _fromDate = string.Empty;
        private string _toDate = string.Empty;
        public string reportName { get { return _repoName; } set { _repoName = value; } }
        public string fromDate { get { return _fromDate; } set { _fromDate = value; } }
        public string toDate { get { return _toDate; } set { _toDate = value; } }
        #endregion
        #region GetCombos
        private void getMaster()
        {
            try
            {
                DataTable dtMaster = new DataTable();
                dtMaster = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_ElecMeterMaster 'ALL'").Tables[0];
                dbcSet.DisplayMember = "MeterName";
                dbcSet.ValueMember = "SetMeterId";
                dbcSet.DataSource = dtMaster;
                dbcSet.Refresh();

                DataTable dtMasterCustomer = new DataTable();
                dtMasterCustomer = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_CustomerName 'ALL'").Tables[0];
                dbcCustomer.DisplayMember = "CustomerName";
                dbcCustomer.ValueMember = "CustomerId";
                dbcCustomer.DataSource = dtMasterCustomer;

                //grdEnquiries.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }
        #endregion
        private void btnExport_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            workbook.SaveAs("Report" + dbcBookingStatus.Text.Replace(" ", "_") + dtpFromDate.Value.Date.ToString("_yyMM"));
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "MONTH_" + dtpFromDate.Value.Date.ToString("MMMyyyy");
            // storing header part in Excel  
            int xlCol = 1;
            int cl;
            int rw;
            for (cl = 1; cl <= grdEnquiries.Model.ColCount; cl++)
            {
                if (!grdEnquiries.GetColHidden(cl))
                {
                    worksheet.Cells[1, xlCol] = grdEnquiries.Model[0, cl].Text;
                    worksheet.Cells[1, xlCol].Font.Bold = true;
                    worksheet.Cells[1, xlCol].Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                    xlCol++;
                }
            }
            // storing Each row and column value to excel sheet  

            for (rw = 1; rw <= grdEnquiries.Model.RowCount; rw++)
            {
                xlCol = 1;
                for (cl = 1; cl <= grdEnquiries.Model.ColCount; cl++)
                {
                    if (!grdEnquiries.GetColHidden(cl))
                    {
                        worksheet.Cells[rw + 1, xlCol] = grdEnquiries.Model[rw, cl].Text;// cl.ToString() + '-' + xlCol.ToString(); 
                        if (cl == 22)
                        {
                            worksheet.Cells[rw, xlCol].Numberformat = "@";
                        }
                        xlCol++;
                    }
                }
            }

            if (xlsFormulaColumns.Length > 0)
            {
                worksheet.Cells[grdEnquiries.Model.RowCount + 2, 2] = "Total";
                worksheet.Cells[grdEnquiries.Model.RowCount + 2, 2].Font.Bold = true;
                //worksheet.Range[worksheet.Cells[grdEnquiries.Model.RowCount + 2, 2]].Font.Bold = true;
                for (cl = 1; cl <= grdEnquiries.Model.ColCount; cl++)
                {

                    if (xlsFormulaColumns.Contains("," + cl.ToString() + ","))
                    {
                        // worksheet.Cells[grdEnquiries.Model.RowCount + 2, cl] = cl.ToString();
                        worksheet.Cells[grdEnquiries.Model.RowCount + 2, cl] = @"=SUM(R[-" + grdEnquiries.Model.RowCount + "]C:R[-1]C";
                        worksheet.Cells[grdEnquiries.Model.RowCount + 2, cl].Font.Bold = true;
                        worksheet.Cells[grdEnquiries.Model.RowCount + 2, cl].Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                    }
                }
            }
        }

        private void frmMISReports_Load(object sender, EventArgs e)
        {
            try
            {
                getMaster();
                // dtpFromDate.Value = Convert.ToDateTime("2019-01-01");
                dtpFromDate.Value = System.DateTime.Now.Date.AddDays(-1 * (System.DateTime.Now.Day - 1));
                // dtpToDate.Value = Convert.ToDateTime("2020-12-31");
                List<string> ReportNames = new List<string>();
                ReportNames.Add("Daily Breakup Readings");
                ReportNames.Add("Daily Readings For Meter");
                ReportNames.Add("Customerwise Usage");
                ReportNames.Add("LT Panel-Daily Readings");
                ReportNames.Add("All Meters Readings");
                ReportNames.Add("Monthly Readings-All Meters");
                ReportNames.Add("Monthly Units Summary");
                ReportNames.Add("Monthly Units Summary - Period");
                ReportNames.Add("Units Summary - Period");
                ReportNames.Add("Monthly Units Summary - Unbilled Usage");
                ReportNames.Add("Monthly Units Listing - Billed Usage");

                dbcBookingStatus.DataSource = ReportNames;
                //dbcBookingStatus.Items.Add("Daily Readings");
                //dbcBookingStatus.Items.Add("Daily Readings");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }

        }
        #region " clsReports "
        private class clsReports
        {
            string _ReportName;
            List<string> _colNames;
            List<string> _DBColName;
            Boolean _HeadingDiff;
            public string ReportName
            {
                get { return _ReportName; }
                set
                {
                    _ReportName = value;
                    _HeadingDiff = false;
                    setReportName();
                }
            }
            private void setReportName()
            {
                if (_ReportName == "Daily Readings For Meter")
                {
                    _colNames = new List<string> { "MeterName", "Day", "Used For", "Opening Reading", "Closing Reading", "Units", "Multiplying Factor", "Consumption", "Remarks", "Used By", "Production Name", "Shooting Details", "Units For Production Excluding Serial", "Serial", "Billing Units for Customer", "Ellora Maint Work", "Billing Unit To Ellora" };
                    _DBColName = new List<String> { "MeterName", "ReadingDate", "usage_purpose", "FromReading", "ToReading", "ReadingUnits", "MultiplyingFactor", "Consumption", "Remarks", "usedBy", "CustomerName", "CategoryName", "TotalUnits", "AdjustUnits", "CustomerUnits", "MaintUnits", "ElloraUnits" };
                }
                if (_ReportName == "LT Panel-Daily Readings")
                {
                    _colNames = new List<string> { "Day", "LT Panel Name", "Opening Reading", "Closing Reading", "Units", "Multiplying Factor", "Consumption", };
                    _DBColName = new List<String> { "ReadingDate", "MeterName", "FromReading", "ToReading", "ReadingUnits", "MultiplyingFactor", "Consumption" };
                }
                if (_ReportName == "Daily Breakup Readings")
                {
                    _colNames = new List<string> { "MeterName", "Shooting",
                        "Vanity"
                       , "Outdoors"
                       , "NoConsumption"
                       , "ElloraHKTeam"
                       , "ACTeam"
                       , "ELETeam"
                       , "CivilWork"
                       , "VendorWork"
                       , "UtilityWork"
                       , "Reiki"
                       , "MiscUsage"
                       , "infraMaintWork"
                       , "MakeupRoom"
                       , "PassOnMeter"
                       , "Total"
                       , "Consumption" };

                    _DBColName = new List<String> {"MeterName", "Shooting",
                        "Vanity"
                       , "Outdoors"
                       , "NoConsumption"
                       , "ElloraHKTeam"
                       , "ACTeam"
                       , "ELETeam"
                       , "CivilWork"
                       , "VendorWork"
                       , "UtilityWork"
                       , "Reiki"
                       , "MiscUsage"
                       , "infraMaintWork"
                       , "MakeupRoom"
                       , "PassOnMeter"
                       , "Total"
                       , "Consumption" };

                }
                if (_ReportName == "Monthly Readings-All Meters")
                {
                    _DBColName = new List<string> { "MeterName", "Flag_Type", "Reading_1", "Reading_2", "Reading_3", "Reading_4", "Reading_5", "Reading_6", "Reading_7", "Reading_8", "Reading_9", "Reading_10", "Reading_11", "Reading_12", "Reading_13", "Reading_14", "Reading_15", "Reading_16", "Reading_17", "Reading_18", "Reading_19", "Reading_20", "Reading_21", "Reading_22", "Reading_23", "Reading_24", "Reading_25", "Reading_26", "Reading_27", "Reading_28", "Reading_29", "Reading_30", "Reading_31", "Total" };
                    _colNames = new List<String> { "MeterName", "Type", " 1", " 2", " 3", " 4", " 5", " 6", " 7", " 8", " 9", " 10", " 11", " 12", " 13", " 14", " 15", " 16", " 17", " 18", " 19", " 20", " 21", " 22", " 23", " 24", " 25", " 26", " 27", " 28", " 29", " 30", " 31", "Total" };
                }
                if (_ReportName == "Customerwise Usage")
                {
                    _DBColName = new List<string> { "CustomerName", "Meter_1", "Meter_2", "Meter_3", "Meter_4", "Meter_5", "Meter_6", "Meter_7", "Meter_8", "Meter_9", "Meter_10", "Meter_11", "Meter_12", "Meter_13", "Meter_14", "Meter_15", "Meter_16", "Meter_17", "Meter_18", "Meter_19", "Meter_20", "Meter_21", "Meter_22", "Meter_23", "Meter_24", "Meter_29", "Meter_35", "Total" };
                    _colNames = new List<String> { "Customer", "Hospital LT With Makeup Room 201, 202 & 203", "Hospital Out Door", "Bungalow 1 LT", "Bungalow 1 Out Door", "Office Set", "Police Station", "8000 sqft", "Restaurant", "Parsi Bungalow AC", "Parsi Bungalow Light", "Bungalow 2 LT", "Bungalow 2 Makeup Room", "Villa Set AC", "Villa Set Light", "Villa Set Out Door", "Road Light", "Hill", "Makeup Room 204 - 206", "Make up room 11 - 14", "Old Makeup room Area 1(4 nos room)", "Old Makeup room Area 2(6 nos room)", "Water Pump Area", "Ellora Office", "Makeup Room 201 - 203", "Govt Office", "Large Parking", "Total" };
                }
                if (_ReportName == "All Meters Readings")
                {
                    _HeadingDiff = true;
                    _DBColName = new List<string> { "MeterName","SetMeterId", "SerialNo",  "MeterType", "Day01", "Day02", "Day03", "Day04", "Day05","DAY06",
"DAY07",
"DAY08",
"DAY09",
"DAY10",
"DAY11",
"DAY12",
"DAY13",
"DAY14",
"DAY15",
"DAY16",
"DAY17",
"DAY18",
"DAY19",
"DAY20",
"DAY21",
"DAY22",
"DAY23",
"DAY24",
"DAY25",
"DAY26",
"DAY27",
"DAY28",
"DAY29",
"DAY30",
"DAY31"
};
                    _colNames = new List<String> { "MeterName", "SetMeterId","SerialNo", "MeterType",  "Day01", "Day02", "Day03", "Day04", "Day05","DAY06",
"DAY07",
"DAY08",
"DAY09",
"DAY10",
"DAY11",
"DAY12",
"DAY13",
"DAY14",
"DAY15",
"DAY16",
"DAY17",
"DAY18",
"DAY19",
"DAY20",
"DAY21",
"DAY22",
"DAY23",
"DAY24",
"DAY25",
"DAY26",
"DAY27",
"DAY28",
"DAY29",
"DAY30",
"DAY31"};
                }
                if (_ReportName == "Monthly Units Summary")
                {
                    _HeadingDiff = false;
                    {
                        _DBColName = new List<string> { "id", "Details", "TotalUnits", "BreakupReport" };
                        _colNames = new List<string> { "Sr", "Description", "Units", "Breakup Report" };
                    }

                }
                if (_ReportName == "Monthly Units Summary - Period")
                {
                    _HeadingDiff = false;
                    {
                        _DBColName = new List<string> { "id", "Details", "TotalUnits" };
                        _colNames = new List<string> { "Sr", "Description", "Units" };
                    }

                }
                if (_ReportName == "Units Summary - Period")
                {
                    _HeadingDiff = false;
                    {
                        _DBColName = new List<string> { "Details", "Flag_Type", "TotalUnits" };
                        _colNames = new List<string> { "Description", "Type", "Units" };
                    }

                }
                if (_ReportName == "Monthly Units Summary - Unbilled Usage")
                {
                    _DBColName = new List<string> { "ElecMeterIdKey", "MeterName", "Usage_purpose", "Day01", "Day02", "Day03", "Day04", "Day05","DAY06",
"DAY07",
"DAY08",
"DAY09",
"DAY10",
"DAY11",
"DAY12",
"DAY13",
"DAY14",
"DAY15",
"DAY16",
"DAY17",
"DAY18",
"DAY19",
"DAY20",
"DAY21",
"DAY22",
"DAY23",
"DAY24",
"DAY25",
"DAY26",
"DAY27",
"DAY28",
"DAY29",
"DAY30",
"DAY31",
"Total"
};
                    _colNames = new List<String> { "SerialNo", "MeterName", "Usage",
"Day01",
"Day02",
"Day03",
"Day04", "Day05","DAY06",
"DAY07",
"DAY08",
"DAY09",
"DAY10",
"DAY11",
"DAY12",
"DAY13",
"DAY14",
"DAY15",
"DAY16",
"DAY17",
"DAY18",
"DAY19",
"DAY20",
"DAY21",
"DAY22",
"DAY23",
"DAY24",
"DAY25",
"DAY26",
"DAY27",
"DAY28",
"DAY29",
"DAY30",
"DAY31",
                    "Total"};

                }
                if (_ReportName == "Monthly Units Listing - Billed Usage")
                {
                    _colNames = new List<string> { "Ref No", "Category Name", "Reading Date", "Production Name", "Usage", "Meter", "Reading Units","Free", "Total Units","Remarks" };
                    _DBColName = new List<String> { "RefNo", "CategoryName", "ReadingDate", "CustomerName", "usage_purpose", "MeterName", "ReadingUnits", "Free", "TotalUnits", "Remarks" };
                }
            }
            public List<string> ReportCols
            {
                get { return _colNames; }
                set { _colNames = value; }
            }
            public List<string> DBCols
            { get { return _DBColName; } set { _DBColName = value; } }
            public Boolean isHeadingDiff
            {
                get { return _HeadingDiff; }
                set { _HeadingDiff = value; }
            }
        }
        #endregion

        #region " prev ver "
        private void frmMISReports_Activated(object sender, EventArgs e)
        {
            flg_frmLoad = true;
        }

        private void dbcSet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dbcShootType_SelectedIndexChanged(object sender, EventArgs e) { }

        private void dbcCustomer_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dbcCustomer_TextUpdate(object sender, EventArgs e)
        {
            dbcCustomer.FindString(dbcCustomer.Text);
        }

        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                clsReports oRepo = new clsReports();
                if (dbcBookingStatus.Text == "")
                    return;
                add2String = true;

                oRepo.ReportName = dbcBookingStatus.Text;
                List<string> ColHeading = oRepo.ReportCols;
                List<string> DBCols = oRepo.DBCols;
                xlsFormulaColumns = "";
                if (oRepo.ReportName == "Daily Breakup Readings")
                    dsSchedule = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "repo2_MeterReading '" + dtpFromDate.Value.Date.ToString("yyyyMMdd") + "'");
                else if (oRepo.ReportName == "Daily Readings For Meter")
                {
                    if (dbcSet.SelectedIndex != -1)
                        if (dbcSet.SelectedIndex == 0)
                            dsSchedule = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "repo2_DailyReadings @SetMeterID = null, @MonthDate = '" + dtpFromDate.Value.Date.ToString("yyyy-MM-dd") + "'");
                        else
                            dsSchedule = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "repo2_DailyReadings @SetMeterID = " + dbcSet.SelectedValue.ToString() + ", @MonthDate = '" + dtpFromDate.Value.Date.ToString("yyyy-MM-dd") + "'");
                }
                else if (oRepo.ReportName == "Monthly Readings-All Meters")
                    //dsSchedule = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "repo2_pivot_Daily '" + dtpFromDate.Value.Date.ToString("yyyyMMdd") + "'");
                    dsSchedule = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "repo2_prepareSnapshot '" + dtpFromDate.Value.Date.ToString("yyyyMM01") + "'");
                else if (oRepo.ReportName == "Customerwise Usage")
                    dsSchedule = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "repo2_Pivot_Customer '" + dtpFromDate.Value.Date.ToString("yyyyMMdd") + "'");
                else if (oRepo.ReportName == "LT Panel-Daily Readings")
                {
                    dsSchedule = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "repo2_DailyReadingsPanel @MonthDate = '" + dtpFromDate.Value.Date.ToString("yyyy-MM-dd") + "'");
                }
                else if (oRepo.ReportName == "All Meters Readings")
                {
                    dsSchedule = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "repo2_AllMeterReadings @FromDate = '" + dtpFromDate.Value.Date.ToString("yyyy-MM-dd") + "', @ToDate='" + dtpToDate.Value.Date.ToString("yyyy-MM-dd") + "'");
                }
                else if (oRepo.ReportName == "Monthly Units Summary")
                {// 
                    if (!dtpToDate.Visible)
                        dsSchedule = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "repo2_monthlySummary @monthDate = '" + dtpFromDate.Value.Date.ToString("yyyy-MM-01") + "'");
                }
                else if (oRepo.ReportName == "Monthly Units Summary - Period")
                {// 
                    string toDate;
                    toDate = dtpToDate.Value.Date.ToString("yyy-MM-" + DateTime.DaysInMonth(dtpToDate.Value.Year, dtpToDate.Value.Month).ToString());
                    string strSQL = "repo2_monthlySummary_range @FromDate = '" + dtpFromDate.Value.Date.ToString("yyyy-MM-01") + "', @ToDate='" + toDate + "'";
                    dsSchedule = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                }
                else if (oRepo.ReportName == "Monthly Units Summary - Unbilled Usage")
                {
                    dsSchedule = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "repo2_Pivot_Usage @monthDate = '" + dtpFromDate.Value.Date.ToString("yyyy-MM-01") + "'");
                }
                else if (oRepo.ReportName == "Units Summary - Period")
                {
                    string strSQL = "repo2_periodicSummary @fromDate = '" + dtpFromDate.Value.Date.ToString("yyyy-MM-dd") + "', @toDate ='" + dtpToDate.Value.Date.ToString("yyyy-MM-dd") + "'";
                    dsSchedule = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                }
                else if (oRepo.ReportName == "Monthly Units Listing - Billed Usage")
                {
                    string strSQL = "repo2_PeriodicBilled_range @fromDate = '" + dtpFromDate.Value.Date.ToString("yyyy-MM-dd") + "', @toDate ='" + dtpToDate.Value.Date.ToString("yyyy-MM-dd") + "'";
                    dsSchedule = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                }
                grdEnquiries.IgnoreReadOnly = true;
                if (grdEnquiries.Model.RowCount >= 1)
                    grdEnquiries.Rows.RemoveRange(1, grdEnquiries.Model.RowCount);
                if (dsSchedule.Tables.Count > 0 && dsSchedule.Tables[0].Rows.Count > 0)
                {
                    grdEnquiries.Rows.InsertRange(1, dsSchedule.Tables[0].Rows.Count);

                    int i = 1;
                    int cl = 0;
                    if (oRepo.isHeadingDiff == false)
                    {
                        grdEnquiries.Cols.RemoveRange(1, grdEnquiries.Model.ColCount);
                        grdEnquiries.ColCount = DBCols.Count; //dsSchedule.Tables[0].Columns.Count;
                        foreach (string clH in ColHeading)
                        {
                            grdEnquiries[0, i].Text = clH.ToString();
                            i++;
                        }
                        if (oRepo.ReportName == "Monthly Readings-All Meters")
                        {
                            for (i = 4; i < dsSchedule.Tables[0].Columns.Count; i++)
                            {
                                grdEnquiries[0, i - 1].Text = grdEnquiries[0, i - 1].Text + "/" + dtpFromDate.Value.Date.ToString("MM/yyyy");

                            }
                        }
                        //else if (oRepo.ReportName == "All Meters Readings")
                        //{
                        //    for (i = 4; i < dsSchedule.Tables[0].Columns.Count; i++)
                        //    {
                        //        grdEnquiries[0, i - 1].Text = grdEnquiries[0, i - 1].Text + "/" + dtpFromDate.Value.Date.ToString("MM/yyyy");
                        //    }

                        //}
                    }
                    else
                    {
                        grdEnquiries.Cols.RemoveRange(1, grdEnquiries.Model.ColCount);
                        grdEnquiries.ColCount = dsSchedule.Tables[0].Columns.Count - 2; //dsSchedule.Tables[0].Columns.Count;

                        if (oRepo.ReportName == "All Meters Readings")
                        {
                            for (i = 2; i < dsSchedule.Tables[0].Columns.Count; i++)
                            {
                                grdEnquiries[0, i - 1].Text = dsSchedule.Tables[0].Columns[i].ColumnName.ToString();
                            }
                        }
                        else
                        {
                            for (i = 2; i < dsSchedule.Tables[0].Columns.Count; i++)
                            {
                                grdEnquiries[0, i - 1].Text = dsSchedule.Tables[0].Columns[i].ColumnName.ToString();
                            }
                        }
                    }
                    i = 1;
                    if (oRepo.isHeadingDiff == false)
                    {
                        foreach (DataRow dr in dsSchedule.Tables[0].Rows)
                        {
                            cl = 1;
                            foreach (string clDB in DBCols)
                            {
                                grdEnquiries[i, cl].Text = Convert.ToString(dr[clDB.ToString()]);
                                cl++;
                            }
                            i++;
                        }
                    }
                    else
                    {
                        if (oRepo.ReportName == "All Meters Readings")
                        {
                            foreach (DataRow dr in dsSchedule.Tables[0].Rows)
                            {
                                for (cl = 2; cl < dsSchedule.Tables[0].Columns.Count; cl++)
                                {
                                    grdEnquiries[i, cl - 1].Text = Convert.ToString(dr[cl]);
                                }
                                i++;
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in dsSchedule.Tables[0].Rows)
                            {
                                for (cl = 2; cl < dsSchedule.Tables[0].Columns.Count; cl++)
                                {
                                    grdEnquiries[i, cl - 1].Text = Convert.ToString(dr[cl]);
                                }
                                i++;
                            }
                        }
                    }
                }
                for (int i = 0; i <= grdEnquiries.ColCount; i++)
                {
                    grdEnquiries.IgnoreReadOnly = true;
                    bool isHidden = false;
                    // Check if the column is hidden
                    for (int j = 0; j < grdEnquiries.ColHiddenEntries.Count; j++)
                    {
                        if (grdEnquiries.ColHiddenEntries[j].ColIndex == i)
                        {
                            isHidden = true;
                            break;
                        }
                    }
                    // set column column width
                    if (!isHidden)
                    {
                        this.grdEnquiries.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(i, i));
                    }
                }
                grdEnquiries.IgnoreReadOnly = false;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        private void dbcBookingStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dbcBookingStatus.Text == "All Meters Readings"
                || dbcBookingStatus.Text == "Units Summary - Period"
                || dbcBookingStatus.Text == "Monthly Units Summary - Period"
                || dbcBookingStatus.Text == "Monthly Units Listing - Billed Usage")
            {
                lblFromDate.Text = "From Date";
                dtpToDate.Visible = true;
                lblToDate.Visible = true;
            }
            else
            {
                lblFromDate.Text = "From Date";
                dtpToDate.Visible = false;
                lblToDate.Visible = false;
            }
            if (dbcBookingStatus.SelectedIndex == 1)
            {
                dbcSet.Visible = true;
            }
            else dbcSet.Visible = false;
            if (dbcBookingStatus.SelectedIndex == 0) { lblFromDate.Text = "Report Date"; }
            else { lblFromDate.Text = "Report Month"; }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void grpPlans_Enter(object sender, EventArgs e)
        {

        }

        private void grdEnquiries_CellDoubleClick(object sender, Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs e)
        {
            // run other report in case of summary report
            // if clicked twice
            if (dbcBookingStatus.Text == "Monthly Units Summary")
            {
                string repoLink = grdEnquiries.Model[grdEnquiries.CurrentCell.RowIndex, grdEnquiries.CurrentCell.ColIndex].CellValue.ToString();
                if (repoLink == "Monthly Units Summary - Unbilled Usage" ||
                    repoLink == "Monthly Readings-All Meters" ||
                    repoLink == "Daily Readings for Meter" )
                { frmMISReports f2 = new frmMISReports();
                    f2.reportName = repoLink;
                    f2.fromDate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                    f2.toDate = dtpToDate.Value.ToString("yyyy-MM-dd");
                    f2.StartPosition = FormStartPosition.CenterScreen;
                    f2.ShowDialog();
                }
            }
        }

        private void frmMISReports_Shown(object sender, EventArgs e)
        {
            if (_repoName != string.Empty)
            {
                dbcBookingStatus.Text = _repoName;
                if (_fromDate != string.Empty)
                {
                    dtpFromDate.Value = Convert.ToDateTime(_fromDate);
                }
                if (_toDate != string.Empty)
                {
                    dtpToDate.Value = Convert.ToDateTime(_toDate);
                }
                this.Cursor = Cursors.WaitCursor;
                button1_Click(null, null);
                this.Cursor = Cursors.Default;
            }
        }
    }
}
