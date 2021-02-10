using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using MediatR;

namespace Application.Features.FileUpload.Commands.Create
{
 
    public partial class CreateFileUploadCommand : IRequest<Result<int>>
    {
        public string DeviceId { get; set; }
        public string FileName { get; set; }
    }
}
