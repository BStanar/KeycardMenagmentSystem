using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Model
{
    public class AccessLog // Assuming this is the correct class name
    {
        public int LogID { get; private set; }
        public int AccessPointID { get; private set; }
        public int KeyCardID { get; private set; }
        public int UserID { get; private set; }
        public DateTime EventDate { get; private set; }
        public bool Successful { get; private set; }
        public int NumberOfScans { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }

        // Constructor
        public string AccessPointName { get; private set; }
        public string KeycardSerial { get; private set; }

        public AccessLog(int logID, int accessPointID, string accessPointName, int keyCardID, string keycardSerial, int userID, DateTime eventDate, bool successful, int numberOfScans, string firstname, string lastname)
        {
            // Initialize all properties here
            LogID = logID;
            AccessPointID = accessPointID;
            AccessPointName = accessPointName;
            KeyCardID = keyCardID;
            KeycardSerial = keycardSerial;
            UserID = userID;
            EventDate = eventDate;
            Successful = successful;
            NumberOfScans = numberOfScans;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}


