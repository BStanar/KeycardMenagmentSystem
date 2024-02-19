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
        
        private Employee _employee;

        public int KeycardID {  get { return _keycardID; } set { _keycardID = value; } }
        public string SerialCode { get { return _serialCode;} set { _serialCode = value; } }
        public Employee Employee { get { return _employee; } }
    }
}
