using System.Collections.Generic;
using System.Linq;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.Services.Interface.Mappers;

namespace Epam.Wunderlist.Services.Services
{
    public class FolderService : FolderServiceBase
    {
        public FolderService(FolderRepositoryBase repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {

        }

        public override IEnumerable<FolderEntity> GetByAuthorId(int authorId)
        {
            return repository.GetByAuthorId(authorId).Select(folder => mapper.Map<DalFolder, FolderEntity>(folder));
        }
    }
}
