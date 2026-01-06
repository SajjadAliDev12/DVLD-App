namespace DVLD_Program
{
    partial class FrmAddNewUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tabCtrlPersonInfo = new System.Windows.Forms.TabControl();
            this.PersonInfoTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbxSearch = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.usctrlpersonInfo1 = new DVLD_Program.usctrlpersonInfo();
            this.button2 = new System.Windows.Forms.Button();
            this.LoginInfoTab = new System.Windows.Forms.TabPage();
            this.lbUserID = new System.Windows.Forms.Label();
            this.txtbxConfirmPass = new System.Windows.Forms.TextBox();
            this.txtbxPassword = new System.Windows.Forms.TextBox();
            this.txtbxUserName = new System.Windows.Forms.TextBox();
            this.chkbxIsActive = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabCtrlPersonInfo.SuspendLayout();
            this.PersonInfoTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.LoginInfoTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(446, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New User";
            // 
            // tabCtrlPersonInfo
            // 
            this.tabCtrlPersonInfo.Controls.Add(this.PersonInfoTab);
            this.tabCtrlPersonInfo.Controls.Add(this.LoginInfoTab);
            this.tabCtrlPersonInfo.Location = new System.Drawing.Point(12, 90);
            this.tabCtrlPersonInfo.Name = "tabCtrlPersonInfo";
            this.tabCtrlPersonInfo.SelectedIndex = 0;
            this.tabCtrlPersonInfo.Size = new System.Drawing.Size(971, 505);
            this.tabCtrlPersonInfo.TabIndex = 1;
            // 
            // PersonInfoTab
            // 
            this.PersonInfoTab.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PersonInfoTab.Controls.Add(this.groupBox1);
            this.PersonInfoTab.Controls.Add(this.usctrlpersonInfo1);
            this.PersonInfoTab.Controls.Add(this.button2);
            this.PersonInfoTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonInfoTab.Location = new System.Drawing.Point(4, 22);
            this.PersonInfoTab.Name = "PersonInfoTab";
            this.PersonInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.PersonInfoTab.Size = new System.Drawing.Size(963, 479);
            this.PersonInfoTab.TabIndex = 0;
            this.PersonInfoTab.Text = "Personal Info";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbxSearch);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.btnAddPerson);
            this.groupBox1.Location = new System.Drawing.Point(7, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(939, 73);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // txtbxSearch
            // 
            this.txtbxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxSearch.Location = new System.Drawing.Point(358, 30);
            this.txtbxSearch.Name = "txtbxSearch";
            this.txtbxSearch.Size = new System.Drawing.Size(233, 24);
            this.txtbxSearch.TabIndex = 4;
            this.txtbxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxSearch_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "National No.",
            "Person ID"});
            this.comboBox1.Location = new System.Drawing.Point(98, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(229, 24);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By :";
            // 
            // btnFind
            // 
            this.btnFind.Image = global::DVLD_Program.Properties.Resources.SearchPerson;
            this.btnFind.Location = new System.Drawing.Point(829, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(49, 49);
            this.btnFind.TabIndex = 1;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Image = global::DVLD_Program.Properties.Resources.Add_Person_40;
            this.btnAddPerson.Location = new System.Drawing.Point(884, 14);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(49, 49);
            this.btnAddPerson.TabIndex = 0;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // usctrlpersonInfo1
            // 
            this.usctrlpersonInfo1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.usctrlpersonInfo1.Location = new System.Drawing.Point(9, 123);
            this.usctrlpersonInfo1.Margin = new System.Windows.Forms.Padding(5);
            this.usctrlpersonInfo1.Name = "usctrlpersonInfo1";
            this.usctrlpersonInfo1.Size = new System.Drawing.Size(1265, 407);
            this.usctrlpersonInfo1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.Image = global::DVLD_Program.Properties.Resources.Next_32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(836, 438);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 35);
            this.button2.TabIndex = 0;
            this.button2.Text = "    Next";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoginInfoTab
            // 
            this.LoginInfoTab.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LoginInfoTab.Controls.Add(this.lbUserID);
            this.LoginInfoTab.Controls.Add(this.txtbxConfirmPass);
            this.LoginInfoTab.Controls.Add(this.txtbxPassword);
            this.LoginInfoTab.Controls.Add(this.txtbxUserName);
            this.LoginInfoTab.Controls.Add(this.chkbxIsActive);
            this.LoginInfoTab.Controls.Add(this.label6);
            this.LoginInfoTab.Controls.Add(this.label5);
            this.LoginInfoTab.Controls.Add(this.label4);
            this.LoginInfoTab.Controls.Add(this.label3);
            this.LoginInfoTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginInfoTab.Location = new System.Drawing.Point(4, 22);
            this.LoginInfoTab.Name = "LoginInfoTab";
            this.LoginInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.LoginInfoTab.Size = new System.Drawing.Size(963, 479);
            this.LoginInfoTab.TabIndex = 1;
            this.LoginInfoTab.Text = "Login Info";
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.Location = new System.Drawing.Point(187, 79);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(30, 16);
            this.lbUserID.TabIndex = 8;
            this.lbUserID.Text = "N/A";
            // 
            // txtbxConfirmPass
            // 
            this.txtbxConfirmPass.Location = new System.Drawing.Point(187, 171);
            this.txtbxConfirmPass.Name = "txtbxConfirmPass";
            this.txtbxConfirmPass.PasswordChar = '*';
            this.txtbxConfirmPass.Size = new System.Drawing.Size(189, 22);
            this.txtbxConfirmPass.TabIndex = 7;
            // 
            // txtbxPassword
            // 
            this.txtbxPassword.Location = new System.Drawing.Point(187, 139);
            this.txtbxPassword.Name = "txtbxPassword";
            this.txtbxPassword.PasswordChar = '*';
            this.txtbxPassword.Size = new System.Drawing.Size(189, 22);
            this.txtbxPassword.TabIndex = 6;
            // 
            // txtbxUserName
            // 
            this.txtbxUserName.Location = new System.Drawing.Point(187, 106);
            this.txtbxUserName.Name = "txtbxUserName";
            this.txtbxUserName.Size = new System.Drawing.Size(189, 22);
            this.txtbxUserName.TabIndex = 5;
            // 
            // chkbxIsActive
            // 
            this.chkbxIsActive.AutoSize = true;
            this.chkbxIsActive.Location = new System.Drawing.Point(186, 199);
            this.chkbxIsActive.Name = "chkbxIsActive";
            this.chkbxIsActive.Size = new System.Drawing.Size(80, 20);
            this.chkbxIsActive.TabIndex = 4;
            this.chkbxIsActive.Text = "IsActive?";
            this.chkbxIsActive.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Confirm Password :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "UserName :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "User ID :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Window;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_Program.Properties.Resources.diskette;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(852, 601);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 39);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "    Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DVLD_Program.Properties.Resources.close__1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(724, 601);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "    Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmAddNewUser
            // 
            this.AcceptButton = this.btnFind;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(998, 652);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabCtrlPersonInfo);
            this.Controls.Add(this.label1);
            this.Name = "FrmAddNewUser";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAddNewUser";
            this.tabCtrlPersonInfo.ResumeLayout(false);
            this.PersonInfoTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.LoginInfoTab.ResumeLayout(false);
            this.LoginInfoTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabCtrlPersonInfo;
        private System.Windows.Forms.TabPage PersonInfoTab;
        private System.Windows.Forms.TabPage LoginInfoTab;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbUserID;
        private System.Windows.Forms.TextBox txtbxConfirmPass;
        private System.Windows.Forms.TextBox txtbxPassword;
        private System.Windows.Forms.TextBox txtbxUserName;
        private System.Windows.Forms.CheckBox chkbxIsActive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtbxSearch;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnAddPerson;
        private usctrlpersonInfo usctrlpersonInfo1;
    }
}