using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWConvention.Controllers.api
{
    public class ServiceController : Controller
    {
        wlakerstoursdbEntities _context = new wlakerstoursdbEntities();
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual JsonResult DateCheck(string fromDate, string endDate)
        {
            try
            {
                DateTime _fromDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);
                DateTime _toDate = DateTime.ParseExact(endDate, "dd/MM/yyyy", null);

                int days = 0;
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

                if (_toDate ==_7dayPackage)
                {
                    _packageDays += 7;
                    _afterDays = (_toDate - _7dayPackage).TotalDays;
                    TotalCost = (double)_context.JW_RoomRate.Where(w => w.PackageId == 1).FirstOrDefault().RoomRate;
                }
                else if(_toDate > _7dayPackage && _toDate <= _8dayPackage)
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
                else if(_toDate > _10dayPackage)
                {
                    _packageDays += 10;
                    _afterDays = (_toDate - _10dayPackage).TotalDays;
                    TotalCost = (double)_context.JW_RoomRate.Where(w => w.PackageId == 4).FirstOrDefault().RoomRate;
                }


                return Json(new {BeforeDays = _beforeDays, PackageDays = _packageDays, AfterDays = _afterDays, TotalCost = TotalCost }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public virtual JsonResult GetHotelRooms(string HotelId)
        {
            try
            {
                var hotel = _context.JW_Hotels.Where(w => w.HotelName == HotelId).FirstOrDefault();

                return Json(
                    _context.JW_Rooms.Where(w => w.HotelID == hotel.HotelID).Select(x => new
                    {
                        id = x.RoomID,
                        name = x.RoomType
                    }), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return null;
            }
        }
    }
}