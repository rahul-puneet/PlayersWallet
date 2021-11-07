using PlayerWallet.BL.Interfaces;
using PlayerWallet.BL.Repository;
using PlayerWallet.DAL.DatabasesContext;
using System;
using System.Collections.Generic;
using System.Text;


namespace PlayerWallet.BL
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly PlayerDbContext _playerDbContext;

        private IPlayerRepository _playerRepository = null;
        private IPlayerWalletRepository _playerWalletRepository = null;


        public UnityOfWork(PlayerDbContext playerDbContext)
        {
            _playerDbContext = playerDbContext;
        }

        public IPlayerWalletRepository PlayerWalletRepository
        {
            get
            {
                if (_playerWalletRepository == null)
                {
                    _playerWalletRepository = new PlayerWalletRepository(_playerDbContext);
                }
                return _playerWalletRepository;
            }
        }

        public IPlayerRepository PlayerRepository
        {
            get
            {
                if (_playerRepository == null)
                {
                    _playerRepository = new PlayerRepository(_playerDbContext);
                }
                return _playerRepository;
            }
        }


        public void Commit()
        {
            _playerDbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_playerDbContext != null)
            {
                _playerDbContext.Dispose();
            }
        }

    }
}
