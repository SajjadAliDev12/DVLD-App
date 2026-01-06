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
    public partial class FrmListDetainedLicenses : Form
    {
        public FrmListDetainedLicenses()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = BussinessLayer.clsDetain.GetAllDetainedLicenses();
            lbRecordsCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewDetain_Click(object sender, EventArgs e)
        {
            FrmDetainLicenes frm = new FrmDetainLicenes();
            frm.ShowDialog();
            LoadData();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt16(dataGridView1.CurrentRow.Cells[3].Value) == 1)
            {
                contextMenuStrip1.Items[4].Enabled = false;
            }
            else
                contextMenuStrip1.Items[4].Enabled=true;
        }

        private void showPersonDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsPerson person1 = new BussinessLayer.clsPerson();
            person1 = BussinessLayer.clsPerson.FindPersonByNationalNumber(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            frmPersonDetailes frm = new frmPersonDetailes(person1.PersonID);
            frm.ShowDialog();
        }

        private void showicenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsLicenses Lic = new BussinessLayer.clsLicenses();
            Lic = Lic.GetLicenseByLicenseID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value));
            FrmShowLicenseDetailes frm = new FrmShowLicenseDetailes(Lic.ApplicationID);
            frm.ShowDialog();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BussinessLayer.clsPerson person1 = new BussinessLayer.clsPerson();
            person1 = BussinessLayer.clsPerson.FindPersonByNationalNumber(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            FrmLicenseHistory frm = new FrmLicenseHistory(person1.PersonID);
            frm.ShowDialog();
        }

        private void btnNewRelease_Click(object sender, EventArgs e)
        {
            FrmReleaseDetainLic frm = new FrmReleaseDetainLic();
            frm.ShowDialog();
            LoadData();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReleaseDetainLic frm = new FrmReleaseDetainLic(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value));
            frm.ShowDialog();
            LoadData();
        }
    }
}
