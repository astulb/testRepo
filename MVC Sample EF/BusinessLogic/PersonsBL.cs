using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessNetF;

namespace BusinessLogic
{
    public static class PersonsBL
    {
        public static PersonRepository PersonRepo = new PersonRepository();

        public static void Edit(int id, string name, string lastName, string email, string phone)
        {
            Person toEdit = new Person()
            {
                PersonId = id,
                Name = name,
                LastName = lastName,
                Email = email,
                Phone = phone
            };

            PersonRepo.Edit(toEdit);
        }

        public static void Delete(int id)
        {
            PersonRepo.Delete(id);
        }

        public static Person GetById(int id)
        {
            return PersonRepo.Get(id);
        }

        public static List<Person> GetAll()
        {
            var ret = PersonRepo.GetAll();
            return ret;
        }

        public static bool EmailExists(string email, Nullable<int> id = null)
        {
            List<Person> dbAll = PersonRepo.GetAll();
            if(dbAll != null)
            {
                foreach (Person person in dbAll)
                {
                    if (person.Email == email)
                    {
                        if (id == null)
                        {
                            return true;
                        }
                        else if (person.PersonId != id)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static int IDoSomething(string data)
        {
            if(data == "valid")
            {
                return IDoSomethingElseIfTheDataIsCorrect(data);
            }
            return IDoSomethingElseIfTheDataIsIncorrect(data);
        }

        private static int IDoSomethingElseIfTheDataIsIncorrect(string data)
        {
            if (data != "valid") return 0;
            return 000;
        }

        private static int IDoSomethingElseIfTheDataIsCorrect(string data)
        {
            if(data == "valid") return 10;
            return 111;
        }



        public static int Create(string name, string lastName, string email, string phone)
        {
            Person newPerson = new Person()
            {
                Name = name,
                LastName = lastName,
                Phone = phone,
                Email = email
            };
            
            return PersonRepo.Add(newPerson);
        }

        public static void AddFriend(int id)
        {
            var allUsers = PersonRepo.GetAll();
            Person user = allUsers.First();

            Person newFriend = PersonRepo.Get(id);

            if(user.Friends == null)
            {
                user.Friends = new List<Person>();
            }
            user.Friends.Add(newFriend);
            PersonRepo.Save();
        }

        public static bool HasPartner()
        {
            var allUsers = PersonRepo.GetAll();
            Person user = allUsers.First();

            if(user.Partner != null)
            {
                return true;
            }
            return false;

        }

        public static void AddPartner(int id)
        {
            var allUsers = PersonRepo.GetAll();
            Person user = allUsers.First();

            Person partner = PersonRepo.Get(id);

            partner.Partner = user;
            user.Partner = partner;
            PersonRepo.Save();
        }

        public static void AddPetTo(int id)
        {
            Person user = GetById(id);
            Random random = new Random();
            Pet newPet = new Pet()
            {
                Name = "Pepe" + random.Next(0, 10000)
            };
            if (user.Pets == null) user.Pets = new List<Pet>();

            user.Pets.Add(newPet);
            PersonRepo.Save();
        }

        public static int FoodAmountForPets(int pets)
        {
            int food = 5 * pets;

            return food;
        }
    }
}
