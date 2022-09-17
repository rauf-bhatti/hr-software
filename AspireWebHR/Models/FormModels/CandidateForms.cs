using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models.FormModels
{
    class CandidateForms : FormModel
    {
        public int CandidateID { get; set; }

        public CandidateForms() : base() { }
        public CandidateForms(int CandidateID, string FilePath, string FormName) : base(FilePath, FormName) { this.CandidateID = CandidateID; }
        public CandidateForms(int CandidateID, int FormID, string FilePath, string FormName) : base(FormID, FilePath, FormName) { this.CandidateID = CandidateID; }

        public override string QueryizeInsert()
        {
            return $"INSERT INTO CandidateForms (CandidateID, PathToFile, FileName) VALUES ('{this.CandidateID}', '{base.FilePath}', '{base.FileName}');";
        }

        public override string QueryizeDelete()
        {
            return $"DELETE FROM CandidateForms WHERE FormID = {base.FormID}";
        }

    }
}
