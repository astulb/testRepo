using System;
using System.Collections.Generic;

namespace Entities
{
    public class Person
    {
        public int PersonId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? PartnerId { get; set; }

        public virtual Person Partner { get; set; }

        public virtual List<Pet> Pets { get; set; }

        public virtual List<Person> Friends { get; set; }
    }
}