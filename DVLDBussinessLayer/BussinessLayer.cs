using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DVLDDataLayer;

namespace DVLDBussinessLayer
{
    public class BussinessLayer
    {
        public enum enMode { AddNew, Update };

        public class clsPerson
        {
            public int PersonID { get; set; }
            public string NationalNumber { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string ThirdName { get; set; }
            public string LastName { get; set; }

            public string FullName()
            { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
            public DateTime BirthDate { get; set; }
            public short Gender { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public int NationalityCountryID { get; set; }
            public string PhotoPath { get; set; }

            

            public enMode enMode = enMode.Update;

            public clsPerson(int personID, string firstName, string secondName, string thirdName, string lastName, string nationalNumber, short gender, DateTime birthDate, string Email, string address, string phone, string photoPath, int NationalityCountryID)
            {
                this.PersonID = personID;
                this.FirstName = firstName;
                this.SecondName = secondName;
                this.ThirdName = thirdName;
                this.LastName = lastName;
                this.NationalNumber = nationalNumber;
                this.Gender = gender;
                this.BirthDate = birthDate;
                this.Address = address;
                this.Email = Email;
                this.Phone = phone;
                this.PhotoPath = photoPath;
                this.enMode = enMode.Update;
                this.NationalityCountryID = NationalityCountryID;
            }

            public clsPerson()
            {
                this.PersonID = -1;
                this.FirstName = "";
                this.SecondName = "";
                this.ThirdName = "";
                this.LastName = "";
                this.NationalNumber = "";
                this.Gender = 0;
                this.BirthDate = DateTime.Now;
                this.Address = "";
                this.Email = "";
                this.Phone = "";
                this.PhotoPath = "";
                this.NationalityCountryID = 0;
                this.enMode = enMode.AddNew;
            }
            public static clsPerson FindPersonById(int PerosnID)
            {
                string firstName = "", secondName = "", thirdName = "", LastName = "", nationalNumber = "", address = "", email = "", phone = "", photoPath = "";
                short gender = 0;
                int NationalityCountryID = 0;
                DateTime birthDate = DateTime.Now;
                if (DVLDDataLayer.DataLayer.GetPersonInfoByID(PerosnID, ref firstName, ref secondName, ref thirdName, ref LastName, ref nationalNumber, ref gender, ref birthDate, ref email, ref address, ref phone, ref photoPath, ref NationalityCountryID))
                {
                    return new clsPerson(PerosnID, firstName, secondName, thirdName, LastName, nationalNumber, gender, birthDate, email, address, phone, photoPath, NationalityCountryID);
                }
                else { return null; }
            }

            public static clsPerson FindPersonByNationalNumber(string NationalNumber)
            {
                int PersonID = 0;
                string firstName = "", secondName = "", thirdName = "", LastName = "", address = "", email = "", phone = "", photoPath = "";
                short gender = 0;
                int NationalityCountryID = 0;
                DateTime birthDate = DateTime.Now;
                if (DVLDDataLayer.DataLayer.GetPersonInfoByNationalNumber(ref PersonID, ref firstName, ref secondName, ref thirdName, ref LastName, NationalNumber, ref gender, ref birthDate, ref email, ref address, ref phone, ref photoPath, ref NationalityCountryID))
                {
                    return new clsPerson(PersonID, firstName, secondName, thirdName, LastName, NationalNumber, gender, birthDate, email, address, phone, photoPath, NationalityCountryID);
                }
                else
                { return null; };
            }

            private bool _AddNewPerson()
            {

                this.PersonID = DVLDDataLayer.DataLayer.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNumber, this.Gender, this.BirthDate,
                   this.Email, this.Address, this.Phone, this.PhotoPath, this.NationalityCountryID);
                this.enMode = enMode.Update;
                return this.PersonID != -1;
            }

            private bool _UpdatPerson()
            {
                return DVLDDataLayer.DataLayer.UpdatePerson(this.PersonID, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNumber, this.Gender, this.BirthDate, this.Email, this.Address, this.Phone, this.PhotoPath, this.NationalityCountryID);
            }
            public bool Save()
            {
                switch (enMode)
                {
                    case enMode.AddNew:
                        {
                            this.enMode = enMode.Update;
                            return _AddNewPerson();
                        }
                    case enMode.Update:
                        {
                            return _UpdatPerson();
                        }
                }
                return false;
            }
            public static DataTable GetAllCountry()
            {
                return DataLayer.GetAllCountries();
            }
            public static bool IsPersonExist(int personID)
            {
                return DVLDDataLayer.DataLayer.IsPersonExist(personID);
            }

            public static bool IsPersonExist(string NationalNumber)
            {
                return DVLDDataLayer.DataLayer.IsPersonExist(NationalNumber);
            }

            public static bool DeletePerson(int personID)
            {
                return DVLDDataLayer.DataLayer.DeletePerson(personID);
            }

            public static DataTable ShowAllPeople()
            {
                return DVLDDataLayer.DataLayer.ShowAllPeople();
            }

            public static string GetCountryByID(int countryID)
            {
                return DataLayer.GetCountryByID(countryID);
            }
        }

        public class clsUser
        {
            public enum enMode { AddNew, Update };
            public int UserID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool isActive { get; set; }

            public int PersonID { get; set; }
            public enMode Mode = enMode.Update;

            public clsUser()
            {
                UserName = " ";
                Password = " ";
                UserID = -1;
                isActive = false;
                PersonID = -1;
                Mode = enMode.AddNew;
            }
            public clsUser(int UserID, string UserName, string Password, bool isActive, int PersonID)
            {
                this.UserID = UserID;
                this.UserName = UserName;
                this.Password = Password;
                this.isActive = isActive;
                this.PersonID = PersonID;
                this.Mode = enMode.Update;
            }

            public static clsUser FindUserByPersonID(int PersonID)
            {

                string UserName = " ", Password = " ";
                bool isActive = false;
                int userID = -1;
                if (DVLDDataLayer.DataLayer.GetUserInfoByPersonID(PersonID, ref userID, ref UserName, ref Password, ref isActive))
                {
                    return new clsUser(userID, UserName, Password, isActive, PersonID);
                }
                else
                    return null;
            }

            public static clsUser FindUserByUserID(int UserID)
            {

                string UserName = " ", Password = " ";
                bool isActive = false;
                int PersonID = -1;
                if (DVLDDataLayer.DataLayer.GetUserInfoByUserID(ref PersonID, UserID, ref UserName, ref Password, ref isActive))
                {
                    return new clsUser(UserID, UserName, Password, isActive, PersonID);
                }
                else
                    return null;
            }
            public static clsUser FindUserByUserName(string UserName)
            {

                string Password = " ";
                bool isActive = false;
                int userID = -1, PersonID = -1;
                if (DVLDDataLayer.DataLayer.GetUserInfoByUsername(ref PersonID, ref userID, UserName, ref Password, ref isActive))
                {
                    return new clsUser(userID, UserName, Password, isActive, PersonID);
                }
                else
                    return null;
            }

            public static DataTable ShowAllUsers()
            {
                return DVLDDataLayer.DataLayer.ShowAllUsers();
            }

            public static bool isUserExist(string UserName)
            {
                return DVLDDataLayer.DataLayer.IsPersonExist(UserName);
            }

            public static bool isUserExist(int PersonId)
            {
                return DVLDDataLayer.DataLayer.IsUserExist(PersonId);
            }
            private bool _AddNewUser()
            {
                this.UserID = DVLDDataLayer.DataLayer.AddNewUser(this.PersonID, this.UserName, this.Password, this.isActive);
                return this.UserID != -1;
            }

            private bool _UpdateUser()
            {
                return DVLDDataLayer.DataLayer.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.isActive);
            }

            public bool Save()
            {
                switch (Mode)
                {
                    case enMode.AddNew:
                        {
                            this.Mode = enMode.Update;
                            return _AddNewUser();
                        }
                    case enMode.Update:
                        {
                            return _UpdateUser();
                        }
                }
                return false;
            }

            public static bool DeleteUser(int PersonID) 
            {
                return DataLayer.DeleteUser(PersonID);
            }

            public static bool ChangePassword(int UserID, string Password)
            {
                return DataLayer.ChangeUserPassword(UserID, Password);
            }
            
        }

