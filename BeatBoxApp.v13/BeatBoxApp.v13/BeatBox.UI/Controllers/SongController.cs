using BeatBox.UI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeatBox.UI.Controllers
{
    public class SongController : Controller
    {
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CategoryDTO category)
        {
            string data = "Ekleme işlemi başarısız. Boş kategori objesi!";
            if (category != null && category.Name != null)
            {
                data = "Ekleme işlemi başarısız. Kategori ismi daha önce eklenmiş yada karakteri sınırını aşamıyor!";
                if (category.Name.Length > 3 && !DataService.Service.categoryService.GetAll().Any(x => x.Name == category.Name))
                {
                    try
                    {
                        DataService.Service.categoryService.Insert(new DAL.ORM.Entity.Category()
                        {
                            Name = category.Name,
                            Description = category.Description
                        });
                        data = "Ekleme işlemi başarılı!";
                        return Json(data);
                    }
                    catch
                    {
                        return Json(data);
                    }
                }
            }
            return Json(data);

        }

        public ActionResult Delete(int? id)
        {
            int result = 0;
            if (id != null)
            {
                result = DataService.Service.categoryService.Delete(id);
            }

            string data = result == 0 ? "Silme işlemi başarısız!" : "Silme işlemi başarılı!";

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SuperDelete(int? id)
        {
            int result = 0;
            if (id != null)
            {
                result = DataService.Service.categoryService.SuperDelete(id);
            }
            string data = result == 0 ? "Veri kalıcı olarak silme işleminiz başarısız!" : "Veri kalıcı olarak silme işleminiz başarılı!";

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UnDelete(int? id)
        {
            int result = 0;
            if (id != null)
            {
                result = DataService.Service.categoryService.UpdateIsActive(id, true, false);
            }
            string data = result == 0 ? "Geri alma işlemi başarısız!" : "Geri alma işlemi başarılı!";

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
