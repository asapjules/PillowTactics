﻿using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillowFight.BusinessServices
{
    public interface IPlayerBL
    {
        public Task CreatePlayerAsync(string p_username, string p_password, string p_email);

        Task<IPlayerCharacter> CreatePlayerCharacterAsync(int userId, string name, CharacterClassEnum characterClass);

        public Task<bool> DeletePlayerCharacterAsync(int userId, int characterId);

        public Task<IPlayer> GetPlayerAsync(string p_username, string p_password);

        public Task<IPlayerCharacter> GetPlayerCharacterAsync(int userId, int characterId);

        public Task<IEnumerable<IPlayerCharacter>> GetPlayerCharactersAsync(int userId);
    }
}
