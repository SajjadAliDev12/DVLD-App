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
    public partial class UCDrivingLecinseApplicationInfo : UserControl
    {

        private BussinessLayer.clsApplications App = new BussinessLayer.clsApplications();
        private BussinessLayer.clsPerson Person = new BussinessLayer.clsPerson();
        private BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
        public UCDrivingLecinseApplicationInfo()
        {
            InitializeComponent();
            
        }

        public void LoadData(int ApplicationID)
        {
            

            App = BussinessLayer.clsApplications.GetAppByAppID(ApplicationID);
            Person = BussinessLayer.clsPerson.FindPersonById(App.ApplicantPersonID);
            Local = Local.GetLocalAppByAppID(ApplicationID);
            DataTable dt = new DataTable();
            lbPassedTest.Text = BussinessLayer.clsLocalDrivingLecinse.GetLocalAppPassedTest(Local.LocalDrivingLicenseApplicationID).ToString() + "/3";
            if (BussinessLayer.clsLocalDrivingLecinse.GetLocalAppPassedTest(Local.LocalDrivingLicenseApplicationID) < 3)
            {
                lnklbShowLicenseInfo.Enabled = false;
            }
            if(App.ApplicationTypeID == 1)
            {
                dt = BussinessLayer.clsLicenseClass.GetAllLicenseClass();
                lbAppliedForLicense.Text = dt.Rows[Local.LicenseClassID-1][1].ToString();
                lbDLAPPID.Text = Local.LocalDrivingLicenseApplicationID.ToString();

            }
            else
            {
                dt = BussinessLayer.clsApplicationsTypes.getAllApplicationType();
                lbAppliedForLicense.Text = dt.Rows[App.ApplicationTypeID-1][1].ToString();
            }
            lbFees.Text = App.PaidFees.ToString();
            lbAppID.Text = App.ApplicationID.ToString();
            if (App.ApplicationStatus == BussinessLayer.clsApplications.enApplicationStatus.New)
            {
                lbStauts.Text = "New";
            }
            else if (App.ApplicationStatus == BussinessLayer.clsApplications.enApplicationStatus.Cancelled)
            {
                lbStauts.Text = "Cancelled";
            }
            else
                lbStauts.Text = "Completed";
            DataTable dt2 = new DataTable();
            dt2 = BussinessLayer.clsApplicationsTypes.getAllApplicationType();
            lbType.Text = dt2.Rows[App.ApplicationTypeID-1][1].ToString();
            lbApplicant.Text = Person.FullName();
            lbDate.Text = App.ApplicationDate.ToString();
            lbStatusDate.Text = App.LastStatusDate.ToString();
            BussinessLayer.clsUser User1 =  BussinessLayer.clsUser.FindUserByUserID(App.CreatedByUserID);
            lbCreatedBY.Text = User1.UserName;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetailes frm = new frmPersonDetailes(App.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void lnklbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(lbAppID.Text != "N/A")
            {
                FrmShowLicenseDetailes frm = new FrmShowLicenseDetailes(Convert.ToInt32(lbAppID.Text));
                frm.ShowDialog();
            }
        }
    }
}
