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
    public partial class FrmRenewDrivingLicense : Form
    {
        
        public FrmRenewDrivingLicense()
        {
            InitializeComponent();
            btnRenew.Enabled = false;
            lbShowLicense.Enabled = false;
            lbShowLicenseHistory.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadData(int ApplicationID)
        {
            BussinessLayer.clsApplications APP = new BussinessLayer.clsApplications();
            APP = BussinessLayer.clsApplications.GetAppByAppID(ApplicationID);
            BussinessLayer.clsLicenses licenses = new BussinessLayer.clsLicenses();
            licenses = licenses.GetLicenseByApplicationID(ApplicationID);
            BussinessLayer.clsPerson person = new BussinessLayer.clsPerson();
            person = BussinessLayer.clsPerson.FindPersonById(APP.ApplicantPersonID);
            BussinessLayer.clsDrivers drivers = new BussinessLayer.clsDrivers();
            drivers = drivers.GetDriverByPersonID(person.PersonID);
            lbClass.Text = BussinessLayer.clsLicenseClass.GetClassNameByClassID(licenses.LicenseClass);
            lbName.Text = person.FullName();
            lbNationalNo.Text = person.NationalNumber;
            if (person.Gender == 0)
                lbGender.Text = "Male";
            else lbGender.Text = "Female";
            lbIssueDate.Text = licenses.IssueDate.ToString();
            lbNotes.Text = licenses.Notes;
            if (licenses.IsActive) lbIsActive.Text = "Yes";
            else lbIsActive.Text = "No";
            lbDateOfBirth.Text = person.BirthDate.ToString();
            lbDriverID.Text = drivers.DriverID.ToString();
            lbExpDate.Text = licenses.ExpirationDate.ToString();
            pictureBox2.ImageLocation = person.PhotoPath;
            if (licenses.IssueReason == BussinessLayer.clsLicenses.enIssueReason.FirstTime) lbIssueReason.Text = "First Time";
            else if (licenses.IssueReason == BussinessLayer.clsLicenses.enIssueReason.Renew) lbIssueReason.Text = "Renew";
            else if (licenses.IssueReason == BussinessLayer.clsLicenses.enIssueReason.ReplacementforDamaged) lbIssueReason.Text = "Replacement for Damaged";
            else lbIssueReason.Text = "Replacement for Lost";
            lbLicenseID.Text = licenses.LicenseID.ToString();
            btnRenew.Enabled = false;
            lbShowLicenseHistory.Enabled = false;
            lbShowLicense.Enabled = false;
            lbRenewAppDate.Text = DateTime.Now.ToString();
            lbRenewAppFees.Text = "7";
            lbRenewCreatedBy.Text = BussinessLayer.clsGlobalUSer._User1.UserName;
            lbRenewExpDate.Text =DateTime.Now.AddYears(Convert.ToInt32( BussinessLayer.clsLicenseClass.GetValidityLengthByLicenseClassID(licenses.LicenseClass))).ToString();
            lbRenewIssueDate.Text = DateTime.Now.ToString();
            lbRenewLicFees.Text = "20";
            lbRenewTotalFees.Text = "27";
            lbOldLicID.Text = licenses.LicenseID.ToString();
        }

        private void txtbxLocalLicID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!Char.IsControl(e.KeyChar)))
                e.Handled = true;
            else
            { e.Handled = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsLicenses Lic = new BussinessLayer.clsLicenses();
            if (string.IsNullOrEmpty(txtbxLocalLicID.Text))
            {
                MessageBox.Show("You have to enter License ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(Lic.GetLicenseByLicenseID(Convert.ToInt32( txtbxLocalLicID.Text)) == null)
            {
                MessageBox.Show("License ID Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((Lic = Lic.GetLicenseByLicenseID(Convert.ToInt32(txtbxLocalLicID.Text))) != null && Lic.ExpirationDate > DateTime.Now)
            {
                LoadData(Lic.ApplicationID);
                lbShowLicenseHistory.Enabled = true;
                MessageBox.Show("Licnese is not yet expired the expiration date is " + Lic.ExpirationDate.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((Lic = Lic.GetLicenseByLicenseID(Convert.ToInt32(txtbxLocalLicID.Text))) != null)
            {
                LoadData(Lic.ApplicationID);
                lbShowLicenseHistory.Enabled = true;
                btnRenew.Enabled = true;
            }

            else
            {
                MessageBox.Show("Could Not Find ID With Number " + txtbxLocalLicID.Text + " !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BussinessLayer.clsPerson Perosn1 = new BussinessLayer.clsPerson();
            Perosn1 = BussinessLayer.clsPerson.FindPersonByNationalNumber(lbNationalNo.Text);
            FrmLicenseHistory frm = new FrmLicenseHistory(Perosn1.PersonID);
            frm.ShowDialog();
        }

        private void lbShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lbRenewApplicationID.Text != "N/A")
            {
                FrmShowLicenseDetailes frm = new FrmShowLicenseDetailes(Convert.ToInt32(lbRenewApplicationID.Text));
                frm.ShowDialog();
            }
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsLicenses OldLic = new BussinessLayer.clsLicenses();
            OldLic = OldLic.GetLicenseByLicenseID(Convert.ToInt32( lbOldLicID.Text));
            if(!OldLic.IsActive)
            {
                MessageBox.Show("This license can not be renewd again !","Erorr",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(MessageBox.Show("Are you sure you want to renew this license?","Confirm",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BussinessLayer.clsPerson Person1 = new BussinessLayer.clsPerson();
            Person1 = BussinessLayer.clsPerson.FindPersonByNationalNumber(lbNationalNo.Text);
            BussinessLayer.clsApplications RenewApp = new BussinessLayer.clsApplications();
            RenewApp.ApplicationDate = DateTime.Now;
            RenewApp.ApplicationStatus = BussinessLayer.clsApplications.enApplicationStatus.New;
            RenewApp.ApplicantPersonID = Person1.PersonID;
            RenewApp.ApplicationTypeID = 2;
            RenewApp.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
            RenewApp.LastStatusDate = DateTime.Now;
            RenewApp.PaidFees = 7;
            if(!RenewApp.AddNewApplication())
            {
                MessageBox.Show("Sorry can not renew this license!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            OldLic.IsActive = false;
            OldLic.UpdateLicenseByLicenseID();
            BussinessLayer.clsLicenses NewLic = new BussinessLayer.clsLicenses();
            NewLic.ApplicationID = RenewApp.ApplicationID;
            NewLic.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
            NewLic.DriverID = OldLic.DriverID;
            NewLic.ExpirationDate = DateTime.Now.AddYears(BussinessLayer.clsLicenseClass.GetValidityLengthByLicenseClassID(OldLic.LicenseClass));
            NewLic.IsActive = true;
            NewLic.IssueDate = DateTime.Now;
            NewLic.IssueReason = BussinessLayer.clsLicenses.enIssueReason.Renew;
            NewLic.LicenseClass = OldLic.LicenseClass;
            NewLic.Notes = "";
            NewLic.PaidFees = 20;
            if(NewLic.AddNewLicenses())
            {
                lbRenewedLicID.Text = NewLic.LicenseID.ToString();
                lbRenewApplicationID.Text = RenewApp.ApplicationID.ToString();
                lbRenewExpDate.Text = NewLic.ExpirationDate.ToString();
                lbShowLicense.Enabled = true;
                MessageBox.Show("License Renewd Successfully With ID = "+ NewLic.LicenseID,"Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRenew.Enabled = false;
                RenewApp.LastStatusDate = DateTime.Now;
                RenewApp.ApplicationStatus = BussinessLayer.clsApplications.enApplicationStatus.Completed;
                RenewApp.UpdateApplication();

            }

            }
            
                
        }
    }
}
