using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services
{
  public class CharacterService : ICharacterService
  {
    private static List<Character> characters = new List<Character> {
            new Character(),
            new Character { Id = 1, Name = "Sam"},
        };
    async Task<ServiceResponse<List<Character>>> ICharacterService.AddCharacter(Character newCharacter)
    {
      ServiceResponse<List<Character>> serviceResponse = new ServiceResponse<List<Character>>();
      characters.Add(newCharacter);
      serviceResponse.Data = characters;
      return serviceResponse;
    }

    async Task<ServiceResponse<List<Character>>> ICharacterService.GetAllCharacters()
    {
      ServiceResponse<List<Character>> serviceResponse = new ServiceResponse<List<Character>>();
      serviceResponse.Data = characters;
      return serviceResponse;
    }

    async Task<ServiceResponse<Character>> ICharacterService.GetCharacterById(int id)
    {
      ServiceResponse<Character> serviceResponse = new ServiceResponse<Character>();
      serviceResponse.Data = characters.FirstOrDefault(c => c.Id == id);
      return serviceResponse;
    }
  }
}