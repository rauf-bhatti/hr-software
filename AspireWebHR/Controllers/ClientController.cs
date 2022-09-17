using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Models;

namespace AspireWebHR.Controllers
{
    class ClientController : Controller
    {
        public int InsertClient(string ClientName)
        {
            ClientModel client = new ClientModel(ClientName);

            try
            {
                return dbInstance.RunInsertionQuery(client.QueryizeInsert());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClientModel> GetClients()
        {
            List<ClientModel> clients = new List<ClientModel>();

            try
            {
                dynamic dataReader = dbInstance.RunReceiveQuery("SELECT * FROM Clients", 1);

                while (dataReader.Read())
                {
                    clients.Add(new ClientModel(dataReader["ClientID"], dataReader["ClientName"]));
                }

                return clients;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
