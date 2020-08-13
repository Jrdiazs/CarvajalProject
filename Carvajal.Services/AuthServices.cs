using Carvajal.Data;
using Carvajal.Models;
using System;

namespace Carvajal.Services
{
    /// <summary>
    /// Componente de servicios para IUserAppData
    /// </summary>
    public class AuthServices : IAuthServices, IDisposable
    {
        private readonly IUserAppData _data;

        private bool disposedValue;

        public AuthServices(IUserAppData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public SesionUserApp Autenticate(AuthSesionUser user)
        {
            try
            {
                return new SesionUserApp();
            }
            catch (Exception)
            {
                throw;
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

    /// <summary>
    /// Componente de servicios para IUserAppData
    /// </summary>
    public interface IAuthServices : IDisposable { }
}