namespace phase_2
{
    partial class frmLTPanelMaster
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
            Syncfusion.Windows.Forms.Grid.GridCellInfo gridCellInfo2 = new Syncfusion.Windows.Forms.Grid.GridCellInfo();
            this.grdData = new Syncfusion.Windows.Forms.Grid.GridControl();
            this.grpEntry = new System.Windows.Forms.GroupBox();
            this.pnlLT = new System.Windows.Forms.Panel();
            this.lblLTToDate = new System.Windows.Forms.Label();
            this.dtpLTToDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpLTFromDate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.dbcLTActive = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLTFactor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLTOpening = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dbcLocation = new System.Windows.Forms.ComboBox();
            this.txtSetMeterID = new System.Windows.Forms.TextBox();
            this.txtMeterNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMeterName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabMaster = new System.Windows.Forms.TabControl();
            this.tabList = new System.Windows.Forms.TabPage();
            this.btnReplace = new System.Windows.Forms.Button();
            this.tabEntry = new System.Windows.Forms.TabPage();
            this.tabMap = new System.Windows.Forms.TabPage();
            this.lsvSetMaster = new System.Windows.Forms.ListView();
            this.clmLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPanel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.setID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SetName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.trvMapping = new System.Windows.Forms.TreeView();
            this.tabSeq = new System.Windows.Forms.TabPage();
            this.btnAPPLY = new System.Windows.Forms.Button();
            this.btnDN = new System.Windows.Forms.Button();
            this.btnUP = new System.Windows.Forms.Button();
            this.lsvSequence = new System.Windows.Forms.ListView();
            this.colSrlID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSetMeterId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMeterName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSerial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.grpEntry.SuspendLayout();
            this.pnlLT.SuspendLayout();
            this.tabMaster.SuspendLayout();
            this.tabList.SuspendLayout();
            this.tabEntry.SuspendLayout();
            this.tabMap.SuspendLayout();
            this.tabSeq.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.AllowSelection = ((Syncfusion.Windows.Forms.Grid.GridSelectionFlags)(((Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Row | Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Keyboard) 
            | Syncfusion.Windows.Forms.Grid.GridSelectionFlags.AlphaBlend)));
            this.grdData.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(94)))), ((int)(((byte)(171)))), ((int)(((byte)(222)))));
            this.grdData.DefaultGridBorderStyle = Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid;
            this.grdData.DefaultRowHeight = 20;
            this.grdData.EnterKeyBehavior = Syncfusion.Windows.Forms.Grid.GridDirectionType.Down;
            this.grdData.Font = new System.Drawing.Font("Tahoma", 8.25F);
            gridCellInfo2.Col = -1;
            gridCellInfo2.Row = -1;
            gridCellInfo2.StyleInfo.Font.Bold = false;
            gridCellInfo2.StyleInfo.Font.Facename = "Tahoma";
            gridCellInfo2.StyleInfo.Font.Italic = false;
            gridCellInfo2.StyleInfo.Font.Size = 8.25F;
            gridCellInfo2.StyleInfo.Font.Strikeout = false;
            gridCellInfo2.StyleInfo.Font.Underline = false;
            gridCellInfo2.StyleInfo.Font.Unit = System.Drawing.GraphicsUnit.Point;
            this.grdData.GridCells.AddRange(new Syncfusion.Windows.Forms.Grid.GridCellInfo[] {
            gridCellInfo2});
            this.grdData.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro;
            this.grdData.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            this.grdData.Location = new System.Drawing.Point(21, 66);
            this.grdData.MetroScrollBars = true;
            this.grdData.Name = "grdData";
            this.grdData.Properties.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.grdData.ReadOnly = true;
            this.grdData.RowHeightEntries.AddRange(new Syncfusion.Windows.Forms.Grid.GridRowHeight[] {
            new Syncfusion.Windows.Forms.Grid.GridRowHeight(0, 29)});
            this.grdData.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeIntoCode;
            this.grdData.Size = new System.Drawing.Size(741, 487);
            this.grdData.SmartSizeBox = false;
            this.grdData.TabIndex = 3;
            this.grdData.Text = "grdData";
            this.grdData.ThemeName = "Metro";
            this.grdData.ThemesEnabled = true;
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonDisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonDisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonPressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ArrowButtonPressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ThumbBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ThumbDisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ThumbDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ThumbHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ThumbHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ThumbPressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.grdData.ThemeStyle.HorizontalScrollBarStyle.ThumbPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ArrowButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ArrowButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ArrowButtonDisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ArrowButtonDisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ArrowButtonHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ArrowButtonHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ArrowButtonPressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ArrowButtonPressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ThumbBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ThumbDisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ThumbDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ThumbHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ThumbHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ThumbPressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.grdData.ThemeStyle.VerticalScrollBarStyle.ThumbPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.grdData.UseRightToLeftCompatibleTextBox = true;
            this.grdData.CellDoubleClick += new Syncfusion.Windows.Forms.Grid.GridCellClickEventHandler(this.grdData_CellDoubleClick);
            // 
            // grpEntry
            // 
            this.grpEntry.Controls.Add(this.pnlLT);
            this.grpEntry.Controls.Add(this.label9);
            this.grpEntry.Controls.Add(this.dbcLocation);
            this.grpEntry.Controls.Add(this.txtSetMeterID);
            this.grpEntry.Controls.Add(this.txtMeterNo);
            this.grpEntry.Controls.Add(this.label2);
            this.grpEntry.Controls.Add(this.txtMeterName);
            this.grpEntry.Controls.Add(this.label1);
            this.grpEntry.Location = new System.Drawing.Point(27, 42);
            this.grpEntry.Name = "grpEntry";
            this.grpEntry.Size = new System.Drawing.Size(730, 348);
            this.grpEntry.TabIndex = 0;
            this.grpEntry.TabStop = false;
            this.grpEntry.Enter += new System.EventHandler(this.grpEntry_Enter);
            // 
            // pnlLT
            // 
            this.pnlLT.Controls.Add(this.lblLTToDate);
            this.pnlLT.Controls.Add(this.dtpLTToDate);
            this.pnlLT.Controls.Add(this.label14);
            this.pnlLT.Controls.Add(this.dtpLTFromDate);
            this.pnlLT.Controls.Add(this.label15);
            this.pnlLT.Controls.Add(this.dbcLTActive);
            this.pnlLT.Controls.Add(this.label12);
            this.pnlLT.Controls.Add(this.txtLTFactor);
            this.pnlLT.Controls.Add(this.label10);
            this.pnlLT.Controls.Add(this.txtLTOpening);
            this.pnlLT.Controls.Add(this.label11);
            this.pnlLT.Location = new System.Drawing.Point(126, 121);
            this.pnlLT.Name = "pnlLT";
            this.pnlLT.Size = new System.Drawing.Size(261, 190);
            this.pnlLT.TabIndex = 21;
            // 
            // lblLTToDate
            // 
            this.lblLTToDate.AutoSize = true;
            this.lblLTToDate.Location = new System.Drawing.Point(76, 161);
            this.lblLTToDate.Name = "lblLTToDate";
            this.lblLTToDate.Size = new System.Drawing.Size(61, 20);
            this.lblLTToDate.TabIndex = 23;
            this.lblLTToDate.Text = "To Date";
            this.lblLTToDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpLTToDate
            // 
            this.dtpLTToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpLTToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLTToDate.Location = new System.Drawing.Point(148, 155);
            this.dtpLTToDate.Name = "dtpLTToDate";
            this.dtpLTToDate.Size = new System.Drawing.Size(96, 27);
            this.dtpLTToDate.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(58, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 20);
            this.label14.TabIndex = 22;
            this.label14.Text = "From Date";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpLTFromDate
            // 
            this.dtpLTFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpLTFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLTFromDate.Location = new System.Drawing.Point(148, 97);
            this.dtpLTFromDate.Name = "dtpLTFromDate";
            this.dtpLTFromDate.Size = new System.Drawing.Size(96, 27);
            this.dtpLTFromDate.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(87, 129);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 20);
            this.label15.TabIndex = 19;
            this.label15.Text = "Active";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dbcLTActive
            // 
            this.dbcLTActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbcLTActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbcLTActive.FormattingEnabled = true;
            this.dbcLTActive.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.dbcLTActive.Location = new System.Drawing.Point(147, 126);
            this.dbcLTActive.Name = "dbcLTActive";
            this.dbcLTActive.Size = new System.Drawing.Size(97, 28);
            this.dbcLTActive.TabIndex = 20;
            this.dbcLTActive.SelectedIndexChanged += new System.EventHandler(this.dbcLTActive_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(261, 20);
            this.label12.TabIndex = 17;
            this.label12.Text = "LT PANEL";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLTFactor
            // 
            this.txtLTFactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLTFactor.Location = new System.Drawing.Point(152, 58);
            this.txtLTFactor.MaxLength = 150;
            this.txtLTFactor.Name = "txtLTFactor";
            this.txtLTFactor.Size = new System.Drawing.Size(66, 27);
            this.txtLTFactor.TabIndex = 14;
            this.txtLTFactor.Text = "1";
            this.txtLTFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLTFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOpening_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "Multiplying Factor";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLTOpening
            // 
            this.txtLTOpening.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLTOpening.Location = new System.Drawing.Point(152, 29);
            this.txtLTOpening.MaxLength = 15;
            this.txtLTOpening.Name = "txtLTOpening";
            this.txtLTOpening.Size = new System.Drawing.Size(66, 27);
            this.txtLTOpening.TabIndex = 13;
            this.txtLTOpening.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLTOpening.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOpening_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "Opening Reading";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Location Name";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dbcLocation
            // 
            this.dbcLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbcLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbcLocation.FormattingEnabled = true;
            this.dbcLocation.Location = new System.Drawing.Point(126, 28);
            this.dbcLocation.Name = "dbcLocation";
            this.dbcLocation.Size = new System.Drawing.Size(213, 28);
            this.dbcLocation.TabIndex = 0;
            // 
            // txtSetMeterID
            // 
            this.txtSetMeterID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSetMeterID.Location = new System.Drawing.Point(526, 21);
            this.txtSetMeterID.MaxLength = 150;
            this.txtSetMeterID.Name = "txtSetMeterID";
            this.txtSetMeterID.Size = new System.Drawing.Size(66, 27);
            this.txtSetMeterID.TabIndex = 18;
            this.txtSetMeterID.Visible = false;
            // 
            // txtMeterNo
            // 
            this.txtMeterNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMeterNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMeterNo.Location = new System.Drawing.Point(126, 86);
            this.txtMeterNo.MaxLength = 25;
            this.txtMeterNo.Name = "txtMeterNo";
            this.txtMeterNo.Size = new System.Drawing.Size(213, 27);
            this.txtMeterNo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Meter Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMeterName
            // 
            this.txtMeterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMeterName.Location = new System.Drawing.Point(126, 57);
            this.txtMeterName.MaxLength = 150;
            this.txtMeterName.Name = "txtMeterName";
            this.txtMeterName.Size = new System.Drawing.Size(369, 27);
            this.txtMeterName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Meter Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnNew
            // 
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(21, 16);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 36);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "NEW";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(102, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 36);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Gold;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(210, 396);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(291, 396);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "CANC&EL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabMaster
            // 
            this.tabMaster.Controls.Add(this.tabList);
            this.tabMaster.Controls.Add(this.tabEntry);
            this.tabMaster.Controls.Add(this.tabMap);
            this.tabMaster.Controls.Add(this.tabSeq);
            this.tabMaster.Location = new System.Drawing.Point(24, 12);
            this.tabMaster.Name = "tabMaster";
            this.tabMaster.SelectedIndex = 0;
            this.tabMaster.Size = new System.Drawing.Size(856, 598);
            this.tabMaster.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMaster.TabIndex = 0;
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.btnReplace);
            this.tabList.Controls.Add(this.btnNew);
            this.tabList.Controls.Add(this.grdData);
            this.tabList.Controls.Add(this.btnEdit);
            this.tabList.Location = new System.Drawing.Point(4, 29);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(848, 565);
            this.tabList.TabIndex = 0;
            this.tabList.Text = "LIST";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // btnReplace
            // 
            this.btnReplace.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplace.Location = new System.Drawing.Point(183, 16);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 36);
            this.btnReplace.TabIndex = 2;
            this.btnReplace.Text = "REPLACE";
            this.btnReplace.UseVisualStyleBackColor = false;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // tabEntry
            // 
            this.tabEntry.Controls.Add(this.btnSave);
            this.tabEntry.Controls.Add(this.grpEntry);
            this.tabEntry.Controls.Add(this.btnCancel);
            this.tabEntry.Location = new System.Drawing.Point(4, 29);
            this.tabEntry.Name = "tabEntry";
            this.tabEntry.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntry.Size = new System.Drawing.Size(848, 565);
            this.tabEntry.TabIndex = 1;
            this.tabEntry.Text = "ADD / EDIT";
            this.tabEntry.UseVisualStyleBackColor = true;
            // 
            // tabMap
            // 
            this.tabMap.Controls.Add(this.lsvSetMaster);
            this.tabMap.Controls.Add(this.btnAdd);
            this.tabMap.Controls.Add(this.btnRemove);
            this.tabMap.Controls.Add(this.trvMapping);
            this.tabMap.Location = new System.Drawing.Point(4, 29);
            this.tabMap.Name = "tabMap";
            this.tabMap.Size = new System.Drawing.Size(848, 565);
            this.tabMap.TabIndex = 2;
            this.tabMap.Text = "MAPPINGS";
            this.tabMap.UseVisualStyleBackColor = true;
            this.tabMap.Click += new System.EventHandler(this.tabMap_Click);
            // 
            // lsvSetMaster
            // 
            this.lsvSetMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvSetMaster.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmLocation,
            this.clmPanel,
            this.setID,
            this.SetName});
            this.lsvSetMaster.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvSetMaster.FullRowSelect = true;
            this.lsvSetMaster.GridLines = true;
            this.lsvSetMaster.HideSelection = false;
            this.lsvSetMaster.Location = new System.Drawing.Point(483, 165);
            this.lsvSetMaster.MultiSelect = false;
            this.lsvSetMaster.Name = "lsvSetMaster";
            this.lsvSetMaster.Size = new System.Drawing.Size(312, 260);
            this.lsvSetMaster.TabIndex = 3;
            this.lsvSetMaster.UseCompatibleStateImageBehavior = false;
            this.lsvSetMaster.View = System.Windows.Forms.View.Details;
            // 
            // clmLocation
            // 
            this.clmLocation.DisplayIndex = 2;
            this.clmLocation.Text = "SetId";
            this.clmLocation.Width = 0;
            // 
            // clmPanel
            // 
            this.clmPanel.DisplayIndex = 3;
            this.clmPanel.Text = "SetName";
            this.clmPanel.Width = 240;
            // 
            // setID
            // 
            this.setID.DisplayIndex = 0;
            this.setID.Text = "LocationId";
            this.setID.Width = 0;
            // 
            // SetName
            // 
            this.SetName.DisplayIndex = 1;
            this.SetName.Text = "PanelId";
            this.SetName.Width = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(415, 305);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 33);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "<<";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(415, 255);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(56, 33);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = ">>";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // trvMapping
            // 
            this.trvMapping.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvMapping.Location = new System.Drawing.Point(19, 41);
            this.trvMapping.Name = "trvMapping";
            this.trvMapping.Size = new System.Drawing.Size(386, 509);
            this.trvMapping.TabIndex = 0;
            // 
            // tabSeq
            // 
            this.tabSeq.Controls.Add(this.btnAPPLY);
            this.tabSeq.Controls.Add(this.btnDN);
            this.tabSeq.Controls.Add(this.btnUP);
            this.tabSeq.Controls.Add(this.lsvSequence);
            this.tabSeq.Location = new System.Drawing.Point(4, 29);
            this.tabSeq.Name = "tabSeq";
            this.tabSeq.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeq.Size = new System.Drawing.Size(848, 565);
            this.tabSeq.TabIndex = 3;
            this.tabSeq.Text = "SEQUENCE";
            this.tabSeq.UseVisualStyleBackColor = true;
            // 
            // btnAPPLY
            // 
            this.btnAPPLY.Location = new System.Drawing.Point(644, 454);
            this.btnAPPLY.Name = "btnAPPLY";
            this.btnAPPLY.Size = new System.Drawing.Size(75, 36);
            this.btnAPPLY.TabIndex = 7;
            this.btnAPPLY.Text = "APPLY";
            this.btnAPPLY.UseVisualStyleBackColor = true;
            this.btnAPPLY.Click += new System.EventHandler(this.btnAPPLY_Click);
            // 
            // btnDN
            // 
            this.btnDN.Location = new System.Drawing.Point(637, 256);
            this.btnDN.Name = "btnDN";
            this.btnDN.Size = new System.Drawing.Size(75, 36);
            this.btnDN.TabIndex = 6;
            this.btnDN.Text = "DOWN";
            this.btnDN.UseVisualStyleBackColor = true;
            this.btnDN.Click += new System.EventHandler(this.btnDN_Click);
            // 
            // btnUP
            // 
            this.btnUP.Location = new System.Drawing.Point(637, 28);
            this.btnUP.Name = "btnUP";
            this.btnUP.Size = new System.Drawing.Size(75, 36);
            this.btnUP.TabIndex = 5;
            this.btnUP.Text = "UP";
            this.btnUP.UseVisualStyleBackColor = true;
            this.btnUP.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // lsvSequence
            // 
            this.lsvSequence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvSequence.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSrlID,
            this.colType,
            this.colSetMeterId,
            this.colMeterName,
            this.colSerial});
            this.lsvSequence.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvSequence.FullRowSelect = true;
            this.lsvSequence.GridLines = true;
            this.lsvSequence.HideSelection = false;
            this.lsvSequence.Location = new System.Drawing.Point(60, 20);
            this.lsvSequence.MultiSelect = false;
            this.lsvSequence.Name = "lsvSequence";
            this.lsvSequence.Size = new System.Drawing.Size(540, 480);
            this.lsvSequence.TabIndex = 4;
            this.lsvSequence.UseCompatibleStateImageBehavior = false;
            this.lsvSequence.View = System.Windows.Forms.View.Details;
            // 
            // colSrlID
            // 
            this.colSrlID.Text = "SrlID";
            this.colSrlID.Width = 0;
            // 
            // colType
            // 
            this.colType.Text = "Meter Type";
            this.colType.Width = 120;
            // 
            // colSetMeterId
            // 
            this.colSetMeterId.Text = "SetMeterId";
            this.colSetMeterId.Width = 0;
            // 
            // colMeterName
            // 
            this.colMeterName.Text = "Meter Name";
            this.colMeterName.Width = 240;
            // 
            // colSerial
            // 
            this.colSerial.Text = "Serial";
            // 
            // frmLTPanelMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 622);
            this.Controls.Add(this.tabMaster);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmLTPanelMaster";
            this.Tag = "MAST-METER";
            this.Text = "LT PANEL";
            this.Load += new System.EventHandler(this.frmMeterMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.grpEntry.ResumeLayout(false);
            this.grpEntry.PerformLayout();
            this.pnlLT.ResumeLayout(false);
            this.pnlLT.PerformLayout();
            this.tabMaster.ResumeLayout(false);
            this.tabList.ResumeLayout(false);
            this.tabEntry.ResumeLayout(false);
            this.tabMap.ResumeLayout(false);
            this.tabSeq.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Grid.GridControl grdData;
        private System.Windows.Forms.GroupBox grpEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMeterNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMeterName;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabMaster;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.TabPage tabEntry;
        private System.Windows.Forms.TextBox txtSetMeterID;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox dbcLocation;
        private System.Windows.Forms.Panel pnlLT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLTFactor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLTOpening;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblLTToDate;
        private System.Windows.Forms.DateTimePicker dtpLTToDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpLTFromDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox dbcLTActive;
        private System.Windows.Forms.TabPage tabMap;
        private System.Windows.Forms.TreeView trvMapping;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListView lsvSetMaster;
        private System.Windows.Forms.ColumnHeader setID;
        private System.Windows.Forms.ColumnHeader SetName;
        private System.Windows.Forms.ColumnHeader clmLocation;
        private System.Windows.Forms.ColumnHeader clmPanel;
        private System.Windows.Forms.TabPage tabSeq;
        private System.Windows.Forms.Button btnDN;
        private System.Windows.Forms.Button btnUP;
        private System.Windows.Forms.ListView lsvSequence;
        private System.Windows.Forms.ColumnHeader colSrlID;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colSetMeterId;
        private System.Windows.Forms.Button btnAPPLY;
        private System.Windows.Forms.ColumnHeader colMeterName;
        private System.Windows.Forms.ColumnHeader colSerial;
    }
}