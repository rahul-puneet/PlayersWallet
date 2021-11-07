using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerWallet.BL.Model
{
    public class PlayerWalletModel
    {
        public decimal Balance { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
