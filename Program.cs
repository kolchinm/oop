using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
    
        MusicCatalog catalog = new MusicCatalog();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Поиск по артистам");
            Console.WriteLine("2. Поиск артистов по жанрам");
            Console.WriteLine("3. Поиск по альбомам");
            Console.WriteLine("4. Поиск по сборникам");
            Console.WriteLine("5. Поиск по песням");
            Console.WriteLine("6. Поиск по продолжительности песни");
            Console.WriteLine("7. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SearchArtists(catalog);
                    break;
                case "2":
                    SearchArtistsByGenre(catalog);
                    break;
                case "3":
                    SearchAlbums(catalog);
                    break;
                case "4":
                    SearchSongsInCompilation(catalog);
                    break;
                case "5":
                    SearchSongs(catalog);
                    break;
                case "6":
                    SearchSongsByDurationWithQuery(catalog);
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите действие из меню.");
                    break;
            }
        }
    }

    static void SearchArtists(MusicCatalog catalog)
    {
        Console.Write("Введите имя артиста: ");
        string artistNameToSearch = Console.ReadLine();

        var foundArtists = catalog.Artists.Where(artist => artist.Name.Contains(artistNameToSearch, StringComparison.OrdinalIgnoreCase));

        if (foundArtists.Any())
        {
            foreach (var artist in foundArtists)
            {
                Console.WriteLine($"Найден артист: {artist.Name}, Жанр: {artist.Genre}");
                foreach (var album in artist.Albums)
                {
                    Console.WriteLine($"    Альбом: {album.Title}");
                    foreach (var song in album.Songs)
                    {
                        Console.WriteLine($"        {song.Title}, {song.Duration}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Артисты по запросу не найдены.");
        }
    }

    static void SearchArtistsByGenre(MusicCatalog catalog)
    {
        Console.Write("Введите жанр для поиска артистов: ");
        string genreToSearch = Console.ReadLine();

        var foundArtists = catalog.Artists.Where(artist => artist.Genre.Equals(genreToSearch, StringComparison.OrdinalIgnoreCase));

        if (foundArtists.Any())
        {
            Console.WriteLine($"Найденные артисты в жанре '{genreToSearch}':");
            foreach (var artist in foundArtists)
            {
                Console.WriteLine($"Имя артиста: {artist.Name}");
                foreach (var album in artist.Albums)
                {
                    Console.WriteLine($"    Альбом: {album.Title}");
                    foreach (var song in album.Songs)
                    {
                        Console.WriteLine($"        {song.Title}, {song.Duration}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine($"Артисты в жанре '{genreToSearch}' не найдены.");
        }
    }

    static void SearchAlbums(MusicCatalog catalog)
    {
        Console.Write("Введите запрос для поиска альбомов: ");
        string query = Console.ReadLine();

        var foundAlbums = catalog.Artists
            .SelectMany(artist => artist.Albums)
            .Where(album => album.Title.Contains(query, StringComparison.OrdinalIgnoreCase));

        if (foundAlbums.Any())
        {
            Console.WriteLine("Найдены следующие альбомы:");
            foreach (var album in foundAlbums)
            {
                Console.WriteLine($"    {album.Title}, исполнитель: {album.Artist.Name}");
                foreach (var song in album.Songs)
                {
                    Console.WriteLine($"        {song.Title}, {song.Duration}");
                }
            }
        }
        else
        {
            Console.WriteLine("Альбомы не найдены.");
        }
    }




    static void SearchSongsInCompilation(MusicCatalog catalog)
    {
        Console.Write("Введите название сборника: ");
        string compilationName = Console.ReadLine();
        var foundCompilations = catalog.Compilations.Where(compilation => compilation.Title.Contains(compilationName, StringComparison.OrdinalIgnoreCase));

        if (foundCompilations.Any())
        {
            foreach (var compilation in foundCompilations)
            {
                Console.WriteLine($"Найден сборник: {compilation.Title}");
                foreach (var artistSongPair in compilation.ArtistSongPairs)
                {
                    var artist = artistSongPair.Artist;
                    var song = artistSongPair.Song;
                    Console.WriteLine($"    {artist.Name} – {song.Title}, {song.Duration}");
                }
            }
        }
        else
        {
            Console.WriteLine("Сборники по запросу не найдены.");
        }
    }


    static void SearchSongs(MusicCatalog catalog)
    {
        Console.Write("Введите название песни: ");
        string songNameToSearch = Console.ReadLine();

        var foundSongs = catalog.Artists
            .SelectMany(artist => artist.Albums.SelectMany(album => album.Songs))
            .Where(song => song.Title.Contains(songNameToSearch, StringComparison.OrdinalIgnoreCase));

        if (foundSongs.Any())
        {
            Console.WriteLine("Найдены следующие песни:");
            foreach (var song in foundSongs)
            {
                var artist = catalog.Artists.First(a => a.Albums.Any(album => album.Songs.Contains(song)));
                Console.WriteLine($"    {artist.Name} – {song.Title}, {song.Duration}");
            }
        }
        else
        {
            Console.WriteLine("Песни не найдены");
        }
    }

    static void SearchSongsByDurationWithQuery(MusicCatalog catalog)
    {
        Console.Write("Введите запрос по длительности (например, '> 3:40', '= 4:02', или '< 3:20'): ");
        string query = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(query))
        {
            Console.WriteLine("Некорректный запрос.");
            return;
        }

        char condition = query[0];
        string durationString = query.Substring(2);

        if (TimeSpan.TryParse(durationString, out TimeSpan duration))
        {
            var foundSongs = catalog.Artists
                .SelectMany(artist => artist.Albums.SelectMany(album => album.Songs));

            switch (condition)
            {
                case '>':
                    foundSongs = foundSongs.Where(song => TimeSpan.Parse(song.Duration) > duration);
                    break;
                case '=':
                    foundSongs = foundSongs.Where(song => TimeSpan.Parse(song.Duration) == duration);
                    break;
                case '<':
                    foundSongs = foundSongs.Where(song => TimeSpan.Parse(song.Duration) < duration);
                    break;
                default:
                    Console.WriteLine("Некорректное условие в запросе.");
                    return;
            }

            if (foundSongs.Any())
            {
                Console.WriteLine("Найдены следующие песни:");
                foreach (var song in foundSongs)
                {
                    var artist = catalog.Artists.First(a => a.Albums.Any(album => album.Songs.Contains(song)));
                    Console.WriteLine($"    {artist.Name} – {song.Title}, {song.Duration}");
                }
            }
            else
            {
                Console.WriteLine("Песни не найдены");
            }
        }
        else
        {
            Console.WriteLine("Некорректный формат длительности.");
        }
    }


}
