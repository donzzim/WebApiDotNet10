using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.DTOs;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoGameCharactersController(IVideoGameCharacterService service) : Controller
{

    [HttpGet]
    public async Task<ActionResult<List<CharacterResponse>>> GetCharacters()
        => Ok(await service.GetAllCharactersAsync());

    [HttpGet("{characterId:int}")]
    public async Task<ActionResult<Character?>> GetCharacter(int characterId)
    {
        var character = await service.GetCharacterByIdAsync(characterId);

        return character is null? NotFound("Character with the given Id does not exists") : Ok(character);
    }

    [HttpPost]
    public async Task<ActionResult<CharacterResponse>> AddCharacter (CreateCharacterRequest character)
    {
        var createdCharacter = await service.AddCharacterAsync(character);
        return CreatedAtAction(nameof(GetCharacter), new {characterId = createdCharacter.Id}, createdCharacter);
    }

    [HttpPut("{characterId:int}")]
    public async Task<ActionResult> UpdateCharacter(int characterId,
        UpdateCharacterRequest character)
    {
        var  updatedCharacter = await service.UpdateCharacterAsync(characterId, character);
        return updatedCharacter ? NoContent() : NotFound("Character with the given Id does not exists");
    }

    [HttpDelete("{characterId:int}")]
    public async Task<ActionResult> DeleteCharacter(int characterId)
    {
        var deletedCharacter = await service.DeleteCharacterAsync(characterId);
        return deletedCharacter ? NoContent() : NotFound("Character with the given Id does not exists");
    }
}