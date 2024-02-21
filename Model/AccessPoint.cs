using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Model
{
    public class AccessPoint
    {
        private int _accesPointID;
        private string _name;
        private string _serial;
        
        public int AccesPointID {  get { return _accesPointID; } set { _accesPointID = value; } }
        public string Name { get { return _name; } set { _name = value; } } 
        public string Serial { get { return _serial; } set { _serial = value; } }
        public AccessPoint(int accesPointId, string name,string serial ) {
            AccesPointID = accesPointId;
            Name = name;
            Serial = serial;
        }

    }
}
