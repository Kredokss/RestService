using System;
using System.Collections.Generic;
using System.Text;

namespace RestService.DAL.Entities
{
    public partial class Contact
    {
        public int PersonContactId { get; set; }
        public string PersonContactTxt { get; set; }

        public Contact(PersonContact contact)
        {
            PersonContactId = contact.ContactTypeId;
            PersonContactTxt = contact.Txt;
        }

        public Contact() { }
    }
}
