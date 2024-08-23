using AutoMapper;
using FinSpotAPI.Application.Models.Operations;
using FinSpotAPI.Application.Services.Interfaces;
using FinSpotAPI.Common.Exceptions;
using FinSpotAPI.Domain.Models.Operations;
using FinSpotAPI.Domain.Repositories.Interfaces;

namespace FinSpotAPI.Application.Services
{
    public class OperationsService : IOperationsService
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;
        private readonly IOperationsRepository _operationsRepository;

        public OperationsService(
            IMapper mapper,
            IUsersRepository usersRepository,
            IOperationsRepository operationsRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _operationsRepository = operationsRepository
                ?? throw new ArgumentNullException(nameof(operationsRepository));
        }

        public async Task<OperationModel> AddAsync(OperationCreateModel operationCreateModel)
        {
            ArgumentNullException.ThrowIfNull(operationCreateModel, nameof(operationCreateModel));

            if (!await _usersRepository.ExistsByIdAsync(operationCreateModel.UserId))
            {
                throw new NotFoundException($"User with ID `{operationCreateModel.UserId}` does not exist.");
            }

            var newOperation = _mapper.Map<Operation>(operationCreateModel);

            var result = await _operationsRepository.AddAsync(newOperation);

            return _mapper.Map<OperationModel>(result);
        }
    }
}
