namespace Odyssey.MusicMatcher
{
    public class AddItemsToPlaylistInput
    {
        public string PlaylistId { get; set; }
        public List<string> Uris { get; set; }

        /// <summary>
        /// Initializes a new instance of the AddItemsToPlaylistInput class.
        /// </summary>
        /// <param name="playlistId">The ID of the playlist to which items will be added.</param>
        /// <param name="uris">The URIs of the items to be added to the playlist.</param>
        public AddItemsToPlaylistInput(string playlistId, List<string> uris)
        {
            PlaylistId = playlistId;
            Uris = uris;
        }
    }
}
