using KeycardMenagmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Services
{
    public interface IAuthenticationService
    {
        public Task<Users> Login(string username, string password);
    }
}
