using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Model
{
    public class Person
    {
        private int _id;
        private string _lastName;
        private string _email;
        private string _firstName;
        private string _password;
        private string _username;
        private DateTime _startOfEmployment;


        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string Lastname { get { return _lastName; } set { _lastName = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public int ID { get { return _id; } }
        public string Password { get { return _password; } }
        public string Username { get { return _username; } }

        public DateTime StartOfEmployment
        {
            get { return _startOfEmployment; }
        }

        /*Konstruktor za menadzera*/
        public Person(int id, string firstName, string lastName, string email, string password, string username) {
            FirstName = firstName;
            Lastname = lastName;
            Email = email;
            this._id = id;
            this._password = password;
            this._username = username;
        }
        /*Konstruktor za emplyee*/
        public Person(int id, string firstName, string lastName, string email, string password, string username, DateTime startOfEmployment)
        {
            FirstName = firstName;
            Lastname = lastName;
            Email = email;
            this._id = id;
            this._password = password;
            this._username = username;
            this._startOfEmployment = startOfEmployment;
            
        }
    }
}
