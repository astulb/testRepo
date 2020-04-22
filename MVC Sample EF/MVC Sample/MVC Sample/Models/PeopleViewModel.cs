using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Sample.Models
{
    public class PeopleViewModel
    {
        public List<PersonViewModel> Persons { get; set; }

        public PeopleViewModel(List<Person> people)
        {
            Persons = new List<PersonViewModel>();

            foreach (var item in people)
            {
                PersonViewModel person = new PersonViewModel() {

                    Id = item.Id,
                    LastName = item.LastName,
                    Name = item.Name,
                    Phone = item.Phone,
                    FullName = string.Format("{0} {1}", item.Name, item.LastName)
                 
                };

                Persons.Add(person);
            }
        }
    }

    public class PersonViewModel
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string FullName { get; set; }
    }
}