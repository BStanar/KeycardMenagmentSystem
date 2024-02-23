using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Model
{
    public class Keycard
    {
        private int _keycardID;
        private string _serialCode;
        private int _userId;
        private bool _activated;


        public int KeycardID { get { return _keycardID; } set { _keycardID = value; } }
        public string SerialCode { get { return _serialCode; } set { _serialCode = value; } }
        public int UserId { get { return _userId; } set { _userId = value; } }
        public bool Activated { get { return _activated; } set { _activated = value; } }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Keycard(int keycardID, string serialCode, int idUser)
        {
            _activated = false;
            KeycardID = keycardID;
            SerialCode = serialCode;
            _userId = idUser;
        }
        public Keycard(string serialCode, int idUser, bool activated)
        {
            _activated = activated;
            SerialCode = serialCode;
            _userId = idUser;
        }
        public Keycard(string serialCode)
        {
            _activated = false;
            SerialCode = serialCode;
        }
        public Keycard(int keycardID, string serialCode, int userId, bool activated, string firstname, string lastname)
        {
            KeycardID = keycardID;
            SerialCode = serialCode;
            UserId = userId;
            Activated = activated;
            Firstname = firstname;
            Lastname = lastname;
        }


    }

}

