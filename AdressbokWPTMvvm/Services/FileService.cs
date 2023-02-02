using AdressbokWPTMvvm.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressbokWPTMvvm.Services
{
    public class FileService
    {
        private static ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();
        private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
        


        public FileService()
        {
            ReadFromFile();
        }

        private void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(sr.ReadToEnd())!;
            }
            catch { contacts = new ObservableCollection<ContactModel>(); }
        }


        private void Save()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(contacts));
        }

        public void Add(ContactModel contact)
        {
            contacts.Add(contact);
            Save();
        }

        public static void Remove(ContactModel contact)
        {
            contacts.Remove(contact);
            //Save();
        }
        public ObservableCollection<ContactModel> Contacts()
        {
            return contacts;
        }
    }
}
