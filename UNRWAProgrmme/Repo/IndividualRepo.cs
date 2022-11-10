using BackEnd;
using BackEnd.Entities;
using Dto.IndividualDto;
using Dto.ViewDto;
using IRepo;
using Microsoft.EntityFrameworkCore;

namespace Repo
{
    public class IndividualRepo : IndividualIRepo
    {
        ApplicationDBContext _context;

        public IndividualDto FindByCHRNumber(int CHRNumber)
        {
            _context = new ApplicationDBContext();

            //select info from ChildCard
           var result =  _context.childCards
                .Include(i => i.individual)
                .Include(rlationship => rlationship.individual.relatioship)
                .Include(father => father.individual)
                .Include(familyCard => familyCard.individual.familyRegestrationCard)
                .Include(orginalPlace => orginalPlace.individual.originalPlace)
                .Include(reg => reg.individual.residentialAddress)
                .Include(nationality => nationality.individual.nationality)
                .Where(c => c.Id == CHRNumber)
                .Select(i => new IndividualDto
                {
                    ID = i.IndivisualId,
                    FirstName = i.individual.FirstName,
                    LastName = i.individual.LastName,
                    FatherName = i.individual.individual.FirstName,
                    Relationship = i.individual.relatioship.Name,
                    Gender = i.individual.Gender,
                    FamilyCard = i.individual.familyRegestrationCard.CardNumber,
                    ResidentialAddress = i.individual.residentialAddress.Address,
                    Nationality = i.individual.nationality.Name,
                    CHR = i.Id
                }).SingleOrDefault();

            // select info from NCDCard
             if(result != null)
            {
                var NCDCard = _context.ncdCards.Where(c => c.IndividualId == result.ID).SingleOrDefault();
                if (NCDCard != null) result.NCD = NCDCard.Id;
                return result;
            }
            else
            {
                return new IndividualDto();
            }
        }

        public  List<IndividualDto> FindByFamilyCard(string familyCard)
        {
            _context = new ApplicationDBContext();
            var family=  _context.familyRegestrationCards.Where(t => t.CardNumber.Equals(familyCard)).ToList();
            
            if (family != null)
            {
                //select info from individiual
                var result =  _context.Individual

                    .Include(rlationship => rlationship.relatioship)
                    .Include(father => father.individual)
                    .Include(familyCard => familyCard.familyRegestrationCard)
                    .Include(orginalPlace => orginalPlace.originalPlace)
                    .Include(reg => reg.residentialAddress)
                    .Include(nationality => nationality.nationality)
                    .Where(t => t.familyRegestrationCard.CardNumber.Equals(familyCard))
                    .Select(i => new IndividualDto
                    {
                        ID = i.Id,
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        FatherName = i.individual.FirstName,
                        Relationship = i.relatioship.Name,
                        Gender = i.Gender,
                        FamilyCard = i.familyRegestrationCard.CardNumber,
                        ResidentialAddress = i.residentialAddress.Address,
                        Nationality = i.nationality.Name
                    })

                    .ToList();

                //select info from NCD 
                List<NCDCard> allNCDCard = new List<NCDCard>();
                allNCDCard = _context.ncdCards.Where(t => t.individual.familyRegestrationCard.CardNumber.Equals(familyCard)).ToList();
                for (int i = 0; i < result.Count; i++)
                {
                    for (int j = 0; j < allNCDCard.Count; j++)
                    {
                        if (result[i].ID == allNCDCard[j].IndividualId) result[i].NCD = allNCDCard[j].Id;
                    }
                }

                //select info fron CHR
                List<ChildCard> allChildCard = new List<ChildCard>();
                allChildCard = _context.childCards.Where(t => t.individual.familyRegestrationCard.CardNumber.Equals(familyCard)).ToList();
                for (int i = 0; i < result.Count; i++)
                {
                    for (int j = 0; j < allChildCard.Count; j++)
                    {
                        if (result[i].ID == allChildCard[j].IndivisualId && allChildCard[j].IsActive) result[i].CHR = allChildCard[j].Id;
                    }
                }
                return result;
            }
            else
            {
               return new List<IndividualDto>();
                
            }
        }

