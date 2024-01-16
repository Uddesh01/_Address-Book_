namespace _Address_Book_
{
    class Program
    {
        static void Main()
        {

            string ConnectionString = "Data Source=DESKTOP-GCJINDI\\SQLEXPRESS;Initial Catalog=AddressBookDB;Integrated Security=True;";
            AddressBooks addressBooks = new AddressBooks(ConnectionString);
            UserInput userInput = new UserInput(ConnectionString);

            Console.WriteLine("**************** Welcome to Address Book Program ****************");

            while (true)
            {
                Console.WriteLine("\nWhat can I do for you?");
                Console.WriteLine("1. Add a new Address Book");
                Console.WriteLine("2. Add a contact");
                Console.WriteLine("3. Search for a contact");   
                Console.WriteLine("4. Edit a contact");
                Console.WriteLine("5. Delete a contact");
                Console.WriteLine("6. Display all contact from city name");
                Console.WriteLine("7. Display all contact from addressbook");
                Console.WriteLine("8. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        userInput.GetAddressBookNameFromUser();
                        break;

                    case "2":
                        userInput.GetContactDetailsFromUser();
                        break;

                    case "3":
                        userInput.GetSearchContactInputFromUser();
                        break;

                    case "4":
                        userInput.GetContactDetailsForEdit();
                        break;

                    case "5":
                        userInput.GetContactDetailsForDeleteContact();
                        break;

                    case "6":
                        List<Contact> cityContacts = userInput.GetCityContacts();

                        if (cityContacts.Count > 0)
                        {
                            Console.WriteLine("Contacts from the same city:");
                            DisplayContacts(cityContacts);
                        }
                        break;

                    case "7":
                        List<Contact> allContacts = userInput.GetContacts();

                        if (allContacts.Count > 0)
                        {
                            Console.WriteLine($"\nAll contacts from the addressbook:\n");
                            DisplayContacts(allContacts);
                        }
                        break;

                    case "8":
                        Console.WriteLine("Exiting the program");
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayContacts(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Address: {contact.Address}");
                Console.WriteLine($"City: {contact.City}");
                Console.WriteLine($"State: {contact.State}");
                Console.WriteLine($"ZIP: {contact.ZipCode}");
                Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine("*****************************************");
            }
        }
    }
}