using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Model
{
    public class Employee : Person
    {
        private string _department;
        
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
        public Employee(int id, string lastName, string email, string firstName, string password, string username,
            DateTime startOfEmployment) : base(id, lastName, email, firstName, password, username, startOfEmployment)
        {
            

        }
    }
}
