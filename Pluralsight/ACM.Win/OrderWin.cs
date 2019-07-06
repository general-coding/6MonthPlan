using ACM.BL;
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
            if (sender is Button button)
            {
                button.Text = "Processing ...";
            }

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

            try
            {
                OrderController orderController = new OrderController();
                orderController.PlaceOrder(customer, order, payment,
                    allowSplitOrders: false,
                    emailReceipt: true);
            }
            catch (ArgumentNullException ex)
            {
                // log the issue
                // display a message to the user
                // that the order was not successful
            }
        }
    }
}