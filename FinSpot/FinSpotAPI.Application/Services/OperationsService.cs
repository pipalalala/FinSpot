using AutoMapper;
using FinSpotAPI.Application.Models.Operations;
using FinSpotAPI.Application.Services.Interfaces;
using FinSpotAPI.Domain.Models.Operations;
using FinSpotAPI.Domain.Repositories.Interfaces;
using FinSpotAPI.Infrastructure.Services.Interfaces;

namespace FinSpotAPI.Application.Services
{
    public class OperationsService : IOperationsService
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IOperationsRepository _operationsRepository;

        public OperationsService(
            IMapper mapper,
            IUsersRepository usersRepository,
            ICurrentUserProvider currentUserProvider,
            IOperationsRepository operationsRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _currentUserProvider = currentUserProvider
                ?? throw new ArgumentNullException(nameof(currentUserProvider));
            _operationsRepository = operationsRepository
                ?? throw new ArgumentNullException(nameof(operationsRepository));
        }

        public async Task<OperationModel> AddAsync(OperationCreateModel operationCreateModel)
        {
            ArgumentNullException.ThrowIfNull(operationCreateModel, nameof(operationCreateModel));

            var currentUserId = await _currentUserProvider.GetCurrentUserIdAsync();

            var newOperation = _mapper.Map<Operation>(operationCreateModel);
            newOperation.UserId = currentUserId;

            var result = await _operationsRepository.AddAsync(newOperation);

            return _mapper.Map<OperationModel>(result);
        }

        public async Task<IEnumerable<OperationModel>> GetByUserIdAsync()
        {
            var currentUserId = await _currentUserProvider.GetCurrentUserIdAsync();

            var operations = await _operationsRepository.GetByUserIdAsync(currentUserId);

            return _mapper.Map<IEnumerable<OperationModel>>(operations);
        }
    }
}
