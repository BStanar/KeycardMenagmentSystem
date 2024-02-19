using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Model
{
    internal class Log
    {
        private int _keyCardID ;
        private int _userID;
        private DateTime _dateOfAccess;
        private bool _succesfull=false;
        private int _numberOfScans=0;

        public int KeyCardID {  get { return _keyCardID; } }
        public int UserID { get { return _userID;} }
        public DateTime DateOfAccess { get { return _dateOfAccess; } }
        public bool Succesfull {  get { return _succesfull; } }
        public int NumberOfScans { get {  return _numberOfScans; } }

        public Log (int keyCardID, int userID, DateTime dateOfAccess, bool succesfull, int numberOfScans)
        {
            this._keyCardID = keyCardID;
            this._userID = userID;
            this._dateOfAccess = dateOfAccess;
            this._succesfull = succesfull;
            this._numberOfScans = numberOfScans;
        }
    }
}
