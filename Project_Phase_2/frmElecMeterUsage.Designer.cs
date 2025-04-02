
namespace phase_2
{
    partial class frmElecMeterUsage
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
            this.tabMaster = new System.Windows.Forms.TabControl();
            this.tabList = new System.Windows.Forms.TabPage();
            this.btnNew = new System.Windows.Forms.Button();
            this.grdData = new Syncfusion.Windows.Forms.Grid.GridControl();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tabEntry = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpEntry = new System.Windows.Forms.GroupBox();
            this.txtShortCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtParent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dbcisRevenue = new System.Windows.Forms.ComboBox();
            this.txtSetMeterID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dbcActive = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dbcUsageType = new System.Windows.Forms.ComboBox();
            this.txtMeterUsage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabMaster.SuspendLayout();
            this.tabList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.tabEntry.SuspendLayout();
            this.grpEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMaster
            // 
            this.tabMaster.Controls.Add(this.tabList);
            this.tabMaster.Controls.Add(this.tabEntry);
            this.tabMaster.Location = new System.Drawing.Point(9, 9);
            this.tabMaster.Name = "tabMaster";
            this.tabMaster.SelectedIndex = 0;
            this.tabMaster.Size = new System.Drawing.Size(923, 690);
            this.tabMaster.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMaster.TabIndex = 0;
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.btnNew);
            this.tabList.Controls.Add(this.grdData);
            this.tabList.Controls.Add(this.btnEdit);
            this.tabList.Location = new System.Drawing.Point(4, 24);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(915, 662);
            this.tabList.TabIndex = 0;
            this.tabList.Text = "LIST";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(24, 22);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(87, 27);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "NEW";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // grdData
            // 
            this.grdData.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.None;
            this.grdData.AllowSelection = ((Syncfusion.Windows.Forms.Grid.GridSelectionFlags)(((Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Row | Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Keyboard) 
            | Syncfusion.Windows.Forms.Grid.GridSelectionFlags.AlphaBlend)));
            this.grdData.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(94)))), ((int)(((byte)(171)))), ((int)(((byte)(222)))));
            this.grdData.ColCount = 5;
            this.grdData.DefaultGridBorderStyle = Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid;
            this.grdData.DefaultRowHeight = 20;
            this.grdData.EnterKeyBehavior = Syncfusion.Windows.Forms.Grid.GridDirectionType.Down;
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
            this.grdData.Location = new System.Drawing.Point(24, 66);
            this.grdData.MetroScrollBars = true;
            this.grdData.Name = "grdData";
            this.grdData.Properties.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.grdData.ReadOnly = true;
            this.grdData.RowHeightEntries.AddRange(new Syncfusion.Windows.Forms.Grid.GridRowHeight[] {
            new Syncfusion.Windows.Forms.Grid.GridRowHeight(0, 29)});
            this.grdData.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeIntoCode;
            this.grdData.Size = new System.Drawing.Size(864, 572);
            this.grdData.SmartSizeBox = false;
            this.grdData.TabIndex = 0;
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
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(119, 22);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 27);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tabEntry
            // 
            this.tabEntry.Controls.Add(this.btnSave);
            this.tabEntry.Controls.Add(this.grpEntry);
            this.tabEntry.Controls.Add(this.btnCancel);
            this.tabEntry.Location = new System.Drawing.Point(4, 24);
            this.tabEntry.Name = "tabEntry";
            this.tabEntry.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntry.Size = new System.Drawing.Size(915, 662);
            this.tabEntry.TabIndex = 1;
            this.tabEntry.Text = "ADD / EDIT";
            this.tabEntry.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Gold;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(245, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpEntry
            // 
            this.grpEntry.Controls.Add(this.txtShortCode);
            this.grpEntry.Controls.Add(this.label5);
            this.grpEntry.Controls.Add(this.txtParent);
            this.grpEntry.Controls.Add(this.label2);
            this.grpEntry.Controls.Add(this.dbcisRevenue);
            this.grpEntry.Controls.Add(this.txtSetMeterID);
            this.grpEntry.Controls.Add(this.label4);
            this.grpEntry.Controls.Add(this.dbcActive);
            this.grpEntry.Controls.Add(this.label3);
            this.grpEntry.Controls.Add(this.dbcUsageType);
            this.grpEntry.Controls.Add(this.txtMeterUsage);
            this.grpEntry.Controls.Add(this.label1);
            this.grpEntry.Location = new System.Drawing.Point(31, 48);
            this.grpEntry.Name = "grpEntry";
            this.grpEntry.Size = new System.Drawing.Size(852, 360);
            this.grpEntry.TabIndex = 0;
            this.grpEntry.TabStop = false;
            // 
            // txtShortCode
            // 
            this.txtShortCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShortCode.Location = new System.Drawing.Point(147, 99);
            this.txtShortCode.MaxLength = 150;
            this.txtShortCode.Name = "txtShortCode";
            this.txtShortCode.Size = new System.Drawing.Size(112, 23);
            this.txtShortCode.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Short Code";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtParent
            // 
            this.txtParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParent.Location = new System.Drawing.Point(279, 141);
            this.txtParent.MaxLength = 150;
            this.txtParent.Name = "txtParent";
            this.txtParent.Size = new System.Drawing.Size(77, 23);
            this.txtParent.TabIndex = 21;
            this.txtParent.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Billed to Production";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dbcisRevenue
            // 
            this.dbcisRevenue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbcisRevenue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbcisRevenue.FormattingEnabled = true;
            this.dbcisRevenue.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.dbcisRevenue.Location = new System.Drawing.Point(147, 139);
            this.dbcisRevenue.Name = "dbcisRevenue";
            this.dbcisRevenue.Size = new System.Drawing.Size(112, 23);
            this.dbcisRevenue.TabIndex = 3;
            // 
            // txtSetMeterID
            // 
            this.txtSetMeterID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSetMeterID.Location = new System.Drawing.Point(614, 24);
            this.txtSetMeterID.MaxLength = 150;
            this.txtSetMeterID.Name = "txtSetMeterID";
            this.txtSetMeterID.Size = new System.Drawing.Size(77, 23);
            this.txtSetMeterID.TabIndex = 18;
            this.txtSetMeterID.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Active";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // dbcActive
            // 
            this.dbcActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbcActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbcActive.FormattingEnabled = true;
            this.dbcActive.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.dbcActive.Location = new System.Drawing.Point(147, 182);
            this.dbcActive.Name = "dbcActive";
            this.dbcActive.Size = new System.Drawing.Size(112, 23);
            this.dbcActive.TabIndex = 7;
            this.dbcActive.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Usage Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dbcUsageType
            // 
            this.dbcUsageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbcUsageType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbcUsageType.FormattingEnabled = true;
            this.dbcUsageType.Location = new System.Drawing.Point(147, 29);
            this.dbcUsageType.Name = "dbcUsageType";
            this.dbcUsageType.Size = new System.Drawing.Size(248, 23);
            this.dbcUsageType.TabIndex = 0;
            this.dbcUsageType.SelectedIndexChanged += new System.EventHandler(this.dbcUsageType_SelectedIndexChanged);
            // 
            // txtMeterUsage
            // 
            this.txtMeterUsage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMeterUsage.Location = new System.Drawing.Point(147, 70);
            this.txtMeterUsage.MaxLength = 150;
            this.txtMeterUsage.Name = "txtMeterUsage";
            this.txtMeterUsage.Size = new System.Drawing.Size(430, 23);
            this.txtMeterUsage.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usage Description";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(339, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "CANC&EL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmElecMeterUsage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 717);
            this.Controls.Add(this.tabMaster);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmElecMeterUsage";
            this.Tag = "USAGE-TYPE";
            this.Text = "Meter Usage";
            this.Load += new System.EventHandler(this.frmElecMeterUsage_Load);
            this.tabMaster.ResumeLayout(false);
            this.tabList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.tabEntry.ResumeLayout(false);
            this.grpEntry.ResumeLayout(false);
            this.grpEntry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMaster;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.Button btnNew;
        private Syncfusion.Windows.Forms.Grid.GridControl grdData;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TabPage tabEntry;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpEntry;
        private System.Windows.Forms.TextBox txtSetMeterID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dbcActive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dbcUsageType;
        private System.Windows.Forms.TextBox txtMeterUsage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dbcisRevenue;
        private System.Windows.Forms.TextBox txtParent;
        private System.Windows.Forms.TextBox txtShortCode;
        private System.Windows.Forms.Label label5;
    }
}