# ManageMyPasswords

ManageMyPasswords is a simple, secure desktop application for managing passwords. Built with C# and Windows Forms, it provides an easy-to-use interface for storing, retrieving, and organizing your passwords.

## Features

- Secure storage of passwords with encryption
- Categorize passwords for better organization
- Filter passwords by category and service
- Generate strong, random passwords
- Import passwords from CSV files
- Copy passwords to clipboard with a single click
- Configurable password generation (length, character types)

## Requirements

- .NET Framework 4.7.2 or higher
- MySQL Server 5.7 or higher

## Database Setup

This application uses MySQL as its database. You need to set up a MySQL server and create a database before running the application. Here's the structure of the required table:

```sql
CREATE TABLE passwords (
    id INT AUTO_INCREMENT PRIMARY KEY,
    category VARCHAR(100) NOT NULL,
    service VARCHAR(255) NOT NULL,
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    notes TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
```

## Setup Instructions

1. Clone the repository or download the source code.
2. Open the solution in Visual Studio.
3. Restore NuGet packages if necessary.
4. Build the solution.
5. Run the application.
6. On first run, you'll be prompted to enter your MySQL database connection details. Make sure you have a MySQL server running and a database created before this step.

## Usage

1. **Adding a password**: Fill in the category, service, username, and password fields, then click "Add Password".
2. **Generating a password**: Click "Generate Password" to create a random, strong password. You can configure the password generation settings in the Options menu.
3. **Filtering passwords**: Use the category and service dropdown menus to filter your passwords.
4. **Copying a password**: Click on the password in the list view to copy it to your clipboard.
5. **Importing passwords**: Go to File > Import CSV to import passwords from a CSV file. The CSV should have columns for category, service, username, password, and notes (optional).

## Security Note

While this application uses encryption for storing the database connection string and implements basic security measures, it's important to note that no password manager is 100% secure. Always use strong, unique passwords for critical accounts, and consider using additional security measures like two-factor authentication where available.

## Contributing

Contributions to ManageMyPasswords are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
