using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AspireWebHR.Models;

namespace AspireWebHR.Views.CandidateViews
{
    /// <summary>
    /// Interaction logic for EditCandidate.xaml
    /// </summary>
    public partial class EditCandidate : Window
    {
        public EditCandidate()
        {
            InitializeComponent();
        }

        public EditCandidate(CandidateModel candidateInstance)
        {
            InitializeComponent();
            InitializeValues(candidateInstance);
        }

        public void InitializeValues(CandidateModel candidateInstance)
        {

            datePicker_EntryDate.SelectedDate = candidateInstance.EntryDate;
            txtBox_FirstName.Text = candidateInstance.FirstName;
            txtBox_MiddleName.Text = candidateInstance.MiddleName;
            txtBox_LastName.Text = candidateInstance.LastName;
            txtBox_Age.Text = candidateInstance.Age.ToString();
            txtBox_MobileNumber.Text = candidateInstance.MobileNumber;
            txtBox_EmailID.Text = candidateInstance.EmailID;
            cbBox_MaritalStatus.SelectedItem = cbBox_MaritalStatus.FindName(candidateInstance.MaritalStatus);
            txtBox_Nationality.Text = candidateInstance.Nationality;
            txtBox_Address.Text = candidateInstance.Address;
            datePicker_BirthDate.SelectedDate = candidateInstance.Birthdate;
            cbBox_Gender.SelectedItem = cbBox_Gender.FindName(candidateInstance.Gender);
            txtBox_ReferenceName.Text = candidateInstance.ReferenceName;

            int expLength = candidateInstance.GetExperienceLength();
            int localCount = 0;

            if (expLength > 0)
            {
                if (localCount <= expLength)
                {
                    txtBox_C0.Text = candidateInstance.CandidateExperience[0].CompanyName;
                    txtBox_J0.Text = candidateInstance.CandidateExperience[0].JobTitle;
                    txtBox_S0.Text = candidateInstance.CandidateExperience[0].Salary.ToString();
                    txtBox_D0.Text = candidateInstance.CandidateExperience[0].Duration.ToString();
                    txtBox_R0.Text = candidateInstance.CandidateExperience[0].LeavingReason;
                    localCount++;
                }

                else if (localCount <= expLength)
                {
                    txtBox_C1.Text = candidateInstance.CandidateExperience[1].CompanyName;
                    txtBox_J1.Text = candidateInstance.CandidateExperience[1].JobTitle;
                    txtBox_S1.Text = candidateInstance.CandidateExperience[1].Salary.ToString();
                    txtBox_D1.Text = candidateInstance.CandidateExperience[1].Duration.ToString();
                    txtBox_R1.Text = candidateInstance.CandidateExperience[1].LeavingReason;
                    localCount++;
                }
                else if (localCount <= expLength)
                {
                    txtBox_C2.Text = candidateInstance.CandidateExperience[2].CompanyName;
                    txtBox_J2.Text = candidateInstance.CandidateExperience[2].JobTitle;
                    txtBox_S2.Text = candidateInstance.CandidateExperience[2].Salary.ToString();
                    txtBox_D2.Text = candidateInstance.CandidateExperience[2].Duration.ToString();
                    txtBox_R2.Text = candidateInstance.CandidateExperience[2].LeavingReason;
                    localCount++;
                }
                else if (localCount <= expLength)
                {
                    txtBox_C3.Text = candidateInstance.CandidateExperience[3].CompanyName;
                    txtBox_J3.Text = candidateInstance.CandidateExperience[3].JobTitle;
                    txtBox_S3.Text = candidateInstance.CandidateExperience[3].Salary.ToString();
                    txtBox_D3.Text = candidateInstance.CandidateExperience[3].Duration.ToString();
                    txtBox_R3.Text = candidateInstance.CandidateExperience[3].LeavingReason;
                    localCount++;
                }
            }
        }
    }
}
