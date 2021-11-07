using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayerWallet.BL.Interfaces;
using PlayerWallet.BL.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlayerWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerDetailsController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerDetailsController(IPlayerService playerService )
        {
            _playerService = playerService;
        }


        [HttpGet]
        public IEnumerable<PlayerModel> Get()
        {
            return _playerService.GetPlayers();
        }

        [HttpGet("{playerId}")]
        public PlayerModel Get(Guid playerId)
        {
            return _playerService.GetPlayerById(playerId);
        }

        [HttpPost]
        public void Post([FromBody] PlayerModel player)
        {
            _playerService.CreatePlayer(player);
        }

        [HttpPut()]
        public void Put([FromBody] PlayerModel player)
        {
            _playerService.UpdatePlayerDetails(player);
        }

        [HttpDelete("{playerId}")]
        public void Delete(Guid playerId)
        {
            _playerService.DeletePlayer(playerId);
        }

        [HttpPost]
        [Route("AddBalance")]
        public PlayerModel AddBalance(Guid playerId, decimal amount)
        {
            return _playerService.AddUpdateBalance(amount, playerId);
        }

        [HttpPost]
        [Route("RemoveBalance")]
        public PlayerModel RemoveBalance(Guid playerId, decimal amount)
        {
            return _playerService.AddUpdateBalance(amount, playerId);
        }
    }

}
