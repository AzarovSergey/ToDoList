using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.Services.Mappers;

namespace Epam.Wunderlist.Services.Services
{
    public class FolderService : IFolderService
    {
        private readonly IUnitOfWork uow;
        private readonly IFolderRepository folderRepository;

        public FolderService(IUnitOfWork uow, IFolderRepository repository)
        {
            this.uow = uow;
            this.folderRepository = repository;
        }

        public void Create(FolderEntity folder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FolderEntity> GetByAuthorId(int authorId)
        {
            return folderRepository.GetByAuthorId(authorId).Select(folder => folder.ToBllFolder());
        }

        public FolderEntity GetById(int id)
        {
            return null;
            //return folderRepository.GetById(id);
        }
    }
}
