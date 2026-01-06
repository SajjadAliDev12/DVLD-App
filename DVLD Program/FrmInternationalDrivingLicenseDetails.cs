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
    public partial class FrmInternationalDrivingLicenseDetails : Form
    {
        public FrmInternationalDrivingLicenseDetails(int InternationalLicenseID)
        {
            InitializeComponent();
            LoadData(InternationalLicenseID);
        }

        private void LoadData(int InternationalLicenseID)
        {
            BussinessLayer.clsInternationalLicense InterLic = new BussinessLayer.clsInternationalLicense();
            InterLic = InterLic.GetClsInternationalLicenseByID(InternationalLicenseID);
            BussinessLayer.clsApplications App1 = new BussinessLayer.clsApplications();
            App1 = BussinessLayer.clsApplications.GetAppByAppID(InterLic.ApplicationID);
            BussinessLayer.clsPerson Person1 = new BussinessLayer.clsPerson();
            Person1 = BussinessLayer.clsPerson.FindPersonById(App1.ApplicantPersonID);
            lbName.Text = Person1.FullName();
            lbInternationalLicID.Text = InternationalLicenseID.ToString();
            lbLocalLicID.Text = InterLic.IssuedUsingLocalLicenseID.ToString();
            lbNationalNo.Text = Person1.NationalNumber.ToString();
            if (Person1.Gender == 0)
                lbGender.Text = "Male";
            else
                lbGender.Text = "Female";
            lbIssueDate.Text = InterLic.IssueDate.ToString();
            
            if (InterLic.IsActive)
                lbIsActive.Text = "Yes";
            else
                lbIsActive.Text = "No";
            lbDateOfBirth.Text = Person1.BirthDate.ToString();
            lbDriverID.Text = InterLic.DriverID.ToString();
            lbExpDate.Text = InterLic.ExpirationDate.ToString();
            pictureBox2.ImageLocation = Person1.PhotoPath;
            lbApplicationID.Text = App1.ApplicationID.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
