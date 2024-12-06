using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Application.Dto.Creates
{
    public class CreatePictureDto
    {
        public int ModelVersionId { get; set; }
        public IFormFile PicturePath { get; set; }

    }
}
