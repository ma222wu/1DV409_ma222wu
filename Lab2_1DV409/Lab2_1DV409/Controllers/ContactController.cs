using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2_1DV409.Models;

namespace Lab2_1DV409.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        IRepository m_repository;

        public ContactController() 
            : this(new Repository())
        {
        }

        public ContactController(IRepository repository)
        {
            m_repository = repository;
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName, LastName, EmailAddress")]Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    m_repository.Add(contact);
                    m_repository.Save();

                    return View("Saved", contact);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "An error occured while deleting contact: " + e.Message);
            }

            return View("Create", contact);
        }

        public ActionResult Delete(int id = 0)
        {
            var contact = m_repository.GetContactById(id);
            if (contact == null)
            {
                return View("NotFound");
            }

            return View("Delete", contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                m_repository.Delete(id);
                m_repository.Save();

                return View("Deleted");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "An error occured while deleting contact: " + e.Message);
            }

            return View("Delete", m_repository.GetContactById(id));
        }

        public ActionResult Edit(int id = 0)
        {
            var contact = m_repository.GetContactById(id);
            if (contact == null)
            {
                return View("NotFound");
            }

            return View("Edit", contact);
        }

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    m_repository.Update(contact);
                    m_repository.Save();

                    return View("Saved", contact);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty,"An error occured while editing contact: " + e.Message);
                }
            }

            return View("Edit", contact);
        }


        public ActionResult Index()
        {


            return View("Index", m_repository.GetLastContacts());
        }

        protected override void Dispose(bool disposing)
        {
            m_repository.Dispose();
            base.Dispose(disposing);
        }

    }
}
