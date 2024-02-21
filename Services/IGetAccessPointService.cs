using KeycardMenagmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Services
{
    internal interface IGetAccessPointService
    {
        public Task<List<AccessPoint>> GetAccesPoints();
    }
}
