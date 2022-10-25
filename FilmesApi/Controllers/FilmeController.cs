using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        private FilmeContext _filmeContext;
        private IMapper _mapper;

        public FilmeController(FilmeContext _filmeContext, IMapper _mapper)
        {
            this._filmeContext = _filmeContext;
            this._mapper = _mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = this._mapper.Map<Filme>(filmeDto);
            this._filmeContext.Filmes.Add(filme);
            this._filmeContext.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(this._filmeContext.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            Filme filme = this._filmeContext.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null) {
                ReadFilmeDto filmeDto = this._mapper.Map<ReadFilmeDto>(filme);
                filmeDto.HoraDaConsulta = DateTime.Now;
                return Ok(filmeDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = this._filmeContext.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            this._mapper.Map(filmeDto, filme);
            this._filmeContext.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = this._filmeContext.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            this._filmeContext.Remove(filme);
            this._filmeContext.SaveChanges();
            return NoContent();
        }
    }
}
