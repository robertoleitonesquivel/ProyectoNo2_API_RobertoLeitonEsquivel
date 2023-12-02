using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoNo2_API_RobertoLeitonEsquivel.Repository
{
    public class MasterRepository
    {

        private readonly string connectionString;

        public MasterRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Aviones"].ConnectionString;
        }

        protected SqlConnection GetConection()
        {
            return new SqlConnection(connectionString);
        }
    }
}