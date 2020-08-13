using Carvajal.Models;
using System;

namespace Carvajal.Data
{
    public class GamePieceData : RepositoryGeneric<GamePiece>, IGamePieceData, IDisposable
    {
        public GamePieceData() : base()
        {
        }
    }

    public interface IGamePieceData : IRepositoryGeneric<GamePiece>, IDisposable { }
}