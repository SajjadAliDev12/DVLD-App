using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDBussinessLayer;

namespace DVLD_Program
{
    public class UserInterface
    {
        public static void FindPersonById(int PersonID)
        {
            DVLDBussinessLayer.BussinessLayer.clsPerson Person = new DVLDBussinessLayer.BussinessLayer.clsPerson();
            Person = DVLDBussinessLayer.BussinessLayer.clsPerson.FindPersonById(PersonID);
            if (Person != null)
            {
                Console.WriteLine("\n\nPerosn Found:- \n\n" + Person.FirstName + " " + Person.LastName + "\n" + Person.Gender);
                Console.WriteLine(Person.PersonID + " \n" +  Person.NationalNumber);
                Console.WriteLine(Person.Address + " \n" + Person.BirthDate + " \n" + Person.Email + "\n" + Person.PhotoPath + "\n" + Person.Phone);
            }
            else
            {
                Console.WriteLine("Could Not Find Perosn");
            }

        }

        public static void FindPersonByNationalNumber(string NationalNumber)
        {
            DVLDBussinessLayer.BussinessLayer.clsPerson Person = new DVLDBussinessLayer.BussinessLayer.clsPerson();
            Person = DVLDBussinessLayer.BussinessLayer.clsPerson.FindPersonByNationalNumber(NationalNumber);
            if (Person != null)
            {
                Console.WriteLine("\n\nPerosn Found:- \n\n" + Person.FirstName + " " + Person.LastName + "\n" + Person.Gender);
                Console.WriteLine(Person.PersonID + " \n"  + Person.NationalNumber);
                Console.WriteLine(Person.Address + " \n" + Person.BirthDate + " \n" + Person.Email + "\n" + Person.PhotoPath + "\n" + Person.Phone);
            }
            else
            {
                Console.WriteLine("Could Not Find Perosn");
            }

        }

        static void AddNewPerson()
        {
            DVLDBussinessLayer.BussinessLayer.clsPerson Person = new DVLDBussinessLayer.BussinessLayer.clsPerson();
            Person.FirstName = "Fatema";
            Person.SecondName = "Nadhem";
            Person.ThirdName = "Abed";
            Person.LastName = "Alawny";
            Person.NationalNumber = "00000114";
            Person.BirthDate = new DateTime(1992, 5, 20);
            Person.Gender = 1;
            Person.Address = "Ur street";
            Person.Email = "Somthing@somthing.com";
            Person.PhotoPath = "No Photo";
            Person.Phone = "485743434";
            Person.NationalityCountryID = 1;

            if (Person.Save())
                Console.WriteLine("Person Added with ID = " + Person.PersonID);
            else { Console.WriteLine("Opration Failed"); }
        }

        static void UpdatePerson()
        {
            DVLDBussinessLayer.BussinessLayer.clsPerson Person = new DVLDBussinessLayer.BussinessLayer.clsPerson();
            Person = DVLDBussinessLayer.BussinessLayer.clsPerson.FindPersonById(1025);

            Person.FirstName = "Sajjad";
            Person.SecondName = "Ali";
            Person.ThirdName = "Mohsin";
            Person.LastName = "Almosawy";
            Person.NationalNumber = "00000114";
            Person.BirthDate = new DateTime(1992, 5, 20);
            Person.Gender = 0;
            Person.Address = "Ur street";
            Person.Email = "Somthing@somthing.com";
            Person.PhotoPath = "No Photo";
            Person.Phone = "485743434";

            if (Person.Save())
                Console.WriteLine("Person with ID = " + Person.PersonID + " Updated succesfully");
            else { Console.WriteLine("Failed to update person with ID " + Person.PersonID); }
        }

        static void IsPersonExist(int PersonID)
        {
            if (DVLDBussinessLayer.BussinessLayer.clsPerson.IsPersonExist(PersonID))
            {
                Console.WriteLine("Person with ID = " + PersonID + " is found!");
            }
            else { Console.WriteLine("Person with ID = " + PersonID + " is not found"); }
        }

        static void IsPersonExist(string NationalNumber)
        {
            if (DVLDBussinessLayer.BussinessLayer.clsPerson.IsPersonExist(NationalNumber))
            {
                Console.WriteLine("Person with NationalNumber = " + NationalNumber + " is found!");
            }
            else { Console.WriteLine("Person with NationalNumber = " + NationalNumber + " is not found"); }
        }

        static void DeletePerson(int PersonID)
        {
            Console.WriteLine("Are you sure to delete person with Id = " + PersonID + " ?(Y/N)");
            string Answer = "N";
            Answer = Console.ReadLine();
            if (Answer == "Y")
            {
                if (DVLDBussinessLayer.BussinessLayer.clsPerson.DeletePerson(PersonID))
                {
                    Console.WriteLine("Person with ID = " + PersonID + " Deleted!");
                }
                else
                {
                    Console.WriteLine("Person with ID = " + PersonID + " is not found");
                }
            }
            else
            { Console.WriteLine("Canceled"); }
        }

        static void ShowAllPeople()
        {
            DataTable dt = new DataTable();
            dt = DVLDBussinessLayer.BussinessLayer.clsPerson.ShowAllPeople();
            foreach (DataRow row in dt.Rows)
            {

                Console.Write("\n" + row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString() + " " + row[4].ToString() + " " + row[5].ToString() + " " + row[7].ToString() + " " + row[8].ToString() + " " + row[9].ToString());
                if (row[6].ToString() == "1")
                    Console.Write(" Female\n");
                else
                { Console.Write(" Male\n"); }
            }
        }

        public static void GetUserInfoByPersonID(int PersonID)
        {
            DVLDBussinessLayer.BussinessLayer.clsUser User1 = new DVLDBussinessLayer.BussinessLayer.clsUser();
            User1 = DVLDBussinessLayer.BussinessLayer.clsUser.FindUserByPersonID(PersonID);
            if (User1 != null)
            {
                Console.WriteLine("\nUser Found\n");
                Console.WriteLine(User1.UserID.ToString() + " " + User1.UserName.ToString() + " " + User1.PersonID.ToString() + " " + User1.Password.ToString() + " " + User1.isActive.ToString());
            }
        }

        public static void GetUserInfoByUserID(int UserID)
        {
            DVLDBussinessLayer.BussinessLayer.clsUser User1 = new DVLDBussinessLayer.BussinessLayer.clsUser();
            User1 = DVLDBussinessLayer.BussinessLayer.clsUser.FindUserByUserID(UserID);
            if (User1 != null)
            {
                Console.WriteLine("\nUser Found\n");
                Console.WriteLine(User1.UserID.ToString() + " " + User1.UserName.ToString() + " " + User1.PersonID.ToString() + " " + User1.Password.ToString() + " " + User1.isActive.ToString());
            }
        }
        public static void GetCountyByID(int ID)
        {
            Console.WriteLine(BussinessLayer.clsPerson.GetCountryByID(ID));
        }

        [STAThread]
        static void Main(string[] args)
        {
            //frmMainScreen frm = new frmMainScreen();
            //frm.ShowDialog();
            ////GetCountyByID(90);
            frmLoginScreen frm = new frmLoginScreen();
            frm.ShowDialog();
            //GetUserInfoByUserID(269);
            //Console.ReadLine();



        }
    }
}
