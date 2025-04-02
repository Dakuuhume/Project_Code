using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserRights
{
    public partial class ElloraProperties: Form
    {
        public ElloraProperties()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users u2 = new Users();
            u2.Show();
            this.Hide();
            //this.Close();
        }

       
    }
}
