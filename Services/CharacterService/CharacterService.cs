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

        public async Task<List<Character>> AddNewCharacter(Character character)
        {
            characters.Add(character);
            
            return characters;
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            return characters;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);

            if(character is not null)
                return character;

            throw new BadHttpRequestException("Character not found");
        }
    }
}