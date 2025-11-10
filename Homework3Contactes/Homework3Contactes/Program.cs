//Yanel Josias Gonzalez Noboa 20250908
using System;
using System.Net.Mail;
using System.Runtime.CompilerServices;

Console.WriteLine("Welcome to my contact list");
byte typeOption;
bool running = true;
List<int> ids = new List<int>();

Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();
SavedContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Two contacts have been found in your data base");
Console.WriteLine("\nTwo contacts have been successfully added to your list.");
Console.WriteLine("You can view them by selecting option 2 from the main menu.\n");
Console.ResetColor();
Console.WriteLine("Prees Any key for continue");
Console.ReadKey();
Console.Clear();

while (running)
{
    Console.Clear();
    Console.Write(@"1. Add Contact | ");
    Console.Write(@"2. View Contacts | ");
    Console.Write(@"3. Search Contact | ");
    Console.Write(@"4. Modify Contact | ");
    Console.Write(@"5. Delete Contact | ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("6. Exit\n");
    Console.ResetColor();

    Console.WriteLine("Insert the option");

    while (true)
    {
        if(!byte.TryParse(Console.ReadLine(), out typeOption)) 
        {
            Console.WriteLine("You must insert a number and numbers between(1 and 6)");
            
            continue;
        }
        else
        {
            break;
        }
    }

    switch (typeOption)
    {
        case 1:
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                Console.ResetColor();

                Console.WriteLine("Press enter for continue");
                Console.ReadKey();
            }
            break;
        case 2: 
            {
                Console.ForegroundColor = ConsoleColor.Magenta;    
                ShowContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                Console.ResetColor();

                Console.WriteLine("Press enter for continue");
                Console.ReadKey();
                

            }
            break;
        case 3: 
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                SearchContact(names, lastnames, addresses, telephones, emails, ages, bestFriends);
                Console.ResetColor();

                Console.WriteLine("Press enter for continue");
                Console.ReadKey();

            }
            break;
        case 4:
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Choose modification type:");
                Console.WriteLine("1. Modify a single field");
                Console.WriteLine("2. Modify all fieldds of a contact");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    ModifyContact(names, lastnames, addresses, telephones, emails, ages, bestFriends);
                }
                else if (choice == "2")
                {
                    ModifyFullContact(names, lastnames, addresses, telephones, emails, ages, bestFriends);
                }
                else
                {
                    Console.WriteLine("Returning to main menu....");
                }
                Console.ResetColor();

                Console.WriteLine("Press enter for continue");
                Console.ReadKey();

                break;
            }
        case 5:
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                Console.ResetColor();

                Console.WriteLine("Press enter for continue");
                Console.ReadKey();

            }

            break;
        case 6:
            running = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press enter for close the program");
            Console.ReadKey();
            Console.ResetColor();
            
            break;
        default:
            Console.WriteLine("Tu eres o te haces el idiota?"); //Lo dejare aqui por meme
            break;
    }
}
static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.Clear();
    
    var data = GetContactData();
    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, data.name);
    lastnames.Add(id, data.lastname);
    addresses.Add(id, data.address);
    telephones.Add(id, data.phone);
    emails.Add(id, data.email);
    ages.Add(id, data.age);
    bestFriends.Add(id, data.isBestFriend);
    Console.WriteLine("Your contact has been entered succesfully");
}
static void ShowContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.Clear();
    if (ids.Count == 0)
    {
        Console.WriteLine("No contacts found");
        return;
    }

    Console.WriteLine("\n My Currently Contact List:");
    foreach (int id in ids)
    {
        Console.WriteLine($"\n=======ID: {id}=======");
        Console.WriteLine($"Name: {names[id]} {lastnames[id]}");
        Console.WriteLine($"Address: {addresses[id]}");
        Console.WriteLine($"Telephone: {telephones[id]}");
        Console.WriteLine($"Email: {emails[id]}");
        Console.WriteLine($"Ages: {ages[id]}");
        Console.WriteLine($"Best Friends: {bestFriends[id]}");
    }
}

