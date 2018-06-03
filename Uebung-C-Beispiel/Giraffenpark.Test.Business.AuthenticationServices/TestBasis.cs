using Giraffenpark.Business.DataServices;
using NUnit.Framework;

namespace Giraffenpark.Test.Business.AuthenticationServices
{
    public class TestBasis
    {
        [SetUp]
        protected void TearDownFuerJedeTestMethode()
        {
            //TODORollback Änderungen. Allgemeine Lösung
            var model = new AuthenticationDatenModel();
            model.Database.ExecuteSqlCommand("TRUNCATE TABLE BENUTZER");
        }

        protected AuthenticationDatenModel HoleObjektModell()
        {
            var model = new AuthenticationDatenModel();
            return model;
        }
    }
}