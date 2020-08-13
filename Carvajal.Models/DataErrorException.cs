using System;

namespace Carvajal.Models
{
    /// <summary>
    /// Excepcion para controlar errores en la capa de datos
    /// </summary>
    public class DataErrorException : Exception
    {
        /// <summary>
        /// Excepcion para controlar errores en la capa de datos
        /// </summary>
        public DataErrorException() : base() { }

        /// <summary>
        /// Excepcion para controlar errores en la capa de datos
        /// </summary>
        /// <param name="message">error de data o validación</param>
        public DataErrorException(string message) : base(message) { }

        /// <summary>
        /// Excepcion para controlar errores en la capa de datos
        /// </summary>
        /// <param name="message">error de negocio o validación</param>
        /// <param name="innerException"></param>
        public DataErrorException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Mensaje de excepcion Interna
        /// </summary>
        public string MessageInnerException { get { return InnerException != null ? InnerException.Message : Message; } }
    }
}