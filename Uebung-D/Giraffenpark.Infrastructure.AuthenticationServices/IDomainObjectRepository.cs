using System;
using System.Collections.Generic;

namespace Giraffenpark.Infrastructure.AuthenticationServices
{
    public interface IDomainObjectRepository
    {
        IEnumerable<T> GetAllDomainObjects<T>();

        IEnumerable<T> GetDomainObjects<T>(Func<T, bool> predicateFilter);

        void PersistDomainObject<T>(T domainObject);

        T CreateDomainObject<T>() where T : new();
    }
}
