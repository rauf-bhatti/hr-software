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
    /// Interaction logic for ManageRecruiterView.xaml
    /// </summary>
    public partial class ManageRecruiterView : Window
    {
        private RecruiterController recruiterController = new RecruiterController();
        private RuntimeController runtimeController = new RuntimeController();


        private void BindDataToGrid()
        {
            this.listView_Main.ItemsSource = runtimeController.GetAllRecruiters();
        }

        private void BindDataToGrid(string key)
        {
            this.listView_Main.ItemsSource = runtimeController.GetAllRecruitersByKey(key);
        }

        public ManageRecruiterView()
        {
            InitializeComponent();
            BindDataToGrid();
        }

        private void txtBox_SearchEmployee_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBox_SearchEmployee.Text.Equals(""))
            {
                BindDataToGrid();
                return;
            }

            BindDataToGrid(txtBox_SearchEmployee.Text);
        }
    }
}
