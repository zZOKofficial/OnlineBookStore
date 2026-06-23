# Online Book Store

Online Book Store is a Windows desktop application built with C#, Windows Forms, .NET Framework 4.8, and Microsoft SQL Server. It is designed as a complete bookstore management system that can be used in bookstores, libraries, or similar environments where inventory, customers, and order handling need to be managed in a structured way.

The application is based on three user roles: Administrator, Manager, and Customer. Each role has its own responsibilities and restricted access to ensure proper separation of concerns and system security.

---

## Features

### Administrator
The administrator has full control over the system. This includes managing users, overseeing operations, and controlling access levels. Only the administrator can create manager accounts. Administrators can also manage customer accounts and remove or restrict users when required.

### Manager
Managers handle the operational side of the bookstore. They can add new books, update existing records, manage stock, and process customer orders. Manager accounts are created and managed exclusively by the administrator.

### Customer
Customers can register, browse available books, place orders, and manage their profile information. They can update personal details such as name, gender, and date of birth after creating an account.

---

## Technology Stack

- C#
- .NET Framework 4.8
- Windows Forms
- Microsoft SQL Server

---

## Getting Started

### Requirements

Before running the project, ensure the following are installed:

- Microsoft Visual Studio
- Microsoft SQL Server
- SQL Server Management Studio (recommended)

### Installation Steps

1. Clone or download the repository.
2. Execute the provided SQL script in SQL Server to create the database and required tables.
3. Open the solution file `OnlineBookStore.sln` in Visual Studio.
4. Locate the database connection string in the project configuration and update it with your local SQL Server details.
5. Build and run the project.

After configuration, the application should run without additional setup.

---

## Screenshots

Screenshots will be added in future updates.

---

## Contributing

Contributions are welcome and appreciated. If you would like to improve this project, fix bugs, or add new features, please fork the repository and submit a pull request with your changes.

Before contributing, ensure your changes are well-tested and aligned with the existing project structure and coding style.

For more detailed guidelines, please refer to the `CONTRIBUTING.md` file in the repository.

---

## Notes

This project is actively maintained and may receive updates that include bug fixes, performance improvements, and UI enhancements.

---

## License

All rights reserved.

This project is shared for learning and collaboration purposes. No permission is granted for commercial use, redistribution, or modification without prior approval.

---

## Developer

Md. Maruf Hossain  
Founder, OxyOrb
