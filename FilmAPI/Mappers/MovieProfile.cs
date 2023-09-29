using AutoMapper;
using FilmAPI.Data.Models;
using FilmAPI.Data.DTOs.Movies;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDTO>().ReverseMap();
        CreateMap<Movie, MoviePostDTO>().ReverseMap();
        CreateMap<Movie, MoviePutDTO>().ReverseMap();
    }
}