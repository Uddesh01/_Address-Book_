namespace _Address_Book_
{
    class Program
    {
        static void Main()
        {
            AddressBooks addressBooks = new AddressBooks();

            Console.WriteLine("**************** Welcome to Address Book Program ****************");

            while (true)
            {
                Console.WriteLine("\nWhat can I do for you?");
                Console.WriteLine("1. Add a new Address Book");
                Console.WriteLine("2. Switch to an existing Address Book");
                Console.WriteLine("3. Add a contact");
                Console.WriteLine("4. Search for a contact");
                Console.WriteLine("5. Edit a contact");
                Console.WriteLine("6. Delete a contact");
                Console.WriteLine("7. View all contacts");
                Console.WriteLine("8. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        addressBooks.AddAddressBook();
                        break;

                    case "2":
                        addressBooks.SwitchAddressBook();
                        break;

                    case "3":
                        addressBooks.AddContact();
                        break;

                    case "4":
                        addressBooks.SearchContact();
                        break;

                    case "5":
                        addressBooks.EditContact();
                        break;

                    case "6":
                        addressBooks.DeleteContact();
                        break;

                    case "7":
                        addressBooks.DisplayAllContacts();
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
    }
}