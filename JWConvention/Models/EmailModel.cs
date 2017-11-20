using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWConvention.Models
{
    public class EmailModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string EmailCC { get; set; }
        public string EmailBCC { get; set; }
        public string BookingRef { get; set; }
        public double Amount { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public DateTime DateofPayment { get; set; }
        public string InvoiceNo { get; set; }
        public string PaymentStatus { get; set; }

        public string HotelName { get; set; }
        public string RoomCategory { get; set; }
        public string Transport { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string PackageType { get; set; }
        public double InvoiceAmount { get; set; }


        // Inquiry
        public string EmailTo { get; set; }
        public string FullName { get; set; }
        public string ContactNo { get; set; }
        public string Message { get; set; }
        public string TourName { get; set; }

        // Error Log
        public string ErrorMessage { get; set; }


        public void SendEmail(EmailModel _email, string TemplateName)
        {
            dynamic email = new Postal.Email(TemplateName);
            email.To = _email.ClientEmail;
            email.From = _email.From;

            if (_email.EmailBCC != null)
            {
                email.Cc = _email.EmailCC;
            }
            if (_email.EmailCC != null)
            {
                email.Bcc = _email.EmailBCC;
            }

            email.HotelName = _email.HotelName;
            email.RoomCategory = _email.RoomCategory;
            email.CheckIn = _email.CheckIn;
            email.CheckOut = _email.CheckOut;

            if (_email.PackageType != null)
            {
                email.Package = _email.PackageType;
            }

            email.InvoiceNo = _email.BookingRef;
            email.InvoiceAmount = _email.InvoiceAmount;
            email.BookingRef = _email.BookingRef;
            email.Amount = _email.Amount;
            email.ClientEmail = _email.ClientEmail;
            email.ClientName = _email.ClientName;
            email.DateofPayment = _email.DateofPayment.ToShortDateString();

            email.Send();
        }

        public void SendInquiry(EmailModel _email, string TemplateName)
        {
            dynamic email = new Postal.Email(TemplateName);
            email.To = _email.EmailTo;
            email.From = "reservatio@jkintranet.com";// _email.From;

            if (_email.EmailCC != null)
            {
                email.Cc = _email.EmailCC;
            }

            if (_email.EmailBCC != null)
            {
                email.Bcc = _email.EmailBCC;
            }

            email.FullName = _email.FullName;
            email.ContactNo = _email.ContactNo;
            email.Message = _email.Message;
            email.TourName = _email.TourName;
            email.Email = _email.ClientEmail;

            email.Send();
        }

        public void SendError(EmailModel _email, string TemplateName)
        {
            dynamic email = new Postal.Email(TemplateName);
            email.To = _email.EmailTo;
            email.From = "reservatio@jkintranet.com";// _email.From;

            if (_email.EmailCC != null)
            {
                email.Cc = _email.EmailCC;
            }

            if (_email.EmailBCC != null)
            {
                email.Bcc = _email.EmailBCC;
            }

            email.ErrorMessage = _email.ErrorMessage;

            email.Send();
        }
    }
}