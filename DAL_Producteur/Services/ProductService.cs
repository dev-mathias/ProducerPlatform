using Common.Repositories;
using Connection_tools;
using DAL_Producteur.Entities;
using Microsoft.Extensions.Configuration;
using static DAL_Producteur.Mappers.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Producteur.Services
{
    public class ProductService : ServiceBase, IProductRepository<Product>
    {
        public ProductService(IConfiguration config) : base(config)
        {
        }

        public int CreateProduct(Product entity)
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("CreateProduct", true);
            comm.AddParameter("nom", entity.Name);
            comm.AddParameter("quantite", entity.Quantity);
            comm.AddParameter("ProducteurId", entity.ProducerID);
            comm.AddParameter("description", entity.Description);
            comm.AddParameter("Price", entity.Price);
            return (int) conn.ExecuteScalar(comm);
        }

        public void DeleteProduct(int id)
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("DeleteProduct", true);
            comm.AddParameter("id", id);
            conn.ExecuteNonQuery(comm);
        }

        public Product GetProductById(int id)
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("GetProductById", true);
            comm.AddParameter("id", id);
            return conn.ExecuteReader<Product>(comm, ConvertProduct).SingleOrDefault();
        }

        public Product GetProductByPurchase(int purchaseId)
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("GetProductByPurchase", true);
            comm.AddParameter("id", purchaseId);
            return conn.ExecuteReader<Product>(comm, ConvertProduct).SingleOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("GetProducts", false);
            return conn.ExecuteReader<Product>(comm, ConvertProduct);
        }

        public IEnumerable<Product> GetProductsByProducerId(int producerId)
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("SELECT * FROM [Product] WHERE [ProducteurID] = @Id");
            comm.AddParameter("@Id", producerId);
            return conn.ExecuteReader(comm, ConvertProduct);

        }

        public void UpdateProduct(int id, Product entity)
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("UpdateProduct", true);
            comm.AddParameter("id", id);
            comm.AddParameter("nom", entity.Name);
            comm.AddParameter("quantite", entity.Quantity);
            comm.AddParameter("description", entity.Description);
            comm.AddParameter("Price", entity.Price);
            conn.ExecuteNonQuery(comm);
        }

    }
}
