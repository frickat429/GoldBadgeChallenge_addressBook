namespace AB_repo;

    public class ProgramUI 
    {
    private readonly ContactRepository _contactRepository; 
    public ProgramUI() 
    {
        _contactRepository = new ContactRepository() ;
        SeedContacts();
    } 
    public void Run() 
    {
    while (true) 
    {
        Console.WriteLine("=-=-=-=- Main Menu -=-=-=-="); 
        Console.WriteLine("1. List all contacts") ; 
        Console.WriteLine("2. Get contact(s) by name") ;
        Console.WriteLine("3. Add a contact") ;  
        Console.WriteLine("4. Update a contact") ;  
        Console.WriteLine("5. Remove a contact") ;
        Console.WriteLine("6. Exit") ; 
        
        Console.WriteLine("Welcome to Lowell Organization Logistics contact management ") ;
        string choice = Console.ReadLine();
        switch(choice) 
        {
            case "1":
            ListAllContacts();
            break; 
            case "2":
            Console.WriteLine("Enter the name of the contact");
            string name = Console.ReadLine();
            getContactByName(name);
            break;
            case "3": 
            AddContact();
            break;
            case "4" :
            UpdateContact();
            break;
            case "5" :
            RemoveContact();
            break;
            case "6":
            Console.WriteLine("Exiting program...");
            return;
            default: 
            Console.WriteLine("Invalid choice. Please select again") ;
            break; 
        }
        }
        }
        //Seed content 
        private void SeedContacts()
        {
        _contactRepository.AddContact(new Contact{Id = 1, Name = "Rowen Solo", Address = "424 Oak Tree LN ", Email = "RowSO@craftables.com", PhoneNumber = "555-000"}) ;
        _contactRepository.AddContact(new Contact{Id = 2, Name = "Edith Green", Address = "820 E. Donley DR.", Email = "EdithG@NorthChurch.com", PhoneNumber = "332-0122" }) ;
        _contactRepository.AddContact(new Contact{Id = 3, Name = "Noel Seeker", Address = "E. Street Apt. 104", Email = "NoLSeeker@Noelsbakery.com", PhoneNumber = "954-0987"});
        }
       //Read 
       //List all contacts
       private void ListAllContacts() 
       {
        Console.WriteLine("/nAll Contacts");
        List<Contact> allContacts = _contactRepository.GetAllContacts();
        foreach(var contact in allContacts) 
        {
            Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Address: {contact.Address}, Email: {contact.Email}, PhoneNumber{contact.PhoneNumber}");
        }
       } 

       //Get contact by name 

       public void getContactByName(string name)  
       {
        List<Contact> contacts = _contactRepository.GetContactByName(name);
        if (contacts.Count == 0) 
        {
            Console.WriteLine("No contacts with that name, please try another");
        } 
        else 
        {
        Console.WriteLine($"Contacts found with the name '{name}':");
        foreach(var contact in contacts) 
        {
            Console.WriteLine($"Name : {contact.Name}, Address : {contact.Address}, Email : {contact.Email}, PhoneNumber : {contact.PhoneNumber}") ;
        }
        }
       }

       
       
       //Create
       private void AddContact() 
       {
        Console.WriteLine("/n Add a new contact ") ;
        Console.WriteLine("Enter the contact name") ;
        string newName = Console.ReadLine();
        Console.WriteLine("Enter contact address") ;
        string newAddress = Console.ReadLine();
        Console.WriteLine("Enter contact email");
        string newEmail = Console.ReadLine();
        Console.WriteLine("Enter contact phone number");
        string newPhoneNumber = Console.ReadLine();
        int nextId = _contactRepository.GetAllContacts().Count +1;
        Contact newContact = new Contact{Id = nextId, Name = newName, Address = newAddress, Email = newEmail, PhoneNumber = newPhoneNumber}; 
        _contactRepository.AddContact(newContact);
        Console.WriteLine("Contact added successfully");
       } 

       //Update 
       private void UpdateContact() 
       {
        Console.WriteLine("/n Update an existing contact ");
        Console.WriteLine("Enter the Id of the contact you wish to update");
        int Id = int.Parse(Console.ReadLine());
        Contact existingContact = _contactRepository.GetAllContacts().Find(c =>c.Id == Id) ;
        if(existingContact != null) 
        {
        Contact updatedContact = new Contact{Id = Id}; 
        Console.WriteLine("Enter the infomation you wish to update(leave blank to keep current infomation )") ; 
        //Update Name
        Console.WriteLine("Enter Updated Name") ;
        string updatedName = Console.ReadLine();
        updatedContact.Name = !string.IsNullOrEmpty(updatedName) ? updatedName: existingContact.Name; 
        // Update Address
        Console.WriteLine("Enter Updated Address") ;
        string updatedAddress = Console.ReadLine();
        updatedContact.Address = !string.IsNullOrEmpty(updatedAddress) ? updatedAddress: existingContact.Address; 
        //Update Email
        Console.WriteLine("Enter Updated Email"); 
        string updatedEmail = Console.ReadLine(); 
        updatedContact.Email = !string.IsNullOrEmpty(updatedEmail) ? updatedEmail: existingContact.Email; 
        //Update Phone Number
        Console.WriteLine("Enter Updated Phone Number") ;
        string updatedPhoneNumber = Console.ReadLine();
        updatedContact.PhoneNumber = !string.IsNullOrEmpty(updatedPhoneNumber) ? updatedPhoneNumber: existingContact.PhoneNumber; 
        _contactRepository.UpdateContact(Id, updatedContact) ; 
        Console.WriteLine("Contact successfully updated") ;
        } 
        else 
        {
            Console.WriteLine("Contact not found, please enter a valid Id") ;
        }
       }
       //Delete 
       private void RemoveContact() 
       {
        Console.WriteLine("/n Remove a contact") ; 
        int Id = int.Parse(Console.ReadLine()) ;
        _contactRepository.RemoveContact(Id);
        Console.WriteLine("Contact removed successfully") ;

       }


       }
