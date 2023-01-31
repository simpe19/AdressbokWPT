using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AdressbokWPTMvvm.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel = new ContactsViewModel();

        [RelayCommand]
        private void GoToAddContact() => CurrentViewModel= new AddContactViewModel();

        [RelayCommand]
        private void GoToContacts() => CurrentViewModel = new ContactsViewModel();
    }
}
