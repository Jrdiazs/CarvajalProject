using Carvajal.Models;
using System;

namespace Carvajal.Data
{
    public class MatchData : RepositoryGeneric<Match>, IMatchData, IDisposable
    {
        public MatchData() : base()
        {
        }
    }

    public interface IMatchData : IRepositoryGeneric<Match>, IDisposable { }
}