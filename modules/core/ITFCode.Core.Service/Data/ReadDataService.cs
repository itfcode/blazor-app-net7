using AutoMapper;
using ITFCode.Core.Domain.Entities.Base.Interfaces;
using ITFCode.Core.Domain.Repositories.Interfaces;
using ITFCode.Core.DTO.Entities.Base.Interfaces;
using ITFCode.Core.DTO.Entities;
using ITFCode.Core.DTO.FilterOptions.Base;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Data.Interfaces;
using ITFCode.Core.Service.Extensions;
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

            var query = GetQueryable();

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

        protected virtual IQueryable<TEntity> ApplySorting(IQueryable<TEntity> queryable, QueryFilterOptions queryOptions)
        {
            ArgumentNullException.ThrowIfNull(queryable, nameof(queryable));
            ArgumentNullException.ThrowIfNull(queryOptions, nameof(queryOptions));

            try
            {
                string sortField = queryOptions?.SortField;

                if (string.IsNullOrWhiteSpace(sortField))
                    return queryable;

                bool isAsc = queryOptions.IsAsc;

                var item = Expression.Parameter(typeof(TEntity), "item");
                var property = GetProperty(item, sortField);
                var lambda = Expression.Lambda(property, item);

                // ReSharper disable once ReplaceWithSingleCallToSingle
                var method = typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                    .Where(a => a.Name == $"OrderBy{(isAsc ? string.Empty : "Descending")}")
                    .Where(a => a.GetParameters().Length == 2)
                    .Single();

                method = method.MakeGenericMethod(new[] { typeof(TEntity), property.Type });

                return (IQueryable<TEntity>)method.Invoke(method, new object[] { queryable, lambda });
            }
            catch
            {
                return queryable;
            }
        }

        protected virtual IQueryable<TEntity> ApplySpecialFiltering(IQueryable<TEntity> query, QueryFilterOptions queryOptions)
        {
            ArgumentNullException.ThrowIfNull(query, nameof(query));

            return query;
        }

        private IQueryable<TEntity> ApplyFiltering(IQueryable<TEntity> query, QueryFilterOptions queryOptions)
        {
            ArgumentNullException.ThrowIfNull(query, nameof(query));
            ArgumentNullException.ThrowIfNull(queryOptions, nameof(queryOptions));

            var filters = queryOptions.Filters;

            if (filters == null || !filters.Any())
                return query;

            foreach (var groupedFilters in filters.GroupBy(a => a.PropertyName.ToLowerInvariant()))
            {
                Expression<Func<TEntity, bool>> orExpression = null;
                foreach (var filterInfo in groupedFilters)
                {
                    CheckFilter(filterInfo);
                    Expression<Func<TEntity, bool>> expr = null;

                    if (filterInfo is StringValueFilter stringValueFilter)
                        expr = new StringValueFilterHandler(stringValueFilter).Handle<TEntity>();

                    if (filterInfo is StringListFilter stringListFilter)
                        expr = new StringListFilterHandler(stringListFilter).Handle<TEntity>();

                    if (filterInfo is NumericValueFilter numericValueFilter)
                        expr = new NumericValueFilterHandler(numericValueFilter).Handle<TEntity>();

                    if (filterInfo is NumericListFilter numericListFilter)
                        expr = new NumericListFilterHandler(numericListFilter).Handle<TEntity>();

                    if (filterInfo is NumericRangeFilter numericRangeFilter)
                        expr = new NumericRangeFilterHandler(numericRangeFilter).Handle<TEntity>();

                    if (filterInfo is DateValueFilter dateValueFilter)
                        expr = new DateValueFilterHandler(dateValueFilter).Handle<TEntity>();

                    if (filterInfo is DateListFilter dateListFilter)
                        expr = new DateListFilterHandler(dateListFilter).Handle<TEntity>();

                    if (filterInfo is DateRangeFilter dateRangeFilter)
                        expr = new DateRangeFilterHandler(dateRangeFilter).Handle<TEntity>();

                    if (filterInfo is GuidValueFilter guidFilter)
                        expr = new GuidValueFilterHandler(guidFilter).Handle<TEntity>();

                    if (filterInfo is GuidListFilter guidListFilter)
                        expr = new GuidListFilterHandler(guidListFilter).Handle<TEntity>();

                    if (expr != null)
                        orExpression = orExpression == null ? expr : orExpression.CombineOr(expr);
                }

                if (orExpression != null)
                    query = query.Where(orExpression);
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

        protected virtual IQueryable<TEntity> GetQueryable() => Repository.GetAll();

        private MemberExpression GetProperty(ParameterExpression item, string propertyName)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));
            ArgumentNullException.ThrowIfNull(propertyName, nameof(propertyName));

            MemberExpression? res = default;

            var properties = propertyName.Split('.');
            foreach (var property in properties)
            {
                if (res == null)
                    res = Expression.Property(item, property);
                else
                    res = Expression.Property(res, property);
            }

            return res ?? throw new NullReferenceException($"Cannot define an expression for property '{propertyName}'");
        }

        #endregion
    }
}