using PlayerWallet.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerWallet.BL
{
    public interface IUnityOfWork
    {
        IPlayerRepository playerRepository { get; }
        void Commit();
        void Dispose();

    }
}
