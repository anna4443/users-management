using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Zadatak
{
    public class FileRepo : IRepo
    {
        private const string PERSONS_FILEPATH = @"Person.txt";
        private const string CITIES_FILEPATH = @"City.txt";
        private const string STATUS_FILEPATH = @"Status.txt";

        public FileRepo()
        {
            CreateFilesIfNotExist();
        }

        private void CreateFilesIfNotExist()
        {
            if (!File.Exists(PERSONS_FILEPATH))
            {
                File.Create(PERSONS_FILEPATH).Close();
            }

            if (!File.Exists(CITIES_FILEPATH))
            {
                File.Create(CITIES_FILEPATH).Close();
            }

            if (!File.Exists(STATUS_FILEPATH))
            {
                File.Create(STATUS_FILEPATH).Close();
            }
        }

        public void DeletePerson(int deleteID)
        {
            // bit će svi zapisani u fileu osim onog s deleteID
            IEnumerable<Person> people = GetPeople().Where(p => p.IDPerson != deleteID);

            File.WriteAllLines(PERSONS_FILEPATH, people.Select(p => p.FormatForFile()));
        }

        public List<City> GetCities()
        {
            List<City> cities = new List<City>();
            IEnumerable<string> lines = File.ReadAllLines(CITIES_FILEPATH, Encoding.GetEncoding("windows-1252"));

            foreach (var line in lines)
            {
                City city = City.ParseFromFile(line);
                cities.Add(city);
            }

            return cities;
        }

        public List<Email> GetEmailsForPerson(int personID)
        {
            // za svaku osobu će foreachat i od svake osobe će uzet njenu kolekciju mailova i dodat će na listu koja se vrati kasnije
            return GetPeople().SelectMany(person => person.Email).ToList();
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            IEnumerable<string> lines = File.ReadAllLines(PERSONS_FILEPATH);

            foreach (var line in lines)
            {
                Person p = Person.ParseFromFile(line);
                people.Add(p);
            }

            return people;
        }

        public List<StatusPerson> GetStatusPeople()
        {
            List<StatusPerson> statuses = new List<StatusPerson>();
            IEnumerable<string> lines = File.ReadAllLines(STATUS_FILEPATH);

            foreach (var line in lines)
            {
                StatusPerson sp = StatusPerson.ParseFromFile(line);
                statuses.Add(sp);
            }

            return statuses;
        }

        public void InsertPerson(Person p)
        {
            p.IDPerson = GetNewPersonID();
            int emailID = GetNewEmailID();

            foreach (var email in p.Email)
            {
                email.IDEmail = emailID++;
            }

            // dodat će na kraj filea na ono kaj je unutar filea
            File.AppendAllText(PERSONS_FILEPATH, p.FormatForFile() + Environment.NewLine);
        }

        public Person IsKorisnik(string email, string password)
        {
            // ako bilo koja osoba zadovoljava uvjet koji smo stavili unutar firstordefault onda će vratiti osobu, uprotivnom null  
            // any - da bilo koji email zadovoljava uvjet
            return GetPeople().FirstOrDefault(p => p.Pass == password && p.Email.Any(e => e.EmailAdress == email));
        }

        public void UpdateEmail(int id, Email e)
        {
            List<Person> people = GetPeople();

            foreach (var person in people)
            {
                //ako osoba ima email koji ima id prosljeden u parametru...
                if(person.Email.Any(x => x.IDEmail == id))
                {
                    //napravi novu listu koja ce zamijeniti trenutnu u osobi
                    List<Email> emails = new List<Email>();

                    //prodi kroz trenutne mailove, ako naides na mail koji ima id onog maila kojeg zelimo updateat, onda taj updateani (iz parametra) stavljamo u listu, inace, samo ostavimo onaj stari
                    foreach (var email in person.Email)
                    {
                        if (email.IDEmail == id)
                            emails.Add(e);
                        else
                            emails.Add(email);
                    }

                    //updateaj kolekciju mejlova s novom
                    person.Email = emails;
                }
            }

            File.WriteAllLines(PERSONS_FILEPATH, people.Select(x => x.FormatForFile()));
        }

        public void UpdatePerson(int id, Person p)
        {
            List<Person> people = GetPeople();

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].IDPerson == id)
                {
                    people[i] = p;
                    File.WriteAllLines(PERSONS_FILEPATH, people.Select(x => x.FormatForFile()));
                }
            }
        }

        private int GetNewPersonID()
        {
            var people = GetPeople();

            if (people.Count == 0)
                return 1;

            return people.Max(person => person.IDPerson) + 1;
        }

        private int GetNewEmailID()
        {
            var people = GetPeople();

            if (people.Count == 0)
                return 1;

            int max = int.MinValue;

            foreach (var person in people)
            {
                foreach (var email in person.Email)
                {
                    if (email.IDEmail > max)
                        max = email.IDEmail;
                }
            }

            return max + 1;
        }
    }
}