        public class clsGlobalUSer
        {
            public static clsUser _User1 = null;
            
        }

        public class clsApplicationsTypes
        {
            public int ApplicationtypeId { get; set; }
            public string ApplicationName { get; set; }
            public float Fees { get; set; }

            public clsApplicationsTypes(int ID , string Name , float Fees)
            {
                ApplicationtypeId = ID;
                ApplicationName = Name;
                this.Fees = Fees;
            }

            public clsApplicationsTypes()
            {
                ApplicationtypeId = 0;
                ApplicationName = "";
                Fees = 0;
            }
            public static clsApplicationsTypes GetApplicationType(int ID)
            {
                float fees = 0;
                string name = "";
                if( DataLayer.GetApplicationType(ID, ref name, ref fees))
                {
                    return new clsApplicationsTypes(ID, name, fees);
                }
                return null;
            }
            public static bool EditApplicationType(int ApplicationtypeId,string Name , float fees)
            {
                return DataLayer.EditApplicationType(ApplicationtypeId, Name, fees);

            }

            public static DataTable getAllApplicationType()
            {
                return DataLayer.GetAllApplictaionTypes();
            }
        }

        public class clsTestTypes
        {
            public int TestTypeID { get; set; }
            public string TestTypeTitle { get; set; }
            public string TestTypeDescription { get; set; }
            public float TestTypeFees { get; set; }

