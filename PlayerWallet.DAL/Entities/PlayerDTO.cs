using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PlayerWallet.DAL.Entities
{
    [Table("Players"), Serializable]
    public class PlayerDTO // Department
    {
        [Key]
        public Guid RegistrationId { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string EmailID { get; set; }
        public virtual IEnumerable<PlayerWalletDTO> PlayerWalletDetails { get; set; } // this is needed to track all the transactions
    }
}

