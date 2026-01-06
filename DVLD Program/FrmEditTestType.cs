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
    public partial class FrmEditTestType : Form
    {
        public FrmEditTestType(int TestTypeID)
        {
            InitializeComponent();
            LoadData(TestTypeID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData(int TestTypeID)
        {
            BussinessLayer.clsTestTypes TestType = BussinessLayer.clsTestTypes.GetTestType(TestTypeID);
            if(TestType != null)
            {
                lbTestID.Text = TestTypeID.ToString();
                txtbxTitle.Text = TestType.TestTypeTitle;
                txtbxDesc.Text = TestType.TestTypeDescription;
                txtbxFees.Text = TestType.TestTypeFees.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(lbTestID.Text) , Fees = Convert.ToInt32(txtbxFees.Text);
            string Title = txtbxTitle.Text , Description = txtbxDesc.Text;
            if(string.IsNullOrEmpty(txtbxDesc.Text) || (string.IsNullOrEmpty(txtbxTitle.Text) || (string.IsNullOrEmpty(txtbxFees.Text))))
            {
                MessageBox.Show("You Have to Fill All Fileds!", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(BussinessLayer.clsTestTypes.EditTestType(ID,Title,Description,Fees))
                {
                    MessageBox.Show("Data Saved Succesfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(ID);
                }
                else
                {
                    MessageBox.Show("Data Save Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
