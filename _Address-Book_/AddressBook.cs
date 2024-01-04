namespace _Address_Book_
{
    public class AddressBook
    {

        private List<Contact> contactList = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contactList.Add(contact);
        }

    }
}
