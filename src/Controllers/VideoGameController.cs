using Microsoft.AspNetCore.Mvc;

namespace src.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoGameController : ControllerBase
{
    private static List<VideoGame> videoGames = new List<VideoGame>
    {
        new VideoGame
        {
            Id = 1,
            Title = "Spiderman 2",
            Platform = "PS5",
            Developer = "Insomniac Games",
            Publisher = "Sony Interactive Entertainment",
        },
        new VideoGame
        {
            Id = 2,
            Title = "The Legend of Zelda: Breath of the Wild",
            Platform = "Nintendo Switch",
            Developer = "Nintendo EPD",
            Publisher = "Nintendo",
        },
        new VideoGame
        {
            Id = 3,
            Title = "Cyberpunk 2077",
            Platform = "PC",
            Developer = "CD Projekt Red",
            Publisher = "CD Projekt",
        },
    };

    [HttpGet]
    public ActionResult<List<VideoGame>> GetVideoGames()
    {
        return Ok(videoGames);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<VideoGame> GetVideoGameById(int id)
    {
        var game = videoGames.FirstOrDefault(game => game.Id == id);

        if (game is null)
            return NotFound();

        return Ok(game);
    }

    [HttpPost]
    public ActionResult<VideoGame> CreateGame(VideoGame newGame)
    {
        if (newGame is null)
            return BadRequest();

        newGame.Id = videoGames.Max(game => game.Id) + 1;
        videoGames.Add(newGame);

        return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGame(int id, VideoGame updatedGame)
    {
        var existingGame = videoGames.FirstOrDefault(game => game.Id == id);

        if (existingGame is null)
            return NotFound();

        existingGame.Title = updatedGame.Title;
        existingGame.Developer = updatedGame.Developer;
        existingGame.Publisher = updatedGame.Publisher;
        existingGame.Platform = updatedGame.Platform;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGame(int id)
    {
        var existingGame = videoGames.FirstOrDefault(game => game.Id == id);

        if (existingGame is null)
            return NotFound();

        videoGames.Remove(existingGame);
        return NoContent();
    }
}
