using Carvajal.Models;
using System;

namespace Carvajal.Data
{
    public class TypeIdData : RepositoryGeneric<TypeIdentification>, ITypeIdData, IDisposable
    {
        public TypeIdData() : base()
        {
        }
    }

    public interface ITypeIdData : IRepositoryGeneric<TypeIdentification>, IDisposable { }
}