using System;
using System.Collections.Generic;
using AspireWebHR.Models;
using System.Text;

namespace AspireWebHR.Controllers
{
    class CandidateController : Controller
    {
        public bool AddCandidate(DateTime EntryDate, string FirstName, string MiddleName, string LastName, int Age, string MobileNumber, string EmailID,
            string MaritalStatus, string Nationality, string Address, DateTime BirthDate, string Gender, string ReferenceName, string c0, string j0, int s0, int d0, string r0,
            string c1, string j1, int s1, int d1, string r1, string c2, string j2, int s2, int d2, string r2, string c3, string j3, int s3, int d3, string r3)
        {

            List<ExperienceModel> experienceList = new List<ExperienceModel>();
            experienceList.Add(new ExperienceModel(c0, j0, s0, d0, r0));
            experienceList.Add(new ExperienceModel(c1, j1, s1, d1, r1));
            experienceList.Add(new ExperienceModel(c2, j2, s2, d2, r2));
            experienceList.Add(new ExperienceModel(c3, j3, s3, d3, r3));


            CandidateModel candidateInstance = new CandidateModel(EntryDate, FirstName, MiddleName, LastName, Age, MobileNumber, EmailID, MaritalStatus, Nationality,
                Address, BirthDate, Gender, ReferenceName, experienceList);


            

            return true;
        }
    }
}
