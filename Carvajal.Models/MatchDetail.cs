using Dapper;

namespace Carvajal.Models
{
    [Table("MatchDetail")]
    public class MatchDetail
    {
        [Column("MatchDetailId")]
        public int MatchDetailId { get; set; }

        [Column("MatchId")]
        public int MatchId { get; set; }

        [Column("PosX")]
        public int PosX { get; set; }

        [Column("PosY")]
        public int PosY { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("GamePieceId")]
        public int GamePieceId { get; set; }
    }
}