using AutoMapper;
using ITFCode.Core.Domain.Entities.Base.Interfaces;
using ITFCode.Core.Domain.Repositories.Interfaces;
using ITFCode.Core.DTO.Entities.Base.Interfaces;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.Interfaces;
using Microsoft.Extensions.Logging;

namespace ITFCode.Core.Service.Data
{
    public abstract class ReadDataService<TEntity, TEntityDTO, TRepository> : DisposableBaseCore, IReadDataService<TEntityDTO>
        where TEntity : class, IEntity
        where TEntityDTO : class, IEntityDTO
        where TRepository : class, IEntityRepositoryCore<TEntity>
    {
        #region Private Fields 

        private readonly IMapper _mapper;
        private readonly ILogger<ReadDataService<TEntity, TEntityDTO, TRepository>> _logger;
        private readonly TRepository _repository;

        #endregion

        #region Protected Properties 

        protected IMapper Mapper => _mapper ?? throw new NullReferenceException("Mapper Service not defined");
        protected ILogger<ReadDataService<TEntity, TEntityDTO, TRepository>> Logger => _logger ?? throw new NullReferenceException("Logger Service not defined");
        protected TRepository Repository => _repository ?? throw new NullReferenceException("Repository Service not defined");

        #endregion

        #region Constructors 

        protected ReadDataService(
            ILogger<ReadDataService<TEntity, TEntityDTO, TRepository>> logger,
            IMapper mapper,
            TRepository repository)
        {
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
            ArgumentNullException.ThrowIfNull(mapper, nameof(mapper));
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        #endregion

        #region Public Methods : IReadDataService Implementation

        public virtual async Task<TEntityDTO> Get(object[] keys, CancellationToken cancellationToken = default)
            => Map(await Repository.Find(keys, cancellationToken));

        public virtual async Task<TEntityDTO> Get(object key, CancellationToken cancellationToken = default)
            => Map(await Repository.Find(key, cancellationToken));

        public Task<IList<TEntityDTO>> GetPage(QueryFilterOptions queryOptions, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Protected Methods 

        protected TEntityDTO Map(TEntity entity) => Mapper.Map<TEntityDTO>(entity);

        protected TEntity Map(TEntityDTO model) => Mapper.Map<TEntity>(model);

        protected TCollection MapRange<TCollection, TCollectionDTO>(TCollectionDTO dtos)
            where TCollection : IEnumerable<TEntity>
            where TCollectionDTO : IEnumerable<TEntityDTO>
        {
            return Mapper.Map<TCollection>(dtos);
        }

        protected TCollectionDTO MapRange<TCollection, TCollectionDTO>(TCollection entities)
            where TCollection : IEnumerable<TEntity>
            where TCollectionDTO : IEnumerable<TEntityDTO>
        {
            return Mapper.Map<TCollectionDTO>(entities);
        }

        #endregion

        #region Private Methods 
        #endregion
    }
}