using AutoMapper;
using ITFCode.Core.Domain.Entities.Base.Interfaces;
using ITFCode.Core.Domain.Repositories.Interfaces;
using ITFCode.Core.DTO.Entities;
using ITFCode.Core.DTO.Entities.Base.Interfaces;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.DTO.FilterOptions.Base;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Reflection;

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


        public Task<IList<TEntityDTO>> GetPage1(QueryFilterOptions queryOptions, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<PageResult<TEntityDTO>> GetPage(QueryFilterOptions queryOptions, CancellationToken cancellationToken = default)
        {
            if (queryOptions == null)
                throw new ArgumentNullException("GetPage(queryOptions): parameter 'queryOptions' can not be null");

            var query = _repository.GetAll();

            query = ApplySpecialFiltering(query, queryOptions);
            query = ApplyFiltering(query, queryOptions);
            query = ApplySorting(query, queryOptions);

            var items = await query
                .Skip(queryOptions.Skip)
                .Take(queryOptions.Take)
                .AsNoTracking()
                .Select(x => Map(x))
                .ToListAsync();

            return new PageResult<TEntityDTO>
            {
                Total = await query.CountAsync(),
                Items = items,
            };
        }


        #endregion

        #region Protected Methods: 

        private IQueryable<TEntity> ApplyFiltering(IQueryable<TEntity> query, QueryFilterOptions queryOptions)
        {
            var filters = queryOptions.Filters;

            if (filters == null || !filters.Any()) return query;

            foreach (var groupedFilters in filters.GroupBy(a => a.PropertyName.ToLowerInvariant()))
            {
                Expression<Func<TEntity, bool>> orExpression = null;
                foreach (var filterInfo in groupedFilters)
                {
                    CheckFilter(filterInfo);
                    Expression<Func<TEntity, bool>> expr = null;

                    if (filterInfo is StringValueFilter stringFilter)
                        expr = new StringValueFilterHandler(stringFilter).Handle<TEntity>();

                    if (filterInfo is StringListFilter stringFilter)
                        expr = new StringListFilterHandler(stringFilter).Handle<TEntity>();

                    if (filterInfo is NumericValueFilter numericFilter)
                        expr = new NumericFilterHandler(numericFilter).Handle<TEntity>();

                    if (filterInfo is NumericListFilter numericFilter)
                        expr = new NumericFilterHandler(numericFilter).Handle<TEntity>();

                    if (filterInfo is NumericRangeFilter numericFilter)
                        expr = new NumericFilterHandler(numericFilter).Handle<TEntity>();

                    if (filterInfo is DateValueFilter dateListFilter)
                        expr = new DateListFilterHandler(dateListFilter).Handle<TEntity>();

                    if (filterInfo is DateListFilter dateListFilter)
                        expr = new DateListFilterHandler(dateListFilter).Handle<TEntity>();

                    if (filterInfo is DateRangeFilter dateRangeFilter)
                        expr = new DateRangeFilterHandler(dateRangeFilter).Handle<TEntity>();

                    if (filterInfo is GuidValueFilter guidFilter)
                        expr = new GuidFilterHandler(guidFilter).Handle<TEntity>();

                    if (filterInfo is GuidListFilter guidListFilter)
                        expr = new GuidListFilterHandler(guidListFilter).Handle<TEntity>();

                    if (filterInfo is NumericListFilter numericListFilter)
                        expr = new NumericListFilterHandler(numericListFilter).Handle<TEntity>();

                    if (filterInfo is StringListFilter stringListFilter)
                        expr = new StringListFilterHandler(stringListFilter).Handle<TEntity>();

                    if (expr != null)
                        orExpression = orExpression == null ? expr : orExpression.Or(expr);
                }

                if (orExpression != null)
                {
                    query = query.Where(orExpression);
                }
            }

            return query;
        }

        #endregion

        #region Protected Methods: Mapping 

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

        private static void CheckFilter(FilterOption filter)
        {
            var propertyName = filter.PropertyName.Split('.');
            PropertyInfo entityPropertyInfo = null;
            var type = typeof(TEntity);

            foreach (var part in propertyName)
            {
                entityPropertyInfo = type.GetProperty(part, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (entityPropertyInfo != null)
                {
                    type = entityPropertyInfo.PropertyType;
                }
                else
                {
                    break;
                }
            }

            if (entityPropertyInfo == null)
            {
                throw new ArgumentException($"Can not find '{filter.PropertyName}' property " + $"in '{typeof(TEntity).FullName}' entity type");
            }
        }

        #endregion
    }
}