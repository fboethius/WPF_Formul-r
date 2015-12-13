using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Formulär.Context;
using WPF_Formulär.Models;

namespace DataAccessLayer.Repositories
{
    public class PersonRepository
    {
        FormContext db = new FormContext();
        public List<Person> GetPersons()
        {
            return db.Persons.ToList();
        }
        public Person GetPersonByEmail(string email)
        {
            return db.Persons.FirstOrDefault(p => p.Email == email);
        }
        public Person GetPersonByPhone(string phone)
        {
            return db.Persons.FirstOrDefault(p => p.Phone == phone);
        }
        public bool UpdatePerson(Person person)
        {
            if (db.Persons.Where(x=>x.Email==person.Email||x.Phone==person.Phone).Count()<1 )
            {
                db.Entry(person).State = EntityState.Added;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
