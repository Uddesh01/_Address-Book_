using _Address_Book_;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        AddressBook addressBook = new AddressBook();
        Console.WriteLine("**************** Welcome to Address Book Program ****************");
        while (true)
        {
            Console.WriteLine("\nWhat can I do for you?");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. Search for a contact");
            Console.WriteLine("3. Edit a contact");
            Console.WriteLine("4. Delete a contact");
            Console.WriteLine("5. View all contacts");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
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

                    string phoneNumberString = Convert.ToString(phoneNumber);
                    string zipString = Convert.ToString(zip);

                    /* Console.WriteLine($"FirstName: {firstName}, IsValid: {Regex.IsMatch(firstName, @"^[a-zA-Z]+$")}");
                     Console.WriteLine($"LastName: {lastName}, IsValid: {Regex.IsMatch(lastName, @"^[a-zA-Z]+$")}");
                     Console.WriteLine($"Address: {address}, IsValid: {Regex.IsMatch(address, @"^[\w]+$")}");
                     Console.WriteLine($"City: {city}, IsValid: {Regex.IsMatch(city, @"^[a-zA-Z]+$")}");
                     Console.WriteLine($"State: {state}, IsValid: {Regex.IsMatch(state, @"^[a-zA-Z]+$")}");
                     Console.WriteLine($"PhoneNumber: {phoneNumberString}, IsValid: {Regex.IsMatch(phoneNumberString, @"^[6-9]\d{9}$")}");
                     Console.WriteLine($"ZipCode: {zipString}, IsValid: {Regex.IsMatch(zipString, @"^[1-9]{1}[0-9]{5}$")}");
                     Console.WriteLine($"Email: {email}, IsValid: {Regex.IsMatch(email, @"^[\w.]+@[\w]+.[\w]{2,5}$")}"); */

                    if (Regex.IsMatch(firstName, @"^[a-zA-Z]+$") && Regex.IsMatch(lastName, @"^[a-zA-Z]+$") &&
                        Regex.IsMatch(address, @"^[\w]+$") && Regex.IsMatch(city, @"^[a-zA-Z]+$") &&
                        Regex.IsMatch(state, @"^[a-zA-Z]+$") && Regex.IsMatch(phoneNumberString, @"^[6-9]\d{9}$") &&
                        Regex.IsMatch(zipString, @"^[1-9]{1}[0-9]{5}$") && Regex.IsMatch(email, @"^[\w.]+@[\w]+.[\w]{2,5}$"))
                    {
                        Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                        addressBook.AddContact(newContact);
                        Console.WriteLine("\nContact added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input.Contact not added.Please check the input.");
                    }
                    break;

                case "2":
                    Console.Write("\nEnter the first name of the contact: ");
                    string _firstName = Console.ReadLine();
                    Console.Write("Enter the last name of the contact: ");
                    string _lastName = Console.ReadLine();

                    Contact contact = addressBook.FindContactByName(_firstName, _lastName);
                    if (contact != null)
                    {
                        Console.WriteLine("\nContact found:");
                        Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                        Console.WriteLine($"Address: {contact.Address}");
                        Console.WriteLine($"City: {contact.City}");
                        Console.WriteLine($"State: {contact.State}");
                        Console.WriteLine($"ZIP: {contact.ZipCode}");
                        Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                        Console.WriteLine($"Email: {contact.Email}");
                    }
                    else
                    {
                        Console.WriteLine("\nContact not found in the address book.");
                    }
                    break;

                case "3":
                    Console.Write("\nEnter the first name of the contact to edit: ");
                    string firstNameToEdit = Console.ReadLine();
                    Console.Write("Enter the last name of the contact to edit: ");
                    string lastNameToEdit = Console.ReadLine();

                    Console.Write("Enter the new first name: ");
                    string newFirstName = Console.ReadLine();
                    Console.Write("Enter the new last name: ");
                    string newLastName = Console.ReadLine();
                    Console.Write("Enter the new address: ");
                    string newAddress = Console.ReadLine();
                    Console.Write("Enter the new city: ");
                    string newCity = Console.ReadLine();
                    Console.Write("Enter the new state: ");
                    string newState = Console.ReadLine();
                    Console.Write("Enter the new ZIP: ");
                    int newZipCode = int.Parse(Console.ReadLine());
                    Console.Write("Enter the new phone number: ");
                    long newPhoneNumber = long.Parse(Console.ReadLine());
                    Console.Write("Enter the new email: ");
                    string newEmail = Console.ReadLine();

                    addressBook.UpdateContact(firstNameToEdit, lastNameToEdit, newFirstName, newLastName, newAddress, newCity, newState, newZipCode, newPhoneNumber, newEmail);
                    break;

                case "4":
                    Console.Write("\nEnter the first name of the contact to delete: ");
                    string firstNameToDelete = Console.ReadLine();
                    Console.Write("Enter the last name of the contact to delete: ");
                    string lastNameToDelete = Console.ReadLine();

                    addressBook.DeleteContact(firstNameToDelete, lastNameToDelete);
                    break;

                case "5":
                    addressBook.DisplayAllContacts();
                    break;

                case "6":
                    Console.WriteLine("Exiting the program");
                    return;


                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
        }
    }
}