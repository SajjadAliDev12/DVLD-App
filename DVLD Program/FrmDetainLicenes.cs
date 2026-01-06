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
    public partial class FrmDetainLicenes : Form
    {
        private int _LicenseID;
        public FrmDetainLicenes()
        {
            InitializeComponent();
            btnDetain.Enabled = false;
            lbShowLicense.Enabled = false;
            lbShowLicenseHistory.Enabled = false;
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

        private void lbShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lbLicenseID.Text != "N/A")
            {
                FrmShowLicenseDetailes frm = new FrmShowLicenseDetailes(Convert.ToInt32(lbLicenseID.Text));
                frm.ShowDialog();
            }
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
            if (IsLicenseDetian(licenses.LicenseID) != 0)
                lbIsDitain.Text = "Yes";
            else
                lbIsDitain.Text = "No";
            _LicenseID = licenses.LicenseID;
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
            
            else if ((Lic = Lic.GetLicenseByLicenseID(Convert.ToInt32(txtbxLocalLicID.Text))) != null)
            {
                LoadData(Lic.ApplicationID);
                lbShowLicenseHistory.Enabled = true;
                btnDetain.Enabled = true;
            }

            else
            {
                MessageBox.Show("Could Not Find ID With Number " + txtbxLocalLicID.Text + " !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int IsLicenseDetian(int licenseID)
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
        private void btnDetain_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsDetain Detain1 = new BussinessLayer.clsDetain();
            Detain1.DetainDate = DateTime.Now;
            Detain1.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
            if(string.IsNullOrEmpty(txtbxFineFees.Text))
            {
                MessageBox.Show("You have to enter fees!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                Detain1.FineFees =Convert.ToInt32( txtbxFineFees.Text);
            Detain1.IsReleased = false;
            Detain1.LicenseID = Convert.ToInt32(lbLicenseID.Text);
            Detain1.ReleaseApplicationID = null;
            Detain1.ReleaseDate = null;
            Detain1.ReleasedByUserID = null;
            if(MessageBox.Show("Are you sure you want to detain this license?","Confirm",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(IsLicenseDetian(_LicenseID) !=0)
                {
                    MessageBox.Show("this license already detained choose another one!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(Detain1.AddNewDetain())
                {
                    lbDetainID.Text = Detain1.DetainID.ToString();
                    lbIsDitain.Text = "Yes";
                    btnDetain.Enabled = false;
                    MessageBox.Show("Data Saved Successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Can not detain license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtbxFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!Char.IsControl(e.KeyChar)))
                e.Handled = true;
            else
            { e.Handled = false; }
        }
    }
}
