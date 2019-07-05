using ACM.BL;
using ACME.Common;
using System;
using System.Windows.Forms;

namespace ACM.Win
{
    public partial class OrderWin : Form
    {

        public OrderWin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlaceOrder();
        }

        private void PlaceOrder()
        {
            // Populate the customer instance
            Customer customer = new Customer();

            // Populate the order instance
            Order order = new Order();

            // Populate the payment info from the UI
            Payment payment = new Payment();

            OrderController orderController = new OrderController();
            orderController.PlaceOrder(customer, order, payment,
                allowSplitOrders: false,
                emailReceipt: true);
        }

    }
}