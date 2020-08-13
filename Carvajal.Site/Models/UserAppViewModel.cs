using Carvajal.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Carvajal.Site.Models
{
    /// <summary>
    /// Usuario View Model
    /// </summary>
    public class UserAppViewModel
    {
        /// <summary>
        /// Id del usuario
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Tipo de identificacion del usuario
        /// </summary>
        [Required]
        public int TypeId { get; set; }

        /// <summary>
        /// Nombre de usuario 
        /// </summary>
        [Required]
        [MaxLength(20, ErrorMessage = "No puede pasar de 20 caracteres")]
        [MinLength(3, ErrorMessage = "Como mínimo deben ser 3 caracteres")]
        public string UserName { get; set; }

        /// <summary>
        /// Apellido
        /// </summary>
        [Required]
        [MaxLength(20, ErrorMessage = "No puede pasar de 20 caracteres")]
        [MinLength(3, ErrorMessage = "Como mínimo deben ser 3 caracteres")]
        public string LastName { get; set; }

        /// <summary>
        /// Numero de identificacion
        /// </summary>
        [Required]
        [MaxLength(15, ErrorMessage = "No puede pasar de 15 caracteres")]
        [MinLength(4, ErrorMessage = "Como mínimo deben ser 4 caracteres")]
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        [MaxLength(20, ErrorMessage = "No puede pasar de 20 caracteres")]
        [MinLength(6, ErrorMessage = "Como mínimo deben ser 6 caracteres")]
        public string UserPassword { get; set; }

        /// <summary>
        /// Confirmacion del password
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Correo de usuario
        /// </summary>
        [EmailAddress]
        [Required]
        public string UserEmail { get; set; }

        /// <summary>
        /// Descripcion del tipo de identificacion
        /// </summary>
        public string TypeIdDescription { get; set; }
    }

    /// <summary>
    /// Clase Tools para el modelo UserApp y UserAppViewModel
    /// </summary>
    public static class UserAppViewModelTools
    {
        /// <summary>
        /// Convierte un UserAppViewModel a un objeto tipo UserApp
        /// </summary>
        /// <param name="user">UserAppViewModel</param>
        /// <returns>UserApp</returns>
        public static UserApp UserViewModelToUser(this UserAppViewModel user)
        {
            return new UserApp()
            {
                DateCreation = DateTime.Now,
                IdentificationNumber = user.IdentificationNumber,
                LastName = user.LastName,
                TypeId = user.TypeId,
                TypeIdentification = new TypeIdentification()
                {
                    TypeId = user.TypeId,
                    TypeDescription = user.TypeIdDescription
                },
                UserEmail = user.UserEmail,
                UserId = user.UserId,
                UserName = user.UserName,
                UserPassword = user.UserPassword
            };
        }

        /// <summary>
        /// Convierte un objeto tipo UserApp a tipo UserAppViewModel
        /// </summary>
        /// <param name="user">UserApp</param>
        /// <returns>UserAppViewModel</returns>
        public static UserAppViewModel UserToUserViewModel(this UserApp user)
        {
            return new UserAppViewModel()
            {
                IdentificationNumber = user.IdentificationNumber,
                UserPassword = user.UserPassword,
                LastName = user.LastName,
                TypeId = user.TypeId,
                UserEmail = user.UserEmail,
                UserId = user.UserId,
                UserName = user.UserName,
                TypeIdDescription = user.TypeIdentification != null ? user.TypeIdentification.TypeCode : string.Empty,
                ConfirmPassword = string.Empty
            };
        }
    }
}