using BackEnd;
using Dto.ServicesDto;
using IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class ServiceRepo : ServiceIRepo
    {
        private ApplicationDBContext _context;
        public List<ServiceDto> ClerckService()
        {
            _context = new ApplicationDBContext();
            var result =   _context.services
                                   .Where(s => s.Id != 5 && s.Id != 7)
                                   .Select(s => new ServiceDto
                                   {
                                       Id = s.Id,
                                       Name = s.Name
                                   }).ToList();
            if(result!= null) return result;
            else return new List<ServiceDto> { };
        } 
    }
}
