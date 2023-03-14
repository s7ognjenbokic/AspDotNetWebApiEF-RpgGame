using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_dotnet_webapi.Dtos.Fight
{
    public class FightResultDto
    {
        public List<string> Log { get; set; } = new List<string>();
    }
}