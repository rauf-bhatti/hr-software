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
    /// Interaction logic for ViewOpenings.xaml
    /// </summary>
    public partial class ViewOpenings : Window
    {
        private JobOpeningController jobController = new JobOpeningController();
        private RuntimeController runtimeController = new RuntimeController();

        public ViewOpenings()
        {
            InitializeComponent();
            BindDataToGrid();
        }

        private void BindDataToGrid()
        {
            this.ChkBox_Active.IsChecked = false;
            this.ChkBox_Cancelled.IsChecked = false;
            this.ChkBox_Completed.IsChecked = false;


            this.listView_Main.ItemsSource = runtimeController.GetAllJobOpenings();
        }

        private void BindDataToGrid(string Status)
        {
            this.listView_Main.ItemsSource = runtimeController.GetAllJobOpenings(Status);
        }

        private void btn_AddJob_Click(object sender, RoutedEventArgs e)
        {
            AddJobOpening addJobOpening = new AddJobOpening();
            addJobOpening.ShowDialog();

            BindDataToGrid();
        }

        private void listView_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = listView_Main.SelectedIndex;
            EditJobOpening editJobOpening = new EditJobOpening(RuntimeController.GetOpeningFromIndex(selectedIndex));
            editJobOpening.ShowDialog();

            BindDataToGrid();
        }

        private void ChkBox_Completed_Checked(object sender, RoutedEventArgs e)
        {
            this.ChkBox_Active.IsChecked = false;
            this.ChkBox_Cancelled.IsChecked = false;
            this.ChkBox_Hold.IsChecked = false;

            BindDataToGrid("Completed");
        }

        private void ChkBox_Active_Checked(object sender, RoutedEventArgs e)
        {
            this.ChkBox_Completed.IsChecked = false;
            this.ChkBox_Cancelled.IsChecked = false;
            this.ChkBox_Hold.IsChecked = false;


            BindDataToGrid("Active");
        }

        private void ChkBox_Cancelled_Checked(object sender, RoutedEventArgs e)
        {
            this.ChkBox_Completed.IsChecked = false;
            this.ChkBox_Active.IsChecked = false;
            this.ChkBox_Hold.IsChecked = false;

            BindDataToGrid("Cancelled");
        }

        private void ChkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            BindDataToGrid();
        }

        private void ChkBox_Hold_Checked(object sender, RoutedEventArgs e)
        {
            this.ChkBox_Active.IsChecked = false;
            this.ChkBox_Cancelled.IsChecked = false;
            this.ChkBox_Completed.IsChecked = false;

            BindDataToGrid("Hold");
        }

    }
}
