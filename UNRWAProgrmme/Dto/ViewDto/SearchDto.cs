using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ViewDto
{
    public  class SearchDto
    {
        //to serch by family Card
        public List<IndividualDto.IndividualDto> individualDtos { get; set; }
        public string familyCard { get; set; }

        //to search by individualId
        public int IndividualId { get; set; }
        public IndividualDto.IndividualDto individualDto { get; set; } 

        //to search by NCDCard
        public int NCDNumber { get; set; }

        //to search by CHRCard
        public int CHRNumber { get; set; }


    }
}
