using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.Web.Mapper;
using Epam.Wunderlist.Web.Models;
using Epam.Wunderlist.Services.Interface;

namespace Epam.Wunderlist.Web.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly FolderServiceBase folderService;
        private readonly IToDoListService toDoListService;
        private readonly IItemService itemService;

        public ToDoListController(IUserService userService, IRoleService roleService, FolderServiceBase folderService, IToDoListService toDoListService, IItemService itemService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.folderService = folderService;
            this.toDoListService = toDoListService;
            this.itemService = itemService;
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
            ToDoListModel[] lists = toDoListService.GetByFolderId(folderId).Select(list => list.ToToDoListModel()).ToArray();
            return Json(lists, JsonRequestBehavior.AllowGet);
        }
    }
}