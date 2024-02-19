using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Services
{
    class AuthenticationService:IAuthenticationService
    {
        public async Task Login(string username, string password)
        {
            await Task.Delay(5000);
        }
    }
}
