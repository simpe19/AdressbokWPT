using AdressbokWPTMvvm.MVVM.Models;
using AdressbokWPTMvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdressbokWPTMvvm.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    { 
        public ContactsViewModel()
        {
            
            contacts = ContactService.Contacts();
        }

        [ObservableProperty]
        private string title = "Contacts";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts;

        [ObservableProperty]
        private ContactModel selectedContact = null!;
    }
}
