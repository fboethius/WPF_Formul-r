using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public class PersonRepository
    {
        FormContext db = new FormContext();

        public Person GetPersonByEmail(string email)
        {
            var person = db.Persons.FirstOrDefault(p => p.Email == email);
            return person;
        }
        public Person GetPersonByPhone(string phone)
        {
            var person = db.Persons.FirstOrDefault(p => p.Phone == phone);
            return person;
        }
        public Person UpdatePerson(Person person)
        {
            if (person.ID==null)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return person;
            }
            else
            {
                var p = db.Persons.FirstOrDefault(x=>x.ID==person.ID);
                p = person;
                db.SaveChanges();
                return person;
            }
        }
    }
}
