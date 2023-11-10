using System.Collections.Generic;

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