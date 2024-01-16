using System.Text.RegularExpressions;

namespace _Address_Book_
{
    public class UserInput
    {
        AddressBooks addressBooks;

        public UserInput(string connectionString)
        {
            addressBooks = new AddressBooks(connectionString);
        }

        public void GetAddressBookNameFromUser()
        {
            try
            {
                Console.Write("\nEnter the name for the new Address Book: ");
                string addressBookName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(addressBookName) || addressBookName.Any(char.IsDigit))
                {
                    throw new AddressBookException("Invalid address book name. Please enter a valid name without numbers or white spaces.");
                }

                addressBooks.AddAddressBook(addressBookName);
                
            }
            catch (AddressBookException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        public void GetContactDetailsFromUser()
        {
            try
            {
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

                Console.Write("In which AddressBook do you want to store the contact? ");
                string selectedAddressBook = Console.ReadLine();

                if (Regex.IsMatch(firstName, @"^[a-zA-Z]+$") &&
                    Regex.IsMatch(lastName, @"^[a-zA-Z]+$") &&
                    Regex.IsMatch(address, @"^[\w\s]+$") &&
                    Regex.IsMatch(city, @"^[a-zA-Z]+$") &&
                    Regex.IsMatch(state, @"^[a-zA-Z]+$") &&
                    Regex.IsMatch(phoneNumberString, @"^[6-9]\d{9}$") &&
                    Regex.IsMatch(zipString, @"^[1-9]{1}[0-9]{5}$") &&
                    Regex.IsMatch(email, @"^[\w.]+@[\w]+.[\w]{2,5}$"))
                {
                    int check = addressBooks.AddContact(firstName, lastName, address, city, state, phoneNumber, zip, email, selectedAddressBook);
                    if (check == 1)
                    {
                        Console.WriteLine("Contact added successfully.");
                    }
                }
                else
                {
                    Console.WriteLine($"\nInvalid input or Contact not added. Please check the input.");
                }
            }
            catch (AddressBookException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }


        public void GetSearchContactInputFromUser()
        {
            try
            {
                Console.Write("\nEnter the first name of the contact: ");
                string searchFirstName = Console.ReadLine();
                Console.Write("Enter the last name of the contact: ");
                string searchLastName = Console.ReadLine();
                Console.Write("In which AddressBook do you want to search for the contact? ");
                string selectedAddressBook = Console.ReadLine();

                Contact foundContact = addressBooks.SearchContact(searchFirstName, searchLastName, selectedAddressBook);

                if (foundContact != null)
                {
                    Console.WriteLine("\nContact found:");
                    Console.WriteLine(foundContact.ToString());
                }
                else
                {
                    Console.WriteLine("\nContact not found in the address book.");
                }
            }
            catch (AddressBookException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void GetContactDetailsForEdit()
        {
            try
            {
                Console.Write("\nEnter the first name of the contact to edit: ");
                string firstNameToEdit = Console.ReadLine();
                Console.Write("Enter the last name of the contact to edit: ");
                string lastNameToEdit = Console.ReadLine();
                Console.Write("In which AddressBook do you want to edit contact? ");
                string selectedAddressBook = Console.ReadLine();
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

                string phoneNumberString = Convert.ToString(newPhoneNumber);
                string zipString = Convert.ToString(newZipCode);

                if (Regex.IsMatch(newFirstName, @"^[a-zA-Z]+$") &&
                    Regex.IsMatch(newLastName, @"^[a-zA-Z]+$") &&
                    Regex.IsMatch(newAddress, @"^[\w\s]+$") &&
                    Regex.IsMatch(newCity, @"^[a-zA-Z]+$") &&
                    Regex.IsMatch(newState, @"^[a-zA-Z]+$") &&
                    Regex.IsMatch(phoneNumberString, @"^[6-9]\d{9}$") &&
                    Regex.IsMatch(zipString, @"^[1-9]{1}[0-9]{5}$") &&
                    Regex.IsMatch(newEmail, @"^[\w.]+@[\w]+.[\w]{2,5}$"))
                {
                    addressBooks.EditContact(firstNameToEdit, lastNameToEdit, newFirstName, newLastName, newAddress, newCity, newState, newPhoneNumber, newZipCode, newEmail, selectedAddressBook);
                }
                else
                {
                    Console.WriteLine($"\nInvalid input or Contact not added. Please check the input.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        public void GetContactDetailsForDeleteContact()
        {
            Console.Write("\nEnter the first name of the contact to delete: ");
            string firstNameToDelete = Console.ReadLine();
            Console.Write("Enter the last name of the contact to delete: ");
            string lastNameToDelete = Console.ReadLine();
            Console.Write("In which AddressBook do you want to delete contact? ");
            string selectedAddressBook = Console.ReadLine();

            try
            {
                addressBooks.DeleteContact(firstNameToDelete, lastNameToDelete, selectedAddressBook);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public List<Contact> GetCityContacts()
        {           
            try
            {
                Console.Write("In which AddressBook do you want to filter same city contact? ");
                string selectedAddressBook = Console.ReadLine();
                Console.Write("\nEnter the city name which you want to filter from the address book: ");
                string cityName = Console.ReadLine();
                List<Contact> cityContacts = addressBooks.GetPerticularCityContacts(selectedAddressBook, cityName);
                return cityContacts;
            }
            catch (AddressBookException ex)
            {
                Console.WriteLine($"Address Book Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return new List<Contact>();
        }


        public List<Contact> GetContacts()
        {
            Console.Write("In which AddressBook do you want to see contacts? ");
            string selectedAddressBook = Console.ReadLine();

            try
            {
                List<Contact> allContacts = addressBooks.GetAllContacts(selectedAddressBook);
                return allContacts;
            }
            catch (AddressBookException ex)
            {
                Console.WriteLine($"Address Book Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return new List<Contact>();
        }

    }
}
