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
    public partial class FrmDrivers : Form
    {
        public FrmDrivers()
        {
            InitializeComponent();
            dataGridView1.DataSource = BussinessLayer.clsDrivers.GetAllDriversData();
            lbRecorsCount.Text = dataGridView1.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
