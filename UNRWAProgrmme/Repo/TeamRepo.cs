using BackEnd;
using Dto.TeamsDto;
using IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class TeamRepo : TeamIRepo
    {
        private ApplicationDBContext _context;
        public List<TeamDto> GetTeams()
        {
            _context = new ApplicationDBContext();
            var result = _context.teams
                .Select(t => new TeamDto
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList();
           if (result!=null)  return result;
           else return new List<TeamDto>();
           
        }
    }
}
