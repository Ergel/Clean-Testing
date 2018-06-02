using System;
using System.Linq;
using System.Reflection;
using Giraffenpark.Business.AuthenticationServices;
using Giraffenpark.Business.DataServices;
using NUnit.Framework;

namespace Giraffenpark.Test.Business.AuthenticationServices
{
    [TestFixture]
    public class BenutzerAnmeldungServiceTest
    {
        private static BenutzerAnmeldungService service;

        [Test]
        public void TesteDasInstanzierenDerServiceKlasse()
        {
            service = new BenutzerAnmeldungService();
            Assert.That(service, Is.Not.Null);
        }

        [Test]
        public void TesteDieRegisterBenutzerMethode()
        {
            var methodParameters = new object[]
            {
                "benutzername", "Özgür", "nachname", "passwort"
            };

            typeof(BenutzerAnmeldungService).GetMethod("RegisterBenutzer", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new BenutzerAnmeldungService(), methodParameters); ;
        }

        [Test]
        public void TesteSaveBenutzerInDatenbank()
        {
            var methodParameters = new object[]
            {
                "benutzername", "Özgür", "nachname", "passwort"
            };

            typeof(BenutzerAnmeldungService).GetMethod("RegisterBenutzer", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new BenutzerAnmeldungService(), methodParameters); ;

            var model = new AuthenticationDatenModel();
            var benutzer = model.Benutzer.First(bntzer => bntzer.Benutzername == "benutzername");
            Assert.That(benutzer.Benutzername, Is.Not.Empty);
        }

        [Test]
        public void TesteMethodeDarfAnmelden()
        {
            var resultOfMethod = service.DarfBenutzerAnmelden("benutzername", "passwort");
            Assert.That(resultOfMethod, Is.True);
        }

        [Test]
        public void TesteÖzgürDarfNichtRegistrieren()
        {
            var resultOfMethod = service.BenutzerRegistrieren("Özgür", "Özgür", "nachname", "passwort");
            Assert.That(resultOfMethod, Is.False);
        }
    }
}
