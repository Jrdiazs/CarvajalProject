using Dapper;

namespace Carvajal.Models
{
    [Table("GamePiece")]
    public class GamePiece
    {
        [Column("GamePieceId")]
        public int GamePieceId { get; set; }

        [Column("Description")]
        public string Description { get; set; }
    }
}