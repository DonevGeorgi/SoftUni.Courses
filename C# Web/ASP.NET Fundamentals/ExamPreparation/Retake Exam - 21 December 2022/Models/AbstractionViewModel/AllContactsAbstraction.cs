using Contacts.Models.ViewModels;

namespace Contacts.Models.AbstractionViewModel
{
    public class AllContactsAbstraction
    {
        public IEnumerable<ContactsInfoViewModel> Contacts { get; set; } = new List<ContactsInfoViewModel>();
    }
}
