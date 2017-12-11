using JWConvention.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWConvention.Controllers
{
    public class BackEndController : Controller
    {
        wlakerstoursdbEntities _context = new wlakerstoursdbEntities();
        // GET: BackEnd
        public ActionResult Login()
        {
            LoginModel objModel = new LoginModel();
            return View(objModel);
        }

        [HttpPost]
        public ActionResult UserLogin(LoginModel _objLogin)
        {
            var _user = _context.JW_Users.Where(w => w.UserName.ToUpper() == _objLogin.UserName.ToUpper() && w.Password == _objLogin.Password && w.IsActive == true).FirstOrDefault();

            if(_user != null)
            {
                Session["UserName"] = _user.UserName;
                return RedirectToAction("Index", "BackEnd");
            }
            else
            {
                return RedirectToAction("Login", "BackEnd");
            }
        }

        public ActionResult Index()
        {
            try
            {
                if (Session["UserName"].ToString() != null)
                {
                    GroupModel objModel = new GroupModel();
                    objModel.groupList = _context.JW_GroupID.ToList();
                    return View(objModel);

                }
                else
                {
                    return RedirectToAction("Login", "BackEnd");
                }
            }
            catch
            {
                return RedirectToAction("Login", "BackEnd");
            }
        }

        [HttpPost]
        public ActionResult SaveGroupId(GroupModel objModel)
        {
            if (Session["UserName"].ToString() != null)
            {
                JW_GroupID _groupID = new JW_GroupID();
                _groupID.GroupID = objModel.GroupID;
                _groupID.AddedDate = DateTime.Now;
                _groupID.AddedBy = Session["UserName"].ToString();
                _context.JW_GroupID.Add(_groupID);
                _context.SaveChanges();

                return RedirectToAction("Index", "BackEnd");
            }
            else
            {
                return RedirectToAction("Login", "BackEnd");
            }
        }


        public ActionResult Amendments(ReservationModel objModel)
        {
            //objModel = null;
            return View(objModel);
        }

        [HttpPost]
        public ActionResult SearchAmendments(string BookingID)
        {
            ReservationModel objModel = new ReservationModel();

            var _jwBooking = _context.JW_Reservation.Where(w => w.BookingID == BookingID).FirstOrDefault();

            if(_jwBooking != null)
            {
                objModel.BookingID = BookingID;
                objModel.PackageCost = (double)_jwBooking.TotalCost;
                objModel._hotel = _context.JW_Hotels.Where(w => w.HotelName == _jwBooking.HotelName).FirstOrDefault();
                objModel._ArrivalDate = _jwBooking.ArrivalDate.GetValueOrDefault().ToShortDateString();
                objModel._DepartureDate = _jwBooking.DepartureDate.GetValueOrDefault().ToShortDateString();
                objModel._fromDate = _jwBooking.CheckInDate.GetValueOrDefault().ToShortDateString();
                objModel._toDate = _jwBooking.CheckOutDate.GetValueOrDefault().ToShortDateString();

                return View(objModel);
            }

            return View();
        }
    }
}