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

        public ViewOpenings()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            this.listView_Main.ItemsSource = jobController.GetAllJobOpenings();
        }

        private void ResetFields()
        {
            this.txtBox_OpeningTitle.Text = null;
            this.datePicker_activeDate.SelectedDate = null;
        }

        private void btn_SubmitJob_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (jobController.AddJobOpening(txtBox_OpeningTitle.Text, (DateTime)datePicker_activeDate.SelectedDate) == 1)
                {
                    MessageBox.Show("[Success] Job opening added.");
                    BindData();
                    ResetFields();
                }
                else
                {
                    MessageBox.Show("[Success] Job opening could not be added.");
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
        }
    }
}
