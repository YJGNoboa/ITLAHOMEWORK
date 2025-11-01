//Yanel Josias Gonzalez Noboa 20250908
Console.WriteLine("Welcome to my contactes list");
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


while (running)
{
    Console.WriteLine(@"1. Add Contact | 2. View Contacts | 3. Search Contact | 4. Modify Contact | 5. Delete Contact | 6. Exit");
    

    Console.WriteLine("Insert the option");

    while (true)
    {
        if(!byte.TryParse(Console.ReadLine(), out typeOption)) 
        {
            Console.WriteLine("You must insert a number");
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
                
                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                Console.WriteLine("Press enter for continue");
                Console.ReadKey();
                Console.WriteLine("===============================================================");
            }
            break;
        case 2: 
            {
                ShowContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                Console.WriteLine("Press enter for continue");
                Console.ReadKey();
                Console.WriteLine("===============================================================");

            }
            break;
        case 3: 
            {
                SearchContact(names, lastnames, addresses, telephones, emails, ages, bestFriends);
                Console.WriteLine("Press enter for continue");
                Console.ReadKey();
                Console.WriteLine("===============================================================");

            }
            break;
        case 4:
            {
                Console.WriteLine("Choose modification type:");
                Console.WriteLine("1. Modify a single field");
                Console.WriteLine("2. Modify all fields of a contact");

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
                Console.WriteLine("Press enter for continue");
                Console.ReadKey();
                Console.WriteLine("===============================================================");

                break;
            }
           
            
        case 5:
            {
                DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                Console.WriteLine("Press enter for continue");
                Console.ReadKey();
                Console.WriteLine("===============================================================");

            }

            break;
        case 6:
            running = false;
            Console.WriteLine("Press enter for close the program");
            Console.ReadKey();
            
            break;
        default:
            Console.WriteLine("Tu eres o te haces el idiota?");
            break;
    }
}


static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{

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

}
static void ShowContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
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
        Console.WriteLine($"Best Frieds: {bestFriends[id]}");
    }
}

static void SearchContact(Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Insert the name of the contact you want to search");
    string nameToFind = Console.ReadLine();
    bool found = false;

    foreach(var entry in names)
    {
        if (entry.Value.Equals(nameToFind, StringComparison.OrdinalIgnoreCase))
        {
            int id = entry.Key;
            Console.WriteLine($"Name: {names[id]} {lastnames[id]}");
            Console.WriteLine($"Address: {addresses[id]}");
            Console.WriteLine($"Telephone: {telephones[id]}");
            Console.WriteLine($"Email: {emails[id]}");
            Console.WriteLine($"Ages: {ages[id]}");
            Console.WriteLine($"Best Frieds: {bestFriends[id]}");
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
            Console.WriteLine($"Insert the new name for the id: {id}");
            names[id] = Console.ReadLine();
            Console.WriteLine("Name updated successfully.");
            break;
        case 2:
            Console.WriteLine($"Insert the new lastname for the id: {id}");
            lastnames[id] = Console.ReadLine();
            Console.WriteLine("Last Name updated successfully.");
            break;
        case 3:
            Console.WriteLine($"Insert the new Address for the id{id}");
            addresses[id] = Console.ReadLine();
            Console.WriteLine("Address updated successfully.");
            break;
        case 4:
            Console.WriteLine($"Insert the new telephone for the id{id}");
            telephones[id] = Console.ReadLine();
            Console.WriteLine("Telephone updated successfully.");
            break;
        case 5:
            Console.WriteLine($"Insert the new email for the id{id}");
            emails[id] = Console.ReadLine();
            Console.WriteLine("Email updated successfully.");
            break;
        case 6:
            Console.WriteLine($"Insert the new age for the id{id}");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int age))
                {
                    Console.WriteLine("Invalid Value, Please enter a valid number");
                    continue;
                }
                ages[id] = age;
                Console.WriteLine("Age updated successfully.");
                break;
            }
            break;
        case 7:
            Console.WriteLine($"If you insert 1, this will be best friend contact, in other case it won't be best friend");
            int input = int.Parse(Console.ReadLine());
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
        default:
            Console.WriteLine("Returning to main menu...");
            break;
    }
}
static void ModifyFullContact(Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{ 
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
    Console.WriteLine("Insert the id of the contact you want to delete");
    int id = int.Parse(Console.ReadLine());
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
    Console.Write("Name: ");
    string name = Console.ReadLine();

    Console.Write("Last name: ");
    string lastname = Console.ReadLine();

    Console.Write("Address: ");
    string address = Console.ReadLine();

    Console.Write("Phone: ");
    string phone = Console.ReadLine();

    Console.Write("Email: ");
    string email = Console.ReadLine();

    int age;
    Console.Write("Age: ");
    while (!int.TryParse(Console.ReadLine(), out age))
    {
        Console.WriteLine("Invalid age. Try again:");
    }

    Console.Write("Is best friend? (1 = Yes, other = No): ");
    bool isBestFriend = Console.ReadLine() == "1";

    return (name, lastname, address, phone, email, age, isBestFriend);
}