
using SpotifyTask.Helper;
using SpotifyTask.Inerfaces;
using SpotifyTask.Models;
using System.Data;

namespace SpotifyTask.Services
{
    internal class ArtistService : IService<Artist>
    {
        public void Add(Artist model)
        {
            Sql.ExecCommand($"INSERT INTO Artists VALUES (N'{model.Name}', N'{model.Surname}', '{model.Birthday}' , N'{model.Gender}')");
        }

        public void Delete(int id)
        {
            Sql.ExecCommand($"DELETE Artists WHERE Id ={id} ");
        }

        public List<Artist> GetAll()
        {
            DataTable dt = Sql.ExecQuery("SELECT * FROM Artists");
            List<Artist> artists = new List<Artist>();
            foreach (DataRow dr in dt.Rows )
            {
                artists.Add(new Artist { Id = Convert.ToInt32(dr["Id"]), Name = dr["Name"].ToString(), Surname = dr["Surname"].ToString(), Birthday = Convert.ToDateTime((dr["Birthday"])), Gender = dr["Gender"].ToString(), });
            }
            return artists;
        }
    }
}
