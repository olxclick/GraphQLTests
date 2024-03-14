using SpotifyWeb;
using HotChocolate;

namespace Odyssey.MusicMatcher
{
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

        /// <summary>
        /// The playlist's tracks.
        /// </summary>
        /// <param name="spotifyService">The Spotify service used to retrieve tracks.</param>
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

        /// <summary>
        /// Initializes a new instance of the Playlist class.
        /// </summary>
        /// <param name="id">The ID of the playlist.</param>
        /// <param name="name">The name of the playlist.</param>
        public Playlist(string id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the Playlist class based on a simplified playlist object.
        /// </summary>
        /// <param name="obj">The simplified playlist object.</param>
        public Playlist(PlaylistSimplified obj)
        {
            Id = obj.Id;
            Name = obj.Name;
            Description = obj.Description;
        }

        /// <summary>
        /// Initializes a new instance of the Playlist class based on a full playlist object.
        /// </summary>
        /// <param name="obj">The full playlist object.</param>
        public Playlist(SpotifyWeb.Playlist obj)
        {
            Id = obj.Id;
            Name = obj.Name;
            Description = obj.Description;
            _tracks = obj.Tracks.Items.Select(item => new Track(item.Track)).ToList();
        }
    }
}
