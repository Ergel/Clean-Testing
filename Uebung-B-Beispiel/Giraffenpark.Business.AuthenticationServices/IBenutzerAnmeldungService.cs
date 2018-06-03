namespace Giraffenpark.Business.AuthenticationServices
{
    public interface IBenutzerAnmeldungService
    {
        bool BenutzerRegistrieren(string benutzername, string vorname, string nachname, string passwort);
        bool DarfBenutzerAnmelden(string benutzerName, string passwort);
    }
}
