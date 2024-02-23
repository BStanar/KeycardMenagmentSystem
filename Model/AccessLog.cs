using System;

namespace KeycardMenagmentSystem.Model
{
    public class AccessLog
    {
        public int LogID { get; private set; }
        public int AccessPointID { get; private set; }
        public int KeyCardID { get; private set; }
        public int UserID { get; private set; }
        public DateTime EventDate { get; private set; }
        private bool successful; // Backing field for Successful
        public int NumberOfScans { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }

        // Constructor
        public string AccessPointName { get; private set; }
        public string KeycardSerial { get; private set; }

        public bool Successful
        {
            get { return successful; }
            private set { successful = value; } // Make this private if you only set it in the constructor
        }

        // Read-only property to get textual representation of Successful
        public string AccessResult => Successful ? "Successful" : "Unsuccessful";

        public AccessLog(int logID, int accessPointID, string accessPointName, int keyCardID, string keycardSerial, int userID, DateTime eventDate, bool successful, int numberOfScans, string firstname, string lastname)
        {
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
