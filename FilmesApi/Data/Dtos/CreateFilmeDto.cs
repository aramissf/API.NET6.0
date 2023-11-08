using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class CreateFilmeDto
{
  
    public string Titulo { get; set; }
    [Required(ErrorMessage = "Genero do filme e obrigatorio")]
    [StringLength(50, ErrorMessage = "O tamanho do genero não pode exceder a 50")]
    public string Genero { get; set; }
    [Required(ErrorMessage = " A duração do filme e obrigatoria")]
    [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 a 600 minutos")]
    public int Duracao { get; set; }
}
