using PlayerWallet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerWallet.BL.Interfaces
{
    public interface IPlayerWalletRepository : IGenericRepository<PlayerWalletDTO>
    {
    }
}
