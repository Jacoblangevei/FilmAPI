using AutoMapper;
using FilmAPI.Data.Models;
using FilmAPI.Data.DTOs.Franchises;

public class FranchiseProfile : Profile
{
    public FranchiseProfile()
    {
        CreateMap<Franchise, FranchiseDTO>().ReverseMap();
        CreateMap<Franchise, FranchisePostDTO>().ReverseMap();
        CreateMap<Franchise, FranchisePutDTO>().ReverseMap();
    }
}