using System.Linq;
using Giraffenpark.Business.AuthenticationServices;
using NUnit.Framework;

namespace Giraffenpark.Test.Business.AuthenticationServices
{
    [TestFixture]
    public class BenutzerAnmeldungServiceTest : TestBasis
    {
        [Test]
        public void TesteBenutzerRegistrierungWennNichtOezguerDannErfolg()
        {
            var benutzername = "Hansi";
            var vorname = "Hans";
            var nachname = "Meyer";
            var passwort = "IstMirEgal";

            var service = new BenutzerAnmeldungService();
            var wurdeBenutzerRegistriert = service.BenutzerRegistrieren(benutzername, vorname, nachname, passwort);
            Assert.That(wurdeBenutzerRegistriert, Is.True);

            //TODO: Wie können wir die Registrierung ohne das Ergebnis aus der Methode prüfen? Maske / Daten / Anderer prozess

            var objektModell = HoleObjektModell();
            var registeredBenutzer = objektModell.Benutzer.Single(bntzer => bntzer.Benutzername.Equals(benutzername));
            Assert.That(registeredBenutzer.Benutzername, Is.EqualTo(benutzername));
            Assert.That(registeredBenutzer.Vorname, Is.EqualTo(vorname));
            Assert.That(registeredBenutzer.Nachname, Is.EqualTo(nachname));
            Assert.That(registeredBenutzer.Passwort, Is.EqualTo(passwort));
        }

        [Test]
        public void TesteBenutzerRegistrierungWennVornameÖzgürDannKeinErfolg()
        {
            var benutzername = "Hansi";
            var vorname = "Özgür";
            var nachname = "Meyer";
            var passwort = "IstMirEgal";

            var service = new BenutzerAnmeldungService();
            var wurdeBenutzerRegistriert = service.BenutzerRegistrieren(benutzername, vorname, nachname, passwort);
            Assert.That(wurdeBenutzerRegistriert, Is.False);

            var objektModell = HoleObjektModell();
            var registeredBenutzer = objektModell.Benutzer.SingleOrDefault(bntzer => bntzer.Benutzername.Equals(benutzername));
            Assert.That(registeredBenutzer, Is.Null);

            //TODO: Check Anmelden
        }

        [Test]
        public void TesteAnmeldungWennDerBenutzerVorherRegistriertDannErfolg()
        {
            var benutzername = "Hansi";
            var vorname = "Hans";
            var nachname = "Meyer";
            var passwort = "IstMirEgal";

            var service = new BenutzerAnmeldungService();
            service.BenutzerRegistrieren(benutzername, vorname, nachname, passwort);

            var darfBenutzerSichAnmelden = service.DarfBenutzerAnmelden(benutzername, passwort);
            Assert.That(darfBenutzerSichAnmelden, Is.True);
        }

        [Test]
        public void TesteAnmeldungWennDerBenutzerVorherNichtRegistriertDannKeinErfolg()
        {
            var service = new BenutzerAnmeldungService();
            var darfBenutzerSichAnmelden = service.DarfBenutzerAnmelden("benutzername", "passwort");
            Assert.That(darfBenutzerSichAnmelden, Is.False);
        }
    }
}