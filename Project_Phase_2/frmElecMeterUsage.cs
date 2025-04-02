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
    public partial class frmElecMeterUsage : Form
    {
        DataSet ds = new DataSet();
        private string _OpMode;
        public frmElecMeterUsage()
        {
            InitializeComponent();
        }
        private Boolean ValidateData()
        {
            if (txtMeterUsage.Text == "")
            {
                MessageBox.Show("Please enter Usage Description", "Warning", MessageBoxButtons.OK);
                txtMeterUsage.Focus();
                return false;
            }
            if (txtShortCode.Text == "")
            {
                MessageBox.Show("Please enter Short Code", "Warning", MessageBoxButtons.OK);
                txtShortCode.Focus();
                return false;
            }
            if (dbcUsageType.Text == "")
            {
                MessageBox.Show("Please select Usage Type", "Warning", MessageBoxButtons.OK);
                dbcUsageType.Focus();
                return false;
            }
            return true;
        }
        private void getMaster()
        {
            try
            {
                DataTable dtMaster = new DataTable();
                dtMaster = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "getElecMeterUsage @parentonly=1").Tables[0];
                dbcUsageType.DisplayMember = "usage_purpose";
                dbcUsageType.ValueMember = "ElecMeterUsageId";
                dbcUsageType.DataSource = dtMaster;
                dbcUsageType.Refresh();
                grdData.IgnoreReadOnly = true;

                grdData.Model[0, 1].Text = "ElecMeterUsageId";
                grdData.Model[0, 2].Text = "Usage Purpose";
                grdData.Model[0, 3].Text = "Short Code";
                grdData.Model[0, 4].Text = "usage_parent_id";
                grdData.Model[0, 5].Text = "Parent";
                grdData.Model[0, 6].Text = "isRevenueHead";
                grdData.IgnoreReadOnly = false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void fillGrid()
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "getElecMeterUsage");
                grdData.IgnoreReadOnly = true;
                grdData.SuspendLayout();
                int rw = 1;
                if (grdData.Model.RowCount >= 1)
                    grdData.Rows.RemoveRange(1, grdData.Model.RowCount);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdData.Rows.InsertRange(1, ds.Tables[0].Rows.Count);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        grdData.Model[rw, 1].Text = Convert.ToString(dr["ElecMeterUsageId"]);
                        grdData.Model[rw, 2].Text = Convert.ToString(dr["usage_purpose"]);
                        grdData.Model[rw, 3].Text = Convert.ToString(dr["usage_short_code"]);
                        grdData.Model[rw, 4].Text = Convert.ToString(dr["usage_parent_id"]);
                        grdData.Model[rw, 5].Text = Convert.ToString(dr["parent"]);
                        grdData.Model[rw, 6].Text = Convert.ToString(dr["isRevenueHead"]);
                        rw++;
                    }
                    grdData.SetColHidden(1, 1, true);
                    grdData.SetColHidden(4, 4, true);
                    grdData.SetColHidden(6, 6, true);
                    grdData.SetColWidth(2, 2, 120);
                    grdData.SetColWidth(5, 5, 120);
                    //this.grdData.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(2, 4));
                }
                grdData.ResumeLayout();
                grdData.IgnoreReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void setOpMode(string value)
        {
            _OpMode = value;
            switch (_OpMode)
            {
                case "VIEW":
                    {
                        grpEntry.Enabled = false;
                        grdData.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        tabMaster.SelectedIndex = 0;
                        break;
                    }
                case "NEW":
                    {
                        txtSetMeterID.Text = "0";
                        dbcActive.Text = "YES";
                        dbcisRevenue.Text = "YES";
                        txtMeterUsage.Text = string.Empty;
                        txtShortCode.Text = string.Empty;

                        grpEntry.Enabled = true;
                        grdData.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        tabMaster.SelectedIndex = 1;
                        break;
                    }
                case "EDIT":
                    {
                        int rw = grdData.CurrentCell.RowIndex;
                        if (rw == 0) break;

                        txtSetMeterID.Text = grdData.Model[rw, 1].Text;
                        txtMeterUsage.Text = grdData.Model[rw, 2].Text;
                        txtShortCode.Text = grdData.Model[rw, 3].Text;
                        if (grdData.Model[rw, 6].Text == "1")
                            dbcisRevenue.Text = "YES";
                        else
                            dbcisRevenue.Text = "NO";
                        txtParent.Text = grdData.Model[rw, 4].Text;
                        dbcUsageType.SelectedValue = grdData.Model[rw, 4].Text;
                        grpEntry.Enabled = true;
                        grdData.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        tabMaster.SelectedIndex = 1;
                        break;
                    }
                default:
                    break;
            }
        }

        private void frmElecMeterUsage_Load(object sender, EventArgs e)
        {
            getMaster();
            fillGrid();
            setOpMode("VIEW");
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdData.CurrentCell.RowIndex > 0)
                setOpMode("EDIT");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setOpMode("VIEW");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            setOpMode("NEW");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                string strSQL = "";
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    strSQL = "exec save_ElecMeterUsage ";
                    strSQL += "@ElecMeterUsageId = " + txtSetMeterID.Text;
                    if (dbcisRevenue.Text.ToUpper() == "YES") strSQL += ", @isRevenue=1";
                    else strSQL += ", @isRevenue=0";
                    strSQL += ", @Usage_Purpose = '" + txtMeterUsage.Text + "'";
                    strSQL += ", @usage_short_code = '" + txtShortCode.Text + "'";
                    strSQL += ", @Usage_Parent_Id = " + dbcUsageType.SelectedValue.ToString();
                    //if (dbcActive.Text == "YES")
                        strSQL += ", @isActive=1";
                    //else strSQL += ", @isActive =0";
                    strSQL += ", @CreatedBy = " + DataContainer.EMP_Code;
                    SqlHelper.ExecuteNonQuery(clsConnection.conn, CommandType.Text, strSQL);

                    this.Cursor = Cursors.Default;
                    fillGrid();
                    MessageBox.Show("Data saved successfully");
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.ToString());
                }
            }
            setOpMode("VIEW");
        }
        private void grdData_CellDoubleClick(object sender, Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs e)
        {
            setOpMode("EDIT");
        }

        private void dbcUsageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dbcUsageType.SelectedIndex == 0) dbcisRevenue.Text = "YES";
            else dbcisRevenue.Text = "NO";
        }
    }
    
}


