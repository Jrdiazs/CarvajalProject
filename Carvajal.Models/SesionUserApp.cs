namespace Carvajal.Models
{
    public class SesionUserApp
    {
        public bool Succes { get; set; }

        public string Message { get; set; }

        public string TokenId { get; set; }

        public int? UserId { get; set; }
    }

    public class AuthSesionUser
    {
        public string IdentificationNumber { get; set; }

        public string Pw { get; set; }
    }
}