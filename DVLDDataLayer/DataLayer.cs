using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Policy;
using Microsoft.SqlServer.Server;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System.Diagnostics;

namespace DVLDDataLayer
{
    public class DataLayer
    {
        static string ConnectionString = "Server = .; Database = DVLD; User Id = sa; Password = sa123456;";
        //People
        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string NationalNumber, ref short Gender, ref DateTime Birthdate, ref string Email, ref string Address,
           ref string Phone, ref string PhotoPath, ref int NationalityCountryID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "select * from People where PersonID = @PersonID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    NationalNumber = (string)reader["NationalNo"];
                    Gender = Convert.ToInt16(reader["Gendor"]);
                    Birthdate = (DateTime)reader["DateOfBirth"];
                    Email = (string)reader["Email"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    PhotoPath = (string)reader["ImagePath"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { con.Close(); }
            return result;
        }
        
        public static bool GetPersonInfoByNationalNumber(ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, string NationalNumber, ref short Gender, ref DateTime Birthdate, ref string Email, ref string Address,
           ref string Phone, ref string PhotoPath, ref int NationalityCountryID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "select * from People where NationalNo = @NationalNo";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNumber);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    NationalNumber = (string)reader["NationalNo"];
                    Gender = Convert.ToInt16(reader["Gendor"]);
                    Birthdate = (DateTime)reader["DateOfBirth"];
                    Email = (string)reader["Email"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    PhotoPath = (string)reader["ImagePath"];
                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }
            finally { con.Close(); }
            return result;
        }

        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName, string NationalNumber, short Gendor, DateTime Birthdate, string Email, string Address,
           string PhoneNumber, string PhotoPath, int NationalityCountryID)
        {
            int PerosnId = -1;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"INSERT INTO People (NationalNo,FirstName,SecondName,ThirdName,LastName,Gendor,DateOfBirth,Phone,Email,Address,ImagePath,NationalityCountryID) VALUES
                           (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@Gendor,@DateOfBirth,@Phone,@Email,@Address,@ImagePath,@NationalityCountryID);SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNumber);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@SecondName", SecondName);
            cmd.Parameters.AddWithValue("@ThirdName", ThirdName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Gendor", Gendor);
            cmd.Parameters.AddWithValue("@DateOfBirth", Birthdate);
            cmd.Parameters.AddWithValue("@Phone", PhoneNumber);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@address", Address);
            cmd.Parameters.AddWithValue("@ImagePath", PhotoPath);
            cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            try
            {
                con.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    PerosnId = result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return PerosnId;
        }

        public static bool UpdatePerson(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string NationalNumber, short Gendor, DateTime Birthdate, string Email, string Address,
           string PhoneNumber, string PhotoPath, int NationalityCountryID)
        {
            int RowAffected = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"UPDATE People SET NationalNo = @NationalNo,FirstName = @FirstName,SecondName = @SecondName,ThirdName = @ThirdName,LastName = @LastName, 
                           Gendor = @Gendor,DateOfBirth = @DateOfBirth,Phone = @Phone,Email = @Email,Address = @Address,ImagePath = @ImagePath , NationalityCountryID = @NationalityCountryID
                           WHERE PersonID = @PersonID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNumber);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@SecondName", SecondName);
            cmd.Parameters.AddWithValue("@ThirdName", ThirdName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Gendor", Gendor);
            cmd.Parameters.AddWithValue("@DateOfBirth", Birthdate);
            cmd.Parameters.AddWithValue("@Phone", PhoneNumber);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@address", Address);
            cmd.Parameters.AddWithValue("@ImagePath", PhotoPath);
            cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            try
            {
                con.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return RowAffected > 0;
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Select X = 1 From People where PersonID = @PersonID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return isFound;
        }

        public static string GetCountryByID(int CountryID)
        {
            string CountryName = "";
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Select CountryName from Countries where CountryID = @CountryID";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue(@"CountryID", CountryID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                    CountryName = reader["CountryName"].ToString();
                reader.Close();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return CountryName;
        }
        public static bool IsPersonExist(string NationalNumber)
        {
            bool isFound = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Select X = 1 From People where NationalNo = @NationalNo";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNumber);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return isFound;
        }

        public static bool DeletePerson(int PersonID)
        {
            int AffectedRow = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Delete From People Where PersonID = @PersonID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                con.Open();
                AffectedRow = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return AffectedRow > 0;
        }

        public static DataTable ShowAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"SELECT        People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth,( Case WHEN People.Gendor = 0 then 'Male' ELSE 'Female' END)as Gendor, People.Address, People.Phone, People.Email, Countries.CountryName, 
                         People.ImagePath
FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }
        //Countries
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"select CountryName from Countries";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;

        }
        //Users Management
        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password, ref bool isActive)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"select UserID , Username , Password , Users.PersonID , isActive from Users inner join People on Users.PersonID = People.PersonID where People.PersonID = @PersonID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue(@"PersonID", PersonID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    UserID = Convert.ToInt32(reader["UserID"]);
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    isActive = (bool)reader["isActive"];
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return result;
        }

        public static bool GetUserInfoByUserID(ref int PersonID, int UserID, ref string UserName, ref string Password, ref bool isActive)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"select * FROM Users WHERE UserID = @UserID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue(@"UserID", UserID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    isActive = (bool)reader["isActive"];
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return result;
        }

        public static bool GetUserInfoByUsername(ref int PersonID, ref int UserID, string UserName, ref string Password, ref bool isActive)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"select * from Users where UserName = @UserName";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue(@"UserName", UserName);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    UserID = Convert.ToInt32(reader["UserID"]);
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    isActive = (bool)reader["isActive"];
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return result;
        }

        public static DataTable ShowAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Select Users.UserID , People.PersonID , People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName as FullName , Username , isActive from Users inner join People on Users.PersonID = People.PersonID";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }

        public static bool IsUserExist(string UserName)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"select X = 1 from Users where UserName = @UserName";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue(@"Username", UserName);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                result = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return result;
        }

        public static bool IsUserExist(int PersonID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"select X = 1 from Users inner join People on Users.PersonID = People.PersonID where People.PersonID = @PersonID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue(@"PersonID", PersonID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                result = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return result;
        }

        public static int AddNewUser(int PersonID, string UserName, string Password, bool isActive)
        {
            int UserID = -1;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"insert into Users (UserName , Password , isActive,PersonID) Values (@UserName,@Password,@isActive,@PersonID); SELECT SCOPE_IDENTITY(); ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue(@"PersonID", PersonID);
            cmd.Parameters.AddWithValue(@"UserName", UserName);
            cmd.Parameters.AddWithValue(@"Password", Password);
            cmd.Parameters.AddWithValue(@"isActive", isActive);
            try
            {
                con.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    UserID = result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return UserID;
        }

        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool isActive)
        {
            int affectedRows = 0;
            SqlConnection conn = new SqlConnection(ConnectionString);
            string Query = @"Update Users set Username = @Username , Password = @Password , PersonID = @PersonID , isActive = @isActive where UserID = @UserID;";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue(@"UserID", UserID);
            cmd.Parameters.AddWithValue(@"PersonID", PersonID);
            cmd.Parameters.AddWithValue(@"UserName", UserName);
            cmd.Parameters.AddWithValue(@"Password", Password);
            cmd.Parameters.AddWithValue(@"isActive", isActive);
            try
            {
                conn.Open();
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return affectedRows > 0;
        }
        public static bool DeleteUser(int PersonID)
        {
            int AffectedRow = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Delete From Users Where Users.PersonID = @PersonID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                con.Open();
                AffectedRow = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return AffectedRow > 0;
        }

        public static bool ChangeUserPassword(int UserID,string Password)
        {
            int affectedRows = 0;
            SqlConnection conn = new SqlConnection(ConnectionString);
            string Query = @"Update Users set Password = @Password where UserID = @UserID;";
            SqlCommand cmd = new SqlCommand(Query, conn);
            
            cmd.Parameters.AddWithValue(@"UserID", UserID);
            
            cmd.Parameters.AddWithValue(@"Password", Password);
            
            try
            {
                conn.Open();
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return affectedRows > 0;
        }
        //Aplication Types
        public static bool EditApplicationType(int ApplicationtypeId, string Name, float fees)
        {
            int affectedrow = 0;
            SqlConnection conn = new SqlConnection(ConnectionString);
            string quey = @"update ApplicationTypes set ApplicationTypeTitle = @Name , ApplicationFees = @Fees where ApplicationTypeID = @ApplicationtypeId;";
            SqlCommand cmd = new SqlCommand(quey, conn);
            cmd.Parameters.AddWithValue(@"ApplicationtypeId", ApplicationtypeId);
            cmd.Parameters.AddWithValue(@"Name", Name);
            cmd.Parameters.AddWithValue(@"Fees", fees);
            try
            {
                conn.Open();
                affectedrow = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); };
            return affectedrow > 0;
        }

        public static DataTable GetAllApplictaionTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Select * from ApplicationTypes";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }

        public static bool GetApplicationType(int ID, ref string Name, ref float Fees)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"select * from ApplicationTypes where ApplicationTypeID = @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue(@"ID", ID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    ID = Convert.ToInt32(reader["ApplicationTypeID"]);
                    Name = (string)reader["ApplicationTypeTitle"];
                    Fees = Convert.ToInt64(reader["ApplicationFees"]);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return result;
        }

        //Test Types

        public static bool EditTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            int affectedrow = 0;
            SqlConnection conn = new SqlConnection(ConnectionString);
            string quey = @"update TestTypes set TestTypeTitle = @TestTypeTitle , TestTypeDescription = @TestTypeDescription , TestTypeFees = @TestTypeFees where TestTypeID = @TestTypeID;";
            SqlCommand cmd = new SqlCommand(quey, conn);
            cmd.Parameters.AddWithValue(@"TestTypeTitle", TestTypeTitle);
            cmd.Parameters.AddWithValue(@"TestTypeDescription", TestTypeDescription);
            cmd.Parameters.AddWithValue(@"TestTypeFees", TestTypeFees);
            cmd.Parameters.AddWithValue(@"TestTypeID", TestTypeID);
            try
            {
                conn.Open();
                affectedrow = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); };
            return affectedrow > 0;
        }

        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Select * from TestTypes";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }

        public static bool GetTestType(int TestTypeID, ref string TestTypeTitle,ref string TestTypeDescription, ref float TestTypeFees)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"select * From TestTypes WHERE TestTypeID = @TestTypeID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue(@"TestTypeID", TestTypeID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    TestTypeID = Convert.ToInt32(reader["TestTypeID"]);
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFees = Convert.ToInt64(reader["TestTypeFees"]);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return result;
        }

        //Applications

        public static DataTable GetAllLocalApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Select LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID as LDLAppID,LicenseClasses.ClassName As ClassName,Applications.ApplicationDate as ApplicationDate ,  case when Applications.ApplicationStatus = 1 then 'New' when Applications.ApplicationStatus = 2 then 'Cancelled' else 'Completed' END as Statues , People.NationalNo As NationalNumber , People.FirstName + ' ' + People.SecondName +' '+People.ThirdName + ' '+People.LastName As FullName  from LocalDrivingLicenseApplications inner join Applications on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID inner join People on People.PersonID = Applications.ApplicantPersonID inner join LicenseClasses on LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }

        public static bool IsApplicationExist(int AppID)
        {
            bool isFound = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Select X = 1 From Applications where ApplicationID = @ApplicationID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PersonID", AppID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return isFound;
        }

        public static bool IsApplicationExistByPersonID(int PersonID)
        {
            bool isFound = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Select X = 1 From Applications where Applications.ApplicantPersonID = @ApplicantPersonID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return isFound;
        }

        public static bool GetApplicationByPersonID(ref int ApplicationID, int ApplicantPersonID, ref DateTime ApplicationDate , ref int ApplicationTypeID, ref short ApplicationStatus,ref DateTime LastStatusDate , ref float PaidFees , ref int CreatedByUserID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "select * from Applications where ApplicantPersonID = @ApplicantPersonID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = Convert.ToInt16( reader["ApplicationStatus"]);
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = float.Parse( reader["PaidFees"].ToString());
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally { con.Close(); }
            return result;
        }

        public static bool GetApplicationByAppID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID, ref short ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "select * from Applications where ApplicationID = @ApplicationID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    ApplicationID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = Convert.ToInt16(reader["ApplicationStatus"]);
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = float.Parse(reader["PaidFees"].ToString());
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally { con.Close(); }
            return result;
        }

        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"INSERT INTO Applications (ApplicantPersonID,ApplicationDate,ApplicationTypeID,LastStatusDate,PaidFees,CreatedByUserID) VALUES
                           (@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,@LastStatusDate,@PaidFees,@CreatedByUserID);SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            
            try
            {
                con.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    ApplicationID = result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return ApplicationID;
        }

        public static bool UpdateApplication(int ApplicationID,int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,short ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int Result = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Update Applications set ApplicantPersonID = @ApplicantPersonID,ApplicationDate = @ApplicationDate,ApplicationTypeID = @ApplicationTypeID, ApplicationStatus = @ApplicationStatus,LastStatusDate = @LastStatusDate,PaidFees = @PaidFees,CreatedByUserID = @CreatedByUserID where ApplicationID = @ApplicationID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                con.Open();
                Result = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return Result > 0;
        }
        public static DataTable GetAllApplicationsByPersonID(int ApplicantPersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"SELECT * FROM Applications WHERE ApplicantPersonID = @ApplicantPersonID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            int AffectedRow = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Delete From Applications Where ApplicationID = @ApplicationID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                con.Open();
                AffectedRow = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return AffectedRow > 0;
        }

        //License Class

        public static DataTable GetAllLicenseClass()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"SELECT * FROM LicenseClasses";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }

        public static string GetLicenseClassNameByID(int LicenseClassID)
        {
            string ClassName = "";
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Select ClassName from LicenseClasses Where LicenseClassID = @LicenseClassID";
            SqlCommand cmd = new SqlCommand(@query, con);
            cmd.Parameters.AddWithValue(@"LicenseClassID", LicenseClassID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    ClassName = (string)reader["ClassName"];
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return ClassName;
        }
        public static short GetValidityLengthByClassID(int LicenseClassID)
        {
            short ValidityLength = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Select DefaultValidityLength from LicenseClasses Where LicenseClassID = @LicenseClassID;";
            SqlCommand sqlCommand = new SqlCommand(@query, con);
            sqlCommand.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                con.Open();
                object obj = sqlCommand.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    ValidityLength = (short)result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return ValidityLength;
        }
        //Local Driving Lecinse Application

        public static int AddNewLocalLecinseApplication(int ApplicationID , int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID,LicenseClassID) VALUES
                           (@ApplicationID,@LicenseClassID);SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            

            try
            {
                con.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    LocalDrivingLicenseApplicationID = result;
                }

            }
            catch (Exception ex) 
            {
                if (!EventLog.Exists("DVLD"))
                {
                    EventLog.CreateEventSource("DVLD", "Application");
                }
                EventLog.WriteEntry("DVLD", "Can not add new local application", EventLogEntryType.Error);
                Console.WriteLine(ex); 
            }
            finally { con.Close(); }
            return LocalDrivingLicenseApplicationID;
        }
        
        public static bool GetLocalAppByAppID(int ApplicationID , ref int LocalDrivingLicenseApplicationID , ref int LicenseClassID)
        {
            bool Result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"Select * From LocalDrivingLicenseApplications Where ApplicationID = @ApplicationID";
            SqlCommand sqlCommand = new SqlCommand(Query, con);
            sqlCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                con.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if(reader.Read())
                {
                    Result = true;
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                reader.Close();
            }
            catch (Exception ex) 
            {
                if (!EventLog.Exists("DVLD"))
                {
                    EventLog.CreateEventSource("DVLD", "Application");
                }
                EventLog.WriteEntry("DVLD", "No local application with this ID", EventLogEntryType.Error);
                Console.WriteLine(ex.Message); 
            }
            finally { con.Close(); }
            return Result;

        }

        public static bool GetLocalAppByLocalAppID(ref int ApplicationID, int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {
            bool Result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"Select * From LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand sqlCommand = new SqlCommand(Query, con);
            sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                con.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    Result = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return Result;

        }

        public static int GetPassedTestsByLocalAppID(int LocalDrivingLicenseApplicationID)
        {
            int PassedTests = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string Query = @"Select SUM(Case When Tests.TestResult = 1 then 1 ELSE 0 END) as PassedTests From Tests inner join TestAppointments inner join LocalDrivingLicenseApplications on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID on Tests.TestAppointmentID = TestAppointments.TestAppointmentID Where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID Group by LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID; ";
            SqlCommand sqlCommand = new SqlCommand( Query, sqlConnection);
            sqlCommand.Parameters.AddWithValue(@"LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if(reader.Read())
                {
                    PassedTests = (int)reader["PassedTests"];
                    
                }
                reader.Close();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { sqlConnection.Close(); }
            return PassedTests;
        }

        public static bool DeleteLocalApplication(int ApplicationID)
        {
            int AffectedRow = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Delete From LocalDrivingLicenseApplications Where ApplicationID = @ApplicationID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                con.Open();
                AffectedRow = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return AffectedRow > 0;
        }

        // Test Appointement

        public static bool GetTestAppointementByTestAppID(int TestAppointmentID,ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref float PaidFees , ref int CreatedByUserID , ref bool IsLocked , ref int? RetakeTestApplicationID)
        {
            bool Result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"Select * From TestAppointments where TestAppointmentID = @TestAppointmentID";
            SqlCommand sqlCommand = new SqlCommand( Query, con);
            sqlCommand.Parameters.AddWithValue(@"TestAppointmentID", TestAppointmentID);
            try
            {
                con.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    Result = true;
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = float.Parse(reader["PaidFees"].ToString());
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    RetakeTestApplicationID =   (int?)reader["RetakeTestApplicationID"];
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return Result;
        }

        public static bool GetTestAppointementByLocalAppID( ref int TestAppointmentID, ref int TestTypeID, int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int? RetakeTestApplicationID)
        {
            bool Result = false;
            
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"Select * From TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand sqlCommand = new SqlCommand(Query, con);
            sqlCommand.Parameters.AddWithValue(@"LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                con.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    Result = true;
                    TestTypeID = (int)reader["TestTypeID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = float.Parse(reader["PaidFees"].ToString());
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    RetakeTestApplicationID = (int?)reader["RetakeTestApplicationID"];
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return Result;
        }

        public static bool IsAppointementExistByAppoinID(int TestAppointmentID)
        {
            bool isFound = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Select X = 1 From TestAppointments where TestAppointmentID = @TestAppointmentID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return isFound;
        }
        public static int AddNewTestAppointement(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees,  int CreatedByUserID,  bool IsLocked,  int? RetakeTestApplicationID)
        {
            int TestAppointementID = -1;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"INSERT INTO TestAppointments (TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,RetakeTestApplicationID,IsLocked) VALUES (@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@CreatedByUserID,@RetakeTestApplicationID,@IsLocked);SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);
            if(RetakeTestApplicationID == null)
            {
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            try
            {
                con.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    TestAppointementID = result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return TestAppointementID;
        }
        public static bool UpdateTestAppointement(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int? RetakeTestApplicationID)
        {
            int RowAffected = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"UPDATE TestAppointments SET TestTypeID = @TestTypeID,LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,AppointmentDate = @AppointmentDate,PaidFees = @PaidFees,RetakeTestApplicationID = @RetakeTestApplicationID ,CreatedByUserID = @CreatedByUserID, 
                           IsLocked = @IsLocked where TestAppointmentID = @TestAppointmentID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);
            if (RetakeTestApplicationID == null)
            {
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            try
            {
                con.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return RowAffected > 0;
        }
        public static DataTable GetAllTestAppointementVision(int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"SELECT TestAppointmentID,AppointmentDate,PaidFees,IsLocked FROM TestAppointments where TestTypeID = 1 and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }

        public static DataTable GetAllTestAppointementWritten(int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"SELECT TestAppointmentID,AppointmentDate,PaidFees,IsLocked FROM TestAppointments where TestTypeID = 2 and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }

        public static DataTable GetAllTestAppointementstreet(int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"SELECT TestAppointmentID,AppointmentDate,PaidFees,IsLocked FROM TestAppointments where TestTypeID = 3 and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }
        //Tests

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID )
        {
            int TestID = -1;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"INSERT INTO Tests (TestAppointmentID,TestResult,Notes,CreatedByUserID)VALUES (@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID);SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                con.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    TestID = result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return TestID;
        }

        public static bool GetTestByTestID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(ConnectionString);
            string Query = @"Select * FROM Tests WHERE TestID = @TestID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@TestID", TestID);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes = (string)reader["Notes"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return isFound;

        }

        public static bool GetTestByTestAppID(ref int TestID,int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(ConnectionString);
            string Query = @"Select * FROM Tests WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestID = (int)reader["TestID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes = (string)reader["Notes"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return isFound;

        }

        //Drivers

        public static DataTable GetAllDriverData()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"SELECT        dbo.Drivers.DriverID, dbo.Drivers.PersonID, dbo.People.NationalNo, dbo.People.FirstName + ' ' + dbo.People.SecondName + ' ' + ISNULL(dbo.People.ThirdName, '') + ' ' + dbo.People.LastName AS FullName, 
                         dbo.Drivers.CreatedDate,
                             (SELECT        COUNT(LicenseID) AS NumberOfActiveLicenses
                               FROM            dbo.Licenses
                               WHERE        (IsActive = 1) AND (DriverID = dbo.Drivers.DriverID)) AS NumberOfActiveLicenses
FROM            dbo.Drivers INNER JOIN
                         dbo.People ON dbo.Drivers.PersonID = dbo.People.PersonID";
            SqlCommand cmd = new SqlCommand(query, con);
            
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }

        public static int AddNewDriver(int PersonID,int CreatedByUserID,DateTime CreatedDate)
        {
            int DriverID = -1;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"INSERT INTO Drivers (PersonID,CreatedByUserID,CreatedDate) VALUES (@PersonID,@CreatedByUserID,@CreatedDate);SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            
            try
            {
                con.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    DriverID = result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return DriverID;
        }

        public static bool GetDriverByPersonID(ref int DriverID,int PersonID,ref int CreatedByUserID,ref DateTime CreatedDate)
        {
            bool isFound = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"Select * From Drivers Where PersonID = @PersonID";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                }
                reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return isFound;
        }

        //License 

        public static int AddNewLicenses(int ApplicationID, int DriverID,int LicenseClass, DateTime IssueDate,DateTime ExpirationDate,string Notes,float PaidFees,bool IsActive, int IssueReason, int CreatedByUserID )
        {
            int LicensesID = -1;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"INSERT INTO Licenses
           (ApplicationID,DriverID,LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,CreatedByUserID)
     VALUES
           (@ApplicationID,@DriverID,@LicenseClass,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID);SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                con.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    LicensesID = result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return LicensesID;
        }

        public static bool GetLicensesByApplicationID(ref int LicenseID, int ApplicationID,ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool IsActive, ref short IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"SELECT * FROM Licenses where Licenses.ApplicationID = @ApplicationID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                con.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if(Reader.Read())
                {
                    IsFound = true;
                    LicenseID = (int)Reader["LicenseID"];
                    DriverID = (int)Reader["DriverID"];
                    LicenseClass = (int)Reader["LicenseClass"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    Notes = (string)Reader["Notes"];
                    PaidFees = float.Parse(Reader["PaidFees"].ToString());
                    IsActive = (bool)Reader["IsActive"];
                    IssueReason = Convert.ToInt16(Reader["IssueReason"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return IsFound;
        }

        public static bool GetLicensesByDriverID(ref int LicenseID,ref int ApplicationID,int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool IsActive, ref short IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"SELECT * FROM Licenses where Licenses.DriverID = @DriverID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                con.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    LicenseID = (int)Reader["LicenseID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    LicenseClass = (int)Reader["LicenseClass"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    Notes = (string)Reader["Notes"];
                    PaidFees = float.Parse(Reader["PaidFees"].ToString());
                    IsActive = (bool)Reader["IsActive"];
                    IssueReason = Convert.ToInt16(Reader["IssueReason"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return IsFound;
        }

        public static bool GetLicensesByLicenseID(int LicenseID, ref int ApplicationID,ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool IsActive, ref short IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"SELECT * FROM Licenses where Licenses.LicenseID = @LicenseID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                con.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    DriverID = (int)Reader["DriverID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    LicenseClass = (int)Reader["LicenseClass"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    Notes = (string)Reader["Notes"];
                    PaidFees = float.Parse(Reader["PaidFees"].ToString());
                    IsActive = (bool)Reader["IsActive"];
                    IssueReason = Convert.ToInt16(Reader["IssueReason"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return IsFound;
        }
        public static DataTable GetLicenesHistoryByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"Select Licenses.LicenseID as LicenseID , Licenses.ApplicationID as ApplicationID, LicenseClasses.ClassName as ClassName,Licenses.IssueDate as IssueDate,Licenses.ExpirationDate As ExDate,Licenses.IsActive As IsActive from Licenses inner join Drivers on Licenses.DriverID = Drivers.DriverID inner join LicenseClasses on Licenses.LicenseClass = LicenseClasses.LicenseClassID inner join People on People.PersonID = Drivers.PersonID where People.PersonID = @PersonID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }

        public static bool UpdateLocalLicneseByLocalLicID(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, short IssueReason, int CreatedByUserID)
        {
            int AffectedRow = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"UPDATE Licenses
   SET ApplicationID = @ApplicationID , DriverID = @DriverID , LicenseClass = @LicenseClass , IssueDate = @IssueDate , ExpirationDate = @ExpirationDate , Notes = @Notes
  ,PaidFees = @PaidFees,IsActive = @IsActive,IssueReason = @IssueReason
      ,CreatedByUserID = @CreatedByUserID
 WHERE Licenses.LicenseID = @LicenseID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            try
            {
                con.Open();
                AffectedRow = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return AffectedRow > 0;
        }

        //InterNational Licenses

        public static DataTable GetInterLicenesHistoryByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"Select InternationalLicenses.InternationalLicenseID as 'Int.lLicenseID' , InternationalLicenses.ApplicationID as ApplicationID , InternationalLicenses.IssuedUsingLocalLicenseID as LicenseID,
InternationalLicenses.IssueDate as IssueDate, InternationalLicenses.ExpirationDate as ExpDate, InternationalLicenses.IsActive as IsActive from InternationalLicenses inner join Drivers on
InternationalLicenses.DriverID = Drivers.DriverID inner join People on People.PersonID = Drivers.PersonID Where People.PersonID = @PersonID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }

        public static int AddNewInternationalLicenses(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int LicensesID = -1;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"INSERT INTO InternationalLicenses (ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID) VALUES (@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID);
SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                con.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    LicensesID = result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return LicensesID;
        }

        public static bool GetInternationalLicensesByLicenseID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"SELECT * FROM InternationalLicenses where InternationalLicenseID = @InternationalLicenseID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                con.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    DriverID = (int)Reader["DriverID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    IssuedUsingLocalLicenseID = (int)Reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    
                    IsActive = (bool)Reader["IsActive"];
                    
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return IsFound;
        }

        public static bool GetInternationalLicensesByLocalLicenseID(ref int InternationalLicenseID, ref int ApplicationID, ref int DriverID,int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"SELECT * FROM InternationalLicenses where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            try
            {
                con.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    DriverID = (int)Reader["DriverID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    InternationalLicenseID = (int)Reader["InternationalLicenseID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];

                    IsActive = (bool)Reader["IsActive"];

                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return IsFound;
        }

        public static bool IsInterLicExistByLocallicID(int IssuedUsingLocalLicenseID)
        {
            bool isFound = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"Select X = 1 From InternationalLicenses where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return isFound;
        }

        public static DataTable GetAllInternationalLicenseApplications()
        {
            DataTable result = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"select InternationalLicenses.InternationalLicenseID as 'Int.LicenseID' , InternationalLicenses.ApplicationID As ApplicationID , InternationalLicenses.DriverID as DriverID , 
InternationalLicenses.IssueDate as IssueDate , InternationalLicenses.ExpirationDate as ExpDate,InternationalLicenses.IsActive as IsActive from InternationalLicenses";
            SqlCommand cmd = new SqlCommand(@Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message + "\n"); }
            finally { con.Close(); }
            return result;
        }

        //Detain License

        public static bool IsLicenseDetaiedByLicID(int LicenseID)
        {
            bool Result = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"Select IsReleased from DetainedLicenses Where DetainedLicenses.LicenseID = @LicenseID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    Result = !(bool)reader["IsReleased"];
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return Result;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"SELECT        dbo.DetainedLicenses.DetainID, dbo.DetainedLicenses.LicenseID, dbo.DetainedLicenses.DetainDate, dbo.DetainedLicenses.IsReleased, dbo.DetainedLicenses.FineFees, dbo.DetainedLicenses.ReleaseDate, 
                         dbo.People.NationalNo, dbo.People.FirstName + ' ' + dbo.People.SecondName + ' ' + ISNULL(dbo.People.ThirdName, ' ') + ' ' + dbo.People.LastName AS FullName, dbo.DetainedLicenses.ReleaseApplicationID
FROM            dbo.People INNER JOIN
                         dbo.Drivers ON dbo.People.PersonID = dbo.Drivers.PersonID INNER JOIN
                         dbo.Licenses ON dbo.Drivers.DriverID = dbo.Licenses.DriverID RIGHT OUTER JOIN
                         dbo.DetainedLicenses ON dbo.Licenses.LicenseID = dbo.DetainedLicenses.LicenseID";
            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message) ; }
            finally { con.Close(); }
            return dt;
        }

        public static DataTable IsLicenseDetainedByLicID(int LicenseID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"Select * from DetainedLicenses where DetainedLicenses.LicenseID = @LicenseID";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return dt;
        }

        public static int AddNewDetain(int LicenseID,DateTime DetainDate , float FineFees,int CreatedByUserID,bool IsReleased,DateTime? ReleaseDate,int? ReleasedByUserID,int? ReleaseApplicationID)
        {
            int DetainID = -1;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"INSERT INTO DetainedLicenses (LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased,ReleaseDate,ReleasedByUserID,ReleaseApplicationID) VALUES (@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,@IsReleased,@ReleaseDate,@ReleasedByUserID,@ReleaseApplicationID);SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);
            if (ReleaseDate == null)
                cmd.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            if (ReleasedByUserID == null)
                cmd.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            if (ReleaseApplicationID == null)
                cmd.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            try
            {
                con.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    DetainID = result;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return DetainID;
        }
        public static bool UpdateDetain(int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            int AffectedRows = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"UPDATE DetainedLicenses
   SET LicenseID = @LicenseID,DetainDate = @DetainDate,FineFees = @FineFees,CreatedByUserID = @CreatedByUserID,IsReleased = @IsReleased,ReleaseDate = @ReleaseDate,ReleasedByUserID = @ReleasedByUserID,ReleaseApplicationID = @ReleaseApplicationID
 WHERE DetainedLicenses.LicenseID = @LicenseID";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);
            if (ReleaseDate == null)
                cmd.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            if (ReleasedByUserID == null)
                cmd.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            if (ReleaseApplicationID == null)
                cmd.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            try
            {
                con.Open();
                AffectedRows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return AffectedRows > 0;

        }

        public static bool GetDetainedLicByDetainID(int DetainID,ref int LicenseID,ref DateTime DetainDate,ref float FineFees,ref int CreatedByUserID,ref bool IsReleased,ref DateTime ReleaseDate,ref int ReleasedByUserID,ref int ReleaseApplicationID)
        {
            bool IsFound = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = @"Select * from DetainedLicenses Where DetainID = @DetainID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@DetainID", DetainID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    IsFound = true;
                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = float.Parse(reader["FineFees"].ToString());
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    if (reader["ReleaseDate"] != DBNull.Value)
                    {
                        ReleaseDate = (DateTime)reader["ReleaseDate"];
                    }
                    if(reader["ReleasedByUserID"] != DBNull.Value)
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    if(reader["ReleaseApplicationID"] != DBNull.Value)
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { con.Close(); }
            return IsFound;
        }

        static void Main(string[] args)
        {
            
        }
    }
}
