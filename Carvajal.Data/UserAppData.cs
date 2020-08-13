using Carvajal.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Carvajal.Data
{
    /// <summary>
    /// Repositorio para la tabla UserApp
    /// </summary>
    public class UserAppData : RepositoryGeneric<UserApp>, IUserAppData, IDisposable
    {
        public UserAppData() : base()
        {
        }

        /// <summary>
        /// Consulta un usuario por documento
        /// </summary>
        /// <param name="identificationNumber"></param>
        /// <returns>UserApp</returns>
        public UserApp GetUserFromByDocument(string identificationNumber)
        {
            try
            {
                var user = GetList("WHERE IdentificationNumber = @Identification", new { Identification = identificationNumber });
                return user.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new DataErrorException("Error in GetUserFromByDocument", ex);
            }
        }

        /// <summary>
        /// Consulta los usuario por nombre completo, por tipo de identificacion, por numero de identificacion
        /// </summary>
        /// <param name="fullName">nombre completo</param>
        /// <param name="typeId">id tipo identificacion</param>
        /// <param name="identificationNumber">documento de identificacion</param>
        /// <param name="showPw">determina si muestra la contraseña</param>
        /// <param name="userId">usuario id</param>
        /// <returns>List UserApp</returns>
        public List<UserApp> GetUserApps(string fullName, int? typeId = null, string identificationNumber = null, int? userId = null, bool showPw = false)
        {
            try
            {
                var users = Connection.Query<UserApp, TypeIdentification, UserApp>("Carvajal_SP_UsersAll", map: (ua, ti) => { ua.TypeIdentification = ti; return ua; },
                    param: new { FullName = fullName, UserId = userId, TypeId = typeId, IdentificationNumber = identificationNumber, ShowPw = showPw },
                    splitOn: "split", commandType: CommandType.StoredProcedure).ToList();
                return users ?? new List<UserApp>();
            }
            catch (Exception ex)
            {
                throw new DataErrorException("Error in GetUserApps", ex);
            }
        }

        /// <summary>
        /// Verifica si existe un usuario por numero de documento
        /// </summary>
        /// <param name="userApp">Usuario</param>
        /// <returns></returns>
        public bool ExistsUserNumber(UserApp userApp)
        {
            try
            {
                int count = 0;
                if (userApp.UserId == 0)
                    count = Count("WHERE IdentificationNumber = @identificationNumber", new { identificationNumber = userApp.IdentificationNumber });
                else
                    count = Count("WHERE IdentificationNumber = @identificationNumber and UserId <> @id", new { identificationNumber = userApp.IdentificationNumber, id = userApp.UserId });

                return count > 0;
            }
            catch (Exception ex)
            {
                throw new DataErrorException("Error in ExistsUserNumber", ex);
            }
        }
    }

    /// <summary>
    /// Repositorio para la tabla UserApp
    /// </summary>
    public interface IUserAppData : IRepositoryGeneric<UserApp>, IDisposable
    {
        /// <summary>
        /// Consulta un usuario por documento
        /// </summary>
        /// <param name="identificationNumber"></param>
        /// <returns></returns>
        UserApp GetUserFromByDocument(string identificationNumber);

        /// <summary>
        /// Consulta los usuario por nombre completo, por tipo de identificacion, por numero de identificacion
        /// </summary>
        /// <param name="fullName">nombre completo</param>
        /// <param name="typeId">id tipo identificacion</param>
        /// <param name="identificationNumber">documento de identificacion</param>
        /// <param name="showPw">determina si muestra la contraseña</param>
        /// <param name="userId">usuario id</param>
        /// <returns>List UserApp</returns>
        List<UserApp> GetUserApps(string fullName, int? typeId = null, string identificationNumber = null, int? userId = null, bool showPw = false);

        /// <summary>
        /// Verifica si existe un usuario por numero de documento
        /// </summary>
        /// <param name="userApp">Usuario</param>
        /// <returns></returns>
        bool ExistsUserNumber(UserApp userApp);
    }
}