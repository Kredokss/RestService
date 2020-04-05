using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestService.BLL.Abstract;
using RestService.DAL.Entities;

namespace RestService.BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly test_dbContext db;

        public PersonService(test_dbContext db)
        {
            this.db = db;
        }

        public async Task<DataTransferPerson> Add(DataTransferPerson person)
        {
            List<PersonContact> contacts = new List<PersonContact>();

            if (person.Contacts != null && person.Contacts.Count >= 1)
            {
                for (int i = 0; i < person.Contacts.Count; i++)
                {
                    contacts.Add(new PersonContact() {PersonContactId = i+1, ContactTypeId = person.Contacts[i].PersonContactId, Txt = person.Contacts[i].PersonContactTxt });
                }
            }
            person.Contacts = null;
            Greeting greeting = db.Greeting.SingleOrDefault(greeting => greeting.Txt1 == person.GreetingTxt1 && greeting.Txt2 == person.GreetingTxt2 &&
            greeting.Txt3 == person.GreetingTxt3 && greeting.Txt4 == person.GreetingTxt4);

            Country country = db.Country.SingleOrDefault(country => country.Txt1 == person.Txt1 && country.Txt2 == person.Txt2 && country.Txt3 == person.Txt3
            && country.Txt4 == person.Txt4);

            //Create an instance of Person from DataTransferPerson
            var model = new Person()
            {
                Id = person.Id,
                Cpny = person.Cpny,
                Title = person.Title,
                Fname = person.FName,
                Lname = person.LName,
                Street = person.Street,
                Greeting = greeting,
                CountryCodeNavigation = country,
                Zip = person.Zip,
                City = person.City,
                DateOfBirth = person.DateOfBirth,
                FirstContact = person.FirstContact,
                GreetingId = greeting.Id,
                PersonContact = contacts
            };

            var res = await db.Person.AddAsync(model);

            await db.SaveChangesAsync();

            return person;

        }

        public async Task<bool> Delete(int id)
        {
            var res = await db.Person.FirstOrDefaultAsync(x => x.Id == id);

            db.Remove(res);

            await db.SaveChangesAsync();

            return true;
        }

        public async Task<DataTransferPerson> Get(int id)
        {
            Person person = await db.Person.Include(x => x.Greeting).Include(x => x.CountryCodeNavigation).Include(x => x.PersonContact).FirstOrDefaultAsync(x => x.Id == id);

            return new DataTransferPerson(person);
        }

        public IEnumerable<DataTransferPerson> Get()
        {
            List<Person> people = db.Person.Include(x=>x.Greeting).Include(x=>x.PersonContact).Include(x => x.CountryCodeNavigation).AsEnumerable().ToList();

            List<DataTransferPerson> Tpeople = new List<DataTransferPerson>();

            foreach(var item in people)
            {
                Tpeople.Add(new DataTransferPerson(item));
            }

            people.Clear();

            return Tpeople.OrderBy(x => x.Id).ToList();
        }

        public async Task<DataTransferPerson> Update(DataTransferPerson person)
        {
            Greeting greeting = db.Greeting.SingleOrDefault(greeting => greeting.Txt1 == person.GreetingTxt1 && greeting.Txt2 == person.GreetingTxt2 &&
            greeting.Txt3 == person.GreetingTxt3 && greeting.Txt4 == person.GreetingTxt4);

            Country country = db.Country.SingleOrDefault(country => country.Txt1 == person.Txt1 && country.Txt2 == person.Txt2 && country.Txt3 == person.Txt3
            && country.Txt4 == person.Txt4);

            List<PersonContact> contacts = new List<PersonContact>();

            if (person.Contacts != null && person.Contacts.Count >= 1)
            {
                for (int i = 0; i < person.Contacts.Count; i++)
                {
                    contacts.Add(new PersonContact() { PersonContactId = i + 1, ContactTypeId = person.Contacts[i].PersonContactId, Txt = person.Contacts[i].PersonContactTxt });
                }
            }

            //Create an instance of Person from DataTransferPerson
            var model = new Person()
            {
                Id = person.Id,
                Cpny = person.Cpny,
                Title = person.Title,
                Fname = person.FName,
                Lname = person.LName,
                Street = person.Street,
                Greeting = greeting,
                CountryCodeNavigation = country,
                CountryCode = country.Code,
                Zip = person.Zip,
                City = person.City,
                DateOfBirth = person.DateOfBirth,
                FirstContact = person.FirstContact,
                GreetingId = greeting.Id,
                PersonContact = contacts
            };


            Person personParent = await db.Person.Include(x => x.Greeting).Include(x => x.CountryCodeNavigation).Include(x => x.PersonContact).FirstOrDefaultAsync(x => x.Id == person.Id);

            if (personParent != null)
            {
                // Update parent
                db.Entry(personParent).CurrentValues.SetValues(model);

                // Delete children
                foreach (var existingChild in personParent.PersonContact.ToList())
                {
                    db.PersonContact.Remove(existingChild);
                }


                // Update and Insert children
                foreach (var childModel in model.PersonContact)
                {
                    // Insert child
                    var newPersonContact = new PersonContact
                    {
                        PersonContactId = childModel.PersonContactId,
                        ContactTypeId = childModel.ContactTypeId,
                        Txt = childModel.Txt
                    };
                    personParent.PersonContact.Add(newPersonContact);
                }
            }

            await db.SaveChangesAsync();
            return person;
        }
    }
}
