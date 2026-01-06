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
    public partial class FrmLicenseHistory : Form
    {
        public FrmLicenseHistory(int PersonID)
        {
            InitializeComponent();
            LoadData(PersonID);
        }
        private void LoadData(int PersonID)
        {
            usctrlpersonInfo1.LoadData(PersonID);
            dgvLocal.DataSource = BussinessLayer.clsLicenses.GetLicenesHistoryByPersonID(PersonID);
            dgvInterNational.DataSource = BussinessLayer.clsInternationalLicense.GetInterLicenseHistoryByPersonID(PersonID) ;
            lbRecordsCount.Text = dgvLocal.RowCount.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                lbRecordsCount.Text = dgvLocal.RowCount.ToString();
            }
            else
            {
                lbRecordsCount.Text = dgvInterNational.RowCount.ToString();
            }
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                FrmShowLicenseDetailes frm = new FrmShowLicenseDetailes(Convert.ToInt32(dgvLocal.CurrentRow.Cells[1].Value));
                frm.ShowDialog();
            }
            else
            {
                FrmInternationalDrivingLicenseDetails frm = new FrmInternationalDrivingLicenseDetails(Convert.ToInt32(dgvInterNational.CurrentRow.Cells[0].Value));
                frm.ShowDialog();
            }
        }
    }
}
