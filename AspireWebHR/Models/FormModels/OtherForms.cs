using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models.FormModels
{
    class OtherForms : FormModel
    {
        public OtherForms() : base() { }
        public OtherForms(string FilePath, string FormName) : base(FilePath, FormName) { }
        public OtherForms(int FormID, string FilePath, string FormName) : base(FormID, FilePath, FormName) { }

        public override string QueryizeInsert()
        {
            return $"INSERT INTO OtherForms (PathToFile, FileName) VALUES ('{base.FilePath}', '{base.FileName}')";
        }

        public override string QueryizeDelete()
        {
            return $"DELETE FROM OtherForms WHERE FormID = {base.FormID}";
        }

    }
}
