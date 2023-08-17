using SpotifyTask.Helper;
using SpotifyTask.Inerfaces;
using SpotifyTask.Models;
using System.Data;


namespace SpotifyTask.Services
{
    internal class MusicService : IService<Music>
    {
        public void Add(Music model)
        {
            Sql.ExecCommand($"Insert into musics values (N'{model.Name}',{model.Duration} ,{model.CategoryId})");
        }

        public void Delete(int id)
        {

            Sql.ExecCommand($"Delete Musics Where Id = {id}");

        }

        public List<Music> GetAll()
        {
            DataTable dt = Sql.ExecQuery("SELECT * FROM Musics");
            List<Music> musics = new List<Music>();
            foreach (DataRow dr  in dt.Rows)
            {
                musics.Add(new Music { Id =Convert.ToInt32(dr["Id"]), Name = dr["Name"].ToString(), Duration = Convert.ToInt32(dr["Duration"]), CategoryId = Convert.ToInt32(dr["CategoryId"]) });
            }
            return musics;
        }
    }
}
