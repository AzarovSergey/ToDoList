using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.Web.Mapper;
using Epam.Wunderlist.Web.Models;
using Epam.Wunderlist.Services.Interface.Entities;

namespace Epam.Wunderlist.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly UserServiceBase userService;
        private readonly RoleServiceBase roleService;
        private readonly FolderServiceBase folderService;
        private readonly ToDoListServiceBase toDoListService;
        private readonly ItemServiceBase itemService;
        readonly IMapper mapper; 

        public ItemController(UserServiceBase userService, RoleServiceBase roleService, FolderServiceBase folderService, ToDoListServiceBase toDoListService, ItemServiceBase itemService,IMapper mapper)
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
        public JsonResult GetItems(int toDoListId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { redirect = "/account/login/" }, JsonRequestBehavior.AllowGet);
            }
            var user = userService.GetByEmail(User.Identity.Name);
            ToDoListEntity currentToDoList = toDoListService.GetById(toDoListId);
            //TODO check that user has permission to get items.

            return Json(itemService.GetByToDoListId(toDoListId).Select(toDoList => mapper.Map<ItemEntity, ItemModel>(toDoList)).ToArray(),
                JsonRequestBehavior.AllowGet);
        }
    }
}