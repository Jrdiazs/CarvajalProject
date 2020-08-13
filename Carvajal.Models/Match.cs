using Dapper;

namespace Carvajal.Models
{
    [Table("Match")]
    public class Match
    {
        [Key]
        [Column("MatchId")]
        public int MatchId { get; set; }

        [Column("MatchName")]
        public string MatchName { get; set; }

        [Column("GameUserIdOne")]
        public int GameUserIdOne { get; set; }

        [Column("GameUserIdTwo")]
        public int GameUserIdTwo { get; set; }

        [Column("GameWinningUser")]
        public int? GameWinningUser { get; set; }

        [Column("GamePieceUserOneId")]
        public int GamePieceUserOneId { get; set; }

        [Column("GamePieceUserTwoId")]
        public string GamePieceUserTwoId { get; set; }
    }
}