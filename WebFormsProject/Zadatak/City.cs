namespace Zadatak
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("City")]
    public partial class City
    {
        private const char DELIMITER = '|';

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public City()
        {
            Person = new HashSet<Person>();
        }

        [Key]
        public int IDCity { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is City)
                return (obj as City).IDCity == IDCity;

            return false;
        }

        public static City ParseFromFile(string line)
        {
            string[] details = line.Split('|');

            return new City
            {
                IDCity = int.Parse(details[0]),
                Name = details[1]
            };
        }
    }
}
