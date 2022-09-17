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
using AspireWebHR.Models;

namespace AspireWebHR.Views.RecruiterViews
{
    /// <summary>
    /// Interaction logic for ManageDepartments.xaml
    /// </summary>
    public partial class ManageDepartments : Window
    {
        private DepartmentController departmentController = new DepartmentController();
        private RuntimeController runtimeController = new RuntimeController();
        
        public ManageDepartments()
        {
            InitializeComponent();
            BindDataToGrid();
        }

        private void BindDataToGrid()
        {
            this.txtBox_DepartmentName.Text = ""; //Reset Text

            this.listView_Main.ItemsSource = runtimeController.GetDepartments();
        }

        private void btn_AddDept_Click(object sender, RoutedEventArgs e)
        {

            if (txtBox_DepartmentName.Text.Length > 0)
            {
                if (departmentController.AddDepartment(txtBox_DepartmentName.Text) == 1)
                {
                    MessageBox.Show("[Success] Department added.");
                    BindDataToGrid();
                }
                else
                {
                    MessageBox.Show("[Error] Department could not be added.");
                }
            }

        }

        private void listView_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = listView_Main.SelectedIndex;
            DepartmentModel clickedInstance = runtimeController.GetDepartmentFromIndex(selectedIndex);

            if (clickedInstance == null)
            {
                return;
            }

            MessageBoxResult result = MessageBox.Show($"Do you want to delete department with ID: {clickedInstance.DepartmentID} and name: {clickedInstance.DepartmentName}?", "Delete Incentive", MessageBoxButton.YesNo);

            if (result.Equals(MessageBoxResult.Yes))
            {
                if (departmentController.DeleteDepartment(clickedInstance) == 1)
                {
                    MessageBox.Show("Entry deleted!");
                    BindDataToGrid();
                }
            }
            else
            {
                MessageBox.Show("Entry could not be deleted");
            }

        }
    }
}
