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
using static DVLDBussinessLayer.BussinessLayer;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Program
{
    public partial class FrmIssueLocalDrivingLicenses : Form
    {
        private int _ApplicationID;
        public FrmIssueLocalDrivingLicenses(int LocalApplicationID)
        {
            InitializeComponent();
            BussinessLayer.clsLocalDrivingLecinse local = new clsLocalDrivingLecinse();
            local = local.GetLocalAppByLocalAppID(LocalApplicationID);
            _ApplicationID = local.ApplicationID;
            ucDrivingLecinseApplicationInfo1.LoadData(_ApplicationID);
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsApplications Applications = new BussinessLayer.clsApplications();
            Applications = BussinessLayer.clsApplications.GetAppByAppID(_ApplicationID);
            BussinessLayer.clsDrivers Driver = new BussinessLayer.clsDrivers();
            if(Driver.GetDriverByPersonID(Applications.ApplicantPersonID) != null)
            {
                Driver = Driver.GetDriverByPersonID(Applications.ApplicantPersonID);
            }
            else
            {
                Driver.CreatedDate = DateTime.Now;
                Driver.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
                Driver.PersonID = Applications.ApplicantPersonID;
                Driver.AddNewDriver();
            }
            
            BussinessLayer.clsLicenses licenses = new BussinessLayer.clsLicenses();
            licenses.ApplicationID = Applications.ApplicationID;
            licenses.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
            licenses.DriverID = Driver.DriverID;
            licenses.IsActive = true;
            licenses.IssueDate = DateTime.Now;
            licenses.IssueReason = BussinessLayer.clsLicenses.enIssueReason.FirstTime;
            BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
            Local = Local.GetLocalAppByAppID(Applications.ApplicationID);
            licenses.LicenseClass = Local.LicenseClassID;
            licenses.ExpirationDate = DateTime.Now.AddYears(BussinessLayer.clsLicenseClass.GetValidityLengthByLicenseClassID(Local.LicenseClassID));
            licenses.Notes = txtbxNotes.Text;
            licenses.PaidFees = Applications.PaidFees;
            if (licenses.AddNewLicenses())
            {
                Applications.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
                Applications.UpdateApplication();
                MessageBox.Show("License Issued With ID = " + licenses.LicenseID, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Could not add License", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
