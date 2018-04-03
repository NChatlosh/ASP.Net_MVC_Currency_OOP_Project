using CurrencyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CurrencyMVC.Models
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private static MoviesContext mc;
        public MoviesContext Mc
        {
            get { return mc; }
            set { Mc = value; }
        }
        public MoviesController()
        {
            if(mc == null)
            {
                mc = new MoviesContext();
            }
            this.ViewData.Model = mc.Movies;
        }

        public ActionResult Index()
        {
            this.ViewData.Model = mc.Movies;
            return View();
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewData.Model = new MovieModel("NA", -1);
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string title = Request.Form["TitleBox"];
                string yearString = Request.Form["YearBox"];
                string genre = Request.Form["GenreBox"];
                int year;
                if(Int32.TryParse(yearString, out year))
                {
                    mc.AddMovie(title, year, genre);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData.Model = mc.Movies[id];
            return View();
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                string title = Request.Form["TitleBox"];
                string yearString = Request.Form["YearBox"];
                string genre = Request.Form["GenreBox"];
                int year;
                if (Int32.TryParse(yearString, out year))
                {
                    mc.EditMovie( mc.Movies[id], title, year, genre);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            ViewData.Model = mc.Movies[id];
            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                MovieModel movie = mc.Movies[id];
                mc.RemoveMovie(movie);

                for(int i = id; i < mc.Movies.Count; i++)
                {
                    mc.Movies[i].PrimaryKey--;
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
