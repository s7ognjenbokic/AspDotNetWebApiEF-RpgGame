using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using udemy_dotnet_webapi.Dtos.Weapon;

namespace udemy_dotnet_webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> AddWeapon(AddWeaponRequestDto newWeapon)
        {
            var response = await _weaponService.AddWeapon(newWeapon);

            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}