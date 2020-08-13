using Carvajal.Models;
using System;

namespace Carvajal.Data
{
    public class MatchDetailData : RepositoryGeneric<MatchDetail>, IMatchDetailData, IDisposable
    {
        public MatchDetailData() : base()
        {
        }
    }

    public interface IMatchDetailData : IRepositoryGeneric<MatchDetail>, IDisposable { }
}