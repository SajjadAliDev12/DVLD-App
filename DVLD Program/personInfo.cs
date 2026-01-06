using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Program
{
    public partial class usctrlpersonInfo : UserControl
    {
        
        public usctrlpersonInfo()
        {
            InitializeComponent();
            linkLabel1.Visible = false;

        }

        public void LoadData(int PersonID)
        {
            linkLabel1.Visible=true;
            BussinessLayer.clsPerson Person1 = new BussinessLayer.clsPerson();
            Person1 = BussinessLayer.clsPerson.FindPersonById(PersonID);
            if (Person1 != null)
            {
                lbPersonID.Text = Person1.PersonID.ToString();
                lbFullName.Text = Person1.FullName();
                lbNationalNo.Text = Person1.NationalNumber.ToString();
                lbPhone.Text = Person1.Phone.ToString();
                lbEmail.Text = Person1.Email.ToString();
                if (Person1.Gender == 0)
                {
                    lbGender.Text = "Male";
                }
                else
                {
                    lbGender.Text = "Female";
                }
                lbAddress.Text = Person1.Address.ToString();

                lbDateOfBirth.Text = Person1.BirthDate.ToShortDateString();
                if (Person1.PhotoPath == null)
                {
                    if (Person1.Gender == 0)
                        pictureBox1.Image = Properties.Resources.person_man__2_;
                    else
                        pictureBox1.Image = Properties.Resources.person_woman;
                }
                else
                {
                    pictureBox1.ImageLocation = Person1.PhotoPath;

                }
                lbCountry.Text = BussinessLayer.clsPerson.GetCountryByID(Person1.NationalityCountryID);
            }
            else
            {
                linkLabel1.Visible = false;
                lbPersonID.Text = "N/A";
                lbFullName.Text = "N/A";
                lbNationalNo.Text = "N/A";
                lbPhone.Text = "N/A";
                lbEmail.Text = "N/A";
                lbGender.Text = "N/A";
                lbAddress.Text = "N/A";

                lbDateOfBirth.Text = "N/A";
                pictureBox1.ImageLocation = "c";
                lbCountry.Text = "N/A";
            }
        }
        


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddPerson frm =  new frmAddPerson(Convert.ToInt32(lbPersonID.Text));
            frm.ShowDialog();
            LoadData(Convert.ToInt32(lbPersonID.Text));
        }
    }
}
