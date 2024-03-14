using SpotifyWeb;
using HotChocolate;

namespace Odyssey.MusicMatcher;

[GraphQLDescription("A curated collection of tracks designed for a specific activity or mood.")]
public class Playlist
{
    [ID]
    [GraphQLDescription("The ID for the playlist.")]
    public string Id { get; }

    [GraphQLDescription("The name of the playlist.")]
    public string Name { get; set; }

    [GraphQLDescription("Describes the playlist, what to expect and entices the user to listen.")]
    public string? Description { get; set; }
    private List<Track>? _tracks;

    [GraphQLDescription("The playlist's tracks.")]
    public async Task<List<Track>> Tracks(SpotifyService spotifyService)
    {
	if (_tracks != null)
		return _tracks;
	else
	{
		var response = await spotifyService.GetPlaylistsTracksAsync(this.Id);
		return response.Items.Select(item => new Track(item.Track)).ToList();
	}
    }
    public Playlist(string id, string name)
    {
        Id = id;
        Name = name;
    }
/// <summary>
/// 
/// </summary>
/// <param name="obj"></param>
    public Playlist(PlaylistSimplified obj)
    {
        Id = obj.Id;
        Name = obj.Name;
        Description = obj.Description;
    }

    public Playlist(SpotifyWeb.Playlist obj)
    {
        Id = obj.Id;
        Name = obj.Name;
        Description = obj.Description;
        _tracks = obj.Tracks.Items.Select(item => new Track(item.Track)).ToList();
    }
}