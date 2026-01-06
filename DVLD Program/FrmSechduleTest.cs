using DVLD_Program.Properties;
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
    public partial class FrmSechduleTest : Form
    {
        private object _sender;
        private int _ID;
        private bool _retake;
        
        BussinessLayer.clsApplications _clsApplications;
        public FrmSechduleTest(int ID,object sender,bool retake = false)
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Now;
            groupBox2.Enabled = false;
            _sender = sender;
            _retake = retake;
            _ID = ID;
            LoadData(ID);
        }

        private void LoadData(int ID)
        {
            BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
            Local = Local.GetLocalAppByAppID(ID);
            BussinessLayer.clsApplications App = new BussinessLayer.clsApplications();
            App = BussinessLayer.clsApplications.GetAppByAppID(ID);
            BussinessLayer.clsPerson Person1 = new BussinessLayer.clsPerson();
            Person1 = BussinessLayer.clsPerson.FindPersonById(App.ApplicantPersonID);
            lbDClass.Text = BussinessLayer.clsLicenseClass.GetClassNameByClassID(Local.LicenseClassID);
            lbDLAppID.Text = Local.LocalDrivingLicenseApplicationID.ToString();
            lbName.Text = Person1.FullName();
            if(_sender.ToString() == "Vision Test")
            {
                label1.Text = "Vision Test";
                lbFees.Text = "10";
                pictureBox1.Image = Resources.Vision_512;
            }
            else if(_sender.ToString() == "Written Test")
            {
                label1.Text = "Written Test";
                lbFees.Text = "20";
                pictureBox1.Image = Resources.Written_Test_512;
            }
            else
            {
                label1.Text = "Street Test";
                lbFees.Text = "35";
                pictureBox1.Image = Resources.driving_test_512;
            }
            if(_retake == true)
            {
                groupBox2.Enabled = true;
                BussinessLayer.clsApplications RetakeApp = new BussinessLayer.clsApplications();
                RetakeApp.ApplicationStatus = BussinessLayer.clsApplications.enApplicationStatus.New;
                RetakeApp.ApplicationDate = DateTime.Now;
                RetakeApp.ApplicantPersonID = App.ApplicantPersonID;
                RetakeApp.ApplicationTypeID = 7;
                RetakeApp.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
                RetakeApp.LastStatusDate = DateTime.Now;
                RetakeApp.PaidFees = 5;
                lbRetakeTestFees.Text = "5";
                lbTotalFees.Text = (int.Parse(lbFees.Text) + 5).ToString();
                RetakeApp.AddNewApplication();
                lbRetakeTestID.Text = RetakeApp.ApplicationID.ToString();
                _clsApplications = RetakeApp;
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsApplications applications = new BussinessLayer.clsApplications();
            applications = BussinessLayer.clsApplications.GetAppByAppID(_ID);
            BussinessLayer.ClsTestAppointments Appoin = new BussinessLayer.ClsTestAppointments();
            if (_sender.ToString() == "Vision Test")
            {
                Appoin.TestTypeID = 1;
            }
            else if (_sender.ToString() == "Written Test")
            {
                groupBox1.Text = "Written Test Appointement";
                Appoin.TestTypeID = 2;
            }
            else
            {
                groupBox1.Text = "Street Test Appointement";
                Appoin.TestTypeID= 3;
            }
            Appoin.LocalDrivingLicenseApplicationID = Convert.ToInt32(lbDLAppID.Text);
            Appoin.AppointmentDate = dateTimePicker1.Value;
            Appoin.PaidFees = Convert.ToInt32(lbFees.Text);
            Appoin.IsLocked = false;
            if(_retake ==  true)
            {
                Appoin.RetakeTestApplicationID = _clsApplications.ApplicationID;
            }
            else
                Appoin.RetakeTestApplicationID = null;

            
            Appoin.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
            if(Appoin.AddNewTestAppointement())
            {
                applications.LastStatusDate = DateTime.Now;
                applications.UpdateApplication();
                if(_retake)
                {
                    _clsApplications.LastStatusDate = DateTime.Now;
                    _clsApplications.ApplicationStatus = BussinessLayer.clsApplications.enApplicationStatus.Completed;
                    _clsApplications.UpdateApplication();
                }
                
                MessageBox.Show("Data Saved Succesfully!","Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(_ID);
                this.Close();
            }
            else
            {
                MessageBox.Show("Can not Add Appointement!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
