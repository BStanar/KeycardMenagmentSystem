using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Model
{
    internal class Keycard
    {
        private int _keycardID;
        private string _serialCode;
        private int _userId;

       
        public int KeycardID {  get { return _keycardID; } set { _keycardID = value; } }
        public string SerialCode { get { return _serialCode;} set { _serialCode = value; } }
    }
}
