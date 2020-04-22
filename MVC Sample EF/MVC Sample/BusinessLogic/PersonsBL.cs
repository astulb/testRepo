using Entities;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public static class PersonsBL
    {
        public static List<Person> People = GetPersons();

        private static List<Person> GetPersons()
        {
            List<Person> people = new List<Person>();

            Person person1 = new Person()
            {
                Id = 1,
                Name = "Juan",
                LastName = "Perez",
                Phone = "12345678"
            };

            Person person2 = new Person()
            {
                Id = 2,
                Name = "Pedro",
                LastName = "Rodriguez",
                Phone = "12345678"
            };

            Person person3 = new Person()
            {
                Id = 3,
                Name = "Luis",
                LastName = "Garcia",
                Phone = "12345678"
            };

            people.Add(person1);
            people.Add(person2);
            people.Add(person3);

            return people;
        }
    }
}
