using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.IndividualDto
{
    public class IndividualDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Relationship { get; set; }
        public bool Gender { get; set; }
        public int NCD { get; set; }
        public int CHR { get; set; }
        public string FamilyCard { get; set; }
        public string ResidentialAddress { get; set; }
        public string Nationality { get; set; }
    }
}
