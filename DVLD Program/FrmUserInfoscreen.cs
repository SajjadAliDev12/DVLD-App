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
    public partial class FrmUserInfoscreen : Form
    {
        private BussinessLayer.clsPerson _person1 = null;
        private BussinessLayer.clsUser _user1 = null;
        public FrmUserInfoscreen(int PersonID)
        {
            InitializeComponent();
            LoadData(PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData(int PersonID)
        {
            _user1 = BussinessLayer.clsUser.FindUserByPersonID(PersonID);
            this.usctrlpersonInfo1.LoadData(PersonID);
            this.lbUserID.Text = _user1.UserID.ToString();
            this.lbUserName.Text = _user1.UserName.ToString();
            if(_user1.isActive )
            {
                lbIsActive.Text = "YES";
            }
            else { lbIsActive.Text = "NO"; }
        }
    }
}
