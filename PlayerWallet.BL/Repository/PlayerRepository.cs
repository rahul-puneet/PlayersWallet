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

        public override IEnumerable<PlayerDTO> Get()
        {
            return _playerDbContext.PlayerDetails.Include(x=>x.PlayerWalletDetails).ToList();
        }

        public override PlayerDTO GetByID(object Id)
        {
            return _playerDbContext.PlayerDetails.Include(x => x.PlayerWalletDetails).FirstOrDefault(p => p.RegistrationId == (Guid)Id);
        }
    }
}
