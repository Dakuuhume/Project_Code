using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO; 
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UserRights
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            LoadUserData();
            this.dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
        }

        private void LoadUserData()
        {
            try
            {
                string query = "SELECT UserName, Mobile, FullName, UserType, IsActive AS Active, Email, Password FROM UserMaster;";
                DataTable dt = SqlHelper.ExecuteQuery(query);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(true);
           
            f1.Show();
           // this.Close();
        }

        private void button6_Click(object sender, EventArgs e) // Assign Rights
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string userName = row.Cells["UserName"].Value.ToString();
                string userType = row.Cells["UserType"].Value.ToString();

                Rights r3 = new Rights(userName, userType);
                
                r3.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Please select a user to assign rights.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                string userName = row.Cells["UserName"].Value.ToString();
                string fullName = row.Cells["FullName"].Value.ToString();
                string userType = row.Cells["UserType"].Value.ToString();
                string mobile = row.Cells["Mobile"].Value.ToString();
                string email = row.Cells["Email"].Value.ToString();
                string active = row.Cells["Active"].Value.ToString();
                string password = row.Cells["Password"].Value.ToString();

                Form1 e1 = new Form1(userName, userType, password, fullName, mobile, email, active);
             
                e1.Show();
                //this.Close();
                LoadUserData();
               
            }
            else
            {
                MessageBox.Show("Please select a user to change password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            Form1 u1 = new Form1(true);
            
            u1.Show();
            this.Hide();
            //this.Close();
            LoadUserData();
            
        }

        private void Rights_Click(object sender, EventArgs e)
        {
            string userName = "";
            string userType = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                userName = row.Cells["UserName"].Value.ToString();
                userType = row.Cells["UserType"].Value.ToString();
            }

            Rights r3 = new Rights(userName, userType);
            r3.Show();
            this.Hide();
            
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string filterText = txtSearch.Text.Trim();
            string selectedUserType = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(filterText) && string.IsNullOrWhiteSpace(selectedUserType))
            {
                MessageBox.Show("Please enter a username or select a user type to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT UserName, Mobile, FullName, UserType, IsActive AS Active, Email, Password FROM UserMaster WHERE 1=1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(filterText))
            {
                if (rbtnContaining.Checked)
                {
                    query += " AND UserName LIKE @FilterText";
                    parameters.Add(new SqlParameter("@FilterText", "%" + filterText + "%"));
                }
                else if (rbtnStarting.Checked)
                {
                    query += " AND UserName LIKE @FilterText + '%'";
                    parameters.Add(new SqlParameter("@FilterText", filterText));
                }
            }

            if (!string.IsNullOrWhiteSpace(selectedUserType))
            {
                query += " AND UserType = @UserType";
                parameters.Add(new SqlParameter("@UserType", selectedUserType));
            }

            try
            {
                DataTable dt = SqlHelper.ExecuteQuery(query, parameters.ToArray());
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            ControlBox = true;
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void Users_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            ElloraProperties main = new ElloraProperties();
            main.Show();
            this.Dispose();
        }
    }
}