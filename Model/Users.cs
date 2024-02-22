using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Model
{
    public class Users
    {
        private int _id;
        private string _lastName;
        private string _email;
        private string _firstName;
        private string _password;
        private string _username;
        private DateTime _startOfEmployment;
        private string _role;

        public Users() { }
        public string FirstName { get { return _firstName; } 
            set 
            { 
                if(value!="")
                    _firstName = value; 
            } 
        }
        public string Lastname { get { return _lastName; } set { _lastName = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public int ID { get { return _id; } set { _id = value;} }
        public string Password { get { return _password; }  set { _password = value; } }
        public string Username { get { return _username; } set { _username = value; } }
        public string Role { get { return _role; }set { _role = value; } }

        public DateTime StartOfEmployment
        {
            get { return _startOfEmployment; } 
            set {  _startOfEmployment = value; }
        }

        public Users(int id, string username, string email, string password, string firstName, string lastName, DateTime startOfEmployment, string role)
        {
            FirstName = firstName;
            Lastname = lastName;
            Email = email;
            Role = role;
            this._id = id;
            this._password = password;
            this._username = username;
            this._startOfEmployment = startOfEmployment;
            
        }
    }
}
