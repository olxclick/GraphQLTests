using SpotifyWeb;

namespace Odyssey.MusicMatcher
{
    public class Mutation
    {
        /// <summary>
        /// Adds items to a playlist.
        /// </summary>
        /// <param name="input">The input containing playlist ID and track URIs.</param>
        /// <param name="spotifyService">The Spotify service used to interact with the API.</param>
        /// <returns>A payload containing the result of the mutation.</returns>
        public async Task<AddItemsToPlaylistPayload> AddItemsToPlaylist(AddItemsToPlaylistInput input, SpotifyService spotifyService)
        {
            try
            {
                // Add tracks to the playlist
                var snapshot_id = await spotifyService.AddTracksToPlaylistAsync(
                    input.PlaylistId,
                    0,
                    string.Join(",", input.Uris)
                );

                // Retrieve the updated playlist
                var response = await spotifyService.GetPlaylistAsync(input.PlaylistId);
                var playlist = new Playlist(response);

                // Return success payload
                return new AddItemsToPlaylistPayload(
                    200,
                    true,
                    "Successfully added items to playlist",
                    playlist
                );
            }
            catch (Exception e)
            {
                // Return error payload
                return new AddItemsToPlaylistPayload(
                    500,
                    false,
                    "Something went wrong: " + e.Message,
                    null
                );
            }
        }
    }
}
