using JWConvention.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWConvention.Controllers
{
    public class ToursController : Controller
    {
        wlakerstoursdbEntities _context = new wlakerstoursdbEntities();
        // GET: Tours
        public ActionResult TourSummary()
        {
            return View();
        }

        public ActionResult Colombo_Loving()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Colombo_Loving";
            return View(objModel);
        }

        public ActionResult Exotic_Sri_Lanka()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Exotic_Sri_Lanka";
            return View(objModel);
        }

        public ActionResult Fly_Swim_Shop()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Fly_Swim_Shop";
            return View(objModel);
        }

        public ActionResult Heritage_Sri_Lanka()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Heritage_Sri_Lanka";
            return View(objModel);
        }

        public ActionResult Into_The_Hills()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Into_The_Hills";
            return View(objModel);
        }

        public ActionResult South_Coast_Adventure()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "South_Coast_Adventure";
            return View(objModel);
        }

        public ActionResult Udawalawe_Day_Excursion()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Udawalawe_Day_Excursion";
            return View(objModel);
        }

        public ActionResult Whale_Watching_Excursion()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Whale_Watching_Excursion";
            return View(objModel);
        }

        public ActionResult Yala_Day_Excursion()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Yala_Day_Excursion";
            return View(objModel);
        }

        public ActionResult Island_Highlights()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Island_Highlights";
            return View(objModel);
        }

        public ActionResult Island_Paradise()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Island_Paradise";
            return View(objModel);
        }

        public ActionResult Island_Quick_Fix()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Island_Quick_Fix";
            return View(objModel);
        }

        public ActionResult Hill_Country_Comfort()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Hill_Country_Comfort";
            return View(objModel);
        }

        public ActionResult Central_Highlands()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Central_Highlands";
            return View(objModel);
        }

        public ActionResult Maldives_Tours()
        {
            InquiryModel objModel = new InquiryModel();
            objModel.TourName = "Maldives_Tours";
            return View(objModel);
        }

        [HttpPost]
        public ActionResult SendInquiry(InquiryModel objModel)
        {
            try
            {
                IPGConfig ipg =  _context.IPGConfigs.Where(w => w.ConventionCode == "JWCON").FirstOrDefault();

                EmailModel em = new EmailModel();
                em.FullName = objModel.FullName;
                em.EmailTo = ipg.EmailTo;
                em.ClientEmail = objModel.Email;
                em.ContactNo = objModel.ContactNo;
                em.Message = objModel.Message;
                em.TourName = objModel.TourName.Replace("_", " ");
                em.EmailCC = ipg.EmailCC;
                em.EmailBCC = ipg.EmailBCC;

                em.SendInquiry(em, "Inquiry");

                EmailModel clientCopy = new EmailModel();
                clientCopy.FullName = objModel.FullName;
                em.EmailTo = objModel.Email;
                clientCopy.ClientEmail = objModel.Email;
                clientCopy.ContactNo = objModel.ContactNo;
                clientCopy.Message = objModel.Message;
                clientCopy.TourName = objModel.TourName.Replace("_", " ");
                clientCopy.EmailCC = ipg.EmailCC;
                clientCopy.EmailBCC = ipg.EmailBCC;
                clientCopy.EmailTo = objModel.Email;

                clientCopy.SendInquiry(clientCopy, "InquiryCustomer");

                return RedirectToAction("TourSummary", "Tours");
            }
             catch(Exception ex)
            {
                return null;
            }
        }
    }
}