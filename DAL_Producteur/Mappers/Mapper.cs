using DAL_Producteur.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Producteur.Mappers
{
    public static class Mapper
    {
        public static Customer convertCustomer(IDataRecord reader)
        {
            if (reader is null) throw new ArgumentNullException();
            return new Customer
            {
                Id = (int)reader[nameof(Customer.Id)],
                Lastname = (string)reader[nameof(Customer.Lastname)],
                Firstname = (string)reader[nameof(Customer.Firstname)],
                Email = (string)reader[nameof(Customer.Email)],
                Password = (string)reader[nameof(Customer.Password)],
                AddressId = (int)reader["AddressId"],
                IsAdmin = (bool)reader[nameof(Customer.IsAdmin)],
            };
        }
        public static Producer convertProducer(IDataRecord reader)
        {
            if (reader is null) throw new ArgumentNullException();
            return new Producer
            {
                Id = (int)reader[nameof(Producer.Id)],
                Lastname = (string)reader[nameof(Producer.Lastname)],
                Firstname =  (reader[nameof(Producer.Firstname)] is DBNull)? " " : (string)(reader[nameof(Producer.Firstname)]),
                Email = (string)reader[nameof(Producer.Email)],
                Password = (string)reader[nameof(Producer.Password)],
                AddressId= (int)reader["AddressId"],
            };
        }
        
        public static Product ConvertProduct(IDataRecord reader)
        {
            if (reader is null) throw new ArgumentNullException();
            return new Product
            {
                Id = (int)reader[nameof(Product.Id)],
                Name = (string)reader[nameof(Product.Name)],
                Description = (string)reader[nameof(Product.Description)],
                Quantity = (double)reader["Quantite"],
                ProducerID = (int)reader["ProducteurID"],
                Price=(double)reader[nameof(Product.Price)],
               
            };
        }
        public static Purchase ConvertPurchase(IDataRecord reader)
        {
            if (reader is null) throw new ArgumentNullException();
            return new Purchase
            {
                Id= (int)reader[nameof(Purchase.Id)],
                Date=(DateTime)reader[nameof(Purchase.Date)],
                CustomerId = (int)reader[nameof(Purchase.CustomerId)],
                ProductId = (int)reader[nameof(Purchase.ProductId)],
                Quantity=(double)reader[nameof(Purchase.Quantity)], 
            };
        }
        public static Address ConvertAddress(IDataRecord reader)
        {
            if (reader is null) return null;
            return new Address
            {
                Rue = (string)reader["rue"],
                Numero = (string)reader["numero"],
                CodePostal = (string)reader["Codepostal"],
                Ville = (string)reader["ville"],
                Pays = (string)reader["pays"],
                Lat = (double)reader["lat"],
                Long = (double)reader["lon"]
            };
        }
    }
}
