# Driving & Vehicle License Department (DVLD) System

A robust desktop application for managing the issuance, renewal, and suspension of driving licenses. This project demonstrates complex relational database management and strict business logic implementation.

## 🚀 Key Features
* **License Management:** Issue Local and International driving licenses.
* **Tests Management:** Schedule and manage Vision, Written, and Street tests.
* **Driver History:** comprehensive tracking of driver's licenses and violations.
* **Detain/Release Licenses:** System to handle license suspension based on fines or violations.
* **User Management:** Role-based access control for system administrators and officers.

## 🛠️ Technology Stack
* **Language:** C#
* **Framework:** .NET (Windows Forms).
* **Data Access:** ADO.NET.
* **Database:** Microsoft SQL Server (Complex Relational Schema).

## 🔑 Login Credentials (For Testing)
To access the system immediately after installation, use the following default admin credentials:
* **Username:** `sajjad`
* **Password:** `12345`
  
## ⚙️ Setup & Installation
1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/SajjadAliDev12/DVLD-Program.git]
    ```
    
2.  **Database Setup:**
    * **Crucial Step:**Create a New DataBase with the Name `DVLD` then Run the `DataBaseSetup.sql` file found in the root directory to set up the database structure and initial data.
3.  **Run:**
    * Open the solution in Visual Studio.
    * Ensure the connection string in the DataAccessLayer matches your server.
    * Build and Run.
    * If the DataLayer and BussinessLayer (Not Found) in the solution try yo remove and add them again form visual studio and add the refrence for Bussiness Layer in the main App

## 📸 Screenshots
<img width="1915" height="1075" alt="Screenshot 2026-01-06 161525" src="https://github.com/user-attachments/assets/527507bd-f5a6-497d-9e1a-58f421dfcfd5" />
<img width="1919" height="1079" alt="Screenshot 2026-01-06 161503" src="https://github.com/user-attachments/assets/b460b7cb-fa1c-4400-ae8b-09520ea1c625" />
<img width="1919" height="1079" alt="Screenshot 2026-01-06 161342" src="https://github.com/user-attachments/assets/265621f0-e5cd-4d64-b9c7-4449dab83214" />
<img width="1919" height="1079" alt="Screenshot 2026-01-06 161322" src="https://github.com/user-attachments/assets/0b6e40dd-34e0-44a8-bd06-c5b49bbd41a6" />
<img width="1919" height="1079" alt="Screenshot 2026-01-06 161311" src="https://github.com/user-attachments/assets/f92412f3-0869-4718-b98a-69f337ae2c87" />
<img width="1919" height="1079" alt="Screenshot 2026-01-06 161250" src="https://github.com/user-attachments/assets/29973a7b-fe36-490e-ad8b-c26b57694dca" />
<img width="1912" height="1030" alt="Screenshot 2026-01-06 161226" src="https://github.com/user-attachments/assets/fff54191-2afd-4d70-8f0c-7d1fd20db3c9" />
<img width="645" height="500" alt="Screenshot 2026-01-06 161203" src="https://github.com/user-attachments/assets/208417ab-e5a8-4d53-9308-4d4928dfde6f" />

