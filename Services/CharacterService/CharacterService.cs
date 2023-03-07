using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_dotnet_webapi.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {   
        private static List<Character> characters = new List<Character> {
            new Character {
                Name = "Frodo"
            },
            new Character {
                Name = "Gandalf",
                Class = RpgClass.Mage
            }
        };

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddNewCharacter(AddCharacterRequestDto newCharacter)
        {   
            var serviceResponse = new ServiceResponse<List<Character>>();
            characters.Add(newCharacter);
            serviceResponse.Data = characters;
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = characters;

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            
            if (character is not null)
            {
                serviceResponse.Data = character;
                return serviceResponse;
            }

            serviceResponse.Success = false;
            serviceResponse.Message = "Character not found";

            return serviceResponse;
        }
    }
}