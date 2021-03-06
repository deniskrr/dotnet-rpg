using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Models;
using dotnet_rpg.Services;
using dotnet_rpg.Services.Dtos.Character;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CharacterController : ControllerBase
  {
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
      this._characterService = characterService;
    }

    [HttpGet("GetAll")]
    async public Task<IActionResult> GetAllCharacters()
    {
      return Ok(await _characterService.GetAllCharacters());
    }

    [HttpGet("{id}")]
    async public Task<IActionResult> GetCharacterById(int id)
    {
      return Ok(await _characterService.GetCharacterById(id));
    }

    [HttpPost]
    async public Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
    {
      return Ok(await _characterService.AddCharacter(newCharacter));
    }

    [HttpPut]
    async public Task<IActionResult> UpdateCharacter(UpdateCharacterDto updateCharacter)
    {
      ServiceResponse<GetCharacterDto> serviceResponse = await _characterService.UpdateCharacter(updateCharacter);
      if (serviceResponse.Data == null)
      {
        return NotFound(serviceResponse);
      }
      else
      {
        return Ok(serviceResponse);
      }
    }
  }
}