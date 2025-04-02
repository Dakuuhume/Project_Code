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
    public partial class frmLTPanelEntry : Form
    {
        private DataSet ds = new DataSet();
        public frmLTPanelEntry()
        {
            InitializeComponent();
        }

        private void frmLTPanelEntry_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " " + System.DateTime.Today.ToString("ddd dd-MMM-yyyy");
            setMasters();
            populateData();
        }
        private void setMasters()
        {
            try
            {
                grdSchedule.IgnoreReadOnly = true;
                grdSchedule[0, 1].Text = "ID";
                grdSchedule[0, 2].Text = "SetMeterID";
                grdSchedule[0, 3].Text = "Meter Name";
                grdSchedule[0, 4].Text = "FROM";
                grdSchedule[0, 5].Text = "TO";
                grdSchedule[0, 6].Text = "Units";
                grdSchedule[0, 7].Text = "UoM";
                grdSchedule[0, 8].Text = "Narration";

                grdSchedule[0, 9].Text = "ACTION";
                grdSchedule[0, 10].Text = "LastEntry";
                grdSchedule.IgnoreReadOnly = false;
                grdSchedule.SetColHidden(1, 2, true);
                grdSchedule.SetColHidden(9, 9, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }
        private void populateData()
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "getLTMeterReading '" + dtpReadingDate.Value.Date.ToString("yyyyMMdd") + "'");
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
                        grdSchedule.Model[i + 1, 4].Text = Convert.ToString(dr["FromReading"]);
                        grdSchedule.Model[i + 1, 5].Text = Convert.ToString(dr["TOReading"]);
                        grdSchedule.Model[i + 1, 6].Text = Convert.ToString(dr["ReadingUnits"]);
                        grdSchedule.Model[i + 1, 7].Text = "UNITS";
                        grdSchedule.Model[i + 1, 8].Text = Convert.ToString(dr["Remarks"]);
                        grdSchedule.Model[i + 1, 5].BackColor = System.Drawing.Color.YellowGreen;
                        grdSchedule.Model[i + 1, 8].VerticalAlignment = GridVerticalAlignment.Middle;
                        grdSchedule.Model[i + 1, 9].Text = Convert.ToString(dr["LTMeterReadingId"]);
                        grdSchedule.Model[i + 1, 10].Text = Convert.ToDateTime(dr["LastEntry"]).ToString("yyyy-MM-dd");

                        //grdSchedule.SetColHidden(9, 9, true);
                        // set all col Disabled
                        for (int j = 2; j <= 10; j++) grdSchedule.Model[i + 1, j].ReadOnly = true;
                        // Allow data entry only for the last date
                        if (Convert.ToDateTime(dr["LastEntry"]) <= dtpReadingDate.Value.Date)
                        {
                            grdSchedule[i + 1, 5].ReadOnly = true;
                            cmdCancel.Enabled = true;
                        }
                        else
                        {
                            grdSchedule[i + 1, 5].ReadOnly = false;
                            cmdCancel.Enabled = false;
                        }
                        i++;
                    }
                }
                this.grdSchedule.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(3, 4));
                this.grdSchedule.ColWidths.SetSize(11, 80);
                grdSchedule.SetColHidden(13, 20, true);
                grdSchedule.CurrentCell.MoveTo(1, 5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }
        private void grdSchedule_CurrentCellAcceptedChanges(object sender, CancelEventArgs e)
        {
            try
            {
                int cl = grdSchedule.CurrentCell.ColIndex;
                int rw = grdSchedule.CurrentCell.RowIndex;
                grdSchedule[rw, cl + 1].CellValue = Convert.ToDouble(grdSchedule[rw, cl].CellValue.ToString()) - Convert.ToDouble(grdSchedule[rw, cl - 1].CellValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data is not in proper format");
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            String strSQL;
            string strCustCode;
            int rw;
            cmdSave.Enabled = false;
            try
            {
                //if (!isValidApply())
                //    return;
                for (rw = 1; rw <= grdSchedule.RowCount; rw++)
                {
                    strSQL = "exec save_PanelMeterReading ";
                    if (grdSchedule.Model[rw, 9].Text == "") strSQL += "  @ElecMeterReadingId = 0";
                    else strSQL += "  @ElecMeterReadingId = " + grdSchedule.Model[rw, 9].Text;
                    strSQL += ", @ReadingDate = '" + dtpReadingDate.Value.Date.ToString("yyyyMMdd") + "'";
                    strSQL += " , @SetMeterID =" + grdSchedule.Model[rw, 2].Text;
                    strSQL += " , @FromReading =" + grdSchedule.Model[rw, 4].Text;
                    strSQL += " , @ToReading =" + grdSchedule.Model[rw, 5].Text;
                    strSQL += " , @ReadingUnits =" + grdSchedule.Model[rw, 6].Text;
                    strSQL += " , @AdjustUnits = null";
                    strSQL += " , @CreatedBy = " + DataContainer.EMP_Code;
                    SqlHelper.ExecuteNonQuery(clsConnection.connStr, CommandType.Text, strSQL);
                }
                MessageBox.Show("Entries saved", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
            finally
            {
                cmdSave.Enabled = true;
            }
        }

        private void grdSchedule_CellClick(object sender, GridCellClickEventArgs e)
        {

        }

        private void dtpReadingDate_ValueChanged(object sender, EventArgs e)
        {
            populateData();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // DELETE ONLY the last Entry
            if (grdSchedule[1, 5].ReadOnly == true)
            {
               DialogResult dialogResult= MessageBox.Show("Are you sure to delete entry of " + dtpReadingDate.Value.Date.ToString("ddd dd/MMM/yyyy") + "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string strSQL = "delete from LTMeterReading where ReadingDate ='" + dtpReadingDate.Value.Date.ToString("yyyy-MM-dd") + "'";
                        SqlHelper.ExecuteNonQuery(clsConnection.connStr, CommandType.Text, strSQL);
                        populateData();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Entry after "+ dtpReadingDate.Value.Date.ToString("ddd dd/MMM/yyyy") + " exists, Cannot delete entries", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
