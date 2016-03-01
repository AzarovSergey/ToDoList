using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using BLL.Interface.Services;
using MvcPL.Mapper;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IFolderService folderService;
        private readonly IToDoListService toDoListService;
        private readonly IItemService itemService;

        public ToDoListController(IUserService userService, IRoleService roleService, IFolderService folderService, IToDoListService toDoListService, IItemService itemService)
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
            if ((folderService.GetById(folderId)?.AuthorId ?? 0) != user.Id)
            {
                return Json(new { redirect = "/account/login/" }, JsonRequestBehavior.AllowGet);
            }
            ToDoListModel[] lists = toDoListService.GetByFolderId(folderId).Select(list => list.ToToDoListModel()).ToArray();
            return Json(lists, JsonRequestBehavior.AllowGet);
        }
    }
}