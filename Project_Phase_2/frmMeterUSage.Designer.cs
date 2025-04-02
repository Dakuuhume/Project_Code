
namespace phase_2
{
    partial class frmMeterUSage
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
            this.txtAdj = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dbcBooking = new System.Windows.Forms.ComboBox();
            this.btnEntryCancel = new System.Windows.Forms.Button();
            this.btnSelBooking = new System.Windows.Forms.Button();
            this.txtIsMakeup = new System.Windows.Forms.TextBox();
            this.txtIsRevenue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dbcUsage = new System.Windows.Forms.ComboBox();
            this.txtUnitFrom = new System.Windows.Forms.TextBox();
            this.txtUnitTo = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblUoM = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCharges = new System.Windows.Forms.TextBox();
            this.txtRwNo = new System.Windows.Forms.TextBox();
            this.cmdApply = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grpEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpEntry
            // 
            this.grpEntry.BackColor = System.Drawing.Color.Honeydew;
            this.grpEntry.Controls.Add(this.label1);
            this.grpEntry.Controls.Add(this.comboBox1);
            this.grpEntry.Controls.Add(this.txtAdj);
            this.grpEntry.Controls.Add(this.label6);
            this.grpEntry.Controls.Add(this.dbcBooking);
            this.grpEntry.Controls.Add(this.btnEntryCancel);
            this.grpEntry.Controls.Add(this.btnSelBooking);
            this.grpEntry.Controls.Add(this.txtIsRevenue);
            this.grpEntry.Controls.Add(this.label2);
            this.grpEntry.Controls.Add(this.dbcUsage);
            this.grpEntry.Controls.Add(this.txtUnitFrom);
            this.grpEntry.Controls.Add(this.txtUnitTo);
            this.grpEntry.Controls.Add(this.label22);
            this.grpEntry.Controls.Add(this.label21);
            this.grpEntry.Controls.Add(this.lblUoM);
            this.grpEntry.Controls.Add(this.txtQty);
            this.grpEntry.Controls.Add(this.lblQty);
            this.grpEntry.Controls.Add(this.txtNarration);
            this.grpEntry.Controls.Add(this.cmdApply);
            this.grpEntry.Controls.Add(this.label4);
            this.grpEntry.Location = new System.Drawing.Point(42, 45);
            this.grpEntry.Name = "grpEntry";
            this.grpEntry.Size = new System.Drawing.Size(859, 275);
            this.grpEntry.TabIndex = 1;
            this.grpEntry.TabStop = false;
            this.grpEntry.Text = "Entry Details";
            this.grpEntry.Visible = false;
            // 
            // txtAdj
            // 
            this.txtAdj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdj.Enabled = false;
            this.txtAdj.Location = new System.Drawing.Point(742, 87);
            this.txtAdj.Name = "txtAdj";
            this.txtAdj.Size = new System.Drawing.Size(84, 23);
            this.txtAdj.TabIndex = 61;
            this.txtAdj.TabStop = false;
            this.txtAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdj.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 60;
            this.label6.Text = "PRODUCTION";
            // 
            // dbcBooking
            // 
            this.dbcBooking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbcBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbcBooking.FormattingEnabled = true;
            this.dbcBooking.Location = new System.Drawing.Point(120, 137);
            this.dbcBooking.Name = "dbcBooking";
            this.dbcBooking.Size = new System.Drawing.Size(469, 23);
            this.dbcBooking.TabIndex = 59;
            // 
            // btnEntryCancel
            // 
            this.btnEntryCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntryCancel.Location = new System.Drawing.Point(504, 166);
            this.btnEntryCancel.Name = "btnEntryCancel";
            this.btnEntryCancel.Size = new System.Drawing.Size(85, 28);
            this.btnEntryCancel.TabIndex = 10;
            this.btnEntryCancel.Text = "CANC&EL";
            this.btnEntryCancel.UseVisualStyleBackColor = true;
            // 
            // btnSelBooking
            // 
            this.btnSelBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelBooking.Location = new System.Drawing.Point(595, 165);
            this.btnSelBooking.Name = "btnSelBooking";
            this.btnSelBooking.Size = new System.Drawing.Size(65, 29);
            this.btnSelBooking.TabIndex = 2;
            this.btnSelBooking.Text = "SELECT";
            this.btnSelBooking.UseVisualStyleBackColor = true;
            this.btnSelBooking.Visible = false;
            // 
            // txtIsMakeup
            // 
            this.txtIsMakeup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIsMakeup.Enabled = false;
            this.txtIsMakeup.Location = new System.Drawing.Point(493, 14);
            this.txtIsMakeup.Name = "txtIsMakeup";
            this.txtIsMakeup.Size = new System.Drawing.Size(35, 23);
            this.txtIsMakeup.TabIndex = 7;
            this.txtIsMakeup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIsMakeup.Visible = false;
            // 
            // txtIsRevenue
            // 
            this.txtIsRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIsRevenue.Location = new System.Drawing.Point(0, 22);
            this.txtIsRevenue.Name = "txtIsRevenue";
            this.txtIsRevenue.Size = new System.Drawing.Size(35, 23);
            this.txtIsRevenue.TabIndex = 6;
            this.txtIsRevenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIsRevenue.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 51;
            this.label2.Text = "USAGE";
            // 
            // dbcUsage
            // 
            this.dbcUsage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbcUsage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbcUsage.FormattingEnabled = true;
            this.dbcUsage.Location = new System.Drawing.Point(234, 43);
            this.dbcUsage.Name = "dbcUsage";
            this.dbcUsage.Size = new System.Drawing.Size(322, 23);
            this.dbcUsage.TabIndex = 1;
            // 
            // txtUnitFrom
            // 
            this.txtUnitFrom.BackColor = System.Drawing.SystemColors.Window;
            this.txtUnitFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitFrom.Enabled = false;
            this.txtUnitFrom.Location = new System.Drawing.Point(562, 43);
            this.txtUnitFrom.Name = "txtUnitFrom";
            this.txtUnitFrom.Size = new System.Drawing.Size(84, 23);
            this.txtUnitFrom.TabIndex = 3;
            this.txtUnitFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUnitTo
            // 
            this.txtUnitTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitTo.Location = new System.Drawing.Point(652, 43);
            this.txtUnitTo.Name = "txtUnitTo";
            this.txtUnitTo.Size = new System.Drawing.Size(84, 23);
            this.txtUnitTo.TabIndex = 4;
            this.txtUnitTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(559, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 15);
            this.label22.TabIndex = 49;
            this.label22.Text = "FROM";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(649, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 15);
            this.label21.TabIndex = 48;
            this.label21.Text = "TO";
            // 
            // lblUoM
            // 
            this.lblUoM.AutoSize = true;
            this.lblUoM.Location = new System.Drawing.Point(764, 69);
            this.lblUoM.Name = "lblUoM";
            this.lblUoM.Size = new System.Drawing.Size(33, 15);
            this.lblUoM.TabIndex = 41;
            this.lblUoM.Text = "UoM";
            // 
            // txtQty
            // 
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Enabled = false;
            this.txtQty.Location = new System.Drawing.Point(742, 43);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(55, 23);
            this.txtQty.TabIndex = 5;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(758, 24);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(39, 15);
            this.lblQty.TabIndex = 47;
            this.lblQty.Text = "UNITS";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNarration
            // 
            this.txtNarration.BackColor = System.Drawing.SystemColors.Window;
            this.txtNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNarration.Location = new System.Drawing.Point(32, 87);
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(321, 40);
            this.txtNarration.TabIndex = 8;
            this.txtNarration.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(55, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 15);
            this.label14.TabIndex = 46;
            this.label14.Text = "METER NAME";
            // 
            // txtCharges
            // 
            this.txtCharges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCharges.Enabled = false;
            this.txtCharges.Location = new System.Drawing.Point(155, 14);
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.Size = new System.Drawing.Size(323, 23);
            this.txtCharges.TabIndex = 0;
            // 
            // txtRwNo
            // 
            this.txtRwNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRwNo.Location = new System.Drawing.Point(535, 14);
            this.txtRwNo.Name = "txtRwNo";
            this.txtRwNo.Size = new System.Drawing.Size(74, 23);
            this.txtRwNo.TabIndex = 45;
            this.txtRwNo.Text = "0";
            this.txtRwNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRwNo.Visible = false;
            // 
            // cmdApply
            // 
            this.cmdApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdApply.Location = new System.Drawing.Point(413, 166);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(85, 28);
            this.cmdApply.TabIndex = 9;
            this.cmdApply.Text = "&APPLY";
            this.cmdApply.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 44;
            this.label4.Text = "COMMENTS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 64;
            this.label1.Text = "USAGE TYPE";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(32, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 23);
            this.comboBox1.TabIndex = 62;
            // 
            // frmMeterUSage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.grpEntry);
            this.Controls.Add(this.txtIsMakeup);
            this.Controls.Add(this.txtCharges);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRwNo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMeterUSage";
            this.Text = "Meter Usage";
            this.grpEntry.ResumeLayout(false);
            this.grpEntry.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtAdj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox dbcBooking;
        private System.Windows.Forms.Button btnEntryCancel;
        private System.Windows.Forms.Button btnSelBooking;
        private System.Windows.Forms.TextBox txtIsRevenue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dbcUsage;
        private System.Windows.Forms.TextBox txtUnitFrom;
        private System.Windows.Forms.TextBox txtUnitTo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblUoM;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.RichTextBox txtNarration;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIsMakeup;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCharges;
        private System.Windows.Forms.TextBox txtRwNo;
    }
}