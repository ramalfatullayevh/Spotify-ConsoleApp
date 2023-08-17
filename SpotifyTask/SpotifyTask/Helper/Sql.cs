using System.Data;
using System.Data.SqlClient;

namespace SpotifyTask.Helper
{
    static class Sql
    {
		static string connectionString = "Server=DESKTOP-UM825JL\\SQLEXPRESS; Database=SpotifyAdonet;Trusted_Connection=True";

        static SqlConnection _connection;

		public static SqlConnection Connection
		{
			get
			{
				if (_connection==null)
				{
					_connection = new SqlConnection(connectionString);	
				}
				return _connection;
			}
		}

		public static void ExecCommand(string command)
		{
			Connection.Open();
			using (SqlCommand sqlCommand = new SqlCommand(command, Connection))
			{
				sqlCommand.ExecuteNonQuery();
			}
			Connection.Close();
		}

		public static DataTable ExecQuery(string query)
		{
			DataTable dt = new DataTable();
			Connection.Open();
			using (SqlDataAdapter sda = new SqlDataAdapter(query, Connection))
			{
				sda.Fill(dt);
			}
			Connection.Close();	
			return dt;
		}

	}
}
