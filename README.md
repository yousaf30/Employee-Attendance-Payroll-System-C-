# Employee-Attendance-Payroll-System-C-
Employee Attendance & Payroll System (C#)

A C# console application to manage employee attendance and automatically calculate payroll.
This version stores employee data in a CSV file, so all records are saved even after closing the program.

Features ✅

Add Employees: Store employee name, daily salary, and assign a unique ID.

Mark Attendance: Record daily attendance for employees.

Automatic Payroll Calculation: Calculates payroll based on days worked and daily salary.

View Employees & Payroll: Displays all employees with their total days worked and payroll.

Persistent Storage: Employee data is saved in employees.csv and loaded automatically on program start.

Dynamic Storage: Supports unlimited employees using a List<Employee>.

How to Run 💻

Clone the repository or download the source code.

Open the project in Visual Studio or any C# IDE.

Build and run the program.

Use the menu options to add employees, mark attendance, or view payroll reports.

Example Usage 📊
--- Employee Attendance & Payroll System ---
1. Add Employee
2. Mark Attendance
3. View Employees & Payroll
4. Exit
Choose an option: 1
Enter Employee Name: Ali
Enter Daily Salary: 500
Employee Added Successfully! ID: 1

Choose an option: 2
Enter Employee ID to mark attendance: 1
Attendance marked for Ali. Total days worked: 1

Choose an option: 3

--- Employees & Payroll ---
ID: 1 | Name: Ali | Days Worked: 1 | Daily Salary: $500.00 | Payroll: $500.00

Project Structure 📁
EmployeeAttendancePayroll/
├── Program.cs       # Main program file
├── employees.csv    # Automatically created CSV file for persistent storage
└── README.md        # Project documentation

Notes ✨

Uses List<Employee> for unlimited employee entries.

CSV storage ensures data persists after closing the program.

Beginner-friendly console program for learning C# basics, loops, lists, and file I/O.

Can be extended to include editing or deleting employees, reports, or salary adjustments.
