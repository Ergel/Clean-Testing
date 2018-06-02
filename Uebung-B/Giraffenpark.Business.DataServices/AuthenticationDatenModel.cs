using System.Data.Entity;

namespace Giraffenpark.Business.DataServices
{
    public partial class AuthenticationDatenModel : DbContext
    {
        public AuthenticationDatenModel()
            : base("name=AuthenticationDatenModel")
        {
        }

        public virtual DbSet<Benutzer> Benutzer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benutzer>()
                .Property(e => e.Passwort)
                .IsFixedLength();
        }
    }
}
