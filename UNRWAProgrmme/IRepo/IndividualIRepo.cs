using BackEnd.Entities;
using Dto.IndividualDto;
using Dto.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepo
{
    public interface IndividualIRepo
    {
        public List<IndividualDto> FindByFamilyCard(string familyCard);
        public IndividualDto FindByIndividiualId(int individiualId);
        public IndividualDto FindByNCDNumber(int NCDNumber);
        public IndividualDto FindByCHRNumber(int CHRNumber);
        public NamingDto GetInfoToEdit(int individualId);
        public bool EditIndividual(EditIndividualDto dto);

    }
}
