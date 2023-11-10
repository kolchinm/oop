using System;
using System.Collections.Generic;

class MusicCatalog
{
    public List<Artist> Artists { get; } = new List<Artist>();
    public List<Compilation> Compilations { get; } = new List<Compilation>();
    public MusicCatalog()
    {
        InitializeCatalog(this);
    }
    private void InitializeCatalog(MusicCatalog catalog)
    {
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
    }
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