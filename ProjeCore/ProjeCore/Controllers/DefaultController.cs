using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjeCore.Models;

namespace ProjeCore.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Birims.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {
            c.Birims.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimSil(int id)
        {
            var birim = c.Birims.Find(id);
            c.Birims.Remove(birim);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimGetir(int id)
        {
            var birim = c.Birims.Find(id);
            return View("BirimGetir", birim);
        }
        public IActionResult BirimGuncelle(Birim b)
        {
            var birim = c.Birims.Find(b.BirimID);
            birim.BirimAd = b.BirimAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
