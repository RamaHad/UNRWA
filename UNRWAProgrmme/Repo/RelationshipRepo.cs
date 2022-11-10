using BackEnd;
using Dto.RelationshipsDto;
using IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class RelationshipRepo : RelationshipIRepo
    {
        private  ApplicationDBContext _context;
        public List<RelatioshipDto> GetRelationships()
        {
            try
            {
                _context = new ApplicationDBContext();
                var result = _context.relationships
                    .Select(i => new RelatioshipDto
                    {
                        Id = i.Id,
                        Name = i.Name
                    }).ToList();
                if (result != null) return result;
                else return new List<RelatioshipDto>();
            }
            catch
            {
                throw;
            }
            throw new NotImplementedException();
        }
    }
}
