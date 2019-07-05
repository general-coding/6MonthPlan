using ACME.Common;

namespace ACM.BL
{
    public class Product : EntityBase, ILoggable
    {
        public Product()
        {

        }

        public Product(int productId)
        {
            ProductID = productId;
        }

        public int ProductID { get; private set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal? CurrentPrice { get; set; }

        /// <summary>
        /// Validates the product
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrEmpty(ProductName)) isValid = false;
            if (CurrentPrice == null) isValid = false;

            return isValid;
        }

        public override string ToString()
        {
            return ProductName;
        }

        public string Log()
        {
            return "This is a product";
        }
    }
}
