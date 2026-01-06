using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLDBussinessLayer;
using Microsoft.Win32;

namespace DVLD_Program
{
    public partial class frmLoginScreen : Form
    {
        string RegPath = @"HKEY_CURRENT_USER\Software\DVDL";
        string Key = "1234567890123456";
        public frmLoginScreen()
        {
            InitializeComponent();
            //StreamReader userInfo = new System.IO.StreamReader("UserInfo.txt");
            //string line;
            //List<string> lines = new List<string>();
            //while ((line = userInfo.ReadLine()) != null)
            //{
            //    lines.Add(line);
            //}
            //txtbxUserName.Text = lines[0];
            //txtbxPassword.Text = lines[1];
            //chcbxRemeberme.Checked = true;
            //userInfo.Close();
            
            string Username = Registry.GetValue(RegPath,"UserName",null)as string;
            string Password = Registry.GetValue(RegPath,"Password",null)as string;
            if(Username != null || Password != null)
            {
                txtbxUserName.Text = Username;
                txtbxPassword.Text = BussinessLayer.clsHashing.Decrypt(Password, Key);
                chcbxRemeberme.Checked = true;
            }
            else
            {
                chcbxRemeberme.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if((BussinessLayer.clsGlobalUSer._User1 = BussinessLayer.clsUser.FindUserByUserName(txtbxUserName.Text)) != null)
            {
                if(txtbxUserName.Text == BussinessLayer.clsGlobalUSer._User1.UserName && BussinessLayer.clsHashing.HashOutput(txtbxPassword.Text)== BussinessLayer.clsGlobalUSer._User1.Password && BussinessLayer.clsGlobalUSer._User1.isActive)
                {
                    string RegPath = @"HKEY_CURRENT_USER\Software\DVDL";
                    string UsernameValue = "UserName";
                    string UserNameData = txtbxUserName.Text;
                    string PasswordValue = "Password";
                    string PasswordData = BussinessLayer.clsHashing.Encrypt( txtbxPassword.Text,Key);
                    //StreamWriter sw = new StreamWriter("UserInfo.txt", false);
                    if (chcbxRemeberme.Checked)
                    {
                        //sw.WriteLine(txtbxUserName.Text);
                        //sw.WriteLine(txtbxPassword.Text);
                        Registry.SetValue(RegPath,UsernameValue, UserNameData,  RegistryValueKind.String);
                        Registry.SetValue(RegPath,PasswordValue, PasswordData,  RegistryValueKind.String);

                    }
                    else
                    {
                        Registry.SetValue(RegPath, UsernameValue, string.Empty, RegistryValueKind.String);
                        Registry.SetValue(RegPath, PasswordValue, string.Empty, RegistryValueKind.String);
                        //sw.WriteLine(string.Empty); sw.WriteLine(string.Empty);
                    }
                    //sw.Close();
                    this.Hide();
                    frmMainScreen frm = new frmMainScreen();
                    frm.ShowDialog();
                }
                else if(!BussinessLayer.clsGlobalUSer._User1.isActive)
                {
                    MessageBox.Show("Your Account is not active please contact the admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Wrong username / password !" , "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Wrong username / password !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
