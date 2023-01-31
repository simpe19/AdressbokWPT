using AdressbokVS.Interfaces;
using AdressbokVS.Models;
using Newtonsoft.Json;
using AdressbokVS.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.ExceptionServices;

namespace AdressbokVS.Services;

internal class MenuService
{
    public static List<Person> persons = new List<Person>();
    public static readonly FileService fileService = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\console.json");

    public void PersonService()
    {
        try
        {
            persons = JsonConvert.DeserializeObject<List<Person>>(fileService.Read())!;
        }
        catch { persons = new List<Person>(); }
    }

    public void Add(Person person)
    {
        persons.Add(person);
        fileService.Save(JsonConvert.SerializeObject(persons));
    }
    public void Remove(Person person)
    {
        persons.Remove(person);
        fileService.Save(JsonConvert.SerializeObject(persons));
    }
    public List<Person> Contacts()
    {
        return persons;
    }

    public void WelcomeMenu()
    {
        Console.Clear();
        Console.WriteLine("ADRESSBOKEN");
        Console.WriteLine("1. Create a new contact ");
        Console.WriteLine("2. Show all contacts ");
        Console.WriteLine("3. Show a specific contact ");
        Console.WriteLine("4. Remove a specific contact ");
        Console.WriteLine("Välj ett alternativ ovan: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1": OptionOne(); break;
            case "2": OptionTwo(); break;
            case "3": OptionThree(); break;
            case "4": OptionFour(); break;
        }
    }
    public void OptionOne()
    {
        Console.Clear();
        Console.WriteLine("Add a new contact");
        
        Person person = new Person();
        Console.Write("Enter first name: ");
        person.FirstName = Console.ReadLine() ?? "";
        Console.Write("Enter last name: ");
        person.LastName = Console.ReadLine() ?? "";
        Console.Write("Enter e-mail adress: ");
        person.Email = Console.ReadLine() ?? "";
        Console.Write("Enter phone number ");
        person.Number = Console.ReadLine() ?? "";
        Console.Write("Enter adress: ");
        person.Adress = Console.ReadLine() ?? "";

        Add(person);
    }
    public void OptionTwo()
    {

    PersonService();

        foreach (Person person in persons)
        {
            Console.WriteLine(person.Email);
        }

        Console.ReadKey();
    }
    private void OptionThree()
    {
        Console.Clear();
        Console.WriteLine("Show one contact:");

        string FirstName = Console.ReadLine() ?? "";
        var person = persons.FirstOrDefault(person => person.FirstName == person.FirstName);
        if (person == null)
        {
            Console.WriteLine("Contact not found");
        }
        else
        {
            Console.WriteLine($"Firstname: {person.FirstName}");
            Console.WriteLine($"Lastname: {person.LastName}");
            Console.WriteLine($"Phone number: {person.Number}");
            Console.WriteLine($"Email: {person.Email}");
            Console.WriteLine($"Address: {person.Adress}");
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();
    }
    public void OptionFour()
    {

        Console.WriteLine("Enter a email to remove:");
        string email = Console.ReadLine() ?? "";
        var person = persons.FirstOrDefault(x => x.Email.ToLower() == email.ToLower())!;

        if (person == null)
        {
            Console.WriteLine("The contact was not found");
            Console.ReadKey();
            return;
        }
        else
        {
            Console.WriteLine("Are you sure you want to remove this contact ? (Y/N)");
        }
        if (Console.ReadKey().Key == ConsoleKey.Y)
        {
            persons.Remove(person);
            Console.WriteLine("You have removed this contact");
            Console.ReadKey();

            fileService.Save(JsonConvert.SerializeObject(persons));
        }
    }
}
