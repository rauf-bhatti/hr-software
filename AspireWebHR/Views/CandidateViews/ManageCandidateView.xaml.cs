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

namespace AspireWebHR.Views.CandidateViews
{
    /// <summary>
    /// Interaction logic for ManageCandidateView.xaml
    /// </summary>
    public partial class ManageCandidateView : Window
    {
        private RuntimeController runtimeController = new RuntimeController();

        private void BindDataToGrid()
        {
            this.listView_Main.ItemsSource = runtimeController.GetAllCandidates();
        }

        private void BindDataToGrid(string key)
        {
            this.listView_Main.ItemsSource = runtimeController.GetAllCandidatesByKey(key);
        }

        public ManageCandidateView()
        {
            InitializeComponent();
            BindDataToGrid();
        }

        private void txtBox_SearchCandidate_TextChanged(object sender, TextChangedEventArgs e)
        {
            BindDataToGrid(txtBox_SearchCandidate.Text);
        }

        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            BindDataToGrid();
        }

        private void listView_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = listView_Main.SelectedIndex;
            EditCandidate editRecruiter = new EditCandidate(RuntimeController.GetCandidateFromIndex(selectedIndex));
            editRecruiter.ShowDialog();
            BindDataToGrid();
        }
    }
}
