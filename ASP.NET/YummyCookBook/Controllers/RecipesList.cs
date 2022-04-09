using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YummyCookBook.Models;
using System.Linq;
namespace YummyCookBook.Controllers

{
    public class RecipesList : Controller
    {
       

        // 
        // GET: /RecipesList/

        public ActionResult Index()
        {
            return View(YummyCookBook.Program.recipes);
        }

        // 
        // GET: /RecipesList/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Recipes per)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", per);

                }
                int nextId = Program.recipes.Max(x => x.Id);
                per.Id = nextId +1;
                Program.recipes.Add(per);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            Recipes per = Program.recipes.Find(emp => emp.Id == id);
            return View(per);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Recipes per = Program.recipes.Find(emp => emp.Id == id);
            return View(per);
        }

        [HttpPost]
        public ActionResult Edit(int id,  Recipes per)
        {
            try
            {
               // return RedirectToAction("Index");
                int id2 = per.Id;
               
                Recipes perOld = Program.recipes.Find(emp => emp.Id == id2);
                int index = Program.recipes.IndexOf(perOld);

                Program.recipes.RemoveAt(index);

                Program.recipes.Insert(index, per);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Recipes per = Program.recipes.Find(emp => emp.Id == id);
            return View(per);
        }

        [HttpPost]
        public ActionResult Delete(int id, Recipes per)
        {
            try { 
            Recipes perOld = Program.recipes.Find(emp => emp.Id == id);
            int index = Program.recipes.IndexOf(perOld);

            Program.recipes.RemoveAt(index);

            return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
