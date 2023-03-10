using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_dotnet_webapi.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterResponseDto>>> AddNewCharacter(AddCharacterRequestDto newCharacter);
        Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto updatedCharacter);
        Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacter(int id);
        Task<ServiceResponse<GetCharacterResponseDto>> AddCharacterSkill(AddCharacterSkillRequestDto newCharacterSkill); 
    }
}