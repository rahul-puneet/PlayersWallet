using PlayerWallet.BL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerWallet.BL.Interfaces
{
    public interface IPlayerService
    {
        IEnumerable<PlayerModel> GetPlayers();

        PlayerModel GetPlayerById(Guid playerId);

        void CreatePlayer(PlayerModel player);
        void UpdatePlayerDetails(PlayerModel player);

        PlayerModel AddUpdateBalance(decimal balanceAmount, Guid playerId);
        PlayerModel StakeBalance(decimal balanceAmount, Guid playerId);
        
        void DeletePlayer(Guid playerId);
    }
}
