using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;

namespace src.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoGameController(VideoGameDbContext context) : ControllerBase
{
    private readonly VideoGameDbContext _context = context;

    [HttpGet]
    public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
    {
        return Ok(
            await _context
                .VideoGames.Include(game => game.VideoGameDetails)
                .Include(game => game.Developer)
                .Include(game => game.Publisher)
                .ToListAsync()
        );
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
    {
        var game = await _context.VideoGames.FirstOrDefaultAsync(game => game.Id == id);

        if (game is null)
            return NotFound();

        return Ok(game);
    }

    [HttpPost]
    public async Task<ActionResult<VideoGame>> CreateGame(VideoGame newGame)
    {
        if (newGame is null)
            return BadRequest();

        await _context.VideoGames.AddAsync(newGame);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGame(int id, VideoGame updatedGame)
    {
        var existingGame = await _context.VideoGames.FirstOrDefaultAsync(game => game.Id == id);

        if (existingGame is null)
            return NotFound();

        existingGame.Title = updatedGame.Title;
        existingGame.Developer = updatedGame.Developer;
        existingGame.Publisher = updatedGame.Publisher;
        existingGame.Platform = updatedGame.Platform;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVideoGame(int id)
    {
        var existingGame = _context.VideoGames.FirstOrDefault(game => game.Id == id);

        if (existingGame is null)
            return NotFound();

        _context.VideoGames.Remove(existingGame);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
