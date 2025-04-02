namespace UserRights
{
    partial class Users
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Rights = new System.Windows.Forms.Button();
            this.User = new System.Windows.Forms.Button();
            this.AddUser = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rbtnContaining = new System.Windows.Forms.RadioButton();
            this.rbtnStarting = new System.Windows.Forms.RadioButton();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Rights
            // 
            this.Rights.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Rights.FlatAppearance.BorderSize = 2;
            this.Rights.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Rights.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rights.Location = new System.Drawing.Point(330, 29);
            this.Rights.Name = "Rights";
            this.Rights.Size = new System.Drawing.Size(123, 33);
            this.Rights.TabIndex = 5;
            this.Rights.Text = "Rights";
            this.Rights.UseVisualStyleBackColor = true;
            this.Rights.UseWaitCursor = true;
            this.Rights.Click += new System.EventHandler(this.Rights_Click);
            // 
            // User
            // 
            this.User.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.User.FlatAppearance.BorderSize = 2;
            this.User.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.User.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User.Location = new System.Drawing.Point(189, 29);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(135, 33);
            this.User.TabIndex = 4;
            this.User.Text = "User";
            this.User.UseVisualStyleBackColor = true;
            this.User.UseWaitCursor = true;
            // 
            // AddUser
            // 
            this.AddUser.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AddUser.BackColor = System.Drawing.SystemColors.Control;
            this.AddUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddUser.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AddUser.FlatAppearance.BorderSize = 2;
            this.AddUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUser.Location = new System.Drawing.Point(57, 29);
            this.AddUser.Name = "AddUser";
            this.AddUser.Size = new System.Drawing.Size(126, 33);
            this.AddUser.TabIndex = 3;
            this.AddUser.TabStop = false;
            this.AddUser.Text = "Add  User";
            this.AddUser.UseVisualStyleBackColor = false;
            this.AddUser.Click += new System.EventHandler(this.AddUser_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Yellow;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnNew.Location = new System.Drawing.Point(93, 109);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(117, 51);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnChangePassword.Location = new System.Drawing.Point(216, 109);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(179, 51);
            this.btnChangePassword.TabIndex = 7;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAssign.Location = new System.Drawing.Point(401, 109);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(153, 51);
            this.btnAssign.TabIndex = 8;
            this.btnAssign.Text = "Assign Rights";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtSearch.Location = new System.Drawing.Point(570, 109);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(210, 26);
            this.txtSearch.TabIndex = 9;
            // 
            // rbtnContaining
            // 
            this.rbtnContaining.AutoSize = true;
            this.rbtnContaining.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rbtnContaining.Location = new System.Drawing.Point(786, 111);
            this.rbtnContaining.Name = "rbtnContaining";
            this.rbtnContaining.Size = new System.Drawing.Size(110, 24);
            this.rbtnContaining.TabIndex = 10;
            this.rbtnContaining.Text = "Containing";
            this.rbtnContaining.UseVisualStyleBackColor = true;
            // 
            // rbtnStarting
            // 
            this.rbtnStarting.AutoSize = true;
            this.rbtnStarting.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rbtnStarting.Location = new System.Drawing.Point(902, 111);
            this.rbtnStarting.Name = "rbtnStarting";
            this.rbtnStarting.Size = new System.Drawing.Size(90, 24);
            this.rbtnStarting.TabIndex = 11;
            this.rbtnStarting.Text = "Starting";
            this.rbtnStarting.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnFilter.Location = new System.Drawing.Point(1138, 105);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(93, 34);
            this.btnFilter.TabIndex = 12;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.Location = new System.Drawing.Point(93, 166);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(985, 516);
            this.dataGridView1.TabIndex = 13;
            // 
            // cmbRole
            // 
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Operations",
            "Manager",
            "Account",
            "Admin",
            "Facility"});
            this.cmbRole.Location = new System.Drawing.Point(998, 109);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(121, 28);
            this.cmbRole.TabIndex = 14;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 710);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.rbtnStarting);
            this.Controls.Add(this.rbtnContaining);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.Rights);
            this.Controls.Add(this.User);
            this.Controls.Add(this.AddUser);
            this.Name = "Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Users_FormClosing);
            this.Load += new System.EventHandler(this.Users_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Rights;
        private System.Windows.Forms.Button User;
        private System.Windows.Forms.Button AddUser;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rbtnContaining;
        private System.Windows.Forms.RadioButton rbtnStarting;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbRole;
    }
}