namespace phase_2
{
    partial class mdiMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.electricityMetersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeupRoomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outdoorSetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lTPanelMetersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bILLMETERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mASTERBillMeterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mONTHLYREADINGSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.meterReadingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeupRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransOutdoor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuLTPanelReading = new System.Windows.Forms.ToolStripMenuItem();
            this.eleCalendarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTDSEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debtorReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerBookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meterConsumptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.stsUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Bisque;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.bILLMETERToolStripMenuItem,
            this.mnuTransactions,
            this.eleCalendarToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.mnuDashboard,
            this.mnuWindows,
            this.mnuExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.mnuWindows;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(975, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "MainMenu";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.electricityMetersToolStripMenuItem,
            this.makeupRoomsToolStripMenuItem,
            this.outdoorSetsToolStripMenuItem,
            this.chargesToolStripMenuItem,
            this.lTPanelMetersToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(79, 26);
            this.masterToolStripMenuItem.Text = "MASTER";
            this.masterToolStripMenuItem.Click += new System.EventHandler(this.masterToolStripMenuItem_Click);
            // 
            // electricityMetersToolStripMenuItem
            // 
            this.electricityMetersToolStripMenuItem.Name = "electricityMetersToolStripMenuItem";
            this.electricityMetersToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.electricityMetersToolStripMenuItem.Tag = "MAST-METER";
            this.electricityMetersToolStripMenuItem.Text = "Electricity Meters";
            this.electricityMetersToolStripMenuItem.Click += new System.EventHandler(this.electricityMetersToolStripMenuItem_Click);
            // 
            // makeupRoomsToolStripMenuItem
            // 
            this.makeupRoomsToolStripMenuItem.Name = "makeupRoomsToolStripMenuItem";
            this.makeupRoomsToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.makeupRoomsToolStripMenuItem.Tag = "MAST-ROOM";
            this.makeupRoomsToolStripMenuItem.Text = "Makeup Rooms";
            this.makeupRoomsToolStripMenuItem.Click += new System.EventHandler(this.makeupRoomsToolStripMenuItem_Click);
            // 
            // outdoorSetsToolStripMenuItem
            // 
            this.outdoorSetsToolStripMenuItem.Name = "outdoorSetsToolStripMenuItem";
            this.outdoorSetsToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.outdoorSetsToolStripMenuItem.Tag = "M_OUTDOOR";
            this.outdoorSetsToolStripMenuItem.Text = "Outdoor Sets";
            this.outdoorSetsToolStripMenuItem.Visible = false;
            // 
            // chargesToolStripMenuItem
            // 
            this.chargesToolStripMenuItem.Name = "chargesToolStripMenuItem";
            this.chargesToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.chargesToolStripMenuItem.Tag = "USAGE-TYPE";
            this.chargesToolStripMenuItem.Text = "Usage Type";
            this.chargesToolStripMenuItem.Click += new System.EventHandler(this.chargesToolStripMenuItem_Click);
            // 
            // lTPanelMetersToolStripMenuItem
            // 
            this.lTPanelMetersToolStripMenuItem.Name = "lTPanelMetersToolStripMenuItem";
            this.lTPanelMetersToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.lTPanelMetersToolStripMenuItem.Text = "LT Panel Meters";
            this.lTPanelMetersToolStripMenuItem.Click += new System.EventHandler(this.lTPanelMetersToolStripMenuItem_Click);
            // 
            // bILLMETERToolStripMenuItem
            // 
            this.bILLMETERToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mASTERBillMeterToolStripMenuItem,
            this.mONTHLYREADINGSToolStripMenuItem});
            this.bILLMETERToolStripMenuItem.Name = "bILLMETERToolStripMenuItem";
            this.bILLMETERToolStripMenuItem.Size = new System.Drawing.Size(100, 26);
            this.bILLMETERToolStripMenuItem.Tag = "MASTER";
            this.bILLMETERToolStripMenuItem.Text = "BILL METER";
            // 
            // mASTERBillMeterToolStripMenuItem
            // 
            this.mASTERBillMeterToolStripMenuItem.Name = "mASTERBillMeterToolStripMenuItem";
            this.mASTERBillMeterToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.mASTERBillMeterToolStripMenuItem.Tag = "BILL_METER_M";
            this.mASTERBillMeterToolStripMenuItem.Text = "MASTER";
            this.mASTERBillMeterToolStripMenuItem.Click += new System.EventHandler(this.bILLMETERToolStripMenuItem_Click);
            // 
            // mONTHLYREADINGSToolStripMenuItem
            // 
            this.mONTHLYREADINGSToolStripMenuItem.Name = "mONTHLYREADINGSToolStripMenuItem";
            this.mONTHLYREADINGSToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.mONTHLYREADINGSToolStripMenuItem.Tag = "MONTH_READ";
            this.mONTHLYREADINGSToolStripMenuItem.Text = "MONTHLY READINGS";
            this.mONTHLYREADINGSToolStripMenuItem.Click += new System.EventHandler(this.mONTHLYREADINGSToolStripMenuItem_Click);
            // 
            // mnuTransactions
            // 
            this.mnuTransactions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meterReadingsToolStripMenuItem,
            this.makeupRoomToolStripMenuItem,
            this.mnuTransOutdoor,
            this.toolStripSeparator2,
            this.toolStripMenuLTPanelReading});
            this.mnuTransactions.Name = "mnuTransactions";
            this.mnuTransactions.Size = new System.Drawing.Size(130, 26);
            this.mnuTransactions.Text = "TRANSACTIONS";
            // 
            // meterReadingsToolStripMenuItem
            // 
            this.meterReadingsToolStripMenuItem.Name = "meterReadingsToolStripMenuItem";
            this.meterReadingsToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.meterReadingsToolStripMenuItem.Tag = "ALL-METERS";
            this.meterReadingsToolStripMenuItem.Text = "Meter Readings";
            this.meterReadingsToolStripMenuItem.Click += new System.EventHandler(this.meterReadingsToolStripMenuItem_Click);
            // 
            // makeupRoomToolStripMenuItem
            // 
            this.makeupRoomToolStripMenuItem.Name = "makeupRoomToolStripMenuItem";
            this.makeupRoomToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.makeupRoomToolStripMenuItem.Tag = "ROOM-USAGE";
            this.makeupRoomToolStripMenuItem.Text = "Makeup Room";
            this.makeupRoomToolStripMenuItem.Click += new System.EventHandler(this.makeupRoomToolStripMenuItem_Click);
            // 
            // mnuTransOutdoor
            // 
            this.mnuTransOutdoor.Name = "mnuTransOutdoor";
            this.mnuTransOutdoor.Size = new System.Drawing.Size(210, 26);
            this.mnuTransOutdoor.Tag = "T_OUTDOOR";
            this.mnuTransOutdoor.Text = "Outdoor";
            this.mnuTransOutdoor.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // toolStripMenuLTPanelReading
            // 
            this.toolStripMenuLTPanelReading.Name = "toolStripMenuLTPanelReading";
            this.toolStripMenuLTPanelReading.Size = new System.Drawing.Size(210, 26);
            this.toolStripMenuLTPanelReading.Text = "LT Panel Readings";
            this.toolStripMenuLTPanelReading.Click += new System.EventHandler(this.toolStripMenuLTPanelReading_Click);
            // 
            // eleCalendarToolStripMenuItem
            // 
            this.eleCalendarToolStripMenuItem.Name = "eleCalendarToolStripMenuItem";
            this.eleCalendarToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.eleCalendarToolStripMenuItem.Tag = "ELEC-DASH";
            this.eleCalendarToolStripMenuItem.Text = "METER READING";
            this.eleCalendarToolStripMenuItem.Click += new System.EventHandler(this.eleCalendarToolStripMenuItem_Click);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTDSEntry,
            this.receiptEntryToolStripMenuItem,
            this.debtorReportsToolStripMenuItem,
            this.customerBookingsToolStripMenuItem});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(99, 26);
            this.accountsToolStripMenuItem.Text = "ACCOUNTS";
            this.accountsToolStripMenuItem.Visible = false;
            // 
            // mnuTDSEntry
            // 
            this.mnuTDSEntry.Enabled = false;
            this.mnuTDSEntry.Name = "mnuTDSEntry";
            this.mnuTDSEntry.Size = new System.Drawing.Size(220, 26);
            this.mnuTDSEntry.Tag = "A_TDS";
            this.mnuTDSEntry.Text = "TDS Entry";
            // 
            // receiptEntryToolStripMenuItem
            // 
            this.receiptEntryToolStripMenuItem.Name = "receiptEntryToolStripMenuItem";
            this.receiptEntryToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.receiptEntryToolStripMenuItem.Tag = "A_RECEIPT";
            this.receiptEntryToolStripMenuItem.Text = "Receipt Entry";
            // 
            // debtorReportsToolStripMenuItem
            // 
            this.debtorReportsToolStripMenuItem.Name = "debtorReportsToolStripMenuItem";
            this.debtorReportsToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.debtorReportsToolStripMenuItem.Tag = "A_DEBTOR";
            this.debtorReportsToolStripMenuItem.Text = "Debtor Reports";
            // 
            // customerBookingsToolStripMenuItem
            // 
            this.customerBookingsToolStripMenuItem.Name = "customerBookingsToolStripMenuItem";
            this.customerBookingsToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.customerBookingsToolStripMenuItem.Tag = "A_C_BOOKING";
            this.customerBookingsToolStripMenuItem.Text = "Customer Bookings";
            this.customerBookingsToolStripMenuItem.Click += new System.EventHandler(this.customerBookingsToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meterConsumptionsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(83, 26);
            this.reportsToolStripMenuItem.Tag = "REPORT-PH2";
            this.reportsToolStripMenuItem.Text = "REPORTS";
            // 
            // meterConsumptionsToolStripMenuItem
            // 
            this.meterConsumptionsToolStripMenuItem.Name = "meterConsumptionsToolStripMenuItem";
            this.meterConsumptionsToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.meterConsumptionsToolStripMenuItem.Tag = "REPORT-PH2";
            this.meterConsumptionsToolStripMenuItem.Text = "Meter Consumptions";
            this.meterConsumptionsToolStripMenuItem.Click += new System.EventHandler(this.meterConsumptionsToolStripMenuItem_Click);
            // 
            // mnuDashboard
            // 
            this.mnuDashboard.Name = "mnuDashboard";
            this.mnuDashboard.Size = new System.Drawing.Size(113, 26);
            this.mnuDashboard.Tag = "PH2-BOOK";
            this.mnuDashboard.Text = "DASHBOARD";
            this.mnuDashboard.Click += new System.EventHandler(this.mnuDashboard_Click);
            // 
            // mnuWindows
            // 
            this.mnuWindows.Name = "mnuWindows";
            this.mnuWindows.Size = new System.Drawing.Size(96, 26);
            this.mnuWindows.Text = "&WINDOWS";
            // 
            // mnuExit
            // 
            this.mnuExit.AutoSize = false;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.mnuExit.Size = new System.Drawing.Size(37, 20);
            this.mnuExit.Text = "E&XIT";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsUserName,
            this.statusRole});
            this.statusStrip.Location = new System.Drawing.Point(0, 567);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(975, 40);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // stsUserName
            // 
            this.stsUserName.Name = "stsUserName";
            this.stsUserName.Padding = new System.Windows.Forms.Padding(5);
            this.stsUserName.Size = new System.Drawing.Size(48, 34);
            this.stsUserName.Text = "User";
            // 
            // statusRole
            // 
            this.statusRole.Margin = new System.Windows.Forms.Padding(5);
            this.statusRole.Name = "statusRole";
            this.statusRole.Padding = new System.Windows.Forms.Padding(5);
            this.statusRole.Size = new System.Drawing.Size(49, 30);
            this.statusRole.Text = "Role";
            // 
            // mdiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 607);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "mdiMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ellora Studios: Facilities";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.mdiMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeupRoomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outdoorSetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuTransactions;
        private System.Windows.Forms.ToolStripMenuItem meterReadingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeupRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTDSEntry;
        private System.Windows.Forms.ToolStripMenuItem receiptEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debtorReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meterConsumptionsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel stsUserName;
        private System.Windows.Forms.ToolStripStatusLabel statusRole;
        private System.Windows.Forms.ToolStripMenuItem mnuTransOutdoor;
        private System.Windows.Forms.ToolStripMenuItem customerBookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDashboard;
        private System.Windows.Forms.ToolStripMenuItem eleCalendarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuWindows;
        private System.Windows.Forms.ToolStripMenuItem electricityMetersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bILLMETERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mASTERBillMeterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mONTHLYREADINGSToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuLTPanelReading;
        private System.Windows.Forms.ToolStripMenuItem lTPanelMetersToolStripMenuItem;
    }
}