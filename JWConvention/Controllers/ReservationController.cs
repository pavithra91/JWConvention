using JWConvention.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWConvention.Controllers
{
    public class ReservationController : Controller
    {
        wlakerstoursdbEntities _context = new wlakerstoursdbEntities();
        // GET: Reservation
        public ActionResult Index(string HotelCode)
        {
            try
            {
                ReservationModel objModel = new ReservationModel();
                JW_Hotels _hotel = _context.JW_Hotels.Where(w => w.HotelCode == HotelCode).FirstOrDefault();
                objModel._hotel = _hotel;
                objModel._roomList = _context.JW_Rooms.Where(w => w.HotelID == _hotel.HotelID).ToList();
                return View(objModel);
            }
            catch(Exception ex)
            {
                ReservationModel objModel = new ReservationModel();
                JW_Hotels _hotel = _context.JW_Hotels.Where(w => w.HotelCode == "CGC").FirstOrDefault();
                objModel._hotel = _hotel;
                objModel._roomList = _context.JW_Rooms.Where(w => w.HotelID == _hotel.HotelID).ToList();
                return View(objModel);
            }
        }

        [HttpPost]
        public ActionResult SaveReservation()
        {
            return View();
        }
    }
}