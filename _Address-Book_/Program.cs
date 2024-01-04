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
            Console.WriteLine("2. Exit");

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
                    Console.WriteLine("Exiting the program");
                    return;
                    
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
        }
    }
}