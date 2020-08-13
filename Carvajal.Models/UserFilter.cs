namespace Carvajal.Models
{
    /// <summary>
    /// Request para buscar usuarios
    /// </summary>
    public class UserFilter
    {
        /// <summary>
        /// Nombre completo
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Tipo de indentificacion
        /// </summary>
        public int? TypeId { get; set; }

        /// <summary>
        /// Numero de identificacion
        /// </summary>
        public string IdentificationNumber { get; set; }
    }
}