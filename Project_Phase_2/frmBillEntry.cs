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
    public partial class frmBillEntry : Form
    {
        private DataTable oDt = new DataTable();
        public frmBillEntry()
        {
            InitializeComponent();
        }
        private void grpEntry_Enter(object sender, EventArgs e)
        {

        }
        private void showReadings(DataRow dr)
        {
            try
            {
                if (dr["FromDate"].ToString() == "" || Convert.ToDateTime(dr["ReadingMonth"]) < dtpBillMonth.Value.Date.AddDays(-1 * dtpBillMonth.Value.Date.Day))
                {
                    txtUnitFrom.Text = dr["ToReading"].ToString();
                    txtUnitTo.Text = string.Empty;
                    txtQty.Text = string.Empty;
                    txtNarration.Text = string.Empty;
                }
                else
                {
                    txtRwNo.Text = Convert.ToString(dr["BillId"]);
                    txtSetMeterID.Text = Convert.ToString(dr["BillMeterID"]);
                    dtpFromDate.Value = Convert.ToDateTime(dr["FromDate"]);
                    dtpToDate.Value = Convert.ToDateTime(dr["ToDate"]);
                    txtUnitFrom.Text = dr["FromReading"].ToString();
                    txtUnitTo.Text = dr["ToReading"].ToString();
                    txtQty.Text = dr["TotalUnits"].ToString();
                    txtNarration.Text = dr["Remarks"].ToString();
                    if (Convert.ToInt32(dr["isEdit"]) > 0)
                    {
                        cmdApply.Enabled = false;
                        btnChange.Enabled = true;
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        cmdApply.Enabled = true;
                        btnChange.Enabled = false;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }
        private void showReadings(DataRow dr, Boolean prevMonth)
        {
            try
            {
                if (prevMonth)
                {
                    txtUnitFrom.Text = dr["ToReading"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }
        private void clearForNextEntry()
        {
            this.SuspendLayout();
            txtRwNo.Text = "0";
            txtUnitTo.Text = string.Empty;
            txtUnitTo.Enabled = true;
            txtQty.Text = string.Empty;
            txtNarration.Text = String.Empty;
            this.ResumeLayout();
            dtpBillMonth.Focus();
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
                    //else q++;

                    txtQty.Text = ((q + fr) * Convert.ToDouble(txtMultiplier.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }
        private bool isValidApply()
        {
            try
            {
                if (dtpBillMonth.Value.Date >= System.DateTime.Today)
                {
                    MessageBox.Show("Bill Month is of future date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (dtpFromDate.Value.Date >= System.DateTime.Today || dtpToDate.Value.Date >= System.DateTime.Today)
                {
                    MessageBox.Show("Bill From Date or To Date is future date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (dtpBillMonth.Value.Date < dtpFromDate.Value.Date || dtpBillMonth.Value.Date > dtpToDate.Value.Date )
                {
                    MessageBox.Show("From Date or To Date is beyond BillMonth", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if ((dtpToDate.Value.Date- dtpFromDate.Value.Date).Days > 32)
                {
                    MessageBox.Show("Days between From Date or To Date is more than 1 month", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtQty.Text.Trim() == "")
                {
                    MessageBox.Show("Entry is not complete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());

                return false;
            }
        }
        private void dtpBillMonth_ValueChanged(object sender, EventArgs e)
        {
            string strSQL;
            try
            {
                strSQL = "get_BillMeterReading 1, '" + dtpBillMonth.Value.ToString("yyyyMM01") + "'";
                oDt = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL).Tables[0];
                if (oDt.Rows.Count > 0)
                {
                    DataRow dr = oDt.Rows[0];
                    showReadings(dr);
                }
                else
                {
                    txtUnitFrom.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }

        }
        private void txtUnitTo_TextChanged(object sender, EventArgs e)
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
        private void txtUnitTo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void cmdApply_Click(object sender, EventArgs e)
        {
            String strSQL;
            string strCustCode;
            int rw;
            try
            {
                if (!isValidApply())
                    return;

                rw = Convert.ToUInt16(txtRwNo.Text);

                strSQL = "exec save_BillMeterReading @BillMeterID=1,";
                if (txtSetMeterID.Text == "") strSQL += " @BillId = 0";
                else strSQL += " @BillId = " + txtSetMeterID.Text;
                strSQL += ", @BillMonth = '" + dtpBillMonth.Value.Date.ToString("yyyyMM01") + "'";
                strSQL += ", @FromDate = '" + dtpFromDate.Value.Date.ToString("yyyyMMdd") + "'";
                strSQL += ", @ToDate = '" + dtpToDate.Value.Date.ToString("yyyyMMdd") + "'";
                // strSQL += " , @BillMeterID =" + txtRwNo.Text;
                strSQL += " , @FromReading =" + txtUnitFrom.Text;
                strSQL += " , @ToReading =" + txtUnitTo.Text;
                strSQL += " , @ReadingUnits =" + txtQty.Text;
                strSQL += " , @TotalUnits =" + txtQty.Text;
                strSQL += " , @Remarks = '" + txtNarration.Text + "'";
                strSQL += " , @CreatedBy = " + DataContainer.EMP_Code;
                SqlHelper.ExecuteNonQuery(clsConnection.connStr, CommandType.Text, strSQL);
                MessageBox.Show("Data saved successfully");
                clearForNextEntry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }

            clearForNextEntry();
        }
        private void btnEntryCancel_Click(object sender, EventArgs e)
        {
            clearForNextEntry();
        }

        private void frmBillEntry_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dtMaster = new DataTable();
            String strSQL;
            string strMrterID;
            strSQL = "select bm.*, isnull(lastEntry, getdate())LastEntry from(select * from BillMeterMaster where isActive = 1 )bm";
            strSQL += " left join(select BillMeterId, max(BillMonth) LastEntry from BillMeterReading group by BillMeterId)br";
            strSQL += " on bm.BillMeterId = br.BillMeterId";
            dtMaster = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL).Tables[0];
            if (dtMaster.Rows.Count > 0)
            {
                DataRow dr = dtMaster.Rows[0];
                strMrterID = Convert.ToString( dr["BillMeterId"]);
                lblMeterSeleted.Text = "Last Bill Month - " + Convert.ToDateTime(dr["lastEntry"]).ToString("MMM-yyyy");
                dtpBillMonth.Value = Convert.ToDateTime(dr["lastEntry"]).AddMonths(1);
                strSQL = "get_BillMeters @BillMeterID = " + strMrterID + ", @isMaster=1";
                ds = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtMultiplier.Text = Convert.ToString(ds.Tables[0].Rows[0]["MultiplyingFactor"]);
                }
                else txtMultiplier.Text = "1";
            }
        }
    }
}
