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
    public partial class FrmEditApplicationType : Form
    {
        public FrmEditApplicationType(int ID)
        {
            InitializeComponent();
            LoadData(ID);
        }

        private void LoadData(int ID)
        {
            BussinessLayer.clsApplicationsTypes App = new BussinessLayer.clsApplicationsTypes();
            if ((App = BussinessLayer.clsApplicationsTypes.GetApplicationType(ID)) != null)
            {
                lbID.Text = App.ApplicationtypeId.ToString();
                txtbxTitle.Text = App.ApplicationName.ToString();
                txtbxFees.Text = App.Fees.ToString();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Fees = Convert.ToInt32(txtbxFees.Text);
            int ID = Convert.ToInt32(lbID.Text);
            if(string.IsNullOrEmpty(txtbxTitle.Text) || string.IsNullOrEmpty(txtbxFees.Text))
            {
                MessageBox.Show("You Have To Fill All Filed!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if(BussinessLayer.clsApplicationsTypes.EditApplicationType(ID, txtbxTitle.Text,Fees))
                {
                    MessageBox.Show("Data Saved Succesfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(ID);
                }
                else
                {
                    MessageBox.Show("Data save failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
