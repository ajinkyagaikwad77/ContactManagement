using System.Collections.Generic;

namespace DAL
{
    public interface IContactRespository
    {
        void Add(Contact _Contact);     // Create New Customer
        void Update(Contact _Contact);  // Modify Customer
        void Delete(Contact _Contact);  // Delete Customer
        Contact GetById(int id); // Get an Single Customer details by id
        IEnumerable<Contact> GetAll();  // Gets All Customer details
    }
}
