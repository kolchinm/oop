using System.Collections.Generic;

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