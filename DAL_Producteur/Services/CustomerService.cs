using Connection_tools;
using DAL_Producteur.Entities;
using static DAL_Producteur.Mappers.Mapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories;
namespace DAL_Producteur.Services
{
    public class CustomerService : ServiceBase, ICustomerRepository<Customer>
    {
        public CustomerService(IConfiguration config) : base(config)
        {
        }

        public Customer CheckCustomer(string email, string password)
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("CheckCustomer", true);
            comm.AddParameter("email", email);
            comm.AddParameter("password", password);
            return conn.ExecuteReader(comm, convertCustomer).SingleOrDefault();
        }

        public int CreateCustomer(Customer newCustomer)
        {
            Connection con= new Connection(InvariantName, ConnectionString);
            Command comm = new Command("CreateCustomer", true);
            comm.AddParameter("LastName", newCustomer.Lastname);
            comm.AddParameter("FirstName", newCustomer.Firstname);
            comm.AddParameter("Email", newCustomer.Email);
            comm.AddParameter("Password", newCustomer.Password);
            comm.AddParameter("isAdmin", newCustomer.IsAdmin);
            comm.AddParameter("AddressId", newCustomer.AddressId);
            //comm.AddParameter("Rue", newCustomer.Address.Rue);
            //comm.AddParameter("Numero", newCustomer.Address.Numero);
            //comm.AddParameter("Ville", newCustomer.Address.Ville);
            //comm.AddParameter("Codepostal", newCustomer.Address.CodePostal);
            //comm.AddParameter("Pays", newCustomer.Address.Pays);

            return (int) con.ExecuteScalar(comm);
        }
        public Customer GetCustomerById(int id )
        {
            Connection con = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("GetCustomerById", true);
            comm.AddParameter("id", id);
            return con.ExecuteReader<Customer>(comm,convertCustomer).SingleOrDefault();
        }

        public Customer GetCustomerByPurchase(int purchaseId)
        {
            Connection con = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("GetCustomerByPurchase", true);
            comm.AddParameter("id", purchaseId);
            return con.ExecuteReader<Customer>(comm, convertCustomer).SingleOrDefault();
        }
    }
}
