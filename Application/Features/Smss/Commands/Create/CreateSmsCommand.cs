using MosCore.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using AutoMapper;
using Domain.Entities.Sms;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Features.Smss.Command.Create
{
   public partial class CreateSmsCommand : IRequest<Result<int>>
    {
        public string SenderNumber { get; set; }
        public string SenderText { get; set; }
        public int DeviceId { get; set; }
    }

    public class CreateSmsCommandHandler : IRequestHandler<CreateSmsCommand, Result<int>>
    {
        private readonly ISmsRepository _smsRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateSmsCommandHandler(ISmsRepository smsRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _smsRepository = smsRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateSmsCommand request, CancellationToken cancellationToken)
        {
            var sms = _mapper.Map<Sms>(request);
            await _smsRepository.InsertAsync(sms);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(sms.Id, "success");
        }
    }
}
