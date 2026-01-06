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
    public partial class FrmManageInternationalApplications : Form
    {
        
        public FrmManageInternationalApplications()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            dataGridView1.DataSource = BussinessLayer.clsInternationalLicense.GetAllInternationalApplications();
            lbRecordsCount.Text = dataGridView1.RowCount.ToString();
        }
        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            FrmInterNationalLicenseApplication applications = new FrmInterNationalLicenseApplication();
            applications.ShowDialog();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsApplications App1 = new BussinessLayer.clsApplications();
            App1 = BussinessLayer.clsApplications.GetAppByAppID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value));
            frmPersonDetailes frm = new frmPersonDetailes(App1.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsApplications App1 = new BussinessLayer.clsApplications();
            App1 = BussinessLayer.clsApplications.GetAppByAppID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value));
            FrmLicenseHistory frm = new FrmLicenseHistory(App1.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInternationalDrivingLicenseDetails frm = new FrmInternationalDrivingLicenseDetails(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }
    }
}