static void SearchContact(Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.Clear();
    string nameToFind;
    while (true)
    {
        Console.WriteLine("Insert the name of the contact you want to search");
        nameToFind = Console.ReadLine();
        if (string.IsNullOrEmpty(nameToFind) && !nameToFind.All(char.IsLetter))
        {
            Console.WriteLine("Invalid input. Only letters are allowed and it cannot be empty");
            continue;
        }
        else
        {
            
            break;
        }
    }
    bool found = false;

    foreach(var entry in names)
    {
        if (entry.Value.Equals(nameToFind, StringComparison.OrdinalIgnoreCase))
        {
            int id = entry.Key;
            Console.WriteLine($"\n=======ID: {id}=======");
            Console.WriteLine($"Name: {names[id]} {lastnames[id]}");
            Console.WriteLine($"Address: {addresses[id]}");
            Console.WriteLine($"Telephone: {telephones[id]}");
            Console.WriteLine($"Email: {emails[id]}");
            Console.WriteLine($"Age: {ages[id]}");
            Console.WriteLine($"Best Friends: {bestFriends[id]}");
            found = true;
        }
    }
    if (!found)
    {
        Console.WriteLine($"No contact found with the name: {nameToFind}");
    }
}
static void ModifyContact(Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{

        Console.Clear();

        Console.WriteLine("Select one option to modify:");
        Console.WriteLine("1. Name\n2. Last Name\n3. Address\n4. Telephone\n5. Email\n6. Age\n7. Best Friend");
        Console.WriteLine("If you write another number, the program will return to the main menu.");
        Console.WriteLine("Insert the option");
        if (!byte.TryParse(Console.ReadLine(), out byte optionModify))
        {
            Console.WriteLine("Invalid option.");
            return;
        }

        Console.WriteLine("Insert the ID of the contact to modify:");
        if (!int.TryParse(Console.ReadLine(), out int id) || !names.ContainsKey(id))
        {
            Console.WriteLine("Invalid ID or contact does not exist.");
            return;
        }

    switch (optionModify)
    { 
        case 1:
            
            names[id] = ValidationString($"Insert the new name for the id ({id}) (max characters 16): ");
                
            break;
        case 2:

            lastnames[id] = ValidationString($"Insert the new last name for the id ({id}) (max characters 16) : ");
                
            
            break;
        case 3:
            while (true)
            {
                Console.WriteLine($"Insert the new address for the id ({id}): ");
                addresses[id] = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(addresses[id]))
                {
                    Console.WriteLine("Invalid input. This field cannot be empty");
                    continue;
                }
                else
                {
                    Console.WriteLine("Address updated successfully.");
                    break;
                }
            }
            break;
        case 4:
            while (true)
            {
               
                Console.WriteLine($"Insert the new telephone for the id ({id})");
                telephones[id] = Console.ReadLine();
                if (string.IsNullOrEmpty(telephones[id]))
                {
                    Console.WriteLine("this field cannot be empty");
                    continue;
                }
                else
                {
                    Console.WriteLine("Updated phone successfully");
                    break;
                }
                
            }
            break;
        case 5:

            while (true) {
                Console.WriteLine($"Insert the new email for the id({id})");
                try
                {
                    string tempMail = Console.ReadLine();
                    var mailT = new MailAddress(tempMail);
                    emails[id] = mailT.Address;
                    Console.WriteLine("Email updated successfully.");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid email format. Please try again.");
                    continue;
                }
            }
            break;
        case 6:
            Console.WriteLine($"Insert the new age for the id ({id})");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int age) && age > 0 && age <= 120)
                {
                    ages[id] = age;
                    Console.WriteLine("Age updated successfully.");
                    break;
                }
                Console.WriteLine("Invalid Value, Please enter a valid number");
                continue;
                
            }
            break;
        case 7:
            Console.WriteLine($"If you insert 1, this will be best friend contact, but if you insert other number it won't be best friend");
            int input;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input))
                {

                    if (input == 1)
                    {
                        bestFriends[id] = true;
                        Console.WriteLine("Marked as best friend.");
                    }
                    else
                    {
                        bestFriends[id] = false;
                        Console.WriteLine("Unmarked as best friend.");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Try again, you must insert number");
                    continue;
                }
            }
            break;
        default:
            Console.WriteLine("Returning to main menu...");
            break;
    }
}
static void ModifyFullContact(Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.Clear();

    Console.WriteLine("Insert the ID of the contact to  full modify:");
    if (!int.TryParse(Console.ReadLine(), out int id) || !names.ContainsKey(id))
    {
        Console.WriteLine("Invalid ID or contact does not exist.");
        return;
    }
    var data = GetContactData();
    names[id] = data.name;
    lastnames[id] = data.lastname;
    addresses[id] = data.address;
    telephones[id] = data.phone;
    emails[id] = data.email;
    ages[id] = data.age;
    bestFriends[id] = data.isBestFriend;
    Console.WriteLine("contact update succesfull");

}

