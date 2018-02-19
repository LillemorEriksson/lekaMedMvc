using Lektion_0129_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lektion_0129_MVC.Controllers
{
    public class CarsController : Controller
    {

        static List<Car> db = new List<Car>()

        {
          new Car(){Model = "900", Brand = "Sabb", MaxSpeed = 246}, // man behöver inte denna lista
          new Car(){Model = "740", Brand = "Volov", MaxSpeed = 200},
          new Car(){Model = "Kadett", Brand = "Opel", MaxSpeed = 220}
        };

        // GET: Cars
        public ActionResult Index()
        {
            return View(db);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind (Include = "MaxSpeed,Model,Brand")] Car car)//( double MaxSpeed, string Brand, string Model)
        {

            if (ModelState.IsValid)

            {
                db.Add(car); //db.Add(new Car() { MaxSpeed = MaxSpeed, Brand = Brand, Model = Model });
            }
             else
            {
                return View(car);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveCar(int carID)
        {
            db.Remove(db.SingleOrDefault(c => c.Id == carID));// kräver ett lamdauttryck
            return RedirectToAction("Index");
        }
    }
}