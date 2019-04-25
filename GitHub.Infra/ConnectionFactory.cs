using GitHub.CrossCutting;
using System.Data.Common;
using System.Data.SqlClient;

namespace GitHub.Infra
{
    public class ConnectionFactory
    {
        public static DbConnection GetGitHubOpenConnection()
        {
            var connection = new SqlConnection(ConnectionStrings.GitHubConnection);

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            return connection;
        }

        public static DbConnection GetGitHubConnection()
        {
            var connection = new SqlConnection(ConnectionStrings.GitHubConnection);
            return connection;
        }
    }
}
