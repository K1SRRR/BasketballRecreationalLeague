using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRecreationalLeague.Data
{
    public class Database
    {
        private string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=super;Database=Kosarkaska rekreativna liga;";

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
