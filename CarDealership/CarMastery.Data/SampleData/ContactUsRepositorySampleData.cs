using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class ContactUsRepositorySampleData : IContactUsRepository
    {
        public static List<ContactUs> _Contacts = new List<ContactUs>
        {
            new ContactUs
            { ContactUsId = 1, ContactUsFirstName = "Jane", ContactUsLastName = "Doe", ContactUsEmail = "janedoe@test1.com", ContactUsPhone = "111-111-1111", ContactUsMessage = "Test1 Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
             new ContactUs
            { ContactUsId = 2, ContactUsFirstName = "John", ContactUsLastName = "Smith", ContactUsEmail = "johnsmith@test2.com", ContactUsPhone = "222-222-2222", ContactUsMessage = "Test2 Lorem ipsum dolor sit amet, consectetur adipiscing elit." }
        };

        public void AddContact(ContactUs contact)
        {

            contact.ContactUsId = _Contacts.Max(m => m.ContactUsId) + 1;
            _Contacts.Add(contact);
        }

        public List<ContactUs> GetAllContactRequests()
        {
            List<ContactUs> list = new List<ContactUs>();

            foreach (var contact in _Contacts)
            {
                ContactUs currentRow = new ContactUs();
                currentRow.ContactUsId = contact.ContactUsId;
                currentRow.ContactUsFirstName = contact.ContactUsFirstName;
                currentRow.ContactUsLastName = contact.ContactUsLastName;
                currentRow.ContactUsEmail = contact.ContactUsEmail;
                currentRow.ContactUsPhone = contact.ContactUsPhone;
                currentRow.ContactUsMessage = contact.ContactUsMessage;
                list.Add(currentRow);
            }
            return list;
        }

        public void DeleteContact(int contactId)
        {
            _Contacts.RemoveAll(c => c.ContactUsId == contactId);
        }
    }
}
