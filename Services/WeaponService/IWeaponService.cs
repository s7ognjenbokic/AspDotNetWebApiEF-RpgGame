using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using udemy_dotnet_webapi.Dtos.Weapon;

namespace udemy_dotnet_webapi.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterResponseDto>> AddWeapon(AddWeaponRequestDto newWeapon);
        
    }
} 