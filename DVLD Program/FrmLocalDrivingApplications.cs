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
    public partial class FrmLocalDrivingApplications : Form
    {
        private BussinessLayer.clsApplications _clsApplication;
        
        public FrmLocalDrivingApplications()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgvApplications.DataSource = BussinessLayer.clsLocalDrivingLecinse.GetAllLocalDrivingApp();
            
            
            lbRecordsCount.Text = (dgvApplications.Rows.Count -1).ToString();
        }

        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            FrmNewLocalDrivingLecinse frm = new FrmNewLocalDrivingLecinse();
            frm.ShowDialog();
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                txtbxFilter.Enabled = false;
            }
            else
            {
                txtbxFilter.Enabled = true;
            }
        }

        private void txtbxFilter_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "FullName":
                    if (!string.IsNullOrWhiteSpace(txtbxFilter.Text))
                    {
                        (dgvApplications.DataSource as DataTable).DefaultView.RowFilter = string.Format("FullName like '%{0}%'", txtbxFilter.Text);
                    }
                    else
                    {
                        LoadData();
                    }
                    break;
                case "NationalNumber":
                    if (!string.IsNullOrWhiteSpace(txtbxFilter.Text))
                    {
                        (dgvApplications.DataSource as DataTable).DefaultView.RowFilter = string.Format("NationalNumber like '%{0}%'", txtbxFilter.Text);
                    }
                    else
                    {
                        LoadData();
                    }
                    break;
                case "Statues":
                    if (!string.IsNullOrWhiteSpace(txtbxFilter.Text))
                    {
                        (dgvApplications.DataSource as DataTable).DefaultView.RowFilter = string.Format("Statues like '%{0}%'", txtbxFilter.Text);
                    }
                    else
                    {
                        LoadData();
                    }
                    break;
                case "ClassName":
                    if (!string.IsNullOrWhiteSpace(txtbxFilter.Text))
                    {
                        (dgvApplications.DataSource as DataTable).DefaultView.RowFilter = string.Format("ClassName like '%{0}%'", txtbxFilter.Text);
                    }
                    else
                    {
                        LoadData();
                    }
                    break;
                case "LDLAppID":
                    {
                        if (!string.IsNullOrWhiteSpace(txtbxFilter.Text))
                        {
                            (dgvApplications.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(LDLAppID , System.String) like '%{0}%'", txtbxFilter.Text);
                        }
                        else
                        {
                            LoadData();
                        }
                        break;

                    }
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to cancel this application?","Confirm",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
                Local = Local.GetLocalAppByLocalAppID(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));
                _clsApplication = BussinessLayer.clsApplications.GetAppByAppID(Local.ApplicationID);
                if(_clsApplication.ApplicationStatus == BussinessLayer.clsApplications.enApplicationStatus.Completed)
                {
                    MessageBox.Show("This application is already completed","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else if (_clsApplication.ApplicationStatus == BussinessLayer.clsApplications.enApplicationStatus.Cancelled)
                {
                    MessageBox.Show("This application is already cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _clsApplication.ApplicationStatus = BussinessLayer.clsApplications.enApplicationStatus.Cancelled;
                    _clsApplication.LastStatusDate = DateTime.Now;
                    _clsApplication.UpdateApplication();
                    LoadData();
                    MessageBox.Show("Application Cancelled Successfully!","Cancelled",MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                
            }
            
        }

        

        private void showApplicationDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
            Local = Local.GetLocalAppByLocalAppID(Convert.ToInt32( dgvApplications.CurrentRow.Cells[0].Value));
            FrmShowApplicationDetailes frm = new FrmShowApplicationDetailes(Local.ApplicationID);
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            contextMenuStrip1.Items[9].Enabled = false;
            contextMenuStrip1.Items[10].Enabled = false;
            if(BussinessLayer.clsLocalDrivingLecinse.GetLocalAppPassedTest(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value)) == 0)
            {
                visionTestToolStripMenuItem.Enabled = true;
                writtenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = false;
            }
            else if(BussinessLayer.clsLocalDrivingLecinse.GetLocalAppPassedTest(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value)) == 1)
            {
                visionTestToolStripMenuItem.Enabled = false;
                writtenTestToolStripMenuItem.Enabled = true;
                streetTestToolStripMenuItem.Enabled = false;
            }
            else if(BussinessLayer.clsLocalDrivingLecinse.GetLocalAppPassedTest(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value)) == 2)
            {
                visionTestToolStripMenuItem.Enabled = false;
                writtenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[9].Enabled = true;
                contextMenuStrip1.Items[10].Enabled = true;
                visionTestToolStripMenuItem.Enabled = false;
                writtenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = false;
            }
            if (dgvApplications.CurrentRow.Cells[3].Value.ToString() == "Cancelled")
            {
                contextMenuStrip1.Items[2].Enabled = false;
                contextMenuStrip1.Items[3].Enabled = true;
                contextMenuStrip1.Items[5].Enabled = false;
                contextMenuStrip1.Items[7].Enabled = false;
            }
            else if(dgvApplications.CurrentRow.Cells[3].Value.ToString() == "Completed" )
            {
                contextMenuStrip1.Items[2].Enabled = false;
                contextMenuStrip1.Items[3].Enabled = false;
                contextMenuStrip1.Items[5].Enabled = false;
                contextMenuStrip1.Items[7].Enabled = false;
                contextMenuStrip1.Items[9].Enabled = false;
                contextMenuStrip1.Items[10].Enabled = true;

            }
            else
            {
                contextMenuStrip1.Items[2].Enabled = true;
                contextMenuStrip1.Items[3].Enabled = true;
                contextMenuStrip1.Items[5].Enabled = true;
                contextMenuStrip1.Items[7].Enabled = true;
                //contextMenuStrip1.Items[9].Enabled = false;

            }
                
            

            }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
            Local = Local.GetLocalAppByLocalAppID(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));
            FrmVisionTest frm = new FrmVisionTest(Local.ApplicationID,sender);
            frm.ShowDialog();
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
            Local = Local.GetLocalAppByLocalAppID(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));
            FrmVisionTest frm = new FrmVisionTest(Local.ApplicationID, sender);
            frm.ShowDialog();
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
            Local = Local.GetLocalAppByLocalAppID(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));
            FrmVisionTest frm = new FrmVisionTest(Local.ApplicationID, sender);
            frm.ShowDialog();
        }

        private void issueDrivingLecinseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIssueLocalDrivingLicenses frm = new FrmIssueLocalDrivingLicenses(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            LoadData();
        }

        private void showLecinseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsLocalDrivingLecinse localLicense = new BussinessLayer.clsLocalDrivingLecinse();
            localLicense = localLicense.GetLocalAppByLocalAppID(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));
            FrmShowLicenseDetailes frm = new FrmShowLicenseDetailes(localLicense.ApplicationID);
            frm.ShowDialog();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
            Local = Local.GetLocalAppByLocalAppID(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));
            BussinessLayer.clsApplications applications = new BussinessLayer.clsApplications();
            applications = BussinessLayer.clsApplications.GetAppByAppID(Local.ApplicationID);
            FrmLicenseHistory frm = new FrmLicenseHistory(applications.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsLocalDrivingLecinse Local = new BussinessLayer.clsLocalDrivingLecinse();
            Local = Local.GetLocalAppByLocalAppID(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));
            if(MessageBox.Show("Are you sure you want to delete application with ID = " + Local.ApplicationID +" ?" , "Confirm",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(BussinessLayer.clsLocalDrivingLecinse.DeleteLocalApplicationByApplicationID(Local.ApplicationID) && BussinessLayer.clsApplications.DeleteApplication(Local.ApplicationID))
                {
                    MessageBox.Show("Application with ID = " + Local.ApplicationID + " deleted succesfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Could not delete application with ID = " + Local.ApplicationID + " because it has data related to it!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

        
    
}
