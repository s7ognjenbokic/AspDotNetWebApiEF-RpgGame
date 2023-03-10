using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_dotnet_webapi.Dtos.Skill
{
    public class GetSkillResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
    }
}