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
using System.Threading;
using FluentFTP;

namespace AspireWebHR.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {

        private NotificationController notificationController = new NotificationController();
        private RuntimeController runtimeController = new RuntimeController();
        public Dashboard()
        {
            InitializeComponent();
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            this.lbl_HeaderName.Content = $"Welcome, {RuntimeController.RecruiterFullName}"; //Set the name

            //Configure what can and cannot be seen.

            if (RuntimeController.RecruiterLevel == 1)
            {
                this.btn_addRecruiter.Visibility = Visibility.Hidden;
                this.Btn_ManageDepartment.Visibility = Visibility.Hidden;
            }
            UpdateNotifications();

        }

        private void UpdateNotifications()
        {
            this.listView_Main.ItemsSource = notificationController.GetNotifications(RuntimeController.RecruiterID);
        }

        private void btn_addRecruiter_Click(object sender, RoutedEventArgs e)
        {
            RecruiterViews.AddRecruiterView recruiterView = new RecruiterViews.AddRecruiterView();
            recruiterView.ShowDialog();
            UpdateNotifications();
        }

        private void btn_addCandidate_Click(object sender, RoutedEventArgs e)
        {
            CandidateViews.AddCandidateView candidateView = new CandidateViews.AddCandidateView();
            candidateView.ShowDialog();
            UpdateNotifications();
        }

        private void btn_manageRecruiter_Click(object sender, RoutedEventArgs e)
        {
            if (RuntimeController.RecruiterLevel == 2)
            {
                this.btn_manageRecruiter.Content = "View Recruiters";
                RecruiterViews.ManageRecruiterView manageRecruiter = new RecruiterViews.ManageRecruiterView();
                manageRecruiter.ShowDialog();
            }
            else
            {
                this.btn_manageRecruiter.Content = "View Forms";
                AdminViews.FormManagement.ManageForms manageForms = new AdminViews.FormManagement.ManageForms(runtimeController.GetRecruiterFromID(RuntimeController.RecruiterID));
                manageForms.ShowDialog();
            }
            
            UpdateNotifications();
        }

        private void btn_ManageCandidates_Click(object sender, RoutedEventArgs e)
        {
            CandidateViews.ManageCandidateView manageCandidates = new CandidateViews.ManageCandidateView();
            manageCandidates.ShowDialog();
            UpdateNotifications();
        }

        private void btn_LeaveApplication_Click(object sender, RoutedEventArgs e)
        {
            RecruiterViews.LeaveApplication leaveApplication = new RecruiterViews.LeaveApplication();
            leaveApplication.ShowDialog();
            UpdateNotifications();
        }

        private void btn_LeaveApplicationManagement_Click(object sender, RoutedEventArgs e)
        {
            RecruiterViews.LeaveManagement leaveManagement = new RecruiterViews.LeaveManagement();
            leaveManagement.ShowDialog();
            UpdateNotifications();
        }

        private void btn_CurrentOpenings_Click(object sender, RoutedEventArgs e)
        {
            MiscViews.ViewOpenings viewOpenings = new MiscViews.ViewOpenings();
            viewOpenings.ShowDialog();
            UpdateNotifications();
        }

        private void Btn_ManageDepartment_Click(object sender, RoutedEventArgs e)
        {
            RecruiterViews.ManageDepartments manageDepts = new RecruiterViews.ManageDepartments();
            manageDepts.ShowDialog();
            UpdateNotifications();
        }

        private void Btn_Settings_Click(object sender, RoutedEventArgs e)
        {
            RecruiterViews.ChangePassword changePass = new RecruiterViews.ChangePassword(true);
            changePass.ShowDialog();
            UpdateNotifications();
        }

        private void Btn_ManageForms_Click(object sender, RoutedEventArgs e)
        {
            AdminViews.FormManagement.FormDashboard formsDashboard = new AdminViews.FormManagement.FormDashboard();
            formsDashboard.ShowDialog();
            UpdateNotifications();
        }
    }
}