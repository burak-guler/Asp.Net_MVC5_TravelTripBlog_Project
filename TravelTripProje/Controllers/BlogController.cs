using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;


namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        Models.Siniflar.Context c = new Models.Siniflar.Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.Deger1=c.Blogs.ToList();
            //burada blogları sondan sıralayıp ilk 3 tanesini getiriyor.
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }
        
        public ActionResult BlogDetay(int id)
        {
            //gelen ıd ye karşılık gelen blogu bulur ve sayfa döndürür
            //var blogbul = c.Blogs.Where(x => x.ID == id).ToList();

            //bir sayfada birden fazla tablo ile işlem yapmamız lazım ise
            //BlogYorum classı gibi bir classta diğer classları property şeklinde yazıp
            //controller tarafında nesne üretip çağırabilirz.
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}