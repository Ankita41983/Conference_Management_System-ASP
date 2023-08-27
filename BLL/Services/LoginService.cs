using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LoginService
    {
        public static object Authenticate(LoginDTO login)
        {
            var mapper = MapperService<LoginDTO, Login>.GetMapper();
            var map = mapper.Map<Login>(login);
            return DataAccess.LoginData().Authenticate(map);
        }
    }
}
