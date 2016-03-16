using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Security;
using System.Web.Mvc;
using Epam.Wunderlist.Web.ViewModels;
using System.Web.Security;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.Web.Models;
using Epam.Wunderlist.Web.Mapper;

namespace Epam.Wunderlist.Web.Controllers.API
{
    [Authorize]
    public class FolderController : Controller//ApiController
    {
        private readonly UserServiceBase userService;
        private readonly RoleServiceBase roleService;
        private readonly FolderServiceBase folderService;
        private readonly ToDoListServiceBase toDoListService;
        private readonly ItemServiceBase itemService;
        private readonly IMapper mapper;

        public FolderController(UserServiceBase userService, RoleServiceBase roleService, FolderServiceBase folderService, ToDoListServiceBase toDoListService, ItemServiceBase itemService, IMapper mapper)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.folderService = folderService;
            this.toDoListService = toDoListService;
            this.itemService = itemService;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetFolders()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { redirect = "/account/login/" }, JsonRequestBehavior.AllowGet);
            }
            var user = userService.GetByEmail(User.Identity.Name);
            FolderModel[] folders = folderService.GetByAuthorId(user.Id).Select(folder=>mapper.Map<FolderEntity,FolderModel>(folder)).ToArray();
            foreach(var folder in folders)
            {
                folder.ToDoLists = toDoListService.GetByFolderId(folder.Id).Select(toDoList => mapper.Map<ToDoListEntity, ToDoListModel>(toDoList)).ToArray();
            }
            return Json(folders, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public EmptyResult Create(string name)
        {
            folderService.Create(new FolderEntity()
            {
                Name = name,
                UserId = userService.GetByEmail(User.Identity.Name).Id
            });
            return new EmptyResult();
        }

        public JsonResult Delete(int folderId)
        {
            folderService.Delete(folderId);
            return GetFolders();
        }

        [HttpPost]
        public void Rename(string name, int id)
        {
            var entity = folderService.GetById(id);
            entity.Name = name;
            folderService.Update(entity);
        }
    }
}
