using MosCore.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MosCore.Application.Features.Devices.Commands.Update
{
    public class UpdateDeviceCommand : IRequest<Result<int>>
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
        public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IDeviceRepository _deviceRepository;

            public UpdateDeviceCommandHandler(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork)
            {
                _deviceRepository = deviceRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateDeviceCommand command, CancellationToken cancellationToken)
            {
                var device = await _deviceRepository.GetByIdAsync(command.Id);

                if (device == null)
                {
                    return Result<int>.Fail($"Device Not Found.");
                }
                else
                {
                    device.OS = command.OS ?? device.OS;
                    device.Imei = command.Imei ?? device.Imei;
                    device.SerialNo = command.SerialNo ?? device.SerialNo;
                    device.Model = command.Model ?? device.Model;
                    device.DeviceId = command.DeviceId ?? device.DeviceId;
                    device.Brand = command.Brand ?? device.Brand;
                    device.Manufacturer = command.Manufacturer ?? device.Manufacturer;
                    device.Hardware = command.Hardware;
                    device.DeviceToken = command.DeviceToken ?? device.DeviceToken;
                    device.FCMToken = command.FCMToken ?? device.FCMToken;

                    await _deviceRepository.UpdateAsync(device);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(device.Id, "success");
                }
            }
        }
    }
}