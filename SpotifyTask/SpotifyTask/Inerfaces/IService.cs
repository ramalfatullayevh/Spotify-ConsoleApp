
namespace SpotifyTask.Inerfaces
{
    interface IService<T>
    {
        void Add(T model);
        void Delete(int id);   
        List<T> GetAll();

    }
}
