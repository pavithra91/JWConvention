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
                //ReservationModel objModel = new ReservationModel(); 
                ReservationModel objModel = TempData["ReservationModel"] as ReservationModel;
                if(objModel==null)
                {
                    ReservationModel objModel1 = new ReservationModel();

                    JW_BookingID _tempBookingID = new JW_BookingID();
                    _context.JW_BookingID.Add(_tempBookingID);
                    _context.SaveChanges();

                    _tempBookingID.BookingID = "JW" + _tempBookingID.AUTOID;
                    _context.Entry(_tempBookingID).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();

                    objModel1.BookingID = _tempBookingID.BookingID;
                    objModel1._additionalList = new List<AddtionalAccommodation>();

                    JW_Hotels _hotel = _context.JW_Hotels.Where(w => w.HotelCode == HotelCode).FirstOrDefault();
                    objModel1._hotel = _hotel;
                    objModel1._roomList = new List<JW_Rooms>();
                    objModel1._hotelList = new List<JW_Hotels>();

                    objModel1._roomList = _context.JW_Rooms.Where(w => w.HotelID == _hotel.HotelID).ToList();
                    objModel1._hotelList = _context.JW_Hotels.ToList();
                    return View(objModel1);
                }
                else
                {
                    objModel._roomList = new List<JW_Rooms>();
                    objModel._hotelList = new List<JW_Hotels>();

                    JW_Hotels _hotel = _context.JW_Hotels.Where(w => w.HotelCode == HotelCode).FirstOrDefault();
                    objModel._hotel = _hotel;

                    objModel._roomList = _context.JW_Rooms.Where(w => w.HotelID == _hotel.HotelID).ToList();
                    objModel._hotelList = _context.JW_Hotels.ToList();

                    // = _context.JW_TempReservation.Where(w=>w.BookingID == objModel.BookingID).ToList()
                    return View(objModel);
                }
                
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult SaveAdditionalRoom(ReservationModel ObjModel)
        {
            ReservationModel tempModel = TempData["ReservationModel"] as ReservationModel;

            var bookingId = _context.JW_BookingID.Where(w => w.BookingID == tempModel.BookingID).FirstOrDefault();

            if(bookingId!=null)
            {
                JW_TempReservation _temp = new JW_TempReservation();
                _temp.BookingID = bookingId.BookingID;
                _temp.AdditionalHotel = ObjModel._additional._addtionalHotel;
                _temp.AdditionalRoom = ObjModel._additional._addtionalRoom;
                _temp.AdditionalOccupancy = ObjModel._additional._addtionalOccupancy;
                //_temp.AdditionalDate = ObjModel._additional._addtionalDate;
                _temp.AdditionalNoofRooms = ObjModel._additional._addtionalNoOfRooms;
                _temp.AdditionalNoofNights = ObjModel._additional._addtionalNoOfNights;

                _context.JW_TempReservation.Add(_temp);
                _context.SaveChanges();

                if(tempModel._additionalList == null)
                {
                    tempModel._additionalList = new List<AddtionalAccommodation>();
                }

                tempModel._additionalList.Add(ObjModel._additional);

                TempData["ReservationModel"] = tempModel;
            }            

            return RedirectToAction("AddtionalAccomerdation", "Reservation");
        }

        [HttpPost]
        public ActionResult SaveReservation(ReservationModel ObjModel)
        {
            TempData["ReservationModel"] = ObjModel;

            return RedirectToAction("AddtionalAccomerdation", "Reservation");
        }


        public ActionResult AddtionalAccomerdation()
        {
            ReservationModel objModel = TempData["ReservationModel"] as ReservationModel;
            objModel._roomList = new List<JW_Rooms>();
            objModel._hotelList = new List<JW_Hotels>();
            objModel._hotelList = _context.JW_Hotels.ToList();

            TempData["ReservationModel"] = objModel;

            return View(objModel);
        }

        [HttpPost]
        public ActionResult Summery()
        {
            ReservationModel objModel = TempData["ReservationModel"] as ReservationModel;

            return View(objModel);
        }

        public ActionResult Registration(string HotelCode)
        {
            ReservationModel objModel = new ReservationModel();
            objModel._hotelCode = HotelCode;
            objModel._delegate = new DelegateModel();

            TempData["ReservationModel"] = objModel;
            return View(objModel);
        }

        [HttpPost]
        public ActionResult RegisterDelegate(ReservationModel _tempobjModel)
        {
            JW_GroupID _group = _context.JW_GroupID.Where(w => w.GroupID == _tempobjModel._delegate.GroupId).FirstOrDefault();
            if(_group != null)
            {
                ReservationModel objModel = TempData["ReservationModel"] as ReservationModel;
                objModel._delegate = _tempobjModel._delegate;
                TempData["ReservationModel"] = objModel;
                return RedirectToAction("Index", "Reservation", new { HotelCode = objModel._hotelCode });
            }
            else
            {
                return RedirectToAction("Registration", "Reservation");
            }
        }
    }
}