using AutoMapper;
using PlayerWallet.BL.Model;
using PlayerWallet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerWallet.BL.CommonHelper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PlayerModel, PlayerDTO>().ReverseMap();
            CreateMap<PlayerWalletModel, PlayerWalletDTO>().ReverseMap();
        }
    }
}
