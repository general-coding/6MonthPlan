using System.Collections.Generic;

namespace ACM.BL
{
    public class AddressRepository
    {
        /// <summary>
        /// Retrieve one customer
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public Address Retrieve(int addressId)
        {
            Address address = new Address(addressId);

            if (addressId == 1)
            {
                address.AddressType = 1;
                address.City = "Houston";
                address.Country = "USA";
                address.PostalCode = "77081";
                address.State = "Texas";
                address.StreetLine1 = "3701 Kirby Dr";
                address.StreetLine2 = "Ste 1133";
            }

            return address;
        }

        public IEnumerable<Address> RetrieveByCustomerId(int customerId)
        {
            var addressList = new List<Address>();

            Address address = new Address(1)
            {
                AddressType = 1,
                City = "Houston",
                Country = "USA",
                PostalCode = "77081",
                State = "Texas",
                StreetLine1 = "3701 Kirby Dr",
                StreetLine2 = "Ste 1133"
            };

            addressList.Add(address);

            address = new Address(2)
            {
                AddressType = 1,
                City = "Houston",
                Country = "USA",
                PostalCode = "77081",
                State = "Texas",
                StreetLine1 = "3701 Kirby Dr",
                StreetLine2 = "Ste 1133"
            };

            addressList.Add(address);

            return addressList;
        }

        /// <summary>
        /// Save the current customer
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return true;
        }
    }
}