        public IndividualDto FindByIndividiualId(int individiualId)
        {
            _context = new ApplicationDBContext();
            
            //select info from individual
            var result = _context.Individual
                .Where(i => i.Id == individiualId)
                .Select(i => new IndividualDto
                {
                    ID = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    FatherName = i.individual.FirstName,
                    Relationship = i.relatioship.Name,
                    Gender = i.Gender,
                    FamilyCard = i.familyRegestrationCard.CardNumber,
                    ResidentialAddress = i.residentialAddress.Address,
                    Nationality = i.nationality.Name

                }).FirstOrDefault();

            //select info from ChildCard
            if (result != null)
            {
                
               var childCard  = _context.childCards.Where(t => t.IndivisualId == individiualId).FirstOrDefault();
               if (childCard!=null) result.CHR = childCard.Id;
               return result;
            }
            else
            {
                return new IndividualDto();
            }
            
        }

        public IndividualDto FindByNCDNumber(int NCDNumber)
        {
            _context = new ApplicationDBContext();

            //select info from NCDCard
            var result = _context.ncdCards
                    .Include(i => i.individual)
                    .Include(rlationship => rlationship.individual.relatioship)
                    .Include(father => father.individual)
                    .Include(familyCard => familyCard.individual.familyRegestrationCard)
                    .Include(orginalPlace => orginalPlace.individual.originalPlace)
                    .Include(reg => reg.individual.residentialAddress)
                    .Include(nationality => nationality.individual.nationality)
                    .Where(c => c.Id == NCDNumber)
                    .Select(i => new IndividualDto
                    {
                        ID = i.IndividualId,
                        FirstName = i.individual.FirstName,
                        LastName = i.individual.LastName,
                        FatherName = i.individual.individual.FirstName,
                        Relationship = i.individual.relatioship.Name,
                        Gender = i.individual.Gender,
                        FamilyCard = i.individual.familyRegestrationCard.CardNumber,
                        ResidentialAddress = i.individual.residentialAddress.Address,
                        Nationality = i.individual.nationality.Name,
                        NCD = i.Id
                    })
                    .SingleOrDefault();
 

            //select from ChildCard
            if(result != null)
            {
               var childCard= _context.childCards.Where(c => c.IndivisualId == result.ID).SingleOrDefault();
                if (childCard != null) result.CHR = childCard.Id;
                return result;
            }
            else
            {
                return new IndividualDto();
            }
        }

        public NamingDto GetInfoToEdit(int individualId)
        {
            _context = new ApplicationDBContext();

            try
            {
                var result = _context.Individual
                    .Where(i=> i.Id==individualId)
                    .Select(individual => new NamingDto
                    {
                        FullName = individual.FirstName + " " + individual.individual.FirstName + " " + individual.LastName,
                        Address = individual.residentialAddress.Address + "/" + individual.residentialAddress.area.Name,
                        StudyLevel = individual.studyLevel.Level,
                        PhoneNumber = individual.PhoneNumber,
                        Gender = individual.Gender,
                        MaritalStatus = individual.MaritalStatus,
                        RelationShip = individual.relatioship.Name,
                        Naming=individual.Naming,
                        IndividualId= individual.Id,
                        RelationshipName = individual.relatioship.Name,
                        StudyLevelName = individual.studyLevel.Level,
                        OldRelationshipId = individual.RelationShipId,
                        OldStudyLevelId = individual.StudyLevelId
                    }).FirstOrDefault();
                    
                    
                    if(result!=null)
                {
                    return result;
                }
                else
                {
                    return new NamingDto();
                }

            }
            catch
            {
                throw;
            }
        }
        public bool EditIndividual(EditIndividualDto dto)
        {
            _context = new ApplicationDBContext();
            try
            {
                var result = _context.Individual.FirstOrDefault(i => i.Id == dto.IndividualId);
                if (result != null)
                {
                    result.StudyLevelId = dto.StudyLevelId;
                    result.PhoneNumber = dto.PhoneNumber;
                    if(! dto.Naming.Equals(" "))
                    {
                        result.Naming = dto.Naming;

                    }
                    result.Gender = dto.Gender;
                    result.MaritalStatus = dto.MaritalStatus;
                    result.RelationShipId = dto.RelationShipId;
                    _context.Update(result);
                    _context.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch
            {
                throw;
            }
        }
       
    }
}
