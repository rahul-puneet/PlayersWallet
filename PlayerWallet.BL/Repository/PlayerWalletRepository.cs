using Microsoft.EntityFrameworkCore;
using PlayerWallet.BL.Interfaces;
using PlayerWallet.DAL.DatabasesContext;
using PlayerWallet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerWallet.BL.Repository
{
    public class PlayerWalletRepository : GenericRepository<PlayerWalletDTO>, IPlayerWalletRepository
    {
        private readonly PlayerDbContext _playerDbContext;

        public PlayerWalletRepository(PlayerDbContext playerDbContext) : base(playerDbContext)
        {
            _playerDbContext = playerDbContext;
        }

        public override IEnumerable<PlayerWalletDTO> Get()
        {
            var result = _playerDbContext.PlayerWalletBalance.Include(x => x.PlayerDTO);
            return result;
        }
    }
}
