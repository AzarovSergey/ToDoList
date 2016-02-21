using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Repository;
using BLL.Mappers;

namespace BLL.Services
{
    public class FolderService : IFolderService
    {
        private readonly IUnitOfWork uow;
        //private readonly IFolderRepository folderRepository;

        public FolderService(IUnitOfWork uow/*, IFolderRepository repository*/)
        {
            this.uow = uow;
            //this.folderRepository = repository;
        }

        public void Create(FolderEntity folder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FolderEntity> GetByAuthorId(int authorId)
        {
            throw new NotImplementedException();
        }
    }
}
