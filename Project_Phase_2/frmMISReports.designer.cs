namespace phase_2
{
    partial class frmMISReports
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
            Syncfusion.Windows.Forms.Grid.GridCellInfo gridCellInfo1 = new Syncfusion.Windows.Forms.Grid.GridCellInfo();
            this.grpPlans = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dbcBookingStatus = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.grdEnquiries = new Syncfusion.Windows.Forms.Grid.GridControl();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dbcCustomer = new System.Windows.Forms.ComboBox();
            this.dbcSet = new System.Windows.Forms.ComboBox();
            this.grpPlans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEnquiries)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPlans
            // 
            this.grpPlans.BackColor = System.Drawing.Color.PowderBlue;
            this.grpPlans.Controls.Add(this.btnApply);
            this.grpPlans.Controls.Add(this.label1);
            this.grpPlans.Controls.Add(this.dbcBookingStatus);
            this.grpPlans.Controls.Add(this.btnExport);
            this.grpPlans.Controls.Add(this.grdEnquiries);
            this.grpPlans.Controls.Add(this.lblToDate);
            this.grpPlans.Controls.Add(this.dtpToDate);
            this.grpPlans.Controls.Add(this.dtpFromDate);
            this.grpPlans.Controls.Add(this.label5);
            this.grpPlans.Controls.Add(this.label6);
            this.grpPlans.Controls.Add(this.lblFromDate);
            this.grpPlans.Controls.Add(this.dbcCustomer);
            this.grpPlans.Controls.Add(this.dbcSet);
            this.grpPlans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpPlans.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPlans.Location = new System.Drawing.Point(32, 30);
            this.grpPlans.Margin = new System.Windows.Forms.Padding(4);
            this.grpPlans.Name = "grpPlans";
            this.grpPlans.Padding = new System.Windows.Forms.Padding(4);
            this.grpPlans.Size = new System.Drawing.Size(1701, 786);
            this.grpPlans.TabIndex = 0;
            this.grpPlans.TabStop = false;
            this.grpPlans.Text = " Electric Meter Reading ";
            this.grpPlans.Enter += new System.EventHandler(this.grpPlans_Enter);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.Gold;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(1228, 132);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(144, 41);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Report Type";
            // 
            // dbcBookingStatus
            // 
            this.dbcBookingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbcBookingStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbcBookingStatus.FormattingEnabled = true;
            this.dbcBookingStatus.Location = new System.Drawing.Point(27, 70);
            this.dbcBookingStatus.Margin = new System.Windows.Forms.Padding(4);
            this.dbcBookingStatus.Name = "dbcBookingStatus";
            this.dbcBookingStatus.Size = new System.Drawing.Size(344, 29);
            this.dbcBookingStatus.TabIndex = 0;
            this.dbcBookingStatus.SelectedIndexChanged += new System.EventHandler(this.dbcBookingStatus_SelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Gold;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(1380, 132);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(144, 41);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // grdEnquiries
            // 
            this.grdEnquiries.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.DblClickOnCell;
            this.grdEnquiries.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(94)))), ((int)(((byte)(171)))), ((int)(((byte)(222)))));
            this.grdEnquiries.ColCount = 18;
            this.grdEnquiries.DefaultGridBorderStyle = Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid;
            this.grdEnquiries.DefaultRowHeight = 20;
            this.grdEnquiries.Font = new System.Drawing.Font("Tahoma", 8.25F);
            gridCellInfo1.Col = -1;
            gridCellInfo1.Row = -1;
            gridCellInfo1.StyleInfo.Font.Bold = false;
            gridCellInfo1.StyleInfo.Font.Facename = "Tahoma";
            gridCellInfo1.StyleInfo.Font.Italic = false;
            gridCellInfo1.StyleInfo.Font.Size = 8.25F;
            gridCellInfo1.StyleInfo.Font.Strikeout = false;
            gridCellInfo1.StyleInfo.Font.Underline = false;
            gridCellInfo1.StyleInfo.Font.Unit = System.Drawing.GraphicsUnit.Point;
            this.grdEnquiries.GridCells.AddRange(new Syncfusion.Windows.Forms.Grid.GridCellInfo[] {
            gridCellInfo1});
            this.grdEnquiries.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro;
            this.grdEnquiries.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            this.grdEnquiries.Location = new System.Drawing.Point(27, 213);
            this.grdEnquiries.Margin = new System.Windows.Forms.Padding(4);
            this.grdEnquiries.MetroScrollBars = true;
            this.grdEnquiries.Name = "grdEnquiries";
            this.grdEnquiries.Properties.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.grdEnquiries.ReadOnly = true;
            this.grdEnquiries.RowCount = 31;
            this.grdEnquiries.RowHeightEntries.AddRange(new Syncfusion.Windows.Forms.Grid.GridRowHeight[] {
            new Syncfusion.Windows.Forms.Grid.GridRowHeight(0, 29)});
            this.grdEnquiries.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeIntoCode;
            this.grdEnquiries.Size = new System.Drawing.Size(1633, 548);
            this.grdEnquiries.SmartSizeBox = false;
            this.grdEnquiries.TabIndex = 7;
            this.grdEnquiries.Text = "gridControl1";
            this.grdEnquiries.ThemeName = "Metro";
            this.grdEnquiries.ThemesEnabled = true;
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonDisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonDisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonPressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonPressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ThumbBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ThumbDisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ThumbDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ThumbHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ThumbHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ThumbPressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.grdEnquiries.ThemeStyle.HorizontalScrollBarStyle.ThumbPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ArrowButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ArrowButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ArrowButtonDisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ArrowButtonDisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ArrowButtonHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ArrowButtonHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ArrowButtonPressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ArrowButtonPressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ThumbBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ThumbDisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ThumbDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ThumbHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ThumbHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ThumbPressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.grdEnquiries.ThemeStyle.VerticalScrollBarStyle.ThumbPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.grdEnquiries.UseRightToLeftCompatibleTextBox = true;
            this.grdEnquiries.CellDoubleClick += new Syncfusion.Windows.Forms.Grid.GridCellClickEventHandler(this.grdEnquiries_CellDoubleClick);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(541, 43);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(68, 23);
            this.lblToDate.TabIndex = 11;
            this.lblToDate.Text = "To Date";
            this.lblToDate.Visible = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(545, 70);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(155, 29);
            this.dtpToDate.TabIndex = 2;
            this.dtpToDate.Visible = false;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(380, 70);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(156, 29);
            this.dtpFromDate.TabIndex = 1;
            this.dtpFromDate.Value = new System.DateTime(2024, 11, 2, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(705, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Meter Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1113, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Customers";
            this.label6.Visible = false;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(376, 42);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(102, 23);
            this.lblFromDate.TabIndex = 9;
            this.lblFromDate.Text = "Report Date";
            // 
            // dbcCustomer
            // 
            this.dbcCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbcCustomer.FormattingEnabled = true;
            this.dbcCustomer.Location = new System.Drawing.Point(1117, 70);
            this.dbcCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.dbcCustomer.Name = "dbcCustomer";
            this.dbcCustomer.Size = new System.Drawing.Size(557, 29);
            this.dbcCustomer.TabIndex = 4;
            this.dbcCustomer.Visible = false;
            this.dbcCustomer.TextUpdate += new System.EventHandler(this.dbcCustomer_TextUpdate);
            // 
            // dbcSet
            // 
            this.dbcSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbcSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbcSet.FormattingEnabled = true;
            this.dbcSet.Location = new System.Drawing.Point(709, 70);
            this.dbcSet.Margin = new System.Windows.Forms.Padding(4);
            this.dbcSet.Name = "dbcSet";
            this.dbcSet.Size = new System.Drawing.Size(399, 29);
            this.dbcSet.TabIndex = 3;
            // 
            // frmMISReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1827, 848);
            this.Controls.Add(this.grpPlans);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMISReports";
            this.Tag = "REPORT-PH2";
            this.Text = "MIS Reports";
            this.Activated += new System.EventHandler(this.frmMISReports_Activated);
            this.Load += new System.EventHandler(this.frmMISReports_Load);
            this.Shown += new System.EventHandler(this.frmMISReports_Shown);
            this.grpPlans.ResumeLayout(false);
            this.grpPlans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEnquiries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPlans;
        private Syncfusion.Windows.Forms.Grid.GridControl grdEnquiries;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.ComboBox dbcCustomer;
        private System.Windows.Forms.ComboBox dbcSet;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dbcBookingStatus;
        private System.Windows.Forms.Button btnApply;
    }
}