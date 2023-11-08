using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class CinemaProfile : Profile
    {
        //Essa classe representa um perfil de mapeamento para a entidade Cinema. Ela herda de Profile que e parte do AutoMapper.

        public CinemaProfile() 
        {
            //No contrutor, são definidos os mapeamentos entre diferentes tipo de objetos usando o AutoMapper

            CreateMap<CreateCinemaDto, Cinema>();
            //Aqui, esta sendo criado um mapeamento do tipo CreateCinemaDto para Cinema.
            //Isso significa que o AutoMapper saberá como transformar um objeto CreateCinemaDto em um objeto Cinema.


            CreateMap<Cinema, ReadCinemaDto>();
            //Este mapeamento e para transformar um objeto Cinema em um objeto ReadCinemaDto
            //Geralmente, CreateCinemaDto e usado para entrada (por exemplo, criação), e ReadCinemaDto e usado para saida (por exemplo, leitura).

            CreateMap<UpdateCinemaDto, Cinema>();
            //Similar ao primeiro mapeamento, mas desta vez entre UpdateCinemaDto e Cinema.
            //UpdateCinemaDto provavelmente contem apenas as propiedades que podem ser atualizadas, enquanto Cinema contem todas as propiedades da entidade Cinema.

        }

    }
}
