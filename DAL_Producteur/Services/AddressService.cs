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
    public class AddressService : ServiceBase, IAdressRepository<Address>
    {
        public AddressService(IConfiguration config) : base(config)
        {
        }
        public int CreateAdress(Address address)
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("CreateAdress", true);
            comm.AddParameter("Rue", address.Rue);
            comm.AddParameter("Numero", address.Numero);
            comm.AddParameter("Codepostal", address.CodePostal);
            comm.AddParameter("Ville", address.Ville);
            comm.AddParameter("Pays", address.Pays);
            comm.AddParameter("Lat", address.Lat);
            comm.AddParameter("Long", address.Long);
            return (int)conn.ExecuteScalar(comm);
        }

        public Address GetAdressByCustomer(int customerId)
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("GetAddressByCustomer", true);
            comm.AddParameter("id", customerId);
            return conn.ExecuteReader(comm, ConvertAddress).SingleOrDefault();
        }

        public Address GetAdressById(int id)
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("GetAdressById", true);
            comm.AddParameter("@Id", id);
            return conn.ExecuteReader(comm, ConvertAddress).SingleOrDefault();
        }

        public Address GetAdressByProducer(int customerId)
        {

            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("GetAddressByProducer", true);
            comm.AddParameter("id", customerId);
            return conn.ExecuteReader(comm, ConvertAddress).SingleOrDefault();
        }

        public IEnumerable<Address> GetAdresses()
        {
            Connection conn = new Connection(InvariantName, ConnectionString);
            Command comm = new Command("SELECT * FROM [Address]");
            return conn.ExecuteReader(comm, ConvertAddress);
        }
    }
}
