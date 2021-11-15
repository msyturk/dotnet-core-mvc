using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjeCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ProjeCore.Controllers
{
    public class PersonelimController : Controller
    {
        Context c = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var degerler = c.Personels.Include(item => item.Birim).ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniPersonel(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult PersonelSil(int id)
        {
            var per = c.Personels.Find(id);
            c.Personels.Remove(per);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult PersonelGetir(int id)
        {
            var per = c.Personels.Find(id);
            return View("PersonelGetir", per);
        }
        public IActionResult PersonelGuncelle(Personel p)
        {
            var per = c.Personels.Find(p.PersonelID);
            per.Ad = p.Ad;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
