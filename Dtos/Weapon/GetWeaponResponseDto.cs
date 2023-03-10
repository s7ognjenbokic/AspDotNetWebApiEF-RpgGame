using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_dotnet_webapi.Dtos.Weapon
{
    public class GetWeaponResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
    }
}