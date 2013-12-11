using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Lab2_1DV409.Models
{
    public interface IRepository : IDisposable
    {
        void Add(Contact contact);
        void Delete(Contact contact);
        void Delete(int contactid);
        //IQueryable<Contact> FindAllContacts();
        Contact GetContactById(int contactid);
        List<Contact> GetLastContacts(int count = 20);
        void Save();
        void Update(Contact contact);

    }
}
