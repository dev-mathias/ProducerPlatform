using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D = DAL_Producteur.Entities;
using B = BLL_Producteur.Entities;
namespace BLL_Producteur.Mapper
{
    public static class Mapper
    {
        public static D.Customer ToDal(this B.Customer entity)
        {
            if (entity is null) return null;
            return new D.Customer
            {
                Id = entity.Id,
                Lastname = entity.Lastname, 
                Firstname= entity.Firstname,
                AddressId= entity.Address.Id,
                Email=entity.Email,
                Password=entity.Password,
                IsAdmin=entity.IsAdmin
            };
        }

        public static B.Customer ToBll(this D.Customer entity)
        {
            if (entity is null) return null;
            return new B.Customer
            {
                Id = entity.Id,
                Lastname = entity.Lastname,
                Firstname = entity.Firstname,
                Address = null,
                Email = entity.Email,
                Password = entity.Password
            };
        }
        public static B.Producer ToBll(this D.Producer entity)
        {
            if (entity is null) return null;
            return new B.Producer
            {
                Id = entity.Id,
                Lastname = entity.Lastname,
                Firstname = entity.Firstname,
                Address = null,
                Email = entity.Email,
                Password = entity.Password
            };
        }
        public static IEnumerable<B.Producer> ToBll(this IEnumerable<D.Producer> entities)
        {
            if (entities is null) throw new ArgumentNullException();
            foreach(D.Producer entity in entities)
            {
                yield return new B.Producer
                {
                    Id = entity.Id,
                    Lastname = entity.Lastname,
                    Firstname = entity.Firstname,
                    Address = null,
                    Email = entity.Email,
                    Password = entity.Password
                };
            }
            
        }
        public static D.Producer ToDal(this B.Producer entity)
        {
            if (entity is null) return null;
            return new D.Producer
            {
                Id = entity.Id,
                Lastname = entity.Lastname,
                Firstname = entity.Firstname,
                AddressId = entity.Address.Id,
                Email = entity.Email,
                Password = entity.Password
            };
        }
        public static D.Product ToDal(this B.Product entity)
        {
            if (entity is null) throw new ArgumentNullException();
            return new D.Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Quantity = entity.Quantity,
                ProducerID = entity.Producer.Id,
                Price=entity.Price,
            };
        }
        public static B.Product ToBll(this D.Product entity)
        {
            if (entity is null) throw new ArgumentNullException();
            return new B.Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Quantity = entity.Quantity,
                Producer = null,
                Price = entity.Price,
            };
        }
        public static IEnumerable<B.Product> ToBll(this IEnumerable<D.Product> entities)
        {
            if (entities is null) throw new ArgumentNullException();
            foreach(D.Product entity in entities)
            {
                yield return new B.Product
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Quantity = entity.Quantity,
                    Producer = null,
                    Price = entity.Price,
                };
            }
        
        }
        public static B.Purchase ToBll( this D.Purchase entity)
        {
            if (entity is null) throw new ArgumentNullException();
            return new B.Purchase
            {
                Id = entity.Id,
                Date = entity.Date,
                Customer = null,
                Product = null,
                Quantity = entity.Quantity,
            };
        }
        public static IEnumerable<B.Purchase> ToBll(this IEnumerable<D.Purchase> entities)
        {
            if (entities is null) throw new ArgumentNullException();
            foreach(var entity in entities)
            { 
                yield return new B.Purchase
                {
                 Id = entity.Id,
                 Date = entity.Date,
                 Customer = null,
                 Product = null,
                 Quantity = entity.Quantity,
                };

            }
        }
        public static D.Purchase ToDal(this B.Purchase entity)
        {
            if (entity is null) throw new ArgumentNullException();
            return new D.Purchase
            {
                Id = entity.Id,
                Date = entity.Date,
                CustomerId = entity.Customer.Id,
                ProductId = entity.Product.Id,
                Quantity = entity.Quantity,
            };
        }
        public static D.Address ToDal(this B.Address entity)
        {
            if (entity is null) return null;
            return new D.Address
            {
                Id = entity.Id,
                Rue = entity.Rue,
                Numero = entity.Numero,
                CodePostal = entity.CodePostal,
                Ville = entity.Ville,
                Pays = entity.Pays,
                Lat = entity.Lat,
                Long= entity.Long
            };
        }
        public static B.Address ToBll(this D.Address entity)
        {
            if (entity is null) return null;
            return new B.Address
            {
                Id = entity.Id,
                Rue = entity.Rue,
                Numero = entity.Numero,
                CodePostal = entity.CodePostal,
                Ville = entity.Ville,
                Pays = entity.Pays,
                Long = entity.Long,
                Lat=entity.Lat
                

            };
        }
        public static IEnumerable<B.Address> ToBll(this IEnumerable<D.Address> entities)
        {
            if (entities is null) throw new ArgumentNullException(); 
            foreach(D.Address entity in entities)
            {
                yield return new B.Address
                {
                    Id = entity.Id,
                    Rue = entity.Rue,
                    Numero = entity.Numero,
                    CodePostal = entity.CodePostal,
                    Ville = entity.Ville,
                    Pays = entity.Pays,
                    Long = entity.Long,
                    Lat = entity.Lat

                };
            }
          
        }

    }
}
