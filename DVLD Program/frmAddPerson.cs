using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Program
{
    public partial class frmAddPerson : Form
    {
        public delegate void DataBackHandler(object sender, int PersonID);
        public event DataBackHandler DataBack;
        private int _PersonId = 0;
        public frmAddPerson()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt = BussinessLayer.clsPerson.GetAllCountry();
            foreach (DataRow dr in dt.Rows)
            {
                cobxCountry.Items.Add(dr[0].ToString());
            }
            cobxCountry.SelectedIndex = 82;
            
            BirthDatepicker.MaxDate = DateTime.Now.AddYears(-18);
            
            
        }

        public frmAddPerson(int personID)
        {
            _PersonId = personID;
            InitializeComponent();
            DataTable dt = new DataTable();
            dt = BussinessLayer.clsPerson.GetAllCountry();
            foreach (DataRow dr in dt.Rows)
            {
                cobxCountry.Items.Add(dr[0].ToString());
            }
            //BirthDatepicker.MaxDate = DateTime.Now.AddYears(-18);
            BussinessLayer.clsPerson person1 = new BussinessLayer.clsPerson();
            person1 = BussinessLayer.clsPerson.FindPersonById(personID);
            if(person1 != null)
            {
                label1.Text = "Update Person";
                lbPersonID.Text = person1.PersonID.ToString();
                txtbxFirstName.Text = person1.FirstName;
                txtbxSecondName.Text = person1.SecondName;
                txtbxThirdName.Text = person1.ThirdName;
                txtbxLastName.Text = person1.LastName;
                txtbxNationalNo.Text = person1.NationalNumber;
                cobxCountry.SelectedIndex = person1.NationalityCountryID - 1;
                txtbxEmail.Text = person1.Email;
                txtbxPhone.Text = person1.Phone;
                txtbxAddress.Text = person1.Address;
                pictureBox1.ImageLocation = person1.PhotoPath;
                BirthDatepicker.Value = person1.BirthDate;
                if(person1.Gender == 0)
                {
                    rdbuttonMale.Select();
                }
                else
                {
                    rdbuttonFemale.Select();
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_VisibleChanged(object sender, EventArgs e)
        {
            linklbRemove.Visible = true;
        }

        private void linklbRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = "C";
            BussinessLayer.clsPerson Person1 = BussinessLayer.clsPerson.FindPersonById(_PersonId);
            Person1.PhotoPath = pictureBox1.ImageLocation;
            linklbRemove.Visible=false;
        }

        private void linklbAddPhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            if (FileDialogPhoto.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = FileDialogPhoto.FileName;
                
            }
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            linklbRemove.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbxFirstName.Text))
            {
                errorProvider1.SetError(txtbxFirstName, "You must type first name!");

            }
            if (string.IsNullOrEmpty(txtbxSecondName.Text))
            {
                errorProvider1.SetError(txtbxSecondName, "You must type second name!");
            }
            if (string.IsNullOrEmpty(txtbxThirdName.Text))
            {
                errorProvider1.SetError(txtbxThirdName, "You must type third name!");
            }
            if (string.IsNullOrEmpty(txtbxLastName.Text))
            {
                errorProvider1.SetError(txtbxLastName, "You must type last name!");
            }
            if (string.IsNullOrEmpty(txtbxEmail.Text))
            {
                errorProvider1.SetError(txtbxEmail, "You must type email!");
            }
            if (string.IsNullOrEmpty(txtbxPhone.Text))
            {
                errorProvider1.SetError(txtbxPhone, "You must type phone!");
            }

            if (string.IsNullOrEmpty(txtbxNationalNo.Text))
            {
                errorProvider1.SetError(txtbxNationalNo, "You must type NationalNo.!");

            }
            if (string.IsNullOrEmpty(txtbxAddress.Text))
            {
                errorProvider1.SetError(txtbxAddress, "You must type Address!");
                txtbxAddress.Focus();
            }
            BussinessLayer.clsPerson person1 = new BussinessLayer.clsPerson();
            if (_PersonId != 0)
            {
                person1 = BussinessLayer.clsPerson.FindPersonById(_PersonId);
                person1.enMode = BussinessLayer.enMode.Update;
            }
            else
            {
                person1.enMode = BussinessLayer.enMode.AddNew;
            }


            
            person1.FirstName = txtbxFirstName.Text;
            person1.SecondName = txtbxSecondName.Text;
            person1.ThirdName = txtbxThirdName.Text;
            person1.LastName = txtbxLastName.Text;
            person1.Email = txtbxEmail.Text;
            person1.Phone = txtbxPhone.Text;
            person1.NationalNumber = txtbxNationalNo.Text;
            person1.PhotoPath = pictureBox1.ImageLocation;
            person1.BirthDate = BirthDatepicker.Value;
            person1.Address = txtbxAddress.Text;
            
            if (rdbuttonMale.Checked)
                person1.Gender = 0;
            else
                person1.Gender = 1;
            person1.NationalityCountryID = cobxCountry.SelectedIndex + 1;
            
            if(person1.Save())
            {
                DataBack?.Invoke(this, person1.PersonID);
                lbPersonID.Text = person1.PersonID.ToString();
                MessageBox.Show("Data Saved Succesfully","Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("You have to fill all fileds","Failed",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
        }

        private void txtbxNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if(BussinessLayer.clsPerson.IsPersonExist(txtbxNationalNo.Text))
            {
                errorProvider1.SetError(txtbxNationalNo, "National number already in use!");
                txtbxNationalNo.Focus();
                btnSave.Enabled = false;
            }
            else 
            {
                btnSave.Enabled = true;
            }
            
        }

       
    }
}
