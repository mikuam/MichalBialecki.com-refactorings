using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MichalBialecki.com.Refactorings.DAL
{
    public abstract class BaseRepository
    {
        private readonly IConfiguration _configuration;
        
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        internal IDbConnection GetBlogConnection()
        {
            var conf = _configuration.GetSection("ConnectionStrings")["Blog"];
            return new SqlConnection(conf);
        }
    }
}
