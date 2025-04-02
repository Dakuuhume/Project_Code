using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using UserRights;

namespace UserRights
{
    public partial class Rights : Form
    {
        private string userName;
        private string userType;

        public Rights(string userName, string userType)
        {
            InitializeComponent();
            this.userName = userName;
            this.userType = userType;

            txtRole.Text = userType;
            txtUsername.Text = userName;

            // Load ListView data when the form opens
            LoadFormNameData();
            LoadCanAddData();

            // Refresh ListView on text change
            txtUsername.TextChanged += TxtFields_TextChanged;
            txtRole.TextChanged += TxtFields_TextChanged;

            // Configure ListView appearance
            SetupListView(listView1, "Menu_Name", 250, true); // Editable initially
            SetupListViewWithCheckBoxes(listView2, "Allows", 100);

            // Attach event handlers to buttons
            btnright.Click += btnright_Click;
            btnleft.Click += btnleft_Click;

            // Attach event handler for checkboxes
            listView2.ItemCheck += listView2_ItemCheck;
        }

        // Setup ListView1 (Names of Permissions)
        private void SetupListView(System.Windows.Forms.ListView listView, string columnName, int width, bool editable)
        {
            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.CheckBoxes = false;
            listView.Columns.Clear();
            listView.Columns.Add(columnName, width);
            listView.Enabled = editable; // Control editability
        }

        // Setup ListView2 (Permissions with Checkboxes)
        private void SetupListViewWithCheckBoxes(System.Windows.Forms.ListView listView, string columnName, int width)
        {
            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.CheckBoxes = true;
            listView.Columns.Clear();
            listView.Columns.Add(columnName, width);
            listView.Enabled = false; // Initially read-only
        }

        // Reload data when textboxes change
        private void TxtFields_TextChanged(object sender, EventArgs e)
        {
            LoadFormNameData();
            LoadCanAddData();
        }

        // Load Form Names into ListView1
        private void LoadFormNameData()
        {
            listView1.Items.Clear();
            try
            {
                string query = @"SELECT UR.Form_Name 
                                FROM UsersRights UR
                                INNER JOIN UserMaster UM ON UR.UserId = UM.UserId
                                WHERE UM.UserName = @UserName AND UM.UserType = @UserType";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@UserName", txtUsername.Text),
                    new SqlParameter("@UserType", txtRole.Text)
                };

                DataTable dt = SqlHelper.ExecuteQuery(query, parameters);

                foreach (DataRow row in dt.Rows)
                {
                    listView1.Items.Add(new ListViewItem(row["Form_Name"].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Menu_Name data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load Permissions into ListView2 (With Checkboxes)
        private void LoadCanAddData()
        {
            listView2.Items.Clear();
            try
            {
                string query = @"SELECT UR.Form_Name, UR.can_Add 
                                FROM UsersRights UR
                                INNER JOIN UserMaster UM ON UR.UserId = UM.UserId
                                WHERE UM.UserName = @UserName AND UM.UserType = @UserType";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@UserName", txtUsername.Text),
                    new SqlParameter("@UserType", txtRole.Text)
                };

                DataTable dt = SqlHelper.ExecuteQuery(query, parameters);

                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["Form_Name"].ToString());
                    item.Checked = row["can_Add"].ToString() == "1";
                    listView2.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Allows data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                string formName = listView2.Items[e.Index].Text;
                int newValue = e.NewValue == CheckState.Checked ? 1 : 0;

                string query = @"
            UPDATE UsersRights 
            SET can_Add = @can_Add 
            WHERE Form_Name = @Form_Name 
            AND UserId = (SELECT UserId FROM UserMaster WHERE UserName = @UserName AND UserType = @UserType)";

                SqlParameter[] parameters =
                {
            new SqlParameter("@UserName", txtUsername.Text),
            new SqlParameter("@UserType", txtRole.Text),
            new SqlParameter("@Form_Name", formName),
            new SqlParameter("@can_Add", newValue)
        };

                SqlHelper.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating permissions: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update Database When Checkbox is Clicked
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listView2.Items)
                {
                    string formName = item.Text;
                    int canAdd = item.Checked ? 1 : 0;

                    string query = @" UPDATE UsersRights 
                                   SET can_Add = @can_Add 
                                   WHERE Form_Name = @Form_Name 
                                   AND UserId = (SELECT UserId FROM UserMaster WHERE UserName = @UserName AND UserType = @UserType)";

                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@UserName", txtUsername.Text),
                        new SqlParameter("@UserType", txtRole.Text),
                        new SqlParameter("@Form_Name", formName),
                        new SqlParameter("@can_Add", canAdd)
                    };

                    SqlHelper.ExecuteNonQuery(query, parameters);
                }

                MessageBox.Show("Permissions saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving permissions: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Rights_Load(object sender, EventArgs e)
        {
            ControlBox = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ElloraProperties main = new ElloraProperties();
            main.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users u2 = new Users();
            u2.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1(true);
            f1.Show();

        }

        private void btnright_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    listView1.Items.Remove(item);
                    listView2.Items.Add((ListViewItem)item.Clone());
                }

                listView1.Enabled = false; // Make ListView1 read-only
                listView2.Enabled = true;  // Make ListView2 editable
            }
            else
            {
                //MessageBox.Show("Please select a permission to move.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnleft_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView2.SelectedItems)
                {
                    listView2.Items.Remove(item);
                    listView1.Items.Add((ListViewItem)item.Clone());
                }

                listView2.Enabled = false; // Make ListView2 read-only
                listView1.Enabled = true;  // Make ListView1 editable
            }
            else
            {
                //MessageBox.Show("Please select a permission to move back.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
// private void btnCancel_Click(object sender, EventArgs e)
//{
//    ElloraProperties main = new ElloraProperties();
//    main.Show();
//    this.Hide();
//}

//private void button2_Click(object sender, EventArgs e)
//{
//    this.Hide();
//    Users u2 = new Users();
//    u2.Show();

//}

//private void button1_Click(object sender, EventArgs e)
//{
//    this.Hide();
//    Form1 f1 = new Form1(true);
//    f1.Show();

//}

//btn right
//try
//{
//    foreach (ListViewItem item in listView2.Items)
//    {
//        string formName = item.Text;
//        int canAdd = item.Checked ? 1 : 0;

//        string query = @" UPDATE UsersRights 
//                                   SET can_Add = @can_Add 
//                                   WHERE Form_Name = @Form_Name 
//                                   AND UserId = (SELECT UserId FROM UserMaster WHERE UserName = @UserName AND UserType = @UserType)";

//        SqlParameter[] parameters =
//        {
//                        new SqlParameter("@UserName", txtUsername.Text),
//                        new SqlParameter("@UserType", txtRole.Text),
//                        new SqlParameter("@Form_Name", formName),
//                        new SqlParameter("@can_Add", canAdd)
//                    };

//        SqlHelper.ExecuteNonQuery(query, parameters);
//    }

//    MessageBox.Show("Permissions saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//}
//catch (Exception ex)
//{
//    MessageBox.Show("Error saving permissions: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//}