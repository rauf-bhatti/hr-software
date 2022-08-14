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
using AspireWebHR.Controllers;

namespace AspireWebHR.Views.MiscViews
{
    /// <summary>
    /// Interaction logic for EditJobOpening.xaml
    /// </summary>
    public partial class EditJobOpening : Window
    {
        private JobOpeningController jobOpeningController = new JobOpeningController();
        private JobOpeningModel openingInstance = new JobOpeningModel();

        public EditJobOpening()
        {
            InitializeComponent();
        }

        public EditJobOpening(JobOpeningModel jobInstance)
        {
            InitializeComponent();
            InitializeValues(jobInstance);
        }

        public void InitializeValues(JobOpeningModel jobInstance)
        {
            this.openingInstance = jobInstance;


            datePicker_postDate.SelectedDate = jobInstance.DatePosted;
            txtBox_CompanyName.Text = jobInstance.CompanyName;
            txtBox_ClientName.Text = jobInstance.ClientName;
            txtBox_JobLocation.Text = jobInstance.JobLocation;
            txtBox_InterviewLocation.Text = jobInstance.InterviewLocation;
            txtBox_ClientContact.Text = jobInstance.ClientContact;
            txtBox_Vacancy.Text = jobInstance.Vacancy.ToString();
            txtBox_Role.Text = jobInstance.Role;
            txtBox_SalaryRange.Text = jobInstance.SalaryRange.ToString();
            txtBox_Experience.Text = jobInstance.Experience;
            txtBox_WorkingHours.Text = jobInstance.WorkingHours.ToString();
            txtBox_WorkingDays.Text = jobInstance.WorkingDays.ToString();
            txtBox_WeeklyOff.Text = jobInstance.WeeklyOff.ToString();
            txtBox_Nationality.Text = jobInstance.Nationality;


            //Indentation of three related characters done so that FindName can be used correctly. The names of respective ComboBox are changed in the 
            //- corresponding XAML file too.
            cbBox_ArabicSpeaker.SelectedItem = cbBox_ArabicSpeaker.FindName($"ara{jobInstance.ArabicSpeaker}");
            cbBox_Accomodation.SelectedItem = cbBox_Accomodation.FindName($"acc{jobInstance.ArabicSpeaker}");
            cbBox_Meals.SelectedItem = cbBox_Meals.FindName($"mea{jobInstance.Meals}");
            cbBox_Transport.SelectedItem = cbBox_Transport.FindName($"tra{jobInstance.Transport}");

            cbBox_InOut.SelectedItem = cbBox_InOut.FindName(jobInstance.INOUT);
            cbBox_Gender.SelectedItem = cbBox_Gender.FindName(jobInstance.Gender);
        }

        private void btn_ModifyJobOpening_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem gender = (ComboBoxItem)cbBox_Gender.SelectedItem;
            ComboBoxItem inout = (ComboBoxItem)cbBox_InOut.SelectedItem;


            ComboBoxItem accomodation = (ComboBoxItem)cbBox_Accomodation.SelectedItem;
            ComboBoxItem arabicSpeaker = (ComboBoxItem)cbBox_ArabicSpeaker.SelectedItem;
            ComboBoxItem meals = (ComboBoxItem)cbBox_Meals.SelectedItem;
            ComboBoxItem transport = (ComboBoxItem)cbBox_Transport.SelectedItem;


            if (jobOpeningController.ModifyJobOpening(openingInstance.OpeningID, (DateTime)datePicker_postDate.SelectedDate, txtBox_CompanyName.Text, txtBox_ClientName.Text, txtBox_JobLocation.Text, txtBox_InterviewLocation.Text,
                RuntimeController.RecruiterID, txtBox_ClientContact.Text, Convert.ToInt32(txtBox_Vacancy.Text), txtBox_Role.Text, Convert.ToInt32(txtBox_SalaryRange.Text), txtBox_Experience.Text,
                Convert.ToInt32(txtBox_WorkingHours.Text), Convert.ToInt32(txtBox_WorkingDays.Text), Convert.ToInt32(txtBox_WeeklyOff.Text), gender.Content.ToString(),
                txtBox_Nationality.Text, Convert.ToBoolean(arabicSpeaker.Content), Convert.ToBoolean(accomodation.Content), Convert.ToBoolean(transport.Content),
                Convert.ToBoolean(meals.Content), inout.Content.ToString(), "Active", 0) == 1)
            {
                MessageBox.Show("Record Successfully Modified.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Record could not be modified. Please try again.");
            }
        }

        private void btn_Complete_Click(object sender, RoutedEventArgs e)
        {
            AmountDialog amountDialog = new AmountDialog();
            amountDialog.ShowDialog();

            if (JobOpeningController.interAmountPaid > 0)
            {
                if (this.jobOpeningController.ModifyJobOpening(this.openingInstance.QueryizeStatusUpdate(JobOpeningController.interAmountPaid, "Completed")) == 1)
                {
                    MessageBox.Show("Status successfully updated!");
                    JobOpeningController.interAmountPaid = -1; //Reset the value of the intermediate amount paid.
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Error updating status!");
                }
            }
        }

        
    }
}
