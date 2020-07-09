using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.Needle.Data.Repository.Dapper.Common
{
    public class Repository : IDisposable
    {
        public IDbConnection MusicStoreConnection
        {
            get { return new SqlConnection(ConfigurationManager.ConnectionStrings["LotteryEntities"].ConnectionString); }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
