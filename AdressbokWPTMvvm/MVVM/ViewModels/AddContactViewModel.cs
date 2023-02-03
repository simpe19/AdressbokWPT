using AdressbokWPTMvvm.MVVM.Models;
using AdressbokWPTMvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AdressbokWPTMvvm.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {

        [ObservableProperty]
        private string title = "Add contact";

        [ObservableProperty]
        private string firstname;

        [ObservableProperty]
        private string lastname;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string adress;

        [ObservableProperty]
        private string number;

        [RelayCommand]

        private void Add()
        {
            ContactService.Add(new ContactModel { FirstName = Firstname, LastName = lastname, Email = email, Address = adress, Number = number });
            Firstname= string.Empty;
            Lastname= string.Empty;
            Email= string.Empty;
            Adress= string.Empty;
            Number= string.Empty;
        }

    }
}
