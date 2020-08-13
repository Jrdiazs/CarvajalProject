using Dapper;
using System;

namespace Carvajal.Models
{
    [Table("UserApp")]
    public class UserApp
    {
        [Column("UserId")]
        public int UserId { get; set; }

        [Column("TypeId")]
        public int TypeId { get; set; }

        [Column("UserName")]
        public string UserName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return $"{UserName} {LastName}"; } }

        [NotMapped]
        public TypeIdentification TypeIdentification { get; set; }

        [Column("IdentificationNumber")]
        public string IdentificationNumber { get; set; }

        [Column("DateCreation")]
        public DateTime? DateCreation { get; set; }

        [Column("UserPassword")]
        public string UserPassword { get; set; }

        [Column("UserEmail")]
        public string UserEmail { get; set; }
    }
}