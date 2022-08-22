using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Zadatak
{
    public class DataRepo : IRepo 
    {
     public List<City> GetCities()
     {
            using (var db = new EntityDataModel())
            {
                List<City> collectionCities = new List<City>(db.City);

                return collectionCities;
            }
     }

    public List<StatusPerson> GetStatusPeople()
     {
            using (var db = new EntityDataModel())
            {
                List<StatusPerson> collectionStatusPeople = new List<StatusPerson>(db.StatusPerson);

                return collectionStatusPeople;
            }
     }

    //Funkciji(InsertPerson) proslijedit neku osobu, parametar treba bit neki Person kasnije kad korisnik u sucelju ispuni sve textboxove, od toga se napravi instanca Persona i onda pozovemo ovu funkciju da je dodamo
     public void InsertPerson(Person p)
        {
                using (var db = new EntityDataModel())
                {
                    db.Person.Add(p);
                    db.SaveChanges();
                }
        }

        public void DeletePerson(int deleteID)
        {
            using (var db = new EntityDataModel())
            {
                Person p = db.Person.Find(deleteID); // u sqlu uvjet!! where id=neki broj
                db.Email.RemoveRange(p.Email);
                db.Person.Remove(p);
                db.SaveChanges();
            }
        }

        public void UpdatePerson(int id, Person p)
        {
            using (var db = new EntityDataModel())
            {
                Person dbPerson = db.Person.Find(id); // u sqlu uvjet!! where id=neki broj
                dbPerson.Name = p.Name;
                dbPerson.Surname = p.Surname;
                dbPerson.Pass = p.Pass;
                dbPerson.Telephone = p.Telephone;
                dbPerson.StatusPersonID = p.StatusPersonID;
                dbPerson.CityID = p.CityID;
                //dbPerson.Email = p.Email; // neće moći 

                foreach (var email in p.Email)
                {
                    var dbEmail = db.Email.Find(email.IDEmail);

                    if (db.Email == null)
                        db.Email.Add(email);

                    else
                        dbEmail.EmailAdress = email.EmailAdress;
                }

                db.SaveChanges();
            }
        }

        public List<Person> GetPeople()
        {
            using (var db = new EntityDataModel())
            {
                return db.Person
                    .Include("Email")
                    .Include("StatusPerson")
                    .Include("City")
                    .ToList();
            }
        }

        public Person IsKorisnik(string email, string password)
        {
            using (var db = new EntityDataModel())
            {
                foreach (var p in db.Person)
                {
                    if (password == p.Pass)
                    {
                        foreach (var e in db.Email)
                        {
                            if (email == e.EmailAdress )
                            {
                                return p;
                            }
                        }
                    }
                }
                return null;
            } 
        }

        public List<Email> GetEmailsForPerson(int personID)
        {
            using (var db = new EntityDataModel())
            {
                return db.Email.Where(e => e.PersonID == personID).ToList();
            }
        }

        public void UpdateEmail(int id, Email e)
        {
            using (var db = new EntityDataModel())
            {
                Email dbEmail = db.Email.Find(id);

                dbEmail.EmailAdress = e.EmailAdress;

                db.SaveChanges();
            }
        }
    }
}