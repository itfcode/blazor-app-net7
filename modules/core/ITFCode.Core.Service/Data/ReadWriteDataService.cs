using AutoMapper;
using ITFCode.Core.Domain.Entities.Base.Interfaces;
using ITFCode.Core.Domain.Repositories.Interfaces;
using ITFCode.Core.DTO.Entities.Base.Interfaces;
using ITFCode.Core.Service.Data.Interfaces;
using Microsoft.Extensions.Logging;

namespace ITFCode.Core.Service.Data
{
    public class ReadWriteDataService<TEntity, TEntityDTO, TUnitOfWork, TRepository> : ReadDataService<TEntity, TEntityDTO, TRepository>, IReadWriteDataService<TEntityDTO>
        where TEntity : class, IEntity
        where TUnitOfWork : class, IUnitOfWorkCore
        where TEntityDTO : class, IEntityDTO
        where TRepository : class, IEntityRepositoryCore<TEntity>
    {
        #region Private Fields

        private readonly TUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        protected ReadWriteDataService(
            ILogger<ReadWriteDataService<TEntity, TEntityDTO, TUnitOfWork, TRepository>> logger,
            IMapper mapper,
            TUnitOfWork unitOfWork,
            TRepository repository) : base(logger: logger, mapper: mapper, repository: repository)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        #endregion
    }
}