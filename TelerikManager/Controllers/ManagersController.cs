using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Telerik.SvgIcons;
using TelerikManager.Interface;
using TelerikManager.Models;

namespace TelerikManager.Controllers
{
    public class ManagersController : Controller
    {
        private readonly IManager ManagerData;
        public ManagersController(IManager managerData)
        {
            ManagerData = managerData;
        }
        public IActionResult Index()
        {
            return View();
        }


        public JsonResult Read([DataSourceRequest] DataSourceRequest request, string SearchText, string SelectedPlace, string SelectedEmail)
        {
            var data = ManagerData.GetAllManagerDetails(SearchText,SelectedPlace, SelectedEmail);

            return Json(data.ToDataSourceResult(request));
       }
       //public ActionResult GetPlaces(string SearchText, string SelectedPlace)
       // {
       //     var places = ManagerData.GetAllManagerDetails(SearchText, SelectedPlace).Select(m => m.Place).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
       //     var placeList = places.Select(p => new { Text = p, Value = p });

       //     return Json(placeList);
       // }
        //
        public ActionResult ReadPlace()
        {
            var data = ManagerData.GetPlaceList().ToList();
            var placeList = data.Select(p => new { Text = p.Place, Value = p.Place });
            return Json(placeList);

        }
        public ActionResult ReadEmail()
        {
            var data = ManagerData.GetEmailList().ToList();
            var emailList = data.Select(p => new { Text = p.Email, Value = p.Email });
            return Json(emailList);

        }
        //
        public IActionResult Create()
        {
            return PartialView("_CreateModal");
        }
        [HttpPost]
        public IActionResult Create(Manager objManager)
        {
            if (ModelState.IsValid)
            {
                ManagerData.AddManagerDetails(objManager);
                return RedirectToAction("Index");
            }
            return PartialView("_CreateModal");
        }
        //get record by id
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var manager = ManagerData.GetManagerDetails(ID);
            return PartialView("_EditModal", manager);
        }
        [HttpPost]
        public IActionResult Update(Manager objManager)
        {
            if (ModelState.IsValid)
            {
                ManagerData.UpdateManagerDetails(objManager);
                
                return RedirectToAction("Index");
            }
            return PartialView("_EditModal", objManager);
        }
        public void Destroy(Manager objManager)
        {
            ManagerData.DeleteManagerDetails(objManager.ID);

        }
        //delete
        [HttpPost]
        public IActionResult Delete(int ID)
        {
            //var manager = ManagerData.GetAllManagerDetails(id,null);
            //if (manager == null)
            //{
            //    return NotFound();
            //}

            ManagerData.DeleteManagerDetails(ID);
            return View("Index");
        }


    }
}





