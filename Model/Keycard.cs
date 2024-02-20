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

       
        public int KeycardID {  get { return _keycardID; } set { _keycardID = value; } }
        public string SerialCode { get { return _serialCode;} set { _serialCode = value; } }
        public int UserId { get{return _userId} set { _userId = value; } }

        public Keycard(int keycardID, string serialCode, int idUser)
        {
            KeycardID = keycardID;
            SerialCode = serialCode;
            _userId = idUser;
        }
    }
}
