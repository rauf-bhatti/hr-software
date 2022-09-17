using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models
{
    public class NotificationModel
    {
        public int NotificationID { get; set; }
        public string NotificationText { get; set; }
        public string RecipientID { get; set; }

        public NotificationModel(string NotificationText, string RecipientID)
        {
            this.NotificationText = NotificationText;
            this.RecipientID = RecipientID;
        }

        public NotificationModel(int NotificationID, string NotificationText, string RecipientID)
        {
            this.NotificationID = NotificationID;
            this.NotificationText = NotificationText;
            this.RecipientID = RecipientID;
        }

        public string InsertNotification()
        {
            return $"INSERT INTO Notifications (NotificationText, RecipientID) VALUES ('{NotificationText}', '{RecipientID}')";
        }
    }
}