static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.Clear();
    int id;
    Console.WriteLine("Insert the id of the contact you want to delete");
    if (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.WriteLine("Invalid input");        
        return;
    }
    if(!names.ContainsKey(id))
    {
        Console.WriteLine("Contact not found");
        return;
    }
    names.Remove(id);
    lastnames.Remove(id);
    addresses.Remove(id);
    telephones.Remove(id);
    emails.Remove(id);
    ages.Remove(id);
    bestFriends.Remove(id);
    ids.Remove(id);

    Console.WriteLine($"Contact with ID {id} deleted successfully.");

}
static (string name, string lastname, string address, string phone, string email, int age, bool isBestFriend) GetContactData()
{
    Console.Clear();
    string name = ValidationString("Name (max characters 16): ");
   
    
    string lastname = ValidationString("Last Name (max characters 16): ");
   
    
    string address;
    while (true)
    {
        Console.Write("Address: ");
        address = Console.ReadLine();
        if (string.IsNullOrEmpty(address))
        {
            Console.WriteLine("this field cannot be empty");
            continue;
        }
        else
        {
            break;
        }
    }
    string phone;
    while (true)
    {
        Console.Write("Phone: ");
        phone = Console.ReadLine();
        if (string.IsNullOrEmpty(phone))
        {
            Console.WriteLine("this field cannot be empty");
            continue;
        }
        else
        {
            break;
        }
    }
    string email;

    
    while (true)
    {

        Console.Write("Email: ");
        email = Console.ReadLine();

        if (string.IsNullOrEmpty(email))
        {
            Console.WriteLine("This fieldd cannot be empty");
            continue;
        }
        
        try
        {

            var tempEmail2 = new MailAddress(email);
            email = tempEmail2.Address;
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid email format, Please Try again");
            continue;
        }
    }
    int age = 0;

    while (true)
    {
        Console.Write("Age: ");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input) )
        {
             
            Console.WriteLine("This fieldd cannot be empty");
            continue;
        }

        if (int.TryParse(input, out int tempAge) && tempAge > 0 && tempAge <= 120)
        {
            age = tempAge;
            break;
        }
        else
        {
            Console.WriteLine("Invalid age, it should be greater than 0 and min than 120");
        }
    }


bool isBestFriend = false;
    Console.WriteLine("Is best friend? 1.Yes, AnyInput.No");
    if (Console.ReadLine() == "1") { isBestFriend = true; }
    Console.ResetColor();

    return (name, lastname, address, phone, email, age, isBestFriend);
}
static void SavedContact (List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    var id = ids.Count + 1;
    names[id] = "Yanel";
    lastnames[id] = "Gonzalez";
    addresses[id] = "Azua, RD";
    telephones[id] = "809-123-4567";
    emails[id] = "yanel@example.com";
    ages[id] = 21;
    bestFriends[id] = true;
    ids.Add(id);
    id++;
    names[id] = "Laura";
    lastnames[id] = "Martinez";
    addresses[id] = "Calle Duarte #45, Santo Domingo";
    telephones[id] = "809-555-7890";
    emails[id] = "laura.martinez@correo.com";
    ages[id] = 24;
    bestFriends[id] = false;
    ids.Add(id);
    id++;
}
static string ValidationString(string textInput)
{    
    while (true)
    {
        Console.Write(textInput);
        string informationPa = Console.ReadLine();
        
        if(string.IsNullOrEmpty(informationPa))
        {
            Console.WriteLine("Invalid input cannot be empty");
            continue;
        }
        if (informationPa.Length >= 16)
        {
            Console.WriteLine("You cannot enter more than 16 characters");
            continue;
        }
        if (!informationPa.All(char.IsLetter))
        {
            Console.WriteLine("Invalid input. Only letters are allowed");
            continue;
        }
        return informationPa;        
    }
}