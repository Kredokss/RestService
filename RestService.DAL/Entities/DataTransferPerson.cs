using System;
using System.Collections.Generic;
using System.Text;

namespace RestService.DAL.Entities
{
    public partial class DataTransferPerson
    {
        public int Id { get; set; }
        public string Cpny { get; set; }
        public string Title { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Street { get; set; }
        public string Txt1 { get; set; }
        public string Txt2 { get; set; }
        public string Txt3 { get; set; }
        public string Txt4 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime FirstContact { get; set; }
        public string GreetingTxt1 { get; set; }
        public string GreetingTxt2 { get; set; }
        public string GreetingTxt3 { get; set; }
        public string GreetingTxt4 { get; set; }
        public List<Contact> Contacts { get; set; }

        public DataTransferPerson(Person person)
        {
            if (person != null)
            {
                Id = person.Id;
                Cpny = person.Cpny;
                Title = person.Title;
                FName = person.Fname;
                LName = person.Lname;
                Street = person.Street;
                Txt1 = person.CountryCodeNavigation.Txt1;
                Txt2 = person.CountryCodeNavigation.Txt2;
                Txt3 = person.CountryCodeNavigation.Txt3;
                Txt4 = person.CountryCodeNavigation.Txt4;
                Zip = person.Zip;
                City = person.City;
                DateOfBirth = person.DateOfBirth;
                FirstContact = person.FirstContact;
                GreetingTxt1 = person.Greeting.Txt1;
                GreetingTxt2 = person.Greeting.Txt2;
                GreetingTxt3 = person.Greeting.Txt3;
                GreetingTxt4 = person.Greeting.Txt4;
                Contacts = new List<Contact>();
                foreach (var item in person.PersonContact)
                {
                    Contacts.Add(new Contact(item));
                }
            }
        }

        public DataTransferPerson() { }

    }
}
