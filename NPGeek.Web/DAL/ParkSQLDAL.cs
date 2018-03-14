using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.DAL
{
    public class ParkSqlDAL:IParkDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ParkSystemDatabaseEntities"].ConnectionString;
    }
}