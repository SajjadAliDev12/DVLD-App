using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Program
{
    public partial class FrmReleaseDetainLic : Form
    {
        private int _LicenseID;
        private int _DetainID;
        public FrmReleaseDetainLic()
        {
            InitializeComponent();
            lbShowLicenseHistory.Enabled = false;
            btnRelease.Enabled = false;
            lbShowLicense.Enabled = false;
        }
        public FrmReleaseDetainLic(int  licenseID)
        {
            InitializeComponent();
            txtbxLocalLicID.Text = licenseID.ToString();
            txtbxLocalLicID.Enabled = false;
            button1.Enabled = false;
            BussinessLayer.clsLicenses Lic = new BussinessLayer.clsLicenses();
            Lic = Lic.GetLicenseByLicenseID(licenseID);
            _DetainID = IsLicenseDetian(licenseID);
            LoadData(Lic.ApplicationID);
        }
        private void txtbxLocalLicID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!Char.IsControl(e.KeyChar)))
                e.Handled = true;
            else
            { e.Handled = false; }
        }
        private int IsLicenseDetian(int  licenseID)
        {
            DataTable dt = new DataTable();
            dt = BussinessLayer.clsDetain.GetDetainedLicByLicID(licenseID);
            foreach (DataRow dr in dt.Rows)
            {
                if ((bool)dr[5] == false)
                {
                    return Convert.ToInt32(dr[0]);
                }
                
            }
            return 0;
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
            lbDetainDate.Text = DateTime.Now.ToString();
            lbLicenseIDDetain.Text = licenses.LicenseID.ToString();
            lbCreatedByUser.Text = BussinessLayer.clsGlobalUSer._User1.UserName;
            lbShowLicenseHistory.Enabled = false;
            lbShowLicense.Enabled = false;
            if (BussinessLayer.clsDetain.IsLicenseDetainedByLicID(licenses.LicenseID))
                lbIsDitain.Text = "Yes";
            else
                lbIsDitain.Text = "No";
            _LicenseID = licenses.LicenseID;
            lbApplicationFees.Text = "15";
            BussinessLayer.clsDetain Detain1 = new BussinessLayer.clsDetain();
            Detain1 = Detain1.GetDetainLicByDetainID(_DetainID);
            lbDetainDate.Text = Detain1.DetainDate.ToString();
            lbDetainID.Text = Detain1.DetainID.ToString();
            lbFineFees.Text = Detain1.FineFees.ToString();
            lbTotalFees.Text = (Convert.ToInt32(lbApplicationFees.Text) + Detain1.FineFees).ToString();
        }

        private void lbShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lbLicenseID.Text != "N/A")
            {
                FrmShowLicenseDetailes frm = new FrmShowLicenseDetailes(Convert.ToInt32(lbLicenseID.Text));
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
            else if ((Lic = Lic.GetLicenseByLicenseID(Convert.ToInt32(txtbxLocalLicID.Text))) != null && IsLicenseDetian(Lic.LicenseID) ==0)
            {
                MessageBox.Show("This License is not detained!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //LoadData(Lic.ApplicationID);
                btnRelease.Enabled = false;
                
                lbShowLicenseHistory.Enabled = false;
            }

            else if ((Lic = Lic.GetLicenseByLicenseID(Convert.ToInt32(txtbxLocalLicID.Text))) != null)
            {
                _DetainID = IsLicenseDetian(Lic.LicenseID);
                LoadData(Lic.ApplicationID);
                lbShowLicenseHistory.Enabled = true;
                btnRelease.Enabled = true;
            }

            else
            {
                MessageBox.Show("Could Not Find ID With Number " + txtbxLocalLicID.Text + " !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to release this license?","Confirm",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BussinessLayer.clsDetain Detain1 = new BussinessLayer.clsDetain();
                Detain1 = Detain1.GetDetainLicByDetainID(_DetainID);
                BussinessLayer.clsPerson Person1 = new BussinessLayer.clsPerson();
                Person1 = BussinessLayer.clsPerson.FindPersonByNationalNumber(lbNationalNo.Text);
                BussinessLayer.clsApplications Application1 = new BussinessLayer.clsApplications();
                Application1.ApplicationDate = DateTime.Now;
                Application1.ApplicantPersonID = Person1.PersonID;
                Application1.ApplicationTypeID = 5;
                Application1.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
                Application1.LastStatusDate = DateTime.Now;
                Application1.PaidFees = Convert.ToInt32(lbTotalFees.Text);
                Application1.ApplicationStatus = BussinessLayer.clsApplications.enApplicationStatus.Completed;
                Application1.AddNewApplication();
                Detain1.ReleaseApplicationID = Application1.ApplicationID;
                Detain1.IsReleased = true;
                Detain1.ReleasedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
                Detain1.ReleaseDate = DateTime.Now;
                if (Detain1.UpdateDetain())
                {
                    MessageBox.Show("License released successfuly", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRelease.Enabled = false;
                    BussinessLayer.clsLicenses Lic = new BussinessLayer.clsLicenses();
                    Lic = Lic.GetLicenseByLicenseID(_LicenseID);
                    LoadData(Lic.ApplicationID);
                    lbApplicationID.Text = Application1.ApplicationID.ToString();
                }
                else
                {
                    MessageBox.Show("Failed to release license!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
            

        }
    }
}
