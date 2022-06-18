using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BankService.EF {
    public partial class BankModel : DbContext {
        public BankModel()
            : base("name=BankEntities") {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Guarantor> Guarantors { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Application>()
                .Property(e => e.Amount)
                .HasPrecision(18, 3);
        }
    }
}
