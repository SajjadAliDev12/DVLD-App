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
    public partial class FrmShowApplicationDetailes : Form
    {
        public FrmShowApplicationDetailes(int ApplicationID)
        {
            InitializeComponent();
            this.ucDrivingLecinseApplicationInfo1.LoadData(ApplicationID);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
