namespace Zadatak
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatusPerson")]
    public partial class StatusPerson
    {
        private const char DELIMITER = '|';

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StatusPerson()
        {
            Person = new HashSet<Person>();
        }

        [Key]
        public int IDStatusPerson { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is StatusPerson)
                return (obj as StatusPerson).IDStatusPerson == IDStatusPerson;

            return false;
        }

        public static StatusPerson ParseFromFile(string line)
        {
            string[] details = line.Split('|');

            return new StatusPerson
            {
                IDStatusPerson = int.Parse(details[0]),
                Name = details[1]
            };
        }
    }
}
