using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YY.Needle.Application.Interfaces;
using YY.Needle.Domain.Entities;

namespace YY.Needle.Web.Controllers
{
  

   // [Authorize(Roles = "Administrator")]
    public class Lottery3DController : Controller
    {
        private readonly ILottery3DAppService _lottery3dAppService;

        public Lottery3DController(ILottery3DAppService lottery3dAppService)
        {
            _lottery3dAppService = lottery3dAppService;
           
        }

        //
        // GET: /StoreManager/

        public ViewResult Index()
        {
            
            return View();
        }

        public JsonResult GetTableData(int pageIndex, int pageSize)
        {
            int total = 0;
            var result = _lottery3dAppService.GetPage(pageSize, pageIndex, out total);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //
        // GET: /StoreManager/Details/5

        //public ViewResult Details(int id)
        //{
        //    var album = _lottery3dAppService.Get(id, @readonly: true);
        //    return View(album);
        //}

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            //ViewBag.GenreId = new SelectList(_genreAppService.All(@readonly: true), "GenreId", "Name");
            //ViewBag.ArtistId = new SelectList(_artistAppService.All(@readonly: true), "ArtistId", "Name");
            return View();
        }

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Lottery3D album)
        {
            if (ModelState.IsValid)
            {
                var validationResult = _lottery3dAppService.Create(album);

                if (validationResult.IsValid)
                    return RedirectToAction("Index");

                foreach (var error in validationResult.Errors)
                    ModelState.AddModelError("", error.Message);
            }

          
            return View(album);
        }

        //
        // GET: /StoreManager/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    var album = _lottery3dAppService.Get(id, @readonly: true);
        //    //ViewBag.GenreId = new SelectList(_genreAppService.All(@readonly: true), "GenreId", "Name", album.GenreId);
        //    //ViewBag.ArtistId = new SelectList(_artistAppService.All(@readonly: true), "ArtistId", "Name", album.ArtistId);
        //    return View(album);
        //}

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Lottery3D album)
        {
            if (ModelState.IsValid)
            {
                var validationResult = _lottery3dAppService.Update(album);

                if (validationResult.IsValid)
                    return RedirectToAction("Index");

                foreach (var error in validationResult.Errors)
                    ModelState.AddModelError("", error.Message);

                return View(album);
            }
            //ViewBag.GenreId = new SelectList(_genreAppService.All(@readonly: true), "GenreId", "Name", album.GenreId);
            //ViewBag.ArtistId = new SelectList(_artistAppService.All(@readonly: true), "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // GET: /StoreManager/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    var album = _lottery3dAppService.Get(id, @readonly: true);
        //    return View(album);
        //}

        //
        // POST: /StoreManager/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var album = _lottery3dAppService.Get(id);
        //    _lottery3dAppService.Remove(album);

        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            _lottery3dAppService.Dispose();
            //_artistAppService.Dispose();
            //_genreAppService.Dispose();

            base.Dispose(disposing);
        }
    }
}