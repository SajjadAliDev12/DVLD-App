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
    public partial class FrmTakeTest : Form
    {
        private int _TestAppID;
        private BussinessLayer.ClsTestAppointments _Appoin;
        public FrmTakeTest(int LocalAppID , int TestAppID)
        {
            
            InitializeComponent();
            _TestAppID = TestAppID;
            LoadData(LocalAppID);
        }

        private void LoadData(int ID)
        {
            BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
            Local = Local.GetLocalAppByAppID(ID);
            BussinessLayer.clsApplications App = new BussinessLayer.clsApplications();
            App = BussinessLayer.clsApplications.GetAppByAppID(ID);
            _Appoin = new BussinessLayer.ClsTestAppointments();
            _Appoin = _Appoin.GetTestAppByTestAppID(_TestAppID);
            if (_Appoin != null)
            {
                lbDate.Text = _Appoin.AppointmentDate.ToString();
            }
            BussinessLayer.clsPerson Person1 = new BussinessLayer.clsPerson();
            Person1 = BussinessLayer.clsPerson.FindPersonById(App.ApplicantPersonID);
            lbDClass.Text = BussinessLayer.clsLicenseClass.GetClassNameByClassID(Local.LicenseClassID);
            lbDLAppID.Text = Local.LocalDrivingLicenseApplicationID.ToString();
            lbName.Text = Person1.FullName();
            lbFees.Text = _Appoin.PaidFees.ToString();


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsTests test1 = new BussinessLayer.clsTests();
            test1.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
            test1.TestAppointmentID = _TestAppID;
            if(rdbFail.Checked )
                test1.TestResult = false; else test1.TestResult = true;
            if(txtbxNotes.Text == null)
            {
                test1.Notes = "";
            }
            else
            {
                test1.Notes = txtbxNotes.Text;
            }
            if(MessageBox.Show("Are you sure you want to take this test ?\nThe result can not be changed later!","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
               if(test1.AddNewTest())
                {
                    _Appoin.IsLocked = true;
                    if(_Appoin.UpdateTestAppontement(_Appoin.TestAppointmentID))
                        MessageBox.Show("Data Saved Succesfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Data Save Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            
        }
    }
}
