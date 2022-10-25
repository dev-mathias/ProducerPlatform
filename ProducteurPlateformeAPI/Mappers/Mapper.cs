using BLL_Producteur.Entities;
using ProducteurPlateformeAPI.Models;
using QuickType;

namespace ProducteurPlateformeAPI.Mappers
{
    public static class Mapper
    {

        public static Customer ToCustom (this CustomerCreate entity)
        {
            if (entity is null) throw new ArgumentNullException();
            return new Customer
            {
                Lastname = entity.Lastname,
                Firstname = entity.Firstname,
                Address = null,
                Email = entity.Email,
                Password = entity.Password,
                IsAdmin=entity.IsAdmin
            };
        }
        public static Producer ToProducer(this ProducerCreate entity)
        {
            if (entity is null) throw new ArgumentNullException();
            return new Producer
            {
                Lastname = entity.Lastname,
                Firstname = entity.Firstname,
                Address = null,
                Email = entity.Email,
                Password = entity.Password
            };
        }
        public static Product ToProduct(this ProductCreate entity)
        {
            if (entity is null) throw new ArgumentNullException();
            return new Product
            {
                Name = entity.Name,
                Description = entity.Description,
                Quantity = entity.Quantity,
                Price=entity.Price,
            };
        }
        public static Product ToProduct(this ProductUpdate entity)
        {
            if (entity is null) throw new ArgumentNullException();
            return new Product
            {
                Name = entity.Name,
                Description = entity.Description,
                Quantity = entity.Quantity,
                Price=entity.Price,
            };
        }
        public static Purchase ToPurchase(this PurchaseCreate entity)
        {
            if(entity is null) throw new ArgumentNullException();
            return new Purchase
            {
                Quantity = entity.Quantity,
                Date = entity.Date
            };
        }
        public static Address toAdresse(this AdressApiResult entity)
        {
            if (entity == null) return null;
            return new Address
            {
                Ville = entity.Results[0].City,
                Pays = entity.Results[0].Country,
                Numero = entity.Results[0].Housenumber.ToString(),
                Rue = entity.Results[0].Street,
                CodePostal = entity.Results[0].Postcode.ToString(),
                Lat = (double)entity.Results[0].Lat,
                Long = (double)entity.Results[0].Lon
            };
        }
    }
}