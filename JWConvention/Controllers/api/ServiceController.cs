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
        public virtual JsonResult DateCheck(string fromDate, string packageID)
        {
            try
            {
                DateTime _fromDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);

                int days = 0;
                if (packageID == "1")
                {
                    days = 6;
                }
                else if (packageID == "2")
                {
                    days = 7;
                }
                else if (packageID == "3")
                {
                    days = 8;
                }
                else if (packageID == "4")
                {
                    days = 9;
                }

                _fromDate = _fromDate.AddDays(days);
                string _testDate = _fromDate.ToString("dd/MM/yyyy");

                return Json(_testDate, JsonRequestBehavior.AllowGet);
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