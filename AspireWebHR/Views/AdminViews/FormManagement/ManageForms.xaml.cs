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
using AspireWebHR.Models.FormModels;
using AspireWebHR.Models;
using AspireWebHR.Controllers;

namespace AspireWebHR.Views.AdminViews.FormManagement
{
    /// <summary>
    /// Interaction logic for ManageForms.xaml
    /// </summary>
    public partial class ManageForms : Window
    {
        private int settingID; //Defines the forms to view.
        private ClientModel clientInstance;
        private RecruiterModel recruiterInstance;
        private CandidateModel candidateInstance;
        private RuntimeController runtimeController = new RuntimeController();



        private bool clientMode = false;
        private bool recruiterMode = false;
        private bool formsMode = false;
        private bool candidateMode = false;


        public ManageForms()
        {
            InitializeComponent();
        }

        public ManageForms(ClientModel clientInstance)
        {
            InitializeComponent();

            this.clientInstance = clientInstance;
            this.lbl_MainHeader.Content = clientInstance.ClientName;
            this.clientMode = true;
            BindData();
        }

        public ManageForms(RecruiterModel recruiterInstance)
        {
            InitializeComponent();

            this.recruiterInstance = recruiterInstance;
            this.lbl_MainHeader.Content = $"{recruiterInstance.FirstName} {recruiterInstance.MiddleName} {recruiterInstance.LastName}";
            this.recruiterMode = true;
            BindData();
        }


        public ManageForms(CandidateModel candidateInstance)
        {
            InitializeComponent();

            this.candidateInstance = candidateInstance;
            this.lbl_MainHeader.Content = $"{candidateInstance.FirstName} {candidateInstance.MiddleName} {candidateInstance.LastName}";
            this.candidateMode = true;
            BindData();
        }

        public ManageForms(int key)
        {
            InitializeComponent();
            this.formsMode = true;
            this.settingID = key;

            if (settingID == 1) //HRForms
            {
                lbl_MainHeader.Content = "Employee Files";
                this.Btn_AddForm.Visibility = Visibility.Hidden;
            }
            else if (settingID == 2) //GovernmentForms
            {
                lbl_MainHeader.Content = "Government Files";

            }
            else if (settingID == 3) //OtherForms
            {
                lbl_MainHeader.Content = "Other Files";
            }

            BindData();
        }


        private void BindData()
        {
            if (formsMode)
            {
                if (settingID == 1) //HRForms
                {
                    this.listView_Main.ItemsSource = runtimeController.GetEmployeeForms();
                }
                else if (settingID == 2) //GovernmentForms
                {
                    this.listView_Main.ItemsSource = runtimeController.GetGovernmentForms();

                }
                else if (settingID == 3) //OtherForms
                {
                    this.listView_Main.ItemsSource = runtimeController.GetOtherForms();
                }
            }
            else if (clientMode)
            {
                this.listView_Main.ItemsSource = runtimeController.GetClientForms(this.clientInstance.ClientID);
            }
            else if (recruiterMode)
            {
                this.listView_Main.ItemsSource = runtimeController.GetEmployeeForms(this.recruiterInstance.EmployeeID);
            }
            else if (candidateMode)
            {
                this.listView_Main.ItemsSource = runtimeController.GetCandidateForms(this.candidateInstance.CandidateID);
            }
        }

        

        private void Btn_AddForm_Click(object sender, RoutedEventArgs e)
        {
            AddForm addForm = null;

            if (formsMode)
            {
                if (settingID == 1) //HRForms
                {
                    addForm = new AddForm(new EmployeeForms());
                }
                else if (settingID == 2) //GovernmentForms
                {
                    addForm = new AddForm(new GovernmentForms());
                }
                else if (settingID == 3) //OtherForms
                {
                    addForm = new AddForm(new OtherForms());
                }
            }
            else if (clientMode)
            {
                addForm = new AddForm(new ClientForms(), clientInstance);
            }            
            else if (recruiterMode)
            {
                addForm = new AddForm(recruiterInstance);
            }
            else if (candidateMode)
            {
                addForm = new AddForm(candidateInstance);
            }

            if (addForm != null)
                addForm.ShowDialog();

            BindData();
        }

        private void txtBox_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (recruiterMode)
            {
                this.listView_Main.ItemsSource = runtimeController.GetEmployeeForms(recruiterInstance.EmployeeID, txtBox_Search.Text);
            }
            else if (clientMode)
            {
                this.listView_Main.ItemsSource = runtimeController.GetClientForms(clientInstance.ClientID, txtBox_Search.Text);
            }
            else if (formsMode)
            {
                if (settingID == 2)
                {
                    this.listView_Main.ItemsSource = runtimeController.GetGovernmentForms(txtBox_Search.Text);
                }
                else if (settingID == 3)
                {
                    this.listView_Main.ItemsSource = runtimeController.GetOtherForms(txtBox_Search.Text);
                }
            }
            else if (candidateMode)
            {
                this.listView_Main.ItemsSource = runtimeController.GetCandidateForms(candidateInstance.CandidateID, txtBox_Search.Text);

            }
        }

        private void Btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            txtBox_Search.Text = "";
            BindData();
        }

        private void listView_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = this.listView_Main.SelectedIndex;
            ActionPrompt actionPrompt = null;

            if (recruiterMode)
            {
                actionPrompt = new ActionPrompt(runtimeController.GetEmployeeFormFromIndex(selectedIndex));
            }
            else if (clientMode)
            {
                actionPrompt = new ActionPrompt(runtimeController.GetClientFormFromIndex(selectedIndex));
            }
            else if (formsMode)
            {
                if (settingID == 2)
                {
                    actionPrompt = new ActionPrompt(runtimeController.GetGovernmentFormFromIndex(selectedIndex));
                }
                else if (settingID == 3)
                {
                    actionPrompt = new ActionPrompt(runtimeController.GetOtherFormFromIndex(selectedIndex));
                }
            }
            else if (candidateMode)
            {
                actionPrompt = new ActionPrompt(runtimeController.GetCandidateFormFromIndex(selectedIndex));

            }

            actionPrompt.ShowDialog();
            BindData();
        }
    }
}
