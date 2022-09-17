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
    /// Interaction logic for IncentiveDialog.xaml
    /// </summary>
    public partial class IncentiveDialog : Window
    {
        private RuntimeController runtimeController = new RuntimeController();
        private IncentivesController incentiveController = new IncentivesController();
        private IncentiveModel incentiveInstance = new IncentiveModel();

        public IncentiveDialog()
        {
            InitializeComponent();
        }

        public IncentiveDialog(IncentiveModel clickedIncentive)
        {
            this.incentiveInstance = clickedIncentive;
            InitializeComponent();
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show($"Do you want to delete incentive with ID: {incentiveInstance.IncentiveID} for Employee: {incentiveInstance.EmployeeID}?", "Delete Incentive", MessageBoxButton.YesNo);

            if (result.Equals(MessageBoxResult.Yes))
            {
                if (incentiveController.DeleteIncentiveEntry(incentiveInstance) == 1)
                {
                    MessageBox.Show("Entry deleted!");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Entry could not be deleted");
                this.Close();
            }
        }

        private void Btn_UpdateClientStatus_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show($"Do you want to update client payment status of incentive with ID: {incentiveInstance.IncentiveID} for Employee: {incentiveInstance.EmployeeID} from {incentiveInstance.StatusClient} to {!incentiveInstance.StatusClient}?", "Update Client Payment", MessageBoxButton.YesNo);
            
            if (result.Equals(MessageBoxResult.Yes))
            {
                if (incentiveController.UpdatePaymentStatus(incentiveInstance, 1) == 1)
                {
                    MessageBox.Show("Incentive instance updated!");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Entry could not be updated");
                this.Close();
            }

        }

        private void Btn_UpdateAspireStatus_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show($"Do you want to update aspire web payment status of incentive with ID: {incentiveInstance.IncentiveID} for Employee: {incentiveInstance.EmployeeID} from {incentiveInstance.StatusClient} to {!incentiveInstance.StatusClient}?", "Update Client Payment", MessageBoxButton.YesNo);

            if (result.Equals(MessageBoxResult.Yes))
            {
                if (incentiveController.UpdatePaymentStatus(incentiveInstance, 2) == 1)
                {
                    MessageBox.Show("Incentive instance updated!");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Entry could not be updated");
                this.Close();
            }
        }
    }
}
