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

namespace AspireWebHR.Views.RecruiterViews
{
    /// <summary>
    /// Interaction logic for LeaveManagement.xaml
    /// </summary>
    public partial class LeaveManagement : Window
    {
        private LeaveController leaveController = new LeaveController();

        private void BindDataToGrid()
        {
            this.listView_Main.ItemsSource = leaveController.GetAllLeaves();
        }


        public LeaveManagement()
        {
            InitializeComponent();
            BindDataToGrid();
        }

        private void ListView_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = this.listView_Main.SelectedIndex;
            dynamic x = this.listView_Main.SelectedItem;
            LeaveDialog leaveDialog = new LeaveDialog(x);
            leaveDialog.ShowDialog();

            BindDataToGrid();
        }
    }
}
