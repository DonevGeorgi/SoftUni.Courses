using Contacts.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Models.ViewModels
{
    public class ContactsInfoViewModel
    {
        public ContactsInfoViewModel(
            int id,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string address,
            string website)
        {
            ContactId = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Website = website;
        }

        public int ContactId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
    }


}
