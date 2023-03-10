using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using udemy_dotnet_webapi.Dtos.Skill;
using udemy_dotnet_webapi.Dtos.Weapon;

namespace udemy_dotnet_webapi.Dtos.Character
{
    public class GetCharacterResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int HitPoints { get; set; } = 100;
        public int Strenght { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; }  = RpgClass.Knight;
        public GetWeaponResponseDto? Weapon { get; set; }
        public List<GetSkillResponseDto>? Skills { get; set; }
    }
}