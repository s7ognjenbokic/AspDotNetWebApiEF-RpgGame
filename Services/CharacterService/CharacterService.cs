using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_dotnet_webapi.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {   
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddNewCharacter(AddCharacterRequestDto newCharacter)
        {   
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            serviceResponse.Data = 
                await _context.Characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToListAsync();
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();

            try {
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id); 
                if (character is null)
                    throw new Exception($"Character with Id '{id}' not found");

                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data =
                    await _context.Characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();

            serviceResponse.Data = 
                await _context.Characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            
            if (character is not null)
            {
                serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);
                return serviceResponse;
            }

            serviceResponse.Success = false;
            serviceResponse.Message = "Character not found";

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();

            try {
                var character = 
                    await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id); 
                if (character is null)
                    throw new Exception($"Character with Id '{updatedCharacter.Id}' not found");

                _mapper.Map(updatedCharacter, character);

                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strenght = updatedCharacter.Strenght;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}