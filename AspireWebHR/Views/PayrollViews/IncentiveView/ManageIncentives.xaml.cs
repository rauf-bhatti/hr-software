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

namespace AspireWebHR.Views.PayrollViews.IncentiveView
{
    /// <summary>
    /// Interaction logic for ManageIncentives.xaml
    /// </summary>
    public partial class ManageIncentives : Window
    {
        private RecruiterModel recruiterInstance = new RecruiterModel();

        private RuntimeController runtimeController = new RuntimeController();
        private IncentivesController incentiveController = new IncentivesController();


        public ManageIncentives()
        {
            InitializeComponent();
        }

        public ManageIncentives(RecruiterModel recruiterInstance)
        {
            InitializeComponent();

            this.recruiterInstance = recruiterInstance;

            string fullName = $"{recruiterInstance.FirstName} {recruiterInstance.MiddleName} {recruiterInstance.LastName}";
            SetHeaderData(recruiterInstance.EmployeeID, fullName, recruiterInstance.Salary);

            BindDataToGridView();
        }

        private void SetHeaderData(string ID, string Name, int Salary)
        {
            this.Lbl_EmployeeID.Content += ID;
            this.Lbl_EmployeeName.Content += Name;
            this.Lbl_EmployeeSalary.Content += Salary.ToString();
        }

        private void BindDataToGridView()
        {
            this.listView_Main.ItemsSource = incentiveController.GetIncentives(recruiterInstance.EmployeeID);
        }

        private void Btn_AddIncentive_Click(object sender, RoutedEventArgs e)
        {
            IncentiveModel newIncentive = new IncentiveModel(recruiterInstance.EmployeeID, (DateTime) datePicker_Added.SelectedDate, Convert.ToInt32(txtBox_IncentivePerc.Text), false, false);
            if (incentiveController.AddIncentiveEntry(newIncentive) == 1)
            {
                MessageBox.Show("Incentive added.");
                BindDataToGridView();
            }
            else
            {
                MessageBox.Show("Incentive could not be added.");
            }
        }

        private void listView_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = listView_Main.SelectedIndex;
            IncentiveModel clickedInstance = runtimeController.GetSelectedIncentive(recruiterInstance.EmployeeID, selectedIndex);

            IncentiveDialog dialog = new IncentiveDialog(clickedInstance);
            dialog.ShowDialog();
            BindDataToGridView();
        }
    }
}
