using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage ="Titulo do filme e obrigatorio")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "Genero do filme e obrigatorio")]
    [MaxLength(50,ErrorMessage = "O tamanho do genero não pode exceder a 50")]
    public string Genero { get; set; }
    [Required(ErrorMessage =" A duração do filme e obrigatoria")]
    [Range(70,600, ErrorMessage ="A duração deve ser entre 70 a 600 minutos")]
    public int Duracao { get; set; }
   
}
