using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers;

[ApiController] //Atributo que indica que esta classe e um controlador da API
[Route("{controller}")] //Define a rota base para este controlador, onde [controller] sera substituido pelo nome da classe, neste caso, "Cinema"

public class CinemaController : ControllerBase //Declaração da classe CinemaController que herda da ControllerBase
{

    private FilmeContext _context; // Declaração de uma variavel privada para representar o contexto do banco de dados
    private IMapper _mapper; // Declaração de uma variavel privada para representar um objeto do IMapper ultilizado para mapear objetos.

    //Contrutor que recebe instancias do contexto de banco de dados e do IMapper como parametro
    //Instanciando o FilmeContext como context e o Imapper como mapper para que quando o construtor seja chamado receber esses parametrosvoce
    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;   
            
    }




    [HttpPost] //Atributo que indica que este metodo responde a requisições do tipo Post (cadastro)
    public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        //Mapeia o objeto CreateCinemaDto para tipo Cinema usando o IMapper.
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

        //Adiciona o objeto Cinema ao contexto do banco de dados
        _context.Cinemas.Add(cinema);

        //Salva as mudanças no banco de dados
        _context.SaveChanges();

        //Retorna um resulta IActionResult, indicando que a operação foi bem sucedida
        return CreatedAtAction(nameof(RecuperaCinemasPorId), new { id = cinema.Id }, cinemaDto);
    }

    [HttpGet] // Atributo que indica que este metodo responde a requisições HTTP do tipo GET
    public IEnumerable<ReadCinemaDto> RecuperaCinemas()
    {
        //Mapeia uma lista de objetos Cinema para uma lista de objetos ReadCinemaDto utilizando o IMaper
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
    }

    [HttpGet("{id}")]// Atributo que indica que este metodo responde requisições HTTP do tipo GET com um parametro na URL
    public IActionResult RecuperaCinemasPorId(int id)
    {
        //Busca objeto Cinema no contexto do banco de dados com base no ID fornecido
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.id == id);

        //Verifica se o cinema foi encontrado
        if(cinema != null)
        {
            //Mapeia o objeto Cinema para o tipo ReadCinemaDto ultilizando o IMapper
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);

            //Retorna um resultado OK com o objeto mapeado.
            return Ok(cinemaDto);
        }

        //Retorna um resultaod NotFound se o cinema não foi encontrado.
        return NotFound();
    }

    [HttpPut("{id}")] //Atributo que indica que este metodo responde a requisições HTTP do tipo PUT com um parametro na URL.
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        //Busca por um objeto Cinema no contexto do banco de dados com base no ID fornecido
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        //Verifica se o cinema foi encontrado
        if(cinema == null)
        {
            return NotFound();
        }
        
        //Atualiza o objeto Cinema com base nos dados fornecidos no objeto UpdateCinemaDto usando o IMapper.
        _mapper.Map(cinemaDto, cinema);

        //Salva no banco de dados
        _context.SaveChanges();

        //Retorna um resultado noContent, indicando que a operação foi bem sucedida.
        return NoContent();

    }

    [HttpDelete("{id}")] // Atributo que indica que este metodo responde a requisições HTTP do tipo PUT com um parametro na URL
    public IActionResult DeletaFilmes(int id)
    {
        //Busca um objeto Cinema no contexto do banco de dados com base em um ID fornecido
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.id = id);

        //Verifica se foi encontrado 
        if(cinema == null)
        {
            //Retorna um resulta NotFound se o cinema não foi encontrado
            return NotFound();
        }
        
        //Remove o objeto Cinema do contexto do banco de dados
        _context.Remove(cinema);

        //Salva as alterações realizadas
        _context.SaveChanges();

        //Retorna um resulta do tipo NotContent indicando que a operação foi bem sucedida
        return NoContent();
    }



}

