using _Address_Book_;
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
            Console.WriteLine("2. Edit a contact");
            Console.WriteLine("3. Delete a contact");
            Console.WriteLine("4. View all contacts");
            Console.WriteLine("5. Exit");

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

                    Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);

                    addressBook.AddContact(newContact);

                    Console.WriteLine("\nContact added successfully!");
                    break;

                case "2":
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

                case "3":
                    Console.Write("\nEnter the first name of the contact to delete: ");
                    string firstNameToDelete = Console.ReadLine();
                    Console.Write("Enter the last name of the contact to delete: ");
                    string lastNameToDelete = Console.ReadLine();

                    addressBook.DeleteContact(firstNameToDelete, lastNameToDelete);
                    break;

                case "4":
                    addressBook.DisplayAllContacts();
                    break;

                case "5":
                    Console.WriteLine("Exiting the program");
                    return;


                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
        }
    }
}