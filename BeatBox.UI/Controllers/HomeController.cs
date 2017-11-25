using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Http;
using BeatBox.DAL.ORM.Entity;
using BeatBox.UI.Models;
using BeatBox.UI.Models.DTO;
using BeatBox.UI.Security.Authorization;

namespace BeatBox.UI.Controllers
{
    [Auth]
    public class HomeController : Controller
    {
        [CustomAuthorize("admin")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetList(string id)
        {
            switch (id)
            {
                case "category":
                    var categoryList = DataService.Service.categoryService.GetAll().Select(x=>new CategoryDTO() { Id=x.Id, Name=x.Name, InsertDate=x.InsertDate , IsActive=x.IsActive}).ToList();
                    return Json(categoryList, JsonRequestBehavior.AllowGet);

                case "singer":

                    var singerList = DataService.Service.SingerService.GetAll().Select(x => new CategoryDTO() { Id = x.Id, Name = x.Name+" "+x.Lastname, InsertDate = x.InsertDate, IsActive = x.IsActive }).ToList();
                    return Json(singerList,JsonRequestBehavior.AllowGet);

                case "song":
                    var songList = DataService.Service.SongService.GetAll().Select(x => new CategoryDTO() { Id = x.Id, Name = x.Name, InsertDate = x.InsertDate, IsActive = x.IsActive }).ToList();
                    return Json(songList,JsonRequestBehavior.AllowGet);

                case "songwriter":
                    var songWriterList = DataService.Service.SongWriterService.GetAll().Select(x => new CategoryDTO() { Id = x.Id, Name = x.Name + " " + x.Lastname, InsertDate = x.InsertDate, IsActive = x.IsActive }).ToList();
                    return Json(songWriterList,JsonRequestBehavior.AllowGet);

                case "melodist":
                    var melodistList = DataService.Service.MelodistService.GetAll().Select(x => new CategoryDTO() { Id = x.Id, Name = x.Name + " " + x.Lastname, InsertDate = x.InsertDate, IsActive = x.IsActive }).ToList();
                    return Json(melodistList,JsonRequestBehavior.AllowGet);

                default:
                    throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}