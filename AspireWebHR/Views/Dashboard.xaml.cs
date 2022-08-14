﻿using System;
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

namespace AspireWebHR.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            InitializeName();
        }

        private void InitializeName()
        {
            this.lbl_HeaderName.Content = $"Welcome, {RuntimeController.RecruiterFullName}";
        }

        private void btn_addRecruiter_Click(object sender, RoutedEventArgs e)
        {
            RecruiterViews.AddRecruiterView recruiterView = new RecruiterViews.AddRecruiterView();
            this.Hide();
            recruiterView.Show();
            this.Show();
        }

        private void btn_addCandidate_Click(object sender, RoutedEventArgs e)
        {
            CandidateViews.AddCandidateView candidateView = new CandidateViews.AddCandidateView();
            candidateView.Show();
            this.Show();
        }

        private void btn_manageRecruiter_Click(object sender, RoutedEventArgs e)
        {
            RecruiterViews.ManageRecruiterView manageRecruiter = new RecruiterViews.ManageRecruiterView();
            manageRecruiter.Show();
            this.Show();
        }

        private void btn_ManageCandidates_Click(object sender, RoutedEventArgs e)
        {
            CandidateViews.ManageCandidateView manageCandidates = new CandidateViews.ManageCandidateView();
            manageCandidates.Show();
            this.Show();
        }

        private void btn_LeaveApplication_Click(object sender, RoutedEventArgs e)
        {
            RecruiterViews.LeaveApplication leaveApplication = new RecruiterViews.LeaveApplication();
            leaveApplication.Show();
            this.Show();
        }

        private void btn_LeaveApplicationManagement_Click(object sender, RoutedEventArgs e)
        {
            RecruiterViews.LeaveManagement leaveManagement = new RecruiterViews.LeaveManagement();
            leaveManagement.Show();
            this.Show();
        }

        private void btn_CurrentOpenings_Click(object sender, RoutedEventArgs e)
        {
            MiscViews.ViewOpenings viewOpenings = new MiscViews.ViewOpenings();
            viewOpenings.Show();
        }
    }
}
