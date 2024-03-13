namespace Odyssey.MusicMatcher;
using SpotifyWeb;
public class Mutation
{
  public async Task<AddItemsToPlaylistPayload> AddItemsToPlaylist(AddItemsToPlaylistInput input, SpotifyService spotifyService)
  {
	try
	{
		var snapshot_id = await spotifyService.AddTracksToPlaylistAsync(
			input.PlaylistId,
			0,
			string.Join(",", input.Uris)
		);

		var response = await spotifyService.GetPlaylistAsync(input.PlaylistId);
		var playlist = new Playlist(response);

		return new AddItemsToPlaylistPayload(
			200,
			true,
			"Successfully added items to playlist",
			playlist
		);
		}
		catch (Exception e)
		{
			return new AddItemsToPlaylistPayload(
				500,
				false,
				"Something went wrong: " + e.Message,
				null
			);
		}
	}
}