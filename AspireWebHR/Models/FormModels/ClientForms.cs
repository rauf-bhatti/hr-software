using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models.FormModels
{
    public class ClientForms : FormModel
    {
        public int ClientID { get; set; }

        public ClientForms() : base() { }
        public ClientForms(int ClientID, string FilePath, string FormName) : base(FilePath, FormName) { this.ClientID = ClientID; }
        public ClientForms(int ClientID, int FormID, string FilePath, string FormName) : base(FormID, FilePath, FormName) { this.ClientID = ClientID; }

        public override string QueryizeInsert()
        {
            return $"INSERT INTO ClientForms (ClientID, PathToFile, FileName) VALUES ('{this.ClientID}', '{base.FilePath}', '{base.FileName}');";
        }

        public override string QueryizeDelete()
        {
            return $"DELETE FROM ClientForms WHERE FormID = {base.FormID}";
        }

    }
}
