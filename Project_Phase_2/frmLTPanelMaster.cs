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
    public partial class frmLTPanelMaster : Form
    {
        DataSet ds = new DataSet();
        private string _OpMode;
        public frmLTPanelMaster()
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
            if (txtLTOpening.Text == "")
            {
                MessageBox.Show("Please enter Opening Reading", "Warning", MessageBoxButtons.OK);
                txtLTOpening.Focus();
                return false;
            }
            if (txtLTFactor.Text == "")
            {
                MessageBox.Show("Please enter Multiplying Factor", "Warning", MessageBoxButtons.OK);
                txtLTFactor.Focus();
                return false;
            }
            return true;
        }
        private void getMaster()
        {
            try
            {
                DataTable dtMaster = new DataTable();
                dtMaster = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_ElecLocation 'Select'").Tables[0];
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
                grdData.Model[0, 6].Text = "Is Active?";
                grdData.Model[0, 7].Text = "Location";
                grdData.Model[0, 8].Text = "LocationId";
                grdData.IgnoreReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }
        private void fillGrid()
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_PanelMeters @isMaster=1");
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
                        grdData.Model[rw, 6].Text = Convert.ToString(dr["isActive"]);
                        grdData.Model[rw, 7].Text = Convert.ToString(dr["LocationName"]);
                        grdData.Model[rw, 8].Text = Convert.ToString(dr["LocationId"]);
                        rw++;
                    }
                    grdData.SetColHidden(1, 1, true);

                    grdData.SetColHidden(8, 8, true);
                    grdData.SetColWidth(4, 4, 120);
                    grdData.SetColWidth(7, 7, 120);
                    this.grdData.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(2, 4));
                }
                grdData.ResumeLayout();
                grdData.IgnoreReadOnly = false;
                // SET TREEVIEW
                try
                {
                    trvMapping.Nodes.Clear();
                    string strL = string.Empty;
                    TreeNode trN;
                    TreeNode trLTP;
                    TreeNode trSetMeterID;
                    DataTable dtTr = new DataTable();
                    dtTr = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "select * from vu_LTPanelSetMeter order by LTPanelId").Tables[0];
                    if (dtTr != null && dtTr.Rows.Count > 0)
                    {
                        strL = dtTr.Rows[0]["PanelMeter"].ToString();
                        trN = new TreeNode(strL);
                        trN.Tag = "PNL-" + dtTr.Rows[0]["LTPanelID"].ToString();
                        trvMapping.Nodes.Add(trN);
                        for (int i = 0; i < dtTr.Rows.Count; i++)
                        {
                            if (dtTr.Rows[i]["PanelMeter"].ToString() == strL)
                            {
                                trLTP = new TreeNode(dtTr.Rows[i]["ElectricMeter"].ToString());
                                trLTP.Tag = "SET-" + dtTr.Rows[i]["SetMeterId"].ToString();
                                trN.Nodes.Add(trLTP);
                            }
                            else
                            {
                                strL = dtTr.Rows[i]["PanelMeter"].ToString();
                                trN = new TreeNode(strL);
                                trN.Tag = "PNL-" + dtTr.Rows[i]["LTPanelID"].ToString();
                                trvMapping.Nodes.Add(trN);
                                trLTP = new TreeNode(dtTr.Rows[i]["ElectricMeter"].ToString());
                                trLTP.Tag = "SET-" + dtTr.Rows[i]["SetMeterID"].ToString();
                                trN.Nodes.Add(trLTP);
                            }
                        }
                    }

                    //dtTr = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "select * from vu_LTPanelSetMeter order by LocationName").Tables[0];

                    /*                   
                     *                    if (dtTr != null && dtTr.Rows.Count > 0)
                                        {
                                            strL = dtTr.Rows[0]["LocationName"].ToString();
                                            trN = new TreeNode(strL);
                                            trN.Tag = "LOC-" + dtTr.Rows[0]["LocationID"].ToString();
                                            trvMapping.Nodes.Add(trN);
                                            trLTP = new TreeNode(dtTr.Rows[0]["PanelMeter"].ToString());
                                            trLTP.Tag = "PNL-" + dtTr.Rows[0]["LTPanelID"].ToString();
                                            trN.Nodes.Add(trLTP);
                                            for (int i = 0; i < dtTr.Rows.Count; i++)
                                            {
                                                if (dtTr.Rows[i]["LocationName"].ToString() == strL)
                                                {
                                                    if ("PNL-" + dtTr.Rows[i]["LTPanelID"].ToString() != trLTP.Tag.ToString())
                                                    {
                                                        trLTP = new TreeNode(dtTr.Rows[i]["PanelMeter"].ToString());
                                                        trLTP.Tag = "PNL-" + dtTr.Rows[i]["LTPanelID"].ToString();
                                                        trN.Nodes.Add(trLTP);
                                                    }
                                                    trSetMeterID = new TreeNode(dtTr.Rows[i]["ElectricMeter"].ToString());
                                                    trSetMeterID.Tag = trLTP.Tag.ToString() + "-SET-" + dtTr.Rows[i]["SetMeterId"].ToString();
                                                    trLTP.Nodes.Add(trSetMeterID);
                                                }
                                                else
                                                {
                                                    strL = dtTr.Rows[i]["LocationName"].ToString();
                                                    trN = new TreeNode(strL);
                                                    trN.Tag = "LOC-" + dtTr.Rows[i]["LocationID"].ToString();
                                                    trvMapping.Nodes.Add(trN);
                                                    trLTP = new TreeNode(dtTr.Rows[i]["PanelMeter"].ToString());
                                                    trLTP.Tag = "PNL-" + dtTr.Rows[i]["LTPanelID"].ToString();
                                                    trN.Nodes.Add(trLTP);
                                                    trSetMeterID = new TreeNode(dtTr.Rows[i]["ElectricMeter"].ToString());
                                                    trSetMeterID.Tag = trLTP.Tag.ToString() + "-SET-" + dtTr.Rows[i]["SetMeterId"].ToString();
                                                    trLTP.Nodes.Add(trSetMeterID);
                                                    //trLTP.Nodes.Add(dtTr.Rows[i]["SetMeterId"].ToString(), dtTr.Rows[i]["ElectricMeter"].ToString());
                                                }
                                            }
                                        }
                                        */
                    /*
                    dtTr = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "select em.* from ElectricityMeterMaster em where (setId is not null )and isactive= 1 and (select count(SetMeterID) from LTPanelMapping ltp where em.SetMeterID = ltp.SetMeterID ) = 0").Tables[0];
                    if (dtTr != null && dtTr.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtTr.Rows.Count; i++)
                        {
                            ListViewItem lsvItem = new ListViewItem();
                            lsvItem.Text = dtTr.Rows[i]["SetMeterId"].ToString();
                            lsvItem.SubItems.Add(dtTr.Rows[i]["MeterName"].ToString());
                            lsvItem.SubItems.Add(dtTr.Rows[i]["LocationId"].ToString());
                            lsvItem.SubItems.Add("");
                            lsvSetMaster.Items.Add(lsvItem);
                        }
                    }
                    */
                }
                catch (Exception exTr)
                {
                    MessageBox.Show(exTr.ToString());
                    clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + exTr.ToString());
                }
                // SET SEQUENCE
                try
                {
                    DataSet dsSeq = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "ph2_MeterSerial ");
                    if ((dsSeq != null) && dsSeq.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsSeq.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = dsSeq.Tables[0].Rows[i];
                            ListViewItem lsvSrl = new ListViewItem();

                            lsvSrl.SubItems[0].Text = Convert.ToString(dr["SerialID"]);
                            lsvSrl.SubItems.Add(Convert.ToString(dr["MeterType"]));
                            lsvSrl.SubItems.Add(Convert.ToString(dr["SetMeterId"]));
                            lsvSrl.SubItems.Add(Convert.ToString(dr["MeterName"]));
                            lsvSrl.SubItems.Add(Convert.ToString(dr["SerialNo"]));
                            lsvSequence.Items.Add(lsvSrl);
                        }
                    }
                }
                catch (Exception extab3)
                {
                    MessageBox.Show(extab3.Message);
                    clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + extab3.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
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
                        tabMaster.SelectedIndex = 0;
                        break;
                    }
                case "NEW":
                    {
                        txtSetMeterID.Text = "0";
                        txtMeterName.Text = string.Empty;
                        txtMeterNo.Text = string.Empty;

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
                        string strSQL = "get_PanelMeters @SetMeterID = " + txtSetMeterID.Text + ", @isMaster=1";
                        ds = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            txtMeterName.Text = Convert.ToString(dr["MeterName"]);
                            txtMeterNo.Text = Convert.ToString(dr["MeterNo"]);
                            if (Convert.ToString(dr["isActive"]) == "YES")
                            {
                                dbcLTActive.Text = "YES";
                                lblLTToDate.Visible = false;
                                dtpLTToDate.Visible = false;
                            }
                            else
                            {
                                dbcLTActive.Text = "NO";
                                lblLTToDate.Visible = true;
                                dtpLTToDate.Visible = true;
                            }
                            txtLTOpening.Text = Convert.ToString(dr["StartReading"]);
                            txtLTFactor.Text = Convert.ToString(dr["MultiplyingFactor"]);
                            dbcLocation.SelectedValue = Convert.ToInt32(dr["LocationId"]);
                            dtpLTFromDate.Value = Convert.ToDateTime(dr["FromDate"]);
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
                            dbcLTActive.Text = "YES";
                            dbcLTActive.Enabled = false;
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
                    strSQL = "exec save_ElecMeterLT ";
                    strSQL += "@SetMeterID = " + txtSetMeterID.Text;
                    strSQL += ", @SetID = null";
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


                    this.Cursor = Cursors.Default;
                    fillGrid();
                    MessageBox.Show("Data saved successfully");
                    setOpMode("VIEW");
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message);
                    clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            TreeNode trSetMeterID;
            string strSQL;

            TreeNode trX;
            string strSetMeterID;
            string strSetMeterName;
            ListViewItem lsvItem = new ListViewItem();
            try
            {
                trX = trvMapping.SelectedNode;
                if (trX.Tag.ToString().Contains("-SET-"))
                {
                    strSetMeterID = trX.Tag.ToString();
                    strSetMeterName = trX.Text;
                    lsvItem.Text = strSetMeterID;
                    lsvItem.SubItems.Add(strSetMeterName);
                    lsvItem.SubItems.Add(trX.Parent.Tag.ToString());
                    lsvItem.SubItems.Add(trX.Parent.Parent.Tag.ToString());
                    lsvSetMaster.Items.Add(lsvItem);
                    trvMapping.Nodes.Remove(trX);
                    // Update Mapping Table
                    //int iSetID = Convert.ToInt32((strSetMeterID.Split('-')[strSetMeterID.Split('-').Length - 1]));
                    //strSQL = "delete from LTPanelMapping where LocationId= " + lsvItem.SubItems[3].Text.Split('-')[1] + " and LTPanelId=" + lsvItem.SubItems[2].Text.Split('-')[1] + " and SetMeterId=" + iSetID.ToString();
                    //SqlHelper.ExecuteNonQuery(clsConnection.conn, CommandType.Text, strSQL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TreeNode trX;
            TreeNode trSetMeterID;
            string strSetMeterID;
            string strSetMeterName;
            string strSQL;
            ListViewItem lsvItem = new ListViewItem();
            try
            {
                trX = trvMapping.SelectedNode;
                lsvItem = lsvSetMaster.SelectedItems[0];
                //if (lsvItem.SubItems[0].Text.ToString().Contains(trX.Tag.ToString()))
                {
                    if (trX.Tag.ToString().Contains("PNL-"))
                    {
                        trSetMeterID = new TreeNode();
                        trSetMeterID.Tag = lsvItem.Text;
                        trSetMeterID.Text = lsvItem.SubItems[1].Text;
                        trX.Nodes.Add(trSetMeterID);
                        lsvSetMaster.SelectedItems[0].Remove();
                        // Update Mapping Table
                        int iLocationID;
                        int iPanelID;
                        int iSetID;
                        iLocationID = Convert.ToInt32((trX.Parent.Tag.ToString().Split('-'))[1]);
                        string tg = trX.Tag.ToString().Substring(trX.Tag.ToString().IndexOf("PNL"));
                        iPanelID = Convert.ToInt32(tg.Split('-')[1]);
                        tg = trSetMeterID.Tag.ToString().Substring(trSetMeterID.Tag.ToString().IndexOf("SET"));
                        iSetID = Convert.ToInt32(tg.Split('-')[1]);
                        //strSQL = "insert into LTPanelMapping (LocationID, LTPanelID, SetMeterID, isActive, FromDate, CreatedOn, CreatedBy)";
                        //strSQL += " values (" + iLocationID.ToString() + "," + iPanelID.ToString() + "," + iSetID + ", 1,'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', getdate(), " + DataContainer.EMP_Code + ")";
                        //SqlHelper.ExecuteNonQuery(clsConnection.conn, CommandType.Text, strSQL);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        private void tabMap_Click(object sender, EventArgs e)
        {

        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            if (lsvSequence.SelectedIndices[0] > 0)
            {
                int iPrev;
                iPrev = lsvSequence.SelectedIndices[0] - 1;
                ListViewItem lsvCurrent = lsvSequence.SelectedItems[0];
                ListViewItem lsvTemp = new ListViewItem();
                lsvTemp.Text = lsvCurrent.Text;
                lsvTemp.SubItems[0].Text = lsvCurrent.SubItems[0].Text;
                lsvTemp.SubItems.Add(lsvCurrent.SubItems[1].Text);
                lsvTemp.SubItems.Add(lsvCurrent.SubItems[2].Text);
                lsvTemp.SubItems.Add(lsvCurrent.SubItems[3].Text);

                lsvCurrent.Text = lsvSequence.Items[iPrev].Text;
                lsvCurrent.SubItems[0].Text = lsvSequence.Items[iPrev].SubItems[0].Text;
                lsvCurrent.SubItems[1].Text = lsvSequence.Items[iPrev].SubItems[1].Text;
                lsvCurrent.SubItems[2].Text = lsvSequence.Items[iPrev].SubItems[2].Text;
                lsvCurrent.SubItems[3].Text = lsvSequence.Items[iPrev].SubItems[3].Text;

                lsvSequence.Items[iPrev].Text = lsvTemp.Text;
                lsvSequence.Items[iPrev].SubItems[0].Text = lsvTemp.SubItems[0].Text;
                lsvSequence.Items[iPrev].SubItems[1].Text = lsvTemp.SubItems[1].Text;
                lsvSequence.Items[iPrev].SubItems[2].Text = lsvTemp.SubItems[2].Text;
                lsvSequence.Items[iPrev].SubItems[3].Text = lsvTemp.SubItems[3].Text;
            }
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            if (lsvSequence.SelectedIndices[0] < lsvSequence.Items.Count - 1)
            {
                int iPrev;
                iPrev = lsvSequence.SelectedIndices[0] + 1;
                ListViewItem lsvCurrent = lsvSequence.SelectedItems[0];
                ListViewItem lsvTemp = new ListViewItem();
                lsvTemp.Text = lsvCurrent.Text;
                lsvTemp.SubItems[0].Text = lsvCurrent.SubItems[0].Text;
                lsvTemp.SubItems.Add(lsvCurrent.SubItems[1].Text);
                lsvTemp.SubItems.Add(lsvCurrent.SubItems[2].Text);
                lsvTemp.SubItems.Add(lsvCurrent.SubItems[3].Text);

                lsvCurrent.Text = lsvSequence.Items[iPrev].Text;
                lsvCurrent.SubItems[0].Text = lsvSequence.Items[iPrev].SubItems[0].Text;
                lsvCurrent.SubItems[1].Text = lsvSequence.Items[iPrev].SubItems[1].Text;
                lsvCurrent.SubItems[2].Text = lsvSequence.Items[iPrev].SubItems[2].Text;
                lsvCurrent.SubItems[3].Text = lsvSequence.Items[iPrev].SubItems[3].Text;

                lsvSequence.Items[iPrev].Text = lsvTemp.Text;
                lsvSequence.Items[iPrev].SubItems[0].Text = lsvTemp.SubItems[0].Text;
                lsvSequence.Items[iPrev].SubItems[1].Text = lsvTemp.SubItems[1].Text;
                lsvSequence.Items[iPrev].SubItems[2].Text = lsvTemp.SubItems[2].Text;
                lsvSequence.Items[iPrev].SubItems[3].Text = lsvTemp.SubItems[3].Text;
            }

        }

        private void btnAPPLY_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvSequence.Items.Count; i++)
            {
                try
                {
                    string strsql = "update ElecMeterPanelSerial set ";
                    strsql += "MeterType ='" + lsvSequence.Items[i].SubItems[1].Text + "', SetMeterID=" + lsvSequence.Items[i].SubItems[2].Text + ", SerialNo=" + lsvSequence.Items[i].SubItems[4].Text;
                    strsql += "where SerialID= " + lsvSequence.Items[i].SubItems[0].Text;
                    SqlHelper.ExecuteNonQuery(clsConnection.conn, CommandType.Text, strsql);
                }
                catch (Exception eSerl)
                { MessageBox.Show(i.ToString() + " " + eSerl.ToString());
                    clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + eSerl.ToString());
                }
            }
        }
    }
}
