using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace DAL_Producteur.Services
{
    public abstract class ServiceBase
    {
        private readonly IConfiguration _config;

        public ServiceBase(IConfiguration config)
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
            _config = config;   
        }
        protected string ConnectionString
        {
            get { return _config.GetConnectionString("localDb"); }
        }
        protected string InvariantName
        {
            get
            {
                return _config.GetSection("InvariantNames").GetSection("localDb").Value;
            }
        }
    }
}
