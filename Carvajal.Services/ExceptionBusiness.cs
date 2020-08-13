using System;

namespace Carvajal.Services
{
    /// <summary>
    /// Excepcion para controlar errores de negocio o validacion
    /// </summary>
    public class ExceptionBusiness : Exception
    {
        /// <summary>
        /// Excepcion para controlar errores de negocio o validacion
        /// </summary>
        public ExceptionBusiness() : base() { }

        /// <summary>
        /// Excepcion para controlar errores de negocio o validacion
        /// </summary>
        /// <param name="message">error de negocio o validación</param>
        public ExceptionBusiness(string message) : base(message) { }

        /// <summary>
        /// Excepcion para controlar errores de negocio o validacion
        /// </summary>
        /// <param name="message">error de negocio o validación</param>
        /// <param name="innerException"></param>
        public ExceptionBusiness(string message, Exception innerException) : base(message, innerException) { }
    }
}