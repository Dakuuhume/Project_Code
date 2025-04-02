
namespace phase_2
{
    partial class frmBillEntry
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
            this.grpEntry = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpBillMonth = new System.Windows.Forms.DateTimePicker();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSetMeterID = new System.Windows.Forms.TextBox();
            this.lblMeterSeleted = new System.Windows.Forms.Label();
            this.btnEntryCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnitFrom = new System.Windows.Forms.TextBox();
            this.txtUnitTo = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.RichTextBox();
            this.txtRwNo = new System.Windows.Forms.TextBox();
            this.cmdApply = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMultiplier = new System.Windows.Forms.TextBox();
            this.grpEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpEntry
            // 
            this.grpEntry.BackColor = System.Drawing.Color.GhostWhite;
            this.grpEntry.Controls.Add(this.txtMultiplier);
            this.grpEntry.Controls.Add(this.label3);
            this.grpEntry.Controls.Add(this.label2);
            this.grpEntry.Controls.Add(this.label1);
            this.grpEntry.Controls.Add(this.dtpToDate);
            this.grpEntry.Controls.Add(this.dtpFromDate);
            this.grpEntry.Controls.Add(this.dtpBillMonth);
            this.grpEntry.Controls.Add(this.btnChange);
            this.grpEntry.Controls.Add(this.btnUpdate);
            this.grpEntry.Controls.Add(this.btnDelete);
            this.grpEntry.Controls.Add(this.txtSetMeterID);
            this.grpEntry.Controls.Add(this.lblMeterSeleted);
            this.grpEntry.Controls.Add(this.btnEntryCancel);
            this.grpEntry.Controls.Add(this.label5);
            this.grpEntry.Controls.Add(this.txtUnitFrom);
            this.grpEntry.Controls.Add(this.txtUnitTo);
            this.grpEntry.Controls.Add(this.label22);
            this.grpEntry.Controls.Add(this.label21);
            this.grpEntry.Controls.Add(this.txtQty);
            this.grpEntry.Controls.Add(this.lblQty);
            this.grpEntry.Controls.Add(this.txtNarration);
            this.grpEntry.Controls.Add(this.txtRwNo);
            this.grpEntry.Controls.Add(this.cmdApply);
            this.grpEntry.Controls.Add(this.label4);
            this.grpEntry.Location = new System.Drawing.Point(99, 64);
            this.grpEntry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpEntry.Name = "grpEntry";
            this.grpEntry.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpEntry.Size = new System.Drawing.Size(606, 411);
            this.grpEntry.TabIndex = 0;
            this.grpEntry.TabStop = false;
            this.grpEntry.Text = " ENTRY DETAILS ";
            this.grpEntry.Enter += new System.EventHandler(this.grpEntry_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 70;
            this.label3.Text = "TO DATE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 69;
            this.label2.Text = "BILL MONTH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "FROM DATE";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(331, 104);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(116, 27);
            this.dtpToDate.TabIndex = 3;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(100, 104);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(116, 27);
            this.dtpFromDate.TabIndex = 2;
            // 
            // dtpBillMonth
            // 
            this.dtpBillMonth.CustomFormat = "MMM-yyyy";
            this.dtpBillMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillMonth.Location = new System.Drawing.Point(104, 61);
            this.dtpBillMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpBillMonth.Name = "dtpBillMonth";
            this.dtpBillMonth.Size = new System.Drawing.Size(98, 27);
            this.dtpBillMonth.TabIndex = 0;
            this.dtpBillMonth.ValueChanged += new System.EventHandler(this.dtpBillMonth_ValueChanged);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.White;
            this.btnChange.Enabled = false;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Location = new System.Drawing.Point(104, 329);
            this.btnChange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(65, 32);
            this.btnChange.TabIndex = 7;
            this.btnChange.Text = "&CHANGE";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Wheat;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(170, 329);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(65, 32);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "&UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Wheat;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(236, 329);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 32);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "&DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            // 
            // txtSetMeterID
            // 
            this.txtSetMeterID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSetMeterID.Location = new System.Drawing.Point(373, 64);
            this.txtSetMeterID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSetMeterID.Name = "txtSetMeterID";
            this.txtSetMeterID.Size = new System.Drawing.Size(74, 27);
            this.txtSetMeterID.TabIndex = 63;
            this.txtSetMeterID.TabStop = false;
            this.txtSetMeterID.Text = "0";
            this.txtSetMeterID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSetMeterID.Visible = false;
            // 
            // lblMeterSeleted
            // 
            this.lblMeterSeleted.BackColor = System.Drawing.Color.White;
            this.lblMeterSeleted.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeterSeleted.Location = new System.Drawing.Point(12, 24);
            this.lblMeterSeleted.Name = "lblMeterSeleted";
            this.lblMeterSeleted.Size = new System.Drawing.Size(557, 34);
            this.lblMeterSeleted.TabIndex = 62;
            this.lblMeterSeleted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEntryCancel
            // 
            this.btnEntryCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntryCancel.Location = new System.Drawing.Point(397, 329);
            this.btnEntryCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEntryCancel.Name = "btnEntryCancel";
            this.btnEntryCancel.Size = new System.Drawing.Size(62, 32);
            this.btnEntryCancel.TabIndex = 9;
            this.btnEntryCancel.Text = "CANC&EL";
            this.btnEntryCancel.UseVisualStyleBackColor = true;
            this.btnEntryCancel.Click += new System.EventHandler(this.btnEntryCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 55;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Visible = false;
            // 
            // txtUnitFrom
            // 
            this.txtUnitFrom.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.txtUnitFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitFrom.Enabled = false;
            this.txtUnitFrom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitFrom.Location = new System.Drawing.Point(100, 149);
            this.txtUnitFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUnitFrom.Name = "txtUnitFrom";
            this.txtUnitFrom.Size = new System.Drawing.Size(84, 30);
            this.txtUnitFrom.TabIndex = 4;
            this.txtUnitFrom.TabStop = false;
            this.txtUnitFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUnitTo
            // 
            this.txtUnitTo.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.txtUnitTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitTo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitTo.Location = new System.Drawing.Point(100, 191);
            this.txtUnitTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUnitTo.Name = "txtUnitTo";
            this.txtUnitTo.Size = new System.Drawing.Size(84, 30);
            this.txtUnitTo.TabIndex = 5;
            this.txtUnitTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnitTo.TextChanged += new System.EventHandler(this.txtUnitTo_TextChanged);
            this.txtUnitTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnitTo_KeyPress);
            this.txtUnitTo.Validating += new System.ComponentModel.CancelEventHandler(this.txtUnitTo_Validating);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(49, 154);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 20);
            this.label22.TabIndex = 49;
            this.label22.Text = "FROM";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(68, 196);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(27, 20);
            this.label21.TabIndex = 48;
            this.label21.Text = "TO";
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(100, 232);
            this.txtQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(84, 30);
            this.txtQty.TabIndex = 6;
            this.txtQty.TabStop = false;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(44, 236);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(50, 20);
            this.lblQty.TabIndex = 47;
            this.lblQty.Text = "UNITS";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNarration
            // 
            this.txtNarration.BackColor = System.Drawing.SystemColors.Window;
            this.txtNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNarration.Location = new System.Drawing.Point(101, 276);
            this.txtNarration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(358, 44);
            this.txtNarration.TabIndex = 7;
            this.txtNarration.Text = "";
            // 
            // txtRwNo
            // 
            this.txtRwNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRwNo.Location = new System.Drawing.Point(27, 349);
            this.txtRwNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRwNo.Name = "txtRwNo";
            this.txtRwNo.Size = new System.Drawing.Size(32, 27);
            this.txtRwNo.TabIndex = 45;
            this.txtRwNo.TabStop = false;
            this.txtRwNo.Text = "0";
            this.txtRwNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRwNo.Visible = false;
            // 
            // cmdApply
            // 
            this.cmdApply.BackColor = System.Drawing.Color.PowderBlue;
            this.cmdApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdApply.Location = new System.Drawing.Point(331, 329);
            this.cmdApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(60, 32);
            this.cmdApply.TabIndex = 8;
            this.cmdApply.Text = "&APPLY";
            this.cmdApply.UseVisualStyleBackColor = false;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "Comments";
            // 
            // txtMultiplier
            // 
            this.txtMultiplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMultiplier.Location = new System.Drawing.Point(465, 64);
            this.txtMultiplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMultiplier.Name = "txtMultiplier";
            this.txtMultiplier.Size = new System.Drawing.Size(74, 27);
            this.txtMultiplier.TabIndex = 1;
            this.txtMultiplier.TabStop = false;
            this.txtMultiplier.Text = "0";
            this.txtMultiplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMultiplier.Visible = false;
            // 
            // frmBillEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.grpEntry);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBillEntry";
            this.Text = "MONTHLY BILL";
            this.Load += new System.EventHandler(this.frmBillEntry_Load);
            this.grpEntry.ResumeLayout(false);
            this.grpEntry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEntry;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtSetMeterID;
        private System.Windows.Forms.Label lblMeterSeleted;
        private System.Windows.Forms.Button btnEntryCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnitFrom;
        private System.Windows.Forms.TextBox txtUnitTo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.RichTextBox txtNarration;
        private System.Windows.Forms.TextBox txtRwNo;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpBillMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.TextBox txtMultiplier;
    }
}