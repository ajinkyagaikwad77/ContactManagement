using DAL;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ContactService : IContactService
    {
        private IContactRespository _iContactRepository;

        public ContactService(IContactRespository iContactRepository)
        {
            _iContactRepository = iContactRepository;
        }
        public IEnumerable<Contact> GetAll()
        {
            return _iContactRepository.GetAll();
        }
    }
}