            public clsTestTypes(int ID, string Name,string desc, float Fees)
            {
                TestTypeID = ID;
                TestTypeTitle = Name;
                TestTypeDescription = desc;
                TestTypeFees = Fees;
            }

            public clsTestTypes()
            {
                TestTypeID = 0;
                TestTypeTitle = "";
                TestTypeDescription = "";
                TestTypeFees = 0;
            }
            public static clsTestTypes GetTestType(int ID)
            {
                float fees = 0;
                string name = "", desc = "";
                if (DataLayer.GetTestType(ID, ref name,ref desc, ref fees))
                {
                    return new clsTestTypes(ID, name,desc, fees);
                }
                return null;
            }
            public static bool EditTestType(int TestTypeID,string TestTypeTitle,string TestTypeDescription,float TestTypeFees)
            {
                return DataLayer.EditTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);

            }

            public static DataTable GetAllTestTypes()
            {
                return DataLayer.GetAllTestTypes();
            }
        }

        public class clsApplications
        {
            public int ApplicationID { get; set; }
            public int ApplicantPersonID { get; set; }
            public DateTime ApplicationDate { get; set; }
            public int ApplicationTypeID { get; set; }
            public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 }
            
            public enApplicationStatus ApplicationStatus { get; set; }
            public DateTime LastStatusDate { get; set; }
            public float PaidFees { get; set; }
            public int CreatedByUserID { get; set; }

