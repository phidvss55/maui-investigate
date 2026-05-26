using Contact = MauiApp1.Model.Contact;

namespace MauiApp1.Repository;

public static class ContactRepository
{
    public static List<Contact> _contacts = new List<Contact>()
    {
        new Contact{ContactId = 1, Name = "John Doe", Phone = "123-456-7890"},
        new Contact{ContactId = 2, Name = "Jane Smith", Phone = "987-654-3210"},
        new Contact{ContactId = 3, Name = "Alice Johnson", Phone = "555-123-4567"},
        new Contact{ContactId = 4, Name = "Bob Brown", Phone = "555-987-6543"},
    };

    public static List<Contact> GetContacts() => _contacts;

    public static Contact GetContactById(int contactId)
    {
        var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
        if (contact != null)
        {
            return new Contact
            {
                ContactId = contact.ContactId,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone
            };
        }

        return new Contact();
    }

    public static void UpdateContact(int contactId, Contact contact)
    {
        if (contactId != contact.ContactId) return;

        var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);
        if (contactToUpdate != null)
        {
            contactToUpdate.Name = contact.Name;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.Phone = contact.Phone;
        }
    }

    public static void AddContact(Contact contact)
    {
        var newContactId = _contacts.Max(x => x.ContactId) + 1;
        contact.ContactId = newContactId;
        _contacts.Add(contact);
    }

    public static void DeleteContact(int contactId)
    {
        var contactToDelete = _contacts.FirstOrDefault(x => x.ContactId == contactId);
        if (contactToDelete != null)
        {
            _contacts.Remove(contactToDelete);
        }
    }
}