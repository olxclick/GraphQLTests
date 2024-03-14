using HotChocolate;

namespace Odyssey.MusicMatcher
{
    public class AddItemsToPlaylistPayload
    {
        [GraphQLDescription("Similar to HTTP status code, represents the status of the mutation.")]
        public int Code { get; set; }

        [GraphQLDescription("Indicates whether the mutation was successful.")]
        public bool Success { get; set; }

        [GraphQLDescription("Human-readable message for the UI.")]
        public string Message { get; set; }

        [GraphQLDescription("The playlist that contains the newly added items.")]
        public Playlist? Playlist { get; set; }

        /// <summary>
        /// Initializes a new instance of the AddItemsToPlaylistPayload class.
        /// </summary>
        /// <param name="code">The status code of the mutation.</param>
        /// <param name="success">Indicates whether the mutation was successful.</param>
        /// <param name="message">A human-readable message for the UI.</param>
        /// <param name="playlist">The playlist that contains the newly added items.</param>
        public AddItemsToPlaylistPayload(int code, bool success, string message, Playlist? playlist)
        {
            Code = code;
            Success = success;
            Message = message;

            if (playlist != null)
                Playlist = playlist;
        }
    }
}
