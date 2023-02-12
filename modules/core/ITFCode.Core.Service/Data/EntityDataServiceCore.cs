using AutoMapper;
using ITFCode.Core.Domain.Entities.Base.Interfaces;
using ITFCode.Core.Domain.Repositories;
using ITFCode.Core.Domain.Repositories.Interfaces;
using ITFCode.Core.DTO.Entities.Base.Interfaces;
using ITFCode.Core.Service.Data.Base;

namespace ITFCode.Core.Service.Data
{
    public abstract class EntityDataServiceCore<TEntity, TEntityDTO, TUnitOfWork, TRepository> : DisposableBaseCore, IEntityDataServiceCore<TEntityDTO>
        where TEntity : class, IEntity
        where TEntityDTO : class, IEntityDTO
        where TUnitOfWork : class, IUnitOfWorkCore
        where TRepository : class, IEntityRepositoryCore<TEntity>
    {
        // protected ILogger<ReadOnlyDataService<TRepository, TEntity, TEntityModel, TKey>> _logger;
        protected IMapper _mapper;
        protected readonly TRepository _repository;
        protected readonly TUnitOfWork _unitOfWork;

        public EntityDataServiceCore(IMapper mapper, TUnitOfWork unitOfWork, TRepository repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        #region IEntityDataService Implementation

        public async Task<TEntityDTO> Get(object[] keys, CancellationToken cancellationToken = default)
            => Map(await _repository.Get(keys, cancellationToken));

        public virtual async Task<IEnumerable<TEntityDTO>> GetAll(CancellationToken cancellationToken = default)
            => Map(await _repository.GetAll().Take(100).ToArray());

        #endregion

        #region Protected Methods 

        protected TEntityDTO Map(TEntity entity) => _mapper.Map<TEntityDTO>(entity);
        protected TEntity Map(TEntityDTO model) => _mapper.Map<TEntity>(model);
        protected IEnumerable<TEntity> Map(IEnumerable<TEntityDTO> entities) => _mapper.Map<IEnumerable<TEntity>>(entities);
        protected IEnumerable<TEntityDTO> Map(IEnumerable<TEntity> entities) => _mapper.Map<IEnumerable<TEntityDTO>>(entities);

        #endregion

    }

}
