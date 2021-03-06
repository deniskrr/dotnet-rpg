using AutoMapper;
using dotnet_rpg.Models;
using dotnet_rpg.Services.Dtos.Character;

namespace dotnet_rpg
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Character, GetCharacterDto>();
      CreateMap<AddCharacterDto, Character>();
    }
  }
}