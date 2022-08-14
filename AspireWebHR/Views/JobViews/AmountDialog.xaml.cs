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
    /// Interaction logic for AmountDialog.xaml
    /// </summary>
    public partial class AmountDialog : Window
    {
        public AmountDialog()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JobOpeningController.interAmountPaid = Convert.ToInt32(txtBox_AmountPaid.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error recording amount paid. Exception Message: {ex.Message}");
            }
        }
    }
}
