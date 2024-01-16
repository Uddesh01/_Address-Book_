using _Address_Book_;
using System.Data.SqlClient;


public class AddressBooks
{
    private SqlConnection connection;
    public AddressBooks(string ConnectionString)
    {
        connection = new SqlConnection(ConnectionString);
    }

    public void AddAddressBook(string addressBookName)
    {
        try
        {
            int addressBookID = GetAddressBookID(addressBookName);

            if (addressBookID == -1)
            {
                connection.Open();
                string insertAddressBookQuery = "INSERT INTO AddressBook (AddressBookName) VALUES (@Name)";
                SqlCommand insertAddressBookCommand = new SqlCommand(insertAddressBookQuery, connection);
                insertAddressBookCommand.Parameters.AddWithValue("@Name", addressBookName);
                insertAddressBookCommand.ExecuteNonQuery();
                Console.WriteLine($"\nAddress Book '{addressBookName}' created successfully!");
            }
            else
            {
                throw new AddressBookException($"Address Book '{addressBookName}' already exists.");
            }
        }
        catch (Exception ex)
        {
            throw new AddressBookException($"An error occurred while adding Address Book: {ex.Message}");
        }
        finally
        {
            connection.Close();
        }
    }



    public int AddContact(string firstName, string lastName, string address, string city, string state, long phoneNumber, int zip, string email, string selectedAddressBook)
    {
        int addressBookID = GetAddressBookID(selectedAddressBook);

        if (addressBookID != -1)
        {
            try
            {
                connection.Open();
                string insertContactQuery = "INSERT INTO Contact (FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email, AddressBookID) VALUES (@FirstName, @LastName, @Address, @City, @State, @ZIP, @PhoneNumber, @Email, @AddressBookID)";
                SqlCommand insertContactCommand = new SqlCommand(insertContactQuery, connection);

                insertContactCommand.Parameters.AddWithValue("@FirstName", firstName);
                insertContactCommand.Parameters.AddWithValue("@LastName", lastName);
                insertContactCommand.Parameters.AddWithValue("@Address", address);
                insertContactCommand.Parameters.AddWithValue("@City", city);
                insertContactCommand.Parameters.AddWithValue("@State", state);
                insertContactCommand.Parameters.AddWithValue("@ZIP", zip);
                insertContactCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                insertContactCommand.Parameters.AddWithValue("@Email", email);
                insertContactCommand.Parameters.AddWithValue("@AddressBookID", addressBookID);

                insertContactCommand.ExecuteNonQuery();
                return 1;
            }
            catch (AddressBookException ex)
            {
                throw new AddressBookException($"An error occurred while adding contact: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new AddressBookException($"An unexpected error occurred while adding contact: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
        else
        {
            throw new AddressBookException($"Address Book with the name '{selectedAddressBook}' not found.");
        }
    }


    private int GetAddressBookID(string addressBookName)
    {
        try
        {
            connection.Open();

            string getAddressBookIDQuery = "SELECT AddressBookID FROM AddressBook WHERE AddressBookName = @Name";
            SqlCommand getAddressBookIDCommand = new SqlCommand(getAddressBookIDQuery, connection);
            getAddressBookIDCommand.Parameters.AddWithValue("@Name", addressBookName);

            SqlDataReader reader = getAddressBookIDCommand.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            else
            {
                return -1;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while getting AddressBookID: {ex.Message}");
            return -1;
        }
        finally
        {
            connection.Close();
        }
    }



    public Contact SearchContact(string searchFirstName, string searchLastName, string selectedAddressBook)
    {
        Contact foundContact = null;

        try
        {
            int addressBookID = GetAddressBookID(selectedAddressBook);

            if (addressBookID != -1)
            {
                string searchContactQuery = "SELECT * FROM Contact WHERE FirstName = @FirstName AND LastName = @LastName AND AddressBookID = @AddressBookID";
                SqlCommand searchContactCommand = new SqlCommand(searchContactQuery, connection);
                searchContactCommand.Parameters.AddWithValue("@FirstName", searchFirstName);
                searchContactCommand.Parameters.AddWithValue("@LastName", searchLastName);
                searchContactCommand.Parameters.AddWithValue("@AddressBookID", addressBookID);

                connection.Open();
                SqlDataReader reader = searchContactCommand.ExecuteReader();

                if (reader.Read())
                {
                    foundContact = new Contact(
                        reader["FirstName"].ToString(),
                        reader["LastName"].ToString(),
                        reader["Address"].ToString(),
                        reader["City"].ToString(),
                        reader["State"].ToString(),
                        Convert.ToInt32(reader["ZipCode"]),
                        Convert.ToInt64(reader["PhoneNumber"]),
                        reader["Email"].ToString()
                    );
                }
            }
            else
            {
                throw new AddressBookException("Address book is not found.");
            }
        }
        catch (Exception ex)
        {
            throw new AddressBookException($"An error occurred while searching for a address book: {ex.Message}");
        }
        finally
        {
            connection.Close();
        }

        return foundContact;
    }
    public void EditContact(string firstNameToEdit, string lastNameToEdit, string newFirstName, string newLastName, string newAddress, string newCity, string newState, long newPhoneNumber, int newZipCode, string newEmail, string selectedAddressBook)
    {
        try
        {
            int addressBookID = GetAddressBookID(selectedAddressBook);

            if (addressBookID == -1)
            {
                throw new AddressBookException($"Address Book with the name '{selectedAddressBook}' not found.");
            }
            connection.Open();

            string updateContactQuery = "UPDATE Contact SET FirstName = @NewFirstName, LastName = @NewLastName, Address = @NewAddress, City = @NewCity, State = @NewState, ZipCode = @NewZipCode, PhoneNumber = @NewPhoneNumber, Email = @NewEmail WHERE FirstName = @FirstName AND LastName = @LastName AND AddressBookID = @AddressBookID";

            SqlCommand updateContactCommand = new SqlCommand(updateContactQuery, connection);
            {
                updateContactCommand.Parameters.AddWithValue("@NewFirstName", newFirstName);
                updateContactCommand.Parameters.AddWithValue("@NewLastName", newLastName);
                updateContactCommand.Parameters.AddWithValue("@NewAddress", newAddress);
                updateContactCommand.Parameters.AddWithValue("@NewCity", newCity);
                updateContactCommand.Parameters.AddWithValue("@NewState", newState);
                updateContactCommand.Parameters.AddWithValue("@NewZipCode", newZipCode);
                updateContactCommand.Parameters.AddWithValue("@NewPhoneNumber", newPhoneNumber);
                updateContactCommand.Parameters.AddWithValue("@NewEmail", newEmail);
                updateContactCommand.Parameters.AddWithValue("@FirstName", firstNameToEdit);
                updateContactCommand.Parameters.AddWithValue("@LastName", lastNameToEdit);
                updateContactCommand.Parameters.AddWithValue("@AddressBookID", addressBookID);

                int rowsAffected = updateContactCommand.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new AddressBookException("Contact not found in the address book.");
                }

                Console.WriteLine("Contact updated successfully!");
            }

        }
        catch (Exception ex)
        {

            throw new AddressBookException($"An unexpected error occurred while updating the contact: {ex.Message}");
        }
        finally
        {
            connection.Close();
        }
    }

    public void DeleteContact(string firstNameToDelete, string lastNameToDelete, string selectedAddressBook)
    {
        try
        {
            int addressBookID = GetAddressBookID(selectedAddressBook);

            if (addressBookID != -1)
            {
                string deleteQuery = "DELETE FROM Contact WHERE FirstName = @FirstName AND LastName = @LastName AND AddressBookID = @AddressBookID";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@FirstName", firstNameToDelete);
                deleteCommand.Parameters.AddWithValue("@LastName", lastNameToDelete);
                deleteCommand.Parameters.AddWithValue("@AddressBookID", addressBookID);

                connection.Open();
                int rowsAffected = deleteCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Contact deleted successfully");
                }
                else
                {
                    Console.WriteLine($"\nContact with the specified details not found in the Address Book '{selectedAddressBook}'.");
                }
            }
            else
            {
                throw new AddressBookException($"Address Book with the name '{selectedAddressBook}' not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred while deleting the contact: {ex.Message}");
        }
        finally
        {
            connection.Close();
        }
    }

    public List<Contact> GetPerticularCityContacts(string selectedAddressBook, string cityName)
    {
        List<Contact> cityContacts = new List<Contact>();

        try
        {
            int addressBookID = GetAddressBookID(selectedAddressBook);

            if (addressBookID != -1)
            {
                string filterCityQuery = "SELECT * FROM Contact WHERE City = @City AND AddressBookID = @AddressBookID";
                SqlCommand filterCityCommand = new SqlCommand(filterCityQuery, connection);
                filterCityCommand.Parameters.AddWithValue("@City", cityName);
                filterCityCommand.Parameters.AddWithValue("@AddressBookID", addressBookID);

                connection.Open();
                SqlDataReader reader = filterCityCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Contact contact = new Contact(
                            reader["FirstName"].ToString(),
                            reader["LastName"].ToString(),
                            reader["Address"].ToString(),
                            reader["City"].ToString(),
                            reader["State"].ToString(),
                            Convert.ToInt32(reader["ZipCode"]),
                            Convert.ToInt64(reader["PhoneNumber"]),
                            reader["Email"].ToString()
                        );
                        cityContacts.Add(contact);
                    }
                }
                else
                {
                    Console.WriteLine($"No contacts found for the city '{cityName}' in the Address Book '{selectedAddressBook}'.");
                }
            }
            else
            {
                throw new AddressBookException($"Invalid input or Address Book with the name '{selectedAddressBook}' not found.");
            }
        }
        catch (Exception ex)
        {
            throw new AddressBookException($"An unexpected error occurred while fetching city contacts: {ex.Message}");
        }
        finally
        {
            connection.Close();
        }

        return cityContacts;
    }


    public List<Contact> GetAllContacts(string selectedAddressBook)
    {
        List<Contact> allContacts = new List<Contact>();
        try
        {
            int addressBookID = GetAddressBookID(selectedAddressBook);

            if (addressBookID != -1)
            {
                string getAllContactQuery = "SELECT * FROM Contact WHERE AddressBookID = @AddressBookID";
                SqlCommand getAllContactCommand = new SqlCommand(getAllContactQuery, connection);
                getAllContactCommand.Parameters.AddWithValue("@AddressBookID", addressBookID);
                connection.Open();
                SqlDataReader reader = getAllContactCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Contact contact = new Contact(
                            reader["FirstName"].ToString(),
                            reader["LastName"].ToString(),
                            reader["Address"].ToString(),
                            reader["City"].ToString(),
                            reader["State"].ToString(),
                            Convert.ToInt32(reader["ZipCode"]),
                            Convert.ToInt64(reader["PhoneNumber"]),
                            reader["Email"].ToString()
                        );
                        allContacts.Add(contact);
                    }
                }
                else
                {
                    throw new AddressBookException($"No contacts found in the Address Book '{selectedAddressBook}'.");
                }
            }
            else
            {
                throw new AddressBookException($"\nInvalid input or Address Book with the name '{selectedAddressBook}' not found. Contact not added. Please check the input.");
            }
        }
        catch (Exception ex)
        {
            throw new AddressBookException($"An unexpected error occurred while fetching city contacts: {ex.Message}");
        }
        finally
        {
            connection.Close();
        }
        return allContacts;
    }
}