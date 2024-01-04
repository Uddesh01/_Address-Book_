namespace _Address_Book_
{
    public class AddressBook
    {

        private List<Contact> contactList = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contactList.Add(contact);
        }

        public Contact FindContactByName(string firstName, string lastName)
        {
            foreach (Contact contact in contactList)
            {
                if (contact.FirstName == firstName && contact.LastName == lastName)
                {
                    return contact;
                }
            }
            return null;
        }

        public void UpdateContact(string firstName, string lastName, string newFirstName, string newLastName, string newAddress, string newCity, string newState, int newZipCode, long newPhoneNumber, string newEmail)
        {
            Contact contactToUpdate = FindContactByName(firstName, lastName);

            if (contactToUpdate != null)
            {
                contactToUpdate.FirstName = newFirstName;
                contactToUpdate.LastName = newLastName;
                contactToUpdate.Address = newAddress;
                contactToUpdate.City = newCity;
                contactToUpdate.State = newState;
                contactToUpdate.ZipCode = newZipCode;
                contactToUpdate.PhoneNumber = newPhoneNumber;
                contactToUpdate.Email = newEmail;
                Console.WriteLine("Contact updated successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found in the address book.");
            }
        }

        public void DisplayAllContacts()
        {
            Console.WriteLine("\nAll Contacts in the Address Book:");
            foreach (var contact in contactList)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Address: {contact.Address}");
                Console.WriteLine($"City: {contact.City}");
                Console.WriteLine($"State: {contact.State}");
                Console.WriteLine($"ZIP: {contact.ZipCode}");
                Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}\n");
            }
        }

    }
}
