using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Model
{
    internal class AccessPoint
    {
        private int _accesPointID;
        private string _name;
        
        public int AccesPointID {  get { return _accesPointID; } set { _accesPointID = value; } }
        public string Name { get { return _name; } set { _name = value; } } 
        public AccessPoint(int accesPointId, string name ) {
            AccesPointID = accesPointId;
            Name = name;
        }
    }
}
