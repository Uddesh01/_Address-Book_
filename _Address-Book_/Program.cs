
using _Address_Book_;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("**************** Welcome to Address Book Program ****************");

        Console.Write("\nEnter the first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter the last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter the address: ");
        string address = Console.ReadLine();
        Console.Write("Enter the city: ");
        string city = Console.ReadLine();
        Console.Write("Enter the state: ");
        string state = Console.ReadLine();
        Console.Write("Enter the ZIP: ");
        int zip = int.Parse(Console.ReadLine());
        Console.Write("Enter the phone number: ");
        long phoneNumber = long.Parse(Console.ReadLine());
        Console.Write("Enter the email: ");
        string email = Console.ReadLine();

       
        Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);

        Console.WriteLine("\nContact created successfully!");
    }
}
