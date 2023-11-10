using System.Collections.Generic;

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