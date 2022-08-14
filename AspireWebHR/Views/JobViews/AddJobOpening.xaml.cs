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
using AspireWebHR.Controllers;

namespace AspireWebHR.Views.MiscViews
{
    /// <summary>
    /// Interaction logic for AddJobOpening.xaml
    /// </summary>
    public partial class AddJobOpening : Window
    {
        private JobOpeningController jobController = new JobOpeningController();

        public AddJobOpening()
        {
            InitializeComponent();
        }

        private void btn_SubmitRecruiter_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem gender = (ComboBoxItem)cbBox_Gender.SelectedItem;
            ComboBoxItem inout = (ComboBoxItem)cbBox_InOut.SelectedItem;


            ComboBoxItem accomodation = (ComboBoxItem)cbBox_Accomodation.SelectedItem;
            ComboBoxItem arabicSpeaker = (ComboBoxItem)cbBox_ArabicSpeaker.SelectedItem;
            ComboBoxItem meals = (ComboBoxItem)cbBox_Meals.SelectedItem;
            ComboBoxItem transport = (ComboBoxItem)cbBox_Transport.SelectedItem;



            if (jobController.AddJobOpening((DateTime)datePicker_postDate.SelectedDate, txtBox_CompanyName.Text, txtBox_ClientName.Text, txtBox_JobLocation.Text, txtBox_InterviewLocation.Text,
                RuntimeController.RecruiterID, txtBox_ClientContact.Text, Convert.ToInt32(txtBox_Vacancy.Text), txtBox_Role.Text, Convert.ToInt32(txtBox_SalaryRange.Text), txtBox_Experience.Text,
                Convert.ToInt32(txtBox_WorkingHours.Text), Convert.ToInt32(txtBox_WorkingDays.Text), Convert.ToInt32(txtBox_WeeklyOff.Text), gender.Content.ToString(),
                txtBox_Nationality.Text, Convert.ToBoolean(arabicSpeaker.Content), Convert.ToBoolean(accomodation.Content), Convert.ToBoolean(transport.Content), Convert.ToBoolean(meals.Content), inout.Content.ToString(), "Active", 0) == 1)
            {
                MessageBox.Show("Successfully inserted record!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error inserting record!");
            }
        }
    }
}
