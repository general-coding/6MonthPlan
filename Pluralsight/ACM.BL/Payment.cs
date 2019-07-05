using System;
using System.ComponentModel;

namespace ACM.BL
{
    public enum PaymentType
    {
        CreditCard = 1,
        PayPal = 2
    }

    /// <summary>
    /// Manages a payment.
    /// </summary>
    public class Payment
    {
        public int PaymentType { get; set; }

        public void ProcessPayment(Payment payment)
        {
            if (!Enum.TryParse(payment.PaymentType.ToString(), out PaymentType paymentTypeOption))
            {
                throw new InvalidEnumArgumentException("Payment type", payment.PaymentType, typeof(PaymentType));
            }

            switch (paymentTypeOption)
            {
                case BL.PaymentType.CreditCard:
                    break;

                case BL.PaymentType.PayPal:
                    break;

                default:
                    throw new ArgumentException();
            }
        }
    }
}
