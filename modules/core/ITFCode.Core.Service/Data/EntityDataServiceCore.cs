using AutoMapper;
using ITFCode.Core.Domain.Entities.Base.Interfaces;
using ITFCode.Core.Domain.Repositories.Interfaces;
using ITFCode.Core.DTO.Entities.Base.Interfaces;
using ITFCode.Core.Service.Data.Base.Interfaces;
using Microsoft.Extensions.Logging;

namespace ITFCode.Core.Service.Data
{
    public abstract class EntityDataServiceCore<TEntity, TEntityDTO, TUnitOfWork, TRepository> : DisposableBaseCore, IEntityDataServiceCore<TEntityDTO>
        where TEntity : class, IEntity
        where TEntityDTO : class, IEntityDTO
        where TUnitOfWork : class, IUnitOfWorkCore
        where TRepository : class, IEntityRepositoryCore<TEntity>
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger<EntityDataServiceCore<TEntity, TEntityDTO, TUnitOfWork, TRepository>> _logger;
        protected readonly TRepository _repository;
        protected readonly TUnitOfWork _unitOfWork;

        public EntityDataServiceCore(IMapper mapper,
            ILogger<EntityDataServiceCore<TEntity, TEntityDTO, TUnitOfWork, TRepository>> logger,
            TUnitOfWork unitOfWork, TRepository repository)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        #region IEntityDataService Implementation

        public virtual async Task<TEntityDTO> Get(object[] keys, CancellationToken cancellationToken = default)
            => Map(await _repository.Find(keys, cancellationToken));

        public virtual async Task<IEnumerable<TEntityDTO>> GetAll(CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        #endregion

        #region Protected Methods 

        protected TEntityDTO Map(TEntity entity) => _mapper.Map<TEntityDTO>(entity);
        protected TEntity Map(TEntityDTO model) => _mapper.Map<TEntity>(model);
        protected IEnumerable<TEntity> Map(IEnumerable<TEntityDTO> entities) => _mapper.Map<IEnumerable<TEntity>>(entities);
        protected IEnumerable<TEntityDTO> Map(IEnumerable<TEntity> entities) => _mapper.Map<IEnumerable<TEntityDTO>>(entities);

        #endregion
    }
}