using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BMI_Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Customer
        {
            public string lastName { get; set; }
            public string firstName { get; set; }
            public string phoneNumber { get; set; }
            public int heightInches { get; set; }
            public int weightLbs { get; set; }
            public int custBMI { get; set; }
            public string statusTitle { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Part 1 of the Lab. ClearBtn & ExitBtn
        private void xClearBtn_Click(object sender, RoutedEventArgs e)
        {
            xPhoneBox.Text = "";
            xFirstNameBox.Text = "";
            xLastNameBox.Text = "";
            xHeightInchesBox.Text = "";
            xWeightLbsBox.Text = "";
        }

        private void xExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        #region The calculator and the message box to show info
        private void xSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Customer customer1 = new Customer();
            customer1.lastName = xLastNameBox.Text;
            customer1.firstName = xFirstNameBox.Text;
            customer1.phoneNumber = xPhoneBox.Text;

            int currentWeight = 0;
            int currentHeight = 0;
            Int32.TryParse(xWeightLbsBox.Text, out currentWeight);
            Int32.TryParse(xHeightInchesBox.Text, out currentHeight);
            customer1.heightInches = currentHeight;
            customer1.weightLbs = currentWeight;

            int bmi;
            bmi = 703 * customer1.weightLbs / (customer1.heightInches * customer1.heightInches);
            customer1.custBMI = bmi;

            string yourBMIStatus;

            xYourBMIResults.Text = ($"{bmi}");

            if(bmi < 18.5)
            {
                xBMIMessage.Text = ("According to CDC.gov BMI Calculator you are underweight.");
                customer1.statusTitle = "Underweight";
            }

            if (bmi < 18.5)
            {
                xBMIMessage.Text = ("According to CDC.gov BMI Calculator you have a normal body.");
                customer1.statusTitle = "Normal";
            }

            if (bmi < 18.5)
            {
                xBMIMessage.Text = ("According to CDC.gov BMI Calculator you are overweight.");
                customer1.statusTitle = "Overweight";
            }

            else
            {
                xBMIMessage.Text = ("According to CDC.gov BMI Calculator you are obese.");
                customer1.statusTitle = "Obese";
            }


            //MessageBox.Show($"The customer's name is {customer1.firstName} {customer1.lastName} and they ca be reached at {customer1.phoneNumber}. They are {customer1.heightInches} Tall. Their weight is {customer1.weightLbs}. Their BMI is {bmi}");

            
            #endregion


        }
    }
}
