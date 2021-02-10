using MosCore.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MosCore.Application.Features.Devices.Commands.Delete
{
    public class DeleteDeviceCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand, Result<int>>
        {
            private readonly IDeviceRepository _deviceRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteDeviceCommandHandler(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork)
            {
                _deviceRepository = deviceRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteDeviceCommand command, CancellationToken cancellationToken)
            {
                var product = await _deviceRepository.GetByIdAsync(command.Id);
                await _deviceRepository.DeleteAsync(product);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(product.Id, "success");
            }
        }
    }
}