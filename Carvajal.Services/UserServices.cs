using Carvajal.Data;
using Carvajal.Models;
using Carvajal.Tools;
using System;
using System.Collections.Generic;

namespace Carvajal.Services
{
    public class UserServices : IDisposable, IUserServices
    {
        private readonly IUserAppData _data;

        private bool disposedValue;

        public UserServices(IUserAppData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public List<UserApp> GetUserAppsFromFilter(UserFilter filter)
        {
            try
            {
                var users = _data.GetUserApps(fullName: filter.FullName, typeId: filter.TypeId, identificationNumber: filter.IdentificationNumber);
                return users;
            }
            catch (DataErrorException ex)
            {
                Logger.ErrorFatal("GetUserAppsFromFilter", ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal("GetUserAppsFromFilter", ex);
                throw ex;
            }
        }

        public UserApp UserAppInsert(UserApp userApp)
        {
            try
            {
                if (_data.ExistsUserNumber(userApp))
                    throw new ExceptionBusiness($"There is already a user with an identification number {userApp.IdentificationNumber}");
                
                userApp.DateCreation = DateTime.Now;

                var userId = _data.Insert<int>(userApp);
                userApp.UserId = userId;

                return userApp;
            }
            catch (DataErrorException ex)
            {
                Logger.ErrorFatal("UserAppInsert", ex);
                throw ex;
            }
            catch (ExceptionBusiness) 
            {
                throw;
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal("GetUserAppsFromFilter", ex);
                throw ex;
            }
        }

        public UserApp UserAppUpdate(UserApp userApp)
        {
            try
            {
                if (_data.ExistsUserNumber(userApp))
                    throw new ExceptionBusiness($"There is already a user with an identification number {userApp.IdentificationNumber}");

                var oldUser = _data.GetFindId(userApp.UserId);

                if (oldUser == null) return null;

                oldUser.IdentificationNumber = userApp.IdentificationNumber;
                oldUser.LastName = userApp.LastName;
                oldUser.TypeId = userApp.TypeId;
                oldUser.UserEmail = userApp.UserEmail;
                oldUser.UserName = userApp.UserName;

                _data.Update(oldUser);

                return oldUser;
            }
            catch (DataErrorException ex)
            {
                Logger.ErrorFatal("UserAppUpdate", ex);
                throw ex;
            }
            catch (ExceptionBusiness)
            {
                throw;
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal("UserAppUpdate", ex);
                throw ex;
            }
        }

        public UserApp GetUserAppFromById(int userId)
        {
            try
            {
                return _data.GetFindId(userId);
            }
            catch (DataErrorException ex)
            {
                Logger.ErrorFatal("GetUserAppFromById", ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal("GetUserAppFromById", ex);
                throw ex;
            }
        }

        #region [Dispose]

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (_data != null)
                        _data.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UserAppServices()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion [Dispose]
    }

    public interface IUserServices : IDisposable
    {
        UserApp GetUserAppFromById(int userId);

        List<UserApp> GetUserAppsFromFilter(UserFilter filter);

        UserApp UserAppInsert(UserApp userApp);

        UserApp UserAppUpdate(UserApp userApp);
    }
}