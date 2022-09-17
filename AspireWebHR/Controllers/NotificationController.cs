using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Models;

namespace AspireWebHR.Controllers
{
    class NotificationController : Controller
    {
        public int AddNotification(string NotificationText, string RecipientID)
        {
            try
            {
                NotificationModel notification = new NotificationModel(NotificationText, RecipientID);
                return dbInstance.RunInsertionQuery(notification.InsertNotification());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NotificationModel> GetNotifications(string RecipientID)
        {
            try
            {
                dynamic dataReader = dbInstance.RunReceiveQuery($"SELECT * FROM Notifications WHERE RecipientID = '{RecipientID}'", 1);
                List<NotificationModel> notifications = new List<NotificationModel>();

                while (dataReader.Read())
                {
                    notifications.Add(new NotificationModel(dataReader["NotificationID"], dataReader["NotificationText"], dataReader["RecipientID"]));
                }

                return notifications;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
