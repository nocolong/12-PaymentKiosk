using PaymentKiosk.Core;
using PaymentKiosk.Core.Service;
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

namespace _12_PaymentKiosk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void buttonChargeCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer
            {
                Name = textBoxCustomerName.Text,
                Phone = textBoxCustomerPhone.Text,


            };
            var creditCard = new CreditCard
            {
                CardNumber = textBoxCreditCardNuber.Text,
                Cvc = textBoxSecurityCode.Text,
                ExpiryDate = DateTime.Parse(textBoxExpiryDate.Text)
            };

            try {
                bool success = MoneyService.Charge(customer, creditCard, decimal.Parse(textBoxChargeAmount.Text));
                if (success)
                {
                    MessageBox.Show("Payment Successful");
                }
                else
                {
                    MessageBox.Show("Payment not Successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
