using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Program
{
    public partial class FrmNewLocalDrivingLecinse : Form
    {
        private BussinessLayer.clsPerson _Person1;
        private BussinessLayer.clsApplications _Applications1;
        private BussinessLayer.clsApplicationsTypes _ApplicationsTypes1;
        
        public FrmNewLocalDrivingLecinse()
        {
            InitializeComponent();
            _ApplicationsTypes1 = BussinessLayer.clsApplicationsTypes.GetApplicationType(1);
            LoadData();
        }
        private void LoadData()
        {
            DataTable dt = new DataTable();
            dt = BussinessLayer.clsLicenseClass.GetAllLicenseClass();
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr[1].ToString());
            }
            comboBox1.SelectedIndex = 2;
            lbApplicationDate.Text = DateTime.Now.ToShortDateString();
            LbCreatedByUser.Text = BussinessLayer.clsGlobalUSer._User1.UserName;
            lbApplicationFees.Text = _ApplicationsTypes1.Fees.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Person1 ==  null)
            {
                MessageBox.Show("You Have to chose a Person", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tabControl1.SelectedIndex = 1;

            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsPerson person1 = new BussinessLayer.clsPerson();
            if (string.IsNullOrEmpty(txtbxSearch.Text))
            {
                MessageBox.Show("You have to enter ID or NationalNo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox2.SelectedIndex == 0)
            {
                person1 = BussinessLayer.clsPerson.FindPersonByNationalNumber(txtbxSearch.Text);
                _Person1 = person1;
            }
            else
            {
                person1 = BussinessLayer.clsPerson.FindPersonById(Convert.ToInt32(txtbxSearch.Text));
                _Person1 = person1;
            }

            if (person1 != null)
            {
                usctrlpersonInfo1.LoadData(person1.PersonID);
            }
            else
            {
                MessageBox.Show("Person does not exsist!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usctrlpersonInfo1.LoadData(0);
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {

            frmAddPerson frmAddPerson = new frmAddPerson();
            frmAddPerson.DataBack += DatabackFrm2;
            frmAddPerson.ShowDialog();

        }
        private void DatabackFrm2(object sender, int PersonID)
        {
            _Person1 = BussinessLayer.clsPerson.FindPersonById(PersonID);
            this.usctrlpersonInfo1.LoadData(PersonID);
            this.txtbxSearch.Text = PersonID.ToString();
            this.comboBox2.SelectedIndex = 1;
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_Person1 ==  null)
            {
                MessageBox.Show("You Have to chose a Person", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(BussinessLayer.clsApplications.IsApplicationExistByPersonID(_Person1.PersonID))
            {
                
                if((LoadApplicationsData(_Person1.PersonID,comboBox1.SelectedIndex +1)) && (_Applications1.ApplicationStatus == BussinessLayer.clsApplications.enApplicationStatus.New) )
                {
                    MessageBox.Show("Person Already Have Active Application For The Same Class With ID = " + _Applications1.ApplicationID, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if((LoadApplicationsData(_Person1.PersonID, comboBox1.SelectedIndex + 1)) && (_Applications1.ApplicationStatus == BussinessLayer.clsApplications.enApplicationStatus.Completed))
                {
                    MessageBox.Show("Person Already Done this Application", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
                    
                    BussinessLayer.clsApplications applications = new BussinessLayer.clsApplications();
                    applications.ApplicationStatus = BussinessLayer.clsApplications.enApplicationStatus.New;
                    applications.ApplicationDate = DateTime.Now;
                    applications.PaidFees = float.Parse(lbApplicationFees.Text);
                    applications.ApplicantPersonID = _Person1.PersonID;
                    applications.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
                    applications.ApplicationTypeID = 1;
                    applications.LastStatusDate = DateTime.Now;
                    
                    if(applications.AddNewApplication() && Local.AddNewLocalLecinseApplication(applications.ApplicationID, Convert.ToInt32(comboBox1.SelectedIndex + 1)))
                    {
                        lbID.Text = applications.ApplicationID.ToString();
                        MessageBox.Show("Data Saved Succesfully","Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Data Save Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
                BussinessLayer.clsApplications applications = new BussinessLayer.clsApplications();
                applications.ApplicationStatus = BussinessLayer.clsApplications.enApplicationStatus.New;
                applications.ApplicationDate = DateTime.Now;
                applications.PaidFees = float.Parse(lbApplicationFees.Text);
                applications.ApplicantPersonID = _Person1.PersonID;
                applications.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
                applications.ApplicationTypeID = 1;
                applications.LastStatusDate = DateTime.Now;
                if (applications.AddNewApplication() && Local.AddNewLocalLecinseApplication(applications.ApplicationID, Convert.ToInt32(comboBox1.SelectedIndex + 1)))
                {
                    lbID.Text = applications.ApplicationID.ToString();
                    MessageBox.Show("Data Saved Succesfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data Save Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool LoadApplicationsData(int PersonID,int ApplicationTypeId )
        {
            BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
            
            List<BussinessLayer.clsApplications> apps = new List<BussinessLayer.clsApplications>();
            BussinessLayer.clsApplications applications = new BussinessLayer.clsApplications();
            DataTable dt = BussinessLayer.clsApplications.GetApplicationsByPersonID(PersonID);
            foreach (DataRow dtApp in dt.Rows)
            {
                applications = new BussinessLayer.clsApplications((int)dtApp[0], (int)dtApp[1], (DateTime)dtApp[2], (int)dtApp[3], short.Parse(dtApp[4].ToString()),(DateTime) dtApp[5],float.Parse( dtApp[6].ToString()), (int)dtApp[7]);
                apps.Add(applications);
            }
            foreach(BussinessLayer.clsApplications clsApplications in apps)
            {
                if(Local.GetLocalAppByAppID(clsApplications.ApplicationID) != null)
                    Local = Local.GetLocalAppByAppID(clsApplications.ApplicationID);
                if (Local == null && clsApplications.ApplicationTypeID == 7)
                    continue;
                else if (Local == null)
                {
                    _Applications1 = clsApplications;
                    return true;
                }
                if (Local.LicenseClassID == comboBox1.SelectedIndex+1)
                {
                    if(clsApplications.ApplicationStatus == BussinessLayer.clsApplications.enApplicationStatus.Cancelled)
                    {
                        continue;
                    }
                    else
                    {
                        _Applications1 = clsApplications;
                        return true;
                    }
                    
                }
                
            }
            return false;

        }

        private void txtbxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox2.SelectedIndex == 1)
            {
                if ((!char.IsNumber(e.KeyChar)) && (!Char.IsControl(e.KeyChar)))
                    e.Handled = true;
            }
            else
            { e.Handled = false; }
        }
    }
}

