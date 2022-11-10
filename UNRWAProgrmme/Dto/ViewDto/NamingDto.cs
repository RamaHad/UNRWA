using Dto.RelationshipsDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ViewDto
{
    public class NamingDto
    {
        public int IndividualId { get; set; }
        public String FullName { get; set; }
        public string Address { get; set; }
        public string StudyLevel { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public bool MaritalStatus { get; set; }
        public string RelationShip { get; set; }
        public string Naming { get; set; } = " ";
        public string StudyLevelName { get; set; }
        public string RelationshipName { get; set; }
        public List<StudeyLevelsDto> studeyLevels { get; set; } = new List<StudeyLevelsDto>(); //to fill select
        public List<RelatioshipDto> relatioships { get; set; } = new List<RelatioshipDto>();

        public int NewStudyLevelId { get; set; } 
        public int NewRelationshipId { get; set; }
        public int OldRelationshipId { get; set; }
        public int OldStudyLevelId { get; set; }


    }
}
