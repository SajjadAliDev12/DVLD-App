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
    public partial class FrmEditSechduleTest : Form
    {
        private int _TestAppID;
        private int _LocalAppID;
        public FrmEditSechduleTest(int LocalAppID,int TestAppoID)
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            groupBox2.Enabled = false;
            lbFees.Text = "10";
            _TestAppID = TestAppoID;
            _LocalAppID = LocalAppID;
            LoadData(LocalAppID);
        }

        private void LoadData(int ID)
        {
            BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
            Local = Local.GetLocalAppByAppID(ID);
            BussinessLayer.clsApplications App = new BussinessLayer.clsApplications();
            App = BussinessLayer.clsApplications.GetAppByAppID(ID);
            BussinessLayer.ClsTestAppointments Appoin = new BussinessLayer.ClsTestAppointments();
            Appoin = Appoin.GetTestAppByTestAppID(_TestAppID);
            if(Appoin != null)
            {
                dateTimePicker1.Value = Appoin.AppointmentDate;
            }
            BussinessLayer.clsPerson Person1 = new BussinessLayer.clsPerson();
            Person1 = BussinessLayer.clsPerson.FindPersonById(App.ApplicantPersonID);
            lbDClass.Text = BussinessLayer.clsLicenseClass.GetClassNameByClassID(Local.LicenseClassID);
            lbDLAppID.Text = Local.LocalDrivingLicenseApplicationID.ToString();
            lbName.Text = Person1.FullName();
            

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BussinessLayer.ClsTestAppointments Appoin = new BussinessLayer.ClsTestAppointments();
            Appoin.TestAppointmentID = _TestAppID;
            Appoin.TestTypeID = 1;
            Appoin.LocalDrivingLicenseApplicationID = Convert.ToInt32(lbDLAppID.Text);
            Appoin.AppointmentDate = dateTimePicker1.Value;
            Appoin.PaidFees = Convert.ToInt32(lbFees.Text);
            Appoin.IsLocked = false;
            Appoin.CreatedByUserID = BussinessLayer.clsGlobalUSer._User1.UserID;
            if (Appoin.UpdateTestAppontement(_TestAppID))
            {
                MessageBox.Show("Data Saved Succesfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(_LocalAppID);
            }
            else
            {
                MessageBox.Show("Can not Edit Appointement!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
