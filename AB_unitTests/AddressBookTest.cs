using AB_repo;

namespace unitTest_Address;

    [TestClass]
    public class AddressBookTest
    {
        private ContactRepository contactRepository; 

        [TestInitialize]
        public void SetUp()
        {
            contactRepository = new ContactRepository(); // Initializing the field in the SetUp method
        }
        // Add mehtod test 
        [TestMethod]
        public void AddContact_WhenCalled_AddContactToList()
        { 
            // Arrange 
            Contact contact = new Contact{Id = 1, Name = "Rowen Solo"}; 
            

            // Act 
            contactRepository.AddContact(contact);

            // Assert 
            var allContacts = contactRepository.GetAllContacts();
            Assert.AreEqual(1, allContacts.Count);
            Assert.IsTrue(allContacts.Contains(contact));
        } 
        //Get a contact method tests by Id or name test. Includes for when name exsits and does not exsits
        [TestMethod] 
        public void GetAllContacts_WhenCalled_ReturnsAllContacts()
        {
            // Arrange 
            Contact contact1 = new Contact { Id = 1, Name = "Rowen Solo" };
            Contact contact2 = new Contact { Id = 2, Name = "Olivia Green" };
            Contact contact3 = new Contact { Id = 3, Name = "Noel Seeker" };
            Contact contact4 = new Contact { Id = 4, Name = "Alex Dudley" };

            contactRepository.AddContact(contact1);
            contactRepository.AddContact(contact2);
            contactRepository.AddContact(contact3);
            contactRepository.AddContact(contact4);

            // Act 
            var allContacts = contactRepository.GetAllContacts();

            // Assert
            Assert.AreEqual(4, allContacts.Count);
            Assert.IsTrue(allContacts.Contains(contact1));
            Assert.IsTrue(allContacts.Contains(contact2));
            Assert.IsTrue(allContacts.Contains(contact3));
            Assert.IsTrue(allContacts.Contains(contact4));
        } 

        [TestMethod] 
        public void GetContactByName_WhenNameExsits_ReturnCorrectContacts() 
        {
        //Arrange 
        Contact contact1 = new Contact {Id = 1, Name = "Rowen Solo"} ; 
        Contact contact2 = new Contact {Id = 2, Name = "Olivia Green"} ;
        Contact contact3 = new Contact {Id = 3, Name = "Noel Seeker"} ;
        Contact contact4 = new Contact {Id = 4, Name = "Alex Dudley"} ;
        contactRepository.AddContact(contact1);
        contactRepository.AddContact(contact2);
        contactRepository.AddContact(contact3);
        contactRepository.AddContact(contact4); 
        //Act 
        var contactByName = contactRepository.GetContactByName("Noel Seeker") ;
        
        //Assert 
        Assert.AreEqual(1, contactByName.Count);
        Assert.IsTrue(contactByName.Contains(contact3)) ;
        } 
        [TestMethod] 
        public void GetContactByName_WhenNameDoesNotExist_ReturnEmptyList() 
        {
            //Arrage 
            Contact contact1 = new Contact {Id = 1, Name = "Rowen Solo"} ;
            Contact contact2 = new Contact {Id = 2, Name = "Olivia Green"} ;
            Contact contact3 = new Contact {Id = 3, Name = "Noel Seeker" } ;
            Contact contact4 = new Contact {Id = 4, Name = "Alex Dudley"} ;
            contactRepository.AddContact(contact1);
            contactRepository.AddContact(contact2);
            contactRepository.AddContact(contact3);
            contactRepository.AddContact(contact4); 
            
            //Act 
            var contactByName = contactRepository.GetContactByName("Flump Jones") ;

            //Assert 
            Assert.AreEqual(0, contactByName.Count);

        } 

        //Update method test 
        [TestMethod]
        public void UpdateContact_WhenContactExists_UpdateContact() 
        { 
            //Arrange
            Contact contact = new Contact {Id = 4, Name = "Alex Dudley", Address = "E. Street Apt. 204", Email = "DetectiveDoodles@CSpolice.com", PhoneNumber = "280-7279"};
            contactRepository.AddContact(contact);
            Contact updatedContact = new Contact{Id = 4, Name = "Updated Name", Address = "Updated Address", Email = "Updated Email", PhoneNumber = "Updated Phone Number"} ;

            //Act 
            contactRepository.UpdateContact(4, updatedContact);

            //Assert 
            var allContacts = contactRepository.GetAllContacts();
            var updatedContactFromRepo = allContacts.Find(c => c.Id == 4);
            Assert.IsNotNull(updatedContactFromRepo) ;
            Assert.AreEqual(updatedContact.Name, updatedContactFromRepo.Name);
            Assert.AreEqual(updatedContact.Address, updatedContactFromRepo.Address);
            Assert.AreEqual(updatedContact.Email, updatedContactFromRepo.Email);
            Assert.AreEqual(updatedContact.PhoneNumber, updatedContactFromRepo.PhoneNumber); 
            
        } 

        //Delete method test
        [TestMethod]
        public void RemoveContact_WhenContactExists_RemoveContactFromList() 
        {

            //Arrange 
            Contact contact = new Contact {Id = 2, Name = "Olivia Green", Address = "820 E. Donley DR.", Email = "Oliv@RoccAgency.com", PhoneNumber = "332-0122" } ;
            contactRepository.AddContact(contact);

            //Act 
            contactRepository.RemoveContact(2);

            //Assert
            var allContacts = contactRepository.GetAllContacts();
            Assert.AreEqual(0, allContacts.Count);
        }

    }


