using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class SongsController : ControllerBase
{
    private static List<Song> _songs = new List<Song>
    {
        new Song { SongId = 1, Title = "Azucar", Language = "English" },
        new Song { SongId = 2, Title = "La Vida es un Carnaval", Language = "Spanish" },
    };

    [HttpGet]
    public IEnumerable<Song> Get()
    {
        return _songs;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Song song)
    {
        _songs.Add(song);
        return CreatedAtAction(nameof(Get), new { id = song.SongId }, song);
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Song song)
    {
        var existingSong = _songs.FirstOrDefault(s => s.SongId == id);
        if (existingSong == null)
        {
            return NotFound();
        }

        existingSong.Title = song.Title;
        existingSong.Language = song.Language;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var song = _songs.FirstOrDefault(s => s.SongId == id);
        if (song != null)
        {
            _songs.Remove(song);
        }
    }
}         