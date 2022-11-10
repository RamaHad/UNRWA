using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ViewDto
{
    public class EditIndividualDto
    {
        public int StudyLevelId { get; set; }
        public int IndividualId { get; set; }
        public string Naming { get; set; } //exp: arabic name
        public string PhoneNumber { get; set; }
        public bool MaritalStatus { get; set; }
        public bool Gender { get; set; }
        public int RelationShipId { get; set; }

    }
}
