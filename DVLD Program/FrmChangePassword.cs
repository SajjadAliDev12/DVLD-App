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
    public partial class FrmChangePassword : Form
    {
        private BussinessLayer.clsPerson _person1 = null;
        private BussinessLayer.clsUser _User1 = null;
        public FrmChangePassword(int PersonID)
        {
            InitializeComponent();
            _person1 = BussinessLayer.clsPerson.FindPersonById(PersonID);
            _User1 = BussinessLayer.clsUser.FindUserByPersonID(PersonID);
            this.usctrlpersonInfo1.LoadData(PersonID);
            this.lbUserID.Text = _User1.UserID.ToString();
            this.lbUserName.Text = _User1.UserName.ToString();
            if(_User1.isActive)
            {
                lbIsActive.Text = "YES";
            }
            else
            {
                lbIsActive.Text = "NO";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if(BussinessLayer.clsHashing.HashOutput(txtbxCurrentPass.Text) != _User1.Password)
            {
                errorProvider1.SetError(txtbxCurrentPass, "Wrong Password");
                txtbxCurrentPass.Focus();
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtbxNewPass.Text != txtbxConfermPass.Text) 
            {
                MessageBox.Show("Password Not Match!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(string.IsNullOrEmpty(txtbxConfermPass.Text) || string.IsNullOrEmpty(txtbxNewPass.Text) || string.IsNullOrEmpty(txtbxCurrentPass.Text))
            {
                MessageBox.Show("You Must Fill All Filed!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
               if( BussinessLayer.clsUser.ChangePassword(_User1.UserID, BussinessLayer.clsHashing.HashOutput(txtbxNewPass.Text)))
                {
                    MessageBox.Show("Data Saved Succesfully!", "Password Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               else
                {
                    MessageBox.Show("Unable to change password!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
