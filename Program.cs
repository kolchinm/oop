using System;
using System.Collections.Generic;
using System.Linq;

class Song
{
    public string Title { get; set; }
    public string Duration { get; set; }

    public Song(string title, string duration)
    {
        Title = title;
        Duration = duration;
    }
}

class Album
{
    public string Title { get; set; }
    public Artist Artist { get; set; }
    public List<Song> Songs { get; } = new List<Song>();

    public Album(string title, Artist artist)
    {
        Title = title;
        Artist = artist;
        artist.Albums.Add(this);
    }

    public void AddSong(string title, string duration)
    {
        Songs.Add(new Song(title, duration));
    }
}

class Artist
{
    public string Name { get; set; }
    public string Genre { get; set; }
    public List<Album> Albums { get; } = new List<Album>();

    public Artist(string name, string genre)
    {
        Name = name;
        Genre = genre;
    }
}

class Compilation
{
    public string Title { get; set; }
    public List<ArtistSongPair> ArtistSongPairs { get; } = new List<ArtistSongPair>();

    public Compilation(string title)
    {
        Title = title;
    }

    public void AddArtistSongPair(Artist artist, Song song)
    {
        ArtistSongPairs.Add(new ArtistSongPair(artist, song));
    }
}

class ArtistSongPair
{
    public Artist Artist { get; }
    public Song Song { get; }

    public ArtistSongPair(Artist artist, Song song)
    {
        Artist = artist;
        Song = song;
    }
}

class MusicCatalog
{
    public List<Artist> Artists { get; } = new List<Artist>();
    public List<Compilation> Compilations { get; } = new List<Compilation>();
    public void AddCompilation(string title)
    {
        Compilation compilation = new Compilation(title);
        Compilations.Add(compilation);
    }

    public void AddArtistSongPairToCompilation(Compilation compilation, Artist artist, Song song)
    {
        compilation.AddArtistSongPair(artist, song);
    }
}

class Program
{
    static void Main()
    {
        MusicCatalog catalog = new MusicCatalog();

        Artist artist1 = new Artist("МакSим", "Поп");
        Artist artist2 = new Artist("Дора", "Кьют-рок");
        Artist artist3 = new Artist("Монеточка", "Антифолк");
        Artist artist4 = new Artist("Александр Гудков", "Поп");
        Artist artist5 = new Artist("Валерий Меладзе", "Поп");

        Album album1 = new Album("Трудный возраст", artist1);
        artist1.Albums[0].AddSong("Трудный возраст", "3:44");
        artist1.Albums[0].AddSong("Сантиметры дыханья", "3:29");
        artist1.Albums[0].AddSong("Нежность", "3:18");
        artist1.Albums[0].AddSong("Лолита", "4:10");
        artist1.Albums[0].AddSong("Сон", "3:23");
        artist1.Albums[0].AddSong("Ветром стать", "3:12");
        artist1.Albums[0].AddSong("Отпускаю", "4:21");
        artist1.Albums[0].AddSong("Пам-парам", "5:13");
        artist1.Albums[0].AddSong("Знаешь ли ты", "4:02");

        Album album2 = new Album("Спасибо", artist1);
        artist1.Albums[1].AddSong("Спасибо", "3:01");


        Album album3 = new Album("Младшая сестра", artist2);
        artist2.Albums[0].AddSong("Дорадура", "2:13");
        artist2.Albums[0].AddSong("Младшая сестра", "3:42");
        artist2.Albums[0].AddSong("Интернет-свидание", "2:52");
        artist2.Albums[0].AddSong("Жулик", "3:51");
        artist2.Albums[0].AddSong("Подружки", "2:22");
        artist2.Albums[0].AddSong("Задолбал меня игнорить", "2:59");
        artist2.Albums[0].AddSong("Дождик за окном", "2:48");

        Album album4 = new Album("Пошлю его на...", artist2);
        artist2.Albums[1].AddSong("Пошлю его на...", "3:08");

        Album album5 = new Album("Втюрилась", artist2);
        artist2.Albums[2].AddSong("Втюрилась", "2:03");


        Album album6 = new Album("Раскраски для взрослых", artist3);
        artist3.Albums[0].AddSong("Русский ковчег", "3:33");
        artist3.Albums[0].AddSong("Каждый раз", "3:28");
        artist3.Albums[0].AddSong("Нимфоманка", "2:40");
        artist3.Albums[0].AddSong("Нет монет", "4:38");
        artist3.Albums[0].AddSong("Ночной ларёк", "2:44");
        artist3.Albums[0].AddSong("Кумушки", "3:32");
        artist3.Albums[0].AddSong("90", "3:21");
        artist3.Albums[0].AddSong("Твоё имя", "3:01");
        artist3.Albums[0].AddSong("Запорожец", "2:49");
        artist3.Albums[0].AddSong("Пост-пост", "3:47");

        Album album7 = new Album("Переживу", artist3);
        artist3.Albums[1].AddSong("Переживу", "3:25");


        Album album8 = new Album("Я узкий", artist4);
        artist4.Albums[0].AddSong("Я узкий", "2:59");


        Album album9 = new Album("Океан", artist5);
        artist5.Albums[0].AddSong("Иностранец", "4:05");
        artist5.Albums[0].AddSong("Салют, Вера", "3:44");
        artist5.Albums[0].AddSong("Осколки лета", "3:41");
        artist5.Albums[0].AddSong("Се ля ви", "3:55");
        artist5.Albums[0].AddSong("Притяженья больше нет", "4:32");
        artist5.Albums[0].AddSong("Красиво", "4:44");
        artist5.Albums[0].AddSong("Океан и три реки", "3:40");
        artist5.Albums[0].AddSong("Сэра", "3:52");
        artist5.Albums[0].AddSong("Актриса", "4:09");
        artist5.Albums[0].AddSong("Самба белого мотылька", "4:01");

        catalog.Artists.Add(artist1);
        catalog.Artists.Add(artist2);
        catalog.Artists.Add(artist3);
        catalog.Artists.Add(artist4);
        catalog.Artists.Add(artist5);

        catalog.AddCompilation("Лучшие хиты");
        Compilation compilation1 = catalog.Compilations[0];
        catalog.AddArtistSongPairToCompilation(compilation1, artist1, new Song("Знаешь ли ты", "4:02"));
        catalog.AddArtistSongPairToCompilation(compilation1, artist1, new Song("Отпускаю", "4:21"));
        catalog.AddArtistSongPairToCompilation(compilation1, artist2, new Song("Дорадура", "2:13"));
        catalog.AddArtistSongPairToCompilation(compilation1, artist3, new Song("Нимфоманка", "2:40"));
        catalog.AddArtistSongPairToCompilation(compilation1, artist4, new Song("Я узкий", "2:59"));
        catalog.AddArtistSongPairToCompilation(compilation1, artist5, new Song("Самба белого мотылька", "4:01"));

        catalog.AddCompilation("Грустные песни");
        Compilation compilation2 = catalog.Compilations[1];
        catalog.AddArtistSongPairToCompilation(compilation2, artist1, new Song("Нежность", "3:18"));
        catalog.AddArtistSongPairToCompilation(compilation2, artist2, new Song("Дождик за окном", "2:48"));
        catalog.AddArtistSongPairToCompilation(compilation2, artist3, new Song("Каждый раз", "3:28"));
        catalog.AddArtistSongPairToCompilation(compilation2, artist5, new Song("Осколки лета", "3:41"));

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
