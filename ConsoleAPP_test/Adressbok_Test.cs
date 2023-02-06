using AdressbokVS.Models;
using AdressbokVS.Services;

namespace ConsoleApp.Test
{
    public class AddressBook_Tests
    {
        private MenuService addressBook;
        Person person;

        public AddressBook_Tests()
        {
            addressBook = new MenuService();
            person = new Person();
        }

        [Fact]
        public void Should_Add_Contact_To_List()
        {
            addressBook.persons.Add(person);
            addressBook.persons.Add(person);

            Assert.Equal(2, addressBook.persons.Count);

        }


        [Fact]
        public void Should_Remove_Contact_From_List()
        {
            
            addressBook.persons.Add(person);
            addressBook.persons.Add(person);

            addressBook.persons.Remove(person);

            Assert.Single(addressBook.persons);
        }
    }
}