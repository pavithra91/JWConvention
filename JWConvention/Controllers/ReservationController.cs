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
        public ActionResult Registration(string HotelCode)
        {
            ReservationModel objModel = new ReservationModel();

            JW_BookingID _tempBookingID = new JW_BookingID();
            _context.JW_BookingID.Add(_tempBookingID);
            _context.SaveChanges();

            _tempBookingID.BookingID = "JW" + _tempBookingID.AUTOID;
            _context.Entry(_tempBookingID).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            objModel.BookingID = _tempBookingID.BookingID;
            objModel._additionalList = new List<AddtionalAccommodation>();

            objModel._hotelCode = HotelCode;
            objModel._delegate = new DelegateModel();

            TempData["ReservationModel"] = objModel;
            return View(objModel);
        }

        public ActionResult Index(string HotelCode)
        {
            //try
            //{
                //ReservationModel objModel = new ReservationModel(); 
                ReservationModel objModel = TempData["ReservationModel"] as ReservationModel;
                objModel._roomList = new List<JW_Rooms>();
                objModel._hotelList = new List<JW_Hotels>();

                JW_Hotels _hotel = _context.JW_Hotels.Where(w => w.HotelCode == HotelCode).FirstOrDefault();
                objModel._hotel = _hotel;
                objModel._hotelCode = HotelCode;

                objModel._roomList = _context.JW_Rooms.Where(w => w.HotelID == _hotel.HotelID).ToList();
                objModel._hotelList = _context.JW_Hotels.ToList();
                
                return View(objModel); 
            //}
            //catch(Exception ex)
            //{
            //    return null;
            //}
        }

        //public ActionResult AddtionalAccomerdation()
        //{
        //    ReservationModel objModel = TempData["ReservationModel"] as ReservationModel;
        //    objModel._roomList = new List<JW_Rooms>();
        //    objModel._hotelList = new List<JW_Hotels>();
        //    objModel._hotelList = _context.JW_Hotels.ToList();

        //    TempData["ReservationModel"] = objModel;

        //    return View(objModel);
        //}

        //[HttpPost]
        //public ActionResult SaveAdditionalRoom(ReservationModel ObjModel)
        //{
        //    ReservationModel tempModel = TempData["ReservationModel"] as ReservationModel;

        //    var bookingId = _context.JW_BookingID.Where(w => w.BookingID == tempModel.BookingID).FirstOrDefault();

        //    if (bookingId != null)
        //    {
        //        JW_TempReservation _temp = new JW_TempReservation();
        //        _temp.BookingID = bookingId.BookingID;
        //        _temp.AdditionalHotel = ObjModel._additional._addtionalHotel;
        //        _temp.AdditionalRoom = ObjModel._additional._addtionalRoom;
        //        _temp.AdditionalOccupancy = ObjModel._additional._addtionalOccupancy;
        //        //_temp.AdditionalDate = ObjModel._additional._addtionalDate;
        //        _temp.AdditionalNoofRooms = ObjModel._additional._addtionalNoOfRooms;
        //        _temp.AdditionalNoofNights = ObjModel._additional._addtionalNoOfNights;

        //        int roomId = Convert.ToInt32(ObjModel._additional._addtionalRoom);

        //        ObjModel._additional._Cost = (float)_context.JW_AdditionalRoomRates.Where(w => w.RoomID == roomId).FirstOrDefault().RoomRate.GetValueOrDefault(0);

        //        _context.JW_TempReservation.Add(_temp);
        //        _context.SaveChanges();

        //        if (tempModel._additionalList == null)
        //        {
        //            tempModel._additionalList = new List<AddtionalAccommodation>();
        //        }

        //        tempModel._additionalList.Add(ObjModel._additional);

        //        JW_Hotels _hotel = _context.JW_Hotels.Where(w => w.HotelCode == ObjModel._hotelCode).FirstOrDefault();
        //        tempModel._hotel = _hotel;
        //        tempModel._hotelCode = ObjModel._hotelCode;
        //        tempModel._delegate = ObjModel._delegate;

        //        TempData["ReservationModel"] = tempModel;
        //    }

        //    return RedirectToAction("AddtionalAccomerdation", "Reservation");
        //}

        [HttpPost]
        public ActionResult SaveReservation(ReservationModel ObjModel, string rdPaymentMethod)
        {
            TempData["ReservationModel"] = ObjModel;
            ObjModel._hotel = _context.JW_Hotels.Where(w => w.HotelCode == ObjModel._hotelCode).FirstOrDefault();

            string BookingID = ObjModel.BookingID;
            string userName = "ruwan";
            string Password = "pass#word1";
            string customerName = ObjModel._delegate.Name;
            string email = ObjModel._delegate.EmailAddress;
            string ConventionCode = "JWCON";
            string Language = "en";
            string Currency = "USD";


            DateTime _fromDate = DateTime.ParseExact(ObjModel._fromDate, "dd/MM/yyyy", null);
            DateTime _toDate = DateTime.ParseExact(ObjModel._toDate, "dd/MM/yyyy", null);

            double _beforeDays = 0;
            int _packageDays = 0;
            double _afterDays = 0;
            double TotalCost = 0;

            DateTime _StartingDate = DateTime.ParseExact("02/07/2018", "dd/MM/yyyy", null);
            TimeSpan t = _StartingDate - _fromDate;
            _beforeDays = t.TotalDays;

            DateTime _7dayPackage = DateTime.ParseExact("08/07/2018", "dd/MM/yyyy", null);
            DateTime _8dayPackage = DateTime.ParseExact("09/07/2018", "dd/MM/yyyy", null);
            DateTime _9dayPackage = DateTime.ParseExact("10/07/2018", "dd/MM/yyyy", null);
            DateTime _10dayPackage = DateTime.ParseExact("11/07/2018", "dd/MM/yyyy", null);

            if (_toDate == _7dayPackage)
            {
                _packageDays += 7;
                _afterDays = (_toDate - _7dayPackage).TotalDays;
                TotalCost = (double)_context.JW_RoomRate.Where(w => w.PackageId == 1).FirstOrDefault().RoomRate;
            }
            else if (_toDate > _7dayPackage && _toDate <= _8dayPackage)
            {
                _packageDays += 8;
                _afterDays = (_toDate - _8dayPackage).TotalDays;
                TotalCost = (double)_context.JW_RoomRate.Where(w => w.PackageId == 2).FirstOrDefault().RoomRate;
            }
            else if (_toDate > _8dayPackage && _toDate <= _9dayPackage)
            {
                _packageDays += 9;
                _afterDays = (_toDate - _9dayPackage).TotalDays;
                TotalCost = (double)_context.JW_RoomRate.Where(w => w.PackageId == 3).FirstOrDefault().RoomRate;
            }
            else if (_toDate > _9dayPackage && _toDate <= _10dayPackage)
            {
                _packageDays += 10;
                _afterDays = (_toDate - _10dayPackage).TotalDays;
                TotalCost = (double)_context.JW_RoomRate.Where(w => w.PackageId == 4).FirstOrDefault().RoomRate;
            }
            else if (_toDate > _10dayPackage)
            {
                _packageDays += 10;
                _afterDays = (_toDate - _10dayPackage).TotalDays;
                TotalCost = (double)_context.JW_RoomRate.Where(w => w.PackageId == 4).FirstOrDefault().RoomRate;
            }

            if(_beforeDays > 0)
            {
                double cost = _context.JW_AdditionalRoomRates.Where(w=>w.RoomID == )
            }

            JW_Delegates _delegate = new JW_Delegates();
            _delegate.BookingID = ObjModel.BookingID;
            _delegate.ContactNo = ObjModel._delegate.ContactNo;
            _delegate.Country = ObjModel._delegate.Country;
            _delegate.DelegeteName = ObjModel._delegate.Name;
            _delegate.Email = ObjModel._delegate.EmailAddress;
            _delegate.Nationality = ObjModel._delegate.Nationality;
            _delegate.PassportNo = ObjModel._delegate.PassportNo;
            _delegate.Title = ObjModel._delegate.Title;
            _delegate.Address = ObjModel._delegate.DelegateAddress;

            _context.JW_Delegates.Add(_delegate);
            _context.SaveChanges();


            JW_Reservation _reservation = new JW_Reservation();
            _reservation.HotelName = ObjModel._hotel.HotelName;
            _reservation.BookingID = ObjModel.BookingID;
            _reservation.ArrivalFlightNo = ObjModel._ArrivalFlightNumber;
            _reservation.DepartureFlightNo = ObjModel._DepartureFlightNumber;
            //_reservation.CheckInDate = objModel._ArrivalDate;
            //_reservation.CheckInTime = objModel._ArrivalTime;
            //_reservation.CheckOutDate = objModel._DepartureDate;
            //_reservation.CheckOutTime = objModel._DepartureTime;
            _reservation.IsArrivalTransportRequired = ObjModel._isArrival;
            _reservation.IsDepartureTransportRequired = ObjModel._isDeparture;
            _reservation.Roomtype = ObjModel._roomType;
            _reservation.Occupancy = ObjModel._Occupancy;
            _reservation.BedPreference = ObjModel._BedPerferance;
            _reservation.TotalCost = TotalCost;
            _reservation.NightBefore = Convert.ToInt32(_beforeDays);
            _reservation.Package = Convert.ToInt32(_packageDays);
            _reservation.NightAfter = Convert.ToInt32(_afterDays);

            if (rdPaymentMethod == "Half")
            {
                _reservation.IsAdvancePayment = true;
            }
            else
            {
                _reservation.IsAdvancePayment = false;
            }

            _context.JW_Reservation.Add(_reservation);
            _context.SaveChanges();

            if (rdPaymentMethod == "Half")
            {
                TotalCost = TotalCost / 2;
            }

                string url = "http://cvisitipg.azurewebsites.net/Payment/WebPortal";
                Response.Clear();
                var sb = new System.Text.StringBuilder();
                sb.Append("<html>");
                sb.AppendFormat("<body onload='document.forms[0].submit()'>");
                sb.AppendFormat("<form action='{0}' method='post'>", url);
                sb.AppendFormat("<input type='hidden' id='CustomerRef' name='CustomerRef' value='" + BookingID + "'>", BookingID);
                sb.AppendFormat("<input type='hidden' id='Amount' name='Amount' value='" + TotalCost + "'>", TotalCost);
                sb.AppendFormat("<input type='hidden' id='UserName' name='UserName' value='" + userName + "'>", userName);
                sb.AppendFormat("<input type='hidden' id='Password' name='Password' value='" + Password + "'>", Password);
                sb.AppendFormat("<input type='hidden' id='customername' name='customername' value='" + customerName + "'>", customerName);
                sb.AppendFormat("<input type='hidden' id='email' name='email' value='" + email + "'>", email);
                sb.AppendFormat("<input type='hidden' id='conventioncode' name='conventioncode' value='" + ConventionCode + "'>", ConventionCode);
                sb.AppendFormat("<input type='hidden' id='language' name='language' value='" + Language + "'>", Language);
                sb.AppendFormat("<input type='hidden' id='_currency' name='_currency' value='" + Currency + "'>", Currency);
                sb.Append("</form>");
                sb.Append("</body>");
                sb.Append("</html>");
                //Response.Write(sb.ToString());
                //Response.End();

                return Content(sb.ToString());

          //  }

          //  return null;
           // return RedirectToAction("AddtionalAccomerdation", "Reservation");
        }

        [HttpPost]
        public ActionResult PostSummery()
        {
            ReservationModel objModel = TempData["ReservationModel"] as ReservationModel;

            TempData["ReservationModel"] = objModel;

            return RedirectToAction("Summery", "Reservation");
        }


        [HttpPost]
        public ActionResult PostToPayment(ReservationModel objModel)
        {
            string BookingID = objModel.BookingID;
            string userName = "ruwan";
            string Password = "pass#word1";
            string customerName = objModel._delegate.Name;
            string email = objModel._delegate.EmailAddress;
            string ConventionCode = "JWCON";
            string Language = "en";
            string Currency = "USD";

            JW_Reservation obj = _context.JW_Reservation.Where(w => w.BookingID == BookingID).FirstOrDefault();
            if(objModel.isAdvancedPayment)
            {
                obj.TotalCost = obj.TotalCost / 2;
            }


            if(obj != null)
            {
                string url = "http://cvisitipg.azurewebsites.net/Payment/WebPortal";
                Response.Clear();
                var sb = new System.Text.StringBuilder();
                sb.Append("<html>");
                sb.AppendFormat("<body onload='document.forms[0].submit()'>");
                sb.AppendFormat("<form action='{0}' method='post'>", url);
                sb.AppendFormat("<input type='hidden' id='CustomerRef' name='CustomerRef' value='" + BookingID + "'>", BookingID);
                sb.AppendFormat("<input type='hidden' id='Amount' name='Amount' value='" + obj.TotalCost + "'>", obj.TotalCost);
                sb.AppendFormat("<input type='hidden' id='UserName' name='UserName' value='" + userName + "'>", userName);
                sb.AppendFormat("<input type='hidden' id='Password' name='Password' value='" + Password + "'>", Password);
                sb.AppendFormat("<input type='hidden' id='customername' name='customername' value='" + customerName + "'>", customerName);
                sb.AppendFormat("<input type='hidden' id='email' name='email' value='" + email + "'>", email);
                sb.AppendFormat("<input type='hidden' id='conventioncode' name='conventioncode' value='" + ConventionCode + "'>", ConventionCode);
                sb.AppendFormat("<input type='hidden' id='language' name='language' value='" + Language + "'>", Language);
                sb.AppendFormat("<input type='hidden' id='_currency' name='_currency' value='" + Currency + "'>", Currency);
                sb.Append("</form>");
                sb.Append("</body>");
                sb.Append("</html>");
                //Response.Write(sb.ToString());
                //Response.End();

                return Content(sb.ToString());
            }
            return null;            
        }

        public ActionResult Summery()
        {
            //try
            //{
                ReservationModel objModel = TempData["ReservationModel"] as ReservationModel;
                int roomID = Convert.ToInt32(objModel._roomType);

                objModel._room = _context.JW_Rooms.Where(w => w.RoomID == roomID).FirstOrDefault();

                int _packageId = Convert.ToInt32(objModel._packageType);

                if (objModel._packageType == "1")
                {
                    objModel._packageType = "7 Night Accomadation";
                }
                else if (objModel._packageType == "2")
                {
                    objModel._packageType = "8 Night Accomadation";
                }
                else if (objModel._packageType == "3")
                {
                    objModel._packageType = "9 Night Accomadation";
                }
                else if (objModel._packageType == "4")
                {
                    objModel._packageType = "10 Night Accomadation";
                }

                double additionalAC = 0;
                if (objModel._additionalList != null || objModel._additionalList.Count !=0)
                {
                    foreach (var item in objModel._additionalList)
                    {
                        int ID = Convert.ToInt32(item._addtionalRoom);
                        var ac = _context.JW_AdditionalRoomRates.Where(w => w.RoomID == ID).FirstOrDefault();
                        double _tempCost = ac.RoomRate.GetValueOrDefault(0) * item._addtionalNoOfNights * item._addtionalNoOfRooms;
                        additionalAC += _tempCost;
                    }
                }

                var cost = _context.JW_RoomRate.Where(w => w.RoomID == roomID && w.Occupancy == objModel._Occupancy && w.PackageId == _packageId).FirstOrDefault();
                objModel.PackageCost = (float)cost.RoomRate;
                objModel.AdditionalACCost = (float)additionalAC;

                float TotalCost = (float)cost.RoomRate + (float)additionalAC;
                objModel.TotalCost = TotalCost;

                JW_Delegates _delegate = new JW_Delegates();
                _delegate.BookingID = objModel.BookingID;
                _delegate.ContactNo = objModel._delegate.ContactNo;
                _delegate.Country = objModel._delegate.Country;
                _delegate.DelegeteName = objModel._delegate.Name;
                _delegate.Email = objModel._delegate.EmailAddress;
                _delegate.Nationality = objModel._delegate.Nationality;
                _delegate.PassportNo = objModel._delegate.PassportNo;
                _delegate.Title = objModel._delegate.Title;
                _delegate.Address = objModel._delegate.DelegateAddress;

                _context.JW_Delegates.Add(_delegate);
                _context.SaveChanges();

                JW_Reservation _reservation = new JW_Reservation();
                _reservation.HotelName = objModel._hotel.HotelName;
                _reservation.BookingID = objModel.BookingID;
                _reservation.ArrivalFlightNo = objModel._ArrivalFlightNumber;
                _reservation.DepartureFlightNo = objModel._DepartureFlightNumber;
                //_reservation.CheckInDate = objModel._ArrivalDate;
                //_reservation.CheckInTime = objModel._ArrivalTime;
                //_reservation.CheckOutDate = objModel._DepartureDate;
                //_reservation.CheckOutTime = objModel._DepartureTime;
                _reservation.IsArrivalTransportRequired = objModel._isArrival;
                _reservation.IsDepartureTransportRequired = objModel._isDeparture;
                _reservation.Roomtype = objModel._roomType;
                _reservation.Occupancy = objModel._Occupancy;
                _reservation.BedPreference = objModel._BedPerferance;
                _reservation.TotalCost = TotalCost;
                _reservation.IsAdvancePayment = objModel.isAdvancedPayment;

                _context.JW_Reservation.Add(_reservation);
                _context.SaveChanges();

                return View(objModel);
            //}
            //catch(Exception ex)
            //{
            //    return RedirectToAction("Registration", "Reservation", new { HotelCode = "CGC" });
            //}
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