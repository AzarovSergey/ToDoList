using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Security;
using System.Web.Mvc;
using MvcPL.ViewModels;
using System.Web.Security;
using BLL.Interface.Services;
using MvcPL.Models;
using BLL.Interface.Entities;
using MvcPL.Mapper;

namespace CustomAuth.Controllers.API
{
    [Authorize]
    public class FolderController : Controller//ApiController
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IFolderService folderService;
        private readonly IToDoListService toDoListService;
        private readonly IItemService itemService;

        public FolderController(IUserService userService, IRoleService roleService, IFolderService folderService, IToDoListService toDoListService, IItemService itemService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.folderService = folderService;
            this.toDoListService = toDoListService;
            this.itemService = itemService;
        }

        [HttpGet]
        public JsonResult/*<IEnumerable<FolderModel>>*/ GetFillFolders()
        {
            //return Json
            //    (new FolderModel()
            //    {
            //        Name ="f1",
            //        OrderIndex =3,
            //        ToDoLists =
            //            new ToDoListModel[]
            //            {
            //            new ToDoListModel
            //                {
            //                    Name ="tl1",OrderIndex=2,
            //                    Items =new ItemModel[] { new ItemModel() {Name="ii1" },new ItemModel {Name="ii2" } }
            //                }
            //            }
            //    },
            //    JsonRequestBehavior.AllowGet);
            var user = userService.GetByEmail(User.Identity.Name);
            FolderEntity[] folders = folderService.GetByAuthorId(user.Id).ToArray();
            FolderModel[] folderModels=new FolderModel[folders.Count()];
            for (int i = 0; i < folders.Length; i++)
            {
                folderModels[i] = folders[i].ToFolderModel();

                ToDoListEntity[] toDoLists = toDoListService.GetByFolderId(folders[i].Id).ToArray();
                ToDoListModel[] toDoListModels = new ToDoListModel[toDoLists.Length];
                for (int j = 0; j < toDoLists.Length; j++)
                {
                    toDoListModels[j].Items = itemService.GetByToDoListId(toDoLists[j].Id).Select(item=>item.ToItemModel()).ToArray();
                }
                folderModels[i].ToDoLists = toDoListModels;
            }
            return Json(folderModels, JsonRequestBehavior.AllowGet);
        }

    }
}
