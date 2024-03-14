using HotChocolate;
using SpotifyWeb;
using System.Collections.Generic;

namespace Odyssey.MusicMatcher
{
    public class Query
    {
        /// <summary>
        /// Retrieves playlists hand-picked to be featured to all users.
        /// </summary>
        /// <param name="spotifyService">The Spotify service used to interact with the API.</param>
        /// <returns>A list of featured playlists.</returns>
        [GraphQLDescription("Playlists hand-picked to be featured to all users.")]
        public async Task<List<Playlist>> FeaturedPlaylists(SpotifyService spotifyService)
        {
            var response = await spotifyService.GetFeaturedPlaylistsAsync();
            var items = response.Playlists.Items;
            var playlists = items.Select(item => new Playlist(item));
            return playlists.ToList();
        }

        /// <summary>
        /// Retrieves a specific playlist.
        /// </summary>
        /// <param name="id">The ID of the playlist to retrieve.</param>
        /// <param name="spotifyService">The Spotify service used to interact with the API.</param>
        /// <returns>The requested playlist, if found; otherwise, null.</returns>
        [GraphQLDescription("Retrieves a specific playlist.")]
        public async Task<Playlist?> GetPlaylist([ID] string id, SpotifyService spotifyService)
        {
            var response = await spotifyService.GetPlaylistAsync(id);
            var playlist = new Playlist(response);
            return playlist;
        }
    }
}
