using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Giraffenpark.Authentication.Domain;
using Giraffenpark.Infrastructure.AuthenticationServices;

namespace Giraffenpark.Business.DataServices
{
    public partial class AuthenticationDatenModel : DbContext, IDomainObjectRepository
    {
        public AuthenticationDatenModel()
            : base("name=AuthenticationDatenModel")
        {
        }

        public virtual DbSet<Benutzer> Benutzer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public IEnumerable<T> GetAllDomainObjects<T>()
        {
            if ((typeof(T) == typeof(Benutzer)))
            {
                return this.Benutzer.Cast<T>();
            }

            throw new NotSupportedException($"Das Holen der Objekte mit dem Type {typeof(T).FullName} wurde noch nicht umgesetzt.");
        }

        public IEnumerable<T> GetDomainObjects<T>(Func<T, bool> predicateFilter)
        {
            if ((typeof(T) == typeof(Benutzer)))
            {
                return GetAllDomainObjects<T>().AsEnumerable().Where(predicateFilter);
            }

            throw new NotSupportedException($"Das Holen der Objekte mit dem Type {typeof(T).FullName} wurde noch nicht umgesetzt.");
        }

        public void PersistDomainObject<T>(T daten)
        {
            if ((typeof(T) == typeof(Benutzer)))
            {
                Benutzer.Add(daten as Benutzer);
            }
            else
            {
                throw new NotSupportedException($"Das Persistieren der Objekte mit dem Type {typeof(T).FullName} wurde noch nicht umgesetzt.");
            }

            SaveChanges();
        }

        public T CreateDomainObject<T>() where T : new()
        {
            return new T();
        }
    }
}
