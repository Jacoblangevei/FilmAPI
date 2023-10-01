using AutoMapper;
using FilmAPI.Data.Models;
using FilmAPI.Data.DTOs.Characters;

public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        CreateMap<Character, CharacterDTO>().ReverseMap();
        CreateMap<Character, CharacterPostDTO>().ReverseMap();
        CreateMap<Character, CharacterPutDTO>().ReverseMap();
    }
}
