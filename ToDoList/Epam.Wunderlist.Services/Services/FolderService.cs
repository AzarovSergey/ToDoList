using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.Services.Mappers;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;

namespace Epam.Wunderlist.Services.Services
{
    public class FolderService : FolderServiceBase
    {
        public override IEnumerable<FolderEntity> GetByAuthorId(int authorId)
        {
            return repository.GetByAuthorId(authorId).Select(folder => mapper.Map<DalFolder, FolderEntity>(folder));
        }
    }
}
