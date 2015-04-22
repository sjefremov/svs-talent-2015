using Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Register.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //TODO create the model
            List<BikeModel> _result = new List<BikeModel>();
            _result.Add(new BikeModel() { Colour = "red", Model = "Specialized", Producer = "R1", RegNumber="123" });
            _result.Add(new BikeModel() { Colour = "red", Model = "Specialized", Producer = "R1", RegNumber = "123" });
            _result.Add(new BikeModel() { Colour = "red", Model = "Specialized", Producer = "R1", RegNumber = "123" });
            _result.Add(new BikeModel() { Colour = "red", Model = "Specialized", Producer = "R1", RegNumber = "123" });
            return View(_result);
        }

    }
}
