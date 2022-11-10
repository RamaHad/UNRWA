using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class Individual
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Naming { get; set; } //exp: arabic name
        public string PhoneNumber { get; set; }
        public bool MaritalStatus { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirthday { get; set; }

        public int FatherId { get; set; }
        public Individual individual { get; set; }

        public int RelationShipId { get; set; }
        public Relationship relatioship { get; set; }

        public int FamilyRegestrationCardId { get; set; }
        public FamilyRegestrationCard familyRegestrationCard { get; set; }

        public int ResidentialAddressId { get; set; }
        public ResidentialAddress residentialAddress { get; set; }

        public int OriginalPlaceId { get; set; }
        public OriginalPlace originalPlace { get; set; }

        public int NationalityId { get; set; }
        public Nationality nationality { get; set; }

        public int StudyLevelId { get; set; }
        public StudyLevel studyLevel { get; set; }

    }
}
