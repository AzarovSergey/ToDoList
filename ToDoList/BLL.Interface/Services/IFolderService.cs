using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IFolderService
    {
        void Create(FolderEntity folder);
        IEnumerable<FolderEntity> GetByAuthorId(int authorId);
        FolderEntity GetById(int id);
    }
}
