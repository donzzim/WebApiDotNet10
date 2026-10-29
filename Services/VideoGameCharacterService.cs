using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.DTOs;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services;

public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
{
    //private readonly AppDbContext  _context;

    //public VideoGameCharacterService(AppDbContext context)
    //{
    //    _context = context;
    //}

    public async Task<List<CharacterResponse>> GetAllCharactersAsync()
        => await context.Characters.Select(c => new CharacterResponse
        {
            Id = c.Id,
            Name = c.Name,
            Game = c.Game,
            Role = c.Role,
        }).ToListAsync();

    public async Task<CharacterResponse?> GetCharacterByIdAsync(int characterId)
    {
        return await context.Characters
            .Where(c => c.Id == characterId)
            .Select(c => new CharacterResponse
            {
                Id = c.Id,
                Name = c.Name,
                Game = c.Game,
                Role = c.Role,
            }).FirstOrDefaultAsync();
    }

    public async Task<CharacterResponse> AddCharacterAsync(CreateCharacterRequest character)
    {
        var newCharacter = new Character
        {
            Name = character.Name,
            Game = character.Game,
            Role = character.Role,
        };

        context.Characters.Add(newCharacter);
        await context.SaveChangesAsync();

        return new CharacterResponse
        {
            Id = newCharacter.Id,
            Name = newCharacter.Name,
            Game = newCharacter.Game,
            Role = newCharacter.Role,
        };
    }

    public async Task<bool> UpdateCharacterAsync(int characterId, UpdateCharacterRequest character)
    {
        var existingCharacter = await context.Characters
            .Where(c => c.Id == characterId)
            .FirstOrDefaultAsync();

        if (existingCharacter == null)
        {
            return false;
        }

        existingCharacter.Name = character.Name;
        existingCharacter.Game = character.Game;
        existingCharacter.Role = character.Role;

        context.Characters.Update(existingCharacter);
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteCharacterAsync(int characterId)
    {
        var characterToDelete = await context.Characters
            .Where(c => c.Id == characterId)
            .FirstOrDefaultAsync();

        if (characterToDelete == null)
        {
            return false;
        }

        context.Characters.Remove(characterToDelete);
        await context.SaveChangesAsync();

        return true;
    }
}