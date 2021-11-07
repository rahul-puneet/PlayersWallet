using AutoMapper;
using PlayerWallet.BL.Interfaces;
using PlayerWallet.BL.Model;
using PlayerWallet.DAL.Entities;
using System;
using System.Collections.Generic;
using NLog;

namespace PlayerWallet.BL.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public PlayerService(IUnityOfWork unityOfWork, IMapper mapper, ILoggerManager logger)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void CreatePlayer(PlayerModel player)
        {
            try
            {
                _unityOfWork.playerRepository.Add(_mapper.Map<PlayerDTO>(player));
                _unityOfWork.Commit();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while creating Player", ex);
                throw ex;
            }
            
        }

        public IEnumerable<PlayerModel> GetPlayers()
        {
            _logger.LogInfo($"Error while creating Player");
            _logger.LogWarn($"Error while creating Player");

            try
            {
                var result = _unityOfWork.playerRepository.Get();
                return _mapper.Map<List<PlayerModel>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in creating Player Method", ex);
            }
            return null;
        }

        public PlayerModel GetPlayerById(Guid playerId)
        {
            try
            {
                return _mapper.Map<PlayerModel>(_unityOfWork.playerRepository.GetByID(playerId));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetPlayerById Method ", ex);
            }
            return null;
        }

        public void DeletePlayer(Guid playerId)
        {
            try
            {
                _unityOfWork.playerRepository.Delete(playerId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Delete Method ", ex);
            }
        }

        public void UpdatePlayerDetails(PlayerModel player)
        {
            try
            {
               var updatedResult= _unityOfWork.playerRepository.Update(_mapper.Map<PlayerDTO>(player));
                _unityOfWork.Commit();
            }
             catch (Exception ex)
            {
                _logger.LogError($"Error in Update Player Details Method ", ex);
            }
        }

        public PlayerModel AddUpdateBalance(decimal balanceAmount, Guid playerId)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Add update Balance ", ex);
            }
            return null;
        }

        public PlayerModel StakeBalance(decimal balanceAmount, Guid playerId)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Stake Balance ", ex);
            }
            return null;
        }
    }
}
