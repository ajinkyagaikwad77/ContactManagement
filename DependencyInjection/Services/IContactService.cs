using DAL;
using System.Collections.Generic;

namespace Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAll();
    }
}
