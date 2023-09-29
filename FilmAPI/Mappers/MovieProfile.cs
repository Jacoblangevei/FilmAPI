using AutoMapper;
using FilmAPI.Data.Models;
using FilmAPI.Data.DTOs.Movies;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDTO>();
            //.ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.PictureUrl)) // This line is redundant but shows how to configure specific property mappings
            //.ReverseMap(); // Allows mapping from MovieDTO back to Movie
    }
}