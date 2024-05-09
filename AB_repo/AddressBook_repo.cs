using System;
namespace AB_repo
{
    public class ContactRepository
    {
        private Dictionary<int, Contact> _contacts; 
        public ContactRepository() 
        {
            _contacts = new Dictionary<int, Contact>() ;
        } 

        // Create 
        public void AddContact(Contact contact) 
        {
            if(_contacts.ContainsKey(contact.Id)) 
            {
              _contacts[contact.Id] = contact; 
            } 

            else
            {
                _contacts.Add(contact.Id, contact) ;
            } 
          
        } 
        
        //Read 
        public List<Contact> GetAllContacts() 
        {
            return new List<Contact>(_contacts.Values) ;
        } 

        //Contact by name 
        public List<Contact> GetContactByName(string name) 
        {
            List<Contact> result = new List<Contact>();
            foreach(var contact in _contacts.Values) 
            {
                if(contact.Name.ToLower() == name.ToLower())
                result.Add(contact) ;
            } 
            return result;
        }
    
    //Update 
    public void UpdateContact(int ID, Contact updateContact) 
    {
        if(!_contacts.ContainsKey(ID)) 
        {
            return; 
        }
        _contacts[ID] = updateContact;
    } 

    //Delete 
    public void RemoveContact(int ID) 
    {
        if(!_contacts.ContainsKey(ID)) 
        {
            return;
        } 
        _contacts.Remove(ID);
    }
    } 
    }