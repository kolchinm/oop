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