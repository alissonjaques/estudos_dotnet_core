using FilmesAPI_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;
        
        [HttpPost]
        public IActionResult AdionaFilme([FromBody] Filme filme) {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(getFilmePorId), new {Id = filme.Id}, filme);
        }
        
        [HttpGet]
        public IActionResult GetFilmes()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult getFilmePorId(int id) { 
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme != null) {
                return Ok(filme);        
            }
            return NotFound();
        }
    }
}