            public clsApplications(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, int ApplicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
            {
                this.ApplicationID = applicationID;
                this.ApplicantPersonID = applicantPersonID;
                this.ApplicationDate = applicationDate;
                this.ApplicationTypeID = applicationTypeID;
                this.LastStatusDate = lastStatusDate;
                this.PaidFees = paidFees;
                this.CreatedByUserID = createdByUserID;
                this.ApplicationStatus = (enApplicationStatus)ApplicationStatus;
            }

            public clsApplications()
            {
                this.ApplicationID = 0;
                this.ApplicantPersonID = 0;
                this.ApplicationDate = DateTime.Now;
                this.ApplicationTypeID = 0;
                this.LastStatusDate = DateTime.Now;
                this.PaidFees = 0;
                this.CreatedByUserID = 0;
                this.ApplicationStatus = enApplicationStatus.New ;
            }
            

            public static bool IsApplicationExist(int APPID)
            {
                return DataLayer.IsApplicationExist(APPID);
            }
            

            public static bool IsApplicationExistByPersonID(int PersonID)
            {
                return DataLayer.IsApplicationExistByPersonID(PersonID);
            }

            public static clsApplications FindApplicationByPersonID(int ApplicantPersonID)
            {
                int ApplicationID = 0,  ApplicationTypeID = 0 , CreatedByUserID = 0;
                DateTime ApplicationDate = DateTime.Now , LastStatusDate = DateTime.Now;
                float PaidFees = 0;
                short ApplicationStatus = 0;
                if (DataLayer.GetApplicationByPersonID(ref ApplicationID, ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
                {
                    return new clsApplications(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
                }
                else
                    return null;
            }
            public bool AddNewApplication()
            {
                this.ApplicationID = DataLayer.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
                this.ApplicationStatus = enApplicationStatus.New;
                return this.ApplicationID != -1;
            }
            public bool UpdateApplication()
            {
                return DataLayer.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, (short)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            }
            public static clsApplications GetAppByAppID(int ApplicationID)
            {
                int ApplicantPersonID = 0, ApplicationTypeID = 0, CreatedByUserID = 0;
                DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
                float PaidFees = 0;
                short ApplicationStatus = 0;
                if (DataLayer.GetApplicationByAppID( ApplicationID,ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
                {
                    return new clsApplications(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
                }
                else
                    return null;
            }
            public static DataTable GetApplicationsByPersonID(int ApplicantPersonID)
            {
                return DataLayer.GetAllApplicationsByPersonID(ApplicantPersonID);
            }

            public static bool DeleteApplication(int ApplicationID)
            {
                return DataLayer.DeleteApplication(ApplicationID);
            }

        }

        public class clsHashing
        {
            public string HashedPassword { get; set; }
            public static string HashOutput(string password)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] Hashbyte = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    return BitConverter.ToString(Hashbyte).Replace("-", "").ToLower();
                }
            }

            public static string Encrypt(string plainText, string key)
            {
                using (Aes aesAlg = Aes.Create())
                {
                    // Set the key and IV for AES encryption
                    aesAlg.Key = Encoding.UTF8.GetBytes(key);
                    aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                    // Create an encryptor
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                    // Encrypt the data
                    using (var msEncrypt = new System.IO.MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }


                        // Return the encrypted data as a Base64-encoded string
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }


            public static string Decrypt(string cipherText, string key)
            {
                using (Aes aesAlg = Aes.Create())
                {
                    // Set the key and IV for AES decryption
                    aesAlg.Key = Encoding.UTF8.GetBytes(key);
                    aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                    // Create a decryptor
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                    // Decrypt the data
                    using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                    {
                        // Read the decrypted data from the StreamReader
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        public class clsLicenseClass
        {
            public static DataTable GetAllLicenseClass() { return DataLayer.GetAllLicenseClass();}
            public static string GetClassNameByClassID(int ClassID)
            {
                return DataLayer.GetLicenseClassNameByID(ClassID);
            }
            public static short GetValidityLengthByLicenseClassID(int LicenseClassID)
            {
                return DataLayer.GetValidityLengthByClassID(LicenseClassID);
            }
        }

        public class clsLocalDrivingLecinse
        {
            public int LocalDrivingLicenseApplicationID { get; set; }
            public int ApplicationID { get; set; }
            public int LicenseClassID { get; set; }

            public clsLocalDrivingLecinse()
            {
                this.LocalDrivingLicenseApplicationID = 0;
                this.ApplicationID = 0;
                this.LicenseClassID = 0;
            }

            public clsLocalDrivingLecinse(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID)
            {
                this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
                this.ApplicationID = applicationID;
                this.LicenseClassID = licenseClassID;
            }

            public bool AddNewLocalLecinseApplication(int ApplicationID,int LicenseClassID)
            {
                this.LocalDrivingLicenseApplicationID = DataLayer.AddNewLocalLecinseApplication(ApplicationID, LicenseClassID);
                return this.LocalDrivingLicenseApplicationID > 0;
            }
            public clsLocalDrivingLecinse GetLocalAppByAppID(int appID)
            {
                int LocalDrivingLicenseApplicationID = 0, LicenseClassID = 0; 
                if(DataLayer.GetLocalAppByAppID(appID,ref LocalDrivingLicenseApplicationID, ref LicenseClassID))
                {
                    return new clsLocalDrivingLecinse(LocalDrivingLicenseApplicationID, appID,LicenseClassID);
                }
                else return null;
            }

            public clsLocalDrivingLecinse GetLocalAppByLocalAppID(int LocalDrivingLicenseApplicationID)
            {
                int appID = 0, LicenseClassID = 0;
                if (DataLayer.GetLocalAppByLocalAppID(ref appID, LocalDrivingLicenseApplicationID, ref LicenseClassID))
                {
                    return new clsLocalDrivingLecinse(LocalDrivingLicenseApplicationID, appID, LicenseClassID);
                }
                else return null;
            }
            public static int GetLocalAppPassedTest(int appID)
            {
                return DataLayer.GetPassedTestsByLocalAppID(appID);
            }
            public static DataTable GetAllLocalDrivingApp()
            {
                return DataLayer.GetAllLocalApplications();
            }

            public static bool DeleteLocalApplicationByApplicationID(int appID)
            {
                return DataLayer.DeleteLocalApplication(appID);
            }
        }

        public class ClsTestAppointments
        {
            public int TestAppointmentID { get; set; }
            public int TestTypeID { get; set; }
            public int LocalDrivingLicenseApplicationID { get; set; }
            public DateTime AppointmentDate { get; set; }
            public float PaidFees { get; set; }
            public int CreatedByUserID { get; set; }
            public bool IsLocked { get; set; }
            public int? RetakeTestApplicationID { get; set; }

            public ClsTestAppointments()
            {
                TestAppointmentID = 0;
                TestTypeID = 0;
                LocalDrivingLicenseApplicationID = 0;
                AppointmentDate = DateTime.Now;
                PaidFees = 0;
                CreatedByUserID = 0;
                IsLocked = true;
                RetakeTestApplicationID = null;
            }
            public ClsTestAppointments(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, int? retakeTestApplicationID)
            {
                this.TestAppointmentID = testAppointmentID;
                this.TestTypeID = testTypeID;
                this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
                this.AppointmentDate = appointmentDate;
                this.PaidFees = paidFees;
                this.CreatedByUserID = createdByUserID;
                this.IsLocked = isLocked;
                this.RetakeTestApplicationID = retakeTestApplicationID;
            }

            public bool AddNewTestAppointement()
            {
                this.TestAppointmentID = DataLayer.AddNewTestAppointement(this.TestTypeID,this.LocalDrivingLicenseApplicationID,this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.IsLocked,this.RetakeTestApplicationID);
                return this.TestAppointmentID != -1;
            }
            public bool UpdateTestAppontement(int testAppointmentID)
            {
                return DataLayer.UpdateTestAppointement(this.TestAppointmentID, this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
            }
            public ClsTestAppointments GetTestAppByTestAppID(int testAppointmentID)
            {
                int testTypeID = 0, localDrivingLicenseApplicationID = 0, createdByUserID = 0;
                int? retakeTestApplicationID = (int?)null;
                float paidFees = 0;
                DateTime appointmentDate = DateTime.Now;
                bool isLocked = false;
                if(DataLayer.GetTestAppointementByTestAppID(testAppointmentID,ref testTypeID,ref localDrivingLicenseApplicationID,ref appointmentDate,ref paidFees,ref createdByUserID,ref isLocked,ref retakeTestApplicationID))
                {
                    return new ClsTestAppointments(testAppointmentID, testTypeID, localDrivingLicenseApplicationID, appointmentDate, paidFees, createdByUserID, isLocked, retakeTestApplicationID);
                }
                return null;
            }

            public ClsTestAppointments GetTestAppByLocalAppID(int localDrivingLicenseApplicationID)
            {
                int testTypeID = 0, testAppointmentID = 0, createdByUserID = 0;
                int? retakeTestApplicationID = 0;
                float paidFees = 0;
                DateTime appointmentDate = DateTime.Now;
                bool isLocked = false;
                if (DataLayer.GetTestAppointementByLocalAppID(ref testAppointmentID, ref testTypeID, localDrivingLicenseApplicationID, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked, ref retakeTestApplicationID))
                {
                    return new ClsTestAppointments(testAppointmentID, testTypeID, localDrivingLicenseApplicationID, appointmentDate, paidFees, createdByUserID, isLocked, retakeTestApplicationID);
                }
                return null;
            }
            public static bool IsTestAppointementExist(int testAppointmentID)
            {
                return DataLayer.IsAppointementExistByAppoinID(testAppointmentID);
            }
            public static DataTable GetAllTestAppointmentsVision(int LocalDrivingLicenseApplicationID)
            {
                return DataLayer.GetAllTestAppointementVision(LocalDrivingLicenseApplicationID);
            }
            public static DataTable GetAllTestAppointmentsWritten(int LocalDrivingLicenseApplicationID)
            {
                return DataLayer.GetAllTestAppointementWritten(LocalDrivingLicenseApplicationID);
            }
            public static DataTable GetAllTestAppointmentsStreet(int LocalDrivingLicenseApplicationID)
            {
                return DataLayer.GetAllTestAppointementstreet(LocalDrivingLicenseApplicationID);
            }
        }

        public class clsTests
        {
            public int TestID { get; set; }
            public int TestAppointmentID { get; set; }
            public bool TestResult { get; set; }
            public string Notes { get; set; }
            public int CreatedByUserID { get; set; }

            public clsTests()
            {
                TestID = 0;
                TestAppointmentID = 0;
                TestResult = false;
                Notes = "";
                CreatedByUserID = 0;
            }
            public clsTests(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
            {
                this.TestID = testID;
                this.TestAppointmentID = testAppointmentID;
                this.TestResult = testResult;
                this.Notes = notes;
                this.CreatedByUserID = createdByUserID;
            }
            public bool AddNewTest()
            {
                this.TestID = DataLayer.AddNewTest(this.TestAppointmentID,this.TestResult,this.Notes,this.CreatedByUserID);
                return this.TestID != -1;
            }
            public clsTests GetTestByTestID(int testID)
            {
                int TestAppointmentID = 0, CreatedByUserID = 0;
                bool TestResult = false;
                string Notes = "";
                if (DataLayer.GetTestByTestID(testID,ref TestAppointmentID,ref TestResult,ref Notes,ref CreatedByUserID))
                    return new clsTests(testID,TestAppointmentID,TestResult,Notes,CreatedByUserID);
                return null;
            }

            public clsTests GetTestByTestAppID(int TestAppointmentID)
            {
                int testID = 0, CreatedByUserID = 0;
                bool TestResult = false;
                string Notes = "";
                if (DataLayer.GetTestByTestAppID(ref testID, TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
                    return new clsTests(testID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
                return null;
            }
        }
        public class clsDrivers
        {
            public int DriverID { get; set; }
            public int PersonID { get; set; }
            public int CreatedByUserID { get; set; }
            public DateTime CreatedDate { get; set; }

            public clsDrivers(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
            {
                this.DriverID = DriverID;
                this.PersonID = PersonID;
                this.CreatedByUserID = CreatedByUserID;
                this.CreatedDate = CreatedDate;
            }
            public clsDrivers()
            {
                DriverID = 0;
                PersonID = 0;
                CreatedByUserID = 0;
                CreatedDate = DateTime.Now;
            }
            public bool AddNewDriver()
            {
                this.DriverID =  DataLayer.AddNewDriver(this.PersonID,this.CreatedByUserID,this.CreatedDate);
                return this.DriverID != -1;
            }
            public clsDrivers GetDriverByPersonID(int PersonID)
            {
                int DriverID = 0, CreatedByUserID = 0;
                DateTime CreatedDate = DateTime.Now;
                if(DataLayer.GetDriverByPersonID(ref DriverID, PersonID, ref CreatedByUserID , ref CreatedDate))
                    return new clsDrivers(DriverID,PersonID,CreatedByUserID ,CreatedDate);
                else return null;
            }
            public static DataTable GetAllDriversData()
            {
                return DataLayer.GetAllDriverData();
            }
        }
        public class clsLicenses
        {
            public enum enIssueReason { FirstTime = 1,Renew = 2,ReplacementforDamaged = 3,ReplacementforLost = 4}
            public int LicenseID { get; set; }
            public int ApplicationID { get; set; }
             public int DriverID { get; set; }
            public int LicenseClass {  get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public string Notes { get; set; }
            public float PaidFees { get; set; }
            public bool IsActive { get; set; }
            public enIssueReason IssueReason { get; set; }
            public int CreatedByUserID { get; set; }

            public clsLicenses(int licenseID, int applicationID, int driverID, int licenseClass, DateTime issueDate, DateTime expirationDate, string notes, float paidFees, bool isActive, enIssueReason issueReason, int createdByUserID)
            {
                LicenseID = licenseID;
                ApplicationID = applicationID;
                DriverID = driverID;
                LicenseClass = licenseClass;
                IssueDate = issueDate;
                ExpirationDate = expirationDate;
                Notes = notes;
                PaidFees = paidFees;
                IsActive = isActive;
                IssueReason = issueReason;
                CreatedByUserID = createdByUserID;
            }
            public clsLicenses() 
            {
                LicenseID = 0;
                ApplicationID = 0;
                DriverID = 0;
                LicenseClass = 0;
                IssueDate = DateTime.Now;
                ExpirationDate= DateTime.Now;
                Notes = "";
                PaidFees= 0;
                IsActive = false;
                IssueReason = enIssueReason.FirstTime;
                CreatedByUserID= 0;
            }
            public bool AddNewLicenses()
            {
                this.LicenseID = DataLayer.AddNewLicenses(this.ApplicationID,this.DriverID,this.LicenseClass,this.IssueDate,this.ExpirationDate,this.Notes,this.PaidFees,this.IsActive,(int)this.IssueReason,this.CreatedByUserID);
                return this.LicenseID > -1;
            }
            public clsLicenses GetLicenseByApplicationID(int ApplicationID)
            {
                int LicenseID = 0 , DriverID = 0 , LicenseClass = 0, CreatedByUserID = 0;
                string Notes = "";
                bool IsActive = false;
                DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
                short IssueReason = 0;
                float PaidFees = 0;
                if (DataLayer.GetLicensesByApplicationID(ref LicenseID, ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
                {
                    return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
                }
                else
                    return null;
            }

            public clsLicenses GetLicenseByDriverID(int DriverID)
            {
                int LicenseID = 0, ApplicationID = 0, LicenseClass = 0, CreatedByUserID = 0;
                string Notes = "";
                bool IsActive = false;
                DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
                short IssueReason = 0;
                float PaidFees = 0;
                if (DataLayer.GetLicensesByDriverID(ref LicenseID,ref ApplicationID, DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
                {
                    return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
                }
                else
                    return null;
            }

            public clsLicenses GetLicenseByLicenseID(int LicenseID)
            {
                int DriverID = 0, ApplicationID = 0, LicenseClass = 0, CreatedByUserID = 0;
                string Notes = "";
                bool IsActive = false;
                DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
                short IssueReason = 0;
                float PaidFees = 0;
                if (DataLayer.GetLicensesByLicenseID(LicenseID, ref ApplicationID,ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
                {
                    return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
                }
                else
                    return null;
            }

            public static DataTable GetLicenesHistoryByPersonID(int PersonID)
            {
                return DataLayer.GetLicenesHistoryByPersonID(PersonID);
            }

            public bool UpdateLicenseByLicenseID()
            {
                return DataLayer.UpdateLocalLicneseByLocalLicID(this.LicenseID,this.ApplicationID,this.DriverID,this.LicenseClass,this.IssueDate,this.ExpirationDate,this.Notes,this.PaidFees,this.IsActive,(short)this.IssueReason,this.CreatedByUserID);
            }
        }
        public class clsInternationalLicense
        {
            public int InternationalLicenseID {  get; set; }
            public int ApplicationID { get; set; }
            public int DriverID { get; set; }
            public int IssuedUsingLocalLicenseID { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public bool IsActive { get; set; }
            public int CreatedByUserID { get; set; }

            public clsInternationalLicense()
            {
                InternationalLicenseID = 0;
                ApplicationID = 0;
                DriverID = 0;
                IssuedUsingLocalLicenseID = 0;
                IssueDate = DateTime.Now;
                ExpirationDate = DateTime.Now;
                IsActive = false;
                CreatedByUserID = 0;
            }

            public clsInternationalLicense(int internationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
            {
                this.InternationalLicenseID = internationalLicenseID;
                this.ApplicationID = applicationID;
                this.DriverID = driverID;
                this.IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
                this.IssueDate = issueDate;
                this.ExpirationDate = expirationDate;
                this.IsActive = isActive;
                this.CreatedByUserID = createdByUserID;
            }
            public bool AddnewInternationalLicense()
            {
                this.InternationalLicenseID = DataLayer.AddNewInternationalLicenses(this.ApplicationID,this.DriverID,this.IssuedUsingLocalLicenseID,this.IssueDate,this.ExpirationDate,this.IsActive,this.CreatedByUserID);
                return this.InternationalLicenseID > 0;
            }

            public clsInternationalLicense GetClsInternationalLicenseByID(int internationalLicenseID)
            {
                int applicationID = 0, driverID = 0, issuedUsingLocalLicenseID = 0, CreatedByUserID = 0;
                DateTime issueDate = DateTime.Now,  expirationDate = DateTime.Now;
                bool IsActive = false;
                if(DataLayer.GetInternationalLicensesByLicenseID(internationalLicenseID,ref applicationID,ref driverID,ref issuedUsingLocalLicenseID,ref issueDate,ref expirationDate,ref IsActive,ref CreatedByUserID))
                {
                    return new clsInternationalLicense(internationalLicenseID, applicationID, driverID, issuedUsingLocalLicenseID, issueDate, expirationDate, IsActive, CreatedByUserID);
                }
                return null;
            }
            public clsInternationalLicense GetClsInternationalLocalLicenseByID(int issuedUsingLocalLicenseID)
            {
                int applicationID = 0, driverID = 0, internationalLicenseID = 0, CreatedByUserID = 0;
                DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
                bool IsActive = false;
                if (DataLayer.GetInternationalLicensesByLocalLicenseID(ref internationalLicenseID, ref applicationID, ref driverID, issuedUsingLocalLicenseID, ref issueDate, ref expirationDate, ref IsActive, ref CreatedByUserID))
                {
                    return new clsInternationalLicense(internationalLicenseID, applicationID, driverID, issuedUsingLocalLicenseID, issueDate, expirationDate, IsActive, CreatedByUserID);
                }
                return null;
            }
            public static bool IsInterLicExistByLocallicID(int IssuedUsingLocalLicenseID)
            {
                return DataLayer.IsInterLicExistByLocallicID(IssuedUsingLocalLicenseID);
            }
            public static DataTable GetInterLicenseHistoryByPersonID(int PersonID)
            {
                return DataLayer.GetInterLicenesHistoryByPersonID(PersonID);
            }
            public static DataTable GetAllInternationalApplications()
            {
                return DataLayer.GetAllInternationalLicenseApplications();
            }
        }
        public class clsDetain
        {
            public int DetainID { get; set; }
            public int LicenseID { get; set; }
            public DateTime DetainDate { get; set; }
            public float FineFees { get; set; }
            public int CreatedByUserID { get; set; }
            public bool IsReleased { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public int? ReleasedByUserID { get; set; }
            public int? ReleaseApplicationID { get; set; }

            public clsDetain()
            {
                DetainID = 0;
                LicenseID = 0;
                DetainDate = DateTime.Now;
                FineFees = 0;
                CreatedByUserID = 0;
                IsReleased = false;
                ReleaseDate = null;
                ReleasedByUserID = null;
                ReleaseApplicationID = null;
            }
            public clsDetain(int detainID, int licenseID, DateTime detainDate, float fineFees, int createdByUserID, bool isReleased, DateTime? releaseDate, int? releasedByUserID, int? releaseApplicationID)
            {
                DetainID = detainID;
                LicenseID = licenseID;
                DetainDate = detainDate;
                FineFees = fineFees;
                CreatedByUserID = createdByUserID;
                IsReleased = isReleased;
                ReleaseDate = releaseDate;
                ReleasedByUserID = releasedByUserID;
                ReleaseApplicationID = releaseApplicationID;
            }

            public static bool IsLicenseDetainedByLicID(int licenseID)
            {
                return DataLayer.IsLicenseDetaiedByLicID(licenseID);
            }

            public static DataTable GetAllDetainedLicenses()
            {
                return DataLayer.GetAllDetainedLicenses();
            }

            public bool AddNewDetain()
            {
                this.DetainID = DataLayer.AddNewDetain(this.LicenseID,this.DetainDate,this.FineFees,this.CreatedByUserID,this.IsReleased,this.ReleaseDate,this.ReleasedByUserID,this.ReleaseApplicationID);
                return this.LicenseID != -1;
            }
            public static DataTable GetDetainedLicByLicID(int LicenseID)
            {
                return DataLayer.IsLicenseDetainedByLicID(LicenseID);
            }
            public bool UpdateDetain()
            {
                return DataLayer.UpdateDetain(this.LicenseID,this.DetainDate,this.FineFees,this.CreatedByUserID,this.IsReleased,this.ReleaseDate,this.ReleasedByUserID, this.ReleaseApplicationID);
            }

            public clsDetain GetDetainLicByDetainID(int DetainID)
            {
                int LicenseID = 0, CreatedByUserID = 0, ReleasedByUserID = 0, ReleaseApplicationID = 0;
                DateTime DetainDate = DateTime.Now , ReleaseDate = DateTime.Now ;
                float FineFees = 0;
                bool IsReleased = false;
                if (DataLayer.GetDetainedLicByDetainID(DetainID,ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
                    return new clsDetain(DetainID,LicenseID, DetainDate,FineFees,CreatedByUserID,IsReleased,ReleaseDate,ReleasedByUserID,ReleaseApplicationID);
                return null;

            }
        }
        static void Main(string[] args)
        {

        }
    }
}