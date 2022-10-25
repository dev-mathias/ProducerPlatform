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
    public class PurchaseService : ServiceBase, IPurchaseRepository<Purchase>
    {
        public PurchaseService(IConfiguration config) : base(config)
        {
        }

        public int CreatePurchase(Purchase entity)
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("CreatePurchase", true);
            comm.AddParameter("Date", entity.Date);
            comm.AddParameter("ProductId", entity.ProductId);
            comm.AddParameter("CustomerId", entity.CustomerId);
            comm.AddParameter("Quantite", entity.Quantity);
            return (int)conn.ExecuteScalar(comm);
        }

        public IEnumerable<Purchase> GetPurchaseByCustomerId(int customerId)
        {

            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("SELECT * FROM [Purchase] WHERE CustomerId=@customerId");
            comm.AddParameter("@customerId", customerId);
            return conn.ExecuteReader(comm, ConvertPurchase);
        }

        public Purchase GetPurchaseById(int id)
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("GetPurchaseById", true);
            comm.AddParameter("Id", id);
            return conn.ExecuteReader(comm, ConvertPurchase).SingleOrDefault();
        }
        
    }
}
