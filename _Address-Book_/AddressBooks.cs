using _Address_Book_;
using System.Text.RegularExpressions;

public class AddressBooks
{
    private Dictionary<string, AddressBook> addressBooks = new Dictionary<string, AddressBook>();
    private AddressBook currentAddressBook;

    public void AddAddressBook()
    {
        Console.Write("\nEnter the name for the new Address Book: ");
        string addressBookName = Console.ReadLine();

        if (!addressBooks.ContainsKey(addressBookName))
        {
            AddressBook newAddressBook = new AddressBook();
            addressBooks.Add(addressBookName, newAddressBook);
            Console.WriteLine($"\nAddress Book '{addressBookName}' created successfully!");
        }
        else
        {
            Console.WriteLine($"\nAddress Book with the name '{addressBookName}' already exists.");
        }
    }

    public void SwitchAddressBook()
    {
        Console.Write("\nEnter the name of the Address Book to switch to: ");
        string addressBookName = Console.ReadLine();

        if (addressBooks.ContainsKey(addressBookName))
        {
            currentAddressBook = addressBooks[addressBookName];
            Console.WriteLine($"\nSwitched to Address Book '{addressBookName}'");
        }
        else
        {
            Console.WriteLine($"\nAddress Book with the name '{addressBookName}' not found.");
        }
    }

    public void AddContact()
    {
        if (currentAddressBook == null)
        {
            Console.WriteLine("\nPlease switch to an existing Address Book or create a new one.");
            return;
        }

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

        if (Regex.IsMatch(firstName, @"^[a-zA-Z]+$") && Regex.IsMatch(lastName, @"^[a-zA-Z]+$") &&
            Regex.IsMatch(address, @"^[\w]+$") && Regex.IsMatch(city, @"^[a-zA-Z]+$") &&
            Regex.IsMatch(state, @"^[a-zA-Z]+$") && Regex.IsMatch(phoneNumberString, @"^[6-9]\d{9}$") &&
            Regex.IsMatch(zipString, @"^[1-9]{1}[0-9]{5}$") && Regex.IsMatch(email, @"^[\w.]+@[\w]+.[\w]{2,5}$"))
        {
            Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            currentAddressBook.AddContact(newContact);
            Console.WriteLine("\nContact added successfully!");
        }
        else
        {
            Console.WriteLine("\nInvalid input. Contact not added. Please check the input.");
        }
    }

    public void SearchContact()
    {
        if (currentAddressBook == null)
        {
            Console.WriteLine("\nPlease switch to an existing Address Book or create a new one.");
            return;
        }

        Console.Write("\nEnter the first name of the contact: ");
        string searchFirstName = Console.ReadLine();
        Console.Write("Enter the last name of the contact: ");
        string searchLastName = Console.ReadLine();

        Contact foundContact = currentAddressBook.FindContactByName(searchFirstName, searchLastName);

        if (foundContact != null)
        {
            Console.WriteLine("\nContact found:");
            Console.WriteLine($"Name: {foundContact.FirstName} {foundContact.LastName}");
            Console.WriteLine($"Address: {foundContact.Address}");
            Console.WriteLine($"City: {foundContact.City}");
            Console.WriteLine($"State: {foundContact.State}");
            Console.WriteLine($"ZIP: {foundContact.ZipCode}");
            Console.WriteLine($"Phone Number: {foundContact.PhoneNumber}");
            Console.WriteLine($"Email: {foundContact.Email}");
        }
        else
        {
            Console.WriteLine("\nContact not found in the address book.");
        }
    }

    public void EditContact()
    {
  
        if (currentAddressBook == null)
        {
            Console.WriteLine("\nPlease switch to an existing Address Book or create a new one.");
            return;
        }

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

        currentAddressBook.UpdateContact(firstNameToEdit, lastNameToEdit, newFirstName, newLastName, newAddress, newCity, newState, newZipCode, newPhoneNumber, newEmail);
    }

    public void DeleteContact()
    {

        if (currentAddressBook == null)
        {
            Console.WriteLine("\nPlease switch to an existing Address Book or create a new one.");
            return;
        }

        Console.Write("\nEnter the first name of the contact to delete: ");
        string firstNameToDelete = Console.ReadLine();
        Console.Write("Enter the last name of the contact to delete: ");
        string lastNameToDelete = Console.ReadLine();

        currentAddressBook.DeleteContact(firstNameToDelete, lastNameToDelete);
    }

    public void DisplayAllContacts()
    {

        if (currentAddressBook == null)
        {
            Console.WriteLine("\nPlease switch to an existing Address Book or create a new one.");
            return;
        }

        currentAddressBook.DisplayAllContacts();
    }
}