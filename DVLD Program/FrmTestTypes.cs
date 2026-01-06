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
    public partial class FrmTestTypes : Form
    {
        public FrmTestTypes()
        {
            InitializeComponent();
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = BussinessLayer.clsTestTypes.GetAllTestTypes();
            lbCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditTestType frm = new FrmEditTestType(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            LoadData();
        }
    }
}
