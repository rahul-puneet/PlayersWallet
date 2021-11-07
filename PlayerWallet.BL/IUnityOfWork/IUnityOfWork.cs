using PlayerWallet.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerWallet.BL
{
    public interface IUnityOfWork
    {
        IPlayerRepository PlayerRepository { get; }
        IPlayerWalletRepository PlayerWalletRepository { get; }
        void Commit();
        void Dispose();

    }
}
