using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PlayerWallet.DAL.Entities
{
    [Table("PlayerWallet"), Serializable]
    public class PlayerWalletDTO //Employee 
    {
        [Key]
        public Guid ID { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Balance { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public Guid RegistrationId { get; set; }

        [ForeignKey("RegistrationId")]
        public virtual PlayerDTO PlayerDTO { get; set; }
    }
}
