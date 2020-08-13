using Dapper;

namespace Carvajal.Models
{
    [Table("TypeId")]
    public class TypeIdentification
    {
        [Column("TypeId")]
        public int TypeId { get; set; }

        [Column("TypeDescription")]
        public string TypeDescription { get; set; }

        [Column("TypeCode")]
        public string TypeCode { get; set; }
    }
}