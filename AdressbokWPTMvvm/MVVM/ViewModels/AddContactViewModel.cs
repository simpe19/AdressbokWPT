using AdressbokWPTMvvm.MVVM.Models;
using AdressbokWPTMvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AdressbokWPTMvvm.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        private readonly FileService fileService;
        public AddContactViewModel()
        {
            fileService = new FileService();
        }



        [ObservableProperty]
        private string title = "Add contact";

        [ObservableProperty]
        private string firstname = string.Empty;

        [ObservableProperty]
        private string lastname = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string adress = string.Empty;

        [ObservableProperty]
        private string number = string.Empty;

        [RelayCommand]

        private void Add()
        {
            fileService.Add(new ContactModel { FirstName = firstname, LastName = lastname, Email = email, Address = adress, Number = number });
        }

    }
}
