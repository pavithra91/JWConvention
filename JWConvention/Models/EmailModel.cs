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

        public void SendEmail(EmailModel _email)
        {
            dynamic email = new Postal.Email("CustomerInvoice");
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

            if (_email.Transport != null)
            {
                email.Package = _email.Transport;
            }

            email.InvoiceNo = _email.BookingRef;
            email.BookingRef = _email.BookingRef;
            email.Amount = _email.Amount;
            email.ClientEmail = _email.ClientEmail;
            email.ClientName = _email.ClientName;
            email.DateofPayment = _email.DateofPayment.ToShortDateString();

            email.Send();
        }

    }
}