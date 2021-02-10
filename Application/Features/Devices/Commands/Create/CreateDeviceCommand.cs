using MosCore.Application.Interfaces.Repositories;
using MosCore.Domain.Entities.Catalog;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MosCore.Domain.Entities.Device;

namespace MosCore.Application.Features.Devices.Commands.Create
{
    public partial class CreateDeviceCommand : IRequest<Result<int>>
    {

        public int Id { get; set; }
        public string DeviceId { get; set; }
        public string OS { get; set; }
        public string Imei { get; set; }

        public string Phone { get; set; }

        public string PrimaryPhone { get; set; }

        public string Brand { get; set; }

        public string SerialNo { get; set; }

        public string AssignedOperator { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }
        public string DeviceToken { get; set; }
        public string FCMToken { get; set; }

        public bool Hardware { get; set; }
    }

    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, Result<int>>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateDeviceCommandHandler(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = _mapper.Map<Device>(request);
            await _deviceRepository.InsertAsync(device);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(device.Id, "success");
        }
    }
}