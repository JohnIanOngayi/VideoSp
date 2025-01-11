namespace src.Models;

public class VideoGameDetails
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime ReleaseDate { get; set; }

    // Foreign key to VideoGame
    public int VideoGameId { get; set; }
}
