using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Model
{
    internal class Menager : Person
    {
        public string _role = "Menager";
        public Menager(int id, string lastName, string email, string firstName, string password, string username, DateTime startOfEmployment) 
            : base(id, lastName, email, firstName, password, username, startOfEmployment)
        {

        }
    }
}
