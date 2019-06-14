using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ranPasscode.Models;

namespace ranPasscode.Controllers
{
    public class IndexController : Controller {
        [HttpGet("")]
        public IActionResult Index() {
            int? Count = HttpContext.Session.GetInt32("Count");
            if (Count != null) {
                Count++;
                ViewBag.Count = Count;
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                string ranstr = "";
                for (int i = 0; i < 15; i++)
                {
                    int r = random.Next(0, 36);
                    ranstr += chars[r];
                    ViewBag.Barry = ranstr;
                    Console.WriteLine(ranstr);
                }  
                HttpContext.Session.SetInt32("Count", (int)Count);
            } else {
                HttpContext.Session.SetInt32("Count", 1);
                ViewBag.Count = 1;
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                string ranstr = "";
                for (int i = 0; i < 15; i++)
                {
                    int r = random.Next(0, 36);
                    ranstr += chars[r];
                    ViewBag.Barry = ranstr;
                    Console.WriteLine(ranstr);
                }
            }
            return View();
        }

        [HttpGet("reset")]
        public IActionResult Reset() {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}