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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Program
{
    
    public partial class FrmVisionTest : Form
    {
        private BussinessLayer.clsLocalDrivingLecinse _Local1;
        private int _AppID;
        private object _sender;
        public FrmVisionTest(int AppID,object sender)
        {
            InitializeComponent();
            _AppID = AppID;
            _sender = sender;
            LoadData(AppID);
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData(int AppID)
        {
            BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
            Local = Local.GetLocalAppByAppID(AppID);
            _Local1 = Local;
            ucDrivingLecinseApplicationInfo1.LoadData(AppID);
            if(_sender.ToString() == "Vision Test")
            {
                 dataGridView1.DataSource = BussinessLayer.ClsTestAppointments.GetAllTestAppointmentsVision(Local.LocalDrivingLicenseApplicationID);
            }
                
            else if(_sender.ToString() == "Written Test")
            {
                label1.Text = "Written Test";
                pictureBox1.Image = Resources.Written_Test_512;
                dataGridView1.DataSource = BussinessLayer.ClsTestAppointments.GetAllTestAppointmentsWritten(Local.LocalDrivingLicenseApplicationID);
            }
            else
            {
                label1.Text = "Street Test";
                pictureBox1.Image = Resources.driving_test_512;
                dataGridView1.DataSource = BussinessLayer.ClsTestAppointments.GetAllTestAppointmentsStreet(Local.LocalDrivingLicenseApplicationID);
            }
                
            lbRecordsCount.Text = (dataGridView1.RowCount).ToString();
            if(dataGridView1 == null)
            {
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
            }
            else
            {
                contextMenuStrip1.Items[0].Enabled = true;
                contextMenuStrip1.Items[1].Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BussinessLayer.ClsTestAppointments TestAppointement1 = new BussinessLayer.ClsTestAppointments();
            TestAppointement1 = TestAppointement1.GetTestAppByLocalAppID(_Local1.LocalDrivingLicenseApplicationID);
            
            if(dataGridView1.RowCount != 0)
            {
                BussinessLayer.clsTests Test1 = new BussinessLayer.clsTests();
                TestAppointement1 = TestAppointement1.GetTestAppByTestAppID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.RowCount-1].Cells[0].Value));
                if((Test1 = Test1.GetTestByTestAppID(TestAppointement1.TestAppointmentID)) != null && Test1.TestResult == true)
                {
                    MessageBox.Show("Can not Add New Appointement Because the person already passed this test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(Test1 != null && Test1.TestResult == false)
                {
                    FrmSechduleTest frm = new FrmSechduleTest(Convert.ToInt32(_Local1.ApplicationID), _sender , true);
                    frm.ShowDialog();
                    LoadData(_AppID);
                }
                else if (!TestAppointement1.IsLocked)
                {
                    MessageBox.Show("Can not Add New Appointement Because there is an active appointement for this test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    FrmSechduleTest frm = new FrmSechduleTest(Convert.ToInt32(_Local1.ApplicationID),_sender);
                    frm.ShowDialog();
                    LoadData(_AppID);
                }
            }
            else if (TestAppointement1  != null)
            {
                if(!TestAppointement1.IsLocked)
                {
                    MessageBox.Show("Can not Add New Appointement Because there is an active appointement for this test","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    FrmSechduleTest frm = new FrmSechduleTest(Convert.ToInt32(_Local1.ApplicationID), _sender);
                    frm.ShowDialog();
                    LoadData(_AppID);
                }

            }
            else {  FrmSechduleTest frm = new FrmSechduleTest(Convert.ToInt32(_Local1.ApplicationID), _sender);
                frm.ShowDialog();
                LoadData(_AppID);
            }
           
        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.ClsTestAppointments Test1 = new BussinessLayer.ClsTestAppointments();
            if ((Test1 = Test1.GetTestAppByTestAppID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value))) != null)
            {
                if (Test1.IsLocked)
                {
                    MessageBox.Show("Can not Edit Appointement beacuse its locked!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    FrmEditSechduleTest frm = new FrmEditSechduleTest(_Local1.ApplicationID, Test1.TestAppointmentID);
                    frm.ShowDialog();
                    LoadData(_AppID);
                }
                
            }
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.ClsTestAppointments Test1 = new BussinessLayer.ClsTestAppointments();
            if ((Test1 = Test1.GetTestAppByTestAppID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value))) != null)
            {
                if (Test1.IsLocked)
                {
                    MessageBox.Show("Can not Take this test beacuse its locked!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                     FrmTakeTest frm = new FrmTakeTest(_Local1.ApplicationID, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                frm.ShowDialog();
                LoadData(_AppID);
                }
                
            }
        }
    }
}
