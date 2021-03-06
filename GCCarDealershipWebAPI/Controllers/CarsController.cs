﻿using GCCarDealership.Domain.Models;
using GCCarDealershipWebAPI.DAL;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace GCCarDealershipWebAPI.Controllers
{
    public class CarsController : ApiController
    {
        private CarDbContext db = new CarDbContext();

        // GET: api/Cars
        public IQueryable<CarModel> GetCars()
        {
            return db.Cars.OrderBy(x => x.Make).ThenBy(x => x.Model);
        }

        [Route("api/Cars/Search")]
        public IQueryable<CarModel> GetSearch(string make = null, string model = null, int? year = null, string color = null)
        {
            var cars = db.Cars.AsQueryable();
            if (!string.IsNullOrWhiteSpace(make))
            {
                cars = cars.Where(x => x.Make == make);
            }
            if (!string.IsNullOrWhiteSpace(model))
            {
                cars = cars.Where(x => x.Model == model);
            }
            if (year.HasValue)
            {
                cars = cars.Where(x => x.Year == year);
            }
            if (!string.IsNullOrWhiteSpace(color))
            {
                cars = cars.Where(x => x.Color == color);
            }

            return cars.OrderBy(x => x.Make).ThenBy(x => x.Model);
        }

        // GET: api/Cars/5
        [ResponseType(typeof(CarModel))]
        public IHttpActionResult GetCarModel(int id)
        {
            CarModel carModel = db.Cars.Find(id);
            if (carModel == null)
            {
                return NotFound();
            }

            return Ok(carModel);
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarModel(int id, CarModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carModel.Id)
            {
                return BadRequest();
            }

            db.Entry(carModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cars
        [ResponseType(typeof(CarModel))]
        public IHttpActionResult PostCarModel(CarModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cars.Add(carModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carModel.Id }, carModel);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(CarModel))]
        public IHttpActionResult DeleteCarModel(int id)
        {
            CarModel carModel = db.Cars.Find(id);
            if (carModel == null)
            {
                return NotFound();
            }

            db.Cars.Remove(carModel);
            db.SaveChanges();

            return Ok(carModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarModelExists(int id)
        {
            return db.Cars.Count(e => e.Id == id) > 0;
        }
    }
}