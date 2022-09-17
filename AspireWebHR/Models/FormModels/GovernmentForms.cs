using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models.FormModels
{
    public class GovernmentForms : FormModel
    {
        public GovernmentForms() : base() { }
        public GovernmentForms(string FilePath, string FormName) : base(FilePath, FormName) { }
        public GovernmentForms(int FormID, string FilePath, string FormName) : base(FormID, FilePath, FormName) { }

        public override string QueryizeInsert()
        {
            return $"INSERT INTO GovernmentForms (PathToFile, FileName) VALUES ('{base.FilePath}', '{base.FileName}')";
        }

        public override string QueryizeDelete()
        {
            return $"DELETE FROM GovernmentForms WHERE FormID = {base.FormID}";
        }
    }
}
