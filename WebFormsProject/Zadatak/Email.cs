namespace Zadatak
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Email")]
    public partial class Email
    {
        [Key]
        public int IDEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAdress { get; set; }

        public int? PersonID { get; set; }

        public virtual Person Person { get; set; }

        public override string ToString() => $"{IDEmail}~{EmailAdress}";
    }
}
