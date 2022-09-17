using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models.FormModels
{
    public class FormModel
    {
        public int FormID { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }

        public FormModel() { }

        public FormModel(string FilePath, string FileName)
        {
            this.FileName = FileName;
            this.FilePath = FilePath;
        }

        public FormModel(int FormID, string FilePath, string FileName)
        {
            this.FormID = FormID;
            this.FilePath = FilePath;
            this.FileName = FileName;
        }

        public virtual string QueryizeInsert() { return ""; }
        public virtual string QueryizeDelete() { return ""; }

    }


}
