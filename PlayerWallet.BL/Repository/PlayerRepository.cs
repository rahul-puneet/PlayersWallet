using Microsoft.EntityFrameworkCore;
using PlayerWallet.BL.Interfaces;
using PlayerWallet.BL.Model;
using PlayerWallet.DAL.DatabasesContext;
using PlayerWallet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerWallet.BL.Repository
{
    public class PlayerRepository : GenericRepository<PlayerDTO>, IPlayerRepository
    {
        private readonly PlayerDbContext _playerDbContext;


        public PlayerRepository(PlayerDbContext playerDbContext) : base(playerDbContext)
        {
            _playerDbContext = playerDbContext;
        }

        public IEnumerable<PlayerWalletDTO> GetPlayerWallet()
        {
            var result = _playerDbContext.PlayerWalletBalance.ToList();
            return result;
        }

        public override IEnumerable<PlayerDTO> Get()
        {
            var result = _playerDbContext.PlayerDetails.Include(x=>x.PlayerWalletDetails).ToList();
            return result;
        }
    }
}
