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
    public partial class frmMakeupRoom : Form
    {
        DataSet ds = new DataSet();
        private string _OpMode;

        public frmMakeupRoom()
        {
            InitializeComponent();
        }
        private void getMaster()
        {
            try
            {
                DataTable dtMaster = new DataTable();

                dtMaster = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "get_MakeupRoomArea").Tables[0];
                dbcMakeupRoomArea.DisplayMember = "MakeuproomArea";
                dbcMakeupRoomArea.ValueMember = "MakeupRoomId";
                dbcMakeupRoomArea.DataSource = dtMaster;
                dtMaster = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_SetMaster 'Select'").Tables[0];
                dbcSet.DisplayMember = "SetName";
                dbcSet.ValueMember = "SetId";
                dbcSet.DataSource = dtMaster;
                dbcSet.Refresh();
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
                ds = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_MakeupRoom '" + dbcMakeupRoomArea.Text.ToString() + "'");
                grdData.Model[0, 1].Text = "MakeupRoomId";
                grdData.Model[0, 2].Text = "Number";
                grdData.Model[0, 3].Text = "Location";
                grdData.Model[0, 4].Text = "Set Name";
                grdData.Model[0, 5].Text = "Is Active?";
                int rw = 1;
                grdData.SuspendLayout();
                if (grdData.Model.RowCount >= 1)
                    grdData.Rows.RemoveRange(1, grdData.Model.RowCount);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdData.Rows.InsertRange(1, ds.Tables[0].Rows.Count);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        grdData.Model[rw, 1].Text = Convert.ToString(dr["MakeupRoomId"]);
                        grdData.Model[rw, 2].Text = Convert.ToString(dr["MakeupRoomNo"]);
                        grdData.Model[rw, 3].Text = Convert.ToString(dr["MakeupRoomArea"]);
                        grdData.Model[rw, 4].Text = Convert.ToString(dr["SetName"]);
                        rw++;
                    }
                    this.grdData.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(2, 4));
                    grdData.SetColHidden(1, 1, true);
                }
            }
            catch (Exception ex)
            {
                throw;
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
                        lblTo.Visible = true;
                        txtRoomDesc.Text = string.Empty;
                        txtRoomFrom.Text = string.Empty;
                        txtRoomTo.Text = string.Empty;
                        dbcSet.SelectedIndex =-1;
                        dbcActive.Text = "YES";
                        tabMaster.SelectedIndex = 0;
                        break;
                    }
                case "NEW":
                    {
                        grpEntry.Enabled = true;
                        grdData.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        txtRoomFrom.Enabled = true;
                        txtRoomTo.Enabled = true;
                        txtRoomTo.Visible = true;
                        lblTo.Visible = true;
                        dbcActive.Text = "YES";
                        tabMaster.SelectedIndex = 1;
                        break;
                    }
                case "EDIT":
                    {
                        int rw = grdData.CurrentCell.RowIndex;
                        if (rw == 0) break;
                        txtRoomDesc.Text = grdData.Model[rw, 3].Text;
                        txtRoomFrom.Text = grdData.Model[rw, 2].Text;
                        txtMakeupRoomId.Text = grdData.Model[rw, 1].Text;
                        string strSQL = "get_MakeupRoomData @MakeupRoomId = " + txtMakeupRoomId.Text;
                        ds = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            dbcSet.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["SetId"]);
                        }
                        grpEntry.Enabled = true;
                        grdData.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        txtRoomFrom.Enabled = true;
                        txtRoomTo.Visible = false;
                        lblTo.Visible = false;
                        tabMaster.SelectedIndex = 1;
                        break;
                    }
                default:
                    break;
            }
        }
        private Boolean ValidateData()
        {
            if (txtRoomDesc.Text == "")
            {
                MessageBox.Show("Please enter MakeupRoom", "Warning", MessageBoxButtons.OK);
                txtRoomDesc.Focus();
                return false;
            }
            if (txtRoomFrom.Text == "")
            {
                MessageBox.Show("Please enter FROM Room No.", "Warning", MessageBoxButtons.OK);
                txtRoomFrom.Focus();
                return false;
            }
            if (txtRoomTo.Text == "" && _OpMode == "NEW")
            {
                MessageBox.Show("Please enter TO Room No.", "Warning", MessageBoxButtons.OK);
                txtRoomTo.Focus();
                return false;
            }
            if (dbcSet.Text == "")
            {
                MessageBox.Show("Please select Set", "Warning", MessageBoxButtons.OK);
                txtRoomTo.Focus();
                return false;
            }
            return true;
        }

        private void grdData_CellClick(object sender, Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmMakeupRoom_Load(object sender, EventArgs e)
        {
            getMaster();
            //fillGrid();
            setOpMode("VIEW");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
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
                    if (_OpMode == "NEW")
                    {
                        for (int i = Convert.ToInt32(txtRoomFrom.Text); i <= Convert.ToInt32(txtRoomTo.Text); i++)
                        {
                            strSQL = "exec save_MakeupRoomMaster ";
                            strSQL += " @MakeupRoomId = 0";
                            strSQL += ", @MakeupRoomNo =  " + i.ToString();
                            strSQL += ", @MakeupRoomArea = '" + txtRoomDesc.Text + "'";
                            strSQL += ", @SetId = " + dbcSet.SelectedValue.ToString();
                            strSQL += ", @FromDate = '" + System.DateTime.Now.Date.ToString("yyyy-MM-dd") + "'";
                            strSQL += ", @LastDate = null";
                            strSQL += ", @CreatedBy = " + DataContainer.EMP_Code;
                            strSQL += ", @active = 1";
                            SqlHelper.ExecuteNonQuery(clsConnection.conn, CommandType.Text, strSQL);
                        }
                    }
                    else
                    {
                        strSQL = "exec save_MakeupRoomMaster ";
                        strSQL += " @MakeupRoomId = " + txtMakeupRoomId.Text;
                        strSQL += ", @MakeupRoomNo =  " + txtRoomFrom.Text;
                        strSQL += ", @MakeupRoomArea = '" + txtRoomDesc.Text + "'";
                        strSQL += ", @SetId = " + dbcSet.SelectedValue.ToString();
                        strSQL += ", @CreatedBy = " + DataContainer.EMP_Code;
                        if (dbcActive.Text == "NO")
                            strSQL += ", @active = 0";
                        SqlHelper.ExecuteNonQuery(clsConnection.conn, CommandType.Text, strSQL);
                    }

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
            getMaster();
            setOpMode("VIEW");
        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = System.Drawing.Color.DarkRed;
            ((Button)sender).ForeColor = System.Drawing.Color.White;
            ((Button)sender).Text = ((Button)sender).Text.ToUpper();

        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = System.Drawing.SystemColors.Control;
            ((Button)sender).ForeColor = System.Drawing.Color.Black;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void grdData_CellDoubleClick(object sender, Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs e)
        {
            setOpMode("EDIT");
        }

        private void txtRoomFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // validate KeyPress
            int ch = e.KeyChar;
            if (char.IsDigit(e.KeyChar) || (ch == (char)Keys.Back) || (ch == (char)Keys.Delete))
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void txtRoomTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // validate KeyPress
            int ch = e.KeyChar;
            if (char.IsDigit(e.KeyChar) || (ch == (char)Keys.Back) || (ch == (char)Keys.Delete))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dbcMakeupRoomArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fillGrid();
        }
    }
}
