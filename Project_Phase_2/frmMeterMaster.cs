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
    public partial class frmMeterMaster : Form
    {
        DataSet ds = new DataSet();
        private string _OpMode;
        public frmMeterMaster()
        {
            InitializeComponent();
        }

        private Boolean ValidateData()
        {
            if (dbcLocation.Text.Contains("SELECT"))
            {
                MessageBox.Show("Please select Location", "Warning", MessageBoxButtons.OK);
                dbcLocation.Focus();
                return false;
            }
            if (txtMeterName.Text == "")
            {
                MessageBox.Show("Please enter Meter Name", "Warning", MessageBoxButtons.OK);
                txtMeterName.Focus();
                return false;
            }
            if (txtOpening.Text == "")
            {
                MessageBox.Show("Please enter Opening Reading", "Warning", MessageBoxButtons.OK);
                txtOpening.Focus();
                return false;
            }
            if (txtFactor.Text == "")
            {
                MessageBox.Show("Please enter Multiplying Factor", "Warning", MessageBoxButtons.OK);
                txtFactor.Focus();
                return false;
            }
            return true;
        }
        private void getMaster()
        {
            try
            {
                DataTable dtMaster = new DataTable();
                dtMaster = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_SetMaster 'Select'").Tables[0];
                dbcSet.DisplayMember = "SetName";
                dbcSet.ValueMember = "SetId";
                dbcSet.DataSource = dtMaster;
                dbcSet.Refresh();


                dtMaster = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_ElecLocation 'Select'").Tables[0];
                //DataRow dr = dtMaster.NewRow();
                //dr["LocationDesc"] = "-- SELECT --";
                //dr["LocationId"] = -1;
                //dtMaster.Rows.Add(dr);
                dbcLocation.DisplayMember = "LocationDesc";
                dbcLocation.ValueMember = "LocationId";
                dbcLocation.DataSource = dtMaster;
                dbcLocation.Refresh();

                grdData.IgnoreReadOnly = true;
                grdData.Model[0, 1].Text = "MeterId";
                grdData.Model[0, 2].Text = "Meter Name";
                grdData.Model[0, 3].Text = "Number";
                grdData.Model[0, 4].Text = "Reading";
                grdData.Model[0, 5].Text = "MF";
                grdData.Model[0, 6].Text = "Set Name";
                grdData.Model[0, 7].Text = "Makeup Room";
                grdData.Model[0, 8].Text = "Is Active?";
                grdData.Model[0, 9].Text = "Location";
                grdData.Model[0, 10].Text = "LocationId";
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
                ds = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_ElecMeters @isMaster=1");
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
                        grdData.Model[rw, 1].Text = Convert.ToString(dr["SetMeterId"]);
                        grdData.Model[rw, 2].Text = Convert.ToString(dr["MeterName"]);
                        grdData.Model[rw, 3].Text = Convert.ToString(dr["MeterNo"]);
                        grdData.Model[rw, 4].Text = Convert.ToString(dr["StartReading"]);
                        grdData.Model[rw, 5].Text = Convert.ToString(dr["MultiplyingFactor"]);
                        grdData.Model[rw, 6].Text = Convert.ToString(dr["SetName"]);
                        grdData.Model[rw, 7].Text = Convert.ToString(dr["isMakeupRoom"]);
                        grdData.Model[rw, 8].Text = Convert.ToString(dr["isActive"]);
                        grdData.Model[rw, 9].Text = Convert.ToString(dr["LocationName"]);
                        grdData.Model[rw, 10].Text = Convert.ToString(dr["LocationId"]);
                        rw++;
                    }
                    grdData.SetColHidden(1, 1, true);

                    grdData.SetColHidden(10, 10, true);
                    grdData.SetColWidth(6, 6, 120);
                    grdData.SetColWidth(9, 9, 120);
                    this.grdData.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(2, 4));
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
                        dbcLTActive.Text = "YES";
                        lblLTToDate.Visible = false;
                        dtpLTToDate.Visible = false;
                        txtLTOpening.Text = string.Empty;
                        txtLTFactor.Text = "1";
                        dtpLTFromDate.Value = System.DateTime.Today;
                        pnlLT.Visible = false;
                        tabMaster.SelectedIndex = 0;
                        break;
                    }
                case "NEW":
                    {
                        txtSetMeterID.Text = "0";
                        dbcActive.Text = "YES";
                        dbcMakeupRoom.Text = "NO";
                        lblToDate.Visible = false;
                        dtpToDate.Visible = false;
                        txtMeterName.Text = string.Empty;
                        txtMeterNo.Text = string.Empty;
                        txtOpening.Text = string.Empty;
                        txtFactor.Text = "1";
                        dtpFromDate.Value = System.DateTime.Today;

                        dbcLTActive.Text = "YES";
                        lblLTToDate.Visible = false;
                        dtpLTToDate.Visible = false;
                        txtLTOpening.Text = string.Empty;
                        txtLTFactor.Text = "1";
                        dtpLTFromDate.Value = System.DateTime.Today;

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
                        string strSQL = "get_ElecMeters @SetMeterID = " + txtSetMeterID.Text + ", @isMaster=1";
                        ds = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            txtMeterName.Text = Convert.ToString(dr["MeterName"]);
                            txtMeterNo.Text = Convert.ToString(dr["MeterNo"]);
                            txtOpening.Text = Convert.ToString(dr["StartReading"]);
                            txtFactor.Text = Convert.ToString(dr["MultiplyingFactor"]);
                            //if (dr["SetID"] is DBNull)
                            //{
                            //    dbcSet.SelectedValue = 0;
                            //    pnlLT.Visible = false;
                            //}
                            //else
                            //{
                            //    dbcSet.SelectedValue = Convert.ToInt32(dr["SetId"]);
                            //    pnlLT.Visible = true;
                            //    txtLTFactor.Text = Convert.ToString(dr["MultiplyingFactorLT"]);
                            //    txtLTOpening.Text = Convert.ToString(dr["StartReadingLT"]);
                            //    dtpLTFromDate.Value = Convert.ToDateTime(dr["FromDateLT"]);
                            //    dbcLTActive.SelectedText = Convert.ToString(dr["isActiveLT"]);
                            //    // dtpLTToDate.Value = Convert.ToDateTime(dr["ToDateLT"]);
                            //}

                            dtpFromDate.Value = Convert.ToDateTime(dr["FromDate"]);
                            if (Convert.ToString(dr["isMakeupRoom"]) == "YES") dbcMakeupRoom.Text = "YES";
                            else dbcMakeupRoom.Text = "NO";
                            if (Convert.ToString(dr["isActive"]) == "YES")
                            {
                                dbcActive.Text = "YES";
                                lblToDate.Visible = false;
                                dtpToDate.Visible = false;
                            }
                            else
                            {
                                dbcActive.Text = "NO";
                                lblToDate.Visible = true;
                                dtpToDate.Visible = true;
                            }
                            dbcLocation.SelectedValue = Convert.ToInt32(dr["LocationId"]);
                        }
                        grpEntry.Enabled = true;
                        grdData.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        tabMaster.SelectedIndex = 1;
                        break;
                    }
                case "REPLACE":
                    {
                        int rw = grdData.CurrentCell.RowIndex;
                        if (rw == 0) break;
                        txtSetMeterID.Text = grdData.Model[rw, 1].Text;
                        string strSQL = "get_ElecMeters @SetMeterID = " + txtSetMeterID.Text;
                        ds = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            txtMeterName.Text = Convert.ToString(dr["MeterName"]);
                            txtMeterName.Enabled = false;
                            txtMeterNo.Text = string.Empty;
                            txtOpening.Text = string.Empty;
                            txtFactor.Text = string.Empty;
                            if (dr["SetID"] is DBNull) dbcSet.SelectedValue = 0;
                            else dbcSet.SelectedValue = Convert.ToInt32(dr["SetId"]);
                            dbcSet.Enabled = false;
                            dtpFromDate.Value = System.DateTime.Today;
                            if (Convert.ToString(dr["isMakeupRoom"]) == "YES") dbcMakeupRoom.Text = "YES";
                            else dbcMakeupRoom.Text = "NO";
                            dbcMakeupRoom.Enabled = false;

                            //if (Convert.ToString(dr["isActive"]) == "YES")
                            //{
                            dbcActive.Text = "YES";
                            //    lblToDate.Visible = false;
                            //    dtpToDate.Visible = false;
                            //}
                            //else
                            //{
                            //    dbcActive.Text = "NO";
                            //    lblToDate.Visible = true;
                            //    dtpToDate.Visible = true;
                            //}
                            dbcActive.Enabled = false;
                        }
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
        private void frmMeterMaster_Load(object sender, EventArgs e)
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
                    strSQL = "exec save_ElecMeterMaster ";
                    strSQL += "@SetMeterID = " + txtSetMeterID.Text;
                    if (dbcSet.Text.ToUpper().StartsWith(" --") || dbcSet.Text.ToUpper() == "") strSQL += ", @SetID=NULL";
                    else strSQL += ", @SetID = " + dbcSet.SelectedValue.ToString();
                    strSQL += ", @MeterName = '" + txtMeterName.Text + "'";
                    if (txtMeterNo.Text == "") strSQL += ", @MeterNo = NULL";
                    else strSQL += ", @MeterNo = '" + txtMeterNo.Text + "'";
                    strSQL += ", @factor =" + txtFactor.Text;
                    strSQL += ", @StartReading = " + txtOpening.Text;
                    if (dbcMakeupRoom.Text == "NO")
                        strSQL += ", @isMakeupRoom = 0 ";
                    else strSQL += ", @isMakeupRoom = 1 ";
                    if (dbcActive.Text == "YES")
                    {
                        strSQL += ", @isActive = 1";
                        strSQL += ", @ToDate = NULL";
                    }
                    else
                    {
                        strSQL += ", @isActive = 0";
                        strSQL += ", @ToDate = '" + dtpToDate.Value.Date.ToString("yyyyMMdd") + "'";
                    }
                    strSQL += ", @FromDate = '" + dtpFromDate.Value.Date.ToString("yyyyMMdd") + "'";

                    strSQL += ", @CreatedBy = " + DataContainer.EMP_Code;
                    strSQL += ", @LocationId = " + dbcLocation.SelectedValue.ToString();
                    strSQL += ", @OpMode = '" + _OpMode + "'";
                    SqlHelper.ExecuteNonQuery(clsConnection.conn, CommandType.Text, strSQL);
                    if (pnlLT.Visible)
                    {
                        strSQL = "exec save_ElecMeterLT ";
                        strSQL += "@SetMeterID = " + txtSetMeterID.Text;
                        strSQL += ", @SetID = " + dbcSet.SelectedValue.ToString();
                        strSQL += ", @MeterName = '" + txtMeterName.Text + "'";
                        if (txtMeterNo.Text == "") strSQL += ", @MeterNo = NULL";
                        else strSQL += ", @MeterNo = '" + txtMeterNo.Text + "'";
                        strSQL += ", @factor =" + txtLTFactor.Text;
                        strSQL += ", @StartReading = " + txtLTOpening.Text;
                        if (dbcLTActive.Text == "YES")
                        {
                            strSQL += ", @isActive = 1";
                            strSQL += ", @ToDate = NULL";
                        }
                        else
                        {
                            strSQL += ", @isActive = 0";
                            strSQL += ", @ToDate = '" + dtpLTToDate.Value.Date.ToString("yyyyMMdd") + "'";
                        }
                        strSQL += ", @FromDate = '" + dtpLTFromDate.Value.Date.ToString("yyyyMMdd") + "'";

                        strSQL += ", @CreatedBy = " + DataContainer.EMP_Code;
                        strSQL += ", @LocationId = " + dbcLocation.SelectedValue.ToString();
                        strSQL += ", @OpMode = '" + _OpMode + "'";
                        SqlHelper.ExecuteNonQuery(clsConnection.conn, CommandType.Text, strSQL);
                    }

                    this.Cursor = Cursors.Default;
                    fillGrid();
                    MessageBox.Show("Data saved successfully");
                    setOpMode("VIEW");
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void grpEntry_Enter(object sender, EventArgs e)
        {

        }

        private void txtOpening_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void dbcActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dbcActive.Text == "NO")
            {
                dtpToDate.Visible = true;
                lblToDate.Visible = true;
            }
            else
            {
                dtpToDate.Visible = false;
                lblToDate.Visible = false;
            }
        }

        private void grdData_CellDoubleClick(object sender, Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs e)
        {
            setOpMode("EDIT");
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            setOpMode("REPLACE");
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dbcLTActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dbcLTActive.Text == "NO")
            {
                dtpLTToDate.Visible = true;
                lblLTToDate.Visible = true;
            }
            else
            {
                dtpLTToDate.Visible = false;
                lblLTToDate.Visible = false;
            }
        }
    }
}
