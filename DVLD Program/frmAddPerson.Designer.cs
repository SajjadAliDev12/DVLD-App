namespace DVLD_Program
{
    partial class frmAddPerson
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cobxCountry = new System.Windows.Forms.ComboBox();
            this.linklbRemove = new System.Windows.Forms.LinkLabel();
            this.linklbAddPhoto = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rdbuttonFemale = new System.Windows.Forms.RadioButton();
            this.rdbuttonMale = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.BirthDatepicker = new System.Windows.Forms.DateTimePicker();
            this.txtbxNationalNo = new System.Windows.Forms.TextBox();
            this.txtbxAddress = new System.Windows.Forms.TextBox();
            this.txtbxEmail = new System.Windows.Forms.TextBox();
            this.txtbxPhone = new System.Windows.Forms.TextBox();
            this.txtbxLastName = new System.Windows.Forms.TextBox();
            this.txtbxThirdName = new System.Windows.Forms.TextBox();
            this.txtbxSecondName = new System.Windows.Forms.TextBox();
            this.txtbxFirstName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPersonID = new System.Windows.Forms.Label();
            this.FileDialogPhoto = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(323, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New Person";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "PersonID :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cobxCountry);
            this.panel1.Controls.Add(this.linklbRemove);
            this.panel1.Controls.Add(this.linklbAddPhoto);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.rdbuttonFemale);
            this.panel1.Controls.Add(this.rdbuttonMale);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.BirthDatepicker);
            this.panel1.Controls.Add(this.txtbxNationalNo);
            this.panel1.Controls.Add(this.txtbxAddress);
            this.panel1.Controls.Add(this.txtbxEmail);
            this.panel1.Controls.Add(this.txtbxPhone);
            this.panel1.Controls.Add(this.txtbxLastName);
            this.panel1.Controls.Add(this.txtbxThirdName);
            this.panel1.Controls.Add(this.txtbxSecondName);
            this.panel1.Controls.Add(this.txtbxFirstName);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 303);
            this.panel1.TabIndex = 2;
            // 
            // cobxCountry
            // 
            this.cobxCountry.FormattingEnabled = true;
            this.cobxCountry.Location = new System.Drawing.Point(443, 138);
            this.cobxCountry.Name = "cobxCountry";
            this.cobxCountry.Size = new System.Drawing.Size(150, 21);
            this.cobxCountry.TabIndex = 30;
            // 
            // linklbRemove
            // 
            this.linklbRemove.AutoSize = true;
            this.linklbRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklbRemove.Location = new System.Drawing.Point(678, 264);
            this.linklbRemove.Name = "linklbRemove";
            this.linklbRemove.Size = new System.Drawing.Size(59, 16);
            this.linklbRemove.TabIndex = 29;
            this.linklbRemove.TabStop = true;
            this.linklbRemove.Text = "Remove";
            this.linklbRemove.Visible = false;
            this.linklbRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbRemove_LinkClicked);
            // 
            // linklbAddPhoto
            // 
            this.linklbAddPhoto.AutoSize = true;
            this.linklbAddPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklbAddPhoto.Location = new System.Drawing.Point(673, 234);
            this.linklbAddPhoto.Name = "linklbAddPhoto";
            this.linklbAddPhoto.Size = new System.Drawing.Size(70, 16);
            this.linklbAddPhoto.TabIndex = 28;
            this.linklbAddPhoto.TabStop = true;
            this.linklbAddPhoto.Text = "Add Photo";
            this.linklbAddPhoto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbAddPhoto_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Program.Properties.Resources.Male_512;
            this.pictureBox1.Location = new System.Drawing.Point(635, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox1_LoadCompleted);
            this.pictureBox1.VisibleChanged += new System.EventHandler(this.pictureBox1_VisibleChanged);
            // 
            // rdbuttonFemale
            // 
            this.rdbuttonFemale.AutoSize = true;
            this.rdbuttonFemale.Location = new System.Drawing.Point(201, 101);
            this.rdbuttonFemale.Name = "rdbuttonFemale";
            this.rdbuttonFemale.Size = new System.Drawing.Size(59, 17);
            this.rdbuttonFemale.TabIndex = 26;
            this.rdbuttonFemale.TabStop = true;
            this.rdbuttonFemale.Text = "Female";
            this.rdbuttonFemale.UseVisualStyleBackColor = true;
            // 
            // rdbuttonMale
            // 
            this.rdbuttonMale.AutoSize = true;
            this.rdbuttonMale.Checked = true;
            this.rdbuttonMale.Location = new System.Drawing.Point(110, 102);
            this.rdbuttonMale.Name = "rdbuttonMale";
            this.rdbuttonMale.Size = new System.Drawing.Size(48, 17);
            this.rdbuttonMale.TabIndex = 25;
            this.rdbuttonMale.TabStop = true;
            this.rdbuttonMale.Text = "Male";
            this.rdbuttonMale.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_Program.Properties.Resources.diskette;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(479, 238);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 44);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "     Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Program.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(358, 238);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 44);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // BirthDatepicker
            // 
            this.BirthDatepicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BirthDatepicker.Location = new System.Drawing.Point(443, 65);
            this.BirthDatepicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.BirthDatepicker.Name = "BirthDatepicker";
            this.BirthDatepicker.Size = new System.Drawing.Size(150, 20);
            this.BirthDatepicker.TabIndex = 22;
            // 
            // txtbxNationalNo
            // 
            this.txtbxNationalNo.Location = new System.Drawing.Point(110, 65);
            this.txtbxNationalNo.Name = "txtbxNationalNo";
            this.txtbxNationalNo.Size = new System.Drawing.Size(150, 20);
            this.txtbxNationalNo.TabIndex = 21;
            this.txtbxNationalNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtbxNationalNo_Validating);
            // 
            // txtbxAddress
            // 
            this.txtbxAddress.Location = new System.Drawing.Point(110, 172);
            this.txtbxAddress.Multiline = true;
            this.txtbxAddress.Name = "txtbxAddress";
            this.txtbxAddress.Size = new System.Drawing.Size(483, 60);
            this.txtbxAddress.TabIndex = 20;
            // 
            // txtbxEmail
            // 
            this.txtbxEmail.Location = new System.Drawing.Point(110, 135);
            this.txtbxEmail.Name = "txtbxEmail";
            this.txtbxEmail.Size = new System.Drawing.Size(150, 20);
            this.txtbxEmail.TabIndex = 19;
            // 
            // txtbxPhone
            // 
            this.txtbxPhone.Location = new System.Drawing.Point(443, 102);
            this.txtbxPhone.Name = "txtbxPhone";
            this.txtbxPhone.Size = new System.Drawing.Size(150, 20);
            this.txtbxPhone.TabIndex = 18;
            // 
            // txtbxLastName
            // 
            this.txtbxLastName.Location = new System.Drawing.Point(635, 30);
            this.txtbxLastName.Name = "txtbxLastName";
            this.txtbxLastName.Size = new System.Drawing.Size(150, 20);
            this.txtbxLastName.TabIndex = 17;
            // 
            // txtbxThirdName
            // 
            this.txtbxThirdName.Location = new System.Drawing.Point(460, 30);
            this.txtbxThirdName.Name = "txtbxThirdName";
            this.txtbxThirdName.Size = new System.Drawing.Size(150, 20);
            this.txtbxThirdName.TabIndex = 16;
            // 
            // txtbxSecondName
            // 
            this.txtbxSecondName.Location = new System.Drawing.Point(285, 30);
            this.txtbxSecondName.Name = "txtbxSecondName";
            this.txtbxSecondName.Size = new System.Drawing.Size(150, 20);
            this.txtbxSecondName.TabIndex = 15;
            // 
            // txtbxFirstName
            // 
            this.txtbxFirstName.Location = new System.Drawing.Point(110, 30);
            this.txtbxFirstName.Name = "txtbxFirstName";
            this.txtbxFirstName.Size = new System.Drawing.Size(150, 20);
            this.txtbxFirstName.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(355, 139);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 16);
            this.label14.TabIndex = 13;
            this.label14.Text = "Country :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(355, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 16);
            this.label13.TabIndex = 12;
            this.label13.Text = "Phone :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(355, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 16);
            this.label12.TabIndex = 11;
            this.label12.Text = "Date Of Birth :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "Address :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Email :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Gender :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "National No. :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(633, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Last";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(476, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Third";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(312, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Second";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(157, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "First";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name :";
            // 
            // lbPersonID
            // 
            this.lbPersonID.AutoSize = true;
            this.lbPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersonID.Location = new System.Drawing.Point(103, 47);
            this.lbPersonID.Name = "lbPersonID";
            this.lbPersonID.Size = new System.Drawing.Size(30, 16);
            this.lbPersonID.TabIndex = 3;
            this.lbPersonID.Text = "N/A";
            // 
            // FileDialogPhoto
            // 
            this.FileDialogPhoto.FileName = "openFileDialog1";
            this.FileDialogPhoto.Filter = "\"Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF\";";
            this.FileDialogPhoto.SupportMultiDottedExtensions = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddPerson
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(817, 389);
            this.Controls.Add(this.lbPersonID);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAddPerson";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Person";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbxNationalNo;
        private System.Windows.Forms.TextBox txtbxAddress;
        private System.Windows.Forms.TextBox txtbxEmail;
        private System.Windows.Forms.TextBox txtbxPhone;
        private System.Windows.Forms.TextBox txtbxLastName;
        private System.Windows.Forms.TextBox txtbxThirdName;
        private System.Windows.Forms.TextBox txtbxSecondName;
        private System.Windows.Forms.TextBox txtbxFirstName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker BirthDatepicker;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton rdbuttonFemale;
        private System.Windows.Forms.RadioButton rdbuttonMale;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbPersonID;
        private System.Windows.Forms.LinkLabel linklbRemove;
        private System.Windows.Forms.LinkLabel linklbAddPhoto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cobxCountry;
        private System.Windows.Forms.OpenFileDialog FileDialogPhoto;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}