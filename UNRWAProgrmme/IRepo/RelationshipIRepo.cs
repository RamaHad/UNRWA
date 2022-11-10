using Dto.RelationshipsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepo
{
    public interface RelationshipIRepo
    {
        public List<RelatioshipDto> GetRelationships();
    }
}
