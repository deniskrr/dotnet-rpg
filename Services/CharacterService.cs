using System.Collections.Generic;
using System.Linq;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services
{
  public class CharacterService : ICharacterService
  {
    private static List<Character> characters = new List<Character> {
            new Character(),
            new Character { Id = 1, Name = "Sam"},
        };
    List<Character> ICharacterService.AddCharacter(Character newCharacter)
    {
      characters.Add(newCharacter);
      return characters;
    }

    List<Character> ICharacterService.GetAllCharacters()
    {
      return characters;
    }

    Character ICharacterService.GetCharacterById(int id)
    {
      return characters.FirstOrDefault(c => c.Id == id);
    }
  }
}