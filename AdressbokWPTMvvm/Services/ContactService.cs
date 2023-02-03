using AdressbokWPTMvvm.MVVM.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System;


namespace AdressbokWPTMvvm.Services
{
    public class ContactService
    {
        private static ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();
        private static FileService fileservice = new FileService ($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json");
        


        static ContactService()
        {
            try
            {
                contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(fileservice.ReadFromFile())!;
            }
            catch { contacts = new ObservableCollection<ContactModel>(); }
        }


        public static void Add(ContactModel contact)
        {
            contacts.Add(contact);
            fileservice.Save(JsonConvert.SerializeObject(contacts));
            
        }

        public static void Remove(ContactModel contact)
        {
            contacts.Remove(contact);
            fileservice.Save(JsonConvert.SerializeObject(contacts));
        }
        public static ObservableCollection<ContactModel> Contacts()
        {
            return contacts;
        }
    }
}
