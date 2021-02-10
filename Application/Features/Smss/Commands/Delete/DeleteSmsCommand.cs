using MosCore.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MosCore.Application.Features.Smss.Commands.Delete
{
    public class DeleteSmsCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteSmsCommandHandler : IRequestHandler<DeleteSmsCommand, Result<int>>
        {
            private readonly ISmsRepository _smsRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteSmsCommandHandler(ISmsRepository smsRepository, IUnitOfWork unitOfWork)
            {
                _smsRepository = smsRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteSmsCommand command, CancellationToken cancellationToken)
            {
                var sms = await _smsRepository.GetByIdAsync(command.Id);
                await _smsRepository.DeleteAsync(sms);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(sms.Id, "success");
            }
        }
    }
}