using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.Web.Mapper;
using Epam.Wunderlist.Web.Models;
using Epam.Wunderlist.Services.Interface;
using Epam.Wunderlist.Services.Interface.Entities;

namespace Epam.Wunderlist.Web.Controllers
{
    [Authorize]
    public class ToDoListController : Controller
    {
        private readonly UserServiceBase userService;
        private readonly RoleServiceBase roleService;
        private readonly FolderServiceBase folderService;
        private readonly ToDoListServiceBase toDoListService;
        private readonly ItemServiceBase itemService;
        private readonly IMapper mapper;

        public ToDoListController(UserServiceBase userService, RoleServiceBase roleService, FolderServiceBase folderService, ToDoListServiceBase toDoListService, ItemServiceBase itemService, IMapper mapper)
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
        public JsonResult GetByFolderId(int folderId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { redirect = "/account/login/" }, JsonRequestBehavior.AllowGet);
            }
            var user = userService.GetByEmail(User.Identity.Name);
            if ((folderService.GetById(folderId)?.UserId ?? 0) != user.Id)
            {
                return Json(new { redirect = "/account/login/" }, JsonRequestBehavior.AllowGet);
            }
            ToDoListModel[] lists = toDoListService.GetByFolderId(folderId).Select(list =>mapper.Map<ToDoListEntity,ToDoListModel>(list)).ToArray();
            return Json(lists, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(string name,int folderId)
        {
            toDoListService.Create(new ToDoListEntity()
            {
                Name = name,
                FolderId = folderId
            });
            return null;
        }

        [HttpPost]
        public void Rename(string name, int id)
        {
            var entity = toDoListService.GetById(id);
            entity.Name = name;
            toDoListService.Update(entity);
        }

        public void Delete(int id)
        {
            toDoListService.Delete(id);
        }

    }
}