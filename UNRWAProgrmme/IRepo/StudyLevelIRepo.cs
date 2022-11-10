using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepo
{
    public interface StudyLevelIRepo
    {
        public List<StudeyLevelsDto> GetStudyLevels();
    }
}
