using DrawShape.Interfaces;
using DrawShape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrawShape.Controllers
{
    public class ShapesController : Controller
    {
        public ActionResult Hello()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetShape(int enteredShapeCode)
        {
            var shapeType = GetShapeType(enteredShapeCode);//Kullanıcının bastığı tuşa uygun şekil oluşturulur
            if (shapeType != null)
                return Json(shapeType, JsonRequestBehavior.AllowGet);   
            else
                return Json("", JsonRequestBehavior.AllowGet); // Geçersiz tuşa bastıysa boş gönderilerek uyarı verilir.

        }

        public IShape GetShapeType(int enteredShapeCode)
        {
            if (enteredShapeCode == 115 || enteredShapeCode == 83) //S-s
                return new Square { ShapeName = "Square", ShapeType = "S" };   //Square class ından yeni bir obje yaratılır.
            else if (enteredShapeCode == 116 || enteredShapeCode == 84) //T-t
                return new Triangle { ShapeName = "Triangle", ShapeType = "T" };  //Triangle class ından yeni bir obje yaratılır.
            else if (enteredShapeCode == 114 || enteredShapeCode == 82) //R-r
                return new Rectangle { ShapeName = "Rectangle", ShapeType = "R" };  //Rectangle class ından yeni bir obje yaratılır.
            else return null;
        }
    }
}