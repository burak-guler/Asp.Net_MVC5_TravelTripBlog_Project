using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context c = new Context();
        public ActionResult Index()
        {
            var image = c.Blogs.Take(3).ToList();
            return View(image);
        }

        public ActionResult About()
        {
            return View();
        }

        //partial view methodu
        public PartialViewResult partial1()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult partial2()
        {
            var degerler = c.Blogs.Where(x => x.ID == 1).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult partial3()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult partial4 ()
        {
            var degerler = c.Blogs.Take(3).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult partial5()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(degerler);
        }

        
    }
}