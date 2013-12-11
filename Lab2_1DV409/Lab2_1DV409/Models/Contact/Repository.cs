using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Lab2_1DV409.Models
{
    public class Repository : IRepository
    {
        bool m_disposed;
        AdventureWorksEntities m_entities = new AdventureWorksEntities();

        public void Add(Contact contact)
        {
            m_entities.Contacts.Add(contact);
        }
        public void Delete(Contact contact)
        {
            m_entities.Contacts.Remove(contact);
        }

        public void Delete(int contactid)
        {
            Contact contact =  m_entities.Contacts.Find(contactid);

            m_entities.Contacts.Remove(contact);
        }

        public Contact GetContactById(int contactid)
        {
            return m_entities.Contacts.Find(contactid);
        }
        public List<Contact> GetLastContacts(int count = 20)
        {
            return m_entities.Contacts.OrderByDescending(c => c.ContactID).Take(count).OrderBy(c => c.ContactID).ToList();

            //List<Contact> contacts = new List<Contact>();
            //List<Contact> dbContacts = m_entities.Contacts.ToList();

            //for (int i = count+1; i > -1; i--)
            //{
            //    contacts.Add(dbContacts[dbContacts.Count - (i + 1)]);
            //}

            //return contacts;
        }
        public void Save()
        {
            m_entities.SaveChanges();

        }
        public void Update(Contact contact)
        { 
            m_entities.Entry(contact).State = System.Data.EntityState.Modified;
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!this.m_disposed)
            {
                if (disposing)
                {
                    m_entities.Dispose();
                }
            }
            this.m_disposed = true;
        }

    }
}