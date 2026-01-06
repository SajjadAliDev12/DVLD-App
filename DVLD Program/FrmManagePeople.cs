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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Program
{
    public partial class FrmManagePeople : Form
    {
        public FrmManagePeople()
        {
            InitializeComponent();
            LoadData();
            txtbxFilter.Visible = false;
        }

        private void LoadData()
        {
            
            dgvShowAllPeople.DataSource = DVLDBussinessLayer.BussinessLayer.clsPerson.ShowAllPeople();
            
            lbRecordsNumber.Text = dgvShowAllPeople.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void showDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID =Convert.ToInt32( dgvShowAllPeople.CurrentRow.Cells[0].Value);
            frmPersonDetailes frm = new frmPersonDetailes(PersonID);
            frm.ShowDialog();
            LoadData();
            
        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "None")
                txtbxFilter.Visible = false;
            else txtbxFilter.Visible = true;

        
        }

        private void txtbxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "PersonID" || comboBox1.SelectedItem.ToString() == "Phone")
            {
                if((!char.IsNumber(e.KeyChar)) && (!Char.IsControl(e.KeyChar)))
                    e.Handled = true;
            }
            else
            { e.Handled = false; }
        }

        private void txtbxFilter_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "FirstName":
                    if (!string.IsNullOrWhiteSpace(txtbxFilter.Text))
                    {
                        (dgvShowAllPeople.DataSource as DataTable).DefaultView.RowFilter = string.Format("FirstName like '%{0}%'", txtbxFilter.Text);
                    }
                    else
                    {
                        LoadData();
                    } break;

                case "SecondName":
                    if (!string.IsNullOrWhiteSpace(txtbxFilter.Text))
                    {
                        (dgvShowAllPeople.DataSource as DataTable).DefaultView.RowFilter = string.Format("SecondName like '%{0}%'", txtbxFilter.Text);
                    }
                    else
                    {
                        LoadData();
                    }
                    break;
                case "ThirdName":
                    if (!string.IsNullOrWhiteSpace(txtbxFilter.Text))
                    {
                        (dgvShowAllPeople.DataSource as DataTable).DefaultView.RowFilter = string.Format("ThirdName like '%{0}%'", txtbxFilter.Text);
                    }
                    else
                    {
                        LoadData();
                    }
                    break;
                case "LastName":
                    if (!string.IsNullOrWhiteSpace(txtbxFilter.Text))
                    {
                        (dgvShowAllPeople.DataSource as DataTable).DefaultView.RowFilter = string.Format("LastName like '%{0}%'", txtbxFilter.Text);
                    }
                    else
                    {
                        LoadData();
                    }
                    break;
                case "NationalNumber":
                    if (!string.IsNullOrWhiteSpace(txtbxFilter.Text))
                    {
                        (dgvShowAllPeople.DataSource as DataTable).DefaultView.RowFilter = string.Format("NationalNo like '%{0}%'", txtbxFilter.Text);
                    }
                    else
                    {
                        LoadData();
                    }
                    break;
                case "Email":
                    if (!string.IsNullOrWhiteSpace(txtbxFilter.Text))
                    {
                        (dgvShowAllPeople.DataSource as DataTable).DefaultView.RowFilter = string.Format("Email like '%{0}%'", txtbxFilter.Text);
                    }
                    else
                    {
                        LoadData();
                    }
                    break;
                case "PersonID":
                    {
                        if (!string.IsNullOrWhiteSpace(txtbxFilter.Text))
                        {
                            (dgvShowAllPeople.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(PersonID , System.String) like '%{0}%'", txtbxFilter.Text);
                        }
                        else
                        {
                            LoadData();
                        }
                        break;
                    }
                case "Phone":
                    if (!string.IsNullOrWhiteSpace(txtbxFilter.Text))
                    {
                        (dgvShowAllPeople.DataSource as DataTable).DefaultView.RowFilter = string.Format("Phone like '%{0}%'", txtbxFilter.Text);
                    }
                    else
                    {
                        LoadData();
                    }
                    break;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID =Convert.ToInt32( dgvShowAllPeople.CurrentRow.Cells[0].Value);
            if(MessageBox.Show("Are You Sure You Want To Delete Person With ID = " + PersonID, "Delete Person", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (DVLDBussinessLayer.BussinessLayer.clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("Person with ID = " + PersonID + " Deleted Succesfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                { MessageBox.Show("Unable to delete person with ID = " + PersonID + " because it has data attached to it!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadData();
                }
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddPerson frm = new frmAddPerson();
            frm.ShowDialog();
            LoadData();
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddPerson frm = new frmAddPerson();
            frm.ShowDialog();
            LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
          int PersonID =  Convert.ToInt32 (dgvShowAllPeople.CurrentRow.Cells[0].Value);
            frmAddPerson frm = new frmAddPerson(PersonID);
            frm.ShowDialog();
            LoadData();
            
            
        }
    }
}
