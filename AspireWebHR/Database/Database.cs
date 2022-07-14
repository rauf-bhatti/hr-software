using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace AspireWebHR.Database
{
    public class Database
    {
        private NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);

        private void ResetConnection()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            else
            {
                connection.Close();
                connection.Open();
            }
        }

        public dynamic RunValidationQuery(string query)
        {
            dynamic resultToReturn;
            try
            {
                ResetConnection();

                NpgsqlCommand _cmd = new NpgsqlCommand(query, connection);

                resultToReturn = _cmd.ExecuteScalar();

                connection.Close();
                return resultToReturn;
            }
            catch (NpgsqlException e)
            {
                connection.Close();
                return e.ErrorCode;
            }

        }

        public dynamic RunModificationQuery(string query)
        {
            dynamic resultToReturn;
            try
            {
                ResetConnection();

                NpgsqlCommand _cmd = new NpgsqlCommand(query, connection);

                resultToReturn = _cmd.ExecuteNonQuery();

                connection.Close();
                return resultToReturn;
            }
            catch (NpgsqlException e)
            {
                connection.Close();
                return e.ErrorCode;
            }

        }


        public dynamic RunDeletionQuery(string query)
        {
            dynamic resultToReturn;
            try
            {
                ResetConnection();

                NpgsqlCommand _cmd = new NpgsqlCommand(query, connection);

                resultToReturn = _cmd.ExecuteNonQuery();

                connection.Close();
                return resultToReturn;
            }
            catch (NpgsqlException e)
            {
                connection.Close();
                return e.ErrorCode;
            }

        }


        public dynamic RunReceiveQuery(string query, int flag) //Flag is set if the query is expected to return any value. Flag = 1 incase result expected, Flag = 0 if not.
        {
            try
            {
                ResetConnection();

                NpgsqlCommand _cmd = new NpgsqlCommand(query, connection);

                return _cmd.ExecuteReader();
            }
            catch (NpgsqlException e)
            {
                connection.Close();
                return e.ErrorCode;
            }

        }

        public dynamic RunInsertionQuery(string query)
        {
            dynamic resultToReturn;
            try
            {
                ResetConnection();

                NpgsqlCommand _cmd = new NpgsqlCommand(query, connection);

                resultToReturn = _cmd.ExecuteNonQuery();

                connection.Close();
                return resultToReturn;
            }
            catch (NpgsqlException e)
            {
                connection.Close();
                return e.ErrorCode;
            }
        }
    }
}
