using Syncfusion.Windows.Forms.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phase_1
{
    public partial class frmBookingDailyBill : Form
    {
        int bookingPlanID;
        int billId;
        
        Double DiscTotal, discountOnAmt, totalBill = 0;
        string strSQL;
        DateTime dtBillDate;
        DataSet dsParameters = new DataSet();
        private bool _canGiveDiscounts;
        public bool canGiveDiscounts { get { return _canGiveDiscounts; } set { _canGiveDiscounts = value; } }
        public int setBookingPlanId { get { return bookingPlanID; } set { bookingPlanID = value; } }
        private Int16 _isUpdated = 0;
        private int G_MARGIN_HOURS;

        public DateTime BillDate
        {
            get { return dtBillDate; }
            set
            {
                dtBillDate = value;
                DataSet tmpDs = new DataSet();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@ScheduleDate", SqlDbType.Date);
                p[0].Value = value;
                p[1] = new SqlParameter("@BookingPlanID", SqlDbType.Int);
                p[1].Value = bookingPlanID;
                tmpDs = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.StoredProcedure, "get_BillForDate ", p);
                billId = Convert.ToInt32(tmpDs.Tables[0].Rows[0]["BillId"].ToString());
            }
        }

        public frmBookingDailyBill()
        {
            InitializeComponent();
        }
        #region GetCombos
        private void getMaster()
        {
            try
            {

                DataTable dtMaster = new DataTable();
                dtMaster = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_SetMaster").Tables[0];
                dbcSet.DisplayMember = "SetName";
                dbcSet.ValueMember = "SetId";
                dbcSet.DataSource = dtMaster;
                dbcSet.Refresh();

                DataTable dtMasterShoot = new DataTable();
                dtMasterShoot = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_CategoryMaster").Tables[0];
                dbcShootType.DisplayMember = "CategoryName";
                dbcShootType.ValueMember = "CategoryId";
                dbcShootType.DataSource = dtMasterShoot;

                DataTable dtMasterCustomer = new DataTable();
                dtMasterCustomer = SqlHelper.ExecuteDataset(clsConnection.connStr, CommandType.Text, "get_CustomerName").Tables[0];
                dbcCustomer.DisplayMember = "CustomerName";
                dbcCustomer.ValueMember = "CustomerId";
                dbcCustomer.DataSource = dtMasterCustomer;

                strSQL = "SELECT * FROM GLOBAL_LIST_VALUES WHERE list_text = 'Extended Hours' and list_type = 'COMP_PARA'";
                DataSet dsTemp = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0) G_MARGIN_HOURS = Convert.ToInt16(dsTemp.Tables[0].Rows[0]["list_value"]);
                else G_MARGIN_HOURS = 1;
                
                dsParameters = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "get_CompanyParameters");

                grdSchedule.IgnoreReadOnly = true;
                grdSchedule.DefaultRowHeight = 28;

                grdSchedule.Model[0, 2].Text = "BillDetailId";
                grdSchedule.Model[0, 1].Text = "BillID";
                grdSchedule.Model[0, 3].Text = "ChargesId";
                grdSchedule.Model[0, 4].Text = "ChargesName";
                grdSchedule.Model[0, 5].Text = "From";
                grdSchedule.Model[0, 6].Text = "To";
                grdSchedule.Model[0, 7].Text = "Qty";
                grdSchedule.Model[0, 8].Text = "Free";
                grdSchedule.Model[0, 9].Text = "Charged";
                grdSchedule.Model[0, 11].Text = "UoM";
                grdSchedule.Model[0, 12].Text = "Rate";
                grdSchedule.Model[0, 13].Text = "CalculatedAmount";
                grdSchedule.Model[0, 14].Text = "Discount";
                grdSchedule.Model[0, 15].Text = "Amount";
                grdSchedule.Model[0, 16].Text = "Narration";
                grdSchedule.Model[0, 17].Text = "miscFlag";
                grdSchedule.CoveredRanges.Add(
    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 18, 0, 19));
                grdSchedule.Model[0, 18].Text = "Action";
                grdSchedule[0, 18].HorizontalAlignment = GridHorizontalAlignment.Center;
                grdSchedule.IgnoreReadOnly = false;
                grdSchedule.SetColHidden(1, 3, true);
                //grdSchedule.SetColHidden(8, 9, true);
                // grdSchedule.SetColHidden(17, 17, true);
                grdSchedule.SetColWidth(16, 16, grdSchedule.DefaultColWidth + 1500);
                // this.grdSchedule.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cols(4, 12));

                //4 Charges Name
                this.grdSchedule.ColWidths.SetSize(4, 100);
                // 5, 6 UNITS
                this.grdSchedule.ColWidths.SetSize(5, 50);
                this.grdSchedule.ColWidths.SetSize(6, 50);
                // 7 8 9 QTY
                this.grdSchedule.ColWidths.SetSize(7, 50);
                this.grdSchedule.ColWidths.SetSize(8, 50);
                this.grdSchedule.ColWidths.SetSize(9, 50);
                // 11 UOM
                this.grdSchedule.ColWidths.SetSize(11, 50);
                // 12 Rate
                this.grdSchedule.ColWidths.SetSize(12, 65);
                // 13 amount
                this.grdSchedule.ColWidths.SetSize(15, 80);
                // this.grdSchedule.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 1, grdSchedule.RowCount, 12), GridResizeToFitOptions.IncludeHeaders);
                this.grdSchedule.ColWidths.SetSize(16, 120);
                grdSchedule.IgnoreReadOnly = false;

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }
        private void populateData()
        {
            try
            {
                if (_canGiveDiscounts)
                {
                    txtDiscPercent.Enabled = true;
                    txtDiscInAmount.Enabled = true;
                }
                else
                {
                    txtDiscPercent.Enabled = false;
                    txtDiscInAmount.Enabled = false;
                }
                DataSet ds = new DataSet();
                DataSet dsDetails = new DataSet();
                if (billId != 0)
                {
                    ds = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "get_BillById " + billId.ToString());
                }
                else
                {
                    ds = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "get_BookingPlanById " + bookingPlanID.ToString());
                }
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dbcSet.SelectedValue = ds.Tables[0].Rows[0]["SetId"];
                    dbcShootType.SelectedValue = ds.Tables[0].Rows[0]["Categoryid"];

                    // FILL DETAILS
                    strSQL = "get_DailyBillCharges ";
                    strSQL += "@setID = " + dbcSet.SelectedValue.ToString();
                    strSQL += ", @CategoryID = " + dbcShootType.SelectedValue.ToString();
                    strSQL += ", @BookingPlanId = " + bookingPlanID.ToString();
                    strSQL += ", @scheduleDate = '" + dtpBillDate.Value.Date.ToString("yyyy-MM-dd") + "'";
                    strSQL += ", @BillId = " + billId.ToString();
                    dsDetails = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                    if (dsDetails.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (dsDetails.Tables[0].Rows[0]["BillDetailId"].ToString() == "-1")
                        {
                            cmdPrint.Enabled = false;
                            cmdCancel.Enabled = false;
                        }
                        else
                        {
                            cmdPrint.Enabled = true;
                            cmdCancel.Enabled = true;
                        }
                        if (grdSchedule.Model.RowCount >= 1)
                            grdSchedule.Rows.RemoveRange(1, grdSchedule.Model.RowCount);

                        grdSchedule.Rows.InsertRange(1, dsDetails.Tables[0].Rows.Count);

                        grdSchedule.IgnoreReadOnly = true;
                        for (int i = 0; i < dsDetails.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = dsDetails.Tables[0].Rows[i];
                            grdSchedule.Model[i + 1, 2].Text = dr["BillDetailId"].ToString();
                            grdSchedule.Model[i + 1, 1].Text = billId.ToString();
                            grdSchedule.Model[i + 1, 3].Text = dr["ChargesId"].ToString();
                            grdSchedule.Model[i + 1, 4].Text = dr["ChargesName"].ToString();
                            if (grdSchedule.Model[i + 1, 2].Text != "-1")
                            {
                                grdSchedule.Model[i + 1, 5].Text = dr["FromUnit"].ToString();
                                grdSchedule.Model[i + 1, 6].Text = dr["ToUnit"].ToString();
                                grdSchedule.Model[i + 1, 7].Text = dr["Qty"].ToString();
                                grdSchedule.Model[i + 1, 8].Text = dr["FreeQty"].ToString();
                                grdSchedule.Model[i + 1, 9].Text = dr["ChargedQty"].ToString();
                                grdSchedule.Model[i + 1, 13].Text = dr["CalculatedAmount"].ToString();
                                grdSchedule.Model[i + 1, 14].Text = dr["Discount"].ToString();
                                grdSchedule.Model[i + 1, 15].Text = dr["Amount"].ToString();
                            }
                            grdSchedule.Model[i + 1, 11].Text = dr["UoM"].ToString();
                            grdSchedule.Model[i + 1, 12].Text = dr["Rate"].ToString();
                            grdSchedule.Model[i + 1, 16].Text = dr["Narration"].ToString();
                            grdSchedule.Model[i + 1, 17].Text = dr["miscFlag"].ToString();
                            grdSchedule[i + 1, 5].HorizontalAlignment = GridHorizontalAlignment.Right;
                            grdSchedule[i + 1, 6].HorizontalAlignment = GridHorizontalAlignment.Right;
                            grdSchedule[i + 1, 7].HorizontalAlignment = GridHorizontalAlignment.Right;
                            grdSchedule[i + 1, 8].HorizontalAlignment = GridHorizontalAlignment.Right;
                            grdSchedule[i + 1, 9].HorizontalAlignment = GridHorizontalAlignment.Right;
                            grdSchedule[i + 1, 11].HorizontalAlignment = GridHorizontalAlignment.Right;
                            grdSchedule[i + 1, 12].HorizontalAlignment = GridHorizontalAlignment.Right;
                            grdSchedule[i + 1, 13].BackColor = Color.GreenYellow;
                            grdSchedule[i + 1, 15].BackColor = Color.GreenYellow;
                            grdSchedule[i + 1, 13].HorizontalAlignment = GridHorizontalAlignment.Right;
                            grdSchedule[i + 1, 14].HorizontalAlignment = GridHorizontalAlignment.Right;
                            grdSchedule[i + 1, 15].HorizontalAlignment = GridHorizontalAlignment.Right;

                            grdSchedule.Model[i + 1, 18].CellType = Syncfusion.Windows.Forms.Grid.GridCellTypeName.PushButton;
                            grdSchedule.Model[i + 1, 18].HorizontalAlignment = GridHorizontalAlignment.Center;
                            grdSchedule.Model[i + 1, 18].VerticalAlignment = GridVerticalAlignment.Middle;
                            grdSchedule[i + 1, 18].Description = "EDIT";
                            grdSchedule[i + 1, 18].TextColor = Color.BlueViolet;
                            grdSchedule.Model[i + 1, 19].CellType = Syncfusion.Windows.Forms.Grid.GridCellTypeName.PushButton;
                            grdSchedule.Model[i + 1, 19].HorizontalAlignment = GridHorizontalAlignment.Center;
                            grdSchedule.Model[i + 1, 19].VerticalAlignment = GridVerticalAlignment.Middle;
                            grdSchedule[i + 1, 19].Description = "DELETE";
                            grdSchedule[i + 1, 19].TextColor = Color.DarkSlateGray;

                            for (int j = 3; j <= 16; j++)
                            {
                                grdSchedule[i + 1, j].VerticalAlignment = GridVerticalAlignment.Middle;
                            }
                        }
                        ////4 Charges Name
                        //this.grdSchedule.ColWidths.SetSize(4, 100);
                        //// 5, 6 UNITS
                        //this.grdSchedule.ColWidths.SetSize(5, 60);
                        //this.grdSchedule.ColWidths.SetSize(6, 60);
                        //// 7 8 9 QTY
                        //this.grdSchedule.ColWidths.SetSize(7, 40);
                        //this.grdSchedule.ColWidths.SetSize(8, 40);
                        //this.grdSchedule.ColWidths.SetSize(9, 40);
                        //// 11 UOM
                        //this.grdSchedule.ColWidths.SetSize(11, 70);
                        //// 12 Rate
                        //this.grdSchedule.ColWidths.SetSize(12, 100);
                        //// 13 amount
                        //this.grdSchedule.ColWidths.SetSize(15, 100);
                        //// this.grdSchedule.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 1, grdSchedule.RowCount, 12), GridResizeToFitOptions.IncludeHeaders);
                        //this.grdSchedule.ColWidths.SetSize(16, 120);
                        grdSchedule.SetColHidden(10, 10, true); // BLANK 
                        grdSchedule.SetColHidden(14, 14, true); // Discount 
                        grdSchedule.SetColHidden(13, 13, true); // CalculatedAmount
                        grdSchedule.SetColHidden(17, 17, true); // MISC FLAG
                        //grdSchedule.SetColHidden(19, 19, true); // MISC FLAG
                        grdSchedule.IgnoreReadOnly = false;
                    }

                    discountOnAmt = Convert.ToDouble(ds.Tables[0].Rows[0]["DiscountOn"].ToString());
                    dbcCustomer.SelectedValue = ds.Tables[0].Rows[0]["CustomerId"];
                    txtContactPerson.Text = ds.Tables[0].Rows[0]["EnquiryContactPerson"].ToString();
                    txtContactDesg.Text = ds.Tables[0].Rows[0]["EnquiryContactDesg"].ToString();
                    txtContactNo.Text = ds.Tables[0].Rows[0]["EnquiryContactPhone"].ToString();
                    dbcFromTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["ShiftTime"]).Substring(0, 5);
                    dbcSet.SelectedValue = ds.Tables[0].Rows[0]["SetId"];
                    dbcShootType.SelectedValue = ds.Tables[0].Rows[0]["Categoryid"];
                    dtpFromDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["BookingFromDate"].ToString());
                    dtpToDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["BookingToDate"].ToString());
                    txtDays.Text = ((dtpToDate.Value.Date - dtpFromDate.Value.Date).Days + 1).ToString();
                    txtRefNo.Text = ds.Tables[0].Rows[0]["RefNo"].ToString();
                    dtpBookingDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["BookingDate"].ToString());
                    txtPlanAmount.Text = String.Format("{0:n2}", ds.Tables[0].Rows[0]["BillAmount"]);
                    txtDiscPercent.Text = ds.Tables[0].Rows[0]["DiscountPercent"].ToString();
                    txtDiscAmount.Text = String.Format("{0:n2}", ds.Tables[0].Rows[0]["Discount"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Discount"]) != "")
                        lblAmtForDisc.Text = "Discount (%) of " + string.Format("{0:n2}", ds.Tables[0].Rows[0]["DiscountOn"]);
                    txtDiscInAmount.Text = String.Format("{0:n2}", ds.Tables[0].Rows[0]["DiscountInAmount"]);
                    if (ds.Tables[0].Rows[0]["DiscountOn"].ToString() != "")
                        discountOnAmt = Convert.ToDouble(ds.Tables[0].Rows[0]["DiscountOn"].ToString());
                    else
                        discountOnAmt = 0;

                    txtSubTotal.Text = string.Format("{0:n2}", ds.Tables[0].Rows[0]["subTotal"]);
                    txtTaxPercent.Text = ds.Tables[0].Rows[0]["TaxPercent"].ToString();
                    txtTax.Text = String.Format("{0:n2}", ds.Tables[0].Rows[0]["Tax"]);
                    txtNett.Text = String.Format("{0:n2}", ds.Tables[0].Rows[0]["TotalAmount"]);
                    // txtComments.Text = ds.Tables[0].Rows[0]["Narration"].ToString();
                    txtBillNo.Text = ds.Tables[0].Rows[0]["BillID"].ToString();
                    txtBillId.Text = Convert.ToString(ds.Tables[0].Rows[0]["BillNo"]);
                    txtInvNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["InvoiceNo"]);
                    dtpBilledOnDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["BillDate"].ToString());
                    //txtAdvanceAmount.Text = string.Format("{0:n2}", ds.Tables[0].Rows[0]["BookingPaidAmount"]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());

            }
        }
        #endregion

        private void frmBookingDailyBill_Load(object sender, EventArgs e)
        {
            try
            {
                getMaster();


                // PASSED FROM GRID
                bookingPlanID = this.setBookingPlanId;
                dtpBillDate.Value = this.BillDate;
                if (bookingPlanID != 0)
                {
                    // GET EXISTING DATA
                    populateData();
                    MakCalc_Daily();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());

            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdSchedule_PushButtonClick(object sender, GridCellPushButtonClickEventArgs e)
        {
            try
            {
                //GridStyleInfo entryStyle = new GridStyleInfo();
                //entryStyle.Font.Bold = true;
                //entryStyle.BackColor = Color.PaleGreen;


                //GridRangeStyle g = new GridRangeStyle();
                //g.StyleInfo = entryStyle;

                //GridStyleInfo defaultStyle = new GridStyleInfo();
                //entryStyle.Font.Bold = false;
                //entryStyle.BackColor = System.Drawing.SystemColors.Window; 
                clearEntry();
                int rw = e.RowIndex;
                int cl = e.ColIndex;
                grdSchedule.IgnoreReadOnly = true;
                grdSchedule[rw, cl].BackColor = Color.Yellow;
                grdSchedule.IgnoreReadOnly = false;
                grdSchedule.Selections.Clear();
                grdSchedule.Selections.SelectRange(GridRangeInfo.Rows(rw, rw), true);

                txtRwNo.Text = rw.ToString();
                txtCharges.Text = grdSchedule.Model[rw, 4].Text;
                // check paramter name
                if (dsParameters.Tables.Count > 0 && dsParameters.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsParameters.Tables[0].Rows)
                    {
                        if (dr["List_text"].ToString().ToUpper().Contains(txtCharges.Text.ToUpper())
                            && dr["List_text"].ToString().ToUpper().Contains(dbcShootType.Text.ToUpper()))
                        {
                            txtFreeQty.Text = dr["List_value"].ToString();
                            break;
                        }
                        else
                            txtFreeQty.Text = string.Empty;
                    }
                }
                txtFromUnitM.Text = string.Empty;
                txtToUnitM.Text = string.Empty;
                lblUoM.Text = grdSchedule.Model[rw, 11].Text;
                txtRate.Text = grdSchedule.Model[rw, 12].Text;
                txtQty.Enabled = true;
                if (lblUoM.Text == "UNIT")
                {
                    lblQty.Text = "UNIT";
                    //txtFromUnitM.Mask = "99999999";
                    //txtToUnitM.Mask = "99999999";

                    // changed for 29.09.2020
                    txtUnitFrom.Visible = false;//true;
                    txtUnitTo.Visible = false; //  true;

                    txtUnitFrom.Top = txtFromUnitM.Top;
                    txtUnitFrom.Left = txtFromUnitM.Left;
                    txtUnitTo.Top = txtToUnitM.Top;
                    txtUnitTo.Left = txtToUnitM.Left;

                    txtFromUnitM.Visible = false;
                    txtToUnitM.Visible = false;
                    txtAmount.Enabled = false;
                    // Changed for 29.09.2020
                    txtQty.Enabled = true; // false;

                    txtUnitFrom.Text = grdSchedule.Model[rw, 5].Text;
                    txtUnitTo.Text = grdSchedule.Model[rw, 6].Text;

                    //txtFromUnitM.ValidatingType = typeof(System.Int32);
                    //txtToUnitM.ValidatingType = typeof(System.Int32);
                    //txtToUnitM.TextAlign = HorizontalAlignment.Right;
                }
                if (lblUoM.Text == "SHIFT")
                {
                    lblQty.Text = "HOURS";
                    txtUnitFrom.Visible = false;
                    txtUnitTo.Visible = false;

                    txtFromUnitM.Visible = true;
                    txtToUnitM.Visible = true;
                    txtQty.Enabled = false ;
                    txtFromUnitM.Mask = "00:00";
                    txtToUnitM.Mask = "00:00";
                    txtAmount.Enabled = false;
                    txtFromUnitM.ValidatingType = typeof(System.DateTime);
                    txtToUnitM.ValidatingType = typeof(System.DateTime);
                }
                if (!(lblUoM.Text == "SHIFT" || lblUoM.Text == "UNIT"))
                {
                    lblQty.Text = "Qty";
                    txtUnitFrom.Visible = false;
                    txtUnitTo.Visible = false;

                    txtUnitFrom.Top = txtFromUnitM.Top;
                    txtUnitFrom.Left = txtFromUnitM.Left;
                    txtUnitTo.Top = txtToUnitM.Top;
                    txtUnitTo.Left = txtToUnitM.Left;

                    txtAmount.Enabled = false;
                    txtFromUnitM.Visible = false;
                    txtToUnitM.Visible = false;

                    txtFromUnitM.ValidatingType = typeof(System.Decimal);
                    txtToUnitM.ValidatingType = typeof(System.Decimal);
                }
                if (lblUoM.Text == "OTHER")
                {
                    txtAmount.Enabled = true;
                }
                if (Convert.ToDouble(txtRate.Text) == 0)
                    txtRate.Enabled = true;
                else
                    txtRate.Enabled = false;

                txtFromUnitM.Text = grdSchedule.Model[rw, 5].Text;
                txtToUnitM.Text = grdSchedule.Model[rw, 6].Text;
                txtQty.Text = grdSchedule.Model[rw, 7].Text;
                //txtch
                txtAmount.Text = grdSchedule.Model[rw, 15].Text;
                txtNarration.Text = grdSchedule.Model[rw, 16].Text;
                if (grdSchedule[rw, cl].Description == "DELETE")
                {
                    if (grdSchedule.Model[rw, 7].Text != "")
                    {
                        DialogResult mAns = MessageBox.Show("Are you sure wou want to delete this entry?", "Confirm", MessageBoxButtons.YesNo);
                        if (mAns == DialogResult.Yes)
                        {
                            clearEntry();
                            grdSchedule.IgnoreReadOnly = true;
                            grdSchedule.Model[rw, 6].Text = string.Empty;
                            grdSchedule.Model[rw, 7].Text = string.Empty;
                            grdSchedule.Model[rw, 15].Text = string.Empty;
                            grdSchedule.Model[rw, 16].Text = string.Empty;
                            grdSchedule.Model[rw, 2].Text = "-1";
                            grdSchedule.Model[rw, 17].Text = "-1";
                            grdSchedule.IgnoreReadOnly = false;
                            MakCalc_Daily();
                            _isUpdated = -1;
                        }
                    }
                }
                if (txtFromUnitM.Visible) { this.txtFromUnitM.Focus(); if (!txtFromUnitM.Focused) this.txtFromUnitM.Focus(); }
                else
                {
                    if (txtUnitFrom.Visible) { this.txtUnitFrom.Focus(); ; if (!this.txtUnitFrom.Focused) this.txtUnitFrom.Focus(); }
                    else txtQty.Focus();
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
                if (txtAmount.Text.Trim() == "")
                {
                    MessageBox.Show("Entry is not complete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtCharges.Text.Trim() == "")
                {
                    MessageBox.Show("Entry is not complete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtQty.Text.Trim() == "")
                {
                    MessageBox.Show("Entry is not complete. Qty is not entered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void cmdApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCharges.Text.ToString() == "")
                    return;
                if (!isValidApply())
                    return;
                int rw = Convert.ToUInt16(txtRwNo.Text);
                grdSchedule.IgnoreReadOnly = true;
                if (txtFromUnitM.Visible)
                    grdSchedule.Model[rw, 5].Text = txtFromUnitM.Text.Trim();
                if (txtUnitFrom.Visible)
                    grdSchedule.Model[rw, 5].Text = txtUnitFrom.Text.Trim();
                if (txtToUnitM.Visible)
                    grdSchedule.Model[rw, 6].Text = txtToUnitM.Text.Trim();
                if (txtUnitTo.Visible)
                    grdSchedule.Model[rw, 6].Text = txtUnitTo.Text.Trim();
                if (txtRate.Enabled)
                    grdSchedule[rw, 12].Text = txtRate.Text.Trim();
                grdSchedule.Model[rw, 7].Text = txtQty.Text;
                grdSchedule.Model[rw, 8].Text = txtFreeQty.Text;
                if (txtFreeQty.Text.ToString() != "")
                    grdSchedule.Model[rw, 9].Text = txtChargedQty.Text;
                else
                    grdSchedule.Model[rw, 9].Text = txtQty.Text;

                grdSchedule.Model[rw, 13].Text = txtAmount.Text; // Calcuclated Amount
                grdSchedule.Model[rw, 15].Text = txtAmount.Text;
                grdSchedule.Model[rw, 16].Text = txtNarration.Text;
                grdSchedule.Model[rw, 17].Text = "1";
                grdSchedule.IgnoreReadOnly = false;
                MakCalc_Daily();
                clearEntry();
                _isUpdated = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        #region Calculations
        private void clearEntry()
        {
            try
            {
                lblQty.Text = "Qty";
                lblUoM.Text = "";
                txtCharges.Text = "";
                txtFromUnitM.Text = "";
                txtToUnitM.Text = "";
                txtQty.Text = "";
                txtRate.Text = "0.00";
                txtAmount.Text = "0.00";
                txtNarration.Text = "";
                txtChargedQty.Text = "";
                txtUnitFrom.Text = "";
                txtUnitTo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MakCalc_Daily()
        {
            try
            {
                double tot = 0;
                double t;
                discountOnAmt = 0;
                for (int i = 1; i <= grdSchedule.RowCount; i++)
                {
                    if (grdSchedule.Model[i, 15].Text != "")
                    {
                        // 2020-10-26 To INCLUDE ALL the Heads for Discount
                        if (Convert.ToInt32( grdSchedule.Model[i, 3].Text.ToString()) <= 3)
                            discountOnAmt += Convert.ToDouble(grdSchedule.Model[i, 12].Text);

                        tot += Convert.ToDouble(grdSchedule.Model[i, 15].Text);
                    }
                }
                tot = Math.Round(tot, 0);
                lblAmtForDisc.Text = "Discount (%) of " + String.Format("{0:n2}", discountOnAmt);
                txtDailyTotal.Text = String.Format("{0:n2}", tot);
                txtPlanAmount.Text = String.Format("{0:n2}", tot);
                if ((Convert.ToDouble(txtDiscInAmount.Text) != 0))
                {
                    DiscTotal = Convert.ToDouble(txtDiscInAmount.Text);
                }
                else DiscTotal = 0;
         

                if (Convert.ToDouble(txtDiscPercent.Text) != 0)
                {
                    t = Convert.ToDouble(txtDiscPercent.Text);
                    DiscTotal += Math.Round((discountOnAmt * t / 100.0), 0);
                }
                else DiscTotal += 0;
                txtDiscAmount.Text = string.Format("{0:n2}", DiscTotal);
                totalBill = tot - DiscTotal;
                txtSubTotal.Text = string.Format("{0:n2}", totalBill);
                totalBill = Math.Round(totalBill * 0.18, 0);
                txtTax.Text = String.Format("{0:n2}", totalBill);
                totalBill = tot - DiscTotal + totalBill;
                txtNett.Text = string.Format("{0:n2}", totalBill);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
                throw;
            }
        }
        private void MakCalc_Units()
        {
            try
            {
                // if (txtFromUnit.Text != "" && txtToUnit.Text != "")
                if (txtUnitFrom.Text == string.Empty || txtUnitTo.Text == string.Empty || txtUnitTo.Text == "" || txtUnitFrom.Text == "")
                {
                    return;
                }
                else
                //if (txtFromUnitM.MaskCompleted && txtToUnitM.MaskCompleted && txtFromUnitM.ValidatingType == txtToUnitM.ValidatingType)
                {
                    int f = Convert.ToInt32(txtUnitFrom.Text);
                    int t = Convert.ToInt32(txtUnitTo.Text);
                    int fr;
                    if (txtFreeQty.Text != "")
                        fr = Convert.ToInt32(txtFreeQty.Text);
                    else
                        fr = 0;
                    int q = (t - f) - fr;
                    if (q < 0)
                        q = 0;
                    Double calcAmt = q * Convert.ToDouble(txtRate.Text);

                    txtQty.Text = (q + fr).ToString();
                    txtChargedQty.Text = string.Format("{0}", q);

                    calcAmt = Math.Round(calcAmt, 0);
                    txtAmount.Text = string.Format("{0:n2}", calcAmt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        private void MakCalc_Hours()
        {
            try
            {
                //if ((txtFromUnitM.Text.Trim().Length >= 5) && txtFromUnit.Text.Contains(':')
                //    &&
                //        (txtToUnit.Text.Trim().Length >= 5) && txtToUnit.Text.Contains(':'))
                if (txtFromUnitM.Text == string.Empty || txtToUnitM.Text == string.Empty)
                {
                    return;
                }
                if (txtFromUnitM.MaskCompleted && txtToUnitM.MaskCompleted && txtFromUnitM.ValidatingType == txtToUnitM.ValidatingType)
                {
                    DateTime f = Convert.ToDateTime(txtFromUnitM.Text);
                    DateTime t = Convert.ToDateTime(txtToUnitM.Text);
                    // IF overNight work allow ToTime Less than FromTime
                    if (t < f)
                    { 
                        DialogResult mAns= MessageBox.Show("ToTime Prior than FromTime.\nIs this overnight working?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (mAns == DialogResult.No)
                            return;
                        t = t.AddHours(24);
                    }
                    double q = (t.Subtract(f).TotalMinutes) / 60.0;
                    // Shift charges min 12
                    if (grdSchedule[Convert.ToInt16( txtRwNo.Text), 3].Text == "1" && q  < 12)
                        q = 12;
                    // IF more han 12 hours calculate additional hours with margin of hours
                    Double calcAmt;
                    if (q > 19)
                    {
                        calcAmt = Convert.ToDouble(txtRate.Text) * 2;
                    }
                    else
                    {
                        if (q > 12)
                        {
                            calcAmt = (q - G_MARGIN_HOURS) * (Convert.ToDouble(txtRate.Text) / 12);
                        }
                        else
                        {
                            calcAmt = q * (Convert.ToDouble(txtRate.Text) / 12);
                        }
                    }
                    txtQty.Text = q.ToString();
                    txtChargedQty.Text = q.ToString();
                    calcAmt = Math.Round(calcAmt, 0);
                    txtAmount.Text = string.Format("{0:n2}", calcAmt);
                    double tot = 0;
                    for (int i = 1; i <= grdSchedule.RowCount; i++)
                    {
                        if (grdSchedule[i, 2].Text != "-1")
                            tot += Convert.ToDouble(grdSchedule.Model[i, 15].Text);
                    }
                    txtDailyTotal.Text = String.Format("{0:n2}", tot);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        private void MakCalc_Qty()
        {
            try
            {
                if (txtQty.Text.Trim() == "")
                    return;
                double q = Convert.ToDouble(txtQty.Text.Trim());
                int fr;
                fr = 0;
                if (txtFreeQty.Text != "")
                    fr = Convert.ToInt32(txtFreeQty.Text);

                Double calcAmt;
                if (fr != 0)
                {
                    calcAmt = (q - fr) * (Convert.ToDouble(txtRate.Text));
                    if (calcAmt < 0)
                        calcAmt = 0;
                }
                else
                    calcAmt = q * (Convert.ToDouble(txtRate.Text));

                calcAmt = Math.Round(calcAmt, 0);
                if (q - fr < 0)
                    txtChargedQty.Text = string.Format("{0}", 0);
                else
                    txtChargedQty.Text = string.Format("{0}", (q - fr));

                txtAmount.Text = string.Format("{0:n2}", calcAmt);
                double tot = 0;
                for (int i = 1; i <= grdSchedule.RowCount; i++)
                {
                    if (grdSchedule.Model[i, 15].Text != "")
                        tot += Convert.ToDouble(grdSchedule.Model[i, 15].Text);
                }
                txtDailyTotal.Text = String.Format("{0:n2}", tot);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        private void txtFromUnit_TextChanged(object sender, EventArgs e)
        {
            if (lblUoM.Text == "UNIT")
            {
                //if (txtToUnitM.MaskCompleted)
                {
                    MakCalc_Units();
                }
            }
            if (lblUoM.Text == "SHIFT")
            {
                if (txtToUnitM.MaskCompleted)
                {
                    MakCalc_Hours();
                }
            }
        }

        private void txtToUnit_TextChanged(object sender, EventArgs e)
        {
            if (lblUoM.Text == "UNIT")
            {
                //if (txtFromUnitM.MaskCompleted)
                {
                    MakCalc_Units();
                }
            }
            if (lblUoM.Text == "SHIFT")
            {
                if (txtFromUnitM.MaskCompleted)
                {
                    MakCalc_Hours();
                }
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void txtDailyTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click_1(object sender, EventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {//chnaged for 29.09.2020
            //if (!(lblUoM.Text == "SHIFT" || lblUoM.Text == "UNIT"))
            if (!(lblUoM.Text == "SHIFT"))
            {
                if (txtQty.Text.Trim() != "")
                {
                    MakCalc_Qty();
                }
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch = e.KeyChar;
            if (char.IsDigit(e.KeyChar) || (ch == (char)Keys.Back) || (ch == (char)Keys.Delete))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtDiscPercent_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscPercent.Text.Trim() != "")
            {
                if (txtDiscPercent.Focused) // calculate only when entry
                {
                    MakCalc_Daily();
                    _isUpdated = -1;
                }
            }
        }

        private void frmBookingDailyBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult isConf;
            if (_isUpdated < 0)
                isConf = MessageBox.Show("Changes done are not Saved.\nDo you want to Close anyway?", "Data not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            else
                isConf = DialogResult.Yes;

            if (isConf == DialogResult.Yes)
            {
                clsGeneric oGen = new clsGeneric();
                DialogResult mAns = oGen.isCloseForm(sender, e);
                if (mAns == DialogResult.Yes)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
            else e.Cancel = true;
        }

        private void txtToUnitM_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (txtToUnitM.ValidatingType.Name.ToUpper() == "DATETIME")
            {
                MakCalc_Hours();
            }
            if (txtToUnitM.ValidatingType.Name.ToUpper() == "INT32")
            {
                MakCalc_Units();
            }
        }

        private void lblUoM_Click(object sender, EventArgs e)
        {

        }

        private void grdSchedule_CellClick(object sender, GridCellClickEventArgs e)
        {

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

        private void txtUnitFrom_Leave(object sender, EventArgs e)
        {
            txtFromUnitM.Text = txtUnitFrom.Text;
        }

        private void txtUnitTo_Leave(object sender, EventArgs e)
        {
            txtToUnitM.Text = txtUnitTo.Text;
        }

        private void txtUnitTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFreeQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void txtToUnitM_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void grdSchedule_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.F2)
                MessageBox.Show("f2 pressed");
        }

        private void grdSchedule_CurrentCellKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.F2)
                MessageBox.Show("f2 pressed");
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Enter))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    MakCalc_Qty();
                }
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            if (txtRate.Enabled)
            {
                MakCalc_Qty();
            }
        }

        private void lblQty_Click(object sender, EventArgs e)
        {

        }

        private void txtBillId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpBilledOnDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvNo.Text.ToString() != "")
                {
                    MessageBox.Show("Invoice is already generated. Cannot delete the bill", "Not Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult mAns = MessageBox.Show("The bill details cannot be recovered.\nAre you sure to delete the Bill?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mAns == DialogResult.Yes)
                {
                    strSQL = "cancel_DailyBill ";
                    strSQL += " @BillId = " + billId.ToString();
                    DataSet dsTemp = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, strSQL);
                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                    {
                        if (dsTemp.Tables[0].Rows[0]["Message"].ToString() == "SUCCESS")
                        {
                            MessageBox.Show("Bill Cancelled Successfully", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            {
                                // GET EXISTING DATA
                                populateData();
                                MakCalc_Daily();
                            }
                        }
                        else
                        {
                            if (dsTemp.Tables[0].Rows[0]["Message"].ToString() == "INVOICE")
                            {
                                MessageBox.Show("Invoice is already generated. Cannot delete the bill", "Not Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        #endregion

        #region  SAVE 
        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                String strBillNo;
                if (!validateSave())
                    return;
                if (txtBillId.Text == "0" || txtBillId.Text == "")
                {
                    DialogResult mAns = MessageBox.Show("Bill Date will be " + dtpBillDate.Value.Date.ToString("dd-MMM-yyyy") + "\nClick Yes to continue.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (mAns == DialogResult.No)
                    {
                        return;
                    }
                }
                SqlParameter[] pMain = new SqlParameter[17];
                pMain[0] = new SqlParameter("@BillID", SqlDbType.Int);
                pMain[0].Value = billId;

                pMain[1] = new SqlParameter("@BillType", SqlDbType.NVarChar);
                pMain[1].Value = "BILL";
                pMain[2] = new SqlParameter("@ScheduleDate", SqlDbType.DateTime);
                pMain[2].Value = dtBillDate;

                pMain[3] = new SqlParameter("@CategoryId", SqlDbType.Int);
                pMain[3].Value = Convert.ToUInt16(dbcShootType.SelectedValue.ToString());

                pMain[4] = new SqlParameter("@BookingPlanId", SqlDbType.Int);
                pMain[4].Value = bookingPlanID;

                pMain[5] = new SqlParameter("@BillAmount", SqlDbType.Float);
                pMain[5].Value = Convert.ToDouble(txtPlanAmount.Text);
                pMain[6] = new SqlParameter("@DiscountPercent", SqlDbType.Float);
                pMain[6].Value = Convert.ToDouble(txtDiscPercent.Text);
                pMain[7] = new SqlParameter("@DiscountOn", SqlDbType.Float);
                pMain[7].Value = discountOnAmt;

                pMain[8] = new SqlParameter("@Discount", SqlDbType.Float);
                pMain[8].Value = Convert.ToDouble(txtDiscAmount.Text);

                pMain[9] = new SqlParameter("@TaxPercent", SqlDbType.Float);
                pMain[9].Value = Convert.ToDouble(txtTaxPercent.Text);

                pMain[10] = new SqlParameter("@Tax", SqlDbType.Float);
                pMain[10].Value = Convert.ToDouble(txtTax.Text);

                pMain[11] = new SqlParameter("@TotalAmount", SqlDbType.Float);
                pMain[11].Value = Convert.ToDouble(txtNett.Text);

                pMain[12] = new SqlParameter("@Narration", SqlDbType.NVarChar, 100);
                //if (txtComments.Text != "")
                //    pMain[12].Value = txtComments.Text;
                //else
                pMain[12].Value = DBNull.Value;

                pMain[13] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pMain[13].Value = DataContainer.EMP_Code;

                pMain[14] = new SqlParameter("@BillNo", SqlDbType.NVarChar);
                if ((txtBillId.Text.ToString() == "" || txtBillId.Text.ToString() == "0"))
                    pMain[14].Value = DBNull.Value;
                else
                    pMain[14].Value = txtBillId.Text;

                pMain[15] = new SqlParameter("@BillDate", SqlDbType.DateTime);
                pMain[15].Value = dtpBilledOnDate.Value;

                pMain[16] = new SqlParameter("@DiscountInAmount", SqlDbType.Float);
                pMain[16].Value = Convert.ToDouble( txtDiscInAmount.Text.ToString());

                DataSet dsBillNo = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.StoredProcedure, "save_Bill", pMain);
                if (dsBillNo.Tables.Count > 0 && dsBillNo.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(dsBillNo.Tables[0].Rows[0]["MSG"]) == "SUCCESS")
                    {
                        if (txtBillId.Text == "0" || txtBillId.Text == "")
                        {
                            txtBillId.Text = Convert.ToString(dsBillNo.Tables[0].Rows[0]["BillNo"]);
                            strBillNo = "\nBill No generated is " + txtBillId.Text;
                        }
                        else strBillNo = "";

                        SqlParameter[] p = new SqlParameter[21];
                        p[0] = new SqlParameter("@BillDetailId", SqlDbType.Int);
                        p[1] = new SqlParameter("@BillId", SqlDbType.Int);
                        p[2] = new SqlParameter("@BookingPlanId", SqlDbType.Int);
                        p[3] = new SqlParameter("@SchedulateDate", SqlDbType.Date);
                        p[4] = new SqlParameter("@BillingDate", SqlDbType.DateTime);
                        p[5] = new SqlParameter("@ShiftTime", SqlDbType.Time);
                        p[6] = new SqlParameter("@ChargesId", SqlDbType.Int);
                        p[7] = new SqlParameter("@Rate", SqlDbType.Float);
                        p[8] = new SqlParameter("@FromUnit", SqlDbType.NVarChar);
                        p[9] = new SqlParameter("@ToUnit", SqlDbType.NVarChar);
                        p[10] = new SqlParameter("@Qty", SqlDbType.Decimal);
                        p[11] = new SqlParameter("@FreeQty", SqlDbType.Decimal);
                        p[12] = new SqlParameter("@ChargedQty", SqlDbType.Decimal);
                        p[13] = new SqlParameter("@CalculatedAmount", SqlDbType.Float);
                        p[14] = new SqlParameter("@DiscountPercent", SqlDbType.Float);
                        p[15] = new SqlParameter("@Discount", SqlDbType.Float);
                        p[16] = new SqlParameter("@TaxPercent", SqlDbType.Float);
                        p[17] = new SqlParameter("@Tax", SqlDbType.Float);
                        p[18] = new SqlParameter("@Amount", SqlDbType.Float);
                        p[19] = new SqlParameter("@Narration", SqlDbType.NVarChar);
                        p[20] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                        for (int i = 1; i <= grdSchedule.RowCount; i++)
                        {
                            if (grdSchedule.Model[i, 15].Text != "")
                            {
                                p[0].Value = Convert.ToInt32(grdSchedule.Model[i, 2].Text);
                                p[1].Value = billId;
                                p[2].Value = bookingPlanID;
                                p[3].Value = dtBillDate;
                                p[4].Value = dtpBillDate.Value;
                                p[5].Value = Convert.ToDateTime(dbcFromTime.Text).TimeOfDay;
                                p[6].Value = Convert.ToInt32(grdSchedule.Model[i, 3].Text);
                                p[7].Value = Convert.ToDouble(grdSchedule.Model[i, 12].Text);
                                p[8].Value = grdSchedule.Model[i, 5].Text;
                                p[9].Value = grdSchedule.Model[i, 6].Text;
                                p[10].Value = Convert.ToDouble(grdSchedule.Model[i, 7].Text);
                                if (grdSchedule.Model[i, 8].Text != "")
                                    p[11].Value = Convert.ToDouble(grdSchedule.Model[i, 8].Text);
                                else
                                    p[11].Value = DBNull.Value;

                                p[12].Value = Convert.ToDouble(grdSchedule.Model[i, 9].Text);
                                p[13].Value = Convert.ToDouble(grdSchedule.Model[i, 13].Text);
                                p[14].Value = DBNull.Value;// new SqlParameter("@DiscountPercent", SqlDbType.Float);
                                if (grdSchedule.Model[i, 14].Text != "")
                                    p[15].Value = Convert.ToDouble(grdSchedule.Model[i, 14].Text);
                                else
                                    p[15].Value = DBNull.Value;

                                p[16].Value = Convert.ToDouble(txtTaxPercent.Text);
                                p[17].Value = Convert.ToDouble(txtTax.Text);
                                if (grdSchedule.Model[i, 15].Text != "")
                                    p[18].Value = Convert.ToDouble(grdSchedule.Model[i, 15].Text);
                                else
                                    p[18].Value = DBNull.Value;

                                if (grdSchedule.Model[i, 16].Text != "")
                                    p[19].Value = grdSchedule.Model[i, 16].Text;
                                else
                                    p[19].Value = DBNull.Value;

                                p[20].Value = DataContainer.EMP_Code;
                                SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.StoredProcedure, "save_BillDetails", p);
                            }
                        }
                        clsConnection.AddToBillLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + txtBillId.Text+"|"+txtPlanAmount.Text);

                        MessageBox.Show("Daily Bill saved successfully" + strBillNo, "Confirmation", MessageBoxButtons.OK);
                        cmdPrint.Enabled = true;
                        cmdCancel.Enabled = true;
                        _isUpdated = 0;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        private bool validateSave()
        {
            try
            {
                // if (txtBillNo.Text == "") { MessageBox.Show("Bill No not specified"); txtBillNo.Focus(); return false; }
                if (dtpBilledOnDate.Value < dtpBillDate.Value) { MessageBox.Show("Billed date cannot be prior to Schedule date"); dtpBilledOnDate.Focus(); return false; }
                if (dtpBilledOnDate.Value < dtpBookingDate.Value) { MessageBox.Show("Billed date cannot be prior to Booking date"); dtpBilledOnDate.Focus(); return false; }

                if (txtPlanAmount.Text == "") { MessageBox.Show("No Bill Amount is generated"); return false; }
                if (Convert.ToDouble(txtPlanAmount.Text) == 0)
                {
                    DialogResult mAns = MessageBox.Show("No Bill Amount is generated.\nDo you want to save the Bill?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (mAns == DialogResult.No) return false;
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

        private void txtDiscInAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscInAmount.Text.Trim() != "")
            {
                if (txtDiscInAmount.Focused) // calculate only when entry
                {
                    MakCalc_Daily();
                    _isUpdated = -1;
                }
            }
        }
        #endregion

        #region PrintBill
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.bookingPlanID == 0)
                    return;
                if (_isUpdated < 0)
                {
                    DialogResult mAns = MessageBox.Show("Changes to the bill are not yet saved. The print will show previously saved bill.\nDo you want to print anyway?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (mAns == DialogResult.No)
                    {
                        return;
                    }
                }

                prepareDoc();
                this.grdPreview.Model.Properties.PrintFrame = false;

                Syncfusion.GridHelperClasses.GridPrintDocumentAdv pd = new Syncfusion.GridHelperClasses.GridPrintDocumentAdv(this.grdPreview);
                pd.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 25);

                pd.HeaderHeight = 70;
                pd.FooterHeight = 50;

                pd.ScaleColumnsToFitPage = true; // this.ScaleColumnsToFit.Checked;

                //                pd.DrawGridPrintHeader += new Syncfusion.GridHelperClasses.GridPrintDocumentAdv.DrawGridHeaderFooterEventHandler(pd_DrawGridPrintHeader);
                //              pd.DrawGridPrintFooter += new Syncfusion.GridHelperClasses.GridPrintDocumentAdv.DrawGridHeaderFooterEventHandler(pd_DrawGridPrintFooter);

                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                //previewDialog.Parent = this;
                previewDialog.TopLevel = true;
                previewDialog.Document = pd;
                previewDialog.Name = "Daily Bill Print";
                previewDialog.PrintPreviewControl.Zoom = 1.5;
                previewDialog.Owner = this;
                previewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while print preview");
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        private void prepareDoc()
        {
            try
            {
                int prRow = 1;
                DataSet dsReport = new DataSet();
                DataSet dsReportHeader = new DataSet();
                dsReportHeader = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "repo_BillHead " + billId.ToString());
                dsReport = SqlHelper.ExecuteDataset(clsConnection.conn, CommandType.Text, "repo_BookingDailyBill " + billId.ToString());
                // NO DATA FOUND
                if (!(dsReportHeader.Tables.Count > 0 && dsReport.Tables[0].Rows.Count > 0))
                    return;
                DataRow drHeader = dsReportHeader.Tables[0].Rows[0];
                /*
                 "##GST_NO##" = drHeader["GST_NO"]
"##Address1##" = drHeader["Address1"]
"##Address2##" = drHeader["Address2"]
"##PAN##" = dr["PAN_NO"]
"##TAN##" = dr ["TAN_NO"]
"##ContactPerson##" = dr[]
##ContactNo##

                 */
                // SET GRID
                GridStyleInfo TitleStyle = new GridStyleInfo();
                TitleStyle.Font.Size = 12;
                TitleStyle.Font.Bold = true;
                TitleStyle.VerticalAlignment = GridVerticalAlignment.Middle;
                TitleStyle.HorizontalAlignment = GridHorizontalAlignment.Center;
                TitleStyle.CellType = GridCellTypeName.Static;

                GridStyleInfo headerstyle = new GridStyleInfo();
                headerstyle.Font.Size = 10;
                headerstyle.Font.Bold = true;
                headerstyle.VerticalAlignment = GridVerticalAlignment.Middle;
                headerstyle.HorizontalAlignment = GridHorizontalAlignment.Center;
                headerstyle.CellType = GridCellTypeName.Static;

                GridStyleInfo subheaderstyle = new GridStyleInfo();
                subheaderstyle.Font.Bold = true;
                subheaderstyle.VerticalAlignment = GridVerticalAlignment.Middle;
                subheaderstyle.CellType = GridCellTypeName.Static;
                subheaderstyle.BackColor = Color.LightGray;
                grdPreview.Model.RowHeights[1] = 20;

                GridStyleInfo smallFonts = new GridStyleInfo();
                smallFonts.Font.Size = 9;
                smallFonts.Font.Bold = false;
                smallFonts.VerticalAlignment = GridVerticalAlignment.Top;
                smallFonts.CellType = GridCellTypeName.Static;
                smallFonts.WrapText = true;

                grdPreview.ClearCells(GridRangeInfo.Cells(1, 1, grdPreview.RowCount, grdPreview.ColCount), true);

                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 1, prRow + 1, grdPreview.ColCount));
                grdPreview[prRow, 1] = headerstyle;
                grdPreview.Model[prRow, 1].Text = DataContainer.g_COMPANY_NAME;
                grdPreview[prRow, 1].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.ExtraThick);

                prRow += 2;
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 1, prRow, grdPreview.ColCount));
                grdPreview[prRow, 1].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                grdPreview.Model[prRow, 1].HorizontalAlignment = GridHorizontalAlignment.Center;
                grdPreview.Model[prRow, 1].Text = DataContainer.g_COMPANY_CIN;

                prRow++;
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 1, prRow, grdPreview.ColCount));
                grdPreview[prRow, 1] = TitleStyle;
                grdPreview.Model[prRow, 1].Text = "Booking Order Bill";
                grdPreview.Model.RowHeights[prRow] = 18;
                grdPreview[prRow, 1].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                grdPreview[prRow, 1].Borders.Top = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thin);
                grdPreview[prRow, 1].Borders.Bottom = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thin);
                // grdPreview[18, 1].Borders.Bottom = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thin);

                prRow++;
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 1, prRow, 2));
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 3, prRow, 7));
                grdPreview[prRow, 1] = subheaderstyle;
                grdPreview.Model[prRow, 1].Text = "Order Date";
                grdPreview.Model[prRow, 3].Text = drHeader["BillDate"].ToString();

                grdPreview[prRow, 10] = subheaderstyle;
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 10, prRow, 11));
                grdPreview.Model[prRow, 10].Text = "Order No.";
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 12, prRow, grdPreview.ColCount));
                grdPreview[prRow, 12].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                grdPreview.Model[prRow, 12].Text = drHeader["BillNo"].ToString();


                prRow++;
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 1, prRow, 2));
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 3, prRow, 7));
                grdPreview[prRow, 1] = subheaderstyle;
                grdPreview.Model[prRow, 1].Text = "Set";
                grdPreview.Model[prRow, 3].Text = drHeader["SetName"].ToString();

                grdPreview[prRow, 10] = subheaderstyle;
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 10, prRow, 11));
                grdPreview.Model[prRow, 10].Text = "Shooting Type";
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 12, prRow, grdPreview.ColCount));
                grdPreview[prRow, 12].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                grdPreview.Model[prRow, 12].Text = drHeader["ShootType"].ToString();

                prRow++;
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 1, prRow, 2));
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 3, prRow, 5));

                grdPreview[prRow, 10] = subheaderstyle;
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 10, prRow, 11));
                grdPreview.Model[prRow, 10].Text = "Booking Ref no.";
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 12, prRow, grdPreview.ColCount));
                grdPreview[prRow, 12].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                grdPreview.Model[prRow, 12].Text = drHeader["RefNo"].ToString();

                prRow++;
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 1, prRow, grdPreview.ColCount));
                grdPreview[prRow, 1] = headerstyle;
                grdPreview.Model[prRow, 1].Text = "Client Information";
                grdPreview[prRow, 1].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                grdPreview[prRow, 1].Borders.Top = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thin);
                grdPreview[prRow, 1].Borders.Bottom = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thin);

                prRow++;
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 1, prRow, 2));
                grdPreview[prRow, 1] = subheaderstyle;
                grdPreview.Model[prRow, 1].Text = "Client Name";
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 3, prRow, grdPreview.ColCount));
                grdPreview[prRow, 3].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                grdPreview.Model[prRow, 3].Text = drHeader["Customer"].ToString() + " (Unit: " + drHeader["CustomerUnit"].ToString() + " )";

                prRow++;
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 12, prRow, grdPreview.ColCount));
                grdPreview[prRow, 11] = subheaderstyle;
                grdPreview.Model[prRow, 11].Text = "GST";
                grdPreview.Model[prRow, 12].Text = drHeader["GST_NO"].ToString();//"##GST_NO##";
                grdPreview[prRow, 12].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);

                prRow++;
                /*                grdPreview.CoveredRanges.Add(
                                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 1, prRow, 2));
                                grdPreview[prRow, 1] = subheaderstyle;
                                grdPreview.Model[prRow, 1].Text = "Address";
                                grdPreview.CoveredRanges.Add(
                                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 3, prRow, 7));
                                grdPreview.CoveredRanges.Add(
                                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow + 1, 3, prRow + 1, 7));
                                grdPreview.Model[prRow, 3].Text = drHeader["Address1"].ToString();
                                grdPreview.Model[prRow + 1, 3].Text = drHeader["Address2"].ToString();
                */
                // grdPreview[prRow, 1] = subheaderstyle;
                grdPreview.Model[prRow, 1].Text = "Address";
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 2, prRow + 1, 7));
                //grdPreview.CoveredRanges.Add(
                //    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow + 1, 3, prRow + 1, 7));
                grdPreview.Model[prRow, 2] = smallFonts;
                grdPreview.Model[prRow, 2].Text = drHeader["Address1"].ToString() + " " + drHeader["Address2"].ToString();
                // grdPreview.Model[prRow + 1, 8].Text = drHeader["Address2"].ToString();

                grdPreview[prRow, 8] = subheaderstyle;
                grdPreview.Model[prRow, 8].Text = "PAN";
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 9, prRow, 10));
                grdPreview.Model[prRow, 9].Text = drHeader["PAN_NO"].ToString();// "##PAN##";

                grdPreview[prRow, 11] = subheaderstyle;
                grdPreview.Model[prRow, 11].Text = "TAN";
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 12, prRow, grdPreview.ColCount));
                grdPreview[prRow, 12].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                grdPreview.Model[prRow, 12].Text = drHeader["TAN_NO"].ToString();// "##TAN##";

                prRow += 2;
                grdPreview[prRow, 1] = subheaderstyle;
                grdPreview.Model[prRow, 1].Text = "Name";
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow + 1, 1, prRow + 1, 5));
                grdPreview.Model[prRow + 1, 1].Text = drHeader["EnquiryContactPerson"].ToString();// "##ContactPerson##";

                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 6, prRow, 9));
                grdPreview[prRow, 6] = subheaderstyle;
                grdPreview.Model[prRow, 6].Text = "Designation";
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow + 1, 6, prRow + 1, 9));
                grdPreview.Model[prRow + 1, 6].Text = drHeader["EnquiryContactDesg"].ToString(); // "##designation##";

                grdPreview[prRow, 11] = subheaderstyle;
                grdPreview.Model[prRow, 11].Text = "Mobile";
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 12, prRow, grdPreview.ColCount));
                grdPreview[prRow, 12].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                grdPreview.Model[prRow, 12].Text = drHeader["ContactNo"].ToString();
                grdPreview[prRow + 1, 11] = subheaderstyle;
                grdPreview.Model[prRow + 1, 11].Text = "Contact";
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow + 1, 12, prRow + 1, grdPreview.ColCount));
                grdPreview[prRow + 1, 12].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                grdPreview.Model[prRow + 1, 12].Text = drHeader["EnquiryContactPhone"].ToString();

                prRow += 2;
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 1, prRow, grdPreview.ColCount));
                grdPreview[prRow, 1].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);

                prRow++;
                grdPreview.CoveredRanges.Add(
                    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 1, prRow, grdPreview.ColCount));
                grdPreview[prRow, 1] = headerstyle;
                grdPreview.Model[prRow, 1].Text = "Billing Information";
                grdPreview[prRow, 1].Borders.Top = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thin);
                grdPreview[prRow, 1].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                prRow++;

                grdPreview[prRow, 1] = subheaderstyle; // Date
                grdPreview[prRow, 3] = subheaderstyle; // Narration
                grdPreview[prRow, 8] = subheaderstyle; // Unit
                grdPreview[prRow, 10] = subheaderstyle; // Rate
                grdPreview[prRow, 12] = subheaderstyle; //Amount
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 1, prRow, 2));
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 3, prRow, 7));
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 8, prRow, 9));
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 10, prRow, 11));
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRow, 12, prRow, grdPreview.ColCount));
                grdPreview.Model[prRow, 1].Text = "Date";
                grdPreview.Model[prRow, 3].Text = "Description";
                //                grdPreview.Model[prRow, 7].Text = "Units";
                grdPreview.Model[prRow, 8].Text = "Units";
                grdPreview.Model[prRow, 10].Text = "Rate (Rs.)";
                grdPreview.Model[prRow, 12].Text = "Amount (Rs.)";
                grdPreview[prRow, 12].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);

                int prRw = prRow + 1;
                for (int i = 0; i < dsReport.Tables[0].Rows.Count; i++)
                {
                    grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 1, prRw + 1, 2));
                    grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 3, prRw + 1, 7));
                    grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 8, prRw + 1, 9));
                    grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 11, prRw + 1, 12));
                    // grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw + 1, 6, prRw + 1, 12));
                    grdPreview.Model[prRw, 1].Text = drHeader["BillDate"].ToString(); //dsReport.Tables[0].Rows[i]["chargesName"].ToString();
                    grdPreview[prRw, 1].Borders.Right = new GridBorder(GridBorderStyle.Dotted, Color.Black, GridBorderWeight.ExtraThin);
                    grdPreview[prRw + 1, 1].Borders.Right = new GridBorder(GridBorderStyle.Dotted, Color.Black, GridBorderWeight.ExtraThin);

                    string strNarration = dsReport.Tables[0].Rows[i]["chargesName"].ToString() + ' ';
                    if (dsReport.Tables[0].Rows[i]["fromUnit"].ToString() != "")
                    {
                        strNarration += dsReport.Tables[0].Rows[i]["fromUnit"].ToString();
                        strNarration += " - " + dsReport.Tables[0].Rows[i]["ToUnit"].ToString();
                    }

                    if (dsReport.Tables[0].Rows[i]["Narration"].ToString() != "")
                    {
                        strNarration += " " + dsReport.Tables[0].Rows[i]["Narration"].ToString();
                    }
                    if (strNarration != "")
                    {
                        grdPreview.Model[(prRw), 3].Text = strNarration;
                        grdPreview.Model[(prRw), 3].WrapText = true;
                        this.grdPreview.RowHeights.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Rows(prRw, prRw), GridResizeToFitOptions.IncludeCellsWithinCoveredRange);
                        grdPreview[prRw, 3].Borders.Right = new GridBorder(GridBorderStyle.Dotted, Color.Black, GridBorderWeight.ExtraThin);
                        grdPreview[prRw + 1, 3].Borders.Right = new GridBorder(GridBorderStyle.Dotted, Color.Black, GridBorderWeight.ExtraThin);
                    }

                    grdPreview.Model[prRw, 8].Text = String.Format("{0:n2}", dsReport.Tables[0].Rows[i]["ChargedQty"]) + ' ' + String.Format("{0:n2}", dsReport.Tables[0].Rows[i]["UoM"]);
                    if (dsReport.Tables[0].Rows[i]["FreeQty"] != DBNull.Value)
                        if (Convert.ToDecimal(dsReport.Tables[0].Rows[i]["FreeQty"]) != 0)
                            grdPreview.Model[prRw, 8].Text = grdPreview.Model[prRw, 8].Text + " " + String.Format("{0}", dsReport.Tables[0].Rows[i]["freeQty"]) + "FREE";
                    grdPreview[prRw, 8].Borders.Right = new GridBorder(GridBorderStyle.Dotted, Color.Black, GridBorderWeight.ExtraThin);
                    grdPreview[prRw + 1, 8].Borders.Right = new GridBorder(GridBorderStyle.Dotted, Color.Black, GridBorderWeight.ExtraThin);

                    // grdPreview.Model[prRw, 8].Text = String.Format("{0:n2}", dsReport.Tables[0].Rows[i]["ChargedQty"]) + ' ' + String.Format("{0:n2}", dsReport.Tables[0].Rows[i]["UoM"]);
                    grdPreview.Model[prRw, 10].HorizontalAlignment = GridHorizontalAlignment.Right;
                    grdPreview.Model[prRw, 10].Text = String.Format("{0:n2}", dsReport.Tables[0].Rows[i]["Rate"]);
                    grdPreview[prRw, 10].Borders.Right = new GridBorder(GridBorderStyle.Dotted, Color.Black, GridBorderWeight.ExtraThin);
                    grdPreview[prRw + 1, 10].Borders.Right = new GridBorder(GridBorderStyle.Dotted, Color.Black, GridBorderWeight.ExtraThin);
                    grdPreview.Model[prRw, 11].HorizontalAlignment = GridHorizontalAlignment.Right;
                    grdPreview.Model[prRw, 11].Text = String.Format("{0:n2}", dsReport.Tables[0].Rows[i]["Amount"]);
                    prRw++;
                    prRw++;
                }
                for (int j = 1; j <= grdPreview.ColCount; j++)
                {
                    grdPreview[prRw, j].Borders.Bottom = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thin);
                    grdPreview[prRw, j].Borders.Top = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.ExtraThin);
                }
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 1, prRw, 2));
                grdPreview[prRw, 1] = subheaderstyle;
                grdPreview.Model[prRw, 1].Text = "Total";

                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 11, prRw, 12));
                grdPreview.Model[prRw, 11].HorizontalAlignment = GridHorizontalAlignment.Right;
                grdPreview.Model[prRw, 11].Text = "Rs." + String.Format("{0:n2}", drHeader["PlanAmount"]);

                prRw++;
                if (Convert.ToDouble(drHeader["Discount"]) != 0)
                {
                    grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 1, prRw, 2));
                    grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 6, prRw, 8));
                    grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 11, prRw, 12));
                    grdPreview[prRw, 1] = subheaderstyle;
                    grdPreview.Model[prRw, 1].Text = "Discount";
                    if (Convert.ToDouble(drHeader["DiscountPercent"]) != 0)
                    {
                        grdPreview.Model[prRw, 4].HorizontalAlignment = GridHorizontalAlignment.Right;
                        grdPreview.Model[prRw, 4].Text = string.Format("{0:n2}", drHeader["DiscountPercent"]) + "%";
                        grdPreview.Model[prRw, 6].HorizontalAlignment = GridHorizontalAlignment.Left;
                        grdPreview.Model[prRw, 6].Text = "(on Rs." + string.Format("{0:n2}", drHeader["DiscountOn"]) + ")";
                    }
                    grdPreview.Model[prRw, 11].HorizontalAlignment = GridHorizontalAlignment.Right;
                    grdPreview.Model[prRw, 11].Text = "Rs.-" + String.Format("{0:n2}", drHeader["Discount"]);
                    prRw++;

                    grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 11, prRw, 12));
                    grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 1, prRw, 2));
                    grdPreview[prRw, 1] = subheaderstyle;
                    grdPreview.Model[prRw, 1].Text = "SubTotal";
                    grdPreview.Model[prRw, 4].HorizontalAlignment = GridHorizontalAlignment.Right;

                    grdPreview.Model[prRw, 11].HorizontalAlignment = GridHorizontalAlignment.Right;
                    grdPreview.Model[prRw, 11].Text = "Rs." + String.Format("{0:n2}", drHeader["SubTotal"]);
                    grdPreview[prRw, 11].Borders.Bottom = new GridBorder(GridBorderStyle.Standard, Color.Black, GridBorderWeight.Thin);
                    grdPreview[prRw, 11].Borders.Top = new GridBorder(GridBorderStyle.Dotted, Color.Black, GridBorderWeight.Thin);
                    prRw++;
                }
                double dlyTax, dlyNett;
                dlyTax = Convert.ToDouble(drHeader["PlanAmount"]);
                dlyTax = Convert.ToDouble(drHeader["Tax"]);
                dlyNett = Math.Round(Convert.ToDouble(drHeader["TotalAmount"]), 0);
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 1, prRw, 2));
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 11, prRw, 12));
                grdPreview[prRw, 1] = subheaderstyle;
                grdPreview.Model[prRw, 1].Text = "Tax";
                grdPreview.Model[prRw, 4].HorizontalAlignment = GridHorizontalAlignment.Right;
                grdPreview.Model[prRw, 4].Text = String.Format("{0:n2}", drHeader["TaxPercent"]) + "%";

                grdPreview.Model[prRw, 11].HorizontalAlignment = GridHorizontalAlignment.Right;
                grdPreview.Model[prRw, 11].Text = "Rs." + String.Format("{0:n2}", drHeader["Tax"]);
                prRw++;


                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 1, prRw + 1, 2));
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 11, prRw, 12));
                grdPreview[prRw, 1] = subheaderstyle;
                grdPreview.Model[prRw, 1].Text = "GRAND TOTAL";
                grdPreview.Model[prRw, 11].HorizontalAlignment = GridHorizontalAlignment.Right;
                grdPreview.Model[prRw, 11].Text = "Rs." + String.Format("{0:n2}", drHeader["TotalAmount"]);
                for (int j = 1; j <= grdPreview.ColCount; j++)
                {
                    grdPreview[prRw, j].Borders.Top = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thin);
                }
                prRw++;

                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 3, prRw, 10));
                grdPreview.Model[prRw, 3].Text = "In Words " + dsReport.Tables[0].Rows[0]["AmtInWords"].ToString();
                for (int j = 1; j <= grdPreview.ColCount; j++)
                {
                    grdPreview[prRw, j].Borders.Bottom = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thin);
                }

                prRw += 5;
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 2, prRw, 8));
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 9, prRw, 13));
                grdPreview[prRw, 2].HorizontalAlignment = GridHorizontalAlignment.Center;
                grdPreview[prRw, 9].HorizontalAlignment = GridHorizontalAlignment.Center;
                grdPreview.Model[prRw, 2].Text = DataContainer.g_COMPANY_NAME;
                grdPreview.Model[prRw, 9].Text = "Hirer";
                for (int j = 1; j <= grdPreview.ColCount; j++)
                {
                    grdPreview[prRw, j].Borders.Bottom = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thin);
                }
                prRw += 2;
                grdPreview.CoveredRanges.Add(
    Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 1, prRw, grdPreview.ColCount));
                grdPreview[prRw, 1] = headerstyle;
                grdPreview.Model[prRw, 1].Text = "Invoice Information";
                grdPreview[prRw, 1].Borders.Bottom = new GridBorder(GridBorderStyle.Dotted, Color.Black, GridBorderWeight.Thin);
                grdPreview[prRw, 1].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                prRw++;
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 3, prRw, 6));
                grdPreview.CoveredRanges.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(prRw, 9, prRw, 12));
                grdPreview[prRw, 2].HorizontalAlignment = GridHorizontalAlignment.Center;
                grdPreview[prRw, 9].HorizontalAlignment = GridHorizontalAlignment.Center;
                if (dsReportHeader.Tables[0].Rows[0]["InvoiceNo"].ToString() != "")
                {
                    grdPreview.Model[prRw, 2].Text = "Invoice No.";
                    grdPreview.Model[prRw, 3].Text = dsReportHeader.Tables[0].Rows[0]["InvoiceNo"].ToString();
                    grdPreview.Model[prRw, 8].Text = "Dt";
                    grdPreview.Model[prRw, 9].Text = Convert.ToDateTime(dsReportHeader.Tables[0].Rows[0]["InvoiceDate"]).ToString("dd-MMM-yyyy");
                }
                else
                {
                    grdPreview.Model[prRw, 2].Text = "Invoice No.";
                    grdPreview.Model[prRw, 3].Text = "-NA-";
                }
                for (int j = 1; j <= grdPreview.ColCount; j++)
                {
                    grdPreview[prRw, j].Borders.Bottom = new GridBorder(GridBorderStyle.Dotted, Color.Black, GridBorderWeight.Thin);
                }
                for (int i = 1; i <= grdPreview.RowCount; i++)
                {
                    grdPreview[i, 1].Borders.Left = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                    grdPreview[i, 14].Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                }
                for (int j = 1; j <= grdPreview.ColCount; j++)
                {
                    grdPreview[1, j].Borders.Top = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                    grdPreview[grdPreview.RowCount, j].Borders.Bottom = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                }
                for (int j = 1; j <= grdPreview.ColCount; j++)
                {
                    grdPreview[prRow, j].Borders.Bottom = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Medium);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                clsConnection.AddToLog(System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|" + this.Text + "|" + ex.ToString());
            }
        }

        #endregion
    }
}
