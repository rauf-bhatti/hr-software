using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models
{
    public class ClientModel
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }

        public ClientModel(string ClientName)
        {
            this.ClientName = ClientName;
        }

        public ClientModel(int ClientID, string ClientName)
        {
            this.ClientID = ClientID;
            this.ClientName = ClientName;
        }

        public string QueryizeInsert()
        {
            return $"INSERT INTO Clients (ClientName) VALUES ('{this.ClientName}');";
        }

    }
}
