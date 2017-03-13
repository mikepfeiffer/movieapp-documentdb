using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieMVC.Models;

namespace MovieMVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var movies = await DocumentDBRepository<Movie>.GetAllItemsAsync();
            return View(movies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,MovieName,Rating,ReleaseDate")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Movie>.CreateItemAsync(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = await DocumentDBRepository<Movie>.GetItemAsync(id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,MovieName,Rating,ReleaseDate")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Movie>.UpdateItemAsync(movie.Id, movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = await DocumentDBRepository<Movie>.GetItemAsync(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Movie movie = await DocumentDBRepository<Movie>.GetItemAsync(id);
            await DocumentDBRepository<Movie>.RemoveItemAsync(movie.Id, movie);

            return RedirectToAction("Index");
        }
    }
}
