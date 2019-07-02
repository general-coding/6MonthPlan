using System;
using System.Collections.Generic;

namespace ACM.BL
{
    public class ProductRepository
    {

        /// <summary>
        /// Retrieves one product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product Retrieve(int productId)
        {
            Product product = new Product(productId);

            if (productId == 2)
            {
                product.ProductName = "Sunflowers";
                product.Description = "It is a sunflower.";
                product.CurrentPrice = 20M;
            }

            object myObject = new object();
            Console.WriteLine($"Object: {myObject.ToString()}");
            Console.WriteLine($"Product: {product.ToString()}");

            return product;
        }

        /// <summary>
        /// Retrieves all the products
        /// </summary>
        /// <returns></returns>
        public List<Product> Retrieve()
        {
            return new List<Product>();
        }

        /// <summary>
        /// Saves the product
        /// </summary>
        /// <returns></returns>
        public bool Save(Product product)
        {
            var success = true;

            if (product.HasChanges)
            {
                if (product.IsValid)
                {
                    if (product.IsNew)
                    {
                        //Insert
                    }
                    else
                    {
                        //Update
                    }
                }
                else
                {
                    success = false;
                }
            }

            return success;
        }
    }
}
