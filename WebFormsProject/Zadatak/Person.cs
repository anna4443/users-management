namespace Zadatak
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Person")]
    public partial class Person
    {
        private const char DELIMITER = '|'; 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            Email = new HashSet<Email>();
        }

        [Key]
        public int IDPerson { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string Pass { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        public int? StatusPersonID { get; set; }

        public int? CityID { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Email> Email { get; set; }

        public virtual StatusPerson StatusPerson { get; set; }

        public static Person ParseFromFile(string line)
        {
            string[] details = line.Split('|');

            string[] emailDetails = details[7].Split('-');

            List<Email> kolekcijaEmailova = new List<Email>();

            foreach (var e in emailDetails)
            {
                string[] mejlDetalji = e.Split('~');

                kolekcijaEmailova.Add(new Email {
                    IDEmail = int.Parse(mejlDetalji[0]),
                    EmailAdress = mejlDetalji[1]
                });
            }

            return new Person
            {
                IDPerson = int.Parse(details[0]),
                Name = details[1],
                Surname = details[2],
                Pass = details[3],
                Telephone = details[4],
                StatusPersonID = int.Parse(details[5]),
                CityID = int.Parse(details[6]),
                Email = kolekcijaEmailova
            };
        }

        public string FormatForFile()
        {
            //var rp = RepoFactory.GetRepository();

            //var mejlovi = rp.GetEmailsForPerson(IDPerson);

            var spojeniMejlovi = string.Join("-", Email);

            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", IDPerson ,Name, Surname, Pass, Telephone, StatusPersonID, CityID, spojeniMejlovi);
        }
    }
}
