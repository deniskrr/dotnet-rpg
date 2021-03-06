using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Models;
using dotnet_rpg.Services.Dtos.Character;

namespace dotnet_rpg.Services
{
  public class CharacterService : ICharacterService
  {
    private readonly IMapper _mapper;
    public CharacterService(IMapper mapper)
    {
      this._mapper = mapper;
    }

    private static List<Character> characters = new List<Character> {
            new Character(),
            new Character { Id = 1, Name = "Sam"},
        };
    async Task<ServiceResponse<List<GetCharacterDto>>> ICharacterService.AddCharacter(AddCharacterDto newCharacter)
    {
      ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      Character character = _mapper.Map<Character>(newCharacter);
      character.Id = characters.Max(c => c.Id) + 1;
      characters.Add(character);
      serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    async Task<ServiceResponse<List<GetCharacterDto>>> ICharacterService.GetAllCharacters()
    {
      ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList(); ;
      return serviceResponse;
    }

    async Task<ServiceResponse<GetCharacterDto>> ICharacterService.GetCharacterById(int id)
    {
      ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
      serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
      ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
      try
      {
        Character character = characters.Find(c => c.Id == updatedCharacter.Id);
        character.Name = updatedCharacter.Name;
        character.Class = updatedCharacter.Class;
        character.Defense = updatedCharacter.Defense;
        character.HitPoints = updatedCharacter.HitPoints;
        character.Intelligence = updatedCharacter.Intelligence;
        character.Strength = updatedCharacter.Strength;

        serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }
      return serviceResponse;
    }
  }
}