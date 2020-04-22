using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            if (people != null)
            {
                foreach (var item in people)
                {
                    PersonViewModel person = new PersonViewModel(item);

                    Persons.Add(person);
                }
            }
        }
    }

    public class PersonViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Invalid phone length")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        public string FullName { get; set; }

        public PersonViewModel(Person person)
        {
            Id = person.PersonId;
            LastName = person.LastName;
            Name = person.Name;
            Email = person.Email;
            Phone = person.Phone;
            FullName = string.Format("{0} {1}", person.Name, person.LastName);
        }

        public PersonViewModel()
        {
            LastName = "";
            Name = "";
            Email = "";
            Phone = "";
            FullName = "";
        }
    }
}