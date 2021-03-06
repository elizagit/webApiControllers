﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HouseHotelv2.Infrastructure;

namespace HouseHotelv2.Controllers
{
    public class ReservationsController : ApiController
    {
        private happyhousesv4Entities db = new happyhousesv4Entities();

        // GET: api/Reservations
        public IQueryable<Reservation> GetReservations()
        {
            return db.Reservations;
        }

        // GET: api/Reservations/1
        [ResponseType(typeof(Reservation))]
        public async Task<IHttpActionResult> GetReservation(string id)
        {
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

     
        [HttpPost]
        // POST: api/Reservations
        [ResponseType(typeof(Reservation))]
        public async Task<IHttpActionResult> PostReservation(Reservation reservation)
        {
            //Add new reservation

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reservations.Add(reservation);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReservationExists(reservation.ReservationID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reservation.ReservationID }, reservation);
        }

      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservationExists(string id)
        {
            return db.Reservations.Count(e => e.ReservationID == id) > 0;
        }
    }
}