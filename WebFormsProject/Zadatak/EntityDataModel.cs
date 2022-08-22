namespace Zadatak
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityDataModel : DbContext
    {
        public EntityDataModel()
            : base("name=EntityDataModel2")
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<StatusPerson> StatusPerson { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Person)
                .WithOptional(e => e.City)
                .HasForeignKey(e => e.CityID);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Email)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.PersonID);

            modelBuilder.Entity<StatusPerson>()
                .HasMany(e => e.Person)
                .WithOptional(e => e.StatusPerson)
                .HasForeignKey(e => e.StatusPersonID);
        }
    }
}
