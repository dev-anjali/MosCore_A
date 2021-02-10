using MosCore.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MosCore.Application.Features.Smss.Commands.Update
{
    public class UpdateSmsCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string SenderNumber { get; set; }
        public string SenderText { get; set; }
        public int DeviceId { get; set; }

        public class UpdateSmsCommandHandler : IRequestHandler<UpdateSmsCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ISmsRepository _smsRepository;

            public UpdateSmsCommandHandler(ISmsRepository smsRepository, IUnitOfWork unitOfWork)
            {
                _smsRepository = smsRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateSmsCommand command, CancellationToken cancellationToken)
            {
                var sms = await _smsRepository.GetByIdAsync(command.Id);

                if (sms == null)
                {
                    return Result<int>.Fail($"Sms Not Found.");
                }
                else
                {
                    sms.SenderNumber = command.SenderNumber ?? sms.SenderNumber;
                    sms.SenderText = command.SenderText ?? sms.SenderText;
                    sms.DeviceId = command.DeviceId;                 
                    await _smsRepository.UpdateAsync(sms);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(sms.Id, "success");
                }
            }
        }
    }
}