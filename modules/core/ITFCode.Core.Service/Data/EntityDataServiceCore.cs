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
        #region Private & Protected Fields 

        private readonly IMapper _mapper;
        private readonly ILogger<EntityDataServiceCore<TEntity, TEntityDTO, TUnitOfWork, TRepository>> _logger;
        private readonly TRepository _repository;
        private readonly TUnitOfWork _unitOfWork;

        #endregion

        #region Protected Properties 

        protected IMapper Mapper => _mapper ?? throw new NullReferenceException("Mapper Service not defined");
        protected ILogger<EntityDataServiceCore<TEntity, TEntityDTO, TUnitOfWork, TRepository>> Logger => _logger ?? throw new NullReferenceException("Logger Service not defined");
        protected TRepository Repository => _repository ?? throw new NullReferenceException("Repository Service not defined");
        protected TUnitOfWork UnitOfWork => _unitOfWork ?? throw new NullReferenceException("UnitOfWork Service not defined");

        #endregion

        #region Constructros 

        protected EntityDataServiceCore(ILogger<EntityDataServiceCore<TEntity, TEntityDTO, TUnitOfWork, TRepository>> logger,
            IMapper mapper,
            TUnitOfWork unitOfWork,
            TRepository repository)
        {
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
            ArgumentNullException.ThrowIfNull(mapper, nameof(mapper));
            ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        #endregion

        #region IEntityDataService Implementation

        public virtual async Task<TEntityDTO> Get(object[] keys, CancellationToken cancellationToken = default)
            => Map(await Repository.Find(keys, cancellationToken));

        public virtual async Task<IEnumerable<TEntityDTO>> GetAll(CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        #endregion

        #region Protected Methods 

        protected TEntityDTO Map(TEntity entity) => Mapper.Map<TEntityDTO>(entity);

        protected TEntity Map(TEntityDTO model) => Mapper.Map<TEntity>(model);

        protected IEnumerable<TEntity> MapRange(IEnumerable<TEntityDTO> dtos)
        {
            return Mapper.Map<IEnumerable<TEntity>>(dtos);
        }

        protected IEnumerable<TEntityDTO> MapRange(IEnumerable<TEntity> entities)
        {
            return MapRange<IEnumerable<TEntity>, IEnumerable<TEntityDTO>, TEntity, TEntityDTO>(entities);
        }

        private TCollectionOut MapRange<TCollectionIn, TCollectionOut, TIn, TOut>(TCollectionIn items)
            where TCollectionIn : IEnumerable<TIn>
            where TCollectionOut : IEnumerable<TOut>
            where TIn : class
            where TOut : class
        {
            return Mapper.Map<TCollectionOut>(items);
        }

        #endregion
    }
}