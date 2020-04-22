using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessNetF
{
    public class PersonRepository
    {
        private AppContext db;
        public PersonRepository()
        {
            db = new AppContext();
        }

        public List<Person> GetAll()
        {

            try
            {
                var PeopleList = db.Persons.ToList();
                return PeopleList;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;

        }

        public Person Get(int id)
        {

            try
            {
                Person per = db.Persons.FirstOrDefault(p => p.PersonId == id);
                return per;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void Delete(int id)
        {

            try
            {
                Person per = db.Persons.FirstOrDefault(p => p.PersonId == id);
                per.Friends.Clear();
                per.Partner = null;
                db.Persons.Remove(per);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                db.SaveChanges();
            }

        }

        public void Edit(Person person)
        {

            try
            {
                Person per = db.Persons.FirstOrDefault(p => p.PersonId == person.PersonId);
                per.Name = person.Name;
                per.LastName = person.LastName;
                per.Email = person.Email;
                per.Phone = person.Phone;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                db.SaveChanges();
            }

        }

        public void Save()
        {
            db.SaveChanges();
        }

        public int Add(Person person)
        {
            try
            {
                db.Persons.Add(person);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                db.SaveChanges();
            }
            int id = db.Persons.FirstOrDefault(x => x.Email == person.Email).PersonId;
            return id;
        }
    }
}