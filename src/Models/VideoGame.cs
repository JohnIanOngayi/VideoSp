namespace src.Models;

public class VideoGame
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Platform { get; set; }

    // The many side of a one to many relationship
    public int? DeveloperId { get; set; }
    public Developer? Developer { get; set; }

    // The many side of a one to many relationship
    public int? PublisherId { get; set; }
    public Publisher? Publisher { get; set; }

    public VideoGameDetails? VideoGameDetails { get; set; }

    public List<Genre>? Genres { get; set; }
}
