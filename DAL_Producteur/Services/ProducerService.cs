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
    public class ProducerService : ServiceBase, IProducerRepository<Producer>
    {
        public ProducerService(IConfiguration config) : base(config)
        {
        }

        public Producer CheckProducer(string email, string password)
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("CheckProducer", true);
            comm.AddParameter("email", email);
            comm.AddParameter("password", password);
            return conn.ExecuteReader(comm, convertProducer).SingleOrDefault();
        }

        public int CreateProducer(Producer newProducer)
        {
            Connection con= new Connection(InvariantName, ConnectionString);
            Command comm = new Command("CreateProducer", true);
            comm.AddParameter("LastName", newProducer.Lastname);
            comm.AddParameter("FirstName", newProducer.Firstname);
            comm.AddParameter("Email", newProducer.Email);
            comm.AddParameter("Password", newProducer.Password);
            comm.AddParameter("AddressId", newProducer.AddressId);
            return (int)con.ExecuteScalar(comm);
        }

        public Producer GetProducerById(int id)
        {
            Connection con = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("GetProducerById", true);
            comm.AddParameter("id", id);
            return con.ExecuteReader<Producer>(comm, convertProducer).SingleOrDefault();
        }

        public Producer GetProducerByProduct(int productId)
        {
            Connection con = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("GetProducerByProduct", true);
            comm.AddParameter("id",productId) ;
            return con.ExecuteReader<Producer>(comm, convertProducer).SingleOrDefault();
        }

        public IEnumerable<Producer> GetProducers()
        {
            Connection con = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("GetProducters", false);
            return con.ExecuteReader<Producer>(comm, convertProducer);
        }
    }
}
