// 03. A company has name, address, phone number, fax number, web site and manager. 
//     The manager has first name, last name, age and a phone number. Write a program that reads the information about a company and its manager and prints them on the console.

using System;

class CompanyDetails
{
    static void Main()
    {
        Console.WriteLine("Please fill the company details:");

        Console.Write("Company name: ");
        string compName = Console.ReadLine();

        Console.Write("Company adress: ");
        string compAddr = Console.ReadLine();

        Console.Write("Company phone: ");
        string compPhone = Console.ReadLine();

        Console.Write("Company fax: ");
        string compFax = Console.ReadLine();

        Console.Write("Company website: ");
        string compWebsite = Console.ReadLine();

        Console.Write("Company manager(ID): ");
        int compManager = int.Parse(Console.ReadLine());


        // Manager
        Console.WriteLine("\nPlease fill the manager details:");

        Console.Write("Manager ID: ");
        int managerId = int.Parse(Console.ReadLine()); // We must have ID if we use relational database

        Console.Write("Manager first name: ");
        string managerFirstName = Console.ReadLine();

        Console.Write("Manager last name: ");
        string managerLastName = Console.ReadLine();

        Console.Write("Manager age: ");
        byte managerAge = byte.Parse(Console.ReadLine());

        Console.Write("Manager phone: ");
        string managerPhone = Console.ReadLine();

        Console.WriteLine("\nCompany Details:\nName:\t{0}\nAdress:\t{1}\nPhone Number:\t{2}\nFax Number:\t{3}\nWebsite:\t{4}\nManagerID:\t{5}\n", compName, compAddr, compPhone, compFax, compWebsite, compManager);
        Console.WriteLine("\nManager Details:\nFirst Name:\t{0}\nLast Name:\t{1}\nAge:\t{2}\nPhone Number:\t{3}", managerFirstName, managerLastName, managerAge, managerPhone);


    }
}
