namespace phase_2
{
    partial class frmMakeupRoom
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
            this.grdData = new Syncfusion.Windows.Forms.Grid.GridControl();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.grpEntry = new System.Windows.Forms.GroupBox();
            this.txtMakeupRoomId = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtRoomTo = new System.Windows.Forms.TextBox();
            this.txtRoomFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dbcActive = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dbcSet = new System.Windows.Forms.ComboBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoomDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMaster = new System.Windows.Forms.TabControl();
            this.tabList = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dbcMakeupRoomArea = new System.Windows.Forms.ComboBox();
            this.tabEntry = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.grpEntry.SuspendLayout();
            this.tabMaster.SuspendLayout();
            this.tabList.SuspendLayout();
            this.tabEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(94)))), ((int)(((byte)(171)))), ((int)(((byte)(222)))));
            this.grdData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grdData.ColCount = 6;
            this.grdData.DefaultGridBorderStyle = Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid;
            this.grdData.DefaultRowHeight = 20;
            this.grdData.Font = new System.Drawing.Font("Tahoma", 8.25F);
            gridCellInfo1.Col = -1;
            gridCellInfo1.Row = -1;
            gridCellInfo1.StyleInfo.Font.Bold = false;
            gridCellInfo1.StyleInfo.Font.Facename = "Tahoma";
            gridCellInfo1.StyleInfo.Font.Italic = false;
            gridCellInfo1.StyleInfo.Font.Size = 8.25F;
            gridCellInfo1.StyleInfo.Font.Strikeout = false;
            gridCellInfo1.StyleInfo.Font.Underline = false;
            gridCellInfo1.StyleInfo.Font.Unit = System.Drawing.GraphicsUnit.Point;
            this.grdData.GridCells.AddRange(new Syncfusion.Windows.Forms.Grid.GridCellInfo[] {
            gridCellInfo1});
            this.grdData.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro;
            this.grdData.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            this.grdData.Location = new System.Drawing.Point(25, 124);
            this.grdData.MetroScrollBars = true;
            this.grdData.Name = "grdData";
            this.grdData.Properties.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.grdData.RowCount = 0;
            this.grdData.RowHeightEntries.AddRange(new Syncfusion.Windows.Forms.Grid.GridRowHeight[] {
            new Syncfusion.Windows.Forms.Grid.GridRowHeight(0, 29)});
            this.grdData.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeIntoCode;
            this.grdData.Size = new System.Drawing.Size(796, 287);
            this.grdData.SmartSizeBox = false;
            this.grdData.TabIndex = 1;
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
            this.grdData.CellClick += new Syncfusion.Windows.Forms.Grid.GridCellClickEventHandler(this.grdData_CellClick);
            this.grdData.CellDoubleClick += new Syncfusion.Windows.Forms.Grid.GridCellClickEventHandler(this.grdData_CellDoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Gold;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(120, 288);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(215, 288);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(548, 58);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(87, 27);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "NEW";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            this.btnNew.MouseEnter += new System.EventHandler(this.btnEdit_MouseHover);
            this.btnNew.MouseLeave += new System.EventHandler(this.btnEdit_MouseLeave);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(455, 91);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 27);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnEdit.Enter += new System.EventHandler(this.btnEdit_MouseHover);
            this.btnEdit.Leave += new System.EventHandler(this.btnEdit_MouseLeave);
            this.btnEdit.MouseEnter += new System.EventHandler(this.btnEdit_MouseHover);
            this.btnEdit.MouseLeave += new System.EventHandler(this.btnEdit_MouseLeave);
            // 
            // grpEntry
            // 
            this.grpEntry.Controls.Add(this.txtMakeupRoomId);
            this.grpEntry.Controls.Add(this.lblTo);
            this.grpEntry.Controls.Add(this.lblFrom);
            this.grpEntry.Controls.Add(this.txtRoomTo);
            this.grpEntry.Controls.Add(this.txtRoomFrom);
            this.grpEntry.Controls.Add(this.label4);
            this.grpEntry.Controls.Add(this.dbcActive);
            this.grpEntry.Controls.Add(this.label3);
            this.grpEntry.Controls.Add(this.dbcSet);
            this.grpEntry.Controls.Add(this.txtLocation);
            this.grpEntry.Controls.Add(this.label2);
            this.grpEntry.Controls.Add(this.txtRoomDesc);
            this.grpEntry.Controls.Add(this.label1);
            this.grpEntry.Location = new System.Drawing.Point(20, 58);
            this.grpEntry.Name = "grpEntry";
            this.grpEntry.Size = new System.Drawing.Size(852, 224);
            this.grpEntry.TabIndex = 8;
            this.grpEntry.TabStop = false;
            // 
            // txtMakeupRoomId
            // 
            this.txtMakeupRoomId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMakeupRoomId.Location = new System.Drawing.Point(422, 114);
            this.txtMakeupRoomId.MaxLength = 150;
            this.txtMakeupRoomId.Name = "txtMakeupRoomId";
            this.txtMakeupRoomId.Size = new System.Drawing.Size(76, 23);
            this.txtMakeupRoomId.TabIndex = 12;
            this.txtMakeupRoomId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMakeupRoomId.Visible = false;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(279, 116);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(19, 15);
            this.lblTo.TabIndex = 11;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(82, 116);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(35, 15);
            this.lblFrom.TabIndex = 10;
            this.lblFrom.Text = "From";
            this.lblFrom.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtRoomTo
            // 
            this.txtRoomTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoomTo.Location = new System.Drawing.Point(320, 114);
            this.txtRoomTo.MaxLength = 150;
            this.txtRoomTo.Name = "txtRoomTo";
            this.txtRoomTo.Size = new System.Drawing.Size(76, 23);
            this.txtRoomTo.TabIndex = 9;
            this.txtRoomTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRoomTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoomTo_KeyPress);
            // 
            // txtRoomFrom
            // 
            this.txtRoomFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoomFrom.Location = new System.Drawing.Point(148, 114);
            this.txtRoomFrom.MaxLength = 150;
            this.txtRoomFrom.Name = "txtRoomFrom";
            this.txtRoomFrom.Size = new System.Drawing.Size(76, 23);
            this.txtRoomFrom.TabIndex = 8;
            this.txtRoomFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRoomFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoomFrom_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Active";
            // 
            // dbcActive
            // 
            this.dbcActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbcActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbcActive.FormattingEnabled = true;
            this.dbcActive.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.dbcActive.Location = new System.Drawing.Point(148, 167);
            this.dbcActive.Name = "dbcActive";
            this.dbcActive.Size = new System.Drawing.Size(76, 23);
            this.dbcActive.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Set Name";
            // 
            // dbcSet
            // 
            this.dbcSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbcSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbcSet.FormattingEnabled = true;
            this.dbcSet.Location = new System.Drawing.Point(148, 67);
            this.dbcSet.Name = "dbcSet";
            this.dbcSet.Size = new System.Drawing.Size(248, 23);
            this.dbcSet.TabIndex = 4;
            // 
            // txtLocation
            // 
            this.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocation.Location = new System.Drawing.Point(338, 184);
            this.txtLocation.MaxLength = 150;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(430, 23);
            this.txtLocation.TabIndex = 3;
            this.txtLocation.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Location";
            this.label2.Visible = false;
            // 
            // txtRoomDesc
            // 
            this.txtRoomDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoomDesc.Location = new System.Drawing.Point(148, 22);
            this.txtRoomDesc.MaxLength = 150;
            this.txtRoomDesc.Name = "txtRoomDesc";
            this.txtRoomDesc.Size = new System.Drawing.Size(430, 23);
            this.txtRoomDesc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Makeup Room No";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabMaster
            // 
            this.tabMaster.Controls.Add(this.tabList);
            this.tabMaster.Controls.Add(this.tabEntry);
            this.tabMaster.Location = new System.Drawing.Point(26, 27);
            this.tabMaster.Name = "tabMaster";
            this.tabMaster.SelectedIndex = 0;
            this.tabMaster.Size = new System.Drawing.Size(848, 467);
            this.tabMaster.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMaster.TabIndex = 9;
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.label5);
            this.tabList.Controls.Add(this.btnSelect);
            this.tabList.Controls.Add(this.dbcMakeupRoomArea);
            this.tabList.Controls.Add(this.grdData);
            this.tabList.Controls.Add(this.btnEdit);
            this.tabList.Controls.Add(this.btnNew);
            this.tabList.Location = new System.Drawing.Point(4, 24);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(840, 439);
            this.tabList.TabIndex = 0;
            this.tabList.Text = "LIST";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Makeup Room List";
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Location = new System.Drawing.Point(455, 58);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(87, 27);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "SELECT";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dbcMakeupRoomArea
            // 
            this.dbcMakeupRoomArea.FormattingEnabled = true;
            this.dbcMakeupRoomArea.Location = new System.Drawing.Point(129, 61);
            this.dbcMakeupRoomArea.Name = "dbcMakeupRoomArea";
            this.dbcMakeupRoomArea.Size = new System.Drawing.Size(320, 23);
            this.dbcMakeupRoomArea.TabIndex = 4;
            this.dbcMakeupRoomArea.SelectionChangeCommitted += new System.EventHandler(this.dbcMakeupRoomArea_SelectionChangeCommitted);
            // 
            // tabEntry
            // 
            this.tabEntry.Controls.Add(this.btnSave);
            this.tabEntry.Controls.Add(this.grpEntry);
            this.tabEntry.Controls.Add(this.btnCancel);
            this.tabEntry.Location = new System.Drawing.Point(4, 24);
            this.tabEntry.Name = "tabEntry";
            this.tabEntry.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntry.Size = new System.Drawing.Size(840, 439);
            this.tabEntry.TabIndex = 1;
            this.tabEntry.Text = "ADD / EDIT";
            this.tabEntry.UseVisualStyleBackColor = true;
            // 
            // frmMakeupRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 665);
            this.Controls.Add(this.tabMaster);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMakeupRoom";
            this.Tag = "MAST-MAKEUPROOM";
            this.Text = "MakeupRoom Master";
            this.Load += new System.EventHandler(this.frmMakeupRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.grpEntry.ResumeLayout(false);
            this.grpEntry.PerformLayout();
            this.tabMaster.ResumeLayout(false);
            this.tabList.ResumeLayout(false);
            this.tabList.PerformLayout();
            this.tabEntry.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Grid.GridControl grdData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox grpEntry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dbcActive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dbcSet;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRoomDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabMaster;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.TabPage tabEntry;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtRoomTo;
        private System.Windows.Forms.TextBox txtRoomFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ComboBox dbcMakeupRoomArea;
        private System.Windows.Forms.TextBox txtMakeupRoomId;
        private System.Windows.Forms.Label label5;
    }
}