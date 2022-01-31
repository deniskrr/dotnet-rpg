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
    async Task<List<Character>> ICharacterService.AddCharacter(Character newCharacter)
    {
      characters.Add(newCharacter);
      return characters;
    }

    async Task<List<Character>> ICharacterService.GetAllCharacters()
    {
      return characters;
    }

    async Task<Character> ICharacterService.GetCharacterById(int id)
    {
      return characters.FirstOrDefault(c => c.Id == id);
    }
  }
}