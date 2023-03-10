using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using udemy_dotnet_webapi.Dtos.Weapon;

namespace udemy_dotnet_webapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterResponseDto>();
            CreateMap<AddCharacterRequestDto, Character>();
            CreateMap<Weapon, GetWeaponResponseDto>();
        }
    }
}