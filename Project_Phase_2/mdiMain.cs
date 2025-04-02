using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phase_2
{
    public partial class mdiMain : Form
    {
        clsGeneric genCode = new clsGeneric();
        public mdiMain()
        {
            InitializeComponent();
        }
        private bool clickFunction(object stryChild)
        {
            foreach (Form fc in MdiChildren)
            {
                if (fc != null)
                {
                    if (fc.Name == stryChild.GetType().Name)
                    {
                        fc.TopMost = true;
                        fc.Activate();
                        return false;
                    }
                }
            }
            return true;
        }


        private bool clickFunctionFormName(Object stryChild, string stryName)
        {
            foreach (Form fc in MdiChildren)
            {
                if (fc != null)
                {
                    if (fc.Name == stryChild.GetType().Name && fc.Text == stryName)
                        return false;
                }
            }
            return true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }

        private void electricityMetersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            if (genCode.hasRights(itm.Tag.ToString(), DataContainer.EMP_ROLE) == true)
            {
                frmMeterMaster fr = new frmMeterMaster();
                if (clickFunction(fr) == false)
                {
                    return;
                }
                fr.StartPosition = FormStartPosition.Manual;
                fr.Location = new Point(0, 0);
                fr.MdiParent = this;
                fr.Icon = this.Icon;
                fr.TopMost = true;
                fr.Show();
            }
            else
                MessageBox.Show("Access denied");

        }
        #region FormLoad
        private void mdiMain_Load(object sender, EventArgs e)
        {
            frmLogin fr = new frmLogin();
            fr.MdiParent = this;
            fr.StartPosition = FormStartPosition.Manual;
            fr.Location = new Point(0, 0);
            fr.FormClosed += new System.Windows.Forms.FormClosedEventHandler(LoginCheck);
            fr.TopMost = true;
            fr.Show();

        }
        private void LoginCheck(object sender, EventArgs e)
        {
            if (DataContainer.EMP_Code == 0)
            {
                MessageBox.Show("No User to Log In. Exiting the system.");
                this.Dispose();
            }
            if (!(DataContainer.USERNAME is null))
            {
                statusStrip.Items[0].Text = DataContainer.USERNAME;
                statusRole.Text = DataContainer.EMP_ROLE;
                // HARD-CODED - tag 
                if (genCode.hasRights("ELEC-DASH", DataContainer.EMP_ROLE) == true)
                {
                    frmCalendarDash fr = new frmCalendarDash();
                    fr.MdiParent = this;
                    fr.StartPosition = FormStartPosition.CenterScreen;
                    fr.TopMost = true;
                    fr.WindowState = FormWindowState.Maximized;
                    fr.Show();
                }
            }
            else return;
        }

        #endregion

        private void customerBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void makeupRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            if (genCode.hasRights(itm.Tag.ToString(), DataContainer.EMP_ROLE) == true)
            {
                frmMakeupRoom fr = new frmMakeupRoom();
                if (clickFunction(fr) == false)
                {
                    return;
                }
                fr.StartPosition = FormStartPosition.Manual;
                fr.Location = new Point(0, 0);
                fr.MdiParent = this;
                fr.Icon = this.Icon;
                fr.TopMost = true;
                fr.Show();
            }
            else
                MessageBox.Show("Access denied");
        }

        private void meterReadingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            if (genCode.hasRights(itm.Tag.ToString(), DataContainer.EMP_ROLE) == true)
            {
                frmMeterReadings fr = new frmMeterReadings();
                if (clickFunction(fr) == false)
                {
                    return;
                }
                fr.StartPosition = FormStartPosition.Manual;
                fr.Location = new Point(0, 0);
                fr.MdiParent = this;
                fr.Icon = this.Icon;
                fr.TopMost = true;
                fr.BookingPlanID = 181;
                fr.Show();
            }
            else
                MessageBox.Show("Access denied");

        }

        private void makeupRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            if (genCode.hasRights(itm.Tag.ToString(), DataContainer.EMP_ROLE) == true)
            {
                frmMakeupRoomUsage fr = new frmMakeupRoomUsage();
                if (clickFunction(fr) == false)
                {
                    return;
                }
                fr.StartPosition = FormStartPosition.Manual;
                fr.Location = new Point(0, 0);
                fr.MdiParent = this;
                fr.Icon = this.Icon;
                fr.TopMost = true;
                fr.BookingPlanID = 181;
                fr.Show();
            }
            else
                MessageBox.Show("Access denied");
        }

        private void mnuDashboard_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            if (genCode.hasRights(itm.Tag.ToString(), DataContainer.EMP_ROLE) == true)
            {
                frmBookingSchedule fr = new frmBookingSchedule();
                if (clickFunction(fr) == false)
                {
                    return;
                }
                fr.MdiParent = this;
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.WindowState = FormWindowState.Maximized;
                fr.TopMost = true;
                fr.Show();
            }
            else
                MessageBox.Show("Access denied");
        }

        private void meterConsumptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            if (genCode.hasRights(itm.Tag.ToString(), DataContainer.EMP_ROLE) == true)
            {
                frmMISReports fr = new frmMISReports();
                if (clickFunction(fr) == false)
                {
                    return;
                }
                if (!(this.ActiveMdiChild is null)) this.ActiveMdiChild.TopMost = false;
                fr.MdiParent = this;
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.WindowState = FormWindowState.Maximized;
                fr.TopMost = true;
                fr.Show();
            }
            else
                MessageBox.Show("Access denied");
        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chargesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            if (genCode.hasRights(itm.Tag.ToString(), DataContainer.EMP_ROLE) == true)
            {
                frmElecMeterUsage fr = new frmElecMeterUsage();
                if (clickFunction(fr) == false)
                {
                    return;
                }
                fr.MdiParent = this;
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.WindowState = FormWindowState.Maximized;
                fr.TopMost = true;
                fr.Show();
            }
            else
                MessageBox.Show("Access denied");
        }

        private void eleCalendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            if (genCode.hasRights(itm.Tag.ToString(), DataContainer.EMP_ROLE) == true)
            {
                frmCalendarDash fr = new frmCalendarDash();
                if (clickFunction(fr) == false)
                {
                    return;
                }
                fr.MdiParent = this;
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.WindowState = FormWindowState.Maximized;
                fr.TopMost = true;
                fr.Show();
            }
            else
                MessageBox.Show("Access denied");
        }

        private void bILLMETERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBillMeterMaster fr = new frmBillMeterMaster();
            if (clickFunction(fr) == false)
            {
                return;
            }
            fr.MdiParent = this;
            fr.StartPosition = FormStartPosition.CenterScreen;
            fr.WindowState = FormWindowState.Maximized;
            fr.TopMost = true;
            fr.Show();
        }

        private void mONTHLYREADINGSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            if (genCode.hasRights(itm.Tag.ToString(), DataContainer.EMP_ROLE) == true)
            {
                frmBillEntry fr = new frmBillEntry();
                if (clickFunction(fr) == false)
                {
                    return;
                }
                fr.MdiParent = this;
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.WindowState = FormWindowState.Maximized;
                fr.TopMost = true;
                fr.Show();
            }
            else
                MessageBox.Show("Access denied");
        }

        private void toolStripMenuLTPanelReading_Click(object sender, EventArgs e)
        {
            frmLTPanelEntry fr = new frmLTPanelEntry();
            if (clickFunction(fr) == false)
            {
                return;
            }
            fr.MdiParent = this;
            fr.StartPosition = FormStartPosition.CenterScreen;
            fr.WindowState = FormWindowState.Maximized;
            fr.TopMost = true;
            fr.Show();
        }

        private void lTPanelMetersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLTPanelMaster fr = new frmLTPanelMaster();
            if (clickFunction(fr) == false)
            {
                return;
            }
            fr.MdiParent = this;
            fr.StartPosition = FormStartPosition.CenterScreen;
            fr.WindowState = FormWindowState.Maximized;
            fr.TopMost = true;
            fr.Show();
        }
    }
}
