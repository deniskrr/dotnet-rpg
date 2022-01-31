using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Models;
using dotnet_rpg.Services.Dtos.Character;

namespace dotnet_rpg.Services
{
  public interface ICharacterService
  {
    Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
    Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
    Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
    Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
  }
}