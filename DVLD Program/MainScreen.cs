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
    public partial class frmMainScreen : Form
    {
        public frmMainScreen()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManagePeople frm = new FrmManagePeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowallUsers frm = new FrmShowallUsers();
            frm.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLoginScreen frm = new frmLoginScreen();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserInfoscreen frm = new FrmUserInfoscreen(DVLDBussinessLayer.BussinessLayer.clsGlobalUSer._User1.PersonID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword frm = new FrmChangePassword(DVLDBussinessLayer.BussinessLayer.clsGlobalUSer._User1.PersonID);
            frm.ShowDialog();
        }

        private void mangeApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmmanageApplicationstype frm = new FrmmanageApplicationstype();
            frm.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTestTypes frm = new FrmTestTypes();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLocalDrivingApplications frm = new FrmLocalDrivingApplications();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewLocalDrivingLecinse frm = new FrmNewLocalDrivingLecinse();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDrivers frm = new FrmDrivers();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInterNationalLicenseApplication frm = new FrmInterNationalLicenseApplication();
            frm.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageInternationalApplications frm = new FrmManageInternationalApplications();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRenewDrivingLicense frm = new FrmRenewDrivingLicense();
            frm.ShowDialog();
        }

        private void repleacementForLoastOrDamegedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmApplicationForLostOrdamageLic frm = new FrmApplicationForLostOrdamageLic();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetainLicenes frm = new FrmDetainLicenes();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListDetainedLicenses frm = new FrmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReleaseDetainLic frm = new FrmReleaseDetainLic();
            frm.ShowDialog();
        }
    }
}
