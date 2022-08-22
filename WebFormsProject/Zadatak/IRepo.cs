using System.Collections.Generic;

namespace Zadatak
{
    public interface IRepo
    {
        List<City> GetCities();
        List<StatusPerson> GetStatusPeople();
        void InsertPerson(Person p);
        void UpdatePerson(int id, Person p);
        List<Person> GetPeople();
        Person IsKorisnik(string email, string password);
        List<Email> GetEmailsForPerson(int personID);
        void UpdateEmail(int id, Email e);
        void DeletePerson(int deleteID);
    }
}