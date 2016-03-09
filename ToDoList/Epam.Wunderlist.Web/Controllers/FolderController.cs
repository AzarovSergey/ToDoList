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
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly FolderServiceBase folderService;
        private readonly IToDoListService toDoListService;
        private readonly IItemService itemService;

        public FolderController(IUserService userService, IRoleService roleService, FolderServiceBase folderService, IToDoListService toDoListService, IItemService itemService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.folderService = folderService;
            this.toDoListService = toDoListService;
            this.itemService = itemService;
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
            FolderModel[] folders = folderService.GetByAuthorId(user.Id).Select(folder=>folder.ToFolderModel()).ToArray();
            return Json(folders, JsonRequestBehavior.AllowGet);
        }


    }
}
