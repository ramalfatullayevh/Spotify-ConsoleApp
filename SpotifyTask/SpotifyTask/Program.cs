using SpotifyTask.Models;
using SpotifyTask.Services;

namespace SpotifyTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicService musicService = new MusicService();

            Music music = new Music { Name = "Mockingbird", Duration = 275, CategoryId = 2 };
            musicService.Add(music);


            //Qeyd: bu bizim evvelki taskimizdaki strukturdadi, yeni ilk delete emeliyyatinda tarix ikinci delete de birbasha silir.
            musicService.Delete(5);


            foreach (var item in musicService.GetAll())
            {
                Console.WriteLine($"{item.Id}, {item.Name}, {item.Duration}, {item.CategoryId}");
            }


            ArtistService artistService = new ArtistService();
            Artist artist = new Artist { Name = "Ramal", Surname = "Fatullayev", Birthday = new DateTime(2002, 10, 5), Gender = "Kisi" };
            artistService.Add(artist);


            //Qeyd: bu bizim evvelki taskimizdaki strukturdadi, yeni ilk delete emeliyyatinda tarix ikinci delete de birbasha silir.
            artistService.Delete(3);


            foreach (var item in artistService.GetAll())
            {
                Console.WriteLine($"{item.Id}, {item.Name}, {item.Surname}, {item.Birthday}, {item.Gender}");
            }


        }
    }
}