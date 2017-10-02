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
                ReservationModel objModel = TempData["ReservationModel"] as ReservationModel;
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

        public ActionResult Registration(string HotelCode)
        {
            ReservationModel objModel = new ReservationModel();
            objModel._hotelCode = HotelCode;
            objModel._delegate = new DelegateModel();
            return View(objModel);
        }

        [HttpPost]
        public ActionResult RegisterDelegate(ReservationModel objModel)
        {
            JW_GroupID _group = _context.JW_GroupID.Where(w => w.GroupID == objModel._delegate.GroupId).FirstOrDefault();
            if(_group != null)
            {
                TempData["ReservationModel"] = objModel;
                return RedirectToAction("Index", "Reservation", new { HotelCode = "CGC" });
            }
            else
            {
                return RedirectToAction("Registration", "Reservation");
            }
        }
    }
}