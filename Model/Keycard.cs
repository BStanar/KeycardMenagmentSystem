using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Model
{
    public class Keycard
    {
        public int KeycardID { get; set; }
        public string SerialCode { get; set; }
        public Employee Employee { get; set; }

        public Keycard(int keycardID, string serialCode, Employee emp)
        {
            KeycardID = keycardID;
            SerialCode = serialCode;
            Employee = emp;
        }
        
    }
}
