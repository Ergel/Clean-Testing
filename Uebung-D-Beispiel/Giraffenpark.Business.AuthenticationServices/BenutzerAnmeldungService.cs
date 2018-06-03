using System;
using System.Linq;
using Giraffenpark.Authentication.Domain;
using Giraffenpark.Infrastructure.AuthenticationServices;

namespace Giraffenpark.Business.AuthenticationServices
{
    public class BenutzerAnmeldungService : IBenutzerAnmeldungService
    {
        private readonly IDomainObjectRepository _domainObjectRepository;
        public BenutzerAnmeldungService(IDomainObjectRepository domainObjectRepository)
        {
            _domainObjectRepository = domainObjectRepository;
        }

        public bool BenutzerRegistrieren(string benutzername, string vorname, string nachname, string passwort)
        {
            if (ReplaceUmlaute(vorname).Equals("Oezguer", StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            ErzeugeRegistriertenBenutzer(benutzername, vorname, nachname, passwort);

            return true;

        }

        private void ErzeugeRegistriertenBenutzer(string benutzername, string vorname, string nachname, string passwort)
        {
            var benutzer = _domainObjectRepository.CreateDomainObject<Benutzer>();
            benutzer.Benutzername = benutzername;
            benutzer.Vorname = vorname;
            benutzer.Nachname = nachname;
            benutzer.Passwort = passwort;

            _domainObjectRepository.PersistDomainObject(benutzer);
        }

        public bool DarfBenutzerAnmelden(string benutzername, string passwort)
        {
            var benutzer = _domainObjectRepository.GetDomainObjects<Benutzer>(bntzer => bntzer.Benutzername.Equals(benutzername)).SingleOrDefault();
            return benutzer?.Passwort.Equals(passwort, StringComparison.Ordinal) ?? false;
        }

        private static string ReplaceUmlaute(string inputText)
        {
            return inputText.Replace("ä", "ae").Replace("ö", "oe").Replace("ü", "ue")
                .Replace("A", "Ae").Replace("Ö", "Oe").Replace("Ü", "Ue").Replace("ß", "ss");
        }
    }
}