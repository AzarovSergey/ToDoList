using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epam.Wunderlist.Services.Interface.Services;

namespace Epam.Wunderlist.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly FolderServiceBase folderService;
        private readonly IToDoListService toDoListService;
        private readonly IItemService itemService;

        public ItemController(IUserService userService, IRoleService roleService, FolderServiceBase folderService, IToDoListService toDoListService, IItemService itemService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.folderService = folderService;
            this.toDoListService = toDoListService;
            this.itemService = itemService;
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetItems(int ToDoListId)
        {
            throw new NotImplementedException();


            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { redirect = "/account/login/" }, JsonRequestBehavior.AllowGet);
            }
            var user = userService.GetByEmail(User.Identity.Name);

        }
    }
}