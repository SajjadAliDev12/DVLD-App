using DVLDBussinessLayer;
using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Program
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class usCnFilter : System.Windows.Forms.UserControl
    {
        private BussinessLayer.clsPerson _Person1;
        public usCnFilter()
        {
            InitializeComponent();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddPerson frmAddPerson = new frmAddPerson();
            frmAddPerson.DataBack += DatabackFrm2;
            frmAddPerson.ShowDialog();
        }
        private void DatabackFrm2(object sender, int PersonID)
        {
            _Person1 = BussinessLayer.clsPerson.FindPersonById(PersonID);
            this.txtbxSearch.Text = PersonID.ToString();
            this.comboBox1.SelectedIndex = 1;
            usctrlpersonInfo1.LoadData(_Person1.PersonID);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsPerson person1 = new BussinessLayer.clsPerson();
            if (string.IsNullOrEmpty(txtbxSearch.Text))
            {
                MessageBox.Show("You have to enter ID or NationalNo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                person1 = BussinessLayer.clsPerson.FindPersonByNationalNumber(txtbxSearch.Text);
                
            }
            else
            {
                person1 = BussinessLayer.clsPerson.FindPersonById(Convert.ToInt32(txtbxSearch.Text));
                
            }

            if (person1 != null)
            {
                _Person1 = person1;
                if (BussinessLayer.clsUser.isUserExist(person1.PersonID))
                {
                    usctrlpersonInfo1.LoadData(person1.PersonID);
                }

                usctrlpersonInfo1.LoadData(person1.PersonID);
            }
            else
            {
                MessageBox.Show("Person does not exsist!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
