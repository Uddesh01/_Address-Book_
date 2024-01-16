namespace _Address_Book_
{
   public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            ZipCode = zip;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\n" +
                   $"Address: {Address}\n" +
                   $"City: {City}\n" +
                   $"State: {State}\n" +
                   $"ZIP: {ZipCode}\n" +
                   $"Phone Number: {PhoneNumber}\n" +
                   $"Email: {Email}\n";
        }
    }
}
