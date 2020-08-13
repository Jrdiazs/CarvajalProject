using Carvajal.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Carvajal.Site.Models
{
    public class UserAppViewModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "No puede pasar de 20 caracteres")]
        [MinLength(3, ErrorMessage = "Como mínimo deben ser 3 caracteres")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "No puede pasar de 20 caracteres")]
        [MinLength(3, ErrorMessage = "Como mínimo deben ser 3 caracteres")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "No puede pasar de 15 caracteres")]
        [MinLength(4, ErrorMessage = "Como mínimo deben ser 4 caracteres")]
        public string IdentificationNumber { get; set; }

        [MaxLength(20, ErrorMessage = "No puede pasar de 20 caracteres")]
        [MinLength(6, ErrorMessage = "Como mínimo deben ser 6 caracteres")]
        public string UserPassword { get; set; }

        public string ConfirmPassword { get; set; }

        [EmailAddress]
        [Required]
        public string UserEmail { get; set; }

        public string TypeIdDescription { get; set; }
    }

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