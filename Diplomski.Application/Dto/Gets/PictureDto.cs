using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.Dto.Gets
{
    public class PictureDto : BaseDto
    {
        public string Path { get; set; }
        public int ModelVersionId { get; set; }
        public string ModelVersionName { get; set; }


    }
}
