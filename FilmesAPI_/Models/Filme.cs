using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FilmesAPI_.Models
{
    public class Filme
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo título é obrigatório!")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório!")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")]
        public string Genero { get; set; }
        [Range(1,240, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 240 minutos!")]
        public int Duracao { get; set; }
        
        public Filme(string titulo, string diretor, string genero, int duracao)
        {
            Titulo = titulo;
            Diretor = diretor;
            Genero = genero;
            Duracao = duracao;
        }

        public override string? ToString()
        {
            StringBuilder resultado = new StringBuilder();
            resultado.Append($"Id: {Id}");
            resultado.Append($"\nTítulo: {Titulo}");
            resultado.Append($"\nDiretor: {Diretor}");
            resultado.Append($"\nGênero: {Genero}");
            resultado.Append($"\nDuração: {Duracao}\n");
            return resultado.ToString();
        }
    }
}
