using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Program
{
    public partial class FrmmanageApplicationstype : Form
    {
        public FrmmanageApplicationstype()
        {
            InitializeComponent();
            LaodData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LaodData()
        {
            dataGridView1.DataSource = BussinessLayer.clsApplicationsTypes.getAllApplicationType();
            lbCount.Text = dataGridView1.RowCount.ToString();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditApplicationType frm = new FrmEditApplicationType(Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            LaodData();
        }
    }
}
