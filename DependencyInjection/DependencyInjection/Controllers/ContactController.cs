using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DependencyInjection.Controllers
{
    public class ContactController : Controller
    {
        private IContactRespository _iContactRepository;

        // Constructor of the Class
        public ContactController(IContactRespository iContactRespository)
        {
            _iContactRepository = iContactRespository;
        }

        // GET: All Contacts
        public ActionResult Index()
        {
            var Alldata = _iContactRepository.GetAll();
            foreach (var item in Alldata)
            {
                if (item.Status)
                {
                    item.Status1 = Contact.StatusEnum.Active;
                }
                else
                {
                    item.Status1 = Contact.StatusEnum.Inactive;
                }
            }
            return View(Alldata);
        }

        // GET: /Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Contact/Create
        [HttpPost]
        public ActionResult Create(Contact _Contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Contact.ContactId = 0;
                    _iContactRepository.Add(_Contact);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(_Contact);
                }
            }
            catch
            {
                return View();
            }

        }

        // GET: /Contact/Details/1
        public ActionResult Details(int id)
        {
            var Detailsdata = _iContactRepository.GetById(id);
            return View(Detailsdata);
        }

        // GET: /Customer/Edit/1
        public ActionResult Edit(int id)
        {
            var Editdata = _iContactRepository.GetById(id);
            return View(Editdata);
        }

        // POST: /Customer/Edit/1
        [HttpPost]
        public ActionResult Edit(Contact _Contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_Contact.Status1.ToString().Equals("Active"))
                    {
                        _Contact.Status = true;
                    }
                    else
                    {
                        _Contact.Status = false;
                    }

                    _iContactRepository.Update(_Contact);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(_Contact);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: /Customer/Delete/1
        public ActionResult Delete(int id)
        {
            var Deletedata = _iContactRepository.GetById(id);
            return View(Deletedata);
        }

        // POST: /Customer/Delete/1
        [HttpPost]
        public ActionResult Delete(Contact _Contact)
        {
            try
            {
                _iContactRepository.Delete(_Contact);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}