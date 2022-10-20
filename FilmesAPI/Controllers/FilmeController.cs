using FilmesAPI.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;
        
        [HttpPost]
        public void AdionaFilme([FromBody] Filme filme) {
            filme.Id = id++;
            filmes.Add(filme);
            Console.WriteLine(filme);            
        }

        [HttpGet]
        public IEnumerable<Filme> GetFilmes()
        {
            return filmes;
        }
    }
}