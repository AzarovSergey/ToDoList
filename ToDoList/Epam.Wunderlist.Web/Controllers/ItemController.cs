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
    [Authorize]
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
            var res = itemService.GetByToDoListId(toDoListId).Select(toDoList => mapper.Map<ItemEntity, ItemModel>(toDoList)).ToArray();
            return Json(res,
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(ItemModel item)
        {
            if (item.DueDateTime == DateTime.MinValue)
                item.DueDateTime = DateTime.MaxValue;
            item.Note = item.Note ?? "";
            item.Name = item.Name ?? "";
            ItemEntity entity = mapper.Map<ItemModel, ItemEntity>(item);
            if (item.Id!=0)
            {
                itemService.Update(entity);
            }
            else
            {
                itemService.Create(entity);
            }
            return GetItems(item.ToDoListId);
        }

        [HttpPost]
        public void SetDueDate(int itemId,string dueDate)
        {
            DateTime date;//=DateTime.MinValue;
            try
            {
                date=Convert.ToDateTime(dueDate);
            }
            catch (FormatException)
            {
                return;
            }
            ItemEntity item = itemService.GetById(itemId);
            if (item == null)
                return;
            item.DueDateTime = date;
            itemService.Update(item);
        }

        [HttpPost]
        public JsonResult SetCompletion(int itemId,bool isCompleted)
        {
            var currentItem = itemService.GetById(itemId);
            currentItem.IsCompleted = isCompleted;
            itemService.Update(currentItem);
            return GetItems(currentItem.ToDoListId);
        }

        public void Update(int id,string note,string name)
        {
            var item = itemService.GetById(id);
            item.Note = note;
            item.Name = name;
            itemService.Update(item);
        }

        [HttpPost]
        public void Delete(int id)
        {
            itemService.Delete(id);
        }
    }
}