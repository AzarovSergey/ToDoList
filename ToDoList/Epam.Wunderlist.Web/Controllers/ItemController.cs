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
        private readonly UserServiceBase userService;
        private readonly RoleServiceBase roleService;
        private readonly FolderServiceBase folderService;
        private readonly ToDoListServiceBase toDoListService;
        private readonly ItemServiceBase itemService;

        public ItemController(UserServiceBase userService, RoleServiceBase roleService, FolderServiceBase folderService, ToDoListServiceBase toDoListService, ItemServiceBase itemService)
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