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
            this.Hide();
            candidateView.Show();
            this.Show();
        }
    }
}
