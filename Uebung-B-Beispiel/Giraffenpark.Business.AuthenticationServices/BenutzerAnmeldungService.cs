using System;
using System.Linq;
using Giraffenpark.Business.DataServices;

namespace Giraffenpark.Business.AuthenticationServices
{
    public class BenutzerAnmeldungService : IBenutzerAnmeldungService
    {
        private AuthenticationDatenModel objektModell;
        public BenutzerAnmeldungService()
        {
            //todo: Interface
            objektModell = new AuthenticationDatenModel();
        }

        public bool BenutzerRegistrieren(string benutzername, string vorname, string nachname, string passwort)
        {
            if (vorname.Equals("Özgür") == false)
            {
                var benutzer = new Benutzer();
                benutzer.Benutzername = benutzername;
                benutzer.Vorname = vorname;
                benutzer.Nachname = nachname;
                benutzer.Passwort = passwort.Trim();

                objektModell.Benutzer.Add(benutzer);
                objektModell.SaveChanges();

                return true;
            }

            return false;
        }

        public bool DarfBenutzerAnmelden(string benutzerName, string passwort)
        {
            var benutzer = objektModell.Benutzer.SingleOrDefault(bntzer => bntzer.Benutzername.Equals(benutzerName));
            return benutzer?.Passwort.Equals(passwort, StringComparison.Ordinal) ?? false;
        }
    }
}