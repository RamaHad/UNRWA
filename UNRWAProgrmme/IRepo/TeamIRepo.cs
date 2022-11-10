using Dto.TeamsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepo
{
    public interface TeamIRepo
    {
        public List<TeamDto> GetTeams();
    }
}
