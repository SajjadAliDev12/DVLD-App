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
    public partial class FrmInterNationalLicenseApplication : Form
    {
        public FrmInterNationalLicenseApplication()
        {
            InitializeComponent();
            btnIssue.Enabled = false;
            lbShowLicense.Enabled = false;
            lbShowLicenseHistory.Enabled = false;
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
            lbInterAppDate.Text = DateTime.Now.ToString();
            lbAppDate.Text = DateTime.Now.ToString();
            lbInterFees.Text = "51";
            lbLocalLicID.Text = licenses.LicenseID.ToString();
            lbinterExpDate.Text = DateTime.Now.AddYears(1).ToString();
            lbCreatedBY.Text = BussinessLayer.clsGlobalUSer._User1.UserName;
            btnIssue.Enabled = false;
            lbShowLicenseHistory.Enabled = false;
            lbShowLicense.Enabled = false;
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
            if(string.IsNullOrEmpty(txtbxLocalLicID.Text))
            {
                MessageBox.Show("You have to enter local License ID!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Lic.GetLicenseByLicenseID(Convert.ToInt32(txtbxLocalLicID.Text)) == null)
            {
                MessageBox.Show("License ID Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((Lic = Lic.GetLicenseByLicenseID(Convert.ToInt32(txtbxLocalLicID.Text))) != null && Lic.LicenseClass != 3)
            {
                MessageBox.Show("Wrong License Type!\nCan not issue international license using this local license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if((Lic = Lic.GetLicenseByLicenseID(Convert.ToInt32(txtbxLocalLicID.Text))) != null)
            {
                LoadData(Lic.ApplicationID);
                lbShowLicenseHistory.Enabled = true;
                btnIssue.Enabled = true;
            }
            
            else
            {
                MessageBox.Show("Could Not Find ID With Number "+txtbxLocalLicID.Text + " !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsInternationalLicense InterLic = new BussinessLayer.clsInternationalLicense();
            if(BussinessLayer.clsInternationalLicense.IsInterLicExistByLocallicID(Convert.ToInt32(lbLicenseID.Text)))
            {
                
                InterLic = InterLic.GetClsInternationalLocalLicenseByID(Convert.ToInt32(lbLicenseID.Text));
                if((InterLic != null) && ((InterLic.ExpirationDate > DateTime.Now) && InterLic.IsActive))
                {
                    MessageBox.Show("Could Not Issue A new International License Because There Is An Active License For This Person!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnIssue.Enabled = false;
                }
            }
            else
            {
                BussinessLayer.clsApplications applications = new BussinessLayer.clsApplications();
                applications.ApplicationDate = DateTime.Now;
                applications.ApplicationTypeID = 6;
                applications.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
                BussinessLayer.clsPerson Person1 = new BussinessLayer.clsPerson();
                Person1 = BussinessLayer.clsPerson.FindPersonByNationalNumber(lbNationalNo.Text);

                applications.ApplicantPersonID = Person1.PersonID;
                applications.ApplicationStatus = BussinessLayer.clsApplications.enApplicationStatus.New;
                applications.PaidFees = 51;
                applications.LastStatusDate = DateTime.Now;

                InterLic.IssueDate = DateTime.Now;
                InterLic.ExpirationDate = DateTime.Now.AddYears(1);
                
                InterLic.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
                BussinessLayer.clsDrivers Driver1 = new BussinessLayer.clsDrivers();
                Driver1 = Driver1.GetDriverByPersonID(Person1.PersonID);
                InterLic.DriverID = Driver1.DriverID;
                InterLic.IsActive = true;
                applications.AddNewApplication();
                InterLic.IssuedUsingLocalLicenseID = Convert.ToInt32(lbLicenseID.Text);
                InterLic.ApplicationID =applications.ApplicationID;
                if(InterLic.AddnewInternationalLicense())
                {
                    
                    applications.ApplicationStatus = BussinessLayer.clsApplications.enApplicationStatus.Completed;
                    applications.UpdateApplication();
                    lbInterNationalAppID.Text = applications.ApplicationID.ToString();
                    lbILicenseID.Text = InterLic.InternationalLicenseID.ToString();
                    lbShowLicense.Enabled = true;
                    btnIssue.Enabled = false;
                    MessageBox.Show("International License Issued With ID " + InterLic.InternationalLicenseID + " !", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Could Not Issue A new International License !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            if(lbILicenseID.Text != "N/A")
            {
                FrmInternationalDrivingLicenseDetails frm = new FrmInternationalDrivingLicenseDetails(Convert.ToInt32(lbILicenseID.Text));
                frm.ShowDialog();
            }
        }
    }
}

