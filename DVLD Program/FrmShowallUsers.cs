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
    public partial class FrmShowallUsers : Form
    {
        public FrmShowallUsers()
        {
            InitializeComponent();
            txtbxSearch.Visible = false;
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = DVLDBussinessLayer.BussinessLayer.clsUser.ShowAllUsers();
            lbCount.Text = dataGridView1.Rows.Count.ToString();
            
            
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "None")
                txtbxSearch.Visible = false;
            else txtbxSearch.Visible = true;
        }

        private void txtbxSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "FullName":
                    {
                        if (!string.IsNullOrWhiteSpace(txtbxSearch.Text))
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("FullName like '%{0}%'", txtbxSearch.Text);
                        }
                        else
                        {
                            LoadData();
                        }
                        break;
                    }
                case "Username":
                    {
                        if (!string.IsNullOrWhiteSpace(txtbxSearch.Text))
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Username like '%{0}%'", txtbxSearch.Text);
                        }
                        else
                        {
                            LoadData();
                        }
                        break;
                    }
                case "UserID":
                    {
                        if (!string.IsNullOrWhiteSpace(txtbxSearch.Text))
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(UserID , System.String) like '%{0}%'", txtbxSearch.Text);
                        }
                        else
                        {
                            LoadData();
                        }
                        break;
                    }
                case "PersonID":
                    {
                        if (!string.IsNullOrWhiteSpace(txtbxSearch.Text))
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(PersonID , System.String) like '%{0}%'", txtbxSearch.Text);
                        }
                        else
                        {
                            LoadData();
                        }
                        break;
                    }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FrmAddNewUser frm = new FrmAddNewUser();
            frm.ShowDialog();
            LoadData();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddNewUser frmAddNewUser = new FrmAddNewUser();
            frmAddNewUser.ShowDialog();
            LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonId = Convert.ToInt32( dataGridView1.CurrentRow.Cells[1].Value);
            FrmAddNewUser frm = new FrmAddNewUser(PersonId);
            frm.ShowDialog();
            LoadData();
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to delete User with User ID = " + dataGridView1.CurrentRow.Cells[0].Value + " ?","Confirm",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == DialogResult.Yes)
            {
               if( BussinessLayer.clsUser.DeleteUser(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value)))
                {
                    MessageBox.Show("User Deleted Succesfully!","Deleted",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadData();
                }
               else
                {
                    MessageBox.Show("Failed to delete user!","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
            }


        }

        private void showDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserInfoscreen frm = new FrmUserInfoscreen(Convert.ToInt32( dataGridView1.CurrentRow.Cells[1].Value));
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword frm = new FrmChangePassword(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value));
            frm.ShowDialog();
        }
    }
}
