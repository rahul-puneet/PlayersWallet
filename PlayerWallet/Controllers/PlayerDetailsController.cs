﻿using System;
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

        [HttpGet("{id}")]
        public PlayerModel Get(Guid playerGuid)
        {
            return _playerService.GetPlayerById(playerGuid);
        }

        [HttpPost]
        public void Post([FromBody] PlayerModel player)
        {
            _playerService.CreatePlayer(player);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(Guid playerId)
        {
            _playerService.DeletePlayer(playerId);
        }
    }
}
