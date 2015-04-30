using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registar.BusinessLayer;
using Registar.BusinessLayer.Contracts;
using RegistarMVC.Models;
using System.Web.Script.Serialization;

namespace RegistarMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        [ActionName("Index"), HttpPost]
        public ActionResult IndexPost()
        {
            //call BL
            BikeSearchCommand _command = new BikeSearchCommand();
            BikeSearchResult _result = CommandInvoker.InvokeCommand<BikeSearchCommand, BikeSearchResult>(_command);
            //
            //return new JsonResult() { Data = _result.Result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            var _jsonSerializer = new JavaScriptSerializer();
            var _jsonString = _jsonSerializer.Serialize(_result.Result);
            return new JsonResult() { Data = _jsonString, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            //JsonResult _jsonResult = Json("Response from Post", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index2()
        {
            List<BikeModel> _result = new List<BikeModel>();
            _result.Add(new BikeModel() { Colour = "red", Model = "R1", Producer = "Specialized", RegNumber = "007" });
            _result.Add(new BikeModel() { Colour = "red", Model = "R1", Producer = "Specialized", RegNumber = "007" });
            _result.Add(new BikeModel() { Colour = "red", Model = "R1", Producer = "Specialized", RegNumber = "007" });
            _result.Add(new BikeModel() { Colour = "red", Model = "R1", Producer = "Specialized", RegNumber = "007" });
            //
            this.ViewBag.SomeNewProperty = "theValue";
            this.ViewData["SomeNewProperty"] = "theValue";
            //
            return View("Index",_result);
        }

    }
}
