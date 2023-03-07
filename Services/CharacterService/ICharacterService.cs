using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_dotnet_webapi.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetAllCharacters();
        Task<ServiceResponse<Character>> GetCharacterById(int id);
        Task<ServiceResponse<List<Character>>> AddNewCharacter(Character character);
    }
}