using VideoGameCharacterApi.DTOs;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services;

public interface IVideoGameCharacterService
{
    Task<List<CharacterResponse>> GetAllCharactersAsync();
    Task<CharacterResponse?> GetCharacterByIdAsync(int characterId);
    Task<CharacterResponse> AddCharacterAsync(CreateCharacterRequest character);
    Task<bool> UpdateCharacterAsync(int characterId, UpdateCharacterRequest character);
    Task<bool> DeleteCharacterAsync(int characterId);
}