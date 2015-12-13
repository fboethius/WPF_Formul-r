using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccessLayer.Context;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class FormInitializer : DropCreateDatabaseIfModelChanges<FormContext>
    {
        protected override void Seed(FormContext context)
        {
            var persons = new List<Person>
            {
                new Person
                {
                    ID=1,
                    Name = "Fredrik",
                     LastName = "Boëthius",
                      Address = new Address { StreetAddress="Sjösabrinken 10", PostalCode="12455", Region="Högdalen" },
                       Birthdate=DateTime.Parse("1981/09/15"),
                        Email="fredrik@luthman.se",
                         Notes="En hyvens karls som gillar öl",
                          Phone="0707670197",
                           Subscriber=true,
                             Type=TypeOfPerson.Privatperson

                }
            };
            persons.ForEach(p => context.Persons.Add(p));
            context.SaveChanges();
        }
    }
}
