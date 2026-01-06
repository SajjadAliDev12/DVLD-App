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
    public partial class FrmAddNewUser : Form
    {
        private BussinessLayer.clsPerson _Person1;
        private BussinessLayer.clsUser _User1;
        public FrmAddNewUser()
        {
            InitializeComponent();
        }
        public FrmAddNewUser(int PersonID)
        {
            
            InitializeComponent();

            this.groupBox1.Enabled = false;
            
            this.txtbxSearch.Text = PersonID.ToString();
            this.label1.Text = "Update User";
            _User1 = BussinessLayer.clsUser.FindUserByPersonID(PersonID);
            this.usctrlpersonInfo1.LoadData(PersonID);
            txtbxUserName.Text = _User1.UserName;
            txtbxPassword.Text = _User1.Password;
            txtbxConfirmPass.Text = _User1.Password;
            lbUserID.Text = _User1.UserID.ToString();
            if (_User1.isActive)
            {
                chkbxIsActive.Checked = true;
            }
            else { chkbxIsActive.Checked = false; }
            _Person1 = BussinessLayer.clsPerson.FindPersonById(PersonID);

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddPerson frmAddPerson = new frmAddPerson();
            frmAddPerson.DataBack += DatabackFrm2;
            frmAddPerson.ShowDialog();

        }
        private void DatabackFrm2(object sender , int PersonID)
        {
            _Person1 = BussinessLayer.clsPerson.FindPersonById(PersonID);
            this.usctrlpersonInfo1.LoadData(PersonID);
            this.txtbxSearch.Text = PersonID.ToString();
            this.comboBox1.SelectedIndex = 1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsPerson person1 = new BussinessLayer.clsPerson();
            if(string.IsNullOrEmpty(txtbxSearch.Text))
            {
                MessageBox.Show("You have to enter ID or NationalNo.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(comboBox1.SelectedIndex == 0)
            {
                person1 = BussinessLayer.clsPerson.FindPersonByNationalNumber(txtbxSearch.Text);
            }
            else
            {
                person1 = BussinessLayer.clsPerson.FindPersonById(Convert.ToInt32(txtbxSearch.Text));
            }

            if(person1 != null)
            {
                _Person1 = person1;
                if(BussinessLayer.clsUser.isUserExist(person1.PersonID))
                {
                    _User1 = BussinessLayer.clsUser.FindUserByPersonID(person1.PersonID);
                    txtbxUserName.Text = _User1.UserName;
                    txtbxPassword.Text = _User1.Password;
                    txtbxConfirmPass.Text = _User1.Password;
                    lbUserID.Text = _User1.UserID.ToString();
                    if(_User1.isActive)
                    {
                        chkbxIsActive.Checked = true;
                    }
                    else { chkbxIsActive.Checked = false; }
                }
                
                usctrlpersonInfo1.LoadData(person1.PersonID);
            }
            else
            {
                MessageBox.Show("Person does not exsist!","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                usctrlpersonInfo1.LoadData(0);
                label1.Text = "Add New User";
                lbUserID.Text = "N/A";
                txtbxConfirmPass.Text = string.Empty;
                txtbxPassword.Text = string.Empty;
                txtbxUserName.Text = string.Empty;
                _Person1 = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(_Person1 == null)
            {
                MessageBox.Show("Person Does Not Exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(BussinessLayer.clsUser.isUserExist(_Person1.PersonID))
            {
                MessageBox.Show("Person already have user please select another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BussinessLayer.clsUser user2 = new BussinessLayer.clsUser();
                user2 = BussinessLayer.clsUser.FindUserByPersonID(_Person1.PersonID);
                if(user2.isActive)
                {
                    chkbxIsActive.Checked = true;
                }
                else { chkbxIsActive.Checked = false; }
                txtbxUserName.Text = user2.UserName;
                txtbxPassword.Text = user2.Password;
                txtbxConfirmPass.Text = user2.Password;
                lbUserID.Text = user2.UserID.ToString();
                label1.Text = "Update User";
            }
            else
            {
                label1.Text = "Add New User";
                txtbxConfirmPass.Text = string.Empty; lbUserID.Text = "N/A";txtbxPassword.Text = string.Empty;txtbxUserName.Text = string.Empty;
                tabCtrlPersonInfo.SelectedIndex = 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtbxUserName.Text) && string.IsNullOrEmpty(txtbxPassword.Text) && string.IsNullOrEmpty(txtbxConfirmPass.Text)) 
            {
                MessageBox.Show("You have to enter all filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txtbxConfirmPass.Text != txtbxPassword.Text)
            {
                MessageBox.Show("Password not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(_Person1 == null)
            {
                MessageBox.Show("No Person Selected!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(BussinessLayer.clsUser.isUserExist(_Person1.PersonID))
            {
                BussinessLayer.clsUser User1 = new BussinessLayer.clsUser();
                
                

                User1.UserID = Convert.ToInt32(lbUserID.Text);
                User1.UserName = txtbxUserName.Text;
                User1.Password = txtbxPassword.Text;
                if (chkbxIsActive.Checked)
                {
                    User1.isActive = true;
                }
                else { User1.isActive = false; }
                User1.PersonID = _Person1.PersonID;
                User1.Mode = BussinessLayer.clsUser.enMode.Update;
                if (User1.Save())
                {
                    label1.Text = "Update Person";
                    lbUserID.Text = User1.UserID.ToString();
                    User1.Mode = BussinessLayer.clsUser.enMode.Update;
                    MessageBox.Show("Data Saved Succefully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Unable to Update user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                BussinessLayer.clsUser User1 = new BussinessLayer.clsUser();
                User1.UserName = txtbxUserName.Text;
                User1.Password = txtbxPassword.Text;
                if(chkbxIsActive.Checked)
                {
                    User1.isActive = true;
                }
                else { User1.isActive = false; }
                User1.PersonID = _Person1.PersonID;
                User1.Mode = BussinessLayer.clsUser.enMode.AddNew;
                if(User1.Save())
                {
                    label1.Text = "Update Person";
                    lbUserID.Text = User1.UserID.ToString();
                    User1.Mode = BussinessLayer.clsUser.enMode.Update;
                    MessageBox.Show("Data Saved Succefully!","Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Unable to add user","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void txtbxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                if ((!char.IsNumber(e.KeyChar)) && (!Char.IsControl(e.KeyChar)))
                    e.Handled = true;
            }
            else
            { e.Handled = false; }
        }
    }
}
