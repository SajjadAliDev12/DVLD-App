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
    public partial class FrmApplicationForLostOrdamageLic : Form
    {
        public FrmApplicationForLostOrdamageLic()
        {
            InitializeComponent();
        }

        private void txtbxLocalLicID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!Char.IsControl(e.KeyChar)))
                e.Handled = true;
            else
            { e.Handled = false; }
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
            if (rdbDamaged.Checked)
                lbFees.Text = "5";
            else lbFees.Text = "10";
            lbAppDate.Text =DateTime.Now.ToString();
            lbShowLicenseHistory.Enabled = false;
            lbShowLicense.Enabled = false;
            lbLocalLicID.Text = licenses.LicenseID.ToString();
            lbCreatedBY.Text = BussinessLayer.clsGlobalUSer._User1.UserName;
            rdbDamaged.Checked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsLicenses Lic = new BussinessLayer.clsLicenses();
            if (string.IsNullOrEmpty(txtbxLocalLicID.Text))
            {
                MessageBox.Show("You have to enter License ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Lic.GetLicenseByLicenseID(Convert.ToInt32(txtbxLocalLicID.Text)) == null)
            {
                MessageBox.Show("License ID Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((Lic = Lic.GetLicenseByLicenseID(Convert.ToInt32(txtbxLocalLicID.Text))) != null && !Lic.IsActive)
            {
                LoadData(Lic.ApplicationID);
                lbShowLicenseHistory.Enabled = true;
                btnIssueRepalce.Enabled = false;
                MessageBox.Show("Licnese is not active please choose another one " , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((Lic = Lic.GetLicenseByLicenseID(Convert.ToInt32(txtbxLocalLicID.Text))) != null)
            {
                LoadData(Lic.ApplicationID);
                lbShowLicenseHistory.Enabled = true;
                btnIssueRepalce.Enabled = true;
            }

            else
            {
                MessageBox.Show("Could Not Find ID With Number " + txtbxLocalLicID.Text + " !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lbAppID.Text != "N/A")
            {
                FrmShowLicenseDetailes frm = new FrmShowLicenseDetailes(Convert.ToInt32(lbAppID.Text));
                frm.ShowDialog();
            }
        }

        private void lbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BussinessLayer.clsPerson Perosn1 = new BussinessLayer.clsPerson();
            Perosn1 = BussinessLayer.clsPerson.FindPersonByNationalNumber(lbNationalNo.Text);
            FrmLicenseHistory frm = new FrmLicenseHistory(Perosn1.PersonID);
            frm.ShowDialog();
        }

        private void btnIssueRepalce_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsLicenses OldLic = new BussinessLayer.clsLicenses();
            OldLic = OldLic.GetLicenseByLicenseID(Convert.ToInt32(lbLocalLicID.Text));
            if (!OldLic.IsActive)
            {
                MessageBox.Show("This license can not be Replaced because it's not active !", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to repalce this license?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BussinessLayer.clsPerson Person1 = new BussinessLayer.clsPerson();
                Person1 = BussinessLayer.clsPerson.FindPersonByNationalNumber(lbNationalNo.Text);
                BussinessLayer.clsApplications RenewApp = new BussinessLayer.clsApplications();
                RenewApp.ApplicationDate = DateTime.Now;
                RenewApp.ApplicationStatus = BussinessLayer.clsApplications.enApplicationStatus.New;
                RenewApp.ApplicantPersonID = Person1.PersonID;
                if(rdbDamaged.Checked)
                {
                    RenewApp.ApplicationTypeID = 4;
                }
                else
                    RenewApp.ApplicationTypeID = 3;
                RenewApp.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
                RenewApp.LastStatusDate = DateTime.Now;
                RenewApp.PaidFees = 5;
                if (!RenewApp.AddNewApplication())
                {
                    MessageBox.Show("Sorry can not renew this license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if(rdbDamaged.Checked)
                {
                    NewLic.IssueReason = BussinessLayer.clsLicenses.enIssueReason.ReplacementforDamaged;
                    NewLic.PaidFees = 5;
                }
                else
                {
                    NewLic.IssueReason = BussinessLayer.clsLicenses.enIssueReason.ReplacementforLost;
                    NewLic.PaidFees = 10;
                }
                
                NewLic.LicenseClass = OldLic.LicenseClass;
                NewLic.Notes = "";
                
                if (NewLic.AddNewLicenses())
                {
                    lbILicenseID.Text = NewLic.LicenseID.ToString();
                    lbAppID.Text = RenewApp.ApplicationID.ToString();
                    lbShowLicense.Enabled = true;
                    MessageBox.Show("License Renewd Successfully With ID = " + NewLic.LicenseID, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnIssueRepalce.Enabled = false;
                    RenewApp.LastStatusDate = DateTime.Now;
                    RenewApp.ApplicationStatus = BussinessLayer.clsApplications.enApplicationStatus.Completed;
                    RenewApp.UpdateApplication();

                }

            }
        }

        private void rdbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbDamaged.Checked)
            {
                lbFees.Text = "5";
            }
            else
            {
                lbFees.Text = "10";
            }
        }
    }
}
