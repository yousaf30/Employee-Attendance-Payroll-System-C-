using System;
using System.Collections.Generic;
using System.IO;

class Employee
{
    public int id;
    public string name;
    public decimal dailySalary;
    public int daysWorked;

    public decimal CalculatePayroll()
    {
        return dailySalary * daysWorked;
    }

    // Convert employee to CSV line
    public string ToCsv()
    {
        return $"{id},{name},{dailySalary},{daysWorked}";
    }

    // Parse CSV line to employee
    public static Employee FromCsv(string line)
    {
        string[] parts = line.Split(',');
        Employee e = new Employee();
        e.id = int.Parse(parts[0]);
        e.name = parts[1];
        e.dailySalary = decimal.Parse(parts[2]);
        e.daysWorked = int.Parse(parts[3]);
        return e;
    }
}

class Program
{
    static List<Employee> employees = new List<Employee>();
    static int employeeCount = 0;
    static string filePath = "employees.csv"; // file to store employee data

    static void Main()
    {
        LoadEmployees(); // Load data from file at start

        while (true)
        {
            Console.WriteLine("\n--- Employee Attendance & Payroll System ---");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Mark Attendance");
            Console.WriteLine("3. View Employees & Payroll");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1") AddEmployee();
            else if (choice == "2") MarkAttendance();
            else if (choice == "3") ViewEmployees();
            else if (choice == "4")
            {
                SaveEmployees(); // Save data before exit
                break;
            }
            else Console.WriteLine("Invalid option!");
        }
    }

    static void AddEmployee()
    {
        Employee e = new Employee();
        e.id = employeeCount + 1;

        Console.Write("Enter Employee Name: ");
        e.name = Console.ReadLine();

        Console.Write("Enter Daily Salary: ");
        e.dailySalary = decimal.Parse(Console.ReadLine());

        e.daysWorked = 0;

        employees.Add(e);
        employeeCount++;

        Console.WriteLine($"Employee Added Successfully! ID: {e.id}");
        SaveEmployees(); // Save after adding
    }

    static void MarkAttendance()
    {
        Console.Write("Enter Employee ID to mark attendance: ");
        int id = int.Parse(Console.ReadLine());

        Employee e = employees.Find(emp => emp.id == id);
        if (e != null)
        {
            e.daysWorked++;
            Console.WriteLine($"Attendance marked for {e.name}. Total days worked: {e.daysWorked}");
            SaveEmployees(); // Save after updating attendance
        }
        else
        {
            Console.WriteLine("Employee not found!");
        }
    }

    static void ViewEmployees()
    {
        Console.WriteLine("\n--- Employees & Payroll ---");
        foreach (Employee e in employees)
        {
            Console.WriteLine($"ID: {e.id} | Name: {e.name} | Days Worked: {e.daysWorked} | Daily Salary: {e.dailySalary:C} | Payroll: {e.CalculatePayroll():C}");
        }
    }

    static void SaveEmployees()
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (Employee e in employees)
            {
                sw.WriteLine(e.ToCsv());
            }
        }
    }

    static void LoadEmployees()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Employee e = Employee.FromCsv(line);
                employees.Add(e);
            }
            if (employees.Count > 0)
                employeeCount = employees[employees.Count - 1].id; // Continue ID from last employee
        }
    }
}
