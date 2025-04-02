using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UserRights
{
    public partial class Form1 : Form
    {
        public Form1(bool isNewUser)
        {
            InitializeComponent();
            InitializeFormControls();

            if (isNewUser)
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtconfirmPassword.Text = "";
                txtFullname.Text = "";
                txtContact.Text = "";
                txtEmail.Text = "";
                cmbActive.SelectedIndex = 0;

                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
                txtconfirmPassword.Enabled = true;
                txtFullname.Enabled = true;
                txtContact.Enabled = true;
                txtEmail.Enabled = true;
                cmbRole.Enabled = true;
                cmbActive.Enabled = true;
                btnsetrights.Enabled = false;
            }
        }

        public Form1(string userName, string userType, string password, string fullName, string contactNo, string email, string active)
        {
            InitializeComponent();
            InitializeFormControls();

            // Set textboxes with the passed values
            txtExistingPassword.Text = password;
            txtUsername.Text = userName;
            txtPassword.Text = password;
            txtconfirmPassword.Text = password;
            cmbActive.SelectedItem = active;
            txtFullname.Text = fullName;
            txtContact.Text = contactNo;
            txtEmail.Text = email;

            // Disable non-password fields
            DisableAllTextboxes();
            EnablePasswordFields();

            // Change the button text to indicate password update
            btnSave.Text = "Save";
        }

        private void DisableAllTextboxes()
        {
            txtUsername.Enabled = false;
            txtFullname.Enabled = false;
            txtContact.Enabled = false;
            txtEmail.Enabled = false;
            cmbRole.Enabled = false;
            cmbActive.Enabled = false;
        }

        private void EnablePasswordFields()
        {
            txtExistingPassword.Enabled = true;
            txtPassword.Enabled = true;
            txtconfirmPassword.Enabled = true;
        }

        private void InitializeFormControls()
        {
            cmbActive.Items.AddRange(new string[] { "Yes", "No" });
            cmbActive.SelectedIndex = 0;

            cmbRole.Items.AddRange(new string[] { "Operation", "Manager", "Account", "Admin", "Facility" });
            cmbRole.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text != txtconfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match or are empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Check if the user exists
                string checkQuery = "SELECT COUNT(*) FROM UserMaster WHERE UserName = @UserName";
                SqlParameter[] checkParams = { new SqlParameter("@UserName", txtUsername.Text) };
                int userExists = Convert.ToInt32(SqlHelper.ExecuteScalar(checkQuery, checkParams));

                if (userExists > 0)
                {
                    // Update existing user
                    string updateQuery = "UPDATE UserMaster SET Password = @Password, UserType = @UserType, isActive = @Active, Email = @Email, Mobile = @Mobile WHERE UserName = @UserName";
                    SqlParameter[] updateParams = {
                        new SqlParameter("@UserName", txtUsername.Text),
                        new SqlParameter("@Password", txtPassword.Text),
                        new SqlParameter("@UserType", cmbRole.Text),
                        new SqlParameter("@Active", cmbActive.Text == "Yes" ? 1 : 0),
                        new SqlParameter("@Email", txtEmail.Text),
                        new SqlParameter("@Mobile", txtContact.Text)
                    };
                    SqlHelper.ExecuteNonQuery(updateQuery, updateParams);
                }
                else
                {
                    // Insert new user
                    string insertQuery = "INSERT INTO UserMaster (UserName, Password, UserType, isActive, Email, Mobile) VALUES (@UserName, @Password, @UserType, @Active, @Email, @Mobile)";
                    SqlParameter[] insertParams = {
                        new SqlParameter("@UserName", txtUsername.Text),
                        new SqlParameter("@Password", txtPassword.Text),
                        new SqlParameter("@UserType", cmbRole.Text),
                        new SqlParameter("@Active", cmbActive.Text == "Yes" ? 1 : 0),
                        new SqlParameter("@Email", txtEmail.Text),
                        new SqlParameter("@Mobile", txtContact.Text)
                    };
                    SqlHelper.ExecuteNonQuery(insertQuery, insertParams);
                }

                MessageBox.Show("Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving record: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            cmbActive.Enabled = true;
            ControlBox = false;
        }

        private void User_Click(object sender, EventArgs e)
        {
            Users userForm = new Users();
            
            userForm.Show();
            this.Hide();
            //this.Close();

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure to cancel?");
            ElloraProperties main = new ElloraProperties();
           
            main.Show();
            this.Hide();
           // this.Close();
        }

        private void Rights_Click(object sender, EventArgs e)
        {
            Rights r3 = new Rights(txtUsername.Text, cmbRole.Text);
           
            r3.Show();
            this.Hide();
           // this.Close();
        }
    }
}