﻿using GCCarDealershipMVC.Clients;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GCCarDealershipMVC.Controllers
{
    public class CarController : Controller
    {
        private readonly CarClient _carClient;

        public CarController()
        {
            _carClient = new CarClient();
        }

        // GET: Car
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetCars()
        {
            var cars = await _carClient.GetCars();
            return View(cars);
        }

        public async Task<ActionResult> Search(string make, string model, int? year, string color)
        {
            var cars = await _carClient.SearchCars(make, model, year, color);
            return View(cars);
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Car/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
