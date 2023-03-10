using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_dotnet_webapi.Dtos.Character
{
    public class AddCharacterSkillRequestDto
    {
        public int CharacterId { get; set; }
        public int SkillId { get; set; }
    }
}