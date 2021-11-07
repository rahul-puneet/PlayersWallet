using PlayerWallet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerWallet.BL.Interfaces
{
    public interface IPlayerRepository : IGenericRepository<PlayerDTO>
    {
        //Task<IQueryable<PlayerDTO>> GetPlayerById(Guid playerId);
        //Task<IQueryable<PlayerDTO>> GetPlayers();

        IEnumerable<PlayerWalletDTO> GetPlayerWallet();
    }
}
