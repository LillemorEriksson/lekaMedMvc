using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lektion_0129_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Mattetabel()
        {
            HttpCookie myCookie = Request.Cookies.Get("CookieNummber");
            if (myCookie != null)
            {
                List<int> nummerna = new List<int>();
                string[] stringNumbers = myCookie.Value.Split('q');// man kan skriva var istället för string men det är tydligare med string
                foreach (var item in stringNumbers)
                {
                    nummerna.Add(int.Parse(item));
                }
                Session["vilkaNummer"] = nummerna;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Mattetabel(int multi)
        {
            HttpCookie myCookie;
            List<int> nummerna = new List<int>();//syan heter List

            if (Session["vilkaNummer"] != null)
            {
                // type-cast
                nummerna = (List<int>)Session["vilkaNummer"];
            }
            else
            {
                myCookie = Request.Cookies.Get("CookieNummber");
                if (myCookie != null)
                {
                    string[] stringNumbers = myCookie.Value.Split('q');// man kan skriva var istället för string men det är tydligare med string
                    foreach (var item in stringNumbers)
                    {
                        nummerna.Add(int.Parse(item));
                    }
                }
            }
            nummerna.Add(multi);// lägga till nya nummer
            Session["vilkaNummer"] = nummerna;// spara listan med nummer

            myCookie = new HttpCookie("CookieNumbers");
            myCookie.Expires = DateTime.Now.AddHours(1);

            foreach(int item in nummerna)
            {
                myCookie.Value += item.ToString() + 'q';
            }

            myCookie.Value = myCookie.Value.Remove(myCookie.Value.Length - 1, 1);

            Response.Cookies.Add(myCookie);

            ViewBag.multi = multi;

            return View();
        }
    }
}