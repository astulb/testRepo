using System;
using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public int PartnerId { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public virtual Person Partner { get; set; }

        public virtual ICollection<Person> Friends { get; set; }
    }
}