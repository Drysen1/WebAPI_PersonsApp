using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_XamarinDemo.Models
{
    public class PersonModel
    {
        public int IDPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public PersonModel()
        {

        }
    }
}