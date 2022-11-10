using BackEnd;
using Dto;
using IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class StudyLevelRepo : StudyLevelIRepo
    {
        private ApplicationDBContext _context;
        public List<StudeyLevelsDto> GetStudyLevels()
        {
            try
            {
                _context = new ApplicationDBContext();
                var result = _context.studyLevels
                    .Select(n => new StudeyLevelsDto
                    {
                        Id= n.Id,
                        Name =n.Level
                    })
                    .ToList();
                if (result != null) return result;
                else return new List<StudeyLevelsDto>();
            }
            catch
            {
                throw;
            }
            throw new NotImplementedException();
        }
    }
}
