using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services
{
    public class LoginService
    {
        public static TokenDTO Login(string email, string pass)
        {
            var user = DataAccess.AuthData().Authenticate(email, pass);
            if (user != null)
            {
                var token = new Token();
                token.TokenKey = Guid.NewGuid().ToString();
                token.Email = user.Email;
                token.CreatedAt = DateTime.Now;
                token.ExpiredAt = null;
                var tk = DataAccess.TokensData().Add(token);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Token, TokenDTO>();
                });
                var mapper = new Mapper(config);
                var data = mapper.Map<TokenDTO>(tk);
                return data;
            }
            return null;
        }
        public static bool IsTokenValid(string token)
        {
            var tk = (from t in DataAccess.TokensData().Get()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      select t).SingleOrDefault();
            if (tk != null)
            {
                return true;
            }
            return false;
        }
    }
}
