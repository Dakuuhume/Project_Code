using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.Design;


namespace phase_2
{
    public partial class frmLogin : Form
    {
        SqlCommand cmd;

        DataTable dtCal = new DataTable();
        DataTable dtFin = new DataTable();

        public frmLogin()
        {
            InitializeComponent();
           
            //this.MdiParent.
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            lblError.Visible = false;

            if (txtUserName.Text.Trim() != "" && txtPassword.Text.Trim() != "")
            {
                DataTable dt = CheckLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim());/*txtPassword.Text.Trim());*/

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["MSG"].ToString().Equals("SUCCESS"))
                    {
                        //((mdiMain)this.MdiParent).InitializeFormData();
                        DataContainer.EMP_Code = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
                        DataContainer.USERNAME = dt.Rows[0]["UserName"].ToString();
                        DataContainer.EMP_ROLE = dt.Rows[0]["UserType"].ToString();
                        OrgDetails org = new OrgDetails();
                        org.CompanyId = 1;
                        DataContainer.g_COMPANY_CIN = org.CIN;
                        DataContainer.g_COMPANY_GST = org.GST;
                        DataContainer.g_COMPANY_NAME = org.CompanyName;
                        DataContainer.g_COMPANY_SHORT_FORM = org.ShortName;
                        DataContainer.g_PAN = org.PAN;
                        DataContainer.g_TAN = org.TAN;
                        DataContainer.g_Address1 = org.Address1;
                        DataContainer.g_Address2 = org.Address2;
                        DataContainer.g_City = org.City;
                        DataContainer.g_Pincode = org.Pincode;
                        DataContainer.g_PhoneNo = org.PhoneNo;
                        DataContainer.g_Website = org.Website;
                        DataContainer.g_Disclaimer_Enquiry = org.Disclaimer_Enquiry;
                        DataContainer.g_BankName = org.BankName;
                        DataContainer.g_BankBranch = org.BankBranch;
                        DataContainer.g_BankAcNo = org.BankAcNo;
                        DataContainer.g_BankIFSC = org.BankIFSC;
                        
                        this.Close();
                    }
                    else
                    {
                        DataContainer.EMP_Code = 0;
                        DataContainer.USERNAME = string.Empty;
                        DataContainer.EMP_ROLE = string.Empty;
                        lblError.Visible = true;
                        lblError.Text = dt.Rows[0]["MSG"].ToString();
                    }
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "User name and password is not valid Please try again.";
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Please enter valid user name and password.";
            }
        }

        public DataTable CheckLogin(string UID, string PASS)
        {
            ////DataSet ds = new DataSet(); 
            SqlDataReader sqlReader;
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = clsConnection.conn;
                //MessageBox.Show(clsConnection.conn.ConnectionString);
                if (clsConnection.conn != null && clsConnection.conn.State == ConnectionState.Closed)
                {
                    clsConnection.conn.Open();
                }

                try
                {
                    cmd.CommandText = "validate_user";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = UID;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = PASS;
                    cmd.Connection = clsConnection.conn;
                    sqlReader = cmd.ExecuteReader();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlReader.Close();
                    da.Fill(dt);
                    da.Dispose();
                    return dt;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                if (clsConnection.conn != null && clsConnection.conn.State == ConnectionState.Open)
                {
                    clsConnection.conn.Close();
                }
            }
        }

        public string Logic()
        {
            
int XORNUM;
XORNUM = 117;
int size;
int charCnt ;
     String data;
     Char char1;
    
    data = "$";
    if (txtPassword.Text != "" )
    {
       
            size=txtPassword.Text.Length;

        for (charCnt = 0; charCnt < size; charCnt++)
        {
            char1 = Convert.ToChar( txtPassword.Text.Substring(charCnt, 1));
            int b = (int)char1;
        
            if((b ^ XORNUM) != 0) 
            {
      char1 =Convert.ToChar(b ^ XORNUM);
            }
            data = data + char1;
        }

    }
            //MessageBox.Show(data);
            data = "$  ";
       return data;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.Transparent;
            if (System.Configuration.ConfigurationSettings.AppSettings["SetConnectionType"].ToString() == "Development")
            {
                txtUserName.Text = "admin";
                txtPassword.Text = "";
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }
    }